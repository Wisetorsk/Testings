using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestingDiscordRPGStuff
{
    class Program
    {

        static void Main(string[] args)
        {
            var t = new TestObject();
            Console.WriteLine(JSONhandler.GetProperties(t));
            //Console.WriteLine(JSONhandler.GetProperties(t));
            //Console.WriteLine(JSONhandler.GetFields(t));

            //t.ReadFromJson(p);
            //var newObj = JSONhandler.CreateObjectFromJson(p);
            //Console.WriteLine(newObj.Collection1);
            

        }

    }
}

