using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductApiEfApp.Models
{
    public class Product
    {
        public int Id { get; set; } // ważne dla EF Core jako klucz główny
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;

        public override string ToString()
        {
            return $" {Id}. {Title} (${Price}) - {Category}";
        }
    }
}