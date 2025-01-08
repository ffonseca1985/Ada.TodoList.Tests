# Ada.TodoList.Tests

# Passos
## 1 - Criar projeto Ada.ToDoList.Domain

dotnet new classlib -n Ada.ToDoList.Domain

##   - Qual tipo de template vamos usar? 
- classlibrary 

## 2 - Criar projeto Ada.ToDoList.Infrastructure (Api e onde vamos inserir os dados)

dotnet new webapi -n Ada.ToDoList.Infrastructure --framework net8.0

##   - Qual tipo de template vamos usar? 
- WebApi (Api) e dentro dele pasta de repository

## 3 - Criar projeto Ada.TodoList.Tests

dotnet new xunit -n Ada.ToDoList.Tests --framework net8.0

##   - Qual tipo de template vamos usar? 
- XUnit, porque é mais moderno e etc...

## 4 - Criar a Solution (Agrupa os projetos e centraliza os comando)
dotnet new sln -n Ada.ToDoList

### 4.1 Depois criar a solution vamos adicionar os projetos nela.
dotnet sln Ada.ToDoList.sln add .\Ada.ToDoList.Domain\Ada.ToDoList.Domain.csproj
dotnet sln .\Ada.ToDoList.sln add .\Ada.ToDoList.Infrastructure\Ada.ToDoList.Infrastructure.csproj
dotnet sln .\Ada.ToDoList.sln add .\Ada.ToDoList.Tests\Ada.ToDoList.Tests.csproj

## 5 - Adicionar as referencias 
   #### Teste referencia Domain e a Infra

dotnet add .\Ada.ToDoList.Tests\Ada.ToDoList.Tests.csproj reference .\Ada.ToDoList.Domain\Ada.ToDoList.Domain.csproj  
dotnet add .\Ada.ToDoList.Tests\Ada.ToDoList.Tests.csproj reference .\Ada.ToDoList.Infrastructure\Ada.ToDoList.Infrastructure.csproj

   #### Infra referencia Domain

dotnet add .\Ada.ToDoList.Infrastructure\Ada.ToDoList.Infrastructure.csproj reference .\Ada.ToDoList.Domain\Ada.ToDoList.Domain.csproj

### 6 - Lição de casa:
baixa o visual studio comunity (Gratuito pra estudo!!!!) e cria um projeto*

## 7 - dividir os projetos em branches

## colocar na area de stage
git add --all

## versionar
git commit -m "aula1 criacao de projetos e teoria"

## mandar para a nuvem
git push

## Vou criar uma branch para deixar na ordem cronologia os estudos