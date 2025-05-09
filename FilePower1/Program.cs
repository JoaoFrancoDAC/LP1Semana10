using System;
using System.Collections.Generic;
using System.IO;

namespace FilePower1
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a filename as an argument.");
                return;
            }

            string fileName = args[0];
            Queue<string> inputQueue = new Queue<string>();

            Console.WriteLine($"insira as palavras, para parar pressione enter sem nada estar digitado");

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;

                inputQueue.Enqueue(input);
            }

            try
            {
                File.WriteAllLines(fileName, inputQueue);

                Console.WriteLine($"salvo no arquivo de texto {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"erro! {ex.Message}");
            }
        }
    }
}