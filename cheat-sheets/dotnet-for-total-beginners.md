# .NET for Total Beginners (No Judgment Zone)

You open a `.cs` file. You see words. This sheet tells you **what job each part does** in plain English.

---

## 1. The two “brains” of a tiny program

| Thing | Plain English |
|--------|----------------|
| `class Program` | “Here is the program’s name tag.” |
| `static void Main(string[] args)` | “When you run the app, **start here**.” |

Everything important usually begins inside `Main`.

---

## 2. Printing to the screen

```csharp
Console.WriteLine("Hello");
Console.WriteLine(x);   // prints the value of x
```

- **`WriteLine`** = print and go to the next line.  
- **`Write`** = print and stay on the same line.

---

## 3. Variables (boxes with labels)

```csharp
int n = 5;
double z = 3.14;
string name = "Alex";
bool ok = true;
```

- **`int`** = whole number.  
- **`double`** = decimal number.  
- **`string`** = text in quotes.  
- **`bool`** = true or false only.

---

## 4. `if` / `else` (choose a path)

```csharp
if (age >= 18)
{
    Console.WriteLine("Adult");
}
else
{
    Console.WriteLine("Not adult");
}
```

**Rule:** The condition inside `if (...)` must be **true or false**.

---

## 5. Loops (do something many times)

**`for`** — you know how many times (or use a counter):

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}
```

**`while`** — repeat while something is true:

```csharp
int i = 0;
while (i < 5)
{
    Console.WriteLine(i);
    i++;
}
```

---

## 6. A class = blueprint for an object

```csharp
class Dog
{
    public string Name;   // every Dog has a Name

    public void Bark()
    {
        Console.WriteLine(Name + " says woof");
    }
}
```

**Using it:**

```csharp
Dog d = new Dog();
d.Name = "Rex";
d.Bark();
```

- **`new Dog()`** = “build one real Dog from the blueprint.”

---

## 7. Constructor = “setup when the object is born”

```csharp
class Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}
```

```csharp
Point p = new Point(3, 4);
```

---

## 8. Properties (fancy getters/setters)

Instead of everyone poking a raw field, you use **properties**:

```csharp
class Circle
{
    private double r;

    public double Radius
    {
        get { return r; }
        set { r = value; }   // "value" is whatever they assigned
    }
}
```

- **`get`** = read.  
- **`set`** = write.  
- Read-only property = only `get`, no `set`.

---

## 9. One-line memory hooks

| You see | Think |
|---------|--------|
| `public` | “Other code can see this.” |
| `private` | “Only inside this class.” |
| `static` | “Belongs to the type, not one instance.” |
| `void` | “This method returns nothing.” |
| `return` | “Send this value back and stop.” |

---

## 10. When the compiler screams

1. Read the **first** error first (later errors are often fake dominoes).  
2. Check: missing `;`? Missing `}`? Wrong capital letter (`Console` not `console`)?  
3. Save the file. Build again.

---

## Where to go next

- **Bigger picture + midterm topics:** `dotnet-mother-of-all-cheat-sheet.md`  
- **Visual Studio clicks and keys:** `dotnet-visual-studio-and-html-super-guide.md`

You’ve got this.
