using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Snabel_Engine.Components
{
    public class Frame
    {
        public TimeSpan Duration { get; set; }
        public Rectangle Rectangle { get; set; }
        public Vector2 PositionOffset { get; set; }

        [ContentSerializerIgnore]
        public Vector2 Center
        {
            get
            {
                return new Vector2(this.Rectangle.Width / 2.0f, this.Rectangle.Height / 2.0f);
            }

        }
    }
}