using System;
using System.Collections;
using System.Collections.Generic;

namespace btl_huy
{
    class Program
    {
       static List<Student> studentList = new List<Student>();
        static void Main(string[] args)
        {
            do {
                dispayMenu();
                int number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        //thêm sinh viên
                        insertNewStudent();
                        break;
                           
                    case 2:
                        // tìm kiếm sinh viên theo tên
                        Console.WriteLine("nhập vào tên sinh viên cần tìm kiếm");
                        String name = Console.ReadLine();
                        List<Student> listNew  = findByName(name);
                        foreach(Student student in listNew)
                        {
                            dispayInforStudent(student);
                        }
                       
                        break;
                        case 3:
                        break;
                    case 6:
                        getAllStudennt();
                        break;
                    default:
                        Console.WriteLine("lưa chọn từ 1->7");
                        break;
                }

            } while (true);
            
            Console.ReadKey();

        }





        public static void dispayMenu()
        {
            Console.WriteLine("*******************Menu*******************");
            Console.WriteLine("1.thêm mới sinh viên");
            Console.WriteLine("2.tìm kiếm sinh viên theo tên ");
            Console.WriteLine("3.nhập điểm cho sinh viên theo tên");
            Console.WriteLine("4.xóa sinh viên theo tên");
            Console.WriteLine("5.sắp xếp sinh viên theo điểm");
            Console.WriteLine("6.hiện thị danh sách sinh viên");
            Console.WriteLine("Thoát");
            Console.WriteLine("nhập sự lựa chọn của bạn");
        }

        public static void dispayInforStudent(Student student)
        {
            Console.WriteLine("*******************Thông tin Sinh viên*******************");
            Console.WriteLine("1.Mã sinh viên : "+student.getId());
            Console.WriteLine("2.Tên sinh viên"+student.getName());
            Console.WriteLine("3.Điểm sinh viên"+student.getDateOfBirth());
          
        }





        public static void insertNewStudent()
        {
            Student student = new Student();
            Console.WriteLine("nhập mã :");
            student.setId(int.Parse(Console.ReadLine()));
            Console.WriteLine("nhập name:");
            student.setName(Console.ReadLine());
            Console.WriteLine("nhập năm sinh:");
            student.setDateOfBirth(int.Parse(Console.ReadLine()));
            studentList.Add(student);
        }
        public static List<Student> findByName(String name)
        {
            List<Student> newList = new List<Student>();
            foreach(Student student in studentList)
            {
                if (student.getName().Equals(name))
                {
                    newList.Add(student);
                }
            }



            return newList;
        }
        public static void inputPointStudent()
        {

        }

        public static void deleteStudent()
        {

        }
        public static void sortStudentByPoint()
        {

        }

        public static void getAllStudennt()
        {
            foreach(Student student in studentList)
            {
                dispayInforStudent(student);
            }
        }


    }
}
