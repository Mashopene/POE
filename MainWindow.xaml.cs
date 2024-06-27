using recipe_app;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeManagementApp
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
            PopulateFoodGroups();
        }

        private void PopulateFoodGroups()
        {
            FoodGroupFilterComboBox.Items.Add(new ComboBoxItem { Content = "All", IsEnabled = true });
            FoodGroupFilterComboBox.Items.Add(new ComboBoxItem { Content = "Fruits", IsEnabled = true });
            FoodGroupFilterComboBox.Items.Add(new ComboBoxItem { Content = "Vegetables", IsEnabled = true });
            FoodGroupFilterComboBox.Items.Add(new ComboBoxItem { Content = "Grains", IsEnabled = true });
            FoodGroupFilterComboBox.Items.Add(new ComboBoxItem { Content = "Proteins", IsEnabled = true });
            FoodGroupFilterComboBox.Items.Add(new ComboBoxItem { Content = "Dairy", IsEnabled = true });
            FoodGroupFilterComboBox.SelectedIndex = 0;
        }

        private void AddNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipeWindow();
            if (addRecipeWindow.ShowDialog() == true)
            {
                recipes.Add(addRecipeWindow.NewRecipe);
                UpdateRecipeList();
            }
        }

        private void ListAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            ClearFilters();
            UpdateRecipeList();
        }

        private void ClearFilters()
        {
            IngredientFilterTextBox.Text = string.Empty;
            FoodGroupFilterComboBox.SelectedIndex = 0;
            CalorieFilterTextBox.Text = string.Empty;
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string ingredientFilter = IngredientFilterTextBox.Text.ToLower();
            string foodGroupFilter = (FoodGroupFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            int maxCalories = int.TryParse(CalorieFilterTextBox.Text, out int calories) ? calories : int.MaxValue;

            var filteredRecipes = recipes.Where(r =>
                (string.IsNullOrEmpty(ingredientFilter) || r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredientFilter))) &&
                (foodGroupFilter == "All" || r.Ingredients.Any(i => i.FoodGroup == foodGroupFilter)) &&
                r.CalculateTotalCalories() <= maxCalories
            ).OrderBy(r => r.Name);

            UpdateRecipeList(filteredRecipes);
        }

        private void UpdateRecipeList(IEnumerable<Recipe> recipesToDisplay = null)
        {
            RecipeListBox.Items.Clear();
            var displayRecipes = recipesToDisplay ?? recipes.OrderBy(r => r.Name);
            foreach (var recipe in displayRecipes)
            {
                RecipeListBox.Items.Add(recipe.Name);
            }
        }

        private void RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                string selectedRecipeName = RecipeListBox.SelectedItem.ToString();
                var selectedRecipe = recipes.FirstOrDefault(r => r.Name == selectedRecipeName);
                if (selectedRecipe != null)
                {
                    var recipeDetailWindow = new RecipeDetailWindow(selectedRecipe);
                    recipeDetailWindow.Show();
                }
            }
        }
    }
}