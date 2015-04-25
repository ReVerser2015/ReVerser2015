using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReVerser2015.WebAPI.MyMail
{
    public class MyMailPerson
    {
        public string FirstName { get; set; }

        public MyMailPerson(string name)
        {
            this.FirstName = name;
        }
    }
}
