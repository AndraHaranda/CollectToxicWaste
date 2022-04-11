using System.ComponentModel.DataAnnotations;

namespace CollectToxicWaste.Dominio.Entidades
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string NomeLogin { get; set; }   
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Profissao { get; set; }
        public string Avatar { get; set; }
        public string Telefone { get; set; }
    }
}
