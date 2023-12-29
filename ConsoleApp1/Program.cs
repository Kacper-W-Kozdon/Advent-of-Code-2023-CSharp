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

    class Calibration_Values<T, U, V>
    {   
        public T val { get => val; set { val = value;  } }
        public U Id { get => Id; set { Id = value; } }
        public V calibration_val { get => calibration_val; set { calibration_val = value; } }
    }
    class Program
    {
        public static IEnumerable<(int index, T value)> Enumerate<T>(IEnumerable<T> line)
            => line.Select((i, val) => (val, i));

        static string Calibrate(string line)
        {
            string ret = string.IsNullOrEmpty(string.Concat(line.Where(char.IsDigit).ToArray()) as string) ? "0" : string.Concat(line.Where(char.IsDigit).ToArray()[0], line.Where(char.IsDigit).ToArray().Last());
            return ret;
        }

        static string Precalibrate(string line)
        {
            string ret = line.ToLower().Replace("one", "o1e").Replace("two", "t2o").Replace("three", "t3e").Replace("four", "f4r").Replace("five", "f5e").Replace("six", "s6x").Replace("seven", "s7n").Replace("eight", "e8t").Replace("nine", "n9e");
            return ret;
        }

        static int _solution;

        static int Sum_calibration_vals(IEnumerable<string> input)
        {
            Program._solution = 0;
            foreach (var line in input)
            {
                _solution += Convert.ToInt32(line);
            }
            return _solution;

        }
       
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Provide the name of the file: ");
            string file_name = Console.ReadLine();
            file_name = file_name is not null ? file_name : throw new Exception("File name not provided.");
            string[] input = DataLoader.Load(file_name);
            var prep_input = Enumerate(input);
            IEnumerable<string> calibration_vals = from line in prep_input select Program.Calibrate(line.value);
            Program.Sum_calibration_vals(calibration_vals);
            int solution = Program._solution;
            Console.WriteLine("The solution is: " + Convert.ToString(solution));
            calibration_vals = from line in prep_input select Program.Calibrate(Program.Precalibrate(line.value));
            Program.Sum_calibration_vals(calibration_vals);
            int solution2 = Program._solution;
            Console.WriteLine("The solution2 is: " + Convert.ToString(solution2));
        }
    }
}

