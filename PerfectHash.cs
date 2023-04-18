using System.Numerics;

namespace PH
{

    public class MyHashTable
    {
        //змінні
        int _size;
        List<Complex>[] _table;
        Random _rnd;
        const int MaxPrimeSize = 100;
        readonly int RandomValue;

        int GetHash(Complex key) => (int)((key.Magnitude * RandomValue) % PrimeNum(_size)) % _size; // генерація хешу


        public MyHashTable(int size) // конструктор класу, иніціалізація змінних
        {
            _size = size;
            _table = new List<Complex>[size];
            for (int i = 0; i < size; i++)
                _table[i] = new List<Complex>();
            _rnd = new Random();
            RandomValue = _rnd.Next(1, 200);
        }

        public void Add(Complex key) // створення хешу, та додання в таблицю
        {
            int hash = GetHash(key); // hash
            if (!_table[hash].Contains(key))
                _table[hash].Add(key); // key
            else
                Console.WriteLine("Знайдено коллiзiю(дублiкат) для iндексу: " + hash + ", значення: " + key + ". Ключ не додається до таблицi!");
        }


        int PrimeNum(int tableSize) // пошук простого числа для вибірки
        {
            int count = 0, res = 0;
            for (int i = tableSize + 1; i < MaxPrimeSize; i++)
            {
                for (int j = 1; j < MaxPrimeSize; j++)
                    if (i % j == 0) count++;

                if (count < 3)
                {
                    res = i;
                    return res;
                }
                count = 0;
            }
            return res;
        }

        public void Print() // вивід таблиці у консоль
        {
            for (int i = 0; i < _size; i++)
            {
                Console.Write("[" + i + "]: ");
                foreach (Complex key in _table[i])
                    Console.Write(key + " ");

                Console.WriteLine();
            }
        }

    }
}