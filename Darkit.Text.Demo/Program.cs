using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darkit.Text.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = new string[] {
                "PascalCaseString",
                "camelCaseString",
                "kebab-case-string",
                "snake_case_string",
            };
            foreach(string t in data)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("Raw: " + t);
                Console.WriteLine("Snake: " + t.ToCase(CaseStyle.SnakeStyle));
                Console.WriteLine("Kebab: " + t.ToCase(CaseStyle.KebabStyle));
                Console.WriteLine("Camel: " + t.ToCase(CaseStyle.CamelStyle));
                Console.WriteLine("Pascal: " + t.ToCase(CaseStyle.PascalStyle));
            }
            Console.ReadLine();
        }
    }
}
