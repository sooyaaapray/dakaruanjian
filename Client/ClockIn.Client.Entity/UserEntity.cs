namespace ClockIn.Client.Entity
{
    public class UserEntity
    {
        /*"{\"user_id\":1,
         * \"user_name\":\"pray\",
         * \"user_role\":\"Boss\",
         * \"user_ip_address\":\"192.168.2.1\",
         * \"user_mac\":\"00D861795D2C\",
         * \"user_pwd\":\"33E603DEB531899CE470B497DDA5896A\",
         * \"user_login_name\":\"admin\",
         * \"is_admin\":true,
         * \"is_active\":true}"*/
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_role { get; set; }
        public string user_ip_address { get; set; }
        public string user_mac { get; set; }
        public string user_pwd { get; set; }
        public string user_login_name { get; set; }
        public bool is_admin { get; set; }
        public bool is_active { get; set; }
        public TimeOnly work_on { get; set; }
        public TimeOnly work_off { get; set; }
        public TimeOnly eat_on { get; set; }
        public TimeOnly eat_off { get; set; }
        public List<MenuEntity> menus {get;set;}
    }
}
