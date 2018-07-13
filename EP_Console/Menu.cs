using System;
using System.Text;
using System.Text.RegularExpressions;
using BL;
using DAL;
using Persistence;

namespace EP_Console
{
    public class Menus
    {
        public void MenuChoice()
        {
            Console.Clear();
            string[] choice = { "Đăng nhập", "Thoát chương trình" };
            int choose = Menu("Chào mừng bạn", choice);
            switch (choose)
            {
                case 1:
                    MenuLogin();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
        public void MenuLogin()
        {
            Console.Clear();
            string row1 = "========================================";
            string row2 = "----------------------------------------";
            Console.WriteLine(row1);
            Console.WriteLine(" ĐĂNG NHẬP");
            Console.WriteLine(row2);
            Console.Write("Nhập Username: ");
            string un = Console.ReadLine();
            Console.Write("Nhập Password: ");
            string pw = Password();
            string choice;
            while ((validate(un, 0) == false) || (validate(pw, 0) == false))
            {
                Console.Write("Đăng nhập lỗi, bạn có muốn tiếp tục đăng nhập không? (Y/N)");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "Y":
                        break;
                    case "y":
                        break;
                    case "n":
                        MenuChoice();
                        break;
                    case "N":
                        MenuChoice();
                        break;
                    default:

                        continue;
                        // break;
                }
                Console.Clear();
                Console.WriteLine("Username và Password không được chứa ký tự đặc biệt! ");
                Console.WriteLine(row1);
                Console.WriteLine(" ĐĂNG NHẬP");
                Console.WriteLine(row2);
                Console.Write("Nhập lại Username: ");
                un = Console.ReadLine();
                Console.Write("Nhập lại Password: ");
                pw = Password();
            }


            UserBL ubl = new UserBL();
            while (ubl.Login(un, pw) == null)
            {

                Console.Write("Đăng nhập lỗi, bạn có muốn tiếp tục đăng nhập không? (Y/N)");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "Y":
                        break;
                    case "y":
                        break;
                    case "n":
                        MenuChoice();
                        break;
                    case "N":
                        MenuChoice();
                        break;
                    default:
                        // Console.Write("Đăng nhập lỗi, bạn có muốn tiếp tục đăng nhập không? (Y/N)");
                        continue;
                        // break;
                }
                Console.Clear();
                Console.WriteLine("Sai Username, Password!");
                Console.WriteLine(row1);
                Console.WriteLine(" ĐĂNG NHẬP");
                Console.WriteLine(row2);
                Console.Write("Nhập lại Username: ");
                un = Console.ReadLine();
                Console.Write("Nhập lại Password: ");
                pw = Password();
                while ((validate(un, 0) == false) || (validate(pw, 0) == false))
                {
                    Console.Write("Đăng nhập lỗi, bạn có muốn tiếp tục đăng nhập không? (Y/N)");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "Y":
                            break;
                        case "y":
                            break;
                        case "n":
                            MenuChoice();
                            break;
                        case "N":
                            MenuChoice();
                            break;
                        default:
                            // Console.Write("Đăng nhập lỗi, bạn có muốn tiếp tục đăng nhập không? (Y/N)");
                            continue;
                            // break;
                    }
                    Console.Clear();
                    Console.WriteLine("Username và Password không được chứa ký tự đặc biệt! ");
                    Console.WriteLine(row1);
                    Console.WriteLine(" ĐĂNG NHẬP");
                    Console.WriteLine(row2);
                    Console.Write("Nhập lại Username: ");
                    un = Console.ReadLine();
                    Console.Write("Nhập lại Password: ");
                    pw = Password();
                }

            }
            if (ubl.Login(un, pw).AccountType == "0")
            {
                menuManager(ubl.Login(un, pw));
            }
            else if (ubl.Login(un, pw).AccountType == "1")
            {
                menuStaff(ubl.Login(un, pw));
            }
        }
        public bool validate(string str, int status)
        {
            if (status == 0)
            {
                Regex regex = new Regex("[a-zA-Z0-9_]");
                MatchCollection matchCollectionstr = regex.Matches(str);
                // Console.WriteLine(matchCollectionstr.Count);
                if (matchCollectionstr.Count < str.Length)
                {
                    return false;
                }
                return true;
            }
            else if (status == 1)
            {
                Regex regex = new Regex("[0-9]");
                MatchCollection matchCollectionstr = regex.Matches(str);
                if ((str.Length < 1) || (str.Length > 2) || (matchCollectionstr.Count < str.Length) || (Int16.Parse(str)) > 23 || (Int16.Parse(str) < 0))
                {
                    return false;
                }
                return true;
            }
            else if (status == 2)
            {
                Regex regex = new Regex("[0-9]");
                MatchCollection matchCollectionstr = regex.Matches(str);
                if ((str.Length < 1) || (str.Length > 2) || (matchCollectionstr.Count < str.Length) || (Int16.Parse(str)) > 60 || (Int16.Parse(str) < 0))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public void menuManager(User us)
        {
            Menus x = new Menus();
            UserBL ubl = new UserBL();
            EventBL ebl = new EventBL();
            Console.Clear();
            string[] managermenu = { "Tạo Sự Kiện", "Mời tham gia sự kiện", "Xem danh sách người dùng", "Xem danh sách sự kiện", "Đăng xuất" };
            do
            {
                short mana = Menu("Bắt Đầu Quản Lý Sự Kiện", managermenu);
                switch (mana)
                {
                    case 3:
                        Console.Clear();
                        var lists = ubl.GetAllUser();
                        string line = ("\n|=======================================================================|\n");
                        Console.WriteLine("\tDanh Sách Người Dùng\t");
                        //Console.Write("|  Name\t\t|\tAge\t|\tJob\t|\tPhone Number\t|");
                        Console.WriteLine("|  {0,-10}\t|\t{1,-10}\t|\t{2,-15}\t|\t{3,-20}\t|","Name","Age","Job","Phone Number");
                        Console.WriteLine(line);
                        foreach (var User in lists)
                        {
                            //Console.WriteLine("|  {0,%5s}\t|{1,-10}|{2,-12}|{3,-15}|", User.Name, User.Age, User.Job, User.Phone);
                            Console.WriteLine("|  {0,-10}\t|\t{1,-10}\t|\t{2,-15}\t|\t{3,-20}\t|", User.Name, User.Age, User.Job, User.Phone);

                        }
                        Console.Write("Press Anything To ComeBack................... ");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.Clear();
                        var list = ebl.GetAllEvent();
                        string lin = ("\n================================================================================================================================\n");
                        Console.Write(" Event ID  |          Name Event         |        Address         |             Description           |        Time       | ");
                        Console.WriteLine(lin);
                        foreach (var Event in list)
                        {
                            Console.WriteLine("{0,-20}{1,-10}{2,-12}{3,-15}{4,-16}", Event.ID_Event, Event.Name_Event, Event.Address_Event, Event.Description, Event.Time);
                        }
                        Console.Write("Press Anything To ComeBack................... ");
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.Clear();
                        MenuChoice();
                        break;
                }
            } while (true);
        }
        public void menuStaff(User us)
        {
            Console.Clear();
            string[] staffmenu = { "Xem sự kiện", "Đăng xuất." };
            int staff = Menu("Chào Bạn", staffmenu);
            switch (staff)
            {
                case 1:
                    Console.Clear();

                    break;
                case 2:
                    Console.Clear();
                    MenuChoice();
                    break;
            }
        }
        public string Password()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.Write("\b\0\b");
                        sb.Length--;
                    }
                    continue;
                }
                Console.Write('*');
                sb.Append(cki.KeyChar);
            }
            return sb.ToString();
        }
        public short Menu(string title, string[] menuItems)
        {
            short choose = 0;
            string line1 = "========================================";
            string line2 = "----------------------------------------";
            Console.WriteLine(line1);
            Console.WriteLine(" " + title);
            Console.WriteLine(line2);
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine(" " + (i + 1) + ". " + menuItems[i]);
            }
            Console.WriteLine(line2);
            do
            {
                Console.Write("Bạn chọn: ");
                try
                {
                    choose = Int16.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Bạn chọn không đúng!");
                    continue;
                }
            }
            while (choose <= 0 || choose > menuItems.Length);
            return choose;
        }
    }
}