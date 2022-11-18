﻿using Newtonsoft.Json;

namespace CarsAPI.Models
{
    public class MakeModel
    {
       // Whenever we need this property in Json format it will be called make //
        [JsonProperty("make")]
        public string Make { get; set; } = string.Empty;
    }
}
