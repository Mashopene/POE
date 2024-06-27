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
    public partial class AddRecipeWindow : Window
    {
        public Recipe NewRecipe { get; private set; }

        public AddRecipeWindow()
        {
            InitializeComponent();
            NewRecipe = new Recipe("");
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var addIngredientWindow = new AddIngredientWindow();
            if (addIngredientWindow.ShowDialog() == true)
            {
                NewRecipe.AddIngredient(addIngredientWindow.NewIngredient);
                IngredientsListBox.Items.Add(addIngredientWindow.NewIngredient.Name);
            }
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (IngredientsListBox.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one ingredient.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewRecipe.Name = RecipeNameTextBox.Text;
            DialogResult = true;
            Close();
        }
    }
}
