using Newtonsoft.Json;

namespace AndreAPI.Model
{
    public class Aeronave
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Nome")]
        public string Nome { get; set; }

        [JsonProperty("Capacidade")]
        public int Capacidade { get; set; }

        public Aeronave()
        {
        }


    }
}
