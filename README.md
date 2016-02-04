# Lexware-Datenbank-Zugriff

[![Build status](https://build.fubar-dev.de/app/rest/builds/buildType:%28id:Lexware_ReleaseBuild%29/statusIcon)](https://build.fubar-dev.com/project.html?projectId=Lexware)

Die Mappings sind unvollständig und enthalten nur die Daten, die
von den bisherigen Projekten benötigt wurden.

Die Besonderheit dieser Klassen ist, dass man vollen Zugriff (auch schreibend)
auf die Lexware-Datenbanken erhält und auch - im Gegensatz zu der bekannten
ODBC-Lösung - Lexware nicht geöffnet sein muss!

# Lizenz

Die Bibliothek unterliegt der [MIT-Lizenz](http://opensource.org/licenses/MIT).

# NuGet-Pakete

| Description				| Badge |
|---------------------------|-------|
| Basis-Bibliothek			| [![FubarDev.Lexware.Database](https://img.shields.io/nuget/v/FubarDev.Lexware.Database.svg)](https://www.nuget.org/packages/FubarDev.Lexware.Database) |
| Basis-Lexware-Komponenten	| [![FubarDev.Lexware.Database.Shared](https://img.shields.io/nuget/v/FubarDev.Lexware.Database.Shared.svg)](https://www.nuget.org/packages/FubarDev.Lexware.Database.Shared) |
| NHibernate-Komponenten	| [![FubarDev.Lexware.Database.NhSupport](https://img.shields.io/nuget/v/FubarDev.Lexware.Database.NhSupport.svg)](https://www.nuget.org/packages/FubarDev.Lexware.Database.NhSupport) |
| Globale Strukturen    	| [![FubarDev.Lexware.Database.Global](https://img.shields.io/nuget/v/FubarDev.Lexware.Database.Global.svg)](https://www.nuget.org/packages/FubarDev.Lexware.Database.Global) |
| Globale Mappings      	| [![FubarDev.Lexware.Database.Global.Mappings](https://img.shields.io/nuget/v/FubarDev.Lexware.Database.Global.Mappings.svg)](https://www.nuget.org/packages/FubarDev.Lexware.Database.Global.Mappings) |
| Faktura-Strukturen    	| [![FubarDev.Lexware.Database.Faktura](https://img.shields.io/nuget/v/FubarDev.Lexware.Database.Faktura.svg)](https://www.nuget.org/packages/FubarDev.Lexware.Database.Faktura) |
| Faktura-Mappings      	| [![FubarDev.Lexware.Database.Faktura.Mappings](https://img.shields.io/nuget/v/FubarDev.Lexware.Database.Faktura.Mappings.svg)](https://www.nuget.org/packages/FubarDev.Lexware.Database.Faktura.Mappings) |
| Buchhaltung-Strukturen   	| [![FubarDev.Lexware.Database.Buchhaltung](https://img.shields.io/nuget/v/FubarDev.Lexware.Database.Buchhaltung.svg)](https://www.nuget.org/packages/FubarDev.Lexware.Database.Buchhaltung) |
| Buchhaltung-Mappings     	| [![FubarDev.Lexware.Database.Buchhaltung.Mappings](https://img.shields.io/nuget/v/FubarDev.Lexware.Database.Buchhaltung.Mappings.svg)](https://www.nuget.org/packages/FubarDev.Lexware.Database.Buchhaltung.Mappings) |

# Beispiele

## Alle Firmen anzeigen

```csharp
var provider = new SybaseWindowsConfigurationProvider("lexware-server-hostname-or-ip");
using (var context = new LexwareGlobalDbContext(provider))
{
    foreach (var firma in context.Firmen)
    {
        Console.WriteLine("{0} ({1})", firma.Name, firma.Id);
    }
}
```

Der `SybaseWindowsConfigurationProvider` liefert eine Standard-Konfiguration für den `LexwareGlobalDbContext`, die von folgenden Bedingungen ausgeht:

1. Die Datenbanken liegen unterhalb von `c:\ProgramData\Lexware\professional\Datenbank`
2. Der Standard-Datenbank-Name ist `LXOFFICE`
3. Die Standard-Datenbankdatei ist `LXOffice.db`
4. Die Firmen-Datenbankdatei hat den Namen `LxCompany.db`

Der `LexwareGlobalDbContext` stellt folgendes zur Verfügung:

* Read-Only-Zugriff auf die `LXOffice.db`
* Abfrage des Superuser-Logins
* Liste der Benutzer
* Liste der Firmen
* Eine `ISessionFactory` für den Zugriff auf die Firmendatenbank

## Alle Artikel der Warenwirtschaft aller Firmen anzeigen

```csharp
var provider = new SybaseWindowsConfigurationProvider("lexware-server-hostname-or-ip");
provider.MappingAssemblies.Add(typeof(ArtikelMap).Assembly);
using (var context = new LexwareGlobalDbContext(provider))
{
    foreach (var firma in context.Firmen)
    {
        using (var session = context.GetCompanySessionFactory(firma, context.SuperUserLogin).OpenSession())
        {
            foreach (var artikel in session.Query<Artikel>())
            {
                Console.WriteLine("{2}: {0} ({1})", artikel.Bezeichnung, artikel.SheetNr, artikel.ArtikelNr);
            }
        }
    }
}
```
