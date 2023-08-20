namespace EmployeeStartPlus.Tests
{
    public class EmployeeTests
    {
        [Test]
        public void WhenCheckAverageShouldBeNotEqualToMinAndMax()
        {
            //arrange
            var StaffInMemory = new StaffInMemory("Piotr", "Kowalski");

            StaffInMemory.AddPoint(1);
            StaffInMemory.AddPoint(2);
            StaffInMemory.AddPoint(3);

            //act

            var statistics = StaffInMemory.GetStatistics();
            var average = statistics.Average;
            var min = statistics.Min;
            var max = statistics.Max;
            var averageAsLetter = statistics.AverageLetter;

            //assert
            Assert.That(min, Is.Not.GreaterThanOrEqualTo(average));
            Assert.That(max, Is.GreaterThanOrEqualTo(average));
            Assert.That(Equals(average, 2f));
            Assert.That(Equals(averageAsLetter, 'D'));
        }

        [Test]
        public void WhenInputPointsAsPercentRangeShouldChangeToNumber()
        {
            //arrange
            var StaffInMemory = new StaffInMemory("Piotr", "Kowalski");

            StaffInMemory.AddPoint("100%");
            StaffInMemory.AddPoint("0%");

            //act

            var statistics = StaffInMemory.GetStatistics();
            var averageLetter = statistics.AverageLetter;
            var averageNumber = statistics.Average;

            //Assert

            Assert.That(Equals(averageNumber, 3.5f));
            Assert.That(Equals(averageLetter, 'C'));
        }
    }
}