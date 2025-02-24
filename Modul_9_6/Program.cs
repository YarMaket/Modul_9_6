using System;
using System.Collections.Generic;

class Program
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

            SortList += SortLastNames;
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

    private static void SortLastNames(List<string> lastNames)
    {
        // Сортировка в зависимости от выбранного варианта
        if (lastNames.Count > 0)
        {
            Console.WriteLine("Сортировка начинается...");
        }

        if (lastNames != null && lastNames.Count > 0)
        {
            // Сортировка по возрастанию (А-Я)
            if (lastNames.Count > 0)
            {
                lastNames.Sort();  // Сортировка по возрастанию
            }
        }
    }

    private static void SortLastNamesDescending(List<string> lastNames)
    {
        // Сортировка по убыванию (Я-А)
        lastNames.Sort((x, y) => y.CompareTo(x)); // Сортировка по убыванию
    }

    private static void DisplayLastNames(List<string> lastNames)
    {
        foreach (var lastName in lastNames)
        {
            Console.WriteLine(lastName);
        }
    }
}