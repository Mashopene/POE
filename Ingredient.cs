using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe_app
{
    // Ingredient class represents an ingredient in a recipe
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        // Constructor to initialize an ingredient
        public Ingredient(string name, double quantity, string unitOfMeasurement, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        // Method to scale the quantity of the ingredient
        public void Scale(double factor)
        {
            Quantity *= factor;
        }

        // Method to represent the ingredient as a string
        public override string ToString()
        {
            return $"{Quantity} of {Name}\nUnits of Measurement: {UnitOfMeasurement}\nFood Group: {FoodGroup}\nCalories: {Calories}";
        }
    }
}

