using Microsoft.Xna.Framework.Content;

namespace Snabel_Engine
{
    public class Weapon : Equipment, IDeepCloneable
    {
        public int Damage { get; set; }

        public object Clone()
        {
            Weapon weapon = new Weapon();

            weapon.Name = this.Name;
            weapon.Price = this.Price;
            weapon.Damage = this.Damage;

            return weapon;

        }
    }

    public class WeaponContentReader : ContentTypeReader<Weapon>
    {
        protected override Weapon Read(ContentReader input, Weapon existingInstance)
        {
            Weapon weapon = existingInstance;

            if(weapon == null)
            {
                weapon = new Weapon();
            }

            weapon.Name = input.ReadString();
            weapon.Price = input.ReadInt32();
            weapon.Damage = input.ReadInt32();

            return weapon;
        }
    }
}