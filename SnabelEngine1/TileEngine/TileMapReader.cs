using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Snabel_Engine;
using Snabel_Engine.Components;

namespace Snabel_Engine.TileEngine
{
    public class TileMapReader : ContentTypeReader<TileMap>
    {

        
        protected override TileMap Read(ContentReader input, TileMap existingInstance)
        {
            TileMap tileMap = new TileMap(input.ReadInt32(), input.ReadInt32());
            tileMap.collisionRects = new List<Rectangle>();

            string assetName = input.ReadString();
            string path = "Levels\\Level1\\";
            tileMap.SetTextures(
                input.ContentManager.Load<Texture2D>(path+assetName));
            
            for (int x = 0; x < tileMap.MapWidth; x++)
            {
                for (int y = 0; y < tileMap.MapHeight; y++)
                {
                        tileMap.SetIndex(x, y, input.ReadInt32());
                        tileMap.collisionRects.Add(new Rectangle(x * tileMap._tileWidth, y * tileMap._tileHeight, tileMap._tileWidth, tileMap._tileHeight));
                }
            }
            return tileMap;
        }
    }
}