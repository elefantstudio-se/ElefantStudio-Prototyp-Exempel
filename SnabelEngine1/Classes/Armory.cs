using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Snabel_Engine
{
    public class Armory : GameObject
    {
        [ContentSerializerIgnore]
        public List<Armor> Armors { get; set; }

        [ContentSerializerIgnore]
        public List<Weapon> Weapons { get; set; }

        public List<string> ArmorList { get; set; }
        public List<string> WeaponList { get; set; }

        public Armory()
        {
            this.Armors = new List<Armor>();
            this.Weapons = new List<Weapon>();
        }
    }

    public class ArmoryContentReader : ContentTypeReader<Armory>
    {
        protected override Armory Read(ContentReader input, Armory existingInstance)
        {
            Armory armory = existingInstance;

            if (armory == null)
            {
                armory = new Armory();
            }

            armory.Name = input.ReadString();
            armory.ArmorList = input.ReadObject<List<string>>();
            armory.WeaponList = input.ReadObject<List<string>>();

            // Add all armors in the armor list
            foreach (string armor in armory.ArmorList)
            {
                Armor newArmor = input.ContentManager.Load<Armor>(armor).Clone() as Armor;
                armory.Armors.Add(newArmor);
            }

            // Add all weapons in weapon list
            foreach (string weapon in armory.WeaponList)
            {
                Weapon newWeapon = input.ContentManager.Load<Weapon>(weapon).Clone() as Weapon;
                armory.Weapons.Add(newWeapon);
            }

            return armory;
        }
    }
}