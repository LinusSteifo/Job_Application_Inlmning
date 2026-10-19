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


    // NY metod: skriver ut sammanfattningen i en färg som beror på status
    public void PrintColored()
    {
        Console.ForegroundColor = Status switch
        {
            Status.Offer => ConsoleColor.Green,
            Status.Rejected => ConsoleColor.Red,
            Status.Interview => ConsoleColor.Yellow,
            _ => ConsoleColor.White
        };

        Console.WriteLine(GetSummary());
        Console.ResetColor();
    }
}

