# The Mother of All .NET / C# Cheat Sheets (Midterm Survival)

One doc. Many topics. Written to match the **kind of exercises** in typical intro .NET courses (and patterns like your practice files: shapes, properties, `virtual`/`override`, delegates, SQLite, LINQ/EF).

**How to use this:** skim the **big headings** before the exam; drill the **gray “exam traps”** boxes the night before.

---

## Table of contents

1. [Project anatomy](#1-project-anatomy)  
2. [Types, operators, strings](#2-types-operators-strings)  
3. [Methods and parameters](#3-methods-and-parameters)  
4. [Classes, fields, constructors](#4-classes-fields-constructors)  
5. [Properties (get / set)](#5-properties-get--set)  
6. [Inheritance, `virtual`, `override`, `base`](#6-inheritance-virtual-override-base)  
7. [Polymorphism (the `Rectangle r = new Cuboid(...)` trick)](#7-polymorphism-the-rectangle-r--new-cuboid-trick)  
8. [Delegates and lambdas](#8-delegates-and-lambdas)  
9. [Exceptions (`try` / `catch`)](#9-exceptions-try--catch)  
10. [Collections + `foreach`](#10-collections--foreach)  
11. [LINQ cheat codes](#11-linq-cheat-codes)  
12. [Entity Framework Core patterns](#12-entity-framework-core-patterns)  
13. [ADO.NET + SQLite (raw SQL)](#13-adonet--sqlite-raw-sql)  
14. [Namespaces, `using`, top-level statements](#14-namespaces-using-top-level-statements)  
15. [Compiler errors decoded](#15-compiler-errors-decoded)

---

## 1. Project anatomy

| File / thing | What it is |
|--------------|------------|
| `.sln` | **Solution** — container for one or more projects |
| `.csproj` | **Project** — your C# project settings + references |
| `Program.cs` | Common entry file; contains `Main` (unless top-level statements) |
| NuGet package | Library you install (e.g. SQLite, EF Core tools) |

---

## 2. Types, operators, strings

```csharp
int a = 10;
double x = 9.8;
decimal money = 19.99m;     // money-ish math (less float weirdness)
bool ok = true;
char c = 'A';
string s = "hello";

int sum = a + 5;
double area = Math.PI * x * x;

string msg = $"radius={x:F2}";   // string interpolation
```

**Useful `Math`:** `Math.PI`, `Math.Sqrt`, `Math.Pow`, `Math.Round`, `Math.Abs`.

> **Exam trap:** `2 * Math.PI * r` for perimeter/circumference — don’t square `PI` by accident for perimeter.

---

## 3. Methods and parameters

```csharp
static int Add(int a, int b)
{
    return a + b;
}

void Print(string text)   // returns nothing
{
    Console.WriteLine(text);
}
```

- **`static`** on a method: call as `ClassName.Method()` without making an object.  
- **`void`**: no `return` value.

**Pass by reference (less common in intro, but shows up):**

```csharp
void Bump(ref int x) { x++; }
void Set(out int x) { x = 42; }
```

---

## 4. Classes, fields, constructors

```csharp
class BankAccount
{
    private decimal balance;   // field: internal storage

    public BankAccount(decimal opening)
    {
        balance = opening;   // constructor runs on `new`
    }

    public decimal GetBalance()
    {
        return balance;
    }
}
```

- **`private`**: only methods inside this class touch it (good default for fields).  
- **`public`**: the outside world can see it.

---

## 5. Properties (get / set)

**Auto-property (shortest):**

```csharp
public string Name { get; set; }
```

**Full property (backing field):**

```csharp
private double r;

public double Radius
{
    get { return r; }
    set { r = value; }     // `value` is the incoming assignment
}
```

**Read-only computed property (only `get`):**

```csharp
public double Perimeter => 2 * Math.PI * r;
```

Or classic:

```csharp
public double Perimeter
{
    get { return 2 * Math.PI * r; }
}
```

**If you need a setter that “reverse engineers” the radius from perimeter** (like some circle exercises):

```csharp
public double Perimeter
{
    get => 2 * Math.PI * r;
    set => r = value / (2 * Math.PI);
}
```

> **Exam trap:** every `{` needs a matching `}`. A stray `{` after a property is a classic syntax killer.

---

## 6. Inheritance, `virtual`, `override`, `base`

```csharp
class Rectangle
{
    protected double length;   // `protected`: subclasses can see it
    protected double width;

    public Rectangle(double l, double w)
    {
        length = l;
        width = w;
    }

    public virtual double Size()   // child classes MAY replace this
    {
        return length * width;
    }
}

class Cuboid : Rectangle
{
    private double height;

    public Cuboid(double l, double w, double h) : base(l, w)  // call parent ctor
    {
        height = h;
    }

    public override double Size()   // MUST match parent signature
    {
        return base.Size() * height;   // base.Size() = rectangle area
    }
}
```

| Keyword | Meaning |
|---------|---------|
| `:` | “inherits from” (`Cuboid : Rectangle`) |
| `base(...)` | call parent **constructor** |
| `base.Method()` | call parent **version** of a method |
| `virtual` | “this method can be replaced” |
| `override` | “I am replacing a virtual method” |

> **Exam trap:** `override` without `virtual` in the parent = compile error. Wrong method signature = not a real override.

---

## 7. Polymorphism (the `Rectangle r = new Cuboid(...)` trick)

```csharp
Rectangle r = new Cuboid(2, 3, 4);
double z = r.Size();   // calls Cuboid.Size if override is correct
```

**Plain English:** the **variable type** is `Rectangle`, but the **actual object** in memory is a `Cuboid`. C# calls the **most specific** `override` of `Size`.

---

## 8. Delegates and lambdas

**Delegate = “type-safe function pointer”** (a variable that holds a method).

```csharp
delegate int IntTransformer(int x);

class Demo
{
    IntTransformer f;

    int DoubleIt(int x) => x * 2;

    public Demo()
    {
        f = DoubleIt;              // method group
        // or: f = x => x * 2;     // lambda
    }

    void Echo(int x)
    {
        int r = f(x);
        Console.WriteLine(r);
    }
}
```

**Built-in generic delegates (very common):**

```csharp
Func<int, int> f = x => x * 2;          // takes int, returns int
Action<string> log = s => Console.WriteLine(s);  // returns void
```

> **Exam trap:** declaring `MyType f;` but never assigning `f` before calling it → **runtime** `NullReferenceException`.

**Safe pattern:**

```csharp
f = x => x;   // identity default, or assign in constructor
```

---

## 9. Exceptions (`try` / `catch`)

```csharp
try
{
    int n = int.Parse(Console.ReadLine());
}
catch (FormatException)
{
    Console.WriteLine("That was not an integer.");
}
finally
{
    // always runs (cleanup)
}
```

---

## 10. Collections + `foreach`

```csharp
var list = new List<int> { 1, 2, 3 };
list.Add(4);

foreach (var n in list)
    Console.WriteLine(n);

int[] arr = new int[] { 10, 20, 30 };
```

---

## 11. LINQ cheat codes

`using System.Linq;` is required for LINQ extension methods.

```csharp
var nums = new[] { 3, 1, 4, 1, 5 };

bool anyBig = nums.Any(n => n > 4);
bool allPos = nums.All(n => n > 0);
int count = nums.Count(n => n == 1);
var evens = nums.Where(n => n % 2 == 0).ToList();
var sorted = nums.OrderBy(n => n).ToList();
var first = nums.FirstOrDefault(n => n > 10);   // 0 if none (for int)

var names = new[] { "Amy", "Bob" };
var upper = names.Select(s => s.ToUpper()).ToArray();
```

**Anti-join pattern** (vendors with **no** products) — same idea as `Where ... !Contains`:

```csharp
// Pseudo-shape from LINQ exercises:
// var q = db.Vendors.Where(v => !db.Products.Select(p => p.VendorId).Contains(v.Id));
```

**SQL intuition:** “Give me rows from A where A’s id is **not** in the set of ids from B.”

---

## 12. Entity Framework Core patterns

**Typical exam pieces:**

- `DbContext` subclass with `DbSet<T>` properties  
- `Add`, `Remove`, `SaveChanges`  
- LINQ translated to SQL

```csharp
// conceptual — names depend on YOUR generated context
// using var db = new SchoolContext();
// var students = db.Students.Where(s => s.Gpa >= 3.5).ToList();
```

> **Exam trap:** typo in context class name (`MidetermExamContext` vs `MidtermExamContext`) = nothing compiles until fixed.

**Include related data (when navigation properties exist):**

```csharp
// using Microsoft.EntityFrameworkCore;
// var orders = db.Orders.Include(o => o.LineItems).ToList();
```

---

## 13. ADO.NET + SQLite (raw SQL)

**Correct “shape”** (method names are **PascalCase** in .NET):

```csharp
using Microsoft.Data.Sqlite;

using var connection = new SqliteConnection(@"Data Source=chinook.db");
connection.Open();

using var command = connection.CreateCommand();
command.CommandText = "SELECT ArtistId, Name FROM artists;";

using var reader = command.ExecuteReader();
while (reader.Read())
{
    var id = reader.GetInt32(0);
    var name = reader.GetString(1);

    // or by column name (if it exists on the result set):
    // var name2 = reader["Name"];
}
```

| Wrong | Right |
|-------|--------|
| `con.open()` | `connection.Open()` |
| `ExecuteReader` (missing call) | `ExecuteReader()` |
| Reading `ProductName` from `artists` | Column must exist on **that** query |

**Parameterized query (safer, exam-friendly):**

```csharp
command.CommandText = "SELECT * FROM artists WHERE ArtistId = $id;";
command.Parameters.AddWithValue("$id", 5);
```

---

## 14. Namespaces, `using`, top-level statements

**Classic:**

```csharp
using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args) { }
    }
}
```

**Modern “top-level”** (no `Main` block — whole file is the program):

```csharp
using System;
Console.WriteLine("Top-level program");
```

> **Exam trap:** mixing random top-level SQL + `using` statements only works in a **true** top-level program file; in a traditional `Main` project, put SQL code **inside** `Main` or a method.

---

## 15. Compiler errors decoded

| Message vibe | Often means |
|----------------|------------|
| `; expected` | Missing semicolon or broken line split mid-token (`new Ci` + `rcle()`) |
| `Type or namespace could not be found` | Missing `using`, wrong spelling, or missing NuGet reference |
| `Cannot convert from X to Y` | wrong types in assignment or return |
| `does not contain a definition for ...` | typo, wrong object type, or missing `()` on method |
| `'X' is a variable but is used like a type` | confused variable/class names |

---

## One-page “day of exam” checklist

1. **`Main` entry** exists (or exactly one top-level program).  
2. **Matching braces** and **semicolons**.  
3. **`()`** on method calls: `Read()`, `ExecuteReader()`, `ToList()`.  
4. **SQLite:** `Open()`, correct column names, `using` for dispose.  
5. **LINQ:** `using System.Linq;`, `ToList()` when you need a concrete list.  
6. **Inheritance:** `virtual`/`override` paired, `base(...)` in child ctor.  
7. **Delegates:** assign before invoke.

---

## Your other sheets

- **Slowest, kindest intro:** `dotnet-for-total-beginners.md`  
- **Visual Studio UI + HTML boxes:** `dotnet-visual-studio-and-html-super-guide.md`

Good luck on the midterm.
