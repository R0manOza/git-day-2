# Visual Studio + .NET — Super Friendly Guide (with HTML)

This file uses **HTML inside Markdown** so tables and “tip boxes” look clearer in viewers that support it (GitHub, many VS Code previews, etc.).

---

## Quick map: what is Visual Studio?

Visual Studio is the **heavy-duty workshop** for building .NET apps: editor, debugger, NuGet (libraries), and project files all in one place.

<details>
<summary><strong>Beginner analogy (click to expand)</strong></summary>

<p>Think of <strong>Visual Studio</strong> as a kitchen with recipes (projects), ingredients (NuGet packages), and a smoke alarm (the debugger) that tells you <em>exactly</em> where the cake burned.</p>
</details>

---

## Part A — HTML cheat boxes (how to read this doc)

<div style="border:1px solid #4CAF50; background:#e8f5e9; padding:12px; border-radius:8px; margin:12px 0;">
<strong>Green box</strong> = do this on almost every homework / midterm run.
</div>

<div style="border:1px solid #2196F3; background:#e3f2fd; padding:12px; border-radius:8px; margin:12px 0;">
<strong>Blue box</strong> = Visual Studio UI path (where to click).
</div>

<div style="border:1px solid #ff9800; background:#fff3e0; padding:12px; border-radius:8px; margin:12px 0;">
<strong>Orange box</strong> = super common “why won’t it run?” fix.
</div>

---

## Part B — Create a console project (step by step)

<div style="border:1px solid #2196F3; background:#e3f2fd; padding:12px; border-radius:8px;">
<ol>
<li>Open <strong>Visual Studio</strong>.</li>
<li><strong>File</strong> → <strong>New</strong> → <strong>Project…</strong></li>
<li>Search: <kbd>Console</kbd> → pick <strong>Console App</strong> (C#).</li>
<li>Name it something boring and clear, e.g. <code>MidtermPractice</code>.</li>
<li>Pick a folder you can find later (Desktop is OK for practice).</li>
<li>Framework: choose what your teacher showed (often <strong>.NET 6 / 8</strong>).</li>
<li>Click <strong>Create</strong>.</li>
</ol>
</div>

You should see **`Program.cs`** and a **green Play** button.

---

## Part C — The buttons you actually need

<table border="1" cellpadding="8" cellspacing="0" style="border-collapse:collapse; width:100%; max-width:720px;">
<thead style="background:#f5f5f5;">
<tr><th>What you want</th><th>What to do</th></tr>
</thead>
<tbody>
<tr><td>Run the program</td><td>Press <kbd>F5</kbd> (with debugger) or <kbd>Ctrl</kbd>+<kbd>F5</kbd> (run without debugger — console stays open at end)</td></tr>
<tr><td>Stop a runaway program</td><td>Press <kbd>Shift</kbd>+<kbd>F5</kbd> or click the red <strong>Stop</strong> square</td></tr>
<tr><td>Save everything</td><td><kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>S</kbd></td></tr>
<tr><td>Build (compile)</td><td><kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>B</kbd></td></tr>
<tr><td>Go to a line</td><td><kbd>Ctrl</kbd>+<kbd>G</kbd></td></tr>
<tr><td>Comment / uncomment</td><td><kbd>Ctrl</kbd>+<kbd>K</kbd> then <kbd>Ctrl</kbd>+<kbd>C</kbd> / <kbd>Ctrl</kbd>+<kbd>U</kbd></td></tr>
</tbody>
</table>

<div style="border:1px solid #4CAF50; background:#e8f5e9; padding:12px; border-radius:8px; margin:12px 0;">
<strong>Exam tip:</strong> If the console window flashes and closes, use <kbd>Ctrl</kbd>+<kbd>F5</kbd> or add <code>Console.ReadKey();</code> at the end of <code>Main</code> while testing.
</div>

---

## Part D — Solution Explorer (your file tree)

<div style="border:1px solid #2196F3; background:#e3f2fd; padding:12px; border-radius:8px;">
<strong>View</strong> → <strong>Solution Explorer</strong> (if you don’t see it).<br/>
Your code files live under the <strong>project</strong> node (the .csproj).
</div>

Typical starter layout:

<pre style="background:#263238; color:#eceff1; padding:12px; border-radius:8px; overflow:auto;">
MidtermPractice.sln
└── MidtermPractice/
    ├── Program.cs        ← often your Main entry
    └── MidtermPractice.csproj
</pre>

---

## Part E — Breakpoints (pause the universe)

1. Click in the **gray gutter** left of a line → a **red dot** appears.  
2. Press <kbd>F5</kbd>. Execution **pauses** on that line.  
3. Hover variables to see values.  
4. **Step over** line: <kbd>F10</kbd>. **Step into** a method: <kbd>F11</kbd>.

<div style="border:1px solid #ff9800; background:#fff3e0; padding:12px; border-radius:8px;">
If the red dot is <strong>hollow</strong>, the file might not be included in the project you’re running, or symbols are out of date — do a <strong>Rebuild</strong> (<strong>Build</strong> → <strong>Rebuild Solution</strong>).
</div>

---

## Part F — NuGet (adding “superpowers” like SQLite)

<div style="border:1px solid #2196F3; background:#e3f2fd; padding:12px; border-radius:8px;">
<strong>Solution Explorer</strong> → right-click <strong>Dependencies</strong> → <strong>Manage NuGet Packages…</strong><br/>
Search <code>Microsoft.Data.Sqlite</code> → <strong>Install</strong>.
</div>

After install, your code can say:

```csharp
using Microsoft.Data.Sqlite;
```

<div style="border:1px solid #ff9800; background:#fff3e0; padding:12px; border-radius:8px;">
<strong>Common mistake:</strong> Installing a package but forgetting <code>using ...</code> at the top → red squiggles everywhere.
</div>

---

## Part G — Error List vs Output window

<table border="1" cellpadding="8" cellspacing="0" style="border-collapse:collapse; width:100%; max-width:720px;">
<tr><th>Window</th><th>Use it for…</th></tr>
<tr><td><strong>Error List</strong></td><td>Fast list of errors/warnings with double-click to jump to code</td></tr>
<tr><td><strong>Output</strong> (Build)</td><td>Longer compiler story when something weird happens</td></tr>
</table>

Open them via **View** menu.

---

## Part H — Minimal “does it work?” console pattern

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("It runs.");
    }
}
```

---

## Part I — HTML you can reuse in your own notes

If you like colorful callouts, copy/paste blocks like this into your own `.md` files:

```html
<div style="border:1px solid #9c27b0; background:#f3e5f5; padding:10px; border-radius:8px;">
<strong>Purple reminder:</strong> Match your teacher’s .NET version and namespaces.
</div>
```

Keyboard keys in docs:

```html
Press <kbd>Ctrl</kbd> + <kbd>S</kbd> to save.
```

---

## Next file

For **inheritance, LINQ, delegates, SQL** in one mega reference, open **`dotnet-mother-of-all-cheat-sheet.md`**.
