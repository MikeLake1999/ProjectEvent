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
                Console.Clear();
                Menus x = new Menus();
                EventDetailsBL edbl = new EventDetailsBL();
                Invited cc = new Invited();
                EventBL ebl = new EventBL();
                var lists = ebl.GetAllEvent();
                var list = edbl.GetAllEvent();
                string[] staffmenu = { "Hòm Thư", "Đăng xuất." };
                if (list == null)
                    {
                        Console.Write("=================>> Bạn Không Có Thư <<");
                    }
                    else 
                    {
                        Console.Write("=================>> Bạn Có Thư <<");
                    }
                do
                {
                    int staff = Menu("Chào Bạn", staffmenu);
                    switch (staff)
                    {
                        case 1:
                            Console.Clear();
                            string lin = ("\n|=======================================================================================================|");
                            Console.WriteLine("\t\tDanh sách lời mời sự kiện");
                            Console.Write("|  {0,-5}\t|  {1,-5}\t|", "Mã Sự Kiện", "Tình Trạng Tham Gia");
                            Console.WriteLine(lin);
                            foreach (var Event in list)
                            {
                                if (ubl.Login(un, pw).User_ID == Event.EventDetails_UserID)
                                {
                                    
                                     Console.WriteLine("|  {0,-5}\t|  {1,-5}\t|", Event.EventDetails_EventID, Event.Status);
                                    
                                }
                            }
                            Console.Write("- Nhập Mã Sự Kiện để xem chi tiết sự kiện hoặc bấm 0 để thoát: ");
                            int ss = Convert.ToInt32(Console.ReadLine());
                            cc.EventDetails_EventID = ss;
                            switch (ss)
                            {
                                case 0:
                                    continue;

                                default:
                                    break;
                            }


                            Console.WriteLine("\n>>(Danh sách sự kiện)<<");
                            foreach (var Event in lists)
                            {
                                if (ss == Event.ID_Event)
                                    Console.WriteLine("\n- Tên Sự Kiện: {0} \n- Địa chỉ Sự Kiện: {1} \n- Mô Tả: {2} \n- Ngày Giờ: {3}", Event.Name_Event, Event.Address_Event, Event.Description, Event.Time);
                            }

                            Console.Write("- Bạn có muốn tham gia sự kiện không? (Gõ 1 để tham gia/ Gõ 0 để từ chối)?: ");
                            string choices = Console.ReadLine();
                            switch (choices)
                            {
                                case "1":
                                    edbl.UpdateEventDetailss(cc);
                                    break;
                                case "0":
                                    edbl.UpdateEventDetails(cc);
                                    break;
                                default:
                                    break;
                            }
                            Console.Write("Press Anything To ComeBack................... ");
                            Console.ReadLine();
                            Console.Clear();

                            break;
                        case 2:
                            Console.Clear();
                            MenuChoice();
                            break;
                    }
                }
                while (true);

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
            EventDetailsBL edbl = new EventDetailsBL();
            var list = ebl.GetAllEvent();
            var lists = ubl.GetAllUser();
            var listss = edbl.GetAllEvent();
            Console.Clear();
            string[] managermenu = { "Tạo Sự Kiện", "Gửi thư mời ", "Xem danh sách người dùng", "Xem danh sách sự kiện", "Reset", "Đăng xuất" };
            do
            {
                short mana = Menu("Bắt Đầu Quản Lý Sự Kiện", managermenu);
                switch (mana)
                {

                    case 1:
                        Event c = new Event();
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("======== Làm mới sự kiện ========");
                            if (c.Name_Event == null)
                            {
                                Console.Write("- Nhập tên sự kiện : ");
                                string p = Console.ReadLine();
                                if (p == "") continue;

                                c.Name_Event = p;
                            }
                            else { Console.WriteLine("- Nhập tên sự kiện : " + c.Name_Event); }

                            if (c.Address_Event == null)
                            {
                                Console.Write("- Nhập địa chỉ sự kiện : ");
                                string p = Console.ReadLine();
                                if (p == "") continue;

                                c.Address_Event = p;
                            }
                            else { Console.WriteLine("- Nhập địa chỉ sự kiện : " + c.Address_Event); }

                            if (c.Description == null)
                            {
                                Console.Write("- Nhập mô tả sự kiện : ");
                                string p = Console.ReadLine();
                                if (p == "") continue;

                                c.Description = p;
                            }
                            else { Console.WriteLine("- Nhập mô tả sự kiện : " + c.Description); }

                            if (c.Time == null)
                            {
                                Console.Write("- Thời gian sự kiện diễn ra : ");
                                string p = Console.ReadLine();
                                if (p == "") continue;

                                c.Time = p;
                            }
                            else { Console.WriteLine("- Thời gian sự kiện diễn ra : " + c.Time); }
                            break;
                        }
                        Console.WriteLine("- Event ID: " + ebl.AddEvent(c));
                        Console.Write("- Tạo sự kiện thành công! ");

                        Console.ReadLine();
                        break;



                    case 2:

                        Invited cc = new Invited();


                        while (true)
                        {
                            string lins = ("\n|=======================================================================================================|");
                            Console.WriteLine("\t\tDanh sách sự kiện");
                            Console.Write("|  {0,-5}\t|  {1,-5}\t|  {2,-15}\t|  {3,-100}\t|  {4,-20} |", "Mã Sự Kiện", "Tên Sự Kiện", "Địa chỉ Sự Kiện", "Mô Tả", "Ngày Giờ");
                            Console.WriteLine(lins);
                            foreach (var Event in list)
                            {
                                Console.WriteLine("|  {0,-5}\t|  {1,-5}\t|  {2,-15}\t|  {3,-100}\t|  {4,-20} |", Event.ID_Event, Event.Name_Event, Event.Address_Event, Event.Description, Event.Time);
                            }

                            if (cc.EventDetails_EventID == null)
                            {
                                Console.Write("- Nhập mã sự kiện: ");
                                int p = Convert.ToInt32(Console.ReadLine());


                                cc.EventDetails_EventID = p;
                            }
                            else { Console.WriteLine("- Nhập mã sự kiện : " + cc.EventDetails_EventID); }

                            string liness = ("\n|=======================================================================================|");
                            Console.WriteLine("\t\tDanh Sách Người Dùng\t");
                            Console.Write("|  {0,-15}\t|  {1,-15}\t|  {2,-5}\t|  {3,-20}\t|  {4,-20}\t|", "Mã Người Dùng", "Họ và Tên", "Tuổi", "Nghành Nghề", "Số Điện Thoại");
                            Console.WriteLine(liness);
                            foreach (var User in lists)
                            {
                                Console.WriteLine("|  {0,-15}\t|  {1,-15}\t|  {2,-5}\t|  {3,-20}\t|  {4,-20}\t|", User.User_ID, User.Name, User.Age, User.Job, User.Phone);

                            }

                            if (cc.EventDetails_UserID == null)
                            {
                                Console.Write("- Nhập mã người dùng : ");
                                int p = Convert.ToInt32(Console.ReadLine());


                                cc.EventDetails_UserID = p;
                            }
                            else { Console.WriteLine("- Nhập mã người dùng : " + cc.EventDetails_UserID); }

                            if (cc.Status == null)
                            {
                                Console.Write("- Tình Trạng Tham Gia : ");
                                string p = Console.ReadLine();


                                cc.Status = p;
                            }
                            else { Console.WriteLine("- Tình Trạng Tham Gia : " + cc.Status); }
                            edbl.AddEventDetails(cc);
                            break;
                        }
                        Console.WriteLine("- Gửi Thư Thành Công!");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        string line = ("\n|=======================================================================================|");
                        Console.WriteLine("\t\tDanh Sách Người Dùng\t");
                        Console.Write("|  {0,-15}\t|  {1,-15}\t|  {2,-5}\t|  {3,-20}\t|  {4,-20}\t|", "Mã Người Dùng", "Họ và Tên", "Tuổi", "Nghành Nghề", "Số Điện Thoại");
                        Console.WriteLine(line);
                        foreach (var User in lists)
                        {
                            Console.WriteLine("|  {0,-15}\t|  {1,-15}\t|  {2,-5}\t|  {3,-20}\t|  {4,-20}\t|", User.User_ID, User.Name, User.Age, User.Job, User.Phone);

                        }
                        Console.Write("Press Anything To ComeBack................... ");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.Clear();
                        string lin = ("\n|=======================================================================================================|");
                        Console.WriteLine("\t\tDanh sách sự kiện");
                        Console.Write("|  {0,-5}\t|  {1,-5}\t|  {2,-15}\t|  {3,-30}\t|  {4,-20} |", "Mã Sự Kiện", "Tên Sự Kiện", "Địa chỉ Sự Kiện", "Mô Tả", "Ngày Giờ");
                        Console.WriteLine(lin);
                        foreach (var Event in list)
                        {
                            Console.WriteLine("|  {0,-5}\t|  {1,-5}\t|  {2,-15}\t|  {3,-100}\t|  {4,-20} |", Event.ID_Event, Event.Name_Event, Event.Address_Event, Event.Description, Event.Time);
                        }

                        Console.Write("- Nhập Mã Sự Kiện để xem khách mời tham dự sự kiện hoặc bấm 0 để thoát: ");
                        int ss = Convert.ToInt32(Console.ReadLine());
                        switch (ss)
                        {
                            case 0:
                                continue;

                            default: 
                                break;
                        }

                        Console.WriteLine("\t\tDanh sách lời mời sự kiện");
                        Console.Write("|  {0,-5}\t|  {1,-5}\t|", "Mã Người Dùng", "Tình Trạng Tham Gia");
                        Console.WriteLine(lin);
                        foreach (var Event in listss)
                        {
                            if (ss == Event.EventDetails_EventID)
                            Console.WriteLine("|  {0,-5}\t|  {1,-5}\t|", Event.EventDetails_UserID, Event.Status);

                        }
                        Console.Write("Press Anything To ComeBack................... ");
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.Clear();
                        {
                            menuManager(us);
                        }
                        break;
                    case 6:
                        Console.Clear();
                        MenuChoice();
                        break;
                }
            } while (true);
        }

        // public void menuStaff(User us)
        // {
        //     Console.Clear();
        //     Menus x = new Menus();
        //     EventDetailsBL edbl = new EventDetailsBL();
        //     UserBL ubl = new UserBL();
        //     var list = edbl.GetAllEvent();
        //     string[] staffmenu = { "Hòm Thư", "Đăng xuất." };
        //     do
        //     {
        //         int staff = Menu("Chào Bạn", staffmenu);
        //         switch (staff)
        //         {
        //             case 1:
        //                 Console.Clear();
        //                 string lin = ("\n|=======================================================================================================|");
        //                 Console.WriteLine("\t\tDanh sách lời mời sự kiện");
        //                 Console.Write("|  {0,-5}\t|  {1,-5}\t|", "Mã Sự Kiện", "Nội Dung");
        //                 Console.WriteLine(lin);
        //                 foreach (var Event in list)
        //                 {
        //                     if (Event.EventDetails_UserID == ubl.Login().User_ID)
        //                     Console.WriteLine("|  {0,-5}\t|  {1,-5}\t|", Event.EventDetails_EventID, Event.Status);
        //                 }
        //                 Console.Write("Press Anything To ComeBack................... ");
        //                 Console.ReadLine();
        //                 Console.Clear();

        //                 break;
        //             case 2:
        //                 Console.Clear();
        //                 MenuChoice();
        //                 break;
        //         }
        //     } 
        //     while (true);
        // }
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