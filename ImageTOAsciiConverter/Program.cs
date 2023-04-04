using SkiaSharp;
using System.Text;

namespace ImageTOAsciiConverter
{
    public class Program
    {
        private static string[] _AsciiChars = { "#", "#", "@", "%", "=", "+", "*", ":", "-", ".", "&nbsp;" };

        [Obsolete]
        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("path >");

                    string path = Console.ReadLine();
                    path = path.Replace('"', ' ').Trim();

                    Console.Write("Width:");
                    int width = int.Parse(Console.ReadLine());
                    Console.Write("Height:");
                    int height = int.Parse(Console.ReadLine());
                    var bitmap = SKBitmap.Decode(path);

                    bitmap = bitmap.Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Mitchell);

                    StringBuilder stringBuilder = new StringBuilder();

                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            var pixel = bitmap.GetPixel(x, y);

                            int avarage = (pixel.Red + pixel.Green + pixel.Blue) / 3;
                            avarage = avarage * 10 / 255;
                            stringBuilder.Append(_AsciiChars[avarage]);
                        }
                        stringBuilder.Append('\n');
                    }

                    Console.WriteLine(stringBuilder.ToString() + "\n\n\n");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message+"\n\n");
                }
            }


        }
    }
}