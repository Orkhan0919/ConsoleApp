using AcademySystem.Domain.Entities;
using AcademySystem.Presentation.Helpers;
using AcademySystem.Repository.Repositories.Implementations;
using AcademySystem.Service.Services.Implementations;

namespace AcademySystem.Presentation.Controller
{
    public class StudentController
    {
        PrintOptions options = new();
        StudentService studentService = new();

        public void GetByGroupID()
        {
            var groupService = new GroupService(); 
            var allGroups = groupService.GetAll();
            if (allGroups == null || allGroups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, 
                    "No groups found. Add group first.");
                options.GetMenu(); 
                return; 
            }

        groupId: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the group ID to list its students:");
            Helper.PrintConsole2(ConsoleColor.Gray,">>>");
            string inputId = Console.ReadLine();

            if (int.TryParse(inputId, out int id))
            {
                var students = studentService.GetByGroupId(id);
                if (students != null && students.Count > 0)
                {
                    foreach (var s in students)
                        Helper.PrintConsole(ConsoleColor.DarkGreen, $"ID: {s.Id}, Name: {s.Name}, Surname: {s.Surname}, Age: {s.Age}, Group: {s.Group.Name}");

                    Helper.PrintConsole(ConsoleColor.DarkGreen, "Choose another option below:");
                    options.GetMenu();
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed, "No students found for this group.");
                    options.GetMenu();
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "Invalid input. Please enter a numeric group ID.");
                goto groupId;
            }
        }

        public void Delete()
        {
            var groupService = new GroupService(); 
            var allGroups = groupService.GetAll();
            if (allGroups == null || allGroups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, 
                    "No groups found. Add group first.");
                options.GetMenu(); 
                return; 
            }

        delId: Helper.PrintConsole(ConsoleColor.DarkBlue, "Provide the student ID to remove:");
        Helper.PrintConsole2(ConsoleColor.Gray,">>>"); 
        string idText = Console.ReadLine();

            if (int.TryParse(idText, out int id))
            {
                var student = studentService.GetById(id);
                if (student != null)
                {
                    studentService.Delete(id);
                    Helper.PrintConsole(ConsoleColor.DarkGreen, "Student successfully removed from the system.");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed, "No student found with that ID.");
                }
                options.GetMenu();
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "Please type a valid numeric ID.");
                goto delId;
            }
        }

        public void GetByAge()
        {
            var groupService = new GroupService(); 
            var allGroups = groupService.GetAll();
            if (allGroups == null || allGroups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, 
                    "No groups found. Add group first.");
                options.GetMenu(); 
                return; 
            }

        ageEntry: Helper.PrintConsole(ConsoleColor.DarkBlue, "Type the student age to filter by:");
          Helper.PrintConsole2(ConsoleColor.Gray,">>>");  
        string ageText = Console.ReadLine();

            if (int.TryParse(ageText, out int age))
            {
                var students = studentService.GetByAge(age);
                if (students.Any())
                {
                    foreach (var s in students)
                        Helper.PrintConsole(ConsoleColor.DarkGreen, $"ID: {s.Id}, Name: {s.Name}, Surname: {s.Surname}, Age: {s.Age}, Group: {s.Group.Name}");

                    Helper.PrintConsole(ConsoleColor.DarkGreen, "Would you like to continue? Choose an option:");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed, "No students match that age.");
                }
                options.GetMenu();
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "Age must be a number. Try again.");
                goto ageEntry;
            }
        }

        public void Search()
        {
            var groupService = new GroupService(); 
            var allGroups = groupService.GetAll();
            if (allGroups == null || allGroups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, 
                    "No groups found. Add group first.");
                options.GetMenu(); 
                return; 
            }

        searchPrompt: Helper.PrintConsole(ConsoleColor.Blue, "Enter keyword to search students:");
            string searchKey = Console.ReadLine();

            var results = studentService.Search(searchKey);
            if (results.Any())
            {
                foreach (var s in results)
                    Helper.PrintConsole(ConsoleColor.DarkGreen, $"ID: {s.Id}, Name: {s.Name}, Surname: {s.Surname}, Age: {s.Age}, Group: {s.Group.Name}");
                Helper.PrintConsole(ConsoleColor.DarkGreen, "Search completed. Select another option:");
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "No matching students found.");
            }
            options.GetMenu();
        }

        public void GetAll()
        {
            var groupService = new GroupService(); 
            var allGroups = groupService.GetAll();
            if (allGroups == null || allGroups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, 
                    "No groups found. Add group first.");
                options.GetMenu(); 
                return; 
            }

            var allStudents = studentService.GetAll();
            if (allStudents.Count > 0)
            {
                foreach (var s in allStudents)
                    Helper.PrintConsole(ConsoleColor.DarkGreen, $"ID: {s.Id}, Name: {s.Name}, Surname: {s.Surname}, Age: {s.Age}, Group: {s.Group.Name}");
                Helper.PrintConsole(ConsoleColor.DarkGreen, "All students displayed. Pick another option:");
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "There are currently no students registered.");
            }
            options.GetMenu();
        }

        public void Update()
        {
            var groupService = new GroupService(); 
            var allGroups = groupService.GetAll();
            if (allGroups == null || allGroups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, 
                    "No groups found. Add group first.");
                options.GetMenu(); 
                return; 
            }

        updId: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the ID of the student to modify:");
        Helper.PrintConsole2(ConsoleColor.Gray,">>>");    
        string inputId = Console.ReadLine();

            if (int.TryParse(inputId, out int id))
            {
            newName: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the student's new first name:");
            Helper.PrintConsole2(ConsoleColor.Gray,">>>"); 
            
                string newName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newName) || !newName.All(char.IsLetter))
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed, "Name must contain only letters. Try again.");
                    goto newName;
                }

            newSurname: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the student's new surname:");
            Helper.PrintConsole2(ConsoleColor.Gray,">>>"); 
            string newSurname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newSurname) || !newSurname.All(char.IsLetter))
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed, "Surname must contain only letters. Try again.");
                    goto newSurname;
                }

            newAge: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the updated age:");
            Helper.PrintConsole2(ConsoleColor.Gray,">>>"); 
            int newAge = int.Parse(Console.ReadLine());

                if (newAge>15 && newAge < 30 )
                {
                    var updated = new Student { Name = Capitalize(newName), Surname = Capitalize(newSurname), Age = newAge };
                    var result = studentService.Update(id, updated);
                    if (result != null)
                    {
                        Helper.PrintConsole(ConsoleColor.DarkGreen, $"Updated -> ID: {updated.Id}, Name: {updated.Name}, Surname: {updated.Surname}, Age: {updated.Age}");
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.DarkRed, "Student not found for update.");
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed, "Age should be a valid number.");
                    goto newAge;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "Invalid student ID. Please try again.");
                goto updId;
            }
            options.GetMenu();
        }

        public void Create()
        {
            var groupService = new GroupService(); 
            var allGroups = groupService.GetAll();
            if (allGroups == null || allGroups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, 
                    "No groups found. Add group first.");
                options.GetMenu(); 
                return; 
            }
            
            
        grpId: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the group ID to add student to:");
        Helper.PrintConsole2(ConsoleColor.Gray,">>>"); 
        string grpText = Console.ReadLine();

            if (int.TryParse(grpText, out int groupId))
            {
            sName: Helper.PrintConsole(ConsoleColor.DarkBlue, "Type the student's first name:");
            Helper.PrintConsole2(ConsoleColor.Gray,">>>"); 
            string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter))
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed, "Invalid name format. Use only letters.");
                    goto sName;
                }

            sSurname: Helper.PrintConsole(ConsoleColor.DarkBlue, "Type the student's last name:");
            Helper.PrintConsole2(ConsoleColor.Gray,">>>"); 
            string surname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(surname) || !surname.All(char.IsLetter))
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed, "Invalid surname format. Use only letters.");
                    goto sSurname;
                }

            sAge: Helper.PrintConsole(ConsoleColor.DarkBlue, "Provide the student's age:");
            Helper.PrintConsole2(ConsoleColor.Gray,">>>"); 
            string ageText = Console.ReadLine();

                if (int.TryParse(ageText, out int age) && age<30 && age > 15)
                {
                    var student = new Student { Name = Capitalize(name), Surname = Capitalize(surname), Age = age };
                    var result = studentService.Create(groupId, student);
                    if (result != null)
                    {
                        Helper.PrintConsole(ConsoleColor.DarkGreen, $"Student Created -> ID: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Group: {student.Group.Name}");
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.DarkRed, "Group not found. Please verify ID.");
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed, "Age must be a valid number. Try again.");
                    goto sAge;
                }
            }
            
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "Group ID must be numeric. Try again.");
                goto grpId;
            }
            options.GetMenu();
        }

        public void GetByID()
        {
            var groupService = new GroupService(); 
            var allGroups = groupService.GetAll();
            if (allGroups == null || allGroups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, 
                    "No groups found. Add group first.");
                options.GetMenu(); 
                return; 
            }

        idEntry: Helper.PrintConsole(ConsoleColor.DarkBlue, "Please enter the student ID:");
        Helper.PrintConsole2(ConsoleColor.Gray,">>>");  
        string idText = Console.ReadLine();

            if (int.TryParse(idText, out int id))
            {
                var student = studentService.GetById(id);
                if (student != null)
                {
                    Helper.PrintConsole(ConsoleColor.DarkGreen, $"Student Info -> ID: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Group: {student.Group.Name}");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed, "No student found with that ID.");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "Invalid input. Enter a numeric ID.");
                goto idEntry;
            }
            options.GetMenu();
        }

        private static string Capitalize(string input)
        {
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
