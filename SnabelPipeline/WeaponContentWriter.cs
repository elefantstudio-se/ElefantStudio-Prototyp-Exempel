using System;
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
    /// This should be part of a Content Pipeline Extension Library project.
    /// </summary>
    [ContentTypeWriter]
    public class WeaponContentWriter : ContentTypeWriter<Weapon>
    {
        protected override void Write(ContentWriter output, Weapon value)
        {
            // TODO: write the specified value to the output ContentWriter.
            output.Write(value.Name);
            output.Write(value.Price);
            output.Write(value.Damage);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            // TODO: change this to the name of your ContentTypeReader
            // class which will be used to load this data.
            return typeof(WeaponContentReader).AssemblyQualifiedName;
        }
    }
}
