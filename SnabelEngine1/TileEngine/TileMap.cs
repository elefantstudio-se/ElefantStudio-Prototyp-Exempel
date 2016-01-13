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
    public class TileMap
    {
       
        //Texture från XML.
        public string _assetName = "";
        public Texture2D _spriteSheet;
        public Texture2D _collRectTexture;

        //TileMap Egenskaper, fält.
        int[,] _textureGrid;
        public int _tileWidth = 32;
        public int _tileHeight = 32;
        public int _tilesPerRow = 2;
        //Rectangles
        public Rectangle _drawRectangle = new Rectangle();
        public Rectangle _sourceRectangle = new Rectangle();
        //List
        public List<Rectangle> collisionRects = new List<Rectangle>();
        public List<Rectangle> tileSet = new List<Rectangle>();

        public int TilesPerRow
        {
            get { return _tilesPerRow; }
            set { _tilesPerRow = value; }
        }
        public int MapWidth
        {
            get { return _textureGrid.GetLength(1); }
        }
        public int MapHeight
        {
            get { return _textureGrid.GetLength(0); }
        }
        public string AssetName
        {
            get { return _assetName; }
            set { _assetName = value; }
        }
    
        public TileMap(int width, int height)
        {
            _textureGrid = new int[height, width];
            _drawRectangle.Width = _sourceRectangle.Width = _tileWidth;
            _drawRectangle.Height = _sourceRectangle.Height = _tileHeight;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < _textureGrid.GetLength(1); x++)
            {
                for (int y = 0; y < _textureGrid.GetLength(0); y++)
                {
                    _drawRectangle.X = x * _tileWidth;
                    _drawRectangle.Y = y * _tileHeight;
                    _sourceRectangle.X = (_textureGrid[y, x] % _tilesPerRow) * _tileWidth;
                    _sourceRectangle.Y = (_textureGrid[y, x] / _tilesPerRow) * _tileHeight;
                    spriteBatch.Draw(
                        _spriteSheet,
                        _drawRectangle,
                        _sourceRectangle,
                        Color.White);

                    
                }
            }
        }
        public void SetTextures(Texture2D spriteSheet)//, string assetName)
        {
            _spriteSheet = spriteSheet;
        }
        public int GetIndex(int x, int y)
        {
            return _textureGrid[y, x];
        }
        public void SetIndex(int x, int y, int value)
        {
            _textureGrid[y, x] = value;
        }
    }
}