using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public class Messages
    {
        public static void AlreadyExistsMessage(string title, string value) => Console.WriteLine($"{title} - {value} already exists");
        public static void ErrorOccuredMessage() => Console.WriteLine("Error occured, try again");
        public static void NotFoundMessage(string title) => Console.WriteLine($"{title} is not found");
        public static void SuccessMessage(string title, string value) => Console.WriteLine($"process for {title} - {value} successfully done");
        public static void InputMessage(string title) => Console.WriteLine($"Input {title}");
        public static void InvalidInputMessage(string title) => Console.WriteLine($"{title} is invalid");
    }
}
