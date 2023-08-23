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