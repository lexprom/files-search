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
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Введите тип файла:");
            var pattern = "*" + Console.ReadLine();
            Console.WriteLine("Введите путь:");
            string path;
            try
            {
                while ((path = Console.ReadLine()) != "")
                {
                    Handle(path, pattern);
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Error! {0}", e.Message);
            }
        }

        static void Handle(string path, string pattern)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException("Путь неверен");

            var files = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
