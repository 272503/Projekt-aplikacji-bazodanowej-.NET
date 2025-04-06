# Projekt-aplikacji-bazodanowej-.NET – Konsolowa aplikacja z bazą danych EF Core i API

## 📌 Autor
- **Imię i nazwisko**: Piotr Kosior
- **Nr indeksu**: 272503

## 📦 Opis projektu
Aplikacja konsolowa w języku C# wykorzystująca **Entity Framework Core** oraz **SQLite** do przechowywania danych o produktach. Dane te pobierane są z zewnętrznego API `https://dummyjson.com/products`. Program umożliwia interakcję z bazą danych przez menu konsolowe.

Obsługiwane operacje na bazie danych
Z poziomu aplikacji użytkownik może:

1. Wyświetlić wszystkie produkty
2. Dodać nowy produkt
3. Filtruj produkty po kategorii
4. Sortować produkty po cenie malejąco
5. Usunąć produkt po podanym ID
6. Wyświetlić wszystkie dostępne kategorie
7. Wyczyścić bazę danych i pobrać dane na nowo z API
8. Wyświetlić szczegóły produktu po podanym ID

Dodatkowo, jeśli baza jest pusta przy uruchomieniu programu, dane zostaną automatycznie pobrane z API.

## 🔧 Kluczowe klasy i metody

### `Product` (Models/Product.cs)
Reprezentuje produkt w bazie danych:
- `Id` – klucz główny
- `Title`, `Description`, `Price`, `Category` – podstawowe informacje o produkcie

### `ProductDbContext` (Data/ProductDbContext.cs)
Konfiguracja bazy danych SQLite i dostęp do tabeli `Products`.

### `ProductService` (Services/ProductService.cs)
Zawiera metodę:
- `FetchProductsFromApi()` – pobiera dane z API, parsuje JSON i zwraca listę produktów.

### `Program.cs`
Główna logika aplikacji z interfejsem tekstowym:
- Inicjalizacja bazy danych
- Obsługa menu: dodawanie, filtrowanie, sortowanie, usuwanie i przeglądanie produktów
- Synchronizacja z API

## 📷 Zrzuty ekranu

### 📁 Struktura projektu:

![image](https://github.com/user-attachments/assets/d6bcf1ce-554e-4931-a6c6-8dbb9e0561f3)



### 💻 Kluczowy fragment programu:
![image](https://github.com/user-attachments/assets/38aae723-9cab-4fdb-ba62-61cbb58daaf6)


## 🚀 Jak uruchomić?
1. Zainstaluj .NET 8 lub nowszy
2. W terminalu:
    ```bash
    dotnet restore
    dotnet run
    ```
3. Program utworzy bazę danych `products.db` i pobierze dane, jeśli nie istnieją.

## 📄 Licencja
MIT License
