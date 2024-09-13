using Application.Services.Concrete;
using Core.Constants;

namespace NTierArch;
public static class Program
{
    public static void Main()
    {
        bool continuty = true;
        while (continuty)
        {
            ShowMenu();
            Messages.InputMessage("choice");
            string input = Console.ReadLine();
            int choice;
            bool isSucceeded = int.TryParse(input, out choice);
            GroupService groupService = new GroupService();
            if (isSucceeded)
            {
                switch ((Operations)choice)
                {
                    
                    case Operations.GetAllGroups:
                        groupService.GetAllGroups();
                        break;
                    case Operations.AddGroup:
                        groupService.CreateGroup();
                        break;
                    case Operations.UpdateGroup:
                        groupService.UpdateGroup();
                        break;
                    case Operations.DeleteGroup:
                        groupService.RemoveGroup();
                        break;
                    case Operations.Exit:
                        continuty = false;
                        return;
                    default:
                        Messages.InvalidInputMessage("choice");
                        break;
                }
            }
            else
            {
                Messages.InvalidInputMessage("choice");
            }
        }
    }
    public static void ShowMenu()
    {
        Console.WriteLine("MENU");
        Console.WriteLine("1 - Get All Groups");
        Console.WriteLine("2 - Add New Group");
        Console.WriteLine("3 - Remove Group");
        Console.WriteLine("4 - Update Group");
        Console.WriteLine("0 - Exit");
    }
}