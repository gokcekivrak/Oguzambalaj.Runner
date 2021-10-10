using System;
namespace Oguzambalaj.Runner.SumOfMultiple
{
    public class SumOfMultipleSolver
    {

        public ulong Solve(int input)
        {
            if (input <= 0)
                throw new ArgumentOutOfRangeException(nameof(input), input, "Limit needs to be positive number!");
            var limit = (ulong)(input - 1);
           
            var sumOf3 = SumOfAllNumbersMultipleOfXTillN(3, limit);
            
            var sumOf5 = SumOfAllNumbersMultipleOfXTillN(5, limit);

            
            var sumOf15 = SumOfAllNumbersMultipleOfXTillN(15, limit);

          
            return sumOf3 + sumOf5 - sumOf15;
        }

        private static ulong SumOfAllNumbersMultipleOfXTillN(ulong multipleOf, ulong limit)
        {
            return SumOfAllNumbersTillN(limit / multipleOf) * multipleOf;
        }

        private static ulong SumOfAllNumbersTillN(ulong n)
        {
            return n * (n + 1) / 2;
        }
    }
}