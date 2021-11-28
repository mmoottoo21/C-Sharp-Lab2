using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreiMassive
{
    class Program
    {
        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        static void InsertionSort(int[] inArray)
        {
            int x;
            int j;
            for (int i = 1; i < inArray.Length; i++)
            {
                x = inArray[i];
                j = i;
                while (j > 0 && inArray[j - 1] > x)
                {
                    Swap(inArray, j, j - 1);
                    j -= 1;
                }
                inArray[j] = x;
            }
        }
        static void Main(string[] args)
        {
            int arrayLength = 0;
            int[] mainArray;
            Random rndGenerator = new Random();

            while (arrayLength <= 0)
            {
                Console.WriteLine("Введите количество элементов массива: ");
                arrayLength = Convert.ToInt32(Console.ReadLine());
            }
            mainArray = new int[arrayLength];

            int negativesProduct = 1;
            int[] reverseArray = new int[arrayLength];
            int sumToMax = 0;

            int maxValue = int.MinValue;
            int maxValueIndex = 0;

            int[] zeroValuesIndex = new int[2] { int.MinValue, int.MinValue };
            int zeroProduct = 1;

            Console.Write("Исходный массив: ");
            for (int i = 0; i < arrayLength; i++)
            {
                mainArray[i] = rndGenerator.Next(-20, 20);
                Console.Write(mainArray[i] + " ");

                if (mainArray[i] < 0)
                    negativesProduct *= mainArray[i];

                reverseArray[arrayLength - i - 1] = mainArray[i];

                if (maxValue < mainArray[i])
                {
                    maxValue = mainArray[i];
                    maxValueIndex = i;
                }

                if (i == arrayLength - 1)
                {
                    for (int k = 0; k < maxValueIndex; k++)
                        sumToMax += mainArray[k];

                    Console.WriteLine();
                }

                if (mainArray[i] == 0)
                {
                    if (zeroValuesIndex[0] == int.MinValue)
                        zeroValuesIndex[0] = i;
                    else if (zeroValuesIndex[1] == int.MinValue)
                    {
                        zeroValuesIndex[1] = i;
                        for (int n = zeroValuesIndex[0] + 1; n < zeroValuesIndex[1]; n++)
                        {
                            zeroProduct *= mainArray[n];
                        }
                    }
                }
            }
            Console.WriteLine("Cумма элементов находящихся до максимального: {0}", sumToMax);
            Console.WriteLine("Произведение отрицательных элементов равно: {0}", negativesProduct);
            Console.WriteLine("Номер максимального элемента массива: {0}", maxValueIndex);
            Console.WriteLine("Произведение элементов массива, расположенных между первым и вторым нулевыми элементами: {0}", zeroProduct);
            InsertionSort(mainArray);
            Console.WriteLine("Отсортированный массив:");
            foreach (int value in mainArray)
            {
                Console.Write($"{value} ");
            }
            Console.Read();
        }
    }
}
