
namespace Ada.ToDoList.Domain;


//Uma classe helper só para ajudar no retorno
public class ExecutionResult<T> where T : class {
    private ExecutionResult() {}

    public bool Success {get; set;}
    public string? ErrorMessage {get; set;}
    public T? Data {get; set;}  

    public static ExecutionResult<T> CreateSuccess(T data) => new ExecutionResult<T>() { Success = true, Data = data };
    public static ExecutionResult<T> CreateFailure(string errorMessage) => new ExecutionResult<T>() { Success = false, ErrorMessage = errorMessage };
}