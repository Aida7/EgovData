using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{
    public class EgovData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name_rus")]
        public string Name { get; set; }
        [JsonProperty("kurs")]
        public float Kurs { get; set; }
    }
}
