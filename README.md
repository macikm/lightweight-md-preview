# Lightweight Markdown Preview pro Windows a Outlook

Jednoduchý, bleskurychlý a nezávislý prohlížeč (Preview Handler) pro soubory `.md` v Průzkumníkovi Windows a v Microsoft Outlooku.

Cílem tohoto projektu je vyřešit otravný problém s mizejícími náhledy. Zatímco velké nástroje (jako PowerToys) často selhávají kvůli zamrzajícímu `WebView2` nebo agresivním bezpečnostním pravidlům Outlooku, tento plugin vykresluje HTML čistě, nativně a zcela bez závislosti na zabudovaných prohlížečích (Edge/IE).

## Proč použít právě tento plugin?
* **Nepotřebuje WebView2:** Žádné černé obrazovky nebo nekonečné načítání.
* **Funguje v Outlooku:** Bezpečnostní sandbox Outlooku (COM Surrogate) jej neblokuje.
* **Malá velikost:** Žádné zbytečné gigabajty dat na pozadí.
* **Přehledný design:** Čisté CSS formátování, zvýraznění bloků kódu a tabulek.

## Jak nainstalovat (Pro běžné uživatele)
1. Přejděte do sekce [Releases](../../releases) a stáhněte si nejnovější `.zip` soubor.
2. Soubor rozbalte do složky, kterou už nebudete přesouvat (např. `C:\Nastroje\MarkdownPreview\`).
3. Klikněte pravým tlačítkem na soubor `_Instalovat.bat` a zvolte **Spustit jako správce**.
4. Restartujte Outlook (nebo okna Průzkumníka). Náhledy jsou aktivní!

*(Pro odinstalaci stačí spustit `_Odinstalovat.bat` a následně složku smazat).*

## Pro vývojáře
Projekt je napsaný v C# (.NET 4.8) s využitím knihoven `SharpShell`, `Markdig` a `HtmlRenderer.WinForms`.

**Kompilace:**
```bash
dotnet build -c Release
