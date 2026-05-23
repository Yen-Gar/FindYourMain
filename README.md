# FindYourMain
````md

Een interactieve webapplicatie gebouwd met ASP.NET Core MVC waarmee gebruikers op basis van hun speelstijl een passend gamecharacter (“main”) kunnen vinden.

De applicatie ondersteunt meerdere games en gebruikt speelstijlfilters zoals aggressive, support, movement en strategy om characters aan te bevelen.

---

# Aan de slag

## Vereisten

- .NET 10
- Visual Studio 2026
- SQL Server / LocalDB

---

# Visual Studio

## Repository clonen

```bash
git clone https://github.com/JOUWNAAM/FindYourMain.git
```

## Database aanmaken

Open de Package Manager Console en voer uit:

```powershell
Update-Database
```

## Applicatie starten

Selecteer het juiste startup project en druk op:

- F5
of
- de groene HTTPS Play knop

---

# Visual Studio Code

## Repository clonen

```bash
git clone https://github.com/JOUWNAAM/FindYourMain.git
cd FindYourMain
```

## Database aanmaken

```bash
dotnet ef database update
```

Indien nodig:

```bash
dotnet tool install --global dotnet-ef
```

## Applicatie starten

```bash
dotnet run
```

---

# Functionaliteiten

- Game selectie
- Character aanbevelingen
- Speelstijl filters
- Database opslag
- Responsive design
- Formuliervalidatie

---

# Technologie Stack

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server / LocalDB
- HTML, CSS, JavaScript
- Razor Views

---

# Gitflow Workflow

| Branch | Doel |
|---|---|
| main | Productiecode |
| development | Ontwikkeling |
| feature/naam | Nieuwe features |
| fix/naam | Bugfixes |
| release/versie | Releases |

---

# Commit Conventies

- feat → nieuwe functionaliteit
- fix → bugfix
- docs → documentatie
- style → styling wijzigingen
- chore → onderhoud/tools

Voorbeeld:

```bash
feat: added character recommendation system
```

---

# Testen

Automatische testen uitvoeren:

```bash
dotnet test
```

---

# Auteur

YC  
HBO-ICT Windesheim  
Software Engineering – Web Development
````

