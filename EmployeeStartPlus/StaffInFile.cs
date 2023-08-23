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