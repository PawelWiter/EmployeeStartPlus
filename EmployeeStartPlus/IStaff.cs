using static EmployeeStartPlus.StaffBase;

namespace EmployeeStartPlus
{
    public interface IStaff
    {
        string Name { get; }
        string Surname { get; }

        void AddPoint(float numberOfScore);

        void AddPoint(string numberOfScore);

        event NotEnoughDelegade WorseThenD;

        Statistics GetStatistics();
    }
}