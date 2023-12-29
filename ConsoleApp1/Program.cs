// See https://aka.ms/new-console-template for more information

using AdventOfCode;
using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;



namespace AdventOfCode
{
    class DataLoader
    {
        public static string[] Load(string file_name)
        {
            string[] input;
            file_name = "D:\\Users\\Użytkownik\\source\\repos\\HelloWorldInCS\\ConsoleApp1\\" + file_name;
            input = File.Exists(file_name) ?
                File.ReadAllLines(file_name) :
                ["File not found."];
            Console.WriteLine(input[0] == "File not found." ? input[0] : "File loaded.");
            return input;
        }
    }
}

namespace HelloWorld
{
    class Program
    {
        public static IEnumerable<(int index, T value)> Enumerate<T>(IEnumerable<T> line)
            => line.Select((i, val) => (val, i));
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Provide the name of the file: ");
            string file_name = Console.ReadLine();
            file_name = file_name is not null ? file_name : throw new Exception("File name not provided.");
            string[] input = DataLoader.Load(file_name);
            var prep_input = Enumerate(input);
            foreach (var line in prep_input)
            {
                Console.WriteLine(line.value != "File not found." ? line : "");
            }            
        }
    }
}

