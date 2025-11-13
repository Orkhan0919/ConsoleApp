using AcademySystem.Domain.Entities;
using AcademySystem.Presentation.Helpers;
using AcademySystem.Repository.Repositories.Implementations;
using AcademySystem.Service.Services.Implementations;

namespace AcademySystem.Presentation.Controller
{
    public class GroupController
    {
        PrintOptions options = new();
        GroupService groupService = new();
        StudentRepository _studentRepository = new();

        public void GetAll()
        {
            List<Groups> groups = groupService.GetAll();
            if (groups.Count != 0)
            {
                foreach (Groups group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.DarkGreen, $"Group ID: {group.Id}, Name: {group.Name}, " +
                  $"Teacher: {group.Teacher}, Room: {group.Room}");
                }
                Helper.PrintConsole(ConsoleColor.DarkGreen, "Choose another option below:");
                options.GetMenu();
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "No groups found. Please create a new one.");
                options.GetMenu();
            }
        }

        public void Create()
{
name: 
    Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the name of the group:");
    Helper.PrintConsole2(ConsoleColor.Gray, ">>>");
    string groupName = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(groupName))
    {
        Helper.PrintConsole(ConsoleColor.DarkBlue, "Please enter a valid group name:");
        goto name;
    }
    groupName = char.ToUpper(groupName[0]) + groupName.Substring(1).ToLower();

    
    var existingGroup = groupService.GetAll().FirstOrDefault(g => g.Name == groupName);
    if (existingGroup != null)
    {
        Helper.PrintConsole(ConsoleColor.Red, $"A group with the name '{groupName}' already exists!");
        goto name;
    }

teacher: 
    Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the teacher's name for this group:");
    Helper.PrintConsole2(ConsoleColor.Gray, ">>>");
    string groupTeacher = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(groupTeacher) || groupTeacher.Any(char.IsDigit))
    {
        Helper.PrintConsole(ConsoleColor.Yellow, "Please enter a valid teacher name:");
        goto teacher;
    }
    groupTeacher = char.ToUpper(groupTeacher[0]) + groupTeacher.Substring(1).ToLower();

