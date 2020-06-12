using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FleaFlickerAPI
{
    public partial class Scoring
    {
        [JsonProperty("schedulePeriod")]
        public SchedulePeriod SchedulePeriod { get; set; }

        [JsonProperty("eligibleSchedulePeriods")]
        public SchedulePeriod[] EligibleSchedulePeriods { get; set; }

        [JsonProperty("games")]
        public Game[] Games { get; set; }
    }

    public partial class SchedulePeriod
    {
        [JsonProperty("ordinal")]
        public long Ordinal { get; set; }

        [JsonProperty("low")]
        public Low Low { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }

    public partial class Low
    {
        [JsonProperty("ordinal")]
        public long Ordinal { get; set; }

        [JsonProperty("season")]
        public long Season { get; set; }

        [JsonProperty("startEpochMilli")]
        public string StartEpochMilli { get; set; }
    }

    public partial class Game
    {
        [JsonProperty("id")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("away")]
        public Away Away { get; set; }

        [JsonProperty("home")]
        public Home Home { get; set; }

        [JsonProperty("awayScore")]
        public Score AwayScore { get; set; }

        [JsonProperty("homeScore")]
        public Score HomeScore { get; set; }

        [JsonProperty("homeResult")]
        public string HomeResult { get; set; }

        [JsonProperty("awayResult")]
        public string AwayResult { get; set; }

        [JsonProperty("isFinalScore")]
        public bool IsFinalScore { get; set; }
    }

    public partial class Away
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logoUrl")]
        public Uri LogoUrl { get; set; }

        [JsonProperty("recordOverall")]
        public Record RecordOverall { get; set; }

        [JsonProperty("recordPostseason")]
        public Record RecordPostseason { get; set; }

        [JsonProperty("pointsFor")]
        public PointsAgainst PointsFor { get; set; }

        [JsonProperty("pointsAgainst")]
        public PointsAgainst PointsAgainst { get; set; }

        [JsonProperty("streak")]
        public PointsAgainst Streak { get; set; }

        [JsonProperty("waiverAcquisitionBudget")]
        public PointsAgainst WaiverAcquisitionBudget { get; set; }

        [JsonProperty("draftPosition")]
        public long DraftPosition { get; set; }

        [JsonProperty("newItemCounts", NullValueHandling = NullValueHandling.Ignore)]
        public AwayNewItemCounts NewItemCounts { get; set; }

        [JsonProperty("initials")]
        public string Initials { get; set; }
    }

    public partial class AwayNewItemCounts
    {
        [JsonProperty("activityUnread")]
        public long ActivityUnread { get; set; }
    }

    //public partial class PointsAgainst
    //{
    //    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? Value { get; set; }

    //    [JsonProperty("formatted")]
    //    public string Formatted { get; set; }
    //}

    //public partial class Record
    //{
    //    [JsonProperty("wins", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? Wins { get; set; }

    //    [JsonProperty("losses", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? Losses { get; set; }

    //    [JsonProperty("winPercentage")]
    //    public PointsAgainst WinPercentage { get; set; }

    //    [JsonProperty("rank")]
    //    public long Rank { get; set; }

    //    [JsonProperty("formatted")]
    //    public string Formatted { get; set; }
    //}

    public partial class Score
    {
        [JsonProperty("score")]
        public PointsAgainst ScoreScore { get; set; }
    }

    public partial class Home
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("recordOverall")]
        public Record RecordOverall { get; set; }

        [JsonProperty("recordPostseason")]
        public Record RecordPostseason { get; set; }

        [JsonProperty("pointsFor")]
        public PointsAgainst PointsFor { get; set; }

        [JsonProperty("pointsAgainst")]
        public PointsAgainst PointsAgainst { get; set; }

        [JsonProperty("streak")]
        public PointsAgainst Streak { get; set; }

        [JsonProperty("waiverAcquisitionBudget")]
        public PointsAgainst WaiverAcquisitionBudget { get; set; }

        [JsonProperty("draftPosition")]
        public long DraftPosition { get; set; }

        [JsonProperty("newItemCounts")]
        public HomeNewItemCounts NewItemCounts { get; set; }

        [JsonProperty("initials")]
        public string Initials { get; set; }

        [JsonProperty("logoUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri LogoUrl { get; set; }
    }

    public partial class HomeNewItemCounts
    {
        [JsonProperty("activityUnread")]
        public long ActivityUnread { get; set; }

        [JsonProperty("messagesUnread", NullValueHandling = NullValueHandling.Ignore)]
        public long? MessagesUnread { get; set; }
    }
}
