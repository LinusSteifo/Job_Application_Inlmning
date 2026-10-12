}using System.Linq;

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
            Console.WriteLine(a.GetSummary());
        }
    }

    public void UpdateStatus(string company, Status nyStatus)
    {
        JobApplication hittad = Applications.FirstOrDefault(a => a.CompanyName.ToLower() == company.ToLower());

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
        JobApplication hittad = Applications.FirstOrDefault(a => a.CompanyName.ToLower() == company.ToLower());

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
}
