namespace EmployeeStartPlus
{
    public class StaffInMemory : StaffBase
    {
        private List<float> pointsList;
        public StaffInMemory(string name, string surname)
        : base(name, surname)
        {
            pointsList = new List<float>();
        }

        public override void AddPoint(float point)
        {
            if (point >= 1 && point <= 6)
            {
                this.pointsList.Add(point);
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

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var point in this.pointsList)
            {
                statistics.AddPoint(point);
            }
            return statistics;
        }
    }
}