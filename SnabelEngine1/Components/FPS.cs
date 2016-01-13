using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XnaContentManager = Microsoft.Xna.Framework.Content.ContentManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Snabel_Engine.Components
{
    public class FPS : DrawableGameComponent
    {
        #region Fields
        public XnaContentManager Content;
        ContentManager content;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        string fontName;

        Vector2 fpsPos;
        int frameRate = 0;
        int frameCounter = 0;
        TimeSpan elapsedTime = TimeSpan.Zero;

        #endregion

        #region Initialization

        public FPS(Game game, string fullFontName, XnaContentManager xnaContent)
            : base(game)
        {
            Content = xnaContent;
            Content.RootDirectory = "Content";
            fontName = fullFontName;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Content.Load<SpriteFont>("Fonts/DebugFontBold");
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        #endregion

        #region Update and Draw

        public override void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            frameCounter++;

            string fps = string.Format("{0}    Nuvarande FPS", frameRate);

            spriteBatch.Begin();

            fpsPos = new Vector2((GraphicsDevice.Viewport.Width - spriteFont.MeasureString(fps).X) - 15, 10);
            spriteBatch.DrawString(spriteFont, fps, fpsPos, Color.MediumPurple);

            spriteBatch.End();
        }

        #endregion
    }
}