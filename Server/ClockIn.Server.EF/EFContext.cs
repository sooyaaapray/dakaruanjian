using Microsoft.EntityFrameworkCore;
using ClockIn.Server.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Globalization;
namespace ClockIn.Server.EF
{
    public class EFContext:DbContext
    {
        private string _connstr = "server=localhost;port=3306;database=record_system_1;user=root;password=111111";

        public EFContext(){ }
        public EFContext(string constr)
        {
            _connstr = constr;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*ValueConverter iconValueConverter = new ValueConverter<string, string>
                (
                 v => string.IsNullOrEmpty(v) ? null : ((int)v.ToCharArray()[0]).ToString("x"),
                 v => v == null ? "" : ((char)int.Parse(v, NumberStyles.HexNumber)).ToString()
                 );
            modelBuilder.Entity<MenuInfo>().Property(p => p.MenuIcon).HasConversion(iconValueConverter);*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connstr, new MySqlServerVersion(new Version(8, 0, 17)));
        }
        public DbSet<SysUserInfo> SysUserInfo { get; set; }
        public DbSet<MenuInfo> MenuInfo { get; set; }
        public DbSet<ClockInDayInfo> ClockInDayInfo { get; set; }
        public DbSet<ClockInInfo> ClockInInfo { get; set; }
        public DbSet<LeaveCheckInfo> LeaveCheckInfo { get; set; }
    }
}
