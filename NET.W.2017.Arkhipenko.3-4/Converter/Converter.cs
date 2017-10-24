using System;
using System.Text;

namespace Converter
{
    public static class Converter
    {
        public static string DoubleHelper(this double f)
        {
            StringBuilder sb = new StringBuilder();
            Byte[] ba = BitConverter.GetBytes(f);
            foreach (Byte b in ba)
                for (int i = 0; i < 8; i++)
                {
                    sb.Insert(0, ((b >> i) & 1) == 1 ? "1" : "0");
                }
            string s = sb.ToString();
           
            return s;
        }
    }

}
