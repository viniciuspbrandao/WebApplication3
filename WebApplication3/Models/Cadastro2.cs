using System.ComponentModel.DataAnnotations;



namespace WebApplication3.Models
{
    public class Cadastro2
    {
        
            [Key]
            public int Idade { get; set; }
            public String Nome { get; set; }
            public String Cpf { get; set; }
            public String Email { get; set; }
            public String Telefone { get; set; }
            public String Qual_serviço_você_procura { get; set; }
            public String Qual_serviço_você_oferece { get; set; }
        
    }
}
