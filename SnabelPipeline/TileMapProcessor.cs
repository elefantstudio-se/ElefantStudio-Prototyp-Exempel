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
using System.IO;

using Snabel_Engine;
using Snabel_Engine.TileEngine;
using Snabel_Engine.Managers;
using Snabel_Engine.Components;

namespace SnabelPipeline
{
    [ContentProcessor(DisplayName = "Snabel Tile Processor")]
    public class TileMapProcessor : ContentProcessor<XmlDocument, TileMap>
    {
        public override TileMap Process(
            XmlDocument input, ContentProcessorContext context)
        {

            XmlNodeList inputNodeList = input.GetElementsByTagName("TileMap");
            TileMap output = new TileMap(
                int.Parse(inputNodeList[0].Attributes["Width"].Value),
                int.Parse(inputNodeList[0].Attributes["Height"].Value));
            XmlNodeList nodeList = inputNodeList[0].ChildNodes;

            string[] layout;
            string[] rowEntries;

            foreach (XmlNode node in nodeList)
            {
                if (node.Name == "Layout")
                {
                    layout = node.InnerText.Trim().Split('\n');
                    for (int row = 0; row < layout.Length; row++)
                    {
                        rowEntries = layout[row].Trim().Split(' ');
                        for (int rowEntry = 0; rowEntry < rowEntries.Length; rowEntry++)
                        {
                            output.SetIndex(
                                rowEntry, row, int.Parse(rowEntries[rowEntry]));
                        }
                    }
                }
                else if (node.Name == "Texture")
                {
                    output.AssetName = node.Attributes["AssetName"].Value;
                }
            }

            return output;
        }
    }
}
