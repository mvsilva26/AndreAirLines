using Newtonsoft.Json;

namespace Model
{
    public class Endereco
    {

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Bairro")]
        public string Bairro { get; set; }

        [JsonProperty("Cidade")]
        public string Cidade { get; set; }

        [JsonProperty("Pais")]
        public string Pais { get; set; }

        [JsonProperty("Cep")]
        public string Cep { get; set; }

        [JsonProperty("Logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("Estado")]
        public string Estado { get; set; }

        [JsonProperty("Numero")]
        public int Numero { get; set; }

        [JsonProperty("Complemento")]
        public string Complemento { get; set; }

        public Endereco()
        {

        }

        public Endereco(int id, string bairro, string cidade, string pais, string cep, string logradouro, string estado, int numero, string complemento)
        {
            Id = id;
            Bairro = bairro;
            Cidade = cidade;
            Pais = pais;
            Cep = cep;
            Logradouro = logradouro;
            Estado = estado;
            Numero = numero;
            Complemento = complemento;
        }

        public override string ToString()
        {
            return "Id: " + Id + "\n" + 
                   "Bairro: " + Bairro + "\n" +
                   "Cidade: " + Cidade + "\n" +
                   "Pais: " + Pais + "\n" +
                   "Cep: " + Cep + "\n" +
                   "Logradouro: " + Logradouro + "\n" +
                   "Estado: " + Estado + "\n" +
                   "Numero: " + Numero + "\n" +
                   "Complemento: " + Complemento + "\n";
        }
    }
}
