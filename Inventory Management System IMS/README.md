<div align="center">

# 📦 Advanced Inventory Management System

### Desktop-Based Inventory & Sales Management Platform

[![Status](https://img.shields.io/badge/status-active-2f855a?style=for-the-badge)](#)
[![Architecture](https://img.shields.io/badge/architecture-3--tier-1a365d?style=for-the-badge)](#architecture)
[![Backend](https://img.shields.io/badge/backend-C%23_WinForms-2b6cb0?style=for-the-badge)](#technology-stack)
[![Database](https://img.shields.io/badge/database-MS_SQL_Server-cc2927?style=for-the-badge)](#database-design-highlights)
[![Cloud](https://img.shields.io/badge/hosting-GearHost_Cloud-0078d4?style=for-the-badge)](https://www.gearhost.com/)
[![Team](https://img.shields.io/badge/team-5_members-6b46c1?style=for-the-badge)](#team)

</div>

---

This project was developed for the **IT Database Implementation module**.  
It is a desktop-based inventory management system built with **C# WinForms** and **Microsoft SQL Server**,
designed around a clean 3-tier architecture and strong database engineering practices including
T-SQL stored procedures, triggers, views, and ACID-compliant transactions.  
The database is hosted on **[GearHost](https://www.gearhost.com/) Cloud Hosting** — no local SQL Server installation required for any team member.

---

## Table of Contents

1. [Project Vision](#project-vision)
2. [Core Capabilities](#core-capabilities)
3. [Technology Stack](#technology-stack)
4. [Architecture](#architecture)
5. [Database Design Highlights](#database-design-highlights)
6. [Repository Structure](#repository-structure)
7. [Cloud Database Setup — GearHost](#cloud-database-setup--gearhost)
8. [Setup Guide](#setup-guide)
9. [Git Workflow](#git-workflow)
10. [Release Process](#release-process)
11. [Commit Convention](#commit-convention)
12. [Development Rules](#development-rules)
13. [Team](#team)
14. [Maintenance Notes](#maintenance-notes)

---

## Project Vision

The Advanced Inventory Management System centralizes core business operations in a single desktop interface.  
The system currently manages:

- **Categories** — product grouping and catalog organization
- **Products** — inventory items with pricing and stock levels
- **Customers** — customer directory with contact information
- **Sales** — transaction recording with full invoice support
- **Sales Details** — line-item breakdown per transaction

It is built to demonstrate reliable CRUD flows, secure parameterized database access,
and advanced T-SQL features that support real-world data consistency and stock automation.  
The live database runs on a shared **MS SQL Server** instance hosted via **GearHost** cloud —
every team member connects to the same database over the internet with no local server setup.

---

## Core Capabilities

- Session-based login with lockout after failed attempts
- Product and category CRUD with low-stock alerting
- Customer directory with upsert stored procedure
- Sales transaction workflow with cart and invoice summary
- Server-side stock validation before every sale
- Parameterized queries via `System.Data.SqlClient` (no raw string SQL)
- Stored procedures for reusable T-SQL logic (`sp_ProcessSale`, `sp_UpsertCustomer`)
- Table-Valued Function for date-range revenue reporting (`fn_DailyRevenue`)
- Trigger for automated stock decrement on each sale (`trg_DecrementStock`)
- View for real-time low-stock reporting (`vw_LowStock`)
- ACID-compliant transaction handling with full `ROLLBACK` on failure
- `BEGIN TRY / BEGIN CATCH` error handling with `RAISERROR` propagation to C#
- Async UI — long-running queries never freeze the WinForms interface
- Cloud-hosted database on GearHost — all team members share one live MS SQL Server instance

---

## Technology Stack

| Layer | Technology |
|---|---|
| UI / Frontend | C# WinForms (.NET Framework 4.7.2+) |
| Business Logic | C# Classes (BLL) |
| Data Access | C# `DatabaseHelper.cs` + `System.Data.SqlClient` |
| Query Language | T-SQL (Transact-SQL) |
| Database Engine | Microsoft SQL Server |
| SQL Editor | SQL Server Management Studio (SSMS) |
| Cloud Hosting | [GearHost](https://www.gearhost.com/) — shared MS SQL Server in the cloud |
| IDE | Visual Studio 2022 |

---

## Architecture

The project follows a strict **3-tier model** to keep responsibilities clear and maintainable.

```
┌──────────────────────────────────────────────┐
│            Presentation Layer                │
│  WinForms (.cs) · DataGridViews              │
│  Buttons · Event Handlers ONLY               │
│  Zero SQL allowed here                       │
└───────────────────┬──────────────────────────┘
                    │
┌───────────────────▼──────────────────────────┐
│            Business Logic Layer              │
│  C# Classes · Validation · Calculations      │
│  ACID Rules · ProductBLL.cs · SaleBLL.cs     │
└───────────────────┬──────────────────────────┘
                    │
┌───────────────────▼──────────────────────────┐
│             Data Access Layer                │
│  DatabaseHelper.cs · SqlConnection           │
│  T-SQL Stored Procedures · Triggers · Views  │
│  ☁️  MS SQL Server on GearHost Cloud         │
└──────────────────────────────────────────────┘
```

> **Rule:** UI → BLL → DAL. Never skip a tier. Never write `SqlConnection` directly inside a Form.

---

## Database Design Highlights

The data layer includes key concepts from database engineering:

- **Normalization-oriented schema** — 5 tables with proper FK constraints enforced at the SQL Server level
- **Stored procedures** for structured T-SQL operations (`sp_ProcessSale`, `sp_UpsertCustomer`)
- **Table-Valued Function** for date-range revenue reporting (`fn_DailyRevenue`)
- **Trigger** for automated business rules (`trg_DecrementStock` on `SalesDetails` AFTER INSERT)
- **View** for read-focused low-stock reporting (`vw_LowStock`)
- **Transaction handling** — `BEGIN TRANSACTION / COMMIT / ROLLBACK` with `BEGIN TRY / BEGIN CATCH` for full atomicity
- **`SCOPE_IDENTITY()`** used to capture new IDs after inserts
- **`RAISERROR`** for propagating T-SQL errors back to the C# `SqlException` catch block

### Schema Overview

```
Categories ──< Products ──< SalesDetails >── Sales >── Customers
```

| Table | Owner | Key T-SQL Object |
|---|---|---|
| Categories | Member 01 | — |
| Products | Member 01 | `vw_LowStock` (View) |
| Customers | Member 02 | `sp_UpsertCustomer` (Stored Procedure) |
| Sales | Member 03 | `sp_ProcessSale` (Stored Procedure) |
| SalesDetails | Member 04 | `trg_DecrementStock` (Trigger) |
| — | Member 05 | `fn_DailyRevenue` (Table-Valued Function) |

### T-SQL Object Naming Convention

| Type | Prefix | Example |
|---|---|---|
| Stored Procedure | `sp_` | `sp_ProcessSale` |
| Trigger | `trg_` | `trg_DecrementStock` |
| View | `vw_` | `vw_LowStock` |
| Function | `fn_` | `fn_DailyRevenue` |

---

## Repository Structure

```text
inventory_management_system/
├── Application/
│   ├── BLL/
│   │   ├── ProductBLL.cs
│   │   ├── CustomerBLL.cs
│   │   └── SaleBLL.cs
│   └── DAL/
│       └── DatabaseHelper.cs
├── Presentation/
│   ├── frmLogin.cs
│   ├── frmMainMenu.cs
│   ├── frmProductInventory.cs
│   ├── frmCustomerDirectory.cs
│   ├── frmSalesTransaction.cs
│   ├── frmStockAdjustment.cs
│   └── frmDashboard.cs
├── SQL_Scripts/
│   ├── 01_Categories.sql
│   ├── 01_Products.sql
│   ├── 01_vw_LowStock.sql
│   ├── 02_Customers.sql
│   ├── 02_sp_UpsertCustomer.sql
│   ├── 03_Sales.sql
│   ├── 03_sp_ProcessSale.sql
│   ├── 04_SalesDetails.sql
│   ├── 04_trg_DecrementStock.sql
│   ├── 05_Indexes.sql
│   └── 05_fn_DailyRevenue.sql
├── App.config
└── README.md
```

---

## Cloud Database Setup — GearHost

The database is hosted on **[GearHost](https://www.gearhost.com/)** — a cloud hosting platform
providing a shared MS SQL Server instance accessible over the internet.  
**No local SQL Server installation is needed by any team member.**

---

### Step 1 — Create a GearHost account

1. Go to [https://www.gearhost.com/](https://www.gearhost.com/) and sign up for a free account
2. Verify your email and log in to the **GearHost Control Panel**

---

### Step 2 — Create a new MS SQL Server database

1. In the Control Panel, go to **Databases → MS SQL**
2. Click **Create Database**
3. Set the database name: `ims_db`
4. Note the following — you will need these for the connection string:
   - **Server hostname** (e.g. `den1.mssql7.gear.host`)
   - **Database name** (`ims_db`)
   - **Username**
   - **Password**

> The exact hostname is shown in the GearHost Control Panel under your database details.

---

### Step 3 — Connect to the cloud DB via SSMS

Download and install **SQL Server Management Studio (SSMS)** (free):  
👉 [https://aka.ms/ssmsfullsetup](https://aka.ms/ssmsfullsetup)

Open SSMS and connect with these settings:

| SSMS Field | Value |
|---|---|
| Server type | Database Engine |
| Server name | `your-hostname.gear.host` *(from GearHost panel)* |
| Authentication | SQL Server Authentication |
| Login | Your GearHost DB username |
| Password | Your GearHost DB password |

Click **Connect**. You should see `ims_db` in the Object Explorer on the left.

> 💡 If you get an SSL certificate error, tick **Trust server certificate** in the connection options.

---

### Step 4 — Run SQL scripts on the cloud database

In SSMS, select `ims_db` from the database dropdown, open a **New Query** window, and run the scripts in this **exact order**:

```text
1.  SQL_Scripts/01_Categories.sql
2.  SQL_Scripts/01_Products.sql
3.  SQL_Scripts/01_vw_LowStock.sql
4.  SQL_Scripts/02_Customers.sql
5.  SQL_Scripts/02_sp_UpsertCustomer.sql
6.  SQL_Scripts/03_Sales.sql
7.  SQL_Scripts/03_sp_ProcessSale.sql
8.  SQL_Scripts/04_SalesDetails.sql
9.  SQL_Scripts/04_trg_DecrementStock.sql
10. SQL_Scripts/05_Indexes.sql
11. SQL_Scripts/05_fn_DailyRevenue.sql
```

> ⚠️ **Order matters.** Tables with FK dependencies must exist before their dependants.  
> Required order: Categories → Products → Customers → Sales → SalesDetails

---

### Step 5 — Configure App.config with GearHost credentials

Open `App.config` in Visual Studio and set your GearHost connection string:

```xml
<connectionStrings>
  <add name="IMSDatabase"
       connectionString="Server=your-hostname.gear.host;
                         Database=ims_db;
                         User Id=your_db_username;
                         Password=your_db_password;
                         TrustServerCertificate=True;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

> ⚠️ **Never hardcode credentials in `.cs` files.** Always read from `App.config`.  
> ⚠️ **Never commit real passwords to Git.** Add `App.config` to `.gitignore`, or  
> store sensitive values in a separate `secrets.config` that is gitignored.

---

### Step 6 — Share credentials securely with the team

Since all 5 members connect to the **same live GearHost database**, share connection details via  
a **private group message** — never in a public commit, pull request comment, or this README.

```
Host     : your-hostname.gear.host
Database : ims_db
Username : [share privately]
Password : [share privately — do NOT commit to Git]
Port     : 1433  (MS SQL Server default)
```

---

## Setup Guide

### 1. Prerequisites

Install the following before cloning:

- [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup) — free, for running T-SQL scripts against GearHost
- [Visual Studio 2022](https://visualstudio.microsoft.com/) — Community edition is free
- `.NET Framework 4.7.2` or higher
- Access to the team's GearHost `ims_db` credentials *(request from Member 05)*

> No local SQL Server installation needed — GearHost is the shared cloud database.

---

### 2. Clone the repository

```bash
git clone https://github.com/<your-org>/inventory_management_system.git
cd inventory_management_system
```

---

### 3. Switch to development branch

```bash
git checkout dev
git pull origin dev
```

---

### 4. Configure App.config

Get the GearHost credentials from **Member 05** (Integration Lead) and update `App.config`  
as shown in [Step 5 of Cloud Database Setup](#step-5--configure-appconfig-with-gearhost-credentials).

---

### 5. Verify System.Data.SqlClient

`System.Data.SqlClient` is built into .NET Framework — **no NuGet install required**.  

If targeting **.NET 5 / .NET 6+** instead, install the package in Visual Studio:

```
Tools → NuGet Package Manager → Manage NuGet Packages
Search: Microsoft.Data.SqlClient → Install
```

---

### 6. Build and run

Open the `.sln` file in Visual Studio → Press **F5** or click **Start**.  
The application launches with `frmLogin.cs` as the entry point.

Default login credentials (seeded in `data.sql`):

```
Username : admin
Password : admin123
```

---

## Git Workflow

This repository follows a team-based branching strategy.

### Branch roles

| Branch | Purpose |
|---|---|
| `main` | Production-ready, stable code only |
| `dev` | Integration branch — all features merge here first |
| `feature/*` | Individual member feature branches |

---

### Create a feature branch

```bash
git checkout dev
git pull origin dev
git checkout -b feature/<your-name>-<feature>
```

**Naming examples:**

- `feature/member01-product-inventory`
- `feature/member02-customer-login`
- `feature/member03-sales-transaction`
- `feature/member04-stock-trigger`
- `feature/member05-dashboard`

---

### Commit and push

```bash
git add .
git commit -m "feat: add product search filter"
git push origin feature/<your-branch>
```

---

### Open Pull Request

- **Base branch:** `dev`
- **Compare branch:** your feature branch
- At least **one other team member** must review and approve before merging

---

### Sync feature branch with latest dev

```bash
git checkout dev
git pull origin dev
git checkout feature/<your-branch>
git merge dev
```

---

### Delete feature branch after merge

```bash
git branch -d feature/<your-branch>
git push origin --delete feature/<your-branch>
```

---

## Release Process

When the `dev` branch is stable and all features pass integration testing, promote to `main`.

**Option 1 — Pull Request (recommended):**

Open a Pull Request from `dev` → `main`. Requires team review.

**Option 2 — Manual merge:**

```bash
git checkout main
git pull origin main
git merge dev
git push origin main
```

> ⚠️ Never push directly to `main`. Every change must pass through `dev` first.

---

## Commit Convention

| Prefix | Use for |
|---|---|
| `feat:` | New feature or WinForms screen |
| `fix:` | Bug fix |
| `refactor:` | Internal code improvement with no behavior change |
| `docs:` | Documentation updates |
| `sql:` | New or modified T-SQL scripts (tables, procedures, triggers, views, functions) |
| `style:` | UI layout or formatting changes only |

**Examples:**

```bash
git commit -m "feat: add low stock alert tab to product form"
git commit -m "sql: create trg_DecrementStock trigger on SalesDetails"
git commit -m "sql: create fn_DailyRevenue table-valued function"
git commit -m "fix: catch SqlException 547 on product delete (FK violation)"
git commit -m "docs: update GearHost connection string setup instructions"
```

---

## Development Rules

- ❌ Do not push directly to `main`
- ❌ Never hardcode the GearHost connection string in `.cs` files
- ❌ Never commit passwords or credentials to Git
- ✅ Always branch from `dev`
- ✅ Keep features focused — one feature per branch
- ✅ Use `DatabaseHelper.cs` for **all** DB access — never write `SqlConnection` directly inside a Form
- ✅ Use parameterized queries — never concatenate user input into SQL strings
- ✅ Wrap all T-SQL stored procedures in `BEGIN TRY / BEGIN CATCH` blocks
- ✅ Use `SCOPE_IDENTITY()` to capture new IDs after any `INSERT`
- ✅ Use `RAISERROR` to propagate T-SQL errors back to the C# `SqlException` catch block
- ✅ Catch FK violation errors in C# — SQL Server error number **547** for FK violations
- ✅ Keep SQL scripts in `/SQL_Scripts/` synchronized after every database change
- ✅ After running a new script on GearHost, commit the `.sql` file and notify the team
- ✅ Maintain strict 3-tier separation — no SQL in the Presentation layer, no UI logic in the DAL

---

## Team

| Member | Role | Student ID | Key Deliverables |
|---|---|---|---|
| Member 01 | Product & Catalog Lead | — | `Categories`, `Products` tables · `vw_LowStock` · `frmProductInventory` |
| Member 02 | Customer & Security Lead | — | `Customers` table · `sp_UpsertCustomer` · `frmLogin` · `frmCustomerDirectory` |
| Member 03 | Sales & Transaction Lead | — | `Sales` table · `sp_ProcessSale` (ACID) · `frmSalesTransaction` |
| Member 04 | Stock Logic & Automation Lead | — | `SalesDetails` table · `trg_DecrementStock` · `frmStockAdjustment` |
| Member 05 | Reports & Integration Lead | — | `DatabaseHelper.cs` · `fn_DailyRevenue` · Indexes · `frmDashboard` · `frmMainMenu` · GearHost DB admin |

---

## Maintenance Notes

- Test all affected flows after any T-SQL schema change on the GearHost database
- After running a new `.sql` script against GearHost, commit the file to `/SQL_Scripts/` and notify the team via group chat
- If GearHost connection fails, verify the server hostname in the GearHost Control Panel — check that the database is still active under your plan
- Add `TrustServerCertificate=True` to the connection string if SSMS or the app reports an SSL/TLS certificate error on GearHost
- Never share GearHost credentials in Git commits, pull request descriptions, or public comments
- If the GearHost database password is compromised, change it in the Control Panel immediately and redistribute the new `App.config` to all members privately
- Run a full integration test (Login → all 5 forms → Dashboard → Logout) before every Friday merge to `dev`
- If `UnitsInStock` goes negative in testing, verify `trg_DecrementStock` exists on GearHost by running in SSMS:
  ```sql
  SELECT name, is_disabled FROM sys.triggers WHERE name = 'trg_DecrementStock';
  ```
- If a stored procedure or function is missing on GearHost, re-run the matching `.sql` file from `/SQL_Scripts/` in SSMS connected to the cloud database

---

<div align="center">

**Advanced Inventory Management System**  
C# WinForms · MS SQL Server · T-SQL · [GearHost Cloud](https://www.gearhost.com/) · System.Data.SqlClient · 3-Tier Architecture

</div>
