using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Задание 1. Создание игры на два игрока
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
            int gameNumber = rnd.Next(12, 121); // Переменная для хранения игрового числа (задается случайно от 12 до 120)
            int userTry; // Переменная для хранения числа выбранное игроком
            string[] nameGamers = new string[2]; // Переменная для хранения имен игроков
            int playerNumber = 0; // Номер игрока делавший ход

            // Вывод в консоль правила игры
            Console.WriteLine("Правила игры:");
            Console.WriteLine("В игре участвуют два игрока. " +
                              "В начале игры загадывается число от 12 до 120 (случайным образом). " +
                              "Игроки по очереди выбирают число от 1 до 4. " +
                              "После этого вычитается заданное число из загаданного числа. " +
                              "Если после хода игрока загаданное число равняется нулю, то походивший игрок оказывается победителем.");

            // Ввод имен игроков
            for (int i = 0; i < nameGamers.Length; i++)
            {
                Console.WriteLine($"Игрок{i+1}, введите свое имя: ");
                nameGamers[i] = Console.ReadLine(); // Считываем с консоли имя игрока
                while (string.IsNullOrEmpty(nameGamers[i])) // Если имя введено неправильно, то просим ввести его снова
                {
                    Console.WriteLine($"Игрок{i+1}, имя не может быть пустым!");
                    Console.WriteLine($"Игрок{i+1}, введите свое имя: ");
                    nameGamers[i] = Console.ReadLine();
                }
            }

            Console.Clear(); // Очистить консоль от предыдущих записей

            // Начало игры
            while (true)
            {                
                Console.WriteLine($"Значение игрового числа: {gameNumber}"); // Вывод в консоль игрого числа

                if (gameNumber < 4) // Если значение меньше 4, то вывести предупреждение
                {
                    Console.WriteLine("Если Вы введете число больше игрового числа, то Вы проиграете!");
                }

                Console.Write($"Ход {nameGamers[playerNumber]}: "); // Приглашаем игрока сделать ход
                userTry = rnd.Next(1, 5); // Выбирается число для игрока
                Console.WriteLine(userTry); // Выводиться выбранное число                             
                
                if (gameNumber - userTry > 0) // Проверка условия выхода из цикла
                {
                    gameNumber -= userTry;
                }
                else
                {
                    break;
                }

                playerNumber++; // Передаем ход следующему игру
                if (playerNumber == nameGamers.Length) // Если число больше кол-ва игроков, то передать ход первому игроку
                {
                    playerNumber = 0;
                }
            }

            // Конец игры
            if(gameNumber - userTry < 0) // Если последний игрок ввел число больше игрового числа, то победителем становится следующий игрок
            {
                playerNumber++; // Передаем ход следующему игру
                if (playerNumber == nameGamers.Length) // Если число больше кол-ва игроков, то передать ход первому игроку
                {
                    playerNumber = 0;
                }
            }

            // Поздравляем победителя
            Console.WriteLine($"Победил {nameGamers[playerNumber]}!!! Поздравляем!!!");
        }
    }
}
