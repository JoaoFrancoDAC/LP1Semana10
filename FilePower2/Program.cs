using System;
using System.IO;

namespace FilePower2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Por favor, forneça um nome de arquivo como argumento.");
                return;
            }

            string fileName = args[0];

            Console.WriteLine("Insira as palavras, para parar pressione Enter sem nada estar digitado:");

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    while (true)
                    {
                        string input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input))
                        {
                            writer.Close();
                            break;
                        }

                        writer.WriteLine(input);
                    }
                }

                Console.WriteLine($"Salvo no arquivo de texto {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro! {ex.Message}");
            }
        }
    }
}