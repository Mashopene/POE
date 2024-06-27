using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe_app
{
    // Recipe class represents a recipe consisting of ingredients and steps
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        // Delegate for calorie notification
        public delegate void CalorieNotification(string message);
        public event CalorieNotification OnCalorieNotification;

        // Constructor to initialize a recipe
        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            CheckCalories();
        }

        // Method to add a step to the recipe
        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        // Method to scale the quantities of all ingredients
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Scale(factor);
            }
        }

        // Method to reset quantities to original values
        public void ResetQuantities(List<Ingredient> originalIngredients)
        {
            Ingredients = new List<Ingredient>(originalIngredients);
        }

        // Method to clear all data
        public void ClearAllData()
        {
            Ingredients.Clear();
            Steps.Clear();
        }

        // Method to calculate the total calories of the recipe
        public int CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories);
        }

        // Method to check if the total calories exceed 300
        private void CheckCalories()
        {
            if (CalculateTotalCalories() > 300)
            {
                OnCalorieNotification?.Invoke($"Warning: The total calories of the recipe '{Name}' exceed 300.");
            }
        }

        // Method to represent the recipe as a string
        public override string ToString()
        {
            StringBuilder recipeString = new StringBuilder();

            recipeString.AppendLine($"Recipe: {Name}");
            recipeString.AppendLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                recipeString.AppendLine(ingredient.ToString());
            }

            recipeString.AppendLine("\nSteps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                recipeString.AppendLine($"{i + 1}. {Steps[i]}");
            }

            int totalCalories = CalculateTotalCalories();
            recipeString.AppendLine($"\nTotal Calories: {totalCalories}");

            // Add a warning message if calories exceed 300
            if (totalCalories > 300)
            {
                recipeString.AppendLine("Calories have exceeded 300.");
            }

            return recipeString.ToString();
        }
    }
}