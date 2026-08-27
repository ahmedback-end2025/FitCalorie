# 🥗 FitCalorie

A calorie and macro tracking web application built with **ASP.NET Core MVC**. Users register with their body metrics and fitness goal, and the app calculates their personalized daily calorie and macro targets (protein, carbs, fats) using the **Mifflin-St Jeor equation**, then lets them log meals and track progress against those targets in real time.

🔗 **Repository:** [github.com/ahmedback-end2025/FitCalorie](https://github.com/ahmedback-end2025/FitCalorie)

---

## ✨ Features

- **User Authentication** — Register/Login powered by ASP.NET Core Identity
- **Personalized Targets** — Daily calorie & macro goals calculated from age, gender, height, weight, and fitness goal (Cutting/Bulking)
- **Meal Logging** — Log meals from a seeded food database (grams-based portions), via AJAX for a smooth experience
- **Live Dashboard** — Visual progress bars for calories, protein, carbs, and fats consumed vs. target
- **Today's Meals** — Full breakdown of the day's logged meals with the ability to delete entries
- **Editable Profile** — Update weight, height, and fitness goal at any time to recalculate targets

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core MVC (.NET 8) |
| Authentication | ASP.NET Core Identity |
| ORM / Database | Entity Framework Core + SQL Server |
| Frontend | Razor Views, Bootstrap 5 |
| Client-side | Vanilla JavaScript (Fetch API for AJAX meal logging) |

---

## 📐 How Target Calculation Works

Targets are calculated using the **Mifflin-St Jeor equation** for Basal Metabolic Rate (BMR):

```
BMR (Male)   = (10 × weight) + (6.25 × height) - (5 × age) + 5
BMR (Female) = (10 × weight) + (6.25 × height) - (5 × age) - 161
```

The BMR is then multiplied by an activity factor (1.375) to get **TDEE** (Total Daily Energy Expenditure), and adjusted based on the user's goal:

- **Bulking** → TDEE + 400 kcal surplus
- **Cutting** → TDEE − 500 kcal deficit

Macros are then split as: **Protein** = 2.2g/kg bodyweight, **Fats** = 25% of target calories, **Carbs** = remaining calories.

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB is fine for local development)
- Visual Studio 2022 (or your editor of choice)

### Setup

1. **Clone the repository**
   ```bash
   git clone git@github.com:ahmedback-end2025/FitCalorie.git
   cd FitCalorie
   ```

2. **Configure your connection string**

   Create an `appsettings.Development.json` file in the project root (this file is git-ignored and won't be committed) with your local SQL Server connection string:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=FitCalorieDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
     }
   }
   ```

3. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the project**
   ```bash
   dotnet run
   ```

   Or press **F5** in Visual Studio.

5. Open your browser at the URL shown in the console (e.g. `https://localhost:5001`), register an account, and start tracking!

---

## 📸 Screenshots

> _Add a few screenshots here (Login, Dashboard, Log Meal) before publishing._

---

## 📄 License

This project is open source and available for learning purposes.
