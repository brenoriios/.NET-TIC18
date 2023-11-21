namespace Pratica002;

public class Task {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly ExpirationDate { get; set; }
    public bool Completed { get; set; }
    
    public Task(string _title, string _description, DateOnly _expirationDate) {
        Title = _title;
        Description = _description;
        ExpirationDate = _expirationDate;
        Completed = false;
    }

    public string toString() {
        return $"{Title} ({ExpirationDate}) {(Completed ? "[X]" : "[ ]" )}";
    }
}
