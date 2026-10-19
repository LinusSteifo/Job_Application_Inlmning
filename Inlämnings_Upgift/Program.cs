JobManager manager = new JobManager();
bool kor = true;

while (kor)
{
    Console.WriteLine();
    Console.WriteLine("=== JOB APPLICATION TRACKER ===");
    Console.WriteLine("1. Lägg till ny ansökan");
    Console.WriteLine("2. Visa alla ansökningar");
    Console.WriteLine("3. Filtrera efter status");
    Console.WriteLine("4. Sortera efter datum");
    Console.WriteLine("5. Visa statistik");
    Console.WriteLine("6. Uppdatera status");
    Console.WriteLine("7. Ta bort ansökan");
    Console.WriteLine("8. Avsluta");
    Console.Write("Välj ett alternativ: ");

    string val = Console.ReadLine();

    switch (val)
    {
        case "1":
            LaggTillAnsokan(manager);
            break;
        case "2":
            manager.ShowAll();
            break;
        case "3":
            Console.Write("Vilken status vill du filtrera på (Applied/Interview/Offer/Rejected)? ");
            if (Enum.TryParse<Status>(Console.ReadLine(), true, out Status filterStatus))
            {
                manager.ShowByStatus(filterStatus);
            }
            else
            {
                Console.WriteLine("Ogiltig status.");
            }
            break;
        case "4":
            manager.ShowSortedByDate();
            break;
        case "5":
            manager.ShowStatistics();
            Console.WriteLine();
            manager.ShowOldUnanswered();
            break;
            Console.Write("Vilket företag vill du uppdatera? ");
            string foretag = Console.ReadLine();
            Console.Write("Ny status (Applied/Interview/Offer/Rejected): ");
            Status nyStatus = Enum.Parse<Status>(Console.ReadLine());
            manager.UpdateStatus(foretag, nyStatus);
            break;
        case "7":
            Console.Write("Vilket företag vill du ta bort? ");
            string taBort = Console.ReadLine();
            manager.RemoveJob(taBort);
            break;
        case "8":
            kor = false;
            break;
        default:
            Console.WriteLine("Ogiltigt val.");
            break;
    }
}

void LaggTillAnsokan(JobManager m)
{
    Console.Write("Företag: ");
    string company = Console.ReadLine();

    Console.Write("Titel: ");
    string title = Console.ReadLine();

    Console.Write("Önskad lön: ");
    int lon = int.Parse(Console.ReadLine());

    JobApplication job = new JobApplication
    {
        CompanyName = company,
        PositionTitle = title,
        Status = Status.Applied,
        ApplicationDate = DateTime.Now,
        SalaryExpectation = lon
    };

    m.AddJob(job);
    Console.WriteLine("Ansökan tillagd!");
}
