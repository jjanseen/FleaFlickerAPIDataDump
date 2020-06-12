

using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FleaFlickerAPI
{
    public partial class Standings
    {
        [JsonProperty("divisions")]
        public Division[] Divisions { get; set; }

        [JsonProperty("season")]
        public long Season { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }
    }

    public partial class Division
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("teams")]
        public Team[] Teams { get; set; }
    }

    public partial class Team
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

        [JsonProperty("owners")]
        public Owner[] Owners { get; set; }

        [JsonProperty("newItemCounts", NullValueHandling = NullValueHandling.Ignore)]
        public NewItemCounts NewItemCounts { get; set; }

        [JsonProperty("initials")]
        public string Initials { get; set; }

        [JsonProperty("logoUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri LogoUrl { get; set; }
    }

    public partial class NewItemCounts
    {
        [JsonProperty("activityUnread")]
        public long ActivityUnread { get; set; }

        [JsonProperty("messagesUnread", NullValueHandling = NullValueHandling.Ignore)]
        public long? MessagesUnread { get; set; }
    }

    public partial class Owner
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("lastSeen")]
        public string LastSeen { get; set; }

        [JsonProperty("initials")]
        public string Initials { get; set; }

        [JsonProperty("lastSeenIso")]
        public DateTimeOffset LastSeenIso { get; set; }
    }


    public partial class League
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("activeForCurrentSeason")]
        public bool ActiveForCurrentSeason { get; set; }

        [JsonProperty("membershipType")]
        public string MembershipType { get; set; }

        [JsonProperty("rosterRequirements")]
        public RosterRequirements RosterRequirements { get; set; }

        [JsonProperty("waiverType")]
        public string WaiverType { get; set; }

        [JsonProperty("draftBoardUrl")]
        public Uri DraftBoardUrl { get; set; }

        [JsonProperty("maxKeepers")]
        public long MaxKeepers { get; set; }

        [JsonProperty("defaultWaiverBudget")]
        public long DefaultWaiverBudget { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("capacity")]
        public long Capacity { get; set; }

        [JsonProperty("initials")]
        public string Initials { get; set; }
    }

    public partial class RosterRequirements
    {
        [JsonProperty("positions")]
        public Position[] Positions { get; set; }

        [JsonProperty("rosterSize")]
        public long RosterSize { get; set; }

        [JsonProperty("starterCount")]
        public long StarterCount { get; set; }

        [JsonProperty("benchCount")]
        public long BenchCount { get; set; }

        [JsonProperty("reserveCount")]
        public long ReserveCount { get; set; }

        [JsonProperty("eligibility")]
        public string[] Eligibility { get; set; }
    }

    public partial class Position
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; set; }

        [JsonProperty("eligibility", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Eligibility { get; set; }

        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        public long? Min { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public long? Max { get; set; }

        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public long? Start { get; set; }

        [JsonProperty("colors", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Colors { get; set; }
    }

}
