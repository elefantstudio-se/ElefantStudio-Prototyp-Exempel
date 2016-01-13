namespace Snabel_Engine
{
    public class Armor : Equipment, IDeepCloneable
    {
        public int DmgBlock { get; set; }

        public object Clone()
        {
            Armor armor = new Armor();

            armor.DmgBlock = this.DmgBlock;
            armor.Name = this.Name;

            return armor;
        }
    }
}
