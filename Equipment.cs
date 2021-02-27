using System;
using System.Collections.Generic;
using System.Text;

namespace TestingDiscordRPGStuff
{
    public class Equipment : IEquipment
    {
        public virtual string Type { get; set; }
        public virtual int Defence { get; set; }
        public virtual int Attack { get; set; }
    }

    public class Armor : Equipment, IEquipment
    {
        public override string Type { get; set; } = "armor";
        public override int Defence { get; set; } = 10;
    }

    public class Weapon : Equipment, IEquipment
    {
        public override string Type { get; set; } = "weapon";
        public override int Attack { get; set; } = 5;
    }
}
