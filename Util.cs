using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjComanda
{
    public static class Util
    {
        
        public static void Continuar()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        public static void CabecalhoMenu(string texto)
        {
            Console.WriteLine("-".PadRight(60,'-'));
            Console.WriteLine($"|{texto.Centralizar(58)}|");
            Console.WriteLine("-".PadRight(60, '-'));
        }
    }
}


