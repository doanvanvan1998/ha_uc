using System;
using System.Collections.Generic;
using System.Text;

namespace btl_huy
{
    class Student : Base
    {

        private int date_of_birth;
        
        public void setDateOfBirth(int date_of_birth)
        {
            this.date_of_birth = date_of_birth;
        }

        public int getDateOfBirth()
        {
            return this.date_of_birth;
        }

        public int tinhSoTuoi(int date_of_birth)
        {
            int age = 2022 - date_of_birth;


            return age;
        }


    }
}
