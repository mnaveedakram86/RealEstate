# 🏠 Property Finder App

A full-stack web application for searching, viewing, and saving properties to favorites.  
Built with **.NET Core (Backend)** and **React + Material UI (Frontend)**.

---

## 📌 Prerequisites

Before running the project, make sure you have installed:

- **Node.js** (v23 or higher) – [Download](https://nodejs.org/en/download/)
- **.NET 8 SDK** (or the version your backend uses) – [Download](https://dotnet.microsoft.com/en-us/download)
- **SQL Server** (LocalDB or full SQL Server instance)
- **Git** – [Download](https://git-scm.com/)

---

## ⚙ Backend Setup (.NET API)

1. **Navigate to Backend folder**
   ```bash
   cd backend
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Update database connection string**  
   - Open `appsettings.json`
   - Update the `ConnectionStrings:DefaultConnection` with your SQL Server connection string.

4. **Apply migrations & create database**
   ```bash
   dotnet ef database update
   ```

5. **Run the backend**
   ```bash
   dotnet run
   ```
   The API will be available at:
   ```
   https://localhost:7128
   ```

---

## 🎨 Frontend Setup (React App)

1. **Navigate to Frontend folder**
   ```bash
   cd frontend
   ```

2. **Install dependencies**
   ```bash
   npm install
   ```
  
3. **Run the frontend**
   ```bash
   npm start
   ```
   The React app will be available at:
   ```
   https://localhost:5173
   ```

---
## Notes
- The default API base URL is set to: `https://localhost:7128`
- The frontend URL is set to: `https://localhost:5173`
- If you change these URLs, make sure to update the CORS policy in your `Program.cs` in the backend and Update API base URL Frontend

Example CORS configuration in `Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("https://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

app.UseCors("AllowFrontend");

- Open `src/Js/constants.js`
- Set `API_BASE_URL` to your backend URL (e.g., `https://localhost:7128/api`).
---

## 🔐 Authentication Notes

- Uses **JWT authentication** with HttpOnly cookies for access and refresh tokens.
- User must register/login before accessing protected routes like Favorites.
- Token auto-refresh logic is implemented in Axios interceptors.

---

## 🛠 Tech Stack

**Backend:**
- .NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication

**Frontend:**
- React (CRA)
- Material UI
- Axios
- React Router
- Context
---

## 🚀 Features

- Search properties by filters
- View property details
- Save favorites (auth required)
- JWT authentication with refresh tokens
- Responsive UI

---

## 🤝 Contributing

1. Fork the repository
2. Create a new branch (`feature/your-feature`)
3. Commit your changes
4. Push the branch and create a pull request

---

## 📄 License

This project is licensed under the MIT License.


