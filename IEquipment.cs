using System;
using System.Collections.Generic;
using System.Text;

namespace TestingDiscordRPGStuff
{
    internal interface IEquipment
    {
        public string Type { get; set; }
        public int Defence { get; set; }
        public int Attack { get; set; }
    }
}
