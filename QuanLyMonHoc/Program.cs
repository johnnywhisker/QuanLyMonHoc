using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonHoc
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject("OOAD", "DV01", 4, DateTime.Now, DateTime.Now.AddDays(3), "Thanh");
            Subject sub2 = new Subject("Nhap mon lap trinh", "DV02", 4, DateTime.Now.AddDays(2), DateTime.Now.AddDays(5), "Son");
            Subject sub3 = new Subject("Lap trinh huong doi tuong", "DV03", 4, DateTime.Now, DateTime.Now.AddDays(4), "Son");
            Database.subjects.Add(sub1);
            Database.subjects.Add(sub2);
            Database.subjects.Add(sub3);
            Interface.printMenu();
        }
    }
}
