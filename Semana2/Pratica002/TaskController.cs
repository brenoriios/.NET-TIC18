using Task = Pratica002.Task;
namespace Pratica002;
class TaskController {
    List<Task> taskList;

    public TaskController(){
        taskList = new();
        taskList.Add(new Task("Task 1", "Descrição da Task 1", new DateOnly(2023, 11, 21)));
        taskList.Add(new Task("Task 2", "Descrição da Task 2", new DateOnly(2023, 11, 21)));
        taskList.Add(new Task("Task 3", "Descrição da Task 3", new DateOnly(2023, 11, 21)));
    }
    public void createTask(){
        Console.WriteLine($"Inserir Nova Tarefa:");
        Console.WriteLine($"Digite o título da nova tarefa: ");
        string? title = Console.ReadLine();
        Console.WriteLine($"Digite a descrição da nova tarefa: ");
        string? description = Console.ReadLine();
        Console.WriteLine($"Digite a data de expiração da nova tarefa (dd/mm/yyyy): ");
        string? dateInput = Console.ReadLine();

        if(string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(dateInput)){
            Console.WriteLine($"Por favor preencha todos os dados!");
            return;
        }

        string[] dateParams = dateInput.Split('/');
        Array.Reverse(dateParams);
        dateInput = string.Join('-', dateParams);

        DateOnly date;
        try {
            date = DateOnly.Parse(dateInput);
        } catch {
            Console.WriteLine($"Data Inválida!");        
            return;
        }

        Task newTask = new(title, description, date);

        taskList.Add(newTask);
    }

    public void completeTask(){
        Console.WriteLine($"Concluir Tarefa:");
        int? index = findTask();

        if(index == null){
            return;
        }

        taskList.ElementAt(index.Value).Completed = true;
    }

    public void deleteTask(){
        Console.WriteLine($"Excluir Tarefa:");
        int? index = findTask();

        if(index == null){
            return;
        }

        taskList.RemoveAt(index.Value);
    }

    public void listTasks(){
        Console.WriteLine($"Lista de Tarefas:");
        for(int i = 0; i < taskList.Count; i++){
            Task task = taskList[i];
            Console.WriteLine($"{i + 1}. {task.toString()}");
        }
    }

    public void listTasks(bool taskState){
        List<Task> tasks = taskList.FindAll(task => task.Completed == taskState);

        Console.WriteLine($"Lista de Tarefas {(taskState ? "Concluídas" : "Pendentes")}:");
        for(int i = 0; i < tasks.Count; i++){
            Task task = tasks[i];
            Console.WriteLine($"{i + 1}. {task.toString()}");
        }
    }

    public void listTasks(List<Task> tasks){
        Console.WriteLine($"Lista de Tarefas:");
        for(int i = 0; i < tasks.Count; i++){
            Task task = tasks[i];
            Console.WriteLine($"{i + 1}. {task.toString()}");
        }
    }

    public int? findTask(){
        listTasks();
        Console.WriteLine($"Digite o número de uma tarefa: ");
        string? taskNumberInput = Console.ReadLine();

        if(string.IsNullOrEmpty(taskNumberInput)){
            Console.WriteLine($"Por favor preencha todos os dados!");
            return null;
        }

        int taskNumber;
        try {
            taskNumber = Int32.Parse(taskNumberInput) - 1;
        } catch {
            Console.WriteLine($"Por favor digite um número!");
            return null;
        }

        Task task;
        try{
            task = taskList.ElementAt(taskNumber);
        } catch {
            Console.WriteLine($"Por favor digite um número válido!");
            return null;
        }

        return taskNumber;
    }

    public void listTaskByKeyword(){
        Console.WriteLine($"Digite os termos da busca: ");
        string? prompt = Console.ReadLine();

        if(string.IsNullOrEmpty(prompt)){
            Console.WriteLine($"Por favor preencha todos os dados!");
            return;
        }

        string[] keywords = prompt.Split(' ');

        List<Task> filteredTasks = taskList.Where(
            task => keywords.All(
                    keyword => task.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase) || task.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                )
            ).ToList();

        listTasks(filteredTasks);
    }

    public void main(){
        while(true){
            Console.WriteLine($"Digite uma opção");
            string? opInput = Console.ReadLine();

            if(string.IsNullOrEmpty(opInput)){
                continue;
            }

            int op;
            try {
                op = Int32.Parse(opInput);
            } catch {
                Console.WriteLine($"Por favor digite um número!");
                continue;
            }

            switch(op){
                case 1: {
                    createTask();
                    break;
                }
                case 2: {
                    completeTask();
                    break;
                }
                case 3: {
                    deleteTask();
                    break;
                }
                case 4: {
                    listTasks();
                    break;
                }
                case 5: {
                    listTasks(taskState: true);
                    break;
                }
                case 6: {
                    listTasks(taskState: false);
                    break;
                }
                case 7: {
                    listTaskByKeyword();
                    break;
                }
                case 0: {
                    break;
                }
                default: {
                    Console.WriteLine($"Opção Inválida");      
                    break;
                }    
            }

            if(op == 0){
                break;
            }
        }
    }
}
