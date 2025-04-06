using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using ProductApiEfApp.Models;

namespace ProductApiEfApp.Services
{
    public static class ProductService
    {
        public static async Task<List<Product>> FetchProductsFromApi()
        {
            using var http = new HttpClient();
            var url = "https://dummyjson.com/products";
            var response = await http.GetStringAsync(url);

            using var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;
            var items = root.GetProperty("products");

            var list = new List<Product>();
            foreach (var item in items.EnumerateArray())
            {
                list.Add(new Product
                {
                    Id = item.GetProperty("id").GetInt32(),
                    Title = item.GetProperty("title").GetString()!,
                    Description = item.GetProperty("description").GetString()!,
                    Price = item.GetProperty("price").GetDecimal(),
                    Category = item.GetProperty("category").GetString()!
                });
            }

            return list;
        }
    }
}