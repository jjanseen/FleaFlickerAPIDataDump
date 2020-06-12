using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FleaFlickerAPI
{

    public partial class PointsAgainst
    {
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public double? Value { get; set; }

        [JsonProperty("formatted")]
        public string Formatted { get; set; }
    }

    public partial class Record
    {
        [JsonProperty("wins", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wins { get; set; }

        [JsonProperty("losses", NullValueHandling = NullValueHandling.Ignore)]
        public long? Losses { get; set; }

        [JsonProperty("winPercentage")]
        public PointsAgainst WinPercentage { get; set; }

        [JsonProperty("rank")]
        public long Rank { get; set; }

        [JsonProperty("formatted")]
        public string Formatted { get; set; }
    }
}
