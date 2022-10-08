using System;
using System.Collections.Generic;
using System.Text;

namespace btl_huy
{
    class Admin : Base
    {
        private String password;

        public void setPassword(String password)
        {
            this.password = password;
        }
        public String getPassword()
        {
            return this.password;
        }

    }
}
