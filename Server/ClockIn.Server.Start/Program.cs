
using ClockIn.Server.Service;
using ClockIn.Server.Start.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication();

// Add services to the container.
builder.Services.AddTransient<ClockIn.Server.IConfiguration.IConfiguration, ClockIn.Server.Configuration.Configuration>();
builder.Services.AddTransient<ClockIn.Server.IEFContext.IEFContext, ClockIn.Server.EFContext.EFContext>();
builder.Services.AddTransient<ClockIn.Server.IService.ILoginService, ClockIn.Server.Service.LoginService>();
builder.Services.AddTransient<ClockIn.Server.IService.IMenuService, ClockIn.Server.Service.MenuService>();

builder.Services.AddTransient<ClockIn.Server.IService.IClockInService, ClockIn.Server.Service.ClockInService>();
builder.Services.AddTransient<ClockIn.Server.IService.ILeaveService, ClockIn.Server.Service.LeaveService>();
builder.Services.AddTransient<ClockIn.Server.IService.ICheckService, ClockIn.Server.Service.CheckService>();
builder.Services.AddTransient<ClockIn.Server.IService.IUpdateUserService, ClockIn.Server.Service.UpdateUserService>();
builder.Services.AddTransient<ClockIn.Server.IService.ILeaveService, ClockIn.Server.Service.LeaveService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
    options.JsonSerializerOptions.Converters.Add(new TimeOnlyConverter());
});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication();//¼øÈ¨
app.UseAuthorization();//ÊÚÈ¨

app.MapControllers();

app.Run();
