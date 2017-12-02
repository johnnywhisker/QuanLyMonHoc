using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonHoc
{
    class Interface
    {
        public static void showAllSubject() {

            Console.Clear();
            Console.WriteLine("Danh Sach Mon Hoc : ");
            foreach (Subject subject in Database.subjects) {
                Dictionary<string, string> processDictionary = subject.getData();
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", processDictionary["name"],
                    processDictionary["code"],
                    processDictionary["credit"],
                    Convert.ToDateTime(processDictionary["startTime"]).ToShortDateString(),
                    Convert.ToDateTime(processDictionary["endTime"]).ToShortDateString(),
                    processDictionary["lectureName"]
                    );
            }
            Console.Write("Bam phim bat ki de ve man hinh chinh.");
            Console.ReadKey();
        }

        public static void findSubject()
        {

            Console.Clear();
            int ammout = 0;
            Console.Write("Nhap vao thong tin can tim cua mon hoc (Neu la ngay nhap MM/DD/YYYY): ");
            string input = Console.ReadLine();
            Console.WriteLine("Ket qua: ");
            foreach (Subject subject in Database.subjects) {
                if (subject.isMe(input)) {
                    ammout++;
                    Dictionary<string, string> processDictionary = subject.getData();
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", processDictionary["name"],
                    processDictionary["code"],
                    processDictionary["credit"],
                    Convert.ToDateTime(processDictionary["startTime"]).ToShortDateString(),
                    Convert.ToDateTime(processDictionary["endTime"]).ToShortDateString(),
                    processDictionary["lectureName"]
                    );
                }
            }
            if (ammout == 0) {
                Console.Clear();
                Console.WriteLine("Khong tim thay bat ki mon hoc nao phu hop voi dac diem: {0}", input);
            }
            Console.WriteLine("Bam phim bat ki de tro ve menu");
            Console.ReadKey();
        }

        public static void modifySubject()
        {
            Console.Clear();
            Dictionary<string, string> processDictionary = null;
            int index = -1;
            Console.Write("Nhap vao ma mon hoc can chinh sua: ");
            string input = Console.ReadLine();
            foreach (Subject subject in Database.subjects) {
                Dictionary<string, string> tempDic = subject.getData();
                if (tempDic["code"] == input)
                {
                    index = Database.subjects.IndexOf(subject);
                    processDictionary = tempDic;
                    break;
                }
            }

            if (processDictionary != null)
            {
                Console.WriteLine("Thong tin: ");
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", processDictionary["name"],
                   processDictionary["code"],
                   processDictionary["credit"],
                   Convert.ToDateTime(processDictionary["startTime"]).ToShortDateString(),
                   Convert.ToDateTime(processDictionary["endTime"]).ToShortDateString(),
                   processDictionary["lectureName"]
                   );
                Edit:
                try
                {
                    Console.Write("Nhap vao ten mon hoc [{0}]: ", processDictionary["name"]);
                    string name = Console.ReadLine();
                    Console.Write("Nhap vao ma mon hoc [{0}]: ", processDictionary["code"]);
                    string code = Console.ReadLine();
                    Console.Write("Nhap vao tin chi [{0}]: ", processDictionary["credit"]);
                    string tempCredit = Console.ReadLine();
                    Console.Write("Nhap vao ngay bat dau mon hoc [{0}]: ", processDictionary["startTime"]);
                    string tempStartDate = Console.ReadLine();
                    if (tempStartDate != "")
                    {
                        DateTime startTime = Convert.ToDateTime(tempStartDate);
                        tempStartDate = startTime.ToShortDateString();
                    }
                    Console.Write("Nhap vao ngay ket thuc mon hoc [{0}]: ", processDictionary["endTime"]);
                    string tempEndTime = Console.ReadLine();
                    if (tempEndTime != "")
                    {
                        DateTime endTime = Convert.ToDateTime(tempEndTime);
                        tempEndTime = endTime.ToShortDateString();
                    }
                    Console.Write("Nhap vao ten giang vien [{0}]: ", processDictionary["lectureName"]);
                    string lectureName = Console.ReadLine();
                    string[] modificationInfo = { name, code, tempCredit, tempStartDate, tempEndTime, lectureName };
                    Database.subjects[index].changeData(modificationInfo);
                }
                catch
                {
                    Console.Write("Gia tri khong hop le.Bam phim bat ki de nhap lai.");
                    Console.ReadKey();
                    Console.Clear();
                    goto Edit;
                }
            }
            else {
                Console.Clear();
                Console.WriteLine("Khong tim thay mon hoc co ma so: {0}. Bam phim bat ki de tro ve menu.", input);
                Console.ReadKey();                
            }
        }
        public static void deleteSubject()
        {
            Console.Clear();
            Dictionary<string, string> processDictionary = null;
            int index = -1;
            Console.Write("Nhap vao ma mon hoc can xoa: ");
            string input = Console.ReadLine();
            foreach (Subject subject in Database.subjects)
            {
                Dictionary<string, string> tempDic = subject.getData();
                if (tempDic["code"] == input)
                {
                    index = Database.subjects.IndexOf(subject);
                    processDictionary = tempDic;
                    break;
                }
            }

            if (processDictionary != null)
            {
                Console.WriteLine("Thong tin: ");
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", processDictionary["name"],
                   processDictionary["code"],
                   processDictionary["credit"],
                   Convert.ToDateTime(processDictionary["startTime"]).ToShortDateString(),
                   Convert.ToDateTime(processDictionary["endTime"]).ToShortDateString(),
                   processDictionary["lectureName"]
                   );
                Confirmation:
                Console.Write("Ban co chac chan muon xoa mon hoc (y/n): ");
                string answer = Console.ReadLine();
                if (answer != "y" && answer != "n")
                {
                    Console.Clear();
                    Console.WriteLine("Khong hop le. Bam phim bat ki de nhap lai.");
                    Console.ReadKey();
                    Console.Clear();
                    goto Confirmation;
                }
                else
                {
                    if (answer == "y")
                    {
                        Database.subjects.RemoveAt(index);
                        Console.Clear();
                        Console.WriteLine("Xoa mon hoc thanh cong. Bam phim bat ki de tro ve menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Huy xoa mon hoc thanh cong. Bam phim bat ki de tro ve menu.");
                        Console.ReadKey();
                    }
                }
            } else {
                Console.Clear();
                Console.WriteLine("Khong tim thay mon hoc co ma so: {0}. Bam phim bat ki de tro ve menu.", input);
                Console.ReadKey();
            }
        }
        public static void printMenu() { 
            Begin:
            Console.Clear();
            Console.Write("QUAN LY MON HOC \n\n1. Xem tat ca mon hoc \n2. Tim mon hoc\n3.Sua mon hoc\n4.Xoa mon hoc\n0.Thoat\nLUA CHON: ");
            
                int choice = int.Parse(Console.ReadLine());
                if (choice > -1 && choice < 5)
                {
                    switch (choice) {
                        case 0:
                            Environment.Exit(69);
                            break;
                        case 1:
                            showAllSubject();
                            break;
                        case 2:
                            findSubject();
                            break;
                        case 3:
                            modifySubject();
                            break;
                        case 4:
                            deleteSubject();
                            break;
                    }
                }
                else {                
                Console.Clear();
                Console.WriteLine("Lua chon khong hop le. Vui long nhap so tu 0 den 4. Bam phim bat ki de thu lai");
                Console.ReadKey();                
            }
            goto Begin;
        }
    }
}
