namespace EmployeeStartPlus
{
    public class Statistics
    {
        public float Min { get; private set; }

        public float Max { get; private set; }

        public float Sum { get; private set; }

        public int Count { get; private set; }

        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }

        public char AverageLetter
        {
            get
            {
                switch (this.Average)
                {
                    case var average when average >= 5:
                        return 'A';
                    case var average when average >= 4:
                        return 'B';
                    case var average when average >= 3:
                        return 'C';
                    case var average when average >= 2:
                        return 'D';
                    default:
                        return 'E';
                }
            }
        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
        }

        public void AddPoint(float point)
        {
            this.Count++;
            this.Sum += point;
            this.Min = Math.Min(this.Min, point);
            this.Max = Math.Max(this.Max, point);
        }
    }
}
