using Microsoft.EntityFrameworkCore;
using simulacro2.Data;
using simulacro2.Services.Especialidades;
using simulacro2.Services.Pacientes;
using simulacro2.Services.Medicos;
using simulacro2.Services.Citas;

using MailerSend.AspNetCore;
using simulacro2.Models;

using simulacro2.Services.MailSend;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<BaseContext>
(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("mySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.2-mysql")
    )
);


builder.Services.AddScoped<IEspecialidadesRepository, EspecialidadesRepository>();
builder.Services.AddScoped<IPacientesRepository, PacientesRepository>();
builder.Services.AddScoped<IMedicosRepository, MedicosRepository>();
builder.Services.AddScoped<ICitasRepository, CitasRepository>();

// envio de correo - registro de interfaces

builder.Services.AddScoped<IEmailSender,EmailSender>();
builder.Services.AddHttpClient<IEmailSender,EmailSender>();

builder.Services.Configure<MailerSendOptionss>(builder.Configuration.GetSection("Mailersend"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();
app.MapControllers();


app.Run();

