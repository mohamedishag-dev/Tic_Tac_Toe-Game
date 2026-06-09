# Tic-Tac-Toe Game (Windows Forms / C#) 🎮

A classic, interactive **Tic-Tac-Toe** desktop application built using **C#** and **Windows Forms**. The project showcases structural OOP design patterns, custom GDI+ graphics rendering, and deterministic win/draw state machines.

---

## ✨ Features

* **Dynamic GDI+ Grid Rendering:** The game board lines are custom-drawn programmatically with customized pens and rounded line caps using the `Paint` event handler.
* **Turn-Based State Machine:** Implements strict turn management using strongly-typed enums (`enPlayer`) to transition seamlessly between Player 1 (X) and Player 2 (O).
* **Deterministic Win/Draw Evaluator:** Scans all 8 win vectors (3 rows, 3 columns, and 2 diagonals) in real-time, instantly highlighting winning cells in `GreenYellow`.
* **State Reset Architecture:** A single-click restart mechanism that systematically flushes component resource images, resets string tags, and wipes execution memory state.
* **Input Validation & Exception Prevention:** Integrated defensive check blocks that intercept illegal moves on already-occupied cells, pushing visual warning dialogues to the user.

---

## 🛠️ Tech Stack & Architecture

* **Language:** C#
* **Framework:** .NET / Windows Forms (WinForms)
* **Graphics API:** GDI+ (`System.Drawing.Graphics`)
* **Resource Management:** Native `Properties.Resources` mapping for dynamic asset extraction (`X`, `O`).

---

## 📂 Core Logic Breakdown

The architectural backbone of `Form1.cs` consists of the following key computational procedures:
* `Form1_Paint`: Leverages `Graphics.DrawLine` to map the game grid coordinates dynamically layout-side.
* `CheckImage`: Acts as the primary input event controller. It validates moves, increments `PlayCount`, binds state tags, and chains to evaluators.
* `CheckWinner` & `CheckValue`: Formulates a recursive-like logical checking structure that verifies structural array matching without out-of-bounds risks.
* `EndGame`: Halts input event chains, forces label state updates, and triggers modal UI windows showing match outcome.
* `btnRestart_Click`: Iterates and safely rolls back the application memory frame to its original state.

---

## 🚀 How to Run & Build

1. **Clone the Repository:**
   ```bash
   git clone https://github.com
   ```
2. **Open the Project:** Launch the `.sln` or `.csproj` file using **Visual Studio 2022** (or higher).
3. **Embed Local Dependencies:** Ensure that your asset files (`X`, `O`, and `question_mark_96`) are properly mapped inside your project's local `Properties.Resources` designer.
4. **Compile and Execute:** Press `F5` or click **Start** inside Visual Studio to build the runtime binary executable.

