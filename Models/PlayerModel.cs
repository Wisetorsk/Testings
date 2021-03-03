using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestingDiscordRPGStuff.Models
{
    public class PlayerModel
    {
        [Key]
        public Int32 ID { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
    }
}
