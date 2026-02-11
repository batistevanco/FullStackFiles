using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Travel.Services.Integration.CountryApi.DTO
{
    public class CountryApiDto
    {
        [JsonProperty("error")] public bool Error { get; set; }
        [JsonProperty("msg")] public string Msg { get; set; } = "";
        [JsonProperty("data")] public List<CountryItem> Data { get; set; } = new();
    }

    public class CountryItem
    {
        [JsonProperty("name")] public string Name { get; set; } = "";
        [JsonProperty("code")] public string Code { get; set; } = "";

    }
}
