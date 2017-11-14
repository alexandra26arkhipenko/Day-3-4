
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
        public static int EuclideanMethod(int firstNumber, int secondNumber) => 
            EuclideanGcd(Math.Abs(firstNumber), Math.Abs(secondNumber)); 
        public static int EuclideanMethod(int firstNumber, int secondNumber, out double time) =>
            CalculateTime(() => EuclideanMethod(firstNumber, secondNumber), out time);
              
        /// <summary>
        /// The EuclideanMethod method takes 3 integer parameters 
        /// and returns the GCD of these numbers using the classical Euclidean algorithm
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="thirdNumber"></param>
        /// <returns>GCD of three numbers(int) and time necessary for calculations(double)</returns>
        public static int EuclideanMethod(int firstNumber, int secondNumber, int thirdNumber) =>
            EuclideanGcd(EuclideanGcd(Math.Abs(firstNumber), Math.Abs(secondNumber)), Math.Abs(thirdNumber));        
        public static int EuclideanMethod(int firstNumber, int secondNumber, int thirdNumber, out double time) =>
            CalculateTime(() => EuclideanMethod(firstNumber, secondNumber, thirdNumber), out time);
        
        /// <summary>
        /// The EuclideanMethod method takes integer array 
        /// and returns the GCD of these numbers using the classical Euclidean algorithm      
        /// /// </summary>
        /// <param name="numbers"></param>
        /// <returns>GCD of integer array numbers(int) and time necessary for calculations(double)</returns>
        public static int EuclideanMethod(params int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException();
            }
            if (numbers == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Math.Abs(numbers[i]);
            }

            for (int i = 1; i < numbers.Length; i++)
            {
                numbers[0] = EuclideanGcd(numbers[0], numbers[i]);
            }
            return numbers[0];
        }
        public static int EuclideanMethod( out double time, params int[] numbers) =>
             CalculateTime(() => EuclideanMethod(numbers), out time);
        #endregion

        #region SteinMethod

        /// <summary>
        /// The BinEuclideanMethod method takes 2 integer parameters 
        /// and returns the NOD of these numbers using the Stein algorithm (Euclid's binary algorithm)
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>GCD of two numbers(int) and time necessary for calculations(double)</returns>
        public static int BinEuclideanMethod(int firstNumber, int secondNumber) =>
            SteinGcd(Math.Abs(firstNumber), Math.Abs(secondNumber));
        public static int BinEuclideanMethod(int firstNumber, int secondNumber, out double time) =>
            CalculateTime(() => BinEuclideanMethod(firstNumber, secondNumber), out time);
       
        /// <summary>
        ///  The BinEuclideanMethod method takes 3 integer parameters 
        /// and returns the NOD of these numbers using the Stein algorithm (Euclid's binary algorithm)
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="thirdNumber"></param>
        /// <returns>GCD of three numbers(int) and time necessary for calculations(double)</returns>
        public static int BinEuclideanMethod(int firstNumber, int secondNumber, int thirdNumber)=>
            SteinGcd(SteinGcd(firstNumber, secondNumber), thirdNumber);
        public static int  BinEuclideanMethod(int firstNumber, int secondNumber, int thirdNumber, out double time)=>
            CalculateTime(() => BinEuclideanMethod(firstNumber, secondNumber, thirdNumber), out time);              

        /// <summary>
        /// The BinEuclideanMethod method takes integer array
        /// and returns the NOD of these numbers using the Stein algorithm (Euclid's binary algorithm)
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>GCD of integer array(int) and time necessary for calculations(double)</returns>
        public static int BinEuclideanMethod(params int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentException();
            }

            if (numbers == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Math.Abs(numbers[i]);
            }
           
            for (int i = 0; i < numbers.Length-1; i++)
            {
                numbers[i + 1] = SteinGcd(numbers[i], numbers[i + 1]);
            }
            return numbers[numbers.Length - 1];

        }
        public static int  BinEuclideanMethod( out double time, params int[] numbers)=>
            CalculateTime(() => BinEuclideanMethod(numbers), out time);

#endregion

        #endregion

        #region private
        private static int EuclideanGcd(int firstn, int secnum)
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
        private static int SteinGcd(int firstNum, int secondNum)
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
        private static int CalculateTime(Func<int> calculateGcd,  out double time)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int result = calculateGcd();

            stopwatch.Stop();
            time = stopwatch.Elapsed.TotalMilliseconds;

            return result;

        }
        #endregion
    }
}
