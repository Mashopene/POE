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
    public partial class AddIngredientWindow : Window
    {
        public Ingredient NewIngredient { get; private set; }

        public AddIngredientWindow()
        {
            InitializeComponent();
            PopulateFoodGroups();
        }

        private void PopulateFoodGroups()
        {
            FoodGroupComboBox.Items.Add("Fruits");
            FoodGroupComboBox.Items.Add("Vegetables");
            FoodGroupComboBox.Items.Add("Grains");
            FoodGroupComboBox.Items.Add("Proteins");
            FoodGroupComboBox.Items.Add("Dairy");
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(QuantityTextBox.Text) ||
                string.IsNullOrWhiteSpace(UnitTextBox.Text) ||
                string.IsNullOrWhiteSpace(CaloriesTextBox.Text) ||
                FoodGroupComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(QuantityTextBox.Text, out double quantity) ||
                !int.TryParse(CaloriesTextBox.Text, out int calories))
            {
                MessageBox.Show("Invalid quantity or calories.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewIngredient = new Ingredient(
                NameTextBox.Text,
                quantity,
                UnitTextBox.Text,
                calories,
                FoodGroupComboBox.SelectedItem.ToString()
            );

            DialogResult = true;
            Close();
        }
    }
}
