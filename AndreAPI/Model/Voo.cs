using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace AndreAPI.Model
{
    public class Voo
    {
        [Key]
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Destino")]
        public virtual Aeroporto Destino { get; set; }

        [JsonProperty("Origem")]
        public virtual Aeroporto Origem { get; set; }

        [JsonProperty("Aeronave")]
        public virtual Aeronave Aeronave { get; set; }

        [JsonProperty("HorarioEmbarque")]
        public DateTime HorarioEmbarque { get; set; }

        [JsonProperty("HorarioDesembarque")]
        public DateTime HorarioDesembarque { get; set; }

        [JsonProperty("Passageiro")]
        public virtual Passageiro Passageiro { get; set; }

        public Voo()
        {


        }
    }
}
