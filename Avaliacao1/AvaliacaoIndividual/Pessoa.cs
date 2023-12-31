namespace advocacia;
public class Pessoa {
    private string? nome;
    private string? cpf;
    private DateTime nascimento;

    public Pessoa(string _nome, string _cpf, DateTime _nascimento) {
        this.Nome = _nome;
        this.Cpf = _cpf;
        this.Nascimento = _nascimento;
    }
    public string? Cpf {
        get { return cpf; }
        set {
            if(String.IsNullOrWhiteSpace(value)){
                throw new Exceptions.EmptyInputException("O CPF não pode estar em branco.");
            }
            if(value.Length != 11 || !value.All(char.IsDigit)) {
                throw new Exceptions.InvalidCpfException("CPF inválido: Precisa ter 11 dígitos.");
            }
            cpf = value;
        }
    }
    
    public DateTime Nascimento {
        get { return nascimento; }
        set {
            nascimento = value;
        }
    }
    
    public string? Nome {
        get { return nome; }
        set {
            if(String.IsNullOrWhiteSpace(value)){
                throw new Exceptions.EmptyInputException("O nome não pode estar em branco.");
            }
            nome = value;
        }
    }


    public int idade() {
        // return DateTime.Now.Subtract(this.nascimento);
        return DateTime.Now.Year - this.nascimento.Year;
    }

    public string ToStr(){
        return $"CPF: {this.Cpf} | Nome: {this.Nome} | Nascimento: {this.Nascimento.ToShortDateString()}";
    }
}
