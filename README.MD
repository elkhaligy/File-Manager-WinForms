# Dual-Pane File Manager for Windows

A Windows file manager with dual-pane interface, built with C# WinForms. Navigate directories, copy/move/delete files, and manage drives with ease.

![File Manager Demo](https://i.imgur.com/qGvCm3d.png) 

## 🚀 Features

- **Dual-pane interface**: Browse two directories simultaneously
- **Basic file operations**: 
  - Copy files/directories 
  - Move files (`>` and `<` buttons)
  - Delete files
- **Navigation**:
  - Double-click directory navigation
  - Back button functionality
  - Drive listing
- **Visual feedback**:
  - Current path display
  - Safe file operations with confirmation dialogs
- **Error handling** for common file system issues

## 📦 Installation

1. **Prerequisites**:
   - [.NET 6.0 SDK](https://dotnet.microsoft.com/download)
   - Visual Studio 2022+ (Recommended)

2. **Clone & Build**:
   ```bash
   git clone https://github.com/yourusername/file-manager.git
   cd file-manager/File_Managment
   dotnet build
   ```

3. **Run**:
   ```bash
   dotnet run --project File_Managment
   ```

## 🕹️ Usage

| Action                | Controls                               |
|-----------------------|----------------------------------------|
| **Navigate**          | Double-click directories               |
| **Copy**              | Select item → Click "Copy"             |
| **Move**              | Select item → Click > or < buttons |
| **Delete**            | Select item → Click "Delete"           |
| **Back**              | Click "Back" button                    |
| **Switch Panes**      | Click in either list pane              |

## 🧩 Code Structure

### Core Architecture

```plaintext
File_Managment/
├── Form1.cs            - Main UI and event handlers
├── Pane.cs             - Pane management (state+UI)
├── Utility/
    └── FileOperations - File copy/move/delete logic

```

### Key Components

1. **`Pane` Class** (Encapsulated UI State Management)
   ```csharp
   public class Pane {
       // UI Control references
       public ListBox ListBox { get; }
       public TextBox PathTextBox { get; }
       
       // Current state
       public string CurrentPath { get; private set; }
       public string SelectedItem { get; private set; }

       public void LoadDrives() { ... }
       public void LoadDirectory(string path) { ... }
       public void GoBack() { ... }
   }
   ```

2. **File Operations** (Safe Copy/Move)
   ```csharp
   public static class FileOperations {
       // Recursive directory copy
       public static void CopyDirectory(string source, string dest) {
           foreach (var dir in Directory.GetDirectories(source))
               CopyDirectory(dir, Path.Combine(dest, Path.GetFileName(dir)));
           
           foreach (var file in Directory.GetFiles(source))
               File.Copy(file, Path.Combine(dest, Path.GetFileName(file)), true);
       }
   }
   ```

## 🛠️ Best Practices Implemented

1. **Encapsulation**  
   - `Pane` class manages its own state/UI synchronization
   - Private field access with public methods for state changes

2. **Separation of Concerns**  
   - UI handling (Form1.cs)  
   - Business logic (Pane.cs)  
   - File operations (Utility/)  

3. **Error Handling**
   ```csharp
   try {
       directories = Directory.GetDirectories(path);
   } catch (UnauthorizedAccessException ex) {
       ErrorHandler.Show($"Access denied: {ex.Message}");
   }
   ```


---

Made with ❤️ by Shehab | [MIT License](LICENSE)

