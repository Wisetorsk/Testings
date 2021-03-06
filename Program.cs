﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestingDiscordRPGStuff
{
    class Program
    {

        static void Main(string[] args)
        {
            /*var t = new TestObject();
            Console.WriteLine(JSONhandler.ObjectToJson(t));
            //Console.WriteLine(JSONhandler.GetProperties(t));
            //Console.WriteLine(JSONhandler.GetFields(t));

            //t.ReadFromJson(p);
            //var newObj = JSONhandler.CreateObjectFromJson(p);
            //Console.WriteLine(newObj.Collection1);
            */
            var players = new List<Player>();
            for (int i = 1; i < 11; i++)
            {
                players.Add(new Player((ulong)i, "player"+i.ToString()));
            }
            foreach (var player in players)
            {
                DBHandler.AddPlayer(player);
            }
            
            var id = players[4].ID;
            var res = DBHandler.GetPlayer(id);
            Console.WriteLine((res is null) ? "Could not find player" : res.ToString());
        }

    }
}

