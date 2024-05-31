using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void ChangeFileTimes(string directory, List<string> filePatterns, string newDate)
    {
        int totalFileCount = 0;
        foreach (string filePattern in filePatterns) //Створюємо масив типів файлів, які хочимо змінювати
        {
            int fileCount = 0;
            foreach (string file in Directory.GetFiles(directory, filePattern, SearchOption.AllDirectories)) //Змінюємо всі файли, час їх створення. Directoty - Папка, яку ми вводимо, у ній і будемо змінюємо 
            {
                if (Path.GetFileName(file).StartsWith(".")) continue;
                Console.WriteLine($"Changing date and time of file {file}");
                File.SetLastWriteTime(file, DateTime.Parse(newDate));
                fileCount++;
            }
            Console.WriteLine($"Changed date and time of {fileCount} files with pattern '{filePattern}'");
            totalFileCount += fileCount;
        }
        Console.WriteLine($"Changed date and time of {totalFileCount} files in all patterns");
    }

    static void Main()
    {
        string directory;
        List<string> filePatterns = new List<string>();
        string newDate = "01.01.2024";

        // Запитати користувача про шлях до каталогу
        Console.Write("Enter the directory path: ");
        directory = Console.ReadLine();

        // Запитати користувача про шаблони файлів, поки він не введе "done"
        string filePattern;
        Console.Write("Enter file patterns (type 'done' when finished): ");
        while ((filePattern = Console.ReadLine()) != "done")
        {
            filePatterns.Add(filePattern);
        }

        // Викликати функцію для зміни дати та часу файлів
        ChangeFileTimes(directory, filePatterns, newDate);
    }
}
