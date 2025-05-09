using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace IntGrouper
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            HashSet<int> intersection = null;

            foreach (string fileName in args)
            {
                HashSet<int> fileNumbers = new HashSet<int>();

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!int.TryParse(line, out int number))
                        {
                            throw new FormatException($"Erro no arquivo {fileName}: '{line}' não é um inteiro.");
                        }
                        fileNumbers.Add(number);
                    }
                }

                if (intersection == null)
                {
                    intersection = fileNumbers;
                }
                else
                {
                    intersection.IntersectWith(fileNumbers);
                }
            }

            if (intersection != null)
            {
                foreach (int number in intersection.OrderBy(n => n))
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                return;
            }
        }
    }
}