using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Задание 2. Повышение уровня сложности игры или увеличение числа игроков
    /// </summary>
    class Program
    {
        /// <summary>
        /// Начало программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Random rnd = new Random(); // Переменная для генирации случайных чисел
            int gameNumber; // Переменная для хранения игрового числа (задается случайно от 12 до 120)
            int userTry = 0; // Переменная для хранения числа выбранное игроком
            int playerTurn; // Переменная для хранения числа, выбранное игроком
            string[] nameGamers; // Переменная для хранения имен игроков
            int numOfPlayer; // Кол-во игроков
            int playerNumber = 0; // Номер игрока делавший ход
            int gameLevel; // Уровень сложности

            // Вывод в консоль правила игры
            Console.WriteLine("Правила игры:");
            Console.WriteLine("В игре участвуют от 2 до 5 игроков.\n" +
                              "Выбирается уровень сложности: 1-легкий, 2-сложный.\n" +
                              "Вначале вводится игровое число от 25 до 120.\n" +
                              "Если выбран легкий уровень сложности, то вводится диапазон от 1 до х (х не превышает 4), из которого игроки по очереди выбирают число.\n" +
                              "При сложном уровне сложности диапазон генерируется каждый ход.\n" +
                              "После этого вычитается заданное число из игрового числа.\n" +
                              "Если после хода игрока загаданное число равняется нулю, то походивший игрок оказывается победителем.");

            // Ввод кол-ва игроков
            Console.WriteLine("Введите количество игроков от 2 до 5: ");
            numOfPlayer = Convert.ToInt32(Console.ReadLine()); // Считываем кол-во игроков
            while (numOfPlayer < 2 || numOfPlayer > 5) // Если число игроков введено неверно, просим повторить ввод
            {
                Console.WriteLine("Введите количество игроков от 2 до 5: ");
                numOfPlayer = Convert.ToInt32(Console.ReadLine());
            }
            nameGamers = new string[numOfPlayer];

            Console.Clear(); // Очистить консоль от предыдущих записей

            // Выбор уровня сложности
            Console.WriteLine("Выберите уровень сложности: 1-легкий, 2-сложный.");
            gameLevel = Convert.ToInt32(Console.ReadLine()); // Считываем уровень сложности
            while (gameLevel < 1 || gameLevel > 2) // Если уровень сложности введено неверно, просим повторить ввод
            {
                Console.WriteLine("Выберите уровень сложности: 1-легкий, 2-сложный.");
                gameLevel = Convert.ToInt32(Console.ReadLine());
            }

            Console.Clear(); // Очистить консоль от предыдущих записей

            // Ввод игрового числа
            Console.WriteLine("Введите игровое число от 25 до 120.");
            gameNumber = Convert.ToInt32(Console.ReadLine()); // Считываем игровое число
            while (gameNumber < 25 || gameNumber > 120) // Если игровое число введено неверно, просим повторить ввод
            {
                Console.WriteLine("Введите игровое число от 25 до 120.");
                gameNumber = Convert.ToInt32(Console.ReadLine());
            }

            Console.Clear(); // Очистить консоль от предыдущих записей

            // Ввод диапазона
            if (gameLevel == 1)
            {
                Console.WriteLine("Введите диапазон от 1 до х, где х не превышает 4.");
                userTry = Convert.ToInt32(Console.ReadLine()); // Считываем диапазон
                while (userTry < 1 || userTry > 4) // Если диапазон введено неверно, просим повторить ввод
                {
                    Console.WriteLine("Введите диапазон от 1 до х, где х не превышает 4.");
                    userTry = Convert.ToInt32(Console.ReadLine());
                }

                Console.Clear(); // Очистить консоль от предыдущих записей
            }

            // Ввод имен игроков
            for (int i = 0; i < nameGamers.Length; i++)
            {
                Console.WriteLine($"Игрок{i + 1}, введите свое имя: ");
                nameGamers[i] = Console.ReadLine(); // Считываем с консоли имя игрока
                while (string.IsNullOrEmpty(nameGamers[i])) // Если имя введено неправильно, то просим ввести его снова
                {
                    Console.WriteLine($"Игрок{i + 1}, имя не может быть пустым!");
                    Console.WriteLine($"Игрок{i + 1}, введите свое имя: ");
                    nameGamers[i] = Console.ReadLine();
                }
            }

            Console.Clear(); // Очистить консоль от предыдущих записей

            // Начало игры
            while (true)
            {
                Console.WriteLine($"Значение игрового числа: {gameNumber}"); // Вывод в консоль игрого числа

                if (gameLevel == 2) // Если выбран уровень сложности: 2-сложно, то userTry генерируется каждый ход
                {
                    userTry = rnd.Next(1, 5); // Задается случайное значение userTry от 1 до 4
                }

                if (gameNumber < userTry) // Если значение меньше userTry, то вывести предупреждение
                {
                    Console.WriteLine("Если Вы введете число больше игрового числа, то Вы пропускаете ход!");
                }

                Console.WriteLine($"Ход {nameGamers[playerNumber]}. Введите число от 1 до {userTry}: "); // Приглашаем игрока сделать ход
                playerTurn = Convert.ToInt32(Console.ReadLine()); // Игрок вводит число
                while (playerTurn < 1 || playerTurn > userTry) // Если игрок ввел неправильно число
                {
                    Console.WriteLine($"{nameGamers[playerNumber]}, введите число от 1 до {userTry}: ");
                    playerTurn = Convert.ToInt32(Console.ReadLine()); // Игрок вводит число
                }

                if (gameNumber - playerTurn > 0) // Проверка условия выхода из цикла
                {
                    gameNumber -= playerTurn;
                }
                else if (gameNumber - playerTurn == 0)
                {
                    break;
                }

                playerNumber++; // Передаем ход следующему игру
                if (playerNumber == nameGamers.Length) // Если число больше кол-ва игроков, то передать ход первому игроку
                {
                    playerNumber = 0;
                }
            }

            Console.Clear(); // Очистить консоль от предыдущих записей

            // Поздравляем победителя
            Console.WriteLine($"Победил {nameGamers[playerNumber]}!!! Поздравляем!!!");
        }
    }
}
