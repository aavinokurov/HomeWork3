using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Задание 3. Реализация игры с компьютером
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
            int playerTurn = 0; // Переменная для хранения числа, выбранное игроком
            string[] nameGamers = new string[2]; // Переменная для хранения имен игроков
            int playerNumber = 0; // Номер игрока делавший ход
            int gameLevel; // Уровень сложности

            // Вывод в консоль правила игры
            Console.WriteLine("Правила игры:");
            Console.WriteLine("В игре участвуют игрок и компьютер.\n" +
                              "Выбирается уровень сложности: 1-легкий, 2-сложный.\n" +
                              "При сложном уровне сложности компьютер труднее обыграть.\n" +
                              "Вначале вводится игровое число от 25 до 120.\n" +
                              "Вводится диапазон от 1 до х (х не превышает 4), из которого игроки по очереди выбирают число.\n" +
                              "После этого вычитается заданное число из игрового числа.\n" +
                              "Если после хода игрока загаданное число равняется нулю, то походивший игрок оказывается победителем.");

            // Ввод имени игрока
            Console.WriteLine("Игрок, введите свое имя: ");
            nameGamers[0] = Console.ReadLine(); // Считываем с консоли имя игрока
            while (string.IsNullOrEmpty(nameGamers[0])) // Если имя введено неправильно, то просим ввести его снова
            {
                Console.WriteLine("Игрок, имя не может быть пустым!");
                Console.WriteLine("Игрок, введите свое имя: ");
                nameGamers[0] = Console.ReadLine();
            }

            nameGamers[1] = "Компьютер";

            Console.Clear(); // Очистить консоль от предыдущих записей

            // Начало игры
            while (true) // Цикл для реванша
            {

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
                Console.WriteLine("Введите диапазон от 2 до х, где х не превышает 4.");
                userTry = Convert.ToInt32(Console.ReadLine()); // Считываем диапазон
                while (userTry < 2 || userTry > 4) // Если диапазон введено неверно, просим повторить ввод
                {
                    Console.WriteLine("Введите диапазон от 2 до х, где х не превышает 4.");
                    userTry = Convert.ToInt32(Console.ReadLine());
                }

                Console.Clear(); // Очистить консоль от предыдущих записей

                while (true) // Цикл основной игры
                {
                    Console.WriteLine($"Значение игрового числа: {gameNumber}"); // Вывод в консоль игрого числа

                    if (gameNumber < userTry) // Если значение меньше 4, то вывести предупреждение
                    {
                        Console.WriteLine("Если Вы введете число больше игрового числа, то Вы пропускаете ход!");
                    }

                    Console.WriteLine($"Ход {nameGamers[playerNumber]}. Введите число от 1 до {userTry}: "); // Приглашаем игрока сделать ход

                    if (playerNumber == 0) // Ход человека
                    {
                        playerTurn = Convert.ToInt32(Console.ReadLine()); // Игрок вводит число
                        while (playerTurn < 1 || playerTurn > userTry) // Если игрок ввел неправильно число
                        {
                            Console.WriteLine($"{nameGamers[playerNumber]}, введите число от 1 до {userTry}: ");
                            playerTurn = Convert.ToInt32(Console.ReadLine()); // Игрок вводит число
                        }
                    }
                    else // Ход компьютера
                    {
                        if (gameLevel == 1) // Если простой уровень сложности
                        {
                            playerTurn = rnd.Next(2, userTry + 1); // Просто задавать случайное число от 2 до userTry
                        }
                        else // Если сложный уровень сложности
                        {
                            // К - компьюте, Ч - человек
                            if (userTry == 2) // Если диапазон от 1 до 2
                            {
                                /*Игровая стратегия
                                 *          0
                                 * ---------------------
                                 * К: 1            2
                                 * --------------------
                                 * Ч: 3            3
                                 * ---------------------
                                 * К: 4            5
                                 * ---------------------
                                 * Ч: 6            6
                                 * --------------------
                                 * К: 7            8
                                 */
                                switch (gameNumber)
                                {
                                    case 7:
                                    case 4:
                                    case 1: playerTurn = 1; break;
                                    default: playerTurn = 2; break;
                                }
                            }

                            if (userTry == 3) // Если диапазон от 1 до 3
                            {
                                /*Игровая стратегия
                                *          0
                                * ---------------------
                                * К: 1      2       3
                                * --------------------
                                * Ч: 4      4       4
                                * ---------------------
                                * К: 5      6       7
                                * ---------------------
                                * Ч: 8       8      8
                                * --------------------
                                * К: 9     10      11
                                */
                                switch (gameNumber)
                                {
                                    case 9:
                                    case 5:
                                    case 1: playerTurn = 1; break;
                                    case 10:
                                    case 6:
                                    case 2: playerTurn = 2; break;
                                    default: playerTurn = 3; break;
                                }
                            }


                            if (userTry == 4) // Если диапазон от 1 до 4
                            {
                                /*Игровая стратегия
                                *          0
                                * ---------------------
                                * К: 1   2    3     4
                                * --------------------
                                * Ч: 5   5    5     5
                                * ---------------------
                                * К: 6   7    8     9
                                * ---------------------
                                * Ч: 10  10   10   10
                                * --------------------
                                * К: 11  12   13   14
                                */
                                switch (gameNumber)
                                {
                                    case 11:
                                    case 6:
                                    case 1: playerTurn = 1; break;
                                    case 12:
                                    case 7:
                                    case 2: playerTurn = 2; break;
                                    case 13:
                                    case 8:
                                    case 3: playerTurn = 3; break;
                                    default: playerTurn = 4; break;
                                }
                            }
                        }
                        Console.WriteLine(playerTurn); // Вывод в консоль выбранное число компьютером
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

                // Реванш
                string answerRematch; // Ответ на реванш
                do
                {
                    Console.WriteLine("Реванш (\"да\", \"нет\"): ");
                    answerRematch = Console.ReadLine(); // Считываем ответ
                } while (answerRematch != "да" && answerRematch != "нет"); // Считываем значение, пока игрок не ответит правильно

                if (answerRematch == "нет") // Если игрок отказался от реванша, то завершить игру
                {
                    break;
                }

                Console.Clear(); // Очищаем консоль
            }
        }
    }
}
