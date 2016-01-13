using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Snabel_Engine
{
    public class TextureManager
    {
        public enum LevelContentState
        {
            Level01,
            Level02,
            Level03,
            Level04,
            Level05,
            Level06,
            Level07,
            Level08,
            Level09,
            Level10,
        }

        LevelContentState currContentLevel = LevelContentState.Level01;


        //Class var.
        private static ContentManager content;
        private SpriteBatch spriteBatch;


        //Sprite Content SpriteSheets
        public Texture2D animationTexture;
        public Texture2D moodyIdle;
        public Texture2D moodyRightWalk;
        public Texture2D moodyLeftWalk;
        public Texture2D moodyJump;
        
        //TileTextures.
        public Texture2D tileTexturesLvl01;

        //NPCs SpriteSheets
        

        //Object Textures
        public Texture2D fireFly;

        //HUD
        //Menus
        //Buttons

        public TextureManager()
        {
            
        }

        public void SpriteContent(ContentManager content)
        {
            //Player
            moodyIdle = content.Load<Texture2D>("Textures\\Characters\\moodyIdleSheet");
            //moodyRightWalk = content.Load<Texture2D>("Textures\\Characters\\moody\\moodyIdleSheet");
            //moodyLeftWalk = content.Load<Texture2D>("Textures\\Characters\\moody\\moodyIdleSheet");
            //moodyJump = content.Load<Texture2D>("Textures\\Characters\\moody\\moodyIdleSheet");
           
        }

        public void NPSpriteContent(ContentManager content)
        {

        }
        public void ObjectsContent(ContentManager content)
        {

        }


        public void LevelTilesContent(ContentManager content)
        {
            switch (currContentLevel)
            {
                case LevelContentState.Level01:
                    tileTexturesLvl01 = content.Load<Texture2D>("");
                    //tileTextures = content.Load<Texture2D>("");
                    //tileTextures = content.Load<Texture2D>("");
                    //tileTextures = content.Load<Texture2D>("");
                    //tileTextures = content.Load<Texture2D>("");
                    break;

                case LevelContentState.Level02:
                    tileTexturesLvl01 = content.Load<Texture2D>("");
                    break;
            }



            
        }

    }
}
