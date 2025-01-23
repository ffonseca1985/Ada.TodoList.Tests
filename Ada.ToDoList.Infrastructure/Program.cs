
//Comentando tudo: Ctrl + a e Ctrl + k + c

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }

//O que a gente tem que fazer?
// - Temos que configurar esta classe para ela chamar a Startup
// - E a classe Program vai Inicializar a api web, reservando uma porta
// - A classe startup vai ter as configurações de roteamento/segurança/openApi/Injecao de dependencia etc...

namespace Ada.ToDoList.Infrastructure;

public class Program {

    public static void Main() {
        CreateHostBuilder().Build().Run(); //Lancar a aplicacao
    }

    public static IHostBuilder CreateHostBuilder() {
        
        var host = Host.CreateDefaultBuilder()
         .ConfigureWebHostDefaults(webBuilder => {
                 webBuilder.UseStartup<Startup>();   
         });

         return host;
    }
}