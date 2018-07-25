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
            Console.Write("Tài Khoản: ");
            string un = Console.ReadLine();
            Console.Write("Mật Khẩu: ");
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
                Console.Write("Tài Khoản: ");
                un = Console.ReadLine();
                Console.Write("Mật Khẩu: ");
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
                Console.Write("Tài Khoản: ");
                un = Console.ReadLine();
                Console.Write("Mật Khẩu: ");
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
                    Console.Write("Tài Khoản: ");
                    un = Console.ReadLine();
                    Console.Write("Mật Khẩu: ");
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
                int i = 0;
                foreach (var get in list)
                {
                    if (get.EventDetails_UserID == 2)
                    {
                        i++;
                    }
                }

                // Console.Write("=================>> Bạn có {0} lời mời tham gia sự kiện <<", Convert.ToString(i));
                // string[] staffmenu = { "Lời Mời Sự Kiện", "Đăng xuất" };

                do
                {
                    Console.Clear();
                    Console.WriteLine(row1);
                    Console.WriteLine("Chào Bạn");
                    Console.WriteLine(row2);
                    Console.WriteLine("1. Lời Mời Sự Kiện({0})", i);
                    Console.WriteLine("2. Đăng Xuất");
                    Console.WriteLine(row2);
                    Console.Write("Chọn :");
                    var staff = Console.ReadLine();
                    if (staff == " ")
                    {
                        Console.ReadLine();
                    }
                    switch (staff)
                    {
                        case "1":
                            ViewInvited(un, pw);
                            // Console.Clear();
                            // string lin = ("\n|====================================================================================================================================================================|");
                            // Console.WriteLine("\t\tDanh sách lời mời sự kiện");
                            // Console.Write("| {0,-5}  | {1,-35}  | {2,-15}  | {3,-51}  | {4,-15}  | {5,-20}  |", "No", "Tên sự kiện", "Địa chỉ", "Mô tả", "Thời gian", "Tình Trạng Tham Gia");
                            // Console.WriteLine(lin);
                            // foreach (var Event in list)
                            // {
                            //     if (ubl.Login(un, pw).User_ID == Convert.ToInt32(Event.EventDetails_UserID))
                            //     {

                            //         Console.WriteLine("| {0,-5}  | {1,-35}  | {2,-15}  | {3,-51}  | {4,-15}  | {5,-20}  |", Event.EventDetails_EventID, Event.events.Name_Event, Event.events.Address_Event, Event.events.Description, Event.events.Time, Event.Status);

                            //     }
                            // }
                            // cc.EventDetails_UserID = ubl.Login(un, pw).User_ID;
                            // Console.Write("- Chọn Mã sự kiện để tham dự hoặc bấm 0 để thoát: ");
                            // int ss = Convert.ToInt32(Console.ReadLine());

                            // switch (ss)
                            // {
                            //     case 0:
                            //         continue;

                            //     default:
                            //         // Console.WriteLine("Bạn Đã Nhập sai! Vui lòng nhập lại!");
                            //         break;
                            // }
                            // Console.Write("- Bạn có muốn tham gia sự kiện không?");
                            // Console.Write("\n  1. Tham Gia");
                            // Console.Write("\n  2. Không Tham Gia");
                            // Console.Write("\n  3. Sẽ Tham Gia");
                            // Console.Write("\n  0. Thoát");
                            // Console.Write("\n- Chọn: ");
                            // string choices = Console.ReadLine();
                            // switch (choices)
                            // {
                            //     case "1":
                            //         edbl.UpdateEventDetailss(cc);
                            //         Console.Write("- Bạn Đã Tham Gia Sự Kiện!");
                            //         break;
                            //     case "2":
                            //         edbl.UpdateEventDetails(cc);
                            //         Console.Write("- Bạn Đã Từ Chối Sự Kiện!");
                            //         break;
                            //     case "3":
                            //         edbl.UpdateEventDetailsss(cc);
                            //         Console.Write("- Bạn Sẽ Tham Gia Sự Kiện!");
                            //         break;
                            //     case "0":
                            //         break;
                            //     default:
                            //         // Console.WriteLine("Bạn Đã Nhập sai! Vui lòng nhập lại!");
                            //         break;
                            // }
                            // Console.Write("\n- Nhập Phím Bất Kỳ Để Trờ Lại.......................................");
                            // Console.ReadKey();


                            break;
                        case "2":
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
            string[] managermenu = { "Tạo Sự Kiện", "Gửi thư mời ", "Xem danh sách người dùng", "Xem danh sách sự kiện", "Đăng xuất" };
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
                        Console.Write(" Bạn có muốn tạo sự kiện này không? (C/K)");

                        string choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "C":
                                Console.WriteLine("- Event ID: " + ebl.AddEvent(c));
                                Console.Write("- Tạo sự kiện thành công! ");
                                break;
                            case "c":
                                Console.WriteLine("- Event ID: " + ebl.AddEvent(c));
                                Console.Write("- Tạo sự kiện thành công! ");
                                break;
                            case "K":

                                break;
                            case "k":

                                break;
                            default:


                                break;
                        }

                        Console.Write("\n - Nhập Phím Bất Kì Để Trờ Lại!................... ");
                        Console.ReadLine();
                        break;



                    case 2:

                        Invited cc = new Invited();


                        while (true)
                        {
                            string lins = ("\n|=====================================================================================================================================================================|\n");
                            Console.WriteLine("\t\tDanh sách sự kiện");
                            Console.Write("|  {0,-5}  | {1,-35}  | {2,-39}  | {3,-47}  | {4,-15} |", "Mã Sự Kiện", "Tên Sự Kiện", "Địa chỉ Sự Kiện", "Mô Tả", "Ngày Giờ");
                            Console.Write(lins);
                            foreach (var Event in list)
                            {
                                Console.WriteLine("|  {0,-5}       | {1,-35}  | {2,-39}  | {3,-47}  | {4,-15} |", Event.ID_Event, Event.Name_Event, Event.Address_Event, Event.Description, Event.Time);
                            }
                            if (cc.EventDetails_EventID == null)
                            {
                                Console.Write("- Nhập mã sự kiện: ");
                                int p = Convert.ToInt32(Console.ReadLine());


                                cc.EventDetails_EventID = p;
                            }
                            else { Console.WriteLine("- Nhập mã sự kiện : " + cc.EventDetails_EventID); }
                            string liness = ("\n|===============================================================================================================|");
                            Console.WriteLine("\t\tDanh Sách Người Dùng\t");
                            Console.Write("|  {0,-15}\t|  {1,-15}\t|  {2,-5}\t|  {3,-20}\t|  {4,-20}\t|", "Mã Người Dùng", "Họ và Tên", "Tuổi", "Nghành Nghề", "Số Điện Thoại");
                            Console.WriteLine(liness);
                            foreach (var User in lists)
                            {
                                Console.WriteLine("|  {0,-15}\t|  {1,-15}\t|  {2,-5}\t|  {3,-20}\t|  {4,-20}\t|", User.User_ID, User.Name, User.Age, User.Job, User.Phone);

                            }

                            Console.Write("- Mời Người Dùng?");
                            Console.Write("\n  1. Mời Từng Người Dùng");
                            Console.Write("\n  2. Mời Tất Cả Người Dùng");
                            Console.Write("\n  0. Thoát");
                            Console.Write("\n- Chọn: ");
                            string choices = Console.ReadLine();
                            switch (choices)
                            {
                                case "1":
                                    if (cc.EventDetails_UserID == null)
                                    {
                                        Console.Write("- Nhập mã người dùng : ");
                                        var p = Convert.ToInt32(Console.ReadLine());


                                        cc.EventDetails_UserID = p;
                                    }
                                    else { Console.WriteLine("- Nhập mã người dùng : " + cc.EventDetails_UserID); }


                                    edbl.AddEventDetails(cc);
                                    Console.WriteLine("- Gửi Lời Mời Thành Công!");
                                    break;
                                case "2":
                                    edbl.AddEventDetailss(cc);
                                    Console.WriteLine("- Gửi Lời Mời Thành Công!");
                                    break;
                                case "0":
                                    break;
                                default:
                                    // Console.WriteLine("Bạn Đã Nhập sai! Vui lòng nhập lại!");
                                    break;
                            }
                            break;
                        }

                        Console.Write("- Nhập Phím Bất Kì Để Trờ Lại!................... ");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        string line = ("\n|===============================================================================================================|");
                        Console.WriteLine("\t\tDanh Sách Người Dùng\t");
                        Console.Write("|  {0,-15}\t|  {1,-15}\t|  {2,-5}\t|  {3,-20}\t|  {4,-20}\t|", "Mã Người Dùng", "Họ và Tên", "Tuổi", "Nghành Nghề", "Số Điện Thoại");
                        Console.WriteLine(line);
                        foreach (var User in lists)
                        {
                            Console.WriteLine("|  {0,-15}\t|  {1,-15}\t|  {2,-5}\t|  {3,-20}\t|  {4,-20}\t|", User.User_ID, User.Name, User.Age, User.Job, User.Phone);

                        }
                        Console.Write("- Nhập Phím Bất Kì Để Trờ Lại!................... ");
                        Console.ReadLine();
                        break;

                    case 4:
                        ViewEvent();
                        break;


                    case 5:
                        Console.Clear();
                        MenuChoice();
                        break;
                }
            } while (true);
        }

        public void ViewEvent()
        {
            Menus x = new Menus();
            UserBL ubl = new UserBL();
            EventBL ebl = new EventBL();
            EventDetailsBL edbl = new EventDetailsBL();
            var list = ebl.GetAllEvent();
            var lists = ubl.GetAllUser();
            var listss = edbl.GetAllEvent();
            Console.Clear();
            string lin = ("\n|=====================================================================================================================================================================|\n");
            Console.WriteLine("\t\tDanh sách sự kiện");
            Console.Write("|  {0,-5}  | {1,-35}  | {2,-39}  | {3,-48}  | {4,-15}|", "Mã Sự Kiện", "Tên Sự Kiện", "Địa chỉ Sự Kiện", "Mô Tả", "Ngày Giờ");
            Console.Write(lin);
            foreach (var Event in list)
            {
                Console.WriteLine("|  {0,-5}       | {1,-35}  | {2,-39}  | {3,-48}  | {4,-15}|", Event.ID_Event, Event.Name_Event, Event.Address_Event, Event.Description, Event.Time);
            }

            Console.Write("- Nhập Mã Sự Kiện để xem khách mời tham dự hoặc bấm 0 để thoát: ");
            int ss = Convert.ToInt32(Console.ReadLine());
            switch (ss)
            {
                case 0:
                    break;

                default:
                    break;
            }

            Console.WriteLine("\t\tDanh sách lời mời sự kiện");
            Console.Write("|  {0,-5}  |  {1,-25}  | {2,-15}  | {3,-25}  | {4,-25}  |", "No", "Tên Khách Mời", "Số Điện Thoại", "Email", "Tình Trạng Tham Gia");
            Console.WriteLine("\n|====================================================================================================================|");
            foreach (var Event in listss)
            {
                if (ss == Event.EventDetails_EventID)
                    Console.WriteLine("|  {0,-5}  |  {1,-25}  | {2,-15}  | {3,-25}  | {4,-25}  |", Event.EventDetails_UserID, Event.users.Name, Event.users.Phone, Event.users.Email, Event.Status);

            }
            Console.Write("- Nhập Phím Bất Kì Để Trờ Lại!................... ");
            Console.ReadLine();
        }

        public void ViewInvited(string un, string pw)
        {
            Console.Clear();
            Menus x = new Menus();
            EventDetailsBL edbl = new EventDetailsBL();
            Invited cc = new Invited();
            EventBL ebl = new EventBL();
            UserBL ubl = new UserBL();
            var lists = ebl.GetAllEvent();
            var list = edbl.GetAllEvent();
            Console.Clear();
            string lin = ("\n|====================================================================================================================================================================|");
            Console.WriteLine("\t\tDanh sách lời mời sự kiện");
            Console.Write("| {0,-5}  | {1,-35}  | {2,-15}  | {3,-51}  | {4,-15}  | {5,-20}  |", "No", "Tên sự kiện", "Địa chỉ", "Mô tả", "Thời gian", "Tình Trạng Tham Gia");
            Console.WriteLine(lin);
            foreach (var Event in list)
            {
                if (ubl.Login(un, pw).User_ID == Convert.ToInt32(Event.EventDetails_UserID))
                {

                    Console.WriteLine("| {0,-5}  | {1,-35}  | {2,-15}  | {3,-51}  | {4,-15}  | {5,-20}  |", Event.EventDetails_EventID, Event.events.Name_Event, Event.events.Address_Event, Event.events.Description, Event.events.Time, Event.Status);

                }
            }
            cc.EventDetails_UserID = ubl.Login(un, pw).User_ID;
            Console.Write("- Chọn Mã sự kiện để tham dự hoặc bấm 0 để thoát: ");
            int ss = Convert.ToInt32(Console.ReadLine());
            cc.EventDetails_EventID = ss;
            switch (ss)
            {
                case 0:
                    break; ;

                default:
                    // Console.WriteLine("Bạn Đã Nhập sai! Vui lòng nhập lại!");
                    break;
            }
            Console.Write("- Bạn có muốn tham gia sự kiện không?");
            Console.Write("\n  1. Tham Gia");
            Console.Write("\n  2. Không Tham Gia");
            Console.Write("\n  3. Sẽ Tham Gia");
            Console.Write("\n  0. Thoát");
            Console.Write("\n- Chọn: ");
            string choices = Console.ReadLine();
            switch (choices)
            {
                case "1":
                    edbl.UpdateEventDetailss(cc);
                    Console.Write("- Bạn Đã Tham Gia Sự Kiện!");
                    break;
                case "2":
                    edbl.UpdateEventDetails(cc);
                    Console.Write("- Bạn Đã Từ Chối Sự Kiện!");
                    break;
                case "3":
                    edbl.UpdateEventDetailsss(cc);
                    Console.Write("- Bạn Sẽ Tham Gia Sự Kiện!");
                    break;
                case "0":
                    break;
                default:
                    // Console.WriteLine("Bạn Đã Nhập sai! Vui lòng nhập lại!");
                    break;
            }
            Console.Write("\n- Nhập Phím Bất Kỳ Để Trờ Lại.......................................");
            Console.ReadKey();
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