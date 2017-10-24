﻿
using System;
using System.Diagnostics;


/// <summary>
/// Класс AlgorithmGCD считает НОД при помощи алгоритма Евклида и алгоритма Стейна(бинарный алгоритм Евклида
/// </summary>
namespace AlgorithmGCD
{
    public class AlgorithmGCD
    {
        /// <summary>
        /// Метод EuclideanMethod принимает 2 целочисленных параметра 
        /// и возвращает НОД этих чисел, используя классический алгоритм Евклида
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        #region Euclidean algorithm with two parameters;
        public static Tuple<int, double> EuclideanMethod(int firstNumber, int secondNumber)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int firstNumberAbs = Math.Abs(firstNumber);
            int secondNumberAbs = Math.Abs(secondNumber);
            while (firstNumberAbs != secondNumberAbs)
            {
                if (firstNumberAbs > secondNumberAbs)
                {
                    firstNumberAbs = firstNumberAbs - secondNumberAbs;
                }
                else
                {
                    secondNumberAbs = secondNumberAbs - firstNumberAbs;
                }
            }
            stopwatch.Stop();

            double time = stopwatch.Elapsed.TotalMilliseconds;
            return Tuple.Create(firstNumberAbs, time);

        }
        #endregion

        /// <summary>
        /// Метод EuclideanMethod принимает 3 целочисленных параметра
        ///  и возвращает НОД этих чисел, используя классический алгоритм Евклида
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="thirdNumber"></param>
        /// <returns></returns>
        #region Euclidean algorithm with three parameters;
        public static Tuple<int, double> EuclideanMethod(int firstNumber, int secondNumber, int thirdNumber)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int firstNumberAbs = Math.Abs(firstNumber);
            int secondNumberAbs = Math.Abs(secondNumber);
            int thirdNumberAbs = Math.Abs(thirdNumber);
            while (firstNumberAbs != secondNumberAbs)
            {
                if (firstNumberAbs > secondNumberAbs)
                {
                    firstNumberAbs = firstNumberAbs - secondNumberAbs;
                }
                else
                {
                    secondNumberAbs = secondNumberAbs - firstNumberAbs;
                }
            }
            while (firstNumberAbs != thirdNumberAbs)
            {
                if (firstNumberAbs > thirdNumberAbs)
                {
                    firstNumberAbs = firstNumberAbs - thirdNumberAbs;
                }
                else
                {
                    thirdNumberAbs = thirdNumberAbs - firstNumberAbs;
                }
            }
            stopwatch.Stop();
            double time = stopwatch.Elapsed.TotalMilliseconds;
            return Tuple.Create(firstNumberAbs, time);
        }
        #endregion

        /// <summary>
        /// Метод EuclideanMethod принимает массив из целых чисел
        ///  и возвращает НОД этих чисел, используя классический алгоритм Евклида        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        #region Euclidean algorithm with several parameters;
        public static Tuple<int, double> EuclideanMethod(params int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException();
            }

            if (numbers == null)
            {
                throw new ArgumentException();
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 1; i < numbers.Length; i++)
            {
                while (Math.Abs(numbers[0]) != Math.Abs(numbers[i]))
                {
                    if (Math.Abs(numbers[0]) > Math.Abs(numbers[i]))
                    {
                        numbers[0] = Math.Abs(numbers[0]) - Math.Abs(numbers[i]);
                    }
                    else
                    {
                        numbers[i] = Math.Abs(numbers[i]) - Math.Abs(numbers[0]);
                    }
                }
            }
            stopwatch.Stop();
            double time = stopwatch.Elapsed.TotalMilliseconds;
            return Tuple.Create(numbers[0], time);
        }
        #endregion

        /// <summary>
        /// Метод BinEuclideanMethod принимает 2 целочисленных параметра 
        /// и возвращает НОД этих чисел, используя алгоритм Стейна(бинарный алгоритм Евклида)
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        #region Binary euclidean algorithm with two parameters;
        public static Tuple<int , double> BinEuclideanMethod(int firstNumber, int secondNumber)
        {
            int firstNumberAbs = Math.Abs(firstNumber);
            int secondNumberAbs = Math.Abs(secondNumber);
           

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int shift;
            if (firstNumber == 0)
            {
                stopwatch.Stop();
                double times = stopwatch.Elapsed.TotalMilliseconds;
                return Tuple.Create(secondNumber, times);
            }
            if (secondNumber == 0)
            {
                stopwatch.Stop();
                double times = stopwatch.Elapsed.TotalMilliseconds;
                return Tuple.Create(firstNumber, times);
            }
            for (shift = 0; ((firstNumberAbs | secondNumberAbs) & 1) == 0; ++shift)
            {
                firstNumberAbs >>= 1;
                secondNumberAbs >>= 1;
            }
            while ((firstNumberAbs & 1) == 0)
                firstNumberAbs >>= 1;
            do
            {
                while ((secondNumberAbs & 1) == 0)
                    secondNumberAbs >>= 1;
                if (firstNumberAbs > secondNumberAbs)
                {
                    int t = secondNumberAbs;
                    secondNumberAbs = firstNumberAbs;
                    firstNumberAbs = t;
                }
                secondNumberAbs = secondNumberAbs - firstNumberAbs;
            } while (secondNumberAbs != 0);
            stopwatch.Stop();
            double time = stopwatch.Elapsed.TotalMilliseconds;
            return Tuple.Create(firstNumber << shift, time);
        }
        #endregion


        /// <summary>
        /// Метод BinEuclideanMethod принимает 3 целочисленных параметра 
        /// и возвращает НОД этих чисел, используя алгоритм Стейна(бинарный алгоритм Евклида)
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="thirdNumber"></param>
        /// <returns></returns>
        #region Binary Euclidean algorithm with three parameters;
        public static Tuple<int,double> BinEuclideanMethod(int firstNumber, int secondNumber, int thirdNumber)
        {
            int firstNumberAbs = Math.Abs(firstNumber);
            int secondNumberAbs = Math.Abs(secondNumber);
            int thirdNumberAbs = Math.Abs(thirdNumber);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int shift;

            if (firstNumber == 0)
            {
                stopwatch.Stop();
                double times = stopwatch.Elapsed.TotalMilliseconds;
                return Tuple.Create(secondNumber, times);
            }
            if (secondNumber == 0)
            {
                stopwatch.Stop();
                double times = stopwatch.Elapsed.TotalMilliseconds;
                return Tuple.Create(firstNumber, times);
            }
            if (thirdNumber == 0)
            {
                stopwatch.Stop();
                double times = stopwatch.Elapsed.TotalMilliseconds;
                return Tuple.Create(thirdNumber, times);
            }

            for (shift = 0; ((firstNumberAbs | secondNumberAbs) & 1) == 0; ++shift)
            {
                firstNumberAbs >>= 1;
                secondNumberAbs >>= 1;
            }
            while ((firstNumberAbs & 1) == 0)
                firstNumberAbs >>= 1;
            do
            {
                while ((secondNumberAbs & 1) == 0)
                    secondNumberAbs >>= 1;
                if (firstNumberAbs > secondNumberAbs)
                {
                    int t = secondNumberAbs;
                    secondNumberAbs = firstNumber;
                    firstNumberAbs = t;
                }
                secondNumberAbs = secondNumberAbs - firstNumberAbs;
            } while (secondNumberAbs != 0);
            int k = firstNumberAbs << shift;

            int shift1;
            for (shift1 = 0; ((k | thirdNumberAbs) & 1) == 0; ++shift1)
            {
                k >>= 1;
                thirdNumberAbs >>= 1;
            }
            while ((k & 1) == 0)
                k >>= 1;
            do
            {
                while ((thirdNumberAbs & 1) == 0)
                    thirdNumberAbs >>= 1;
                if (k > thirdNumberAbs)
                {
                    int t = thirdNumberAbs;
                    thirdNumberAbs = k;
                    k = t;
                }
                thirdNumberAbs = thirdNumberAbs - k;
            } while (thirdNumberAbs != 0);
            stopwatch.Stop();
            double time = stopwatch.Elapsed.TotalMilliseconds;
            return Tuple.Create(k << shift1, time);
        }
        #endregion

        /// <summary>
        /// Метод BinEuclideanMethod принимает массив, состоящий из целых чисел , 
        /// и возвращает НОД этих чисел, используя алгоритм Стейна(бинарный алгоритм Евклида)
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        #region Binary Euclidean algorithm with several parameters;
        public static Tuple<int,double> BinEuclideanMethod(params int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException();
            }

            if (numbers == null)
            {
                throw new ArgumentException();
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < numbers.Length-1; i++)
            {
                int shift;
                if (numbers[i] == 0)
                {
                    stopwatch.Stop();
                    double times = stopwatch.Elapsed.TotalMilliseconds;
                    return Tuple.Create(numbers[i], times);
                }
                if (numbers[i+1] == 0)
                {
                    stopwatch.Stop();
                    double times = stopwatch.Elapsed.TotalMilliseconds;
                    return Tuple.Create(numbers[i+1], times);
                }
                for (shift = 0; ((Math.Abs(numbers[i]) | Math.Abs(numbers[i+1])) & 1) == 0; ++shift)
                {
                    numbers[i] >>= 1;
                    numbers[i+1] >>= 1;
                }
                while ((Math.Abs(numbers[i]) & 1) == 0)
                    numbers[i]>>= 1;
                do
                {
                    while ((numbers[i+1] & 1) == 0)
                        numbers[i + 1] >>= 1;
                    if (Math.Abs(numbers[i]) > numbers[i + 1])
                    {
                        int t = numbers[i + 1];
                        numbers[i + 1] = numbers[i];
                        numbers[i] = t;
                    }
                    numbers[i + 1] = numbers[i + 1] - numbers[i];
                } while (numbers[i + 1] != 0);
                numbers[i+1] = numbers[i] << shift;
            }
            stopwatch.Stop();
            double time = stopwatch.Elapsed.TotalMilliseconds;
            return Tuple.Create(numbers[numbers.Length - 1], time);
        }
        #endregion





    }
}