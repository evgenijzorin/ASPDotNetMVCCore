using TaskLesson_1.Data.Interfaces;
using TaskLesson_1.Data.Mocks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Внедрение зависимостей
builder.Services.AddTransient<
    IAllProducts,       // какой интерфейс 
    MockProducts> ();   // какой класс реализует интерфейс
builder.Services.AddTransient<ICategorys, MockCategorys>();
               
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
