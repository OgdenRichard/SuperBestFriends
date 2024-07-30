using Microsoft.EntityFrameworkCore;
using SuperBestFriends.DAL;
using SuperBestFriends.Business.Extensions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Import Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<FriendsDbContext>();

// Import DBContext
builder.Services.AddDbContext<FriendsDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("FriendsDbContext")));

// Import des services
builder.Services.AddBusiness();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
