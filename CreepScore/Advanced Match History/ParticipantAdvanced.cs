﻿using System;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{
    public class ParticipantAdvanced
    {
        /// <summary>
        /// Champion ID
        /// </summary>
        public int championId;

        /// <summary>
        /// Participant ID
        /// </summary>
        public int participantId;

        /// <summary>
        /// First summoner spell ID
        /// </summary>
        public int spell1Id;

        /// <summary>
        /// Second summoner spell ID
        /// </summary>
        public int spell2Id;

        /// <summary>
        /// Participant statistics
        /// </summary>
        public ParticipantStatsAdvanced stats;

        /// <summary>
        /// Team ID
        /// </summary>
        public int teamId;

        /// <summary>
        /// Timeline data
        /// </summary>
        public ParticipantTimelineAdvanced timeline;

        public ParticipantAdvanced(int championId,
            int participantId,
            int spell1Id,
            int spell2Id,
            JObject stats,
            int teamId,
            JObject timeline)
        {
            this.championId = championId;
            this.participantId = participantId;
            this.spell1Id = spell1Id;
            this.spell2Id = spell2Id;
            if (stats != null)
            {
                this.stats = LoadStats(stats);
            }
            this.teamId = teamId;
            if (timeline != null)
            {
                this.timeline = LoadTimeline(timeline);
            }
        }

        ParticipantStatsAdvanced LoadStats(JObject o)
        {
            return new ParticipantStatsAdvanced((long?)o["assists"],
                (long?)o["champLevel"],
                (long?)o["combatPlayerScore"],
                (long?)o["deaths"],
                (long?)o["doubleKills"],
                (bool?)o["firstBloodAssist"],
                (bool?)o["firstBloodKill"],
                (bool?)o["firstInhibitorAssist"],
                (bool?)o["firstInhibitorKill"],
                (bool?)o["firstTowerAssist"],
                (bool?)o["firstTowerKill"],
                (long?)o["goldEarned"],
                (long?)o["goldSpent"],
                (long?)o["inhibitorKills"],
                (long?)o["item0"],
                (long?)o["item1"],
                (long?)o["item2"],
                (long?)o["item3"],
                (long?)o["item4"],
                (long?)o["item5"],
                (long?)o["item6"],
                (long?)o["killingSprees"],
                (long?)o["kills"],
                (long?)o["largestCriticalStrike"],
                (long?)o["largestKillingSpree"],
                (long?)o["largestMultiKill"],
                (long?)o["magicDamageDealt"],
                (long?)o["magicDamageDealtToChampions"],
                (long?)o["magicDamageTaken"],
                (long?)o["minionsKilled"],
                (long?)o["neutralMinionsKilled"],
                (long?)o["neutralMinionsKilledEnemyJungle"],
                (long?)o["neutralMinionsKilledTeamJungle"],
                (long?)o["nodeCapture"],
                (long?)o["nodeCaptureAssist"],
                (long?)o["nodeNeutralize"],
                (long?)o["nodeNeutralizeAssist"],
                (long?)o["objectivePlayerScore"],
                (long?)o["pentaKills"],
                (long?)o["physicalDamageDealt"],
                (long?)o["physicalDamageDealtToChampions"],
                (long?)o["physicalDamageTaken"],
                (long?)o["quadraKills"],
                (long?)o["sightWardsBoughtInGame"],
                (long?)o["teamObjective"],
                (long?)o["totalDamageDealt"],
                (long?)o["totalDamageDealtToChampions"],
                (long?)o["totalDamageTaken"],
                (long?)o["totalHeal"],
                (long?)o["totalPlayerScore"],
                (long?)o["totalScoreRank"],
                (long?)o["totalTimeCrowdControlDealt"],
                (long?)o["totalUnitsHealed"],
                (long?)o["towerKills"],
                (long?)o["tripleKills"],
                (long?)o["trueDamageDealt"],
                (long?)o["trueDamageDealtToChampions"],
                (long?)o["trueDamageTaken"],
                (long?)o["unrealKills"],
                (long?)o["visionWardsBoughtInGame"],
                (long?)o["wardsKilled"],
                (long?)o["wardsPlaced"],
                (bool?)o["winner"]);
        }

        ParticipantTimelineAdvanced LoadTimeline(JObject o)
        {
            return new ParticipantTimelineAdvanced((JObject)o["ancientGolemAssistsPerMinCountsO"],
                (JObject)o["ancientGolemKillsPerMinCountsO"],
                (JObject)o["assistedLaneDeathsPerMinDeltasO"],
                (JObject)o["assistedLaneKillsPerMinDeltasO"],
                (JObject)o["baronAssistsPerMinCountsO"],
                (JObject)o["baronKillsPerMinCountsO"],
                (JObject)o["creepsPerMinDeltasO"],
                (JObject)o["csDiffPerMinDeltasO"],
                (JObject)o["damageTakenDiffPerMinDeltasO"],
                (JObject)o["damageTakenPerMinDeltasO"],
                (JObject)o["dragonAssistsPerMinCountsO"],
                (JObject)o["dragonKillsPerMinCountsO"],
                (JObject)o["elderLizardAssistsPerMinCountsO"],
                (JObject)o["elderLizardKillsPerMinCountsO"],
                (JObject)o["goldPerMinDeltasO"],
                (JObject)o["inhibitorAssistsPerMinCountsO"],
                (JObject)o["inhibitorKillsPerMinCountsO"],
                (string)o["lane"],
                (string)o["role"],
                (JObject)o["towerAssistsPerMinCountsO"],
                (JObject)o["towerKillsPerMinCountsO"],
                (JObject)o["towerKillsPerMinDeltasO"],
                (JObject)o["vilemawAssistsPerMinCountsO"],
                (JObject)o["vilemawKillsPerMinCountsO"],
                (JObject)o["wardsPerMinDeltasO"],
                (JObject)o["xpDiffPerMinDeltasO"],
                (JObject)o["xpPerMinDeltasO"]);
        }
    }
}
