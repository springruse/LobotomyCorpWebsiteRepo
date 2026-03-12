# Lobotomy Corp Weapon Forge 

A fan-made Blazor web application inspired by the world of **Lobotomy Corporation**. Users can create accounts and design custom weapons themed around the game's unique Abnormality-driven aesthetic — complete with EGO gear lore, risk levels, and weapon stats.

> ⚠️ This is a fan project and is not affiliated with Project Moon or the official Lobotomy Corporation IP.

---

## Table of Contents

- [Project Overview](#project-overview)
- [Setup & Installation](#setup--installation)
- [Contributing](#contributing)

---

## Project Overview

Lobotomy Corp Weapon Forge lets fans of *Lobotomy Corporation* and *Library of Ruina* express their creativity by building custom EGO weapons. Registered users can:

- **Create an account** and manage a personal weapon collection
- **Design weapons** with custom names, risk levels (ZAYIN → ALEPH), damage types, and lore descriptions
- **Save and delete** your creations at any time

The application is built with **Blazor Server** (ASP.NET Core), using a component-based architecture for a smooth, reactive UI without heavy JavaScript.

---

## Setup & Installation

### Prerequisites

Make sure you have the following installed:

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) (recommended) or VS Code with the C# Dev Kit extension
- A database provider — **SQL Server**, **SQLite**, or whatever is configured in `appsettings.json`
- Git

**Note: this was made using a real server and as such uses SQLSever, so using Sqlite on this project will required some setup and extra configuration**

### 1. Clone the Repository

```bash
git clone https://github.com/springruse/LobotomyCorpWebsiteRepo.git
cd LobotomyCorpWebsiteRepo
```

### 2. Configure the Database

Open `appsettings.json` (or `appsettings.Development.json`) and update the connection string to match your local database setup:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LobotomyCorpDb;Trusted_Connection=True;"
}
```

--If you are using a real sever, you can skip this part
### 3. Apply Migrations

Run Entity Framework Core migrations to create the database schema:

```bash
dotnet ef database update
```

If migrations don't exist yet, create them first:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

Then open your browser and navigate to `https://localhost:5001` (or whichever port is shown in the terminal).

### 5. Create an Account

Once the app is running, register an account through the UI and start forging weapons.

---

## Contributing

Contributions are welcome! Whether you're fixing bugs, adding new weapon fields, improving UI, or expanding the lore system — feel free to jump in.

### How to Contribute

1. **Fork** the repository on GitHub
2. **Create a branch** for your feature or fix:
   ```bash
   git checkout -b feature/my-new-feature
   ```
3. **Make your changes** and commit with a clear message:
   ```bash
   git commit -m "Add damage type selector to weapon builder"
   ```
4. **Push** to your fork:
   ```bash
   git push origin feature/my-new-feature
   ```
5. **Open a Pull Request** against the `main` branch and describe what you changed and why

### Guidelines

- Keep code style consistent with the existing project (follow standard C# / Blazor conventions)
- If you're adding a new feature, consider adding a brief comment or summary in the PR description
- Bug fixes should reference the relevant issue if one exists
- Be respectful — this is a fan project built for fun

### Ideas for Contributions

- Additional weapon stats (attack speed, sanity drain, EGO cost)
- Weapon card visual previews
- Risk level filtering and search
- Dark/light theme toggle
- Weapon rating or favoriting system

---

## License

This project is open source and available under the [MIT License](LICENSE).

*"We control what we don't understand by putting it to work."* — Lobotomy Corporation
