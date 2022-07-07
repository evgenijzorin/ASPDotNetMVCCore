using Serilog;
using TaskLesson_5.Options;
using TaskLesson_5.Servicies;
using TaskLesson_5.Servicies.Interfaces;

Log.Logger = new LoggerConfiguration()
 .WriteTo.Console()
 .CreateBootstrapLogger(); // означает, что глобальный логер будет заменен на вариант из Host.UseSerilog
Log.Information("Starting up");
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Подключить серилог
    builder.Host.UseSerilog((_, conf) => conf.WriteTo.Console());

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    // Регистрация заваисимостей конфигурации
    builder.Services.Configure<SmtpConfig> // Указывается класс с которрым связываются конфигурации 
        (builder.Configuration.GetSection("SmtpConfig")); // Указывается секция файла appsettings.json на которой находятся конфигурации данного класса
                                                          // Кроме того добавлен пользовательский секрет - пароль к почте сендера

    // Регистрация зависимостей
    builder.Services.AddScoped<IEmailSender, MailKitSntpEmailSender>();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Сервер рухнул!");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush(); // перед выходом дожидаемся пока все логи будут записаны
}












