using System.Collections.ObjectModel;

namespace Menu;

public partial class ShoppingListPage : ContentPage
{
    public ShoppingListPage(ObservableCollection<ShoppingItem> shoppingList)
    {
        InitializeComponent();
        ShoppingListCollection.ItemsSource = shoppingList;
    }
}
