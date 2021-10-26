using System;

namespace I3.WAD21.Demos.ADO.DisposableObject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChirurgicalMask mask1 = new ChirurgicalMask() { Couleur = ConsoleColor.Blue }) {
                Console.WriteLine($"mask1 est de couleur {mask1.Couleur}");
            }
            Console.WriteLine("FIN PROGRAMME");
        }
    }
}
