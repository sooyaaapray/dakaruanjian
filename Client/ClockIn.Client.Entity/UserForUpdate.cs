using System;

namespace ClockIn.Client.Entity
{
    public class UserForUpdate
    {
        private static readonly object locker = new object(); //lock
        private static UserForUpdate? unique_user;

        public int User_id { get; set; }
        public string User_name { get; set; }
        public string User_ip_address { get; set; }
        public string User_mac { get; set; }
        public string User_pwd { get; set; }
        public string User_login_name { get; set; }
        public string User_role { get; set; }
        public bool Is_admin { get; set; }
        public bool Is_active { get; set; }

        public DateTime work_on { get; set; }
        public DateTime work_off { get; set; }
        public DateTime eat_on { get; set; }
        public DateTime eat_off { get; set; }

        private UserForUpdate() { }
        public static UserForUpdate _user_instance()
        {
            lock (locker)
            {
                if (unique_user == null)
                {
                    unique_user = new UserForUpdate();
                }
            }
            return unique_user;
        }
    }
}
