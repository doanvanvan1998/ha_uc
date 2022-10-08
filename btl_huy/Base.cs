using System;
using System.Collections.Generic;
using System.Text;

namespace btl_huy
{
    class Base
    {
        private int id;
        private String name;


        public void setId(int id)
        {
            this.id = id;
        }

        public void setName(String name)
        {
            this.name = name;

        }

        public int getId()
        {
            return this.id;

        }
        public String getName()
        {
            return this.name;
        }

    }
}
