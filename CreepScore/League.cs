﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using CreepScoreAPI.Constants;

namespace CreepScoreAPI
{
    /// <summary>
    /// League class
    /// </summary>
    public class League
    {
        /// <summary>
        /// List of LeagueItem entries
        /// </summary>
        public List<LeagueItem> entries;

        /// <summary>
        /// Name of league
        /// </summary>
        public string name;

        /// <summary>
        /// Queue type as a string
        /// </summary>
        public string queueString;

        /// <summary>
        /// Queue type
        /// </summary>
        public GameConstants.Queue queue;

        /// <summary>
        /// Tier type as a string
        /// </summary>
        public string tierString;

        /// <summary>
        /// Tier type
        /// </summary>
        public GameConstants.Tier tier;

        /// <summary>
        /// League constructor
        /// </summary>
        /// <param name="entriesA">JArray of LeagueItem entries</param>
        /// <param name="name">Name of league</param>
        /// <param name="queueString">Queue type as a string</param>
        /// <param name="tierString">Tier type as a string</param>
        public League(JArray entriesA, string name, string queueString, string tierString)
        {
            entries = new List<LeagueItem>();
            LoadEntries(entriesA);
            this.name = name;
            this.queueString = queueString;
            queue = GameConstants.SetQueue(queueString);
            this.tierString = tierString;
            tier = GameConstants.SetTier(tierString);
        }

        /// <summary>
        /// Load the Entries list
        /// </summary>
        /// <param name="a">The json list of entries</param>
        void LoadEntries(JArray a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                entries.Add(new LeagueItem((bool)a[i]["isFreshBlood"],
                    (bool)a[i]["isHotStreak"],
                    (bool)a[i]["isInactive"],
                    (bool)a[i]["isVeteran"],
                    (long)a[i]["lastPlayed"],
                    (string)a[i]["leagueName"],
                    (int)a[i]["leaguePoints"],
                    (JObject)a[i]["miniSeries"],
                    (string)a[i]["playerOrTeamId"],
                    (string)a[i]["playerOrTeamName"],
                    (string)a[i]["queueType"],
                    (string)a[i]["rank"],
                    (string)a[i]["tier"],
                    (int)a[i]["wins"]));
            }
        }
    }
}