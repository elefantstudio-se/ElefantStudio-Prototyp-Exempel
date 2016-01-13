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
    public class Player2ContentWriter : ContentTypeWriter<Player2>
    {
        PlayerContentWriter playerWriter = null;

        protected override void Initialize(ContentCompiler compiler)
        {
            playerWriter = compiler.GetTypeWriter(typeof(Player)) as PlayerContentWriter;

            base.Initialize(compiler);
        }
        protected override void Write(ContentWriter output, Player2 value)
        {
            output.WriteRawObject<Player>(value as Player, playerWriter);
            output.Write(value.WeaponAsset);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return typeof(Player2.Player2ContentReader).AssemblyQualifiedName;
        }
    }
}