
using System;
using System.Diagnostics;


namespace AlgorithmGCD
{
    /// <summary>
    ///The AlgorithmGCD class considers the GCD using the Euclidean algorithm and the Stein algorithm (Euclid's binary algorithm)
    /// </summary>
    public class AlgorithmGCD
    {
        #region public

        #region EuclideanMethod method
        /// <summary>
        /// The EuclideanMethod method takes 2 integer parameters 
        /// and returns the GCD of these numbers using the classical Euclidean algorithm
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns> GCD of two numbers(int) and time necessary for calculations(double)</returns>
        public static Tuple<int, double> EuclideanMethod(int firstNumber, int secondNumber)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int firstNumberAbs = Math.Abs(firstNumber);
            int secondNumberAbs = Math.Abs(secondNumber);

            int result = NodLoop(firstNumberAbs, secondNumberAbs);

            stopwatch.Stop();
            double time = stopwatch.Elapsed.TotalMilliseconds;
            return Tuple.Create(result, time);

        }

        /// <summary>
        /// The EuclideanMethod method takes 3 integer parameters 
        /// and returns the GCD of these numbers using the classical Euclidean algorithm
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="thirdNumber"></param>
        /// <returns>GCD of three numbers(int) and time necessary for calculations(double)</returns>
        public static Tuple<int, double> EuclideanMethod(int firstNumber, int secondNumber, int thirdNumber)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int firstNumberAbs = Math.Abs(firstNumber);
            int secondNumberAbs = Math.Abs(secondNumber);
            int thirdNumberAbs = Math.Abs(thirdNumber);

            firstNumberAbs = NodLoop(firstNumberAbs, secondNumberAbs);
            firstNumberAbs = NodLoop(firstNumberAbs, thirdNumberAbs);
            stopwatch.Stop();

            double time = stopwatch.Elapsed.TotalMilliseconds;
            return Tuple.Create(firstNumberAbs, time);
        }

        /// <summary>
        /// The EuclideanMethod method takes integer array 
        /// and returns the GCD of these numbers using the classical Euclidean algorithm      
        /// /// </summary>
        /// <param name="numbers"></param>
        /// <returns>GCD of integer array numbers(int) and time necessary for calculations(double)</returns>
        public static Tuple<int, double> EuclideanMethod(params int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException();
            }
            if (numbers == null)
            {
                throw new ArgumentNullException();
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 1; i < numbers.Length; i++)
            {
                numbers[0] = NodLoop(numbers[0], numbers[i]);
            }

            stopwatch.Stop();
            double time = stopwatch.Elapsed.TotalMilliseconds;

            return Tuple.Create(numbers[0], time);
        }
        #endregion



        /// <summary>
        /// The BinEuclideanMethod method takes 2 integer parameters 
        /// and returns the NOD of these numbers using the Stein algorithm (Euclid's binary algorithm)
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>GCD of two numbers(int) and time necessary for calculations(double)</returns>
        public static Tuple<int , double> BinEuclideanMethod(int firstNumber, int secondNumber)
        {
            int firstNumberAbs = Math.Abs(firstNumber);
            int secondNumberAbs = Math.Abs(secondNumber);
           

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int k = BinNodLoop(firstNumberAbs, secondNumberAbs);
            stopwatch.Stop();
            
            double time = stopwatch.Elapsed.TotalMilliseconds;
            return Tuple.Create(k, time);
        }

        /// <summary>
        ///  The BinEuclideanMethod method takes 3 integer parameters 
        /// and returns the NOD of these numbers using the Stein algorithm (Euclid's binary algorithm)
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="thirdNumber"></param>
        /// <returns>GCD of three numbers(int) and time necessary for calculations(double)</returns>
        public static Tuple<int,double> BinEuclideanMethod(int firstNumber, int secondNumber, int thirdNumber)
        {
            int firstNumberAbs = Math.Abs(firstNumber);
            int secondNumberAbs = Math.Abs(secondNumber);
            int thirdNumberAbs = Math.Abs(thirdNumber);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

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

            int k = BinNodLoop(firstNumberAbs, secondNumberAbs);
            k = BinNodLoop(k, thirdNumberAbs);
            
            stopwatch.Stop();
            double time = stopwatch.Elapsed.TotalMilliseconds;
            return Tuple.Create(k, time);
        }

        /// <summary>
        /// The BinEuclideanMethod method takes integer array
        /// and returns the NOD of these numbers using the Stein algorithm (Euclid's binary algorithm)
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>GCD of integer array(int) and time necessary for calculations(double)</returns>
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
                numbers[i + 1] = BinNodLoop(numbers[i], numbers[i + 1]);
            }
            stopwatch.Stop();
            double time = stopwatch.Elapsed.TotalMilliseconds;
            return Tuple.Create(numbers[numbers.Length - 1], time);
        }
        #endregion

        #region private
        private static int NodLoop(int firstn, int secnum)
        {
            while (firstn != secnum)
            {
                if (firstn > secnum)
                {
                    firstn = firstn - secnum;

                }
                else
                {
                    secnum = secnum - firstn;

                }
            }
            return firstn;
        }


        private static int BinNodLoop(int firstNum, int secondNum)
        {
            int shift;
            for (shift = 0; ((firstNum | secondNum) & 1) == 0; ++shift)
            {
                firstNum >>= 1;
                secondNum >>= 1;
            }
            while ((firstNum & 1) == 0)
                firstNum >>= 1;
            do
            {
                while ((secondNum & 1) == 0)
                    secondNum >>= 1;
                if (firstNum > secondNum)
                {
                    int t = secondNum;
                    secondNum = firstNum;
                    firstNum = t;
                }
                secondNum = secondNum - firstNum;
            } while (secondNum != 0);
            return firstNum << shift;
        }
        #endregion
    }
}
