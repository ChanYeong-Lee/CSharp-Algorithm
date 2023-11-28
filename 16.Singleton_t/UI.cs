using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Singleton_t
{
    public class UI
    {
        private static UI instance;
        private UI()
        {

        }

        public static UI GetInstance()
        {
            if (instance == null)
            {
                instance = new UI();
            }
            return instance;
        }

        public void ShowList(List<Item> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0}. {1}, {2}, {3}", i+1, list[i].name, list[i].discription, list[i].price);
            }
        }
    }
}
