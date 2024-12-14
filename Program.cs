using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Simple Calculator");
                Console.WriteLine("=================\n");

                try
                {
                    // Input first number
                    Console.Write("Enter the first number: ");
                    double num1 = Convert.ToDouble(Console.ReadLine());

                    // Input operator
                    Console.Write("Enter an operator (+, -, *, /): ");
                    char op = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    // Input second number
                    Console.Write("Enter the second number: ");
                    double num2 = Convert.ToDouble(Console.ReadLine());

                    // Perform calculation
                    double result = 0;
                    bool validOperation = true;

                    switch (op)
                    {
                        case '+':
                            result = num1 + num2;
                            break;
                        case '-':
                            result = num1 - num2;
                            break;
                        case '*':
                            result = num1 * num2;
                            break;
                        case '/':
                            if (num2 != 0)
                                result = num1 / num2;
                            else
                            {
                                Console.WriteLine("Error: Division by zero is not allowed.");
                                validOperation = false;
                            }
                            break;
                        default:
                            Console.WriteLine("Error: Invalid operator.");
                            validOperation = false;
                            break;
                    }

                    // Display result
                    if (validOperation)
                        Console.WriteLine($"Result: {num1} {op} {num2} = {result}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a valid number.");
                }

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
