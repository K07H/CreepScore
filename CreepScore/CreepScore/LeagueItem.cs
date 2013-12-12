﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CreepScore
{
    /// <summary>
    /// LeagueItem class
    /// </summary>
    public class LeagueItem
    {
        /// <summary>
        /// Is fresh blood?
        /// </summary>
        public bool isFreshBlood;

        /// <summary>
        /// Is hot streak?
        /// </summary>
        public bool isHotStreak;

        /// <summary>
        /// Is inactive?
        /// </summary>
        public bool isInactive;

        /// <summary>
        /// Is veteran?
        /// </summary>
        public bool isVeteran;

        /// <summary>
        /// Last played date specified as epoch milliseconds
        /// </summary>
        public long lastPlayedLong;

        /// <summary>
        /// Last played date
        /// </summary>
        public DateTime lastPlayed;

        /// <summary>
        /// League name
        /// </summary>
        public string leagueName;

        /// <summary>
        /// Number of league points
        /// </summary>
        public int leaguePoints;

        /// <summary>
        /// Number of losses
        /// </summary>
        public int losses;

        /// <summary>
        /// If not null the player/team is in a mini series
        /// </summary>
        public MiniSeries miniSeries;

        /// <summary>
        /// Player or team ID
        /// </summary>
        public string playerOrTeamId;

        /// <summary>
        /// Player or team name
        /// </summary>
        public string playerOrTeamName;

        /// <summary>
        /// Queue type as a string
        /// </summary>
        public string queueTypeString;

        /// <summary>
        /// Queue type
        /// </summary>
        public CreepScore.Queue queueType;

        /// <summary>
        /// Rank
        /// </summary>
        public string rank;

        /// <summary>
        /// Tier as a string
        /// </summary>
        public string tierString;

        /// <summary>
        /// Tier
        /// </summary>
        public CreepScore.Tier tier;

        /// <summary>
        /// Time until decay date specified as epoch milliseconds
        /// </summary>
        public long timeUntilDecayLong;

        /// <summary>
        /// Time until decay as a DateTime
        /// </summary>
        /// <remarks>I do not know if this should be a TimeSpan or a DateTime</remarks>
        public DateTime timeUntilDecay;

        /// <summary>
        /// Number of wins
        /// </summary>
        public int wins;

        /// <summary>
        /// League Item constructor
        /// </summary>
        /// <param name="isFreshBlood">Is fresh blood?</param>
        /// <param name="isHotStreak">Is hot streak?</param>
        /// <param name="isInactive">Is inactive?</param>
        /// <param name="isVeteran">Is veteran?</param>
        /// <param name="lastPlayedLong">Last played date specified as epoch milliseconds</param>
        /// <param name="leagueName">League name</param>
        /// <param name="leaguePoints">Number of league points</param>
        /// <param name="losses">Number of losses</param>
        /// <param name="miniSeriesO">JObject representing the miniseries</param>
        /// <param name="playerOrTeamId">Player or team ID</param>
        /// <param name="playerOrTeamName">Player or team name</param>
        /// <param name="queueTypeString">Queue type as a string</param>
        /// <param name="rank">Rank</param>
        /// <param name="tierString">Tier as a string</param>
        /// <param name="timeUntilDecayLong">Time until decay date specified as epoch milliseconds</param>
        /// <param name="wins">Number of wins</param>
        public LeagueItem(bool isFreshBlood,
            bool isHotStreak,
            bool isInactive,
            bool isVeteran,
            long lastPlayedLong,
            string leagueName,
            int leaguePoints,
            int losses,
            JObject miniSeriesO,
            string playerOrTeamId,
            string playerOrTeamName,
            string queueTypeString,
            string rank,
            string tierString,
            long timeUntilDecayLong,
            int wins)
        {
            this.isFreshBlood = isFreshBlood;
            this.isHotStreak = isHotStreak;
            this.isInactive = isInactive;
            this.isVeteran = isVeteran;
            this.lastPlayedLong = lastPlayedLong;
            lastPlayed = CreepScore.EpochToDateTime(lastPlayedLong);
            this.leagueName = leagueName;
            this.leaguePoints = leaguePoints;
            this.losses = losses;
            LoadMiniSeries(miniSeriesO);
            this.playerOrTeamId = playerOrTeamId;
            this.playerOrTeamName = playerOrTeamName;
            this.queueTypeString = queueTypeString;
            this.rank = rank;
            this.tierString = tierString;
            this.timeUntilDecayLong = timeUntilDecayLong;
            timeUntilDecay = CreepScore.EpochToDateTime(timeUntilDecayLong);
            //timeUntilDecay = TimeSpan.FromMilliseconds(timeUntilDecayLong);
            this.wins = wins;
        }

        /// <summary>
        /// Load MiniSeries if the player is in one
        /// </summary>
        /// <param name="o">The json object representing the miniseries</param>
        /// <remarks>If the player is not in a miniseries o will be null</remarks>
        void LoadMiniSeries(JObject o)
        {
            if (o != null)
            {
                miniSeries = new MiniSeries((int)o["losses"], ((string)o["progress"]).ToCharArray(), (int)o["target"], (long)o["timeLeftToPlayMillis"], (int)o["wins"]);
            }
        }
    }
}
