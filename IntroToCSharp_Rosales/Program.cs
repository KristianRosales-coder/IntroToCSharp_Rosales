using System;
using System.Linq;

/*
 * Author: Kristian Carlo Q. Rosales
 * Date: February 20, 2026
 * Description: Codac Logistics Delivery & Fuel Auditor
 */

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("   CODAC LOGISTICS FUEL AUDITOR SYSTEM   ");
        Console.WriteLine("==========================================\n");

        // ==================== TASK 1: DRIVER PROFILE & DISTANCE VALIDATION ====================
        
        Console.WriteLine("--- TASK 1: Driver Profile Setup ---");
        
        // Using string for name
        Console.Write("Enter Driver's Full Name: ");
        string driverName = Console.ReadLine();
        
        // Using decimal for budget with error handling
        decimal weeklyBudget = 0;
        bool validBudget = false;
        while (!validBudget)
        {
            Console.Write("Enter Weekly Fuel Budget ($): ");
            string budgetInput = Console.ReadLine();
            
            // Try to parse the input as decimal
            if (decimal.TryParse(budgetInput, out weeklyBudget))
            {
                if (weeklyBudget > 0)
                {
                    validBudget = true;
                }
                else
                {
                    Console.WriteLine("❌ Budget must be greater than 0. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid input. Please enter a valid number.");
            }
        }
        
        // Using double for distance with validation
        double totalDistance = 0;
        bool isValidDistance = false;
        
        Console.WriteLine("\n--- Distance Validation (must be between 1.0 and 5000.0 km) ---");
        while (!isValidDistance)
        {
            Console.Write("Enter Total Distance Traveled this week (km): ");
            string distanceInput = Console.ReadLine();
            
            // Try to parse the input as double
            if (double.TryParse(distanceInput, out totalDistance))
            {
                if (totalDistance >= 1.0 && totalDistance <= 5000.0)
                {
                    isValidDistance = true;
                    Console.WriteLine($"✓ Distance recorded: {totalDistance} km (Valid input)");
                }
                else
                {
                    Console.WriteLine("❌ ERROR: Distance must be between 1.0 and 5000.0 kilometers. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid input. Please enter a valid number.");
            }
        }
        
        Console.WriteLine("\n✅ Task 1 Complete: Driver profile created successfully!\n");
        
        // ==================== TASK 2: FUEL EXPENSE TRACKING ====================
        
        Console.WriteLine("--- TASK 2: Daily Fuel Expense Tracking ---");
        Console.WriteLine("Please enter fuel costs for each day (Monday to Friday)\n");
        
        decimal[] fuelExpenses = new decimal[5];
        decimal totalFuelSpent = 0;
        
        for (int i = 0; i < fuelExpenses.Length; i++)
        {
            bool validExpense = false;
            while (!validExpense)
            {
                Console.Write($"Enter fuel cost for Day {i + 1} (Monday-Friday): $");
                string expenseInput = Console.ReadLine();
                
                // Try to parse the input as decimal
                if (decimal.TryParse(expenseInput, out fuelExpenses[i]))
                {
                    if (fuelExpenses[i] > 0)
                    {
                        validExpense = true;
                        totalFuelSpent += fuelExpenses[i];
                        Console.WriteLine($"  Running total so far: ${totalFuelSpent:F2}\n");
                    }
                    else
                    {
                        Console.WriteLine("❌ Fuel cost must be greater than 0. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("❌ Invalid input. Please enter a valid number.");
                }
            }
        }
        
        Console.WriteLine("✅ Task 2 Complete: All daily expenses recorded!\n");
        
        // ==================== TASK 3: PERFORMANCE ANALYSIS ====================
        
        Console.WriteLine("--- TASK 3: Performance Analysis ---");
        
        decimal averageExpense = totalFuelSpent / 5;
        Console.WriteLine($"Average Daily Fuel Expense: ${averageExpense:F2}");
        
        // Calculate Fuel Efficiency Rating
        double efficiency = totalDistance / (double)totalFuelSpent;
        
        string efficiencyRating;
        if (efficiency > 15)
        {
            efficiencyRating = "HIGH EFFICIENCY - Excellent performance";
        }
        else if (efficiency >= 10)
        {
            efficiencyRating = "STANDARD EFFICIENCY - Normal operation";
        }
        else
        {
            efficiencyRating = "LOW EFFICIENCY - Maintenance Required";
        }
        
        Console.WriteLine($"Fuel Efficiency: {efficiency:F2} kilometers per dollar");
        Console.WriteLine($"Efficiency Rating: {efficiencyRating}");
        
        bool stayedUnderBudget = totalFuelSpent < weeklyBudget;
        Console.WriteLine($"Budget Status: {(stayedUnderBudget ? "✓ UNDER BUDGET" : "❌ OVER BUDGET")}");
        
        Console.WriteLine("✅ Task 3 Complete: Performance analysis finished!\n");
        
        // ==================== TASK 4: THE AUDIT REPORT ====================
        
        Console.WriteLine("--- TASK 4: Generating Audit Report ---\n");
        
        Console.WriteLine("==========================================");
        Console.WriteLine("       CODEC LOGISTICS FUEL AUDIT        ");
        Console.WriteLine("==========================================\n");
        
        Console.WriteLine($"Driver Information:");
        Console.WriteLine($"  Name: {driverName}");
        Console.WriteLine($"  Report Date: {DateTime.Now.ToString("MMMM dd, yyyy")}");
        Console.WriteLine($"  Report Time: {DateTime.Now.ToString("hh:mm tt")}\n");
        
        Console.WriteLine($"Weekly Budget: ${weeklyBudget:F2}\n");
        Console.WriteLine($"Distance Summary:");
        Console.WriteLine($"  Total Distance: {totalDistance:F2} km\n");
        
        Console.WriteLine($"Daily Expense Breakdown (5-Day Week):");
        Console.WriteLine($"  Day 1 (Monday):    ${fuelExpenses[0]:F2}");
        Console.WriteLine($"  Day 2 (Tuesday):   ${fuelExpenses[1]:F2}");
        Console.WriteLine($"  Day 3 (Wednesday): ${fuelExpenses[2]:F2}");
        Console.WriteLine($"  Day 4 (Thursday):  ${fuelExpenses[3]:F2}");
        Console.WriteLine($"  Day 5 (Friday):    ${fuelExpenses[4]:F2}\n");
        
        Console.WriteLine($"Financial Summary:");
        Console.WriteLine($"  Total Fuel Cost:    ${totalFuelSpent:F2}");
        Console.WriteLine($"  Average Daily Cost: ${averageExpense:F2}");
        Console.WriteLine($"  Remaining Budget:   ${(weeklyBudget - totalFuelSpent):F2}\n");
        
        Console.WriteLine($"Performance Summary:");
        Console.WriteLine($"  Efficiency Rating: {efficiencyRating}");
        Console.WriteLine($"  Kilometers per Dollar: {efficiency:F2}");
        Console.WriteLine($"  Under Budget: {stayedUnderBudget}\n");
        
        Console.WriteLine($"Budget Compliance Report:");
        if (stayedUnderBudget)
        {
            Console.WriteLine($"  ✓ GOOD: Driver stayed within budget");
            Console.WriteLine($"  ✓ Savings: ${(weeklyBudget - totalFuelSpent):F2}");
        }
        else
        {
            Console.WriteLine($"  ❌ ALERT: Driver exceeded budget");
            Console.WriteLine($"  ❌ Overspent: ${(totalFuelSpent - weeklyBudget):F2}");
        }
        
        Console.WriteLine("\n==========================================");
        Console.WriteLine("       END OF AUDIT REPORT               ");
        Console.WriteLine("==========================================");
        
        // Additional Statistics
        Console.WriteLine("\n--- Additional Statistics ---");
        if (fuelExpenses.Length > 0)
        {
            Console.WriteLine($"Highest Daily Expense: ${fuelExpenses.Max():F2}");
            Console.WriteLine($"Lowest Daily Expense: ${fuelExpenses.Min():F2}");
        }
        Console.WriteLine($"Total Days Recorded: {fuelExpenses.Length}");
        
        Console.WriteLine("\n✅ Task 4 Complete: Report generated successfully!\n");
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }
}