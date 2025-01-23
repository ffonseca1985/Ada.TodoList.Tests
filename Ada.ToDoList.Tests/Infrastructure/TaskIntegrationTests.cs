

//O que vamos Fazer?
//1 => Vamos chamar a API.
//1.1 => algo +- Assim: host://api/task 
//2 => A api será chamada via httpClient do CustomStartupWebApplicationFactory
//3 => Porém a api usará a nossa startup customizada, que é a CustomStartupWebApplicationFactory
using System.Net.Http;

namespace Ada.ToDoList.Tests.Infrastructure;

public class TaskIntegrationTests : IClassFixture<CustomStartupWebApplicationFactory> {

    //Nos testes usaremos esta factory como base.
    private readonly CustomStartupWebApplicationFactory _factory;

    public TaskIntegrationTests(CustomStartupWebApplicationFactory factory)
    {
        _factory = factory;
    }

    //Teste Simples
    //Vamos testar o Get...
    [Fact]
    public async System.Threading.Tasks.Task Get_WhenRequest_ReturnMessage() {

        //Arrage
        //Vamos criar o objeto de request, para isso usaremos a factory.
        HttpClient httpClient = _factory.CreateClient();

        //Act
        var response = await httpClient.GetAsync("/api/task");

        //Assert
        response.EnsureSuccessStatusCode();
        var value = await response.Content.ReadAsStringAsync();

        Assert.Equivalent(value, "OK Task");
    }
}