# Lightweight Markdown Preview for Windows & Outlook

A simple, lightning-fast, and standalone Preview Handler for `.md` (Markdown) files in Windows File Explorer and Microsoft Outlook.

This project was born out of frustration with broken file previews. While heavy tools (like Microsoft PowerToys) often fail to display Markdown previews in Outlook due to crashing `WebView2` dependencies or aggressive COM Surrogate sandboxing, this plugin uses native, independent rendering. 

## Why use this plugin?
* **No WebView2 Required:** Completely bypasses modern Edge/IE rendering engines, eliminating "black screens" and infinite loading issues.
* **Works natively in Outlook:** Successfully avoids Microsoft Outlook's strict COM Surrogate security blocks.
* **Extremely Lightweight:** No bloated background processes or gigabytes of cache.
* **Clean Design:** Simple CSS formatting, properly highlighted code blocks, and structured tables out of the box.

## How to Install (For regular users)
1. Go to the [Releases](../../releases) tab and download the latest `.zip` file.
2. Extract the `.zip` file into a permanent folder on your drive (e.g., `C:\Tools\MarkdownPreview\`).
3. Right-click the `install.bat` file and select **Run as administrator**.
4. Restart Microsoft Outlook (or close and reopen File Explorer windows). Your `.md` files will now have fully rendered previews!

*(To uninstall, simply run `uninstall.bat` as administrator and delete the folder).*

## For Developers
This project is written in C# (.NET Framework 4.8) and leverages `SharpShell`, `Markdig`, and `HtmlRenderer.WinForms`.

**How to build from source:**
```bash
# Clone the repository
git clone [https://github.com/YourUsername/lightweight-md-preview.git](https://github.com/YourUsername/lightweight-md-preview.git)
cd lightweight-md-preview

# Build using .NET CLI
dotnet build -c Release
```
*(Note: To test your local build, you may need to kill the prevhost.exe process if the .dll is locked by Windows: taskkill /f /im prevhost.exe)*