Room: 
    Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the room number for this group:");
    Helper.PrintConsole2(ConsoleColor.Gray, ">>>");
    string groupRoom = Console.ReadLine();

    int room;
    bool isRoom = int.TryParse(groupRoom, out room);
    if (isRoom)
    {
        Groups group = new Groups { Name = groupName, Teacher = groupTeacher, Room = room };
        var result = groupService.Create(group);
        Helper.PrintConsole(ConsoleColor.DarkGreen, $"Group successfully created!\nID: {group.Id}, Name: {group.Name}, " +
            $"Teacher: {group.Teacher}, Room: {group.Room}");
        Helper.PrintConsole(ConsoleColor.DarkGreen, "You can now choose another action:");
        options.GetMenu();
    }
    else
    {
        Helper.PrintConsole(ConsoleColor.Red, "Invalid input. Please enter a valid room number:");
        goto Room;
    }
}


        public void GetById()
        {
        group: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the group ID:");
            Helper.PrintConsole2(ConsoleColor.Gray, ">>>");
            string getById = Console.ReadLine();

            int id;

            bool isGetById = int.TryParse(getById, out id);

            if (isGetById)
            {
                Groups group = groupService.GetById(id);
                if (group != null)
                {
                    Helper.PrintConsole(ConsoleColor.DarkGreen, $"Group found!\nID: {group.Id}, Name: {group.Name}, " +
                    $"Teacher: {group.Teacher}, Room: {group.Room}");
                    Helper.PrintConsole(ConsoleColor.DarkGreen, "Choose another option below:");
                    options.GetMenu();
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed, $"No group found with that ID. Returning to menu...");
                    options.GetMenu();
                }

            }
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "Invalid input. Please enter a numeric group ID:");
                goto group;
            }
        }

        public void GetByRoom()
        {
        Room: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the room number to search:");
            Helper.PrintConsole2(ConsoleColor.Gray, ">>>");
            string getRoom = Console.ReadLine();

            int room;

            bool isGetByroom = int.TryParse(getRoom, out room);

            if (isGetByroom)
            {
                List<Groups> groups = groupService.GetByRoom(room);
                if (groups != null && groups.Count > 0)
                {
                    foreach (var group in groups)
                    {
                        Helper.PrintConsole(ConsoleColor.DarkGreen,
                         $"Group ID: {group.Id}, Name: {group.Name}, " +
                         $"Teacher: {group.Teacher}, Room: {group.Room}");
                    }
                    Helper.PrintConsole(ConsoleColor.DarkGreen, "Choose another option below:");
                    options.GetMenu();
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed,
                        $"No groups found for that room. Returning to menu...");
                    options.GetMenu();
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "Invalid input. Please enter a valid room number:");
                goto Room;
            }
        }

        public void GetByTeacher()
        {
            string groupTeacher = "";

            while (true)
            {
                Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the teacher's name to search:");
                Helper.PrintConsole2(ConsoleColor.Gray, ">>>");
                groupTeacher = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrWhiteSpace(groupTeacher))
                {
                    groupTeacher = char.ToUpper(groupTeacher[0]) + groupTeacher.Substring(1).ToLower();
                    break;
                }

                Helper.PrintConsole(ConsoleColor.DarkBlue, "Please enter a valid teacher name:");
            }

            List<Groups> groups = groupService.GetByTeacher(groupTeacher);

            if (groups != null && groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.DarkGreen,
                        $"Group ID: {group.Id}, Name: {group.Name}, " +
                        $"Teacher: {group.Teacher}, Room: {group.Room}");
                }
                Helper.PrintConsole(ConsoleColor.DarkGreen, "Select another option to continue:");
                options.GetMenu();
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "No groups found for this teacher. Returning to menu...");
                options.GetMenu();
            }
        }


        public void Update()
        {
            IdType: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the ID of the group you want to update:");
            Helper.PrintConsole2(ConsoleColor.Gray, ">>>");
            string getById = Console.ReadLine();
            int id;

            bool isGetById = int.TryParse(getById, out id);
            if (isGetById)
            {
            name: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the new name for the group:");
            Helper.PrintConsole2(ConsoleColor.Gray, ">>>");
                string newName = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(newName))
                {
                    Helper.PrintConsole(ConsoleColor.DarkBlue, "Please provide a valid group name:");
                    goto name;
                }
                newName = char.ToUpper(newName[0]) + newName.Substring(1).ToLower();

            teacher: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the new teacher's name:");
            Helper.PrintConsole2(ConsoleColor.Gray, ">>>");
                string newTeacher = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(newTeacher))
                {
                    Helper.PrintConsole(ConsoleColor.DarkBlue, "Please provide a valid teacher name:");
                    goto teacher;
                }
                newTeacher = char.ToUpper(newTeacher[0]) + newTeacher.Substring(1).ToLower();

            roomm: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the new room number:");
            Helper.PrintConsole2(ConsoleColor.Gray, ">>>");
            string newRoom = Console.ReadLine();

                int room;

                bool IsRoom = int.TryParse(newRoom, out room);
                if (IsRoom)
                {
                    Groups group = new Groups { Name = newName, Teacher = newTeacher, Room = room };
                    Groups groups = groupService.Update(id, group);

                    if (groups != null)
                    {
                        Helper.PrintConsole(ConsoleColor.DarkGreen, $"Group updated successfully!\nID: {group.Id}, Name: {group.Name}, " +
                        $"Teacher: {group.Teacher}, Room: {group.Room}");
                        Helper.PrintConsole(ConsoleColor.DarkGreen, "Choose another action:");
                        options.GetMenu();
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.DarkRed, "No group found with that ID. Returning to menu...");
                        options.GetMenu();
                    }

                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed, "Invalid input. Please enter a valid room number:");
                    goto roomm;

                }   
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "Invalid input. Please enter a numeric group ID:");
                goto IdType;
            }

        }

        public void Delete()
        {
        deletegroup: Helper.PrintConsole(ConsoleColor.DarkBlue, "Enter the ID of the group to delete:");
        Helper.PrintConsole2(ConsoleColor.Gray, ">>>");
        string getById = Console.ReadLine();

            int id;

            bool isGetById = int.TryParse(getById, out id);

            if (isGetById)
            {
                Groups group = groupService.GetById(id);
                if (group != null)
                {
                    Helper.PrintConsole(ConsoleColor.DarkGreen, "The group has been deleted successfully.");
                    Helper.PrintConsole(ConsoleColor.DarkGreen, "Select another option to continue:");
                    options.GetMenu();
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.DarkRed, "No group found with that ID. Returning to menu...");
                    options.GetMenu();
                }

            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid input. Please enter a valid numeric group ID:");
                goto deletegroup;
            }
        }

        public void Search()
        {
            SearchText: Helper.PrintConsole(ConsoleColor.Blue, "Enter text to search for groups:");
            Helper.PrintConsole2(ConsoleColor.Gray, ">>>");
            string searchName = Console.ReadLine();

            List<Groups> groups = groupService.Search(searchName);

            if (groups.Count != 0)
            {
                foreach (Groups group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.DarkGreen, $"Group ID: {group.Id}, Name: {group.Name}, " +
                  $"Teacher: {group.Teacher}, Room: {group.Room}");
                }
                Helper.PrintConsole(ConsoleColor.DarkGreen, "Choose another option below:");
                options.GetMenu();
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.DarkRed, "No groups matched your search. Try again or create a new one.");
                options.GetMenu();
            }
        }
    }
}
