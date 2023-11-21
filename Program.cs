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
            Console.WriteLine("Error: " + ex.Message);
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
            Console.WriteLine($"File opened: {filePath}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File does not exist error {filePath}.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Error: You don't have permission to open the file {filePath}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error opening file {filePath}: {ex.Message}");
        }
    }
}