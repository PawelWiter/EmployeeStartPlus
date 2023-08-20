namespace EmployeeStartPlus
{
    public class StaffInFile : StaffBase
    {
        private const string FileName = " - grades.txt";
        private string staffFileName;

        public StaffInFile(string name, string surname)
        : base(name, surname)
        {
            staffFileName = name + surname + FileName;
        }

        public override void AddPoint(float point)
        {
            if (point >= 1 && point <= 6)
            {
                using var writer = File.AppendText(staffFileName);
                writer.WriteLine(point);
            }
            else
            {
                throw new Exception("#error: value out of range");
            }
        }

        public override void AddPoint(string point)
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

        private List<float> ReadScoresFromFile()
        {
            var points = new List<float>();
            if (File.Exists($"{staffFileName}"))
            {
                using (var reader = File.OpenText(staffFileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        points.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return points;
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var score in ReadScoresFromFile())
            {
                statistics.AddPoint(score);
            }
            return statistics;
        }
    }
}