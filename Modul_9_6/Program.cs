using System;
using System.Collections.Generic;

/*
//задание 1
public class MyCustomException : Exception
{
    public MyCustomException(string message) : base(message) { }
}

class Program1
{
    static void Main()
    {
        // Массив исключений
        Exception[] exceptions = new Exception[]
        {
            new DivideByZeroException("Деление на ноль"),
            new NullReferenceException("Ссылка на ноль"),
            new ArgumentOutOfRangeException("Индекс находится за пределами массива"),
            new InvalidOperationException("Недопустимая операция"),
            new MyCustomException("Это мое собственное исключение")
        };

        // Итерация по массиву исключений
        foreach (var exception in exceptions)
        {
            try
            {
                // Принудительно вызываем исключение
                throw exception;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Поймано исключение: {e.Message}");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"Поймано исключение: {e.Message}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Поймано исключение: {e.Message}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Поймано исключение: {e.Message}");
            }
            catch (MyCustomException e)
            {
                Console.WriteLine($"Поймано собственное исключение: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally выполнен\n");
            }
        }
    }
}
*/

//Задание 2

public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}

class Program2
{
    public delegate void SortingEventHandler(List<string> lastNames);

    public static event SortingEventHandler SortList;

    static void Main()
    {
        List<string> lastNames = new List<string> { "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов" };

        Console.WriteLine("Исходный список фамилий:");
        DisplayLastNames(lastNames);

        Console.WriteLine("Введите 1 для сортировки по возрастанию (А-Я) или 2 для сортировки по убыванию (Я-А):");

        string userInput = Console.ReadLine();

        try
        {
            int sortOption = int.Parse(userInput);
            if (sortOption < 1 || sortOption > 2)
            {
                throw new InvalidInputException("Ошибка: Введено недопустимое число. Пожалуйста, введите 1 или 2.");
            }

            // Подписываемся на событие в зависимости от выбора пользователя
            if (sortOption == 1)
            {
                SortList += SortLastNamesAscending;
            }
            else if (sortOption == 2)
            {
                SortList += SortLastNamesDescending;
            }

            // Вызываем событие сортировки
            SortList(lastNames);

            Console.WriteLine("Отсортированный список фамилий:");
            DisplayLastNames(lastNames);
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Некорректный формат ввода. Пожалуйста, введите число.");
        }
        catch (InvalidInputException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Завершение программы.");
        }
    }

    private static void SortLastNamesAscending(List<string> lastNames)
    {
        lastNames.Sort(); // Сортировка по возрастанию (А-Я)
    }

    private static void SortLastNamesDescending(List<string> lastNames)
    {
        lastNames.Sort((x, y) => y.CompareTo(x)); // Сортировка по убыванию (Я-А)
    }

    private static void DisplayLastNames(List<string> lastNames)
    {
        foreach (var lastName in lastNames)
        {
            Console.WriteLine(lastName);
        }
    }
}