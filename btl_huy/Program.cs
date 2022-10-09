using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace btl_huy
{
    class Program
    {
       static List<Student> studentList = new List<Student>();
        static List<Admin> adminList = new List<Admin>();
        
       

        static void Main(string[] args)
        {
           
            readFromFile();
            Admin admin = new Admin();
            admin.setId(1);
            admin.setName("huy");
            admin.setPassword("huy");
            adminList.Add(admin);
            bool checkLogin = true;
            do {
                bool resuit = dispayLogin();
                if(resuit == true)
                {
                    checkLogin = false;
                }
                else
                {
                    Console.WriteLine("sai tên đăng nhập or mật khẩu");
                }
            } while (checkLogin);
            


            do {
                dispayMenu();
                int number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        //thêm sinh viên
                        Console.WriteLine("số sinh viên cần nhập ");
                        int sum  = int.Parse(Console.ReadLine());
                        for( int i =0; i< sum; i++)
                        {
                            insertNewStudent();

                        }
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
                    case 4:
                        Console.WriteLine("nhập mã sinh viên cần sửa điểm ");
                        int id = int.Parse(Console.ReadLine());
                        updatePointStudent(id);
                            break;
                    case 5:
                        List<Student> listSort = sortStudentByPoint();
                        foreach (Student student in listSort)
                        {
                            dispayInforStudent(student);
                        }

                        break;
                    case 6:
                        getAllStudennt();
                        break;
                    case 7:
                        System.Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("lưa chọn từ 1->7");
                        break;
                }

            } while (true);
        }


        public static bool dispayLogin()
        {

            Console.WriteLine("nhập username");
            String username = Console.ReadLine();
            Console.WriteLine("nhập password");
            String password = Console.ReadLine();
            foreach(Admin admin in adminList)
            {
                if(admin.getName().Equals(username) && admin.getPassword().Equals(password))
                {
                    return true;
                }
            }
            return false;
        }


        public static void dispayMenu()
        {
            Console.WriteLine("*******************Menu*******************");
            Console.WriteLine("1.thêm mới sinh viên");
            Console.WriteLine("2.tìm kiếm sinh viên theo tên ");
            Console.WriteLine("3.nhập điểm cho sinh viên theo tên");
            Console.WriteLine("4.update điểm viên theo mã ");
            Console.WriteLine("5.sắp xếp sinh viên theo điểm");
            Console.WriteLine("6.hiện thị danh sách sinh viên");
            Console.WriteLine("7.Thoát");
            Console.WriteLine("nhập sự lựa chọn của bạn");
        }

        public static void dispayInforStudent(Student student)
        {
            Console.WriteLine("*******************Thông tin Sinh viên*******************");
            Console.WriteLine("1.Mã sinh viên : "+student.getId());
            Console.WriteLine("2.Tên sinh viên"+student.getName());
            Console.WriteLine("3.Tuổi sinh viên"+student.getDateOfBirth());
            Console.WriteLine("4.Điểm sinh viên" + student.getPoint());

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
            Console.WriteLine("nhập điểm :");
            student.setPoit(float.Parse(Console.ReadLine()));
            studentList.Add(student);
            writeToFile(student);
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
        public static void updatePointStudent(int id)
        {
            //Student student = findById(id);
            Console.WriteLine("nhập điểm cần sửa");
                float newPoint = float.Parse(Console.ReadLine());
            foreach(Student student in studentList)
            {
                if(student.getId() == id)
                {
                    student.setPoit(newPoint);
                }

            }

        }

        public static void deleteStudent()
        {

        }
        public static List<Student> sortStudentByPoint()
        {
           List<Student> listAfterSort = studentList.OrderBy(x => x.getPoint()).ToList();
            return listAfterSort;

        }

        public static void getAllStudennt()
        {
            foreach(Student student in studentList)
            {
                dispayInforStudent(student);
            }
        }


        public static Student findById(int id)
        {
            foreach(Student student in studentList)
            {
                if(student.getId() == id)
                {
                    return student;
                }
            }
            return null;
        }
        public static void readFromFile()
        {
            List<Student> listStudentInFile = new List<Student>();
                try{

                using (StreamReader sr = new StreamReader("C:/Users/dmx/source/repos/btl_huy/qlsv.txt"))
                {

                
                    string line;
                    int step = 0;

                while((line = sr.ReadLine()) != null)
                    {
                        if (step != 0)
                        {
                            Student student = new Student();
                            String[] data = line.Split("                    ");
                            student.setId(int.Parse(data[0]));
                            student.setName(data[1]);
                            student.setDateOfBirth(int.Parse(data[2]));
                            student.setPoit(float.Parse(data[3]));

                            listStudentInFile.Add(student);
                            //Console.Write(student.getId());
                            //Console.Write("                ");
                            //Console.Write(student.getName());
                            //Console.Write("                ");
                            //Console.Write(student.getDateOfBirth());
                            //Console.Write("                ");
                            //Console.Write(student.getPoint());
                            //Console.Write("                ");
                            //Console.WriteLine();
                        }
                        
                        step++;
                    }
                
                }
                studentList = listStudentInFile;
              
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void writeToFile(Student student)
        {
            try
            {
               

                using (StreamWriter sw = new StreamWriter("C:/Users/dmx/source/repos/btl_huy/qlsv.txt",true))
                {
                    
                    sw.Write((student.getId()).ToString());
                    sw.Write("                    ");
                    sw.Write(student.getName());
                    sw.Write("                    ");
                    sw.Write((student.getDateOfBirth()).ToString());
                    sw.Write("                    ");
                    sw.Write((student.getPoint()).ToString());
                    sw.WriteLine();

                }
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
