namespace EmployeeStartPlus
{
    public abstract class StaffBase : IStaff
    {
        public delegate void NotEnoughDelegade(object sender, EventArgs args);
        public event NotEnoughDelegade WorseThenD;
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public StaffBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public abstract void AddPoint(float point);

        public abstract void AddPoint(string point);

        public abstract Statistics GetStatistics();

        public void PreviewStatistics()
        {
            var statistics = GetStatistics();
            if (statistics.Count != 0)
            {
                Console.Clear();
                Console.WriteLine($"Statistics for {Name} {Surname}:");
                Console.WriteLine($"Total points: {statistics.Count}");
                Console.WriteLine($"The highest point: {statistics.Max:N1}");
                Console.WriteLine($"The lowest point: {statistics.Min:N1}");
                Console.WriteLine($"Average: {statistics.Average:N1}");
                Console.WriteLine();
                Console.WriteLine($"Final assessment: {statistics.AverageLetter}");
                if (statistics.AverageLetter == 'E')
                {
                    CheckEventWorseThenD();
                }
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"You entered no points for {Name} {Surname}, so there is no statistisc.");
                Console.ReadKey();
            }
            void CheckEventWorseThenD()
            {
                if (WorseThenD != null)
                {
                    WorseThenD(this, new EventArgs());
                }
            }
        }
    }
}