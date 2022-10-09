using System;
using System.Collections.Generic;
using System.Text;

namespace btl_huy
{
    class Student : Base
    {

        private int date_of_birth;
        private float point;
        
        public void setDateOfBirth(int date_of_birth)
        {
            this.date_of_birth = date_of_birth;
        }

        public int getDateOfBirth()
        {
            return this.date_of_birth;
        }
        public void setPoit(float point)
        {
            this.point = point;
        }
        public float getPoint()
        {
            return this.point;
        }
    }
}
