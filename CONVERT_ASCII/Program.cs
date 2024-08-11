using System;
using System.Drawing;
using System.IO;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    //static string basePath = AppDomain.CurrentDomain.BaseDirectory;
    static string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    static string imagePath = Path.Combine(projectPath, "IMAGEN", "imagen.jpg");
    static string outputPath = Path.Combine(projectPath, "ASCII", "OutImagen.txt");

    private const string DB = "./DB/db.json";
    static void Main(string[] args)
    {
        using (Bitmap bitmap = new Bitmap(imagePath))
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char asciiChar = GetAsciiChar(grayValue);
                    sb.Append(asciiChar);
                }
                sb.AppendLine();
            }
            File.WriteAllText(outputPath, sb.ToString());
        }
        Console.WriteLine("El arte ASCII se ha guardado en: " + outputPath);
    }

    static char GetAsciiChar(int grayValue)
    {
        string asciiChars = "@%#*+=-:. ";
        int index = (grayValue * (asciiChars.Length - 1)) / 250;
        return asciiChars[index];
    }
}