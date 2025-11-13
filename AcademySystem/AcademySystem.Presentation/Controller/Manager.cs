using AcademySystem.Presentation.Controller;
using AcademySystem.Presentation.Helpers;
namespace AcademySystem.Presentation;

public class Manager
{
    public static void Manage()
    {
            PrintOptions menuPrinter = new();
            GroupController groupCtrl = new();
            StudentController studentCtrl = new();

            Helper.PrintConsole(ConsoleColor.DarkGray, "Choose an action from the list below!");
            menuPrinter.GetMenu();
           

            while (true)
            {
            ChooseOption:
                Helper.PrintConsole2(ConsoleColor.Gray,">>>"); 
                string userInput = Console.ReadLine();
                bool isValidChoice = int.TryParse(userInput, out int selectedNumber);

                if (isValidChoice)
                {
                    switch (selectedNumber)
                    {
                        case (int)Menu.GetById: groupCtrl.GetById(); break;
                        case (int)Menu.DeleteGroup: groupCtrl.Delete(); break;
                        case (int)Menu.UpdateGroup: groupCtrl.Update(); break;
                        case (int)Menu.CreateGroup: groupCtrl.Create(); break;
                        case (int)Menu.GetAllGroup: groupCtrl.GetAll(); break;
                        case (int)Menu.CreateStudent: studentCtrl.Create(); break;
                        case (int)Menu.UpdateStudent: studentCtrl.Update(); break;
                        case (int)Menu.GetByIdStudent: studentCtrl.GetByID(); break;
                        case (int)Menu.DeleteStudent: studentCtrl.Delete(); break;
                        case (int)Menu.GetAllStudent: studentCtrl.GetAll(); break;
                        case (int)Menu.GetByTeacher: groupCtrl.GetByTeacher(); break;
                        case (int)Menu.GetByRoom: groupCtrl.GetByRoom(); break;
                        case (int)Menu.GetByAge: studentCtrl.GetByAge(); break;
                        case (int)Menu.GetByGroupId: studentCtrl.GetByGroupID(); break;
                        case (int)Menu.SearchGroupByName: groupCtrl.Search(); break;
                        case (int)Menu.SearchStudentByName: studentCtrl.Search(); break;
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Please enter a valid option number!");
                    goto ChooseOption;
                }
            }
    }
}