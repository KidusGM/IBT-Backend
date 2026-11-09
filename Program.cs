bool running = true;

while (running)
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("              MOBILE CARD TOP-UP");
    Console.WriteLine("==============================================");
    Console.WriteLine();

    Console.Write("Customer Name       : ");
    string name = Console.ReadLine() ?? "";

    Console.Write("Mobile Network      : ");
    string network = Console.ReadLine() ?? "";

    Console.Write("Top-Up Amount (ETB) : ");
    string amountInput = Console.ReadLine() ?? "";

    Console.WriteLine();

    // Validate amount
    if (!decimal.TryParse(amountInput, out decimal topUpAmount))
    {
        Console.WriteLine("Invalid amount. Please enter a valid number.");
    }
    else if (topUpAmount <= 0)
    {
        Console.WriteLine("Top-up amount must be greater than zero.");
    }
    else if (topUpAmount > 5000)
    {
        Console.WriteLine("Maximum top-up amount is 5,000.00 ETB.");
    }
    else
    {
        // Initial amount
        decimal initialAmount = topUpAmount;

        // Determine bonus rate
        decimal bonusRate = network.ToLower() switch
        {
            "ethio telecom" => 0.05m,
            "ethio" => 0.05m,
            "safaricom" => 0.03m,
            "safari" => 0.03m,
            _ => 0m
        };

        // Percentage bonus
        decimal percentageBonus = topUpAmount * bonusRate;

        // Fixed bonus for top-ups of 1,000 ETB or more
        decimal fixedBonus = 0m;

        if (topUpAmount >= 1000)
        {
            fixedBonus = 20m;
        }

        // Total bonus
        decimal totalBonus = percentageBonus + fixedBonus;

        // Final credit
        decimal finalCredit = initialAmount + totalBonus;

        // Receipt
        Console.WriteLine("==============================================");
        Console.WriteLine("                TOP-UP RECEIPT");
        Console.WriteLine("==============================================");

        Console.WriteLine($"{"Customer",-22}: {name}");
        Console.WriteLine($"{"Mobile Network",-22}: {network}");
        Console.WriteLine($"{"Initial Top-Up",-22}: {initialAmount:N2} ETB");
        Console.WriteLine($"{"Bonus Rate",-22}: {bonusRate:P0}");
        Console.WriteLine($"{"Percentage Bonus",-22}: {percentageBonus:N2} ETB");
        Console.WriteLine($"{"Fixed Bonus",-22}: {fixedBonus:N2} ETB");
        Console.WriteLine($"{"Total Bonus",-22}: {totalBonus:N2} ETB");

        Console.WriteLine("----------------------------------------------");

        Console.WriteLine($"{"FINAL CREDIT",-22}: {finalCredit:N2} ETB");

        Console.WriteLine("==============================================");
    }

    Console.WriteLine();
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. Top Up Again");
    Console.WriteLine("2. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
            break;

        case "2":
            running = false;
            Console.WriteLine();
            Console.WriteLine("Thank you for using Mobile Card Top-Up!");
            break;

        default:
            Console.WriteLine();
            Console.WriteLine("Invalid choice. Exiting...");
            running = false;
            break;
    }
}