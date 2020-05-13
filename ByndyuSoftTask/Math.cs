using System;
using System.Linq;

namespace ByndyuSoftTask
{
    public class Math
    {
        public int SumTwoMinIntInArray(int[] array)
        {
            if (array == null || array.Length < 2)
                throw new Exception("Invalid array. The array must not be null and must have at least 2 elements.");

            var firstMinValue = 0;
            var secondMinValue = 0;

            for (var i = 0; i < array.Length; i++)
            {
                if (i == 0)
                {
                    firstMinValue = array[0];
                    secondMinValue = array[1];
                    continue;
                }

                if (firstMinValue > array[i])
                {
                    secondMinValue = firstMinValue;
                    firstMinValue = array[i];
                    continue;
                }

                if (secondMinValue > array[i])
                {
                    secondMinValue = array[i];
                }
            }

            return secondMinValue + firstMinValue;
        }
    }
}