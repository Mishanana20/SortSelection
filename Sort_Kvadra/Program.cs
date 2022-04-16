///Сортировка выбором
///передаем в функцию массив конечной длины и на выходе получаем отсортированный
///Сортировка устойчивая и сложность равна O(n^2)
///Преимущество - крайняя простота и малая константа в квадратичной зависимости
///
///
///Суть: проходимя по массиву. И в простом варианте сначала проходимя с первого, потом со второго и до конца
///и после каждого пробега записываем значение в новый массив

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Kvadra
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[100000];
            for (int i = 99999; i>=0;i--)
            {
                array[i] = 100-i;
            }

            Stopwatch stopwatch = new Stopwatch();
            //засекаем время начала операции
            stopwatch.Start();
            List<int> sortedList = Sort_Selection(array);
            stopwatch.Stop();
            //смотрим сколько миллисекунд было затрачено на выполнение
            Console.WriteLine("Время выполнения {0}",stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            sortedList.Clear();

            stopwatch.Start();
            List<int> sortedList2 = SortSelection(array);
            stopwatch.Stop();
            //смотрим сколько миллисекунд было затрачено на выполнение
            Console.WriteLine("Время выполнения второй сортировки {0}", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            sortedList.Clear();
            
            //засекаем время начала операции
            stopwatch.Start();
            Stack<int> sortedList3 = SortSelectionStack(array);
            stopwatch.Stop();
            //смотрим сколько миллисекунд было затрачено на выполнение
            Console.WriteLine("Время выполнения третьей сортировки {0}", stopwatch.ElapsedMilliseconds);

            Console.ReadLine();
        }

        static List<int> Sort_Selection(int[] array)
        {
            int[] sortArray = array;
            List<int> listArray = array.ToList<int>();
            
            for (int i = 0; i < listArray.Count; i++)
            {
                int k = i;
                int minInArray = listArray[i];
                for (int j = i; j < listArray.Count; j++)
                {
                   if (minInArray < listArray[j])
                    {
                        minInArray = listArray[j];
                        k = j;
                    }
                }
                listArray.RemoveAt(k);
                listArray.Insert(0, minInArray);
            }
            return listArray;
        }

        static List<int> SortSelection(int[] array)
        {
            int[] sortArray = array;
            Stack<int> numbers = new Stack<int>();
            List<int> listArray = array.ToList<int>();

            for (int i = 0; i < listArray.Count; i++)
            {
                int k = i;
                int minInArray = listArray[i];
                for (int j = i; j < listArray.Count; j++)
                {
                    if (minInArray < listArray[j])
                    {
                        minInArray = listArray[j];
                        k = j;
                    }
                }
                numbers.Push(minInArray);
            }
            listArray = numbers.ToList();
            return listArray;
        }
        static Stack<int> SortSelectionStack(int[] array)
        {
            int[] sortArray = array;
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < sortArray.Length; i++)
            {
                int k = i;
                int minInArray = sortArray[i];
                for (int j = i; j < sortArray.Length; j++)
                {
                    if (minInArray < sortArray[j])
                    {
                        minInArray = sortArray[j];
                        k = j;
                    }
                }
                numbers.Push(minInArray);
            }
            return numbers;
        }
    }
}
