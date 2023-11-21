using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            for (int i = 1; i < 10; i++)
            {
                string filePath = $"L0{new string('0', i)}L.txt";
                CreateTextFile(filePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
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
}