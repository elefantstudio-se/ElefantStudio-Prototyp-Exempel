using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.IO;
using System.Collections.Generic;
using Snabel_Engine.Components;


namespace Snabel_Engine
{
    public abstract class GameObject
    {
        //-----------------Player Constructers-----------------//
        public string Name { get; set; }
        //Physics
        protected float moveSpeed;
        protected float movement;
        protected Vector2 prevPosition;
        protected const float MoveAccel = 500.0f;
        protected const float GravityAccel = 100.0f;
        protected const float MaxFallSpeed = 600f;
        
        // Constants for controlling vertical movement
        protected float minVelocity;
        protected float maxVelocity;

        protected float jumpSpeed = 1500f;
        protected float jumpPower = -180.0f;
        protected float jumpMaxTime = 0.25f;
        protected float jumpInitialTime = 0.065f;

        protected float Orientation;
        protected static Random rand = new Random();

        public static bool activateGravity;
        public static bool IsActive = true;
        public static bool hasJumped;
        public static bool canJump;
        public static bool OnGround;
        public static bool canClimb = false;
        public static bool isClimbing = false;
        public static bool collidingLeft;
        public static bool collidingRight;
        public static bool collidingTop;
        public static bool collidingBottom;
        public static bool collidingObject;
        protected bool isPlayerControlled = true;

        //Sprite Settings
        protected SpriteEffects flip = SpriteEffects.None;
        

        //---------------------------[END]-----------------------//
        public static Game Instance { get;  set; }
        public static Viewport Viewport { get { return Instance.GraphicsDevice.Viewport; } }
        public static Vector2 ScreenSize { get { return new Vector2(Viewport.Width, Viewport.Height); } }
        public static GameTime GameTime { get;  set; }
        public static ContentManager content { get; set; }
        public static GraphicsDevice graphics { get; set; }

        //-----------------World Constructers-----------------//

        protected const float gravity = 100f; //100f;
        //---------------------------[END]--------------------//


        //----------------------Blandat skit---------------------//
        protected int score;
        protected int health;
        protected Game Game;
        //---------------------------[END]-----------------------//

        //----------------------Game Cons.-----------------------//

        public static List<int> treasuresCollected = new List<int> { };
        public static Dictionary<int, int> treasuresCollectedPersistant = new Dictionary<int, int>();

        //public static int[] multiplayerSelectedCharacters = { 0, 0, 0, 0 };
        //---------------------------[END]-----------------------//

        /// <summary>
        /// Fucks up everything
        /// </summary>
        public static bool PIRATE_COPY = false;


        public GameObject()
        {
            this.Name = this.GetHashCode().ToString();
            
        }

        public GameObject(string name)
        {
            this.Name = name;
            
        }

        
        
    }
}