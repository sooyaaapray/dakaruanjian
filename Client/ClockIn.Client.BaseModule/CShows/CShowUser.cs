using System;
using System.Windows.Media;

namespace ClockIn.Client.BaseModule.CShows
{
    public class CShowUser
    {
        private int user_id;
        private string user_name;
        private string user_role;
        private string user_ip_address;
        private string user_mac;
        private bool is_admin;
        private char tag;
        private Brush bcolor;

        public int User_id { get => user_id; set => user_id = value; }
        public string User_name { get => user_name; set => user_name = value; }
        public string User_ip_address { get => user_ip_address; set => user_ip_address = value; }
        public string User_mac { get => user_mac; set => user_mac = value; }
        public string User_role { get => user_role; set => user_role = value; }
        public char Tag { get => tag; set => tag = value; }
        public Brush bColor { get => bcolor; set => bcolor = value; }

        public CShowUser() { }
    }
}
