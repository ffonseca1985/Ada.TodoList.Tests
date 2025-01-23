

namespace Ada.ToDoList.Infrastructure;

//A api de test, irá deixar a classe Startup dinamica, ou seja, poderá mudar, connection string,
//Injecao de dependencia, etc...
public class Startup {

    // - O que temos na classe de Startup???
    // - Objetos que leêm arquivos de configuração (json, etc....)
    public IConfiguration Configuration { get;}
    public Startup (IConfiguration configuration) {
        this.Configuration = configuration;
    }

    //Classes Helpers / Services do WebApi, Services de Injecao de Dependencia
    public void ConfigureServices(IServiceCollection services) {

        //Habilitar ou instanciar/criar as classes globais aqui;
        services.AddEndpointsApiExplorer();
        services.AddControllers();
        services.AddSwaggerGen();

        //Registro do nossa inteface de Repositorio => ITaskRepository
    }

    //Pipeline de Requisições Http (Middlewares)
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

        //Adicionando Swagger
        app.UseSwagger();
        app.UseSwaggerUI();

        //Usar somente https
        app.UseHttpsRedirection();

        // Habilitar roteamento
        app.UseRouting();

        //Iremos mandar os roteamentos para as controllers
        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });
    }  
}