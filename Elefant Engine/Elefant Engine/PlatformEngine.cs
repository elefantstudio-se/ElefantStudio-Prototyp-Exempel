using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

using Snabel_Engine.SnabelTile;
using Snabel_Engine.Components;

using Snabel_Engine.Managers;

using Snabel_Engine;
using System.IO;


namespace SnabelEngine
{
    public class PlatformEngine : Game
    {
        private GraphicsDeviceManager mGraphics;
        private SpriteBatch spriteBatch;
        //private ContentManager contentR;

        bool GameDebug = true;
        bool playerDebug = true;

        

        //Vectors Grafik Fonter
        SpriteFont spriteFont;
        SpriteFont spriteFontBold;
        
        //Levels
        Map map;
        
        //Spelare
        Player player;
        //Player2 player2;
        Weapon weaponXML;
        Armory armoryXML;

        InputManager input;

        //Camera
        Camera camera;
        Rectangle mapView;
        
        //Test.. Diverse
        Vector2 screenCenter;
        

        

        // We store our input states so that we only poll once per frame, 
        // then we use the same input state wherever needed
        private KeyboardState keyboardState;
        private AccelerometerState accelerometerState;


        public PlatformEngine()
        {
            mGraphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            

            mGraphics.PreferredBackBufferWidth = 1280;
            mGraphics.PreferredBackBufferHeight = 720;
            mGraphics.IsFullScreen = false;
            mGraphics.PreferMultiSampling = false;
            IsFixedTimeStep = false;
            IsMouseVisible = true;

            mGraphics.ApplyChanges();
            //FPS Debug..
            FPS FrameRateCounter = new FPS(this, "Fonts/DebugFontBold", Content);
            Components.Add(FrameRateCounter);
        }

        protected override void Initialize()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map = new Map();
            input = new InputManager();
            player = new Player();
            camera = new Camera(GraphicsDevice.Viewport);
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Tiles.Content = Content;
            
            //Laddar från XML 
            weaponXML = Content.Load<Weapon>("XMLConfigs\\Weapons\\Weapon_Basic");
            armoryXML = Content.Load<Armory>("XMLConfigs\\Armory\\Armory_Basic");

            //Fonts
            spriteFont = Content.Load<SpriteFont>("Fonts/DebugFont");
            spriteFontBold = Content.Load<SpriteFont>("Fonts/DebugFontBold");

            //player2 = Content.Load<Player2>("XMLConfigs\\Player\\Player2").Clone() as Player2;

            map.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            }, 64);
            
            player = Content.Load<Player>("XMLConfigs\\Player\\Player1");
            player.LoadContent(Content);

            GC.Collect();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) this.Exit();



            

            foreach (Tiles.CollisionTiles tiles in map.CollisionTiles)
            {
                
                player.Collision(tiles.Rectangle, map.Width, map.Height);
                
                camera.Update(player.Position, map.Width, map.Height);       
            }
            player.Update(gameTime, player, input);
            
            base.Update(gameTime);
            
        }
        
        //public static string ToString(bool value);
        
        
        protected override void Draw(GameTime gameTime)
        {

            //Bools
            //Playerstates
            bool isActive = GameObject.IsActive;
            bool activateGravity = GameObject.activateGravity;
            bool canJump = GameObject.canJump;
            bool hasJumped = GameObject.hasJumped;
            bool OnGround = GameObject.OnGround;
            bool canClimb = GameObject.canClimb;
            bool isClimbing = GameObject.isClimbing;
            bool isCollBottom = GameObject.collidingBottom;

            GraphicsDevice.Clear(Color.LightBlue);
            Viewport viewport = mGraphics.GraphicsDevice.Viewport;
            screenCenter = new Vector2(viewport.Bounds.Width / 2, viewport.Bounds.Height / 2);
            Rectangle fullscreen = new Rectangle(0, 0, viewport.Width, viewport.Height);

            //Skall in i egen Class sen....
            //GC Output ( realtime ) 
            //int generation = 0;
            bool forceFullCollection = true;
            ulong bytes = (ulong)GC.GetTotalMemory(forceFullCollection);
            string mb = ConvertToMegabytes(bytes);
            string GCOutput = " ---[L] Minne: " + mb;
            string playerPsXDebug = " ---PlayerPos X: " + player.Position.X.ToString();
            string playerPsYDebug = " ---PlayerVel Y: " + player.velocity.Y.ToString();
            //Playerstates
            string playerisActive = " ---Active?: " + isActive.ToString();
            string playerGravity = " ---Gravity?: " + activateGravity.ToString();
            string playercanJump = " ---canJump?: " + canJump.ToString();
            string playerhasJumped = " ---hasJumped? " + hasJumped.ToString();
            string playerOnGround = " ---OnGround?: " + OnGround.ToString();
            string playercanClimb = " ---canClimb?: " + canClimb.ToString();
            string playerisClimb = " ---isClimbing?: " + isClimbing.ToString();
            string playerCollidingY = " ---CollidesY?--> " + "BOTTOM: " + isCollBottom.ToString();
            string playerCollidingX = " ---CollidesX?--> " + "Inte implenterat..";
            //PlayerINFO, abilities etc.
            string playerName = " ---Active Player: " + player.Name.ToString();
            string playerArmory = " ---Armory Name: " + armoryXML.Name.ToString();
            string playerWeapons = " ---Weapons: " + weaponXML.Name.ToString();

            // Render in immediate mode to allow easy tiling of textures if needed.
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
            map.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(
                SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                camera.Transform);
            player.Draw(spriteBatch, gameTime);
            spriteBatch.End();
            
            

            if(GameDebug)
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            //Garbage Memory allocation In real time.
            spriteBatch.DrawString(spriteFontBold," [ G A M E I N F O ] ",new Vector2(5,5), Color.Black);
            spriteBatch.DrawString(spriteFont, GCOutput, new Vector2(10, 15), Color.Black);
            spriteBatch.DrawString(spriteFont, playerPsXDebug, new Vector2(10, 35), Color.Black);
            spriteBatch.DrawString(spriteFont, playerPsYDebug, new Vector2(10, 45), Color.Black);
            spriteBatch.DrawString(spriteFont, playerCollidingY, new Vector2(10, 55), Color.Black);
            spriteBatch.DrawString(spriteFont, playerCollidingX, new Vector2(10, 65), Color.Black);
            spriteBatch.End();
            

            if(playerDebug)
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.DrawString(spriteFontBold, " [ P L A Y E R S T A T E S ]", new Vector2(10, 75), Color.Black);
            spriteBatch.DrawString(spriteFont, playerisActive, new Vector2(10, 95), Color.Black);
            spriteBatch.DrawString(spriteFont, playerGravity, new Vector2(10, 105), Color.Black);
            spriteBatch.DrawString(spriteFont, playercanJump, new Vector2(10, 115), Color.Black);
            spriteBatch.DrawString(spriteFont, playerhasJumped, new Vector2(10, 125), Color.Black);
            spriteBatch.DrawString(spriteFont, playerOnGround, new Vector2(10, 135), Color.Black);
            spriteBatch.DrawString(spriteFont, playercanClimb, new Vector2(10, 145), Color.Black);
            spriteBatch.DrawString(spriteFont, playerisClimb, new Vector2(10, 155), Color.Black);
            spriteBatch.DrawString(spriteFontBold, " [ P L A Y E R E N T I T I E S ]", new Vector2(10, 185), Color.Black);
            spriteBatch.DrawString(spriteFont, playerName, new Vector2(10, 205), Color.Black);
            spriteBatch.DrawString(spriteFont, playerArmory, new Vector2(10, 215), Color.Black);
            spriteBatch.DrawString(spriteFont, playerWeapons, new Vector2(10, 225), Color.Black);
            spriteBatch.End();

            
            
            
            base.Draw(gameTime);

        }


        static string ConvertToMegabytes(ulong bytes)
        {
            return ((decimal)bytes / 1024M / 1024M).ToString("F1") + "MB";
        }

        
    }
}