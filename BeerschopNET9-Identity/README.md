# BeerschopNET9-Identity

A .NET 9 ASP.NET Core MVC e-commerce beer shop application with ASP.NET Identity, role-based authorization, and a session-based shopping cart.

---

## Solution Structure

```
BeerschopNET9-Identity/
├── BeerschopNET9-Identity/        # Web (MVC) project
├── Beershop.Domain/               # Entities + BeerDbContext
├── Beershop.Repositories/         # Data access (DAOs)
└── Beershop.Services/             # Business logic (Services)
```

**Dependency chain:** Web → Services → Repositories → Domain → Database

---

## Projects

### BeerschopNET9-Identity (Web)
ASP.NET Core MVC app. Entry point is `Program.cs`.

Key NuGet packages:
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` + `.UI`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `AutoMapper.Extensions.Microsoft.DependencyInjection`

### Beershop.Domain
Contains all entities and `BeerDbContext`.

### Beershop.Repositories
Contains `IDAO<T>` interface and `BeerDAO` implementation.

### Beershop.Services
Contains `IService<T>` interface and `BeerService` implementation.

---

## Database

Two separate EF Core DbContexts, both pointing to SQL Server:

| Context | Purpose | Connection |
|---|---|---|
| `ApplicationDbContext` | ASP.NET Identity tables | `DefaultConnection` in `appsettings.json` |
| `BeerDbContext` | Beer shop domain data | Same connection string, hardcoded in Domain |

**Connection string** (`appsettings.json`):
```
Server=.\SQL22_VIVES; Database=Biersql; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true
```

### Identity Migrations (in Web project)
- `00000000000000_CreateIdentitySchema` — base identity tables
- `20260211100920_AddExtraFieldsToUser` — adds `Adress`, `BirthYear`, `PostalCode`
- `20260211104100_AddExtraFieldsToUserName` — adds name fields
- `20260211111619_AddExtraFieldsToUserName2`
- `20260211112647_AddExtraFieldsToUser2`

---

## Domain Entities

### Beer
| Field | Type | Notes |
|---|---|---|
| `Biernr` | int | PK |
| `Naam` | string (50) | Fixed length |
| `Brouwernr` | int | FK → Brewery |
| `Soortnr` | int | FK → Variety |
| `Alcohol` | decimal(3,2) | |
| `Image` | string (50) | Fixed length |

### Brewery
| Field | Type | Notes |
|---|---|---|
| `Brouwernr` | int | PK, no auto-generation |
| `Naam` | string (50) | |
| `Adres` | string (60) | |
| `Postcode` | string (10) | |
| `Gemeente` | string (40) | |
| `Omzet` | decimal(12,2) | |

### Variety
| Field | Type | Notes |
|---|---|---|
| `Soortnr` | int | PK, no auto-generation |
| `Soortnaam` | string (30) | Non-unicode, fixed length |

### ApplicationUser (extends IdentityUser)
Custom fields added on top of standard Identity:
| Field | Type | Notes |
|---|---|---|
| `FirstName` | string | Required |
| `LastName` | string | Required |
| `BirthYear` | int | Range 1900–2100 |
| `Adress` | string (200) | |
| `PostalCode` | int | Max 4 digits |

---

## Architecture

### Interfaces

**`IDAO<T>`** (Beershop.Repositories)
```
GetAllAsync()     → IEnumerable<T>?
FindByIdAsync(id) → T?
AddAsync(entity)
UpdateAsync(entity)
DeleteAsync(entity)
```

**`IService<T>`** (Beershop.Services) — same contract, delegates to IDAO.

### Implementations
- `BeerDAO` implements `IDAO<Beer>` — uses `BeerDbContext`, includes related `Brewery` and `Variety` on queries
- `BeerService` implements `IService<Beer>` — delegates entirely to `BeerDAO`

### DI Registration (Program.cs)
```csharp
AddScoped<IService<Beer>, BeerService>()
AddScoped<IDAO<Beer>, BeerDAO>()
AddDbContext<ApplicationDbContext>(...)   // Identity
AddDbContext<BeerDbContext>(...)          // Beer domain
AddDefaultIdentity<ApplicationUser>(...).AddRoles<IdentityRole>()
AddAutoMapper(typeof(Program))
AddSession()  // Cookie: "be.VIVES.Session", timeout: 10 min
```

---

## Controllers

| Controller | Route | Auth | Description |
|---|---|---|---|
| `HomeController` | `/` | — | Home + Privacy pages |
| `BeerController` | `/Beer` | `[Authorize(Roles="User")]` (Index is AllowAnonymous) | Beer catalog + add to cart |
| `ShoppingCartController` | `/ShoppingCart` | Payment requires auth | Cart CRUD + payment |
| `SessionController` | `/Session` | — | Demo: write to session |
| `Session2Controller` | `/Session2` | — | Demo: read from session |

### BeerController actions
- `Index()` — lists all beers (AllowAnonymous), mapped to `BeerVM` via AutoMapper
- `Select(int? id)` — adds beer to session cart

### ShoppingCartController actions
- `Index()` — displays cart
- `Update(int beerNumber, int count)` — POST, updates quantity
- `Remove(int id)` — removes item
- `Clear()` — clears full cart
- `Payment()` — requires auth, processes payment flow

---

## ViewModels

| ViewModel | Fields |
|---|---|
| `BeerVM` | `Biernr`, `Naam`, `BrouwerNaam`, `SoortNaam`, `Alcohol`, `Image` |
| `CartVM` | `BeerNumber`, `Name`, `Count`, `Price`, `DateCreated` |
| `ShoppingCartVM` | `Carts` (List\<CartVM\>) |
| `SessionVM` | `Date`, `Company` |
| `ErrorViewModel` | `RequestId`, `ShowRequestId` |

### AutoMapper Profile
`Beer` → `BeerVM`:
- `BrouwerNaam` ← `BrouwernrNavigation.Naam`
- `SoortNaam` ← `SoortnrNavigation.Soortnaam`

---

## Session

Shopping cart is stored in HTTP session using custom extensions:

```csharp
// SessionExtensions.cs
session.SetObject<T>(key, value)   // serializes to JSON
session.GetObject<T>(key)          // deserializes from JSON
```

Uses `Newtonsoft.Json`. Session cookie name: `be.VIVES.Session`, idle timeout: 10 minutes.

---

## Identity / Auth

- Scaffolded Identity pages under `Areas/Identity/Pages/Account/`
- Pages: `Register`, `Login`, `Logout`, `ForgotPassword`, `ResetPassword`, `ConfirmEmail`, `ResendEmailConfirmation`
- `Register` has custom fields: `FirstName`, `LastName`, `BirthYear`, `Adress`, `PostalCode`
- Email confirmation is **required** (`RequireConfirmedAccount = true`)
- Roles: `"User"` role used for authorization on BeerController

---

## Views

```
Views/
├── Home/         Index, Privacy
├── Beer/         Index (catalog with add-to-cart buttons)
├── ShoppingCart/ Index (cart with update/remove)
├── Session/      Index (write session demo)
├── Session2/     Index (read session demo)
└── Shared/       _Layout, _LoginPartial, Error
```

---

## Key Files

| File | Purpose |
|---|---|
| `Program.cs` | App configuration, DI, middleware |
| `appsettings.json` | Connection string, logging |
| `Data/ApplicationDbContext.cs` | Identity DbContext |
| `Beershop.Domain/Data/BeerDbContext.cs` | Beer domain DbContext |
| `Areas/Identity/Data/ApplicationUser.cs` | Custom Identity user |
| `AutoMapper/AutoMapperProfile.cs` | Beer → BeerVM mapping |
| `Extensions/SessionExtensions.cs` | JSON session helpers |
