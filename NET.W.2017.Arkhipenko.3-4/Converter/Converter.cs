using System;
using System.Text;

namespace Converter
{
    /// <summary>
    /// static class Converter that implements the DoubleHelper extension method
    /// </summary>
    public static class Converter
    {
       /// <summary>
       /// static extention method DoubleHelper for Double
       /// </summary>
       /// <param name="doubleNumber"></param>
       /// <returns>double to string</returns>
        public static string DoubleHelper(this double doubleNumber)
        {
            StringBuilder sb = new StringBuilder();
            Byte[] doubleByte = BitConverter.GetBytes(doubleNumber);
            foreach (Byte b in doubleByte)
                for (int i = 0; i < 8; i++)
                {
                    sb.Insert(0, ((b >> i) & 1) == 1 ? "1" : "0");
                }
            string doubleToString = sb.ToString();
           
            return doubleToString;
        }
    }

}
