using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteOffice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "hello world";
            string reversed = ReverseString(input);
            Console.WriteLine(reversed);  // Output: "dlrow olleh"

            int[] numbers = { 1, 4, 2, 7, 3 };
            int largestNumber = GetLargestNumber(numbers);
            Console.WriteLine(largestNumber);  // Output: 7


            int number = 17;
            bool isPrime = IsPrimeNumber(number);
            Console.WriteLine(isPrime);  // Output: True

            int n = 15;
            PrintFizzBuzz(n);


            Node<int> head = new Node<int>(1);
            head.Next = new Node<int>(2);
            head.Next.Next = new Node<int>(3);
            head.Next.Next.Next = new Node<int>(4);

            Node<int> reversedHead =Node<int>.ReverseLinkedList(head);

            Console.WriteLine(reversedHead.Value); // 4
            Console.WriteLine(reversedHead.Next.Value); // 3
            Console.WriteLine(reversedHead.Next.Next.Value); // 2
            Console.WriteLine(reversedHead.Next.Next.Next.Value); // 1

        }

        public static string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.");
            }

            int length = input.Length;
            StringBuilder reversed = new StringBuilder(length);

            for (int i = length - 1; i >= 0; i--)
            {
                reversed.Append(input[i]);
            }

            return reversed.ToString();
        }

        public static int GetLargestNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Input array cannot be null or empty.");
            }

            int maxNumber = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }

            return maxNumber;
        }

        public static bool IsPrimeNumber(int number)
        {
            if (number <= 1)
            {
                throw new ArgumentException("Input number must be greater than 1.");
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void PrintFizzBuzz(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Input number must be greater than 0.");
            }

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }

        public static Node<T> ReverseLinkedList(Node<T> head)
        {
            if (head == null)
            {
                return null;
            }

            Node<T> prev = null;
            Node<T> current = head;
            Node<T> next = current.Next;

            while (next != null)
            {
                current.Next = prev;
                prev = current;
                current = next;
                next = current.Next;
            }

            current.Next = prev;
            return current;
        }
    }
}
