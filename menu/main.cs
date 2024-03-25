using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu;

class Start
{
    static void Main()
    {
        // Bспользования класса MenuMaster
        List<string> menuItems = new List<string> { "Матча", "Латте", "Смузи", "Джин", "Эскимо", "Шаурма", "Пельмени", "Шашлык" };
        int itemsPerPage = 1;

        MenuMaster menuMaster = new MenuMaster(menuItems, itemsPerPage);

    }
}
