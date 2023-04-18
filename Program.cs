using System.Numerics;

namespace PH
{
    internal class Program
    {
        //Ініціалізація змінних
        static int size = 15;
        static MyHashTable myTable = new MyHashTable(size);
        static Complex[] keys = new Complex[size];
        static Random rnd = new Random();

        static void Main(string[] args) => OutputResult(); //точка входу в програму

        static void OutputResult() // обрахунки та вивід у консоль
        {
            //Заповнення змінних
            var real = rnd.Next(1, 214);
            var imaginary = rnd.NextDouble();
            Complex key;
            for (int i = 0; i < size; i++)
            {
                key = new Complex(real, imaginary); // псевдо-випадкове комплексне число
                if (keys.Contains(key)) // перевірка на дублікат
                {
                    size++;
                    Console.WriteLine("Знайдено дублікат початкового ключа. (Пропускаемо, та генеруємо інший)");
                    continue;
                }
                keys[i] = key; // додаємо дійсне число до вибірки
                myTable.Add(key);  // обрахунок
            }

            //Вивід у консоль
            PrintToConsole(myTable, keys);
        }

        static void PrintToConsole(MyHashTable myTable, Complex[] keys) // метод для виводу у консоль
        {
            myTable.Print();
            Console.WriteLine("\nПочатковi значення:");
            for (int i = 0; i < keys.Length; i++)
                Console.WriteLine($"{i}. " + keys[i] + " ");

            Console.WriteLine();
        }
    }
}