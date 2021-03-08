using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestingDiscordRPGStuff
{
    public class Player : IPlayer
    {
        [Key]
        public ulong ID { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }

        public Player(ulong id, string name, int hp=25, int df=5, int at=5)
        {
            ID = id;
            Name = name;
            Health = hp;
            Defense = df;
            Attack = at;
        }

        public override string ToString()
        {
            return $"ID:{ID}\nName:{Name}\nHealth:{Health}\nDefense:{Defense}\nAttack:{Attack}\n";
        }
    }

}
