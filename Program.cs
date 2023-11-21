using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            for (int i = 1; i < 10; i++)
            {
                string filePath = Path.Combine(desktopPath, $"L0{new string('0', i)}L.txt");
                CreateAndOpenTextFile(filePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
    }

    static void CreateAndOpenTextFile(string filePath)
    {
        CreateTextFile(filePath);
        OpenFile(filePath);
    }

    static void CreateTextFile(string filePath)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < 200; j++)
                {
                    sw.Write("L0000000000L ");
                }
                sw.WriteLine();
            }
        }
    }

    static void OpenFile(string filePath)
    {
        try
        {
            Process.Start(filePath);
            Console.WriteLine($"Otwarto plik: {filePath}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Błąd: Plik {filePath} nie istnieje.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Błąd: Brak uprawnień do otwarcia pliku {filePath}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd podczas otwierania pliku {filePath}: {ex.Message}");
        }
    }
}