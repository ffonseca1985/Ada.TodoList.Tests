# Ada.TodoList.Tests

## Links do Excalidraw
- [Diagrama 1](https://excalidraw.com/#json=Q6F4gE89Hb-B53_amz71r,yP7g0OS0HQNWkMX3QcO1Ew)
- [Diagrama 2](https://excalidraw.com/#json=OPI6BU_5jQdz-crVhRxig,5zgyI8uJKrltLvxlPeZSiA)

---

## Passos para Configuração

1. Criar o Projeto `Ada.ToDoList.Domain`  
   Este projeto conterá as entidades e regras de negócio.

   ```bash
   dotnet new classlib -n Ada.ToDoList.Domain
   ```

   - **Tipo de template:** `classlibrary`

2. Criar o Projeto `Ada.ToDoList.Infrastructure`  
   Este será o projeto de infraestrutura, contendo a API e os repositórios para persistência de dados.

   ```bash
   dotnet new webapi -n Ada.ToDoList.Infrastructure --framework net8.0
   ```

   - **Tipo de template:** `WebApi`
   - **Estrutura:** incluir uma pasta para repositórios.

3. Criar o Projeto de Testes `Ada.ToDoList.Tests`  
   Este projeto será usado para os testes unitários.

   ```bash
   dotnet new xunit -n Ada.ToDoList.Tests --framework net8.0
   ```

   - **Tipo de template:** `xUnit` (escolhido por ser moderno e amplamente utilizado).

4. Criar a Solution  
   A Solution agrupa os projetos e centraliza os comandos.

   ```bash
   dotnet new sln -n Ada.ToDoList
   ```

   4.1. Adicionar os Projetos à Solution

   ```bash
   dotnet sln Ada.ToDoList.sln add .\Ada.ToDoList.Domain\Ada.ToDoList.Domain.csproj
   dotnet sln Ada.ToDoList.sln add .\Ada.ToDoList.Infrastructure\Ada.ToDoList.Infrastructure.csproj
   dotnet sln Ada.ToDoList.sln add .\Ada.ToDoList.Tests\Ada.ToDoList.Tests.csproj
   ```

5. Adicionar Referências  

   - Testes Referenciam `Domain` e `Infrastructure`  

     ```bash
     dotnet add .\Ada.ToDoList.Tests\Ada.ToDoList.Tests.csproj reference .\Ada.ToDoList.Domain\Ada.ToDoList.Domain.csproj
     dotnet add .\Ada.ToDoList.Tests\Ada.ToDoList.Tests.csproj reference .\Ada.ToDoList.Infrastructure\Ada.ToDoList.Infrastructure.csproj
     ```

   - Infraestrutura Referencia `Domain`  

     ```bash
     dotnet add .\Ada.ToDoList.Infrastructure\Ada.ToDoList.Infrastructure.csproj reference .\Ada.ToDoList.Domain\Ada.ToDoList.Domain.csproj
     ```

6. Lição de Casa  
   Baixar o **Visual Studio Community** (gratuito para estudos) e criar um projeto.

7. Gerenciar Branches e Controle de Versão  

   - Colocar Arquivos na Área de Stage  

     ```bash
     git add --all
     ```

   - Versionar Alterações  

     ```bash
     git commit -m "aula1 criacao de projetos e teoria"
     ```

   - Enviar para o Repositório Remoto  

     ```bash
     git push
     ```

   - Criar e Enviar uma Nova Branch  

     ```bash
     git checkout -b aula1
     git add --all
     git commit -m "criado branch aula1"
     git push --set-upstream origin aula1
     ```

---

## Aula 2: Introdução ao XUnit

- **Conceitos básicos do XUnit**
- **Padrões de nomenclatura para testes**
- **Resolução de exercícios**

## Aula 3:

- **ClassFixture**
- **Conceitos de TDD**
- **Classes de Domain >> Entities**

## Aula 4: 

- **Mock
- **Libs:
   - https://nsubstitute.github.io/
   - https://www.codemag.com/Article/2305041/Using-Moq-A-Simple-Guide-to-Mocking-for-.NET
   - https://github.com/devlooped/moq

- **instalando pacotes:**
   ```bash 
   NSubstitute: dotnet add .\Ada.ToDoList.Tests\Ada.ToDoList.Tests.csproj package NSubstitute 
   ```