using System;
using PencilDurabilityKata;

namespace PencilDurabilityKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Pencil _pencil = new Pencil(4000,3000,1000);

            Console.WriteLine(_pencil.Write(Console.ReadLine()));
            Console.WriteLine($"PD After {_pencil.PointDegradation}");

            Console.WriteLine(_pencil.Erase(Console.ReadLine()));
            Console.WriteLine($"ED After {_pencil.EraseDegradation}");
            
            Console.WriteLine(_pencil.Edit(Console.ReadLine()));
            Console.ReadLine();
            
        }
    }
}
