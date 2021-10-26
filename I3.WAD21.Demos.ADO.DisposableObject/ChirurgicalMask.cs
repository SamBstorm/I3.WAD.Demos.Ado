using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3.WAD21.Demos.ADO.DisposableObject
{
    public class ChirurgicalMask : IDisposable
    {
        public ConsoleColor Couleur { get; set; }

        public void Dispose()
        {
            Console.WriteLine($"Bye bye COVID! {this.Couleur}");
        }
    }
}
