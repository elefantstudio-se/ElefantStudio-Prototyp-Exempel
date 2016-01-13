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
    public class PlayerContentWriter : ContentTypeWriter<Player>
    {
        protected override void Write(ContentWriter output, Player value)
        {
            output.Write(value.Name);
            output.Write(value.ArmorAsset);
            output.Write(value.TextureAsset);
            output.Write(value.jParticleAsset);
            output.Write(value.Position);
            //output.Write(value.Velocity);
            //output.Write(value.MaxVelocity);
            //output.Write(value.Gravity);
            //output.Write(value.Friction);
            //output.Write(value.Acceleration);
            //output.Write(value.Decceleration);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return typeof(Player.PlayerContentReader).AssemblyQualifiedName;
        }
    }
}
