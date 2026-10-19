using System.Collections.Generic;
using System.Linq;

public class JobManager
{
    // Samling av alla ansökningar
    public List<JobApplication> Applications = new List<JobApplication>();

   

    public void AddJob(JobApplication job)
    {
        Applications.Add(job);
    }

    public void ShowAll()
    {
        if (Applications.Count == 0)
        {
            Console.WriteLine("Inga ansökningar registrerade ännu.");
            return;
        }

        foreach (JobApplication a in Applications)
        {
            Console.WriteLine(a.GetSummary());
        }
    }

    public void UpdateStatus(string company, Status nyStatus)
    {
        JobApplication hittad = Applications
            .FirstOrDefault(a => a.CompanyName.ToLower() == company.ToLower());

        if (hittad != null)
        {
            hittad.Status = nyStatus;
            Console.WriteLine("Status uppdaterad!");
        }
        else
        {
            Console.WriteLine("Hittade ingen ansökan med det företagsnamnet.");
        }
    }

    public void RemoveJob(string company)
    {
        JobApplication hittad = Applications
            .FirstOrDefault(a => a.CompanyName.ToLower() == company.ToLower());

        if (hittad != null)
        {
            Applications.Remove(hittad);
            Console.WriteLine("Ansökan borttagen.");
        }
        else
        {
            Console.WriteLine("Hittade ingen ansökan med det företagsnamnet.");
        }
    }

    // ---------- NYTT i feature-linq ----------

    // LINQ: Where – filtrerar ansökningar på en viss status
    public void ShowByStatus(Status status)
    {
        var filtered = Applications.Where(a => a.Status == status);

        if (!filtered.Any())
        {
            Console.WriteLine($"Inga ansökningar med status {status}.");
            return;
        }

        foreach (var a in filtered)
        {
            Console.WriteLine(a.GetSummary());
        }
    }

    // LINQ: OrderBy – sorterar ansökningar efter datum (äldst först)
    public void ShowSortedByDate()
    {
        var sorted = Applications.OrderBy(a => a.ApplicationDate);

        foreach (var a in sorted)
        {
            Console.WriteLine($"{a.ApplicationDate:yyyy-MM-dd}  {a.GetSummary()}");
        }
    }

    // LINQ: Count, GroupBy, Where, Average – visar statistik
    public void ShowStatistics()
    {
        // Totalt antal
        Console.WriteLine($"Totalt antal ansökningar: {Applications.Count}");

        // Antal per status
        var perStatus = Applications.GroupBy(a => a.Status);
        foreach (var grupp in perStatus)
        {
            Console.WriteLine($"  {grupp.Key}: {grupp.Count()} st");
        }

        // Genomsnittlig svarstid (bara ansökningar som fått svar)
        var medSvar = Applications.Where(a => a.ResponseDate != null);

        if (medSvar.Any())
        {
            double snittDagar = medSvar
                .Average(a => (a.ResponseDate.Value - a.ApplicationDate).TotalDays);

            Console.WriteLine($"Genomsnittlig svarstid: {snittDagar:F1} dagar");
        }
        else
        {
            Console.WriteLine("Genomsnittlig svarstid: inga svar mottagna ännu.");
        }
    }

    // Extra filter (VG): ansökningar utan svar som är äldre än 14 dagar
    public void ShowOldUnanswered()
    {
        var gamla = Applications
            .Where(a => a.ResponseDate == null && a.GetDaysSinceApplied() > 14);

        Console.WriteLine("Ansökningar utan svar äldre än 14 dagar:");

        if (!gamla.Any())
        {
            Console.WriteLine("  Inga.");
            return;
        }

        foreach (var a in gamla)
        {
            Console.WriteLine($"  {a.GetSummary()}");
        }
    }
}