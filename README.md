# Job Application Tracker

Ett konsolprogram i C# som hjälper användaren att hålla koll på sina jobbansökningar.
Man kan lägga till, visa, filtrera, sortera, uppdatera och ta bort ansökningar, samt se statistik.

## Funktioner
- Lägga till ny ansökan (företag, titel, önskad lön)
- Visa alla ansökningar (färgkodade efter status)
- Filtrera ansökningar efter status (LINQ)
- Sortera ansökningar efter datum (LINQ)
- Visa statistik: totalt antal, antal per status och genomsnittlig svarstid (LINQ)
- Visa ansökningar utan svar som är äldre än 14 dagar
- Uppdatera status på en ansökan
- Ta bort en ansökan

## Projektstruktur
| Fil | Beskrivning |
|---|---|
| `Program.cs` | Menyn (while-loop och switch) |
| `JobManager.cs` | Hanterar listan med ansökningar och all LINQ-logik |
| `JobApplication.cs` | Representerar en enskild ansökan |
| `Status.cs` | Enum med Applied, Interview, Offer och Rejected |

## Hur man kör programmet
1. Klona repot
2. Öppna en terminal i projektmappen
3. Kör:

```
dotnet run
```

## Färger i konsolen
- Grön = Offer
- Röd = Rejected
- Gul = Interview
- Vit = Applied

## Git och GitHub
Projektet har byggts med flera branches och Pull Requests:
- `feature-menu`: meny och grundfunktioner
- `feature-linq`: filtrering, sortering och statistik med LINQ
- `feature-colors`: färgkodad utskrift

Branch protection är aktiverat på `main`, så ändringar går via Pull Requests.

## Reflektion
**Hur hjälpte LINQ dig att skriva renare kod?**

LINQ låter dig beskriva vad du vill ha i stället för att skriva ut hur det ska göras steg för steg. Resultatet blir kortare kod som är lättare att läsa. t.ex i min kod n rad som kan läsas som en mening: "ta ansökningarna där statusen är Interview".

**Vilken del av projektet var mest utmanande, och hur löste du den?**

Jobmanager.cs var de mest utmanande för mycket rader av kod blir struligt tillslut att förstå använde mig mycket utav ai och videos.

## Skapad av
Linus Steifo, 2026-10-19
