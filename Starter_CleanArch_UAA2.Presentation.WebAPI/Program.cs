using Mailer;
using Microsoft.EntityFrameworkCore;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Repositories;
using Starter_CleanArch_UAA2.ApplicationCore.Interfaces.Services;

using Starter_CleanArch_UAA2.ApplicationCore.Services;
using Starter_CleanArch_UAA2.Infrastructure.Database;
using Starter_CleanArch_UAA2.Infrastructure.Database.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMailerService, MailerService>(service =>
{
    return new MailerService(
        builder.Configuration["Mailer:Host"]!,
        builder.Configuration.GetValue<int>("Mailer:Port", 25),
        builder.Configuration["Mailer:Username"]!,
        builder.Configuration["Mailer:AppEmail"]!,
        builder.Configuration["Mailer:AppName"]!
    );
});

// Add services to the container.
builder.Services.AddSingleton<Random>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IMailerService,MailerService>();

builder.Services.AddScoped<ISubscriberRepository, SubscriberRepository>();

builder.Services.AddDbContext<AppDbContext>(options=>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});


builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
