using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingDiscordRPGStuff
{
    class Program
    {

        static void Main(string[] args)
        {
            var t = new TestObject();
            var p = JSONhandler.ObjectToJson(t);
            Console.WriteLine(p);

            //t.ReadFromJson(p);
            JSONhandler.CreateObjectFromJson(p);

            var equipment = new List<IEquipment>();
            List<IEquipment> eq = new List<IEquipment>
            {
                new Armor(),
                new Weapon(),
                new Armor(),
                new Weapon()
            };

        }

    }
}
