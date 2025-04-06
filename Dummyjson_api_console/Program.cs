using System.Text.Json;

using ProductApiEfApp.Data;
using ProductApiEfApp.Models;
using ProductApiEfApp.Services;

using ProductApiEfApp.Data;
using ProductApiEfApp.Models;
using ProductApiEfApp.Services;

class Program
{
    static async Task Main(string[] args)
    {
        using var db = new ProductDbContext();
        db.Database.EnsureCreated();

        if (!db.Products.Any())
        {
            Console.WriteLine("Brak danych w bazie. Pobieranie z API...");
            var products = await ProductService.FetchProductsFromApi();
            db.Products.AddRange(products);
            db.SaveChanges();
            Console.WriteLine($"Dodano {products.Count} produktów do bazy.");
        }

        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Wyświetl wszystkie produkty");
            Console.WriteLine("2. Dodaj nowy produkt");
            Console.WriteLine("3. Filtruj po kategorii");
            Console.WriteLine("4. Sortuj po cenie malejąco");
            Console.WriteLine("5. Usuń produkt po ID");
            Console.WriteLine("6. Wyświetl kategorie");
            Console.WriteLine("7. Wyczyść baze");
            Console.WriteLine("8. Wyświetl produkt o ID:");
            Console.WriteLine("0. Wyjście");
            Console.Write("Wybierz opcję: ");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    foreach (var p in db.Products.OrderBy(p => p.Id))
                        Console.WriteLine(p);
                    break;
                case "2":
                    Console.Write("Nazwa: ");
                    var title = Console.ReadLine();
                    Console.Write("Opis: ");
                    var desc = Console.ReadLine();
                    Console.Write("Cena: ");
                    var price = decimal.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Kategoria: ");
                    var cat = Console.ReadLine();
                    var newProduct = new Product { Title = title!, Description = desc!, Price = price, Category = cat! };
                    db.Products.Add(newProduct);
                    db.SaveChanges();
                    Console.WriteLine("Produkt dodany.");
                    break;
                case "3":
                    Console.Write("Podaj kategorię: ");
                    var filterCat = Console.ReadLine();
                    var filtered = db.Products.Where(p => p.Category.ToLower() == filterCat!.ToLower());
                    foreach (var p in filtered) Console.WriteLine(p);
                    break;
                case "4":
                    var sorted = db.Products.ToList().OrderByDescending(p => p.Price);
                    foreach (var p in sorted) Console.WriteLine(p);
                    break;
                case "5":
                    Console.Write("Podaj ID produktu do usunięcia: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        var toDelete = db.Products.FirstOrDefault(p => p.Id == id);
                        if (toDelete != null)
                        {
                            db.Products.Remove(toDelete);
                            db.SaveChanges();
                            Console.WriteLine("Usunięto produkt.");
                        }
                        else Console.WriteLine("Nie znaleziono produktu.");
                    }
                    break;
                case "6":
                    var categories = db.Products
                        .Select(p => p.Category)
                        .Distinct()
                        .OrderBy(c => c)
                        .ToList();

                    Console.WriteLine("Dostępne kategorie:");
                    foreach (var ctg in categories)
                    {
                        Console.WriteLine($"- {ctg}");
                    }
                    break;
                case "7":
                    db.Products.RemoveRange(db.Products);
                    db.SaveChanges();
                    Console.WriteLine("Baza wyczyszczona, ponowne pobieranie z Api");
                    var products = await ProductService.FetchProductsFromApi();
                    db.Products.AddRange(products);
                    db.SaveChanges();
                    Console.WriteLine($"Dodano {products.Count} produktów do bazy.");
                    break;
                case "8":
                    Console.Write("Podaj ID produktu: ");
                    if (int.TryParse(Console.ReadLine(), out int id_))
                    {
                        var produkt = db.Products.FirstOrDefault(p => p.Id == id_);
                        if (produkt != null)
                        {
                            Console.WriteLine("Id: " + produkt.Id);
                            Console.WriteLine("Nazwa: " + produkt.Title);
                            Console.WriteLine("Opis: " + produkt.Description);                            
                            Console.WriteLine("Cena: " + produkt.Price);
                            Console.WriteLine("Kategoria: " + produkt.Category);
                        }
                        else Console.WriteLine("Nie znaleziono produktu.");
                    }
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
        }
    }
}