using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Snabel_Engine;
using Snabel_Engine.Components;

namespace Snabel_Engine.SnabelTile
{
    public class Tiles
    {
        public Texture2D texture;
        private Vector2 screenCenter;
        protected Texture2D nullTexture;
        private Viewport viewport;
        private Rectangle rectangle;
        //private TextureManager textureManager;
       
        
        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            screenCenter = new Vector2(viewport.Bounds.Width / 2, viewport.Bounds.Height / 2);
            
            spriteBatch.Draw(texture,rectangle,Color.White);
        }

        public class CollisionTiles : Tiles
        {
            public int num;

            public CollisionTiles(int i, Rectangle newRectangle)
            {
                // Tile + i ( Laddar namnet "Tile" och nr... ex. Tile1, Tile2...
                num = i;
                texture = Content.Load<Texture2D>("Levels\\Level01\\Tile" + i);
                this.Rectangle = newRectangle;
            }
        }

    }
}
