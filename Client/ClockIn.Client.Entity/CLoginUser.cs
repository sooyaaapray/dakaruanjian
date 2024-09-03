using System.ComponentModel.DataAnnotations.Schema;

namespace ClockIn.Client.Entity
{
    public class CLoginUser
    {
        private static readonly object locker = new object(); //lock
        private static CLoginUser? unique_user;

        public int User_id { get; set; }
        public string User_name { get; set; }
        public string User_ip_address { get; set; }
        public string User_mac { get; set; }
        public string User_pwd { get; set; }
        public string User_login_name { get; set; }
        public string User_role { get; set; }
        public bool Is_admin { get; set; }

        public TimeOnly work_on { get; set; }
        public TimeOnly work_off { get; set; }
        public TimeOnly eat_on { get; set; }
        public TimeOnly eat_off { get; set; }

        public List<MenuEntity> menus { get; set; }

        private CLoginUser() { }
        public static CLoginUser _user_instance()
        {
            lock (locker)
            {
                if (unique_user == null)
                {
                    unique_user = new CLoginUser();
                }
            }
            return unique_user;
        }
    }
}
