using System;
using System.Collections.Generic;
using Snabel_Engine;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

// TODO: replace this with the type you want to write out.
//using TWrite = SnabelEngine.Weapon;

namespace SnabelPipeline
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to write the specified data type into binary .xnb format.
    ///
    /// This should be paart of a Content Pipeline Extension Library project.
    /// </summary>
    [ContentTypeWriter]
    public class ArmoryContentWriter : ContentTypeWriter<Armory>
    {
        protected override void Write(ContentWriter output, Armory value)
        {
            // TODO: write the specified value to the output ContentWriter.
            output.Write(value.Name);
            output.WriteObject<List<string>>(value.ArmorList);
            output.WriteObject<List<string>>(value.WeaponList);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            // TODO: change this to the name of your ContentTypeReader
            // class which will be used to load this data.
            return typeof(ArmoryContentReader).AssemblyQualifiedName;
        }
    }
}
