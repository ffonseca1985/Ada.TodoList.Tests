

//O que é esta classe => É a nossa startup no Test,
//Nela diremos como a aplicacao Web irá se comportar!!!
//Poderemos trocar: Classes de DI, ConnectionString, Urls etc....

//Para este fim, teremos que usar uma Lib do .netCore.

//Microsoft.AspNetCore.Mvc.Testing --version 8.0.12
//dotnet add .\Ada.ToDoList.Tests\Ada.ToDoList.Tests.csproj package Microsoft.AspNetCore.Mvc.Testing --version 8.0.12 

using Ada.ToDoList.Domain.Repositories;
using Ada.ToDoList.Infrastructure;
using Ada.ToDoList.Tests.Infrastructure.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Ada.ToDoList.Tests.Infrastructure;

//Esta classe irá definir a estrategia da minha case startup
public class CustomStartupWebApplicationFactory : WebApplicationFactory<Startup> {

    //Por exemplo poderemos mudar as classes DI
    //POr exemplo: Trocar a classe de repositorio - colocar uma classe de repositorio de ambiente DEV
    //Podemos dar Override em varios items do Startup ou Program

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //Podemos aqui adicionar outros services        
        base.ConfigureWebHost(builder); //Mantem o que já estava, mas agora vamos acrescentar mais alguma coisa.

        builder.ConfigureServices(services => {

            //Aqui, vamos registrar os serviços, de Test.
            //Infra que tem objetos de DEV, InMemory etc..

            //No exemplo abaixo, vamos usar o mock de taskRepository
            services.AddSingleton<ITaskRepository, TaskRepositoryMock>();
        });
    }
}

