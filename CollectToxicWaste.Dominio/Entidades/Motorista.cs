using System.ComponentModel.DataAnnotations;

namespace CollectToxicWaste.Dominio.Entidades
{
    public class Motorista
    {
        [Key]
        public int Id { get; set; }
        public string NomeMotorista { get; set; }
        public string Idade { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        CategoriaCNH TipoCNH { get; set; }

    }

    public enum CategoriaCNH
    {
        CATEGORIA_A = 1, //Moto
        CATEGORIA_B = 2, //Carro
        CATEGORIA_C = 3, //Caminhão
        CATEGORIA_D = 4, //Van ou Onibus
    }

}
