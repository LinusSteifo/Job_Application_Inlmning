public class JobApplication
{
    public string CompanyName;
    public string PositionTitle;
    public Status Status;
    public DateTime ApplicationDate;
    public DateTime? ResponseDate;
    public int SalaryExpectation;

    public int GetDaysSinceApplied()
    {
        return (DateTime.Now - ApplicationDate).Days;
    }

    public string GetSummary()
    {
        return $"{PositionTitle} hos {CompanyName} – Status: {Status} ({GetDaysSinceApplied()} dagar sedan)";
    }
}
