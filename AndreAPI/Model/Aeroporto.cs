using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AndreAPI.Model
{
    public class Aeroporto
    {   
        
        [Key]
        [JsonProperty("Sigla")]
        public string Sigla { get; set; }

        [JsonProperty("Nome")]
        public string Nome { get; set; }

        [JsonProperty("Endereco")]
        public virtual Endereco Endereco { get; set; }

        public Aeroporto()
        {
        }
    }
}
