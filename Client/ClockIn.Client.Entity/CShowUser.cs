using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.Entity
{
    public class CShowUser
    {
        private int user_id;
        private string user_name;
        private string user_role;
        private string user_ip_address;
        private string user_mac;
        private string user_pwd;
        private string user_login_name;
        private bool is_admin;
        private char tag;
        private Brush bcolor;

        public int User_id { get => user_id; set => user_id = value; }
        public string User_name { get => user_name; set => user_name = value; }
        public string User_ip_address { get => user_ip_address; set => user_ip_address = value; }
        public string User_mac { get => user_mac; set => user_mac = value; }
        public string User_pwd { get => user_pwd; set => user_pwd = value; }
        public string User_login_name { get => user_login_name; set => user_login_name = value; }
        public string User_role { get => user_role; set => user_role = value; }
        public bool Is_admin { get => is_admin; set => is_admin = value; }
        public char Tag { get => tag; set => tag = value; }
        public Brush bColor { get => bcolor; set => bcolor = value; }

        public CShowUser() { }
    }
}
