using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using System.Xml;

using Snabel_Engine;
using Snabel_Engine.TileEngine;
using Snabel_Engine.Managers;
using Snabel_Engine.Components;

namespace SnabelPipeline
{
    [ContentTypeWriter]
    public class TileMapWriter : ContentTypeWriter<TileMap>
    {
        protected override void Write(ContentWriter output, TileMap value)
        {
            output.Write(value.MapWidth);
            output.Write(value.MapHeight);
            output.Write(value.AssetName);
            for (int x = 0; x < value.MapWidth; x++)
            {
                for (int y = 0; y < value.MapHeight; y++)
                {
                    output.Write(value.GetIndex(x, y));
                }
            }
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return typeof(TileMapReader).AssemblyQualifiedName;
                //"Snabel_Engine.TileEngine.TileMapReader, Snabel_Engine.TileEngine";
        }
    }
}