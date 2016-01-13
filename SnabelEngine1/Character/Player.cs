using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Snabel_Engine.SnabelTile;

using Snabel_Engine.Components;

using Snabel_Engine.Managers;


namespace Snabel_Engine
{
    public class Player : GameObject, IDeepCloneable
    {

        [ContentSerializerIgnore]
        TextureManager textureManager;

        //Get or Set armor of the player
        [ContentSerializerIgnore]
        public Armor Armor { get; set; }
        ////Texture

        [ContentSerializerIgnore]
        public Texture2D Texture { get; set; }
        // Gets or sets the name of the Armor asset
        [ContentSerializerIgnore]
        public Texture2D jumpParticle { get; set; }

        public string ArmorAsset { get; set; }
        //Gets or set the name of the texture
        public string TextureAsset { get; set; }

        public string jParticleAsset { get; set; }

        [ContentSerializerIgnore]
        public Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        [ContentSerializerIgnore]
        public Rectangle PlayerRectangle;

        [ContentSerializerIgnore]
        public Rectangle animationRectangle;


        [ContentSerializerIgnore]
        public Vector2 velocity;


        [ContentSerializerIgnore]
        private Vector2 originalPosition;

        //Creates a deep clone of the current player.
        //Returns a copy of the current pl..

        //Animation
        [ContentSerializerIgnore]
        Rectangle debugRectangle;
        [ContentSerializerIgnore]
        Texture2D debugTextureRect;



        public virtual object Clone()
        {
            Player p = new Player();

            //Base Class.
            p.Name = this.Name;

            //Player Class
            p.Armor = this.Armor.Clone() as Armor;
            p.ArmorAsset = this.ArmorAsset;
            p.TextureAsset = this.TextureAsset;
            p.Texture = this.Texture;
            p.Position = this.Position;
            p.jParticleAsset = this.jParticleAsset;
            p.jumpParticle = this.jumpParticle;
            p.textureManager = this.textureManager;


            return p;

        }


        public Player()
        {



        }


        public class PlayerContentReader : ContentTypeReader<Player>
        {
            protected override Player Read(ContentReader input, Player existingInstance)
            {
                Player player = existingInstance;

                if (player == null)
                {
                    player = new Player();
                }

                player.Name = input.ReadString();
                player.ArmorAsset = input.ReadString();
                player.Armor = input.ContentManager.Load<Armor>(player.ArmorAsset).Clone() as Armor;
                player.TextureAsset = input.ReadString();
                player.Texture = input.ContentManager.Load<Texture2D>("Textures\\Characters\\" + player.TextureAsset);
                player.jParticleAsset = input.ReadString();
                player.jumpParticle = input.ContentManager.Load<Texture2D>("Textures\\Particles\\" + player.jParticleAsset);
                player.Position = input.ReadVector2();
                //player.Velocity = input.ReadVector2();
                //player.MaxVelocity = input.ReadVector2();
                //player.Gravity = input.ReadSingle();
                //player.Friction = input.ReadVector2();
                //player.Acceleration = input.ReadVector2();
                //player.Decceleration = input.ReadVector2();

                return player;

            }

        }

        public void Initialize()
        {
            
        }

        public virtual void LoadContent(ContentManager content)
        {

            debugTextureRect = content.Load<Texture2D>("Textures\\Debug\\debug_70_70");

  
        }

        public void Update(GameTime gameTime, Player player, InputManager input)
        {


            PlayerRectangle = new Rectangle((int)Position.X, (int)Position.Y, 64,64);
            ////PlayerRectangle = new Rectangle(currentFrame * frameWidth,0, frameWidth, frameHeight);
            debugRectangle = new Rectangle((int)Position.X, (int)Position.Y, 64, 64);
            position += velocity;

            InputControl(gameTime, input);

            PhysicsCheck(gameTime);

        }


        public void InputControl(GameTime gameTime, InputManager input)
        {

            KeyboardState keybState = Keyboard.GetState();
            KeyboardState oldState = Keyboard.GetState();  // get the newest state
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            moveSpeed = 400f;

                if (IsActive)
                {
                    if (keybState.IsKeyDown(Keys.Space) && OnGround == true && hasJumped == false && canJump == true && collidingBottom == true)
                    {
                        position.Y += -10f;
                        velocity.Y = -8f;
                        OnGround = false;
                        canJump = false;
                        hasJumped = true;
                        canClimb = false;
                        isClimbing = false;
                        collidingBottom = false;
                    }

                    if (keybState.IsKeyDown(Keys.D))
                    { 
                        velocity.X = +moveSpeed * elapsed;

                    }
                    else if (keybState.IsKeyDown(Keys.A))
                    {
                        
                        velocity.X = -moveSpeed * elapsed;

                    }
                    else
                    {
                        velocity.X = 0;
                    }
                    //velocity.Y = MathHelper.Clamp(velocity.Y + GravityAccel * elapsed, -MaxFallSpeed, MaxFallSpeed);

                }
            }



        private void PhysicsCheck(GameTime gameTime)
        {
            activateGravity = true;

            if (velocity.Y == 0)
            {
                OnGround = true;
                canJump = true;
                hasJumped = false;
                canClimb = true;
                isClimbing = false;
                collidingBottom = true;
            }
            else
            {
                OnGround = false;
                canJump = false;
                hasJumped = true;
                canClimb = false;
                isClimbing = false;

            }

            if (velocity.Y < 10)
                velocity.Y += 0.4f;

        }
        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {

            if (PlayerRectangle.TouchTopOf(newRectangle))
            {
                PlayerRectangle.Y = newRectangle.Y - PlayerRectangle.Height;
                velocity.Y = 0f;
                collidingTop = true;
                //hasJumped = false;

            }
            if (PlayerRectangle.TouchLeftOf(newRectangle))
            {
                position.X = newRectangle.X - PlayerRectangle.Width - 2;
                collidingLeft = true;
            }
            if (PlayerRectangle.TouchRightOf(newRectangle))
            {
                position.X = newRectangle.X + newRectangle.Width + 2;
                collidingRight = true;
            }
            if (PlayerRectangle.TouchBottomOf(newRectangle) && OnGround == false && hasJumped == true && canJump == false)

                OnGround = true;
            canJump = true;
            hasJumped = false;
            canClimb = true;
            isClimbing = false;
            collidingBottom = true;

            if (position.X < 0) position.X = 0f;
            if (position.X > xOffset - PlayerRectangle.Width) position.X = xOffset - PlayerRectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - PlayerRectangle.Height) position.Y = yOffset - PlayerRectangle.Height;

        }


        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //// Flip the sprite to face the way we are moving.
            if (velocity.X < 0)
                flip = SpriteEffects.FlipHorizontally;
            else if (velocity.X > 0)
                flip = SpriteEffects.None;

            //spriteBatch.Draw(animationTexture, position, PlayerRectangle, Color.White, 0f, originalPosition, 1.0f, flip, 0f);
            //spriteBatch.Draw(spriteManager.Texture, moodyIdle.Position, PlayerRectangle, Color.White, 0f, new Vector2(0, 0), 1.0f, flip, 1f);
            //spriteBatch.Draw(animationTexture, rectangle, null, Color.White, 0, new Vector2(0, 0), flip, 0);

            spriteBatch.Draw(debugTextureRect, debugRectangle, null, Color.White, 0, new Vector2(0, 0), flip, 0);

        }
    }
}

