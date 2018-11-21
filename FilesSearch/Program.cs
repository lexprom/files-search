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
            var files = Directory.GetFiles("../../testFolder", "image*", SearchOption.AllDirectories);
            var signature = getSignature("../../testFolder/image.jpg");
            var result = files.Where(file => getSignature(file) == signature);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static string getSignature(string myFile)
        {
            string signature = null;
            using (var fs = new FileStream(myFile, FileMode.Open))
            {
                var buffer = new byte[100];
                fs.Read(buffer, 0, buffer.Length);
                signature = string.Join(" ", buffer.Select(b => b.ToString("X2")));
                //Console.WriteLine(signature);

                /*if (signature.StartsWith("FF D8 FF E0"))
                    Console.WriteLine("JPEG");

                if (signature.StartsWith("89 50 4E 47 0D 0A 1A 0A"))
                    Console.WriteLine("PNG");*/
            }
            return signature;
        }
    }
}
