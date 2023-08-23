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

        public void AddPoint(string point)
        {
            var listOfSchoolScore = new[] { "1", "2", "3", "4", "5", "6", "+1", "1+", "2-", "-2", "2+", "+2", "3-", "-3", "3+", "+3", "4-", "-4", "4+", "+4", "5-", "-5", "5+", "+5", "-6", "6-" };

            if (_ = listOfSchoolScore.Contains(point))
            {
                float correctionValue;

                if (point.Contains('+'))
                {
                    point = point.Replace("+", "");
                    correctionValue = 0.4f;
                }
                else if (point.Contains('-'))
                {
                    point = point.Replace("-", "");
                    correctionValue = -0.2f;
                }
                else
                {
                    correctionValue = 0f;
                }

                switch (point)
                {
                    case "6":
                        this.AddPoint(6f + correctionValue);
                        break;
                    case "5":
                        this.AddPoint(5f + correctionValue);
                        break;
                    case "4":
                        this.AddPoint(4f + correctionValue);
                        break;
                    case "3":
                        this.AddPoint(3f + correctionValue);
                        break;
                    case "2":
                        this.AddPoint(2f + correctionValue);
                        break;
                    case "1":
                        this.AddPoint(1f + correctionValue); ;
                        break;
                    default:
                        throw new Exception("#error: probably wrong grade entered");
                }
            }
            else if (float.TryParse(point, out float result))
            {
                result = float.Round(result, 1);
                this.AddPoint(result);
            }
            else if (point.EndsWith('%'))
            {
                point = point.Replace("%", "");
                float.TryParse(point, out float result1);
                result1 = float.Round(((result1 * 5 / 100) + 1), 1);
                this.AddPoint(result1);
            }
            else
            {
                throw new Exception("#error: entered string is not a float");
            }
        }

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