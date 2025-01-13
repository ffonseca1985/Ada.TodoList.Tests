

using Ada.ToDoList.Domain.Entities;

namespace Ada.ToDoList.Tests.Domain.Entities;

//Using TDD
public class TaskTests {

    //Create Task
    [Fact]
    public void Create_ShouldSetPropertiesCorrectly() {

        //Passos => Red, Green e Refactore
        //Arrange
        int taskId = 1;
        string name = "Estudar TDD";

        //Act
        var task = new Task(taskId, name);

        // Assert
        Assert.Equal(taskId, task.Id);
        Assert.Equal(name, task.Name);
        Assert.Equal(TaskStatus.NotStarted, task.Status);
        Assert.True(task.GetTaskItems().Count == 0);
    }

    //Insert Item to Task
    //Remover Item To Task

}
