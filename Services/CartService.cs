using System.Text.Json;
using DesignByTjader.Models;
using Microsoft.JSInterop;

namespace DesignByTjader.Services
{
    public class CartService
    {
        private readonly IJSRuntime _js;
        private const string CartKey = "designByTjaderCart";

        public List<CartItem> Items { get; private set; } = new();

        public CartService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task LoadCartAsync()
        {
            var json = await _js.InvokeAsync<string?>("localStorage.getItem", CartKey);

            if (!string.IsNullOrWhiteSpace(json))
            {
                Items = JsonSerializer.Deserialize<List<CartItem>>(json) ?? new List<CartItem>();
            }
        }

        private async Task SaveCartAsync()
        {
            var json = JsonSerializer.Serialize(Items);
            await _js.InvokeVoidAsync("localStorage.setItem", CartKey, json);
        }

        public async Task AddToCartAsync(Product product, string? selectedColor)
        {
            await LoadCartAsync();

            var existingItem = Items.FirstOrDefault(i =>
                i.ProductId == product.Id &&
                i.SelectedColor == selectedColor);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1,
                    SelectedColor = selectedColor
                });
            }

            await SaveCartAsync();
        }

        public async Task RemoveFromCartAsync(int productId)
        {
            await LoadCartAsync();

            var item = Items.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                Items.Remove(item);
                await SaveCartAsync();
            }
        }

        public async Task IncreaseQuantityAsync(int productId)
        {
            await LoadCartAsync();

            var item = Items.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                item.Quantity++;
                await SaveCartAsync();
            }
        }

        public async Task DecreaseQuantityAsync(int productId)
        {
            await LoadCartAsync();

            var item = Items.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                item.Quantity--;

                if (item.Quantity <= 0)
                {
                    Items.Remove(item);
                }

                await SaveCartAsync();
            }
        }

        public decimal GetTotalPrice()
        {
            return Items.Sum(i => i.TotalPrice);
        }

        public async Task ClearCartAsync()
        {
            Items.Clear();
            await _js.InvokeVoidAsync("localStorage.removeItem", CartKey);
        }
    }
}
