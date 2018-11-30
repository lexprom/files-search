using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles("../../testFolder", "*", SearchOption.AllDirectories);

            foreach (var item in files)
            {
                Console.Write(item + " -- ");
                getSignature(item);
            }
        }

        static void getSignature(string myFile)
        {
            string signature = null;
            using (var fs = new FileStream(myFile, FileMode.Open))
            {
                var buffer = new byte[10];
                fs.Read(buffer, 0, buffer.Length);
                signature = string.Join(" ", buffer.Select(b => b.ToString("X2")));
                // Console.WriteLine(signature);
                switch (signature)
                {
                    case "FF D8 FF E0 00 10 4A 46 49 46":
                        Console.WriteLine("JPEG");
                        break;
                    case "89 50 4E 47 0D 0A 1A 0A":
                        Console.WriteLine("PNG");
                        break;
                    case "50 4B 03 04 14 00 06 00 08 00":
                        buffer = new byte[6];
                        fs.Read(buffer, 0, buffer.Length);
                        signature = string.Join(" ", buffer.Select(b => b.ToString("X2")));
                        switch (signature)
                        {
                            case "00 00 21 00 DF A4":
                                Console.WriteLine("DOCX");
                                break;
                            case "00 00 21 00 DF CC":
                                Console.WriteLine("PPTX");
                                break;
                            default:
                                Console.WriteLine("Unknown");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown");
                        break;
                }
            }
        }
    }
}
