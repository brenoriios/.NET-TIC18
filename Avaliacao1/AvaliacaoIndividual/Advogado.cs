namespace advocacia;
public class Advogado : Pessoa { 
    private string? cna;
    public string? Cna {
        get { return cna; }
        set {
            if(String.IsNullOrWhiteSpace(value)){
                throw new Exceptions.EmptyInputException("O CNA não pode estar em branco.");
            }
            if(value.Length != 12){
                throw new Exceptions.EmptyInputException("CNA inválido: Precisa ter 12 dígitos.");
            }
            cna = value;
        }
    }
    
    public Advogado(string cna, string nome, string cpf, DateTime nascimento) : base(nome, cpf, nascimento) {
        this.Cna = cna;
    }

    public new string ToStr(){
        return $"CNA: {this.Cna} | Nome: {this.Nome} | Nascimento: {this.Nascimento.ToShortDateString()} | CPF: {this.Cpf}";
    }
}
