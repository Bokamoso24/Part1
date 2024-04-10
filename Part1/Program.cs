using System;

namespace recipe
{
    class Ingredient
    {
        public string Name { get; set; }    // Name of the ingredient
        public double Quantity { get; set; }    // Quantity of the ingredient
        public string Unit { get; set; }    // Unit of measurement for the ingredient
    }

    // Class to represent a step in the recipe
    class Step
    {
        public string Description { get; set; }    // Description of the step
    }

    // Class to represent the entire recipe
    class Recipe
    {
        public Ingredient[] Ingredients { get; set; }    // Array to store ingredients
        public Step[] Steps { get; set; }    // Array to store steps

        // Constructor to initialize the recipe with specified counts of ingredients and steps
        public Recipe(int ingredientCount, int stepCount)
        {
            Ingredients = new Ingredient[ingredientCount];
            Steps = new Step[stepCount];
        }

        // Method to display the entire recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i].Description}");
            }
        }

        // Method to scale the recipe 
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        // Method to reset ingredient quantities to their original values
        public void ResetQuantities()
        {
            // Iterate through ingredients and reset quantities to 1
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = 1;
            }
        }

        // Method to clear all data in the recipe
        public void ClearRecipe()
        {
            Ingredients = new Ingredient[Ingredients.Length];
            Steps = new Step[Steps.Length];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Recipe Manager!");

            Console.WriteLine("Enter the number of ingredients:");
            int ingredientCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of steps:");
            int stepCount = int.Parse(Console.ReadLine());

            Recipe recipe = new Recipe(ingredientCount, stepCount);

            // Input details for each ingredient
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                recipe.Ingredients[i] = new Ingredient();
                Console.Write("Name: ");
                recipe.Ingredients[i].Name = Console.ReadLine();
                Console.Write("Quantity: ");
                recipe.Ingredients[i].Quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit: ");
                recipe.Ingredients[i].Unit = Console.ReadLine();
            }

            // Input description for each step
            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter description for step {i + 1}:");
                recipe.Steps[i] = new Step();
                recipe.Steps[i].Description = Console.ReadLine();
            }

            // Display the recipe details
            Console.WriteLine("\nRecipe Details:");
            recipe.DisplayRecipe();

            // Scaling and resetting options
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Scale recipe");
                Console.WriteLine("2. Reset ingredient quantities");
                Console.WriteLine("3. Clear recipe and start over");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nEnter scaling factor (0.5 for half, 2 for double, 3 for triple):");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        Console.WriteLine("\nScaled Recipe Details:");
                        recipe.DisplayRecipe();
                        break;
                    case 2:
                        recipe.ResetQuantities();
                        Console.WriteLine("\nIngredient quantities reset to original values.");
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        recipe.ClearRecipe();
                        Console.WriteLine("\nRecipe cleared. Enter new recipe details:");
                        Main(args); // Restart the process
                        break;
                    case 4:
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
