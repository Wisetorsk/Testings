#nullable enable
using System;
using System.Collections.Generic;
using System.Text;
using TestingDiscordRPGStuff.Models;

namespace TestingDiscordRPGStuff
{
    public class DBHandler
    {

        public static void AddPlayer(Player player)
        {

            using (var db = new EFContext())
            {
                var lookup = db.Players.Find((int)player.ID);
                if (!(lookup is null))
                {
                    if (lookup.ID == (int)player.ID) return;
                }
                var entity = new PlayerModel() {
                    ID = (int)player.ID,
                    Name = player.Name,
                    Health = player.Health,
                    Defense = player.Defense,
                    Attack = player.Attack
                };
                db.Players.Add(entity);
                db.SaveChanges();
            }
        }

        public static Player? GetPlayer(ulong ID)
        {
            using (var db = new EFContext())
            {
                var result = db.Players.Find((int)ID);
                if (result is null) return null;
                var p = new Player((ulong)result.ID, result.Name, result.Health, result.Defense, result.Attack);
                return p;
            }
        }
    }


}
