
namespace AcademySystem.Presentation.Helpers
{
    public  class PrintOptions
    {
        public  void GetMenu()
        {
            Helper.PrintConsole(ConsoleColor.DarkCyan, 
                "1 - GetById Group, " + 
                "2 - Delete Group, " +
                "3 - Update Group, " +
                "4 - Create Group, " +
                "5 - GetAll Group, " +
                "6 - Create Student, " +
                "7 - Update Student, " +
                "8 - GetById Student, " +
                "9 - Delete Student, " +
                "10 - GetAll Student, " +
                "11 - Get by Groups Teacher, " +
                "12 - Get by Groups Room, " +
                "13 - Get by Age, " +
                "14 - Get by GroupId, " +
                "15 - Search Group by Name, " +
                "16 - Search Student by Name");

        }
    }

}
