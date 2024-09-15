//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using TodoApp.Data;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();


//builder.Services.AddDbContext<TodoContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//var app = builder.Build();





//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Todo/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Todo}/{action=Index}/{id?}");

//app.Run();

//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.OpenApi.Models;
//using TodoApp.Data;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//// Add Swagger services
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "Todo API",
//        Version = "v1",
//        Description = "API for managing Todo tasks",
//        Contact = new OpenApiContact
//        {
//            Name = "Abul Kashim",
//            Email = "kashimmirza86@gmai.com",
//        }
//    });
//});

//// Configure Entity Framework and SQL Server
//builder.Services.AddDbContext<TodoContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllOrigins", builder =>
//    {
//        builder.AllowAnyOrigin() // Allows requests from any origin
//               .AllowAnyMethod() // Allows all HTTP methods
//               .AllowAnyHeader(); // Allows all headers
//    });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint.
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API v1");
//        c.RoutePrefix = string.Empty;  // Set Swagger UI to the root path (optional).
//    });
//}
//else
//{
//    app.UseExceptionHandler("/Todo/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();
//app.UseCors("AllowSpecificOrigin");

//app.UseAuthorization();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

// Define the default controller route
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Todo}/{action=Index}/{id?}");

//app.Run();

//var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//       policy =>
//        {
//            policy.WithOrigins("http://localhost:3000")
//                  .AllowAnyMethod()
//                  .AllowAnyHeader();
//        });
//});

//builder.Services.AddControllers(); // Register services for controllers

//var app = builder.Build();

//Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseCors("AllowSpecificOrigin"); // Use the CORS policy

//app.UseAuthorization();

//app.MapControllers(); // Map controller endpoints

//app.Run();


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using TodoApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Todo API",
        Version = "v1",
        Description = "API for managing Todo tasks",
        Contact = new OpenApiContact
        {
            Name = "Abul Kashim",
            Email = "kashimmirza86@gmai.com",
        }
    });
});

// Configure Entity Framework and SQL Server
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API v1");
        c.RoutePrefix = string.Empty;  // Set Swagger UI to the root path (optional).
    });
}
else
{
    app.UseExceptionHandler("/Todo/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowAllOrigins"); // Use the CORS policy

app.UseAuthorization();

app.MapControllers(); // Map controller endpoints

app.Run();



