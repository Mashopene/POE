using recipe_app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RecipeManagementApp
{
    public partial class RecipeDetailWindow : Window
    {
        public RecipeDetailWindow(Recipe recipe)
        {
            InitializeComponent();
            DisplayRecipe(recipe);
        }

        private void DisplayRecipe(Recipe recipe)
        {
            RecipeNameTextBlock.Text = recipe.Name;
            RecipeDetailsTextBox.Text = recipe.ToString();
            TotalCaloriesTextBlock.Text = $"Total Calories: {recipe.CalculateTotalCalories()}";
        }
    }
}
