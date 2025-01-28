

//O que vamos Fazer?
//1 => Vamos chamar a API.
//1.1 => algo +- Assim: host://api/task 
//2 => A api será chamada via httpClient do CustomStartupWebApplicationFactory
//3 => Porém a api usará a nossa startup customizada, que é a CustomStartupWebApplicationFactory
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;

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

        //Arrange
        //Vamos criar o objeto de request, para isso usaremos a factory.
        HttpClient httpClient = _factory.CreateClient();

        //Act
        var response = await httpClient.GetAsync("/api/task");

        //Assert
        response.EnsureSuccessStatusCode();
        var value = await response.Content.ReadAsStringAsync();

        Assert.Equivalent(value, "OK Task");
    }

    // nota-se que quando chamamos a api (via test), é usado o TaskRepository, porém queremos usar o TaskRepositoryMock,
    // visto que é um ambiente de TEST e não de PROD
    [Theory]
    [InlineData(1)]
    public async System.Threading.Tasks.Task GetById_WhenRequest_ReturnTask(int id) {

        //Arrange
        HttpClient httpClient = _factory.CreateClient();

        //Act
        var response = await httpClient.GetAsync($"/api/task/{id}");

        //Assert
        response.EnsureSuccessStatusCode();
        ToDoList.Domain.Entities.Task value = (await response.Content.ReadFromJsonAsync<ToDoList.Domain.Entities.Task>())!;        

        Assert.NotNull(value);
        Assert.Equal(id, value.Id);
        Assert.Equal("Primeira Task", value.Name);
    }

    //Quero que Façam em casa: Post
    [Theory]
    [InlineData(2, "Tarefa 2")]
    public async System.Threading.Tasks.Task Post_GivenTask_Create(int id, string name) {

        //Arrange
        HttpClient httpClient = _factory.CreateClient();
        var task = new Ada.ToDoList.Domain.Entities.Task(id, name);

         var json = JsonConvert.SerializeObject(task);
         HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

        //Act
        //Inserir // POST
        var response = await httpClient.PostAsync($"/api/task", content);

        //Assert
        response.EnsureSuccessStatusCode();
        ToDoList.Domain.Entities.Task valuePost = (await response.Content.ReadFromJsonAsync<ToDoList.Domain.Entities.Task>())!;

        // Depois de Inserir, valido se de fato cadastrou
        var responseSearch = await httpClient.GetAsync($"/api/task/{task.Id}");
        
        responseSearch.EnsureSuccessStatusCode();
        ToDoList.Domain.Entities.Task valueGet = (await responseSearch.Content.ReadFromJsonAsync<ToDoList.Domain.Entities.Task>())!;

        valuePost.Should().BeEquivalentTo(valueGet);
        valuePost.Id.Should().Be(id);
        valuePost.Name.Should().Be(name);
    }
}