using System;
using System.Text;

namespace Converter
{
    /// <summary>
    /// Статический класс Converter,  котором реализуется расширяющий метод DoubleHelper
    /// </summary>
    public static class Converter
    {
       /// <summary>
       /// Статический расширяющий метод DoubleHelper. Расширяет тип Double
       /// </summary>
       /// <param name="doubleNumber"></param>
       /// <returns></returns>
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
