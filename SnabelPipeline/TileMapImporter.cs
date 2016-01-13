using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using System.Xml;

using Snabel_Engine;
using Snabel_Engine.TileEngine;
using Snabel_Engine.Managers;
using Snabel_Engine.Components;

namespace SnabelPipeline
{
    [ContentImporter(".snab", DisplayName = "Snabel Tile Importer",
        DefaultProcessor = "TileMapProcessor")]
    public class TileMapImporter : ContentImporter<XmlDocument>
    {
        public override XmlDocument Import(
            string filename, ContentImporterContext context)
        {
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            return document;
        }
    }
}
