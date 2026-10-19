using System.Collections.Generic;
using System.Linq;

public class JobManager
{
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
            a.PrintColored(); // NYTT (var: Console.WriteLine(a.GetSummary());)
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
            a.PrintColored(); // NYTT
        }
    }

    public void ShowSortedByDate()
    {
        var sorted = Applications.OrderBy(a => a.ApplicationDate);

        foreach (var a in sorted)
        {
            Console.Write($"{a.ApplicationDate:yyyy-MM-dd}  "); // NYTT (Write istället för WriteLine)
            a.PrintColored();                                    // NYTT
        }
    }

    public void ShowStatistics()
    {
        Console.WriteLine($"Totalt antal ansökningar: {Applications.Count}");

        var perStatus = Applications.GroupBy(a => a.Status);
        foreach (var grupp in perStatus)
        {
            Console.WriteLine($"  {grupp.Key}: {grupp.Count()} st");
        }

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
            Console.Write("  "); // NYTT
            a.PrintColored();    // NYTT
        }
    }
}