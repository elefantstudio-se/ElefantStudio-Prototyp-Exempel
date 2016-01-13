using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Snabel_Engine
{
    public class Player2 : Player, IDeepCloneable
    {
        /// <summary>
        /// Gets or sets the player weapon
        /// </summary>
        [ContentSerializerIgnore]
        public Weapon Weapon { get; set; }

        ///// <summary>
        ///// Gets or sets the name of the Weapon asset
        ///// </summary>
        public string WeaponAsset { get; set; }

        /// <summary>
        /// Creates a deep clone of the current player
        /// </summary>
        /// <returns>A copy of the current player</returns>
        public override object Clone()
        {
            Player2 p = new Player2();

            // Base class
            p.Name = this.Name;
            p.Armor = this.Armor.Clone() as Armor;
            p.ArmorAsset = this.ArmorAsset;
            p.Texture = this.Texture;
            p.TextureAsset = this.TextureAsset;
            p.Position = this.Position;

            // Blah class
            p.Weapon = this.Weapon.Clone() as Weapon;
            p.WeaponAsset = this.WeaponAsset;

            return p;
        }
        public class Player2ContentReader : ContentTypeReader<Player2>
        {
            protected override Player2 Read(ContentReader input, Player2 existingInstance)
            {
                Player2 player2 = existingInstance;

                if (player2 == null)
                {
                    player2 = new Player2();
                }

                // Read the Player settings
                input.ReadRawObject<Player2>(player2 as Player2);

                // Read the rest of the stuff
                player2.WeaponAsset = input.ReadString();
                player2.Weapon = input.ContentManager.Load<Weapon>(player2.WeaponAsset).Clone() as Weapon;
                //player.Texture = input.ContentManager.Load<Texture2D>("Textures\\Characters\\" + player.TextureAsset);
                return player2;
            }
        }
    }
}