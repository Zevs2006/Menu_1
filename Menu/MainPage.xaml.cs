using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace Menu;

    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Recipe> Recipes { get; set; } = new();
        public ObservableCollection<ShoppingItem> ShoppingList { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();
            LoadRecipes();
            RecipesCollection.ItemsSource = Recipes;
        }

        private void LoadRecipes()
        {
            Recipes.Add(new Recipe
            {
                Name = "Салат",
                Category = "Закуски",
                CookTime = "15 минут",
                Ingredients = new Dictionary<string, string>
                {
                    { "Овощи", "200 г" },
                    { "Салат", "50 г" },
                    { "Орехи", "20 г" },
                    { "Масло", "30 мл" }
                }
            });

            Recipes.Add(new Recipe
            {
                Name = "Пицца",
                Category = "Основное блюдо",
                CookTime = "40 минут",
                Ingredients = new Dictionary<string, string>
                {
                    { "Тесто", "300 г" },
                    { "Сыр", "200 г" },
                    { "Томат", "100 г" },
                    { "Пепперони", "150 г" }
                }
            });
            // Добавьте остальные рецепты...
        }

        private void OnAddToShoppingListClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button?.CommandParameter is Recipe recipe)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    var existingItem = ShoppingList.FirstOrDefault(i => i.Name == ingredient.Key);
                    if (existingItem != null)
                    {
                        existingItem.Quantity += ingredient.Value;
                    }
                    else
                    {
                        ShoppingList.Add(new ShoppingItem { Name = ingredient.Key, Quantity = ingredient.Value });
                    }
                }
            }
        }

        private async void OnViewShoppingListClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingListPage(ShoppingList));
        }
    }

    // Модель данных для рецептов
    public class Recipe
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string CookTime { get; set; }
        public Dictionary<string, string> Ingredients { get; set; }
    }

    // Модель данных для списка покупок
    public class ShoppingItem
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
    }
