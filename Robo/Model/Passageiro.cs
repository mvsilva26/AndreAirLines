using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Passageiro
    {
        [Key]
        [JsonProperty("Cpf")]
        public string Cpf { get; set; }

        [JsonProperty("Nome")]
        public string Nome { get; set; }

        [JsonProperty("Telefone")]
        public string Telefone { get; set; }

        [JsonProperty("DataNasc")]
        public DateTime DataNasc { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Endereco")]
        public virtual Endereco Endereco { get; set; }

        public Passageiro()
        {

        }

        public Passageiro(string cpf, string nome, string telefone, DateTime dataNasc, string email, Endereco endereco)
        {
            Cpf = cpf;
            Nome = nome;
            Telefone = telefone;
            DataNasc = dataNasc;
            Email = email;
            Endereco = endereco;
        }
    }
}
