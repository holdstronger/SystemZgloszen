# Dokumentacja projektu: System zgłoszeń

 Instalacja projektu

### Wymagania systemowe:
- System operacyjny: Windows 10/11
- Zainstalowane środowisko Visual Studio 2022 lub nowsze
- Pakiety NuGet:
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.AspNetCore.Mvc
  - Microsoft.AspNetCore.Razor

### Instalacja krok po kroku:
1. Pobierz kod projektu lub sklonuj repozytorium.
2. Otwórz projekt w Visual Studio.
3. W pliku `appsettings.json` dodaj connection string do bazy danych SQL Server:
   
    "ConnectionStrings": {
     "BugTrackingDBConnection": "Server=127.0.0.1;Database=BugTrackerDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;"
 }
   ```
4. W `Package Manager Console` wykonaj komendy migracji:
   ```bash
   Add-Migration InitialCreate
   Update-Database
   ```
Struktura folderów projektu:
- `Controllers/`
  - `ZgloszeniaController.cs` (kontroler obsługujący zgłoszenia)
- `Views/Zgloszenia/`
  - `Index.cshtml` (lista zgłoszeń)
  - `Create.cshtml` (formularz tworzenia zgłoszenia)
  - `Details.cshtml` (szczegóły zgłoszenia)
- `Data/`
  - `AplikacjaContext.cs` (kontekst bazy danych)


 Opis działania aplikacji z perspektywy użytkownika:
1. Po uruchomieniu aplikacji użytkownik widzi ekran główny z menu nawigacyjnym.
2. Kliknięcie „Zgłoszenie błędu” przenosi do formularza, gdzie użytkownik może wprowadzić szczegóły zgłoszenia.
3. Po wypełnieniu formularza i kliknięciu „Dodaj” zgłoszenie jest zapisywane w bazie danych.
4. Zgłoszenie można przeglądać, edytować i usuwać poprzez odpowiednie akcje w widoku szczegółowym.
