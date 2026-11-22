
using System;
using System.Collections.Generic;
using System.Globalization;

namespace AddisEats.Day_2_Exercises
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("=== Addis Eats Exercises ===");
            Console.WriteLine("1. Environment information");
            Console.WriteLine("2. Console output");
            Console.WriteLine("3. Primitive types");
            Console.WriteLine("4. Receipt formatting");
            Console.WriteLine("5. Integer division");
            Console.WriteLine("6. Value vs reference types");
            Console.WriteLine("7. Null handling");
            Console.WriteLine("8. Safe ETB parsing");

            Console.Write("Choose an exercise (1-8): ");

            string? input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(
                            " Welcome to Module-4 DotNet Program Which we will learn Intersting things Run dotnet --info in the terminal for Exercise 2.");
                        break;

                    case 2:
                        Exercise2();
                        break;

                    case 3:
                        Exercise3();
                        break;

                    case 4:
                        Exercise4();
                        break;

                    case 5:
                        Exercise5();
                        break;

                    case 6:
                        Exercise6();
                        break;

                    case 7:
                        Exercise7();
                        break;

                    case 8:
                        Exercise8();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Choose 1-8.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }


        // Exercise 2
        static void Exercise2()
        {
            Console.WriteLine("Kidus Girum");
            Console.WriteLine(DateTime.Today.ToString("16 11 2026"));
            Console.WriteLine("CodeOps Module 4 — .NET track");
        }

        // Exercise 3
        static void Exercise3()
        {
            int menuItemId = 101;
            long orderNumber = 20261122001L;
            short tableNumber = 12;
            byte quantity = 2;
            decimal price = 1480.50m;
            double averageRating = 4.7;
            float deliveryDistance = 3.5f;
            bool isAvailable = true;
            char categoryCode = 'M';
            string menuItemName = "Doro Wot";

            Console.WriteLine($"int: {menuItemId}");
            Console.WriteLine($"long: {orderNumber}");
            Console.WriteLine($"short: {tableNumber}");
            Console.WriteLine($"byte: {quantity}");
            Console.WriteLine($"decimal: {price}");
            Console.WriteLine($"double: {averageRating}");
            Console.WriteLine($"float: {deliveryDistance}");
            Console.WriteLine($"bool: {isAvailable}");
            Console.WriteLine($"char: {categoryCode}");
            Console.WriteLine($"string: {menuItemName}");
        }

        // Exercise 4
        static void Exercise4()
        {
            decimal subtotal = 1480.5m;
            decimal deliveryFee = 60m;
            decimal total = subtotal + deliveryFee;

            Console.WriteLine($"Subtotal: {subtotal,10:N2}");
            Console.WriteLine($"Delivery: {deliveryFee,10:N2}");
            Console.WriteLine($"Total:    {total,10:N2}");
        }

        // Exercise 5
        static void Exercise5()
        {
            int integerResult = 7 / 2;
            decimal decimalResult = (decimal)7 / 2;

            Console.WriteLine($"Integer division: {integerResult}");
            Console.WriteLine($"Decimal division: {decimalResult}");

            // Use decimal for a delivery fee split to preserve fractional amounts.
        }

        // Exercise 6
        static void Exercise6()
        {
            // int is a value type, so assigning it copies the value.
            int firstNumber = 10;
            int copiedNumber = firstNumber;

            firstNumber = 20;

            Console.WriteLine($"Original int: {firstNumber}");
            Console.WriteLine($"Copied int: {copiedNumber}");

            // List<string> is a reference type, so both variables refer to the same list.
            List<string> originalItems =
                new List<string> { "Doro Wot", "Shiro" };

            List<string> copiedItems = originalItems;

            originalItems.Add("Tibs");

            Console.WriteLine(
                $"Original list: {string.Join(", ", originalItems)}");

            Console.WriteLine(
                $"Copied list: {string.Join(", ", copiedItems)}");
        }

        // Exercise 7
        static void Exercise7()
        {
            string? restaurantName = null;

            // Explicit null check
            if (restaurantName != null)
            {
                Console.WriteLine(
                    $"Explicit check: {restaurantName.Length}");
            }
            else
            {
                Console.WriteLine("Explicit check: 0");
            }

            // Null-coalescing operator
            Console.WriteLine(
                $"Using ??: {restaurantName?.Length ?? 0}");

            // Null-conditional operator
            Console.WriteLine(
                $"Using ?.: {restaurantName?.Length}");
        }

        // Exercise 8
        static void Exercise8()
        {
            Console.Write("Enter an ETB amount: ");
            string? input = Console.ReadLine();

            if (decimal.TryParse(
                    input,
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out decimal amount)
                && amount > 0)
            {
                Console.WriteLine($"Amount: {amount:N2} ETB");
            }
            else
            {
                Console.WriteLine(
                    "Invalid amount. Enter a number greater than zero.");
            }
        }
    }
}
