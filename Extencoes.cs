using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExt
    {
        public static string Centralizar(this string str, int length, char character = ' ') => str.PadLeft((length - str.Length) / 2 + str.Length, character).PadRight(length, character);
    }
}
