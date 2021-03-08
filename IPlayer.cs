using System;
using System.Collections.Generic;
using System.Text;

namespace TestingDiscordRPGStuff
{
    public interface IPlayer
    {
        ulong ID { get; set; }
        string Name { get; set; }
        int Health { get; set; }
        int Defense { get; set; }
        int Attack { get; set; }
    }
}
