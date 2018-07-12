using System;
using System.Text;
using System.Security;
using BL;
using System.Text.RegularExpressions;
using Persistence;
namespace EP_Console
{
    public class Program
    {

        static void Main(string[] args)
        {
            Menus m = new Menus();
            m.MenuChoice();
        }

    }
}
