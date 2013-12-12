﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace CreepScore
{
    /// <summary>
    /// CreepScore class
    /// </summary>
    public class CreepScore
    {
        /// <summary>
        /// Base URL
        /// </summary>
        string baseUrl = "https://prod.api.pvp.net/api";

        /// <summary>
        /// lol part of URL
        /// </summary>
        string lolPart = "/lol";

        /// <summary>
        /// Region part. one of: na, euw, eune, (br, tr)
        /// </summary>
        string regionPart = "";

        // one of: v1.1, v2.1
        //string versionPart = "";

        /// <summary>
        /// Summoner ID part of URL
        /// </summary>
        string summonerId = "";

        /// <summary>
        /// Summoner name part of URL
        /// </summary>
        string summonerName = "";

        /// <summary>
        /// API key
        /// </summary>
        string apiKey = "";

        /// <summary>
        /// The list of champion information
        /// </summary>
        public List<Champion> champions;

        /// <summary>
        /// List of loaded summoners
        /// </summary>
        public List<Summoner> summoners;

        // Test strings
        public JObject o = JObject.Parse("{\"id\":26040955,\"name\":\"golf1052\",\"profileIconId\":558,\"summonerLevel\":30,\"revisionDate\":1386673906000,\"revisionDateStr\":\"12/10/2013 11:11 AM UTC\"}");
        public JObject champList = JObject.Parse("{\"champions\":[{\"id\":266,\"name\":\"Aatrox\",\"active\":true,\"attackRank\":8,\"defenseRank\":4,\"magicRank\":3,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":103,\"name\":\"Ahri\",\"active\":true,\"attackRank\":3,\"defenseRank\":4,\"magicRank\":8,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":84,\"name\":\"Akali\",\"active\":true,\"attackRank\":5,\"defenseRank\":3,\"magicRank\":8,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":12,\"name\":\"Alistar\",\"active\":true,\"attackRank\":6,\"defenseRank\":9,\"magicRank\":5,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":32,\"name\":\"Amumu\",\"active\":true,\"attackRank\":2,\"defenseRank\":6,\"magicRank\":8,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":34,\"name\":\"Anivia\",\"active\":true,\"attackRank\":1,\"defenseRank\":4,\"magicRank\":10,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":1,\"name\":\"Annie\",\"active\":true,\"attackRank\":2,\"defenseRank\":3,\"magicRank\":10,\"difficultyRank\":4,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":22,\"name\":\"Ashe\",\"active\":true,\"attackRank\":7,\"defenseRank\":3,\"magicRank\":2,\"difficultyRank\":4,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":53,\"name\":\"Blitzcrank\",\"active\":true,\"attackRank\":4,\"defenseRank\":8,\"magicRank\":5,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":63,\"name\":\"Brand\",\"active\":true,\"attackRank\":2,\"defenseRank\":2,\"magicRank\":9,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":51,\"name\":\"Caitlyn\",\"active\":true,\"attackRank\":8,\"defenseRank\":2,\"magicRank\":2,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":69,\"name\":\"Cassiopeia\",\"active\":true,\"attackRank\":2,\"defenseRank\":3,\"magicRank\":9,\"difficultyRank\":10,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":31,\"name\":\"Chogath\",\"active\":true,\"attackRank\":3,\"defenseRank\":7,\"magicRank\":7,\"difficultyRank\":7,\"botEnabled\":true,\"freeToPlay\":true,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":42,\"name\":\"Corki\",\"active\":true,\"attackRank\":8,\"defenseRank\":3,\"magicRank\":6,\"difficultyRank\":7,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":122,\"name\":\"Darius\",\"active\":true,\"attackRank\":9,\"defenseRank\":5,\"magicRank\":1,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":131,\"name\":\"Diana\",\"active\":true,\"attackRank\":7,\"defenseRank\":6,\"magicRank\":8,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":119,\"name\":\"Draven\",\"active\":true,\"attackRank\":9,\"defenseRank\":3,\"magicRank\":1,\"difficultyRank\":10,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":36,\"name\":\"DrMundo\",\"active\":true,\"attackRank\":5,\"defenseRank\":7,\"magicRank\":6,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":60,\"name\":\"Elise\",\"active\":true,\"attackRank\":6,\"defenseRank\":5,\"magicRank\":7,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":28,\"name\":\"Evelynn\",\"active\":true,\"attackRank\":4,\"defenseRank\":2,\"magicRank\":7,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":81,\"name\":\"Ezreal\",\"active\":true,\"attackRank\":7,\"defenseRank\":2,\"magicRank\":6,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":9,\"name\":\"FiddleSticks\",\"active\":true,\"attackRank\":2,\"defenseRank\":3,\"magicRank\":9,\"difficultyRank\":5,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":114,\"name\":\"Fiora\",\"active\":true,\"attackRank\":10,\"defenseRank\":4,\"magicRank\":2,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":105,\"name\":\"Fizz\",\"active\":true,\"attackRank\":6,\"defenseRank\":4,\"magicRank\":7,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":3,\"name\":\"Galio\",\"active\":true,\"attackRank\":3,\"defenseRank\":7,\"magicRank\":6,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":41,\"name\":\"Gangplank\",\"active\":true,\"attackRank\":7,\"defenseRank\":6,\"magicRank\":4,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":86,\"name\":\"Garen\",\"active\":true,\"attackRank\":7,\"defenseRank\":7,\"magicRank\":1,\"difficultyRank\":2,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":79,\"name\":\"Gragas\",\"active\":true,\"attackRank\":5,\"defenseRank\":6,\"magicRank\":7,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":104,\"name\":\"Graves\",\"active\":true,\"attackRank\":8,\"defenseRank\":5,\"magicRank\":3,\"difficultyRank\":4,\"botEnabled\":true,\"freeToPlay\":true,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":120,\"name\":\"Hecarim\",\"active\":true,\"attackRank\":8,\"defenseRank\":6,\"magicRank\":4,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":74,\"name\":\"Heimerdinger\",\"active\":true,\"attackRank\":2,\"defenseRank\":6,\"magicRank\":8,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":true,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":39,\"name\":\"Irelia\",\"active\":true,\"attackRank\":7,\"defenseRank\":4,\"magicRank\":5,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":true,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":40,\"name\":\"Janna\",\"active\":true,\"attackRank\":3,\"defenseRank\":5,\"magicRank\":7,\"difficultyRank\":9,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":59,\"name\":\"JarvanIV\",\"active\":true,\"attackRank\":6,\"defenseRank\":8,\"magicRank\":3,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":24,\"name\":\"Jax\",\"active\":true,\"attackRank\":7,\"defenseRank\":5,\"magicRank\":7,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":126,\"name\":\"Jayce\",\"active\":true,\"attackRank\":8,\"defenseRank\":4,\"magicRank\":3,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":222,\"name\":\"Jinx\",\"active\":true,\"attackRank\":9,\"defenseRank\":2,\"magicRank\":4,\"difficultyRank\":9,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":43,\"name\":\"Karma\",\"active\":true,\"attackRank\":1,\"defenseRank\":7,\"magicRank\":8,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":true,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":30,\"name\":\"Karthus\",\"active\":true,\"attackRank\":2,\"defenseRank\":2,\"magicRank\":10,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":38,\"name\":\"Kassadin\",\"active\":true,\"attackRank\":3,\"defenseRank\":5,\"magicRank\":8,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":55,\"name\":\"Katarina\",\"active\":true,\"attackRank\":4,\"defenseRank\":3,\"magicRank\":9,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":10,\"name\":\"Kayle\",\"active\":true,\"attackRank\":6,\"defenseRank\":6,\"magicRank\":7,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":85,\"name\":\"Kennen\",\"active\":true,\"attackRank\":6,\"defenseRank\":4,\"magicRank\":7,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":121,\"name\":\"Khazix\",\"active\":true,\"attackRank\":9,\"defenseRank\":4,\"magicRank\":3,\"difficultyRank\":7,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":96,\"name\":\"KogMaw\",\"active\":true,\"attackRank\":8,\"defenseRank\":2,\"magicRank\":5,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":7,\"name\":\"Leblanc\",\"active\":true,\"attackRank\":1,\"defenseRank\":4,\"magicRank\":10,\"difficultyRank\":9,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":64,\"name\":\"LeeSin\",\"active\":true,\"attackRank\":8,\"defenseRank\":5,\"magicRank\":3,\"difficultyRank\":9,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":89,\"name\":\"Leona\",\"active\":true,\"attackRank\":4,\"defenseRank\":8,\"magicRank\":3,\"difficultyRank\":4,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":127,\"name\":\"Lissandra\",\"active\":true,\"attackRank\":2,\"defenseRank\":5,\"magicRank\":8,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":236,\"name\":\"Lucian\",\"active\":true,\"attackRank\":8,\"defenseRank\":5,\"magicRank\":3,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":117,\"name\":\"Lulu\",\"active\":true,\"attackRank\":4,\"defenseRank\":5,\"magicRank\":7,\"difficultyRank\":7,\"botEnabled\":false,\"freeToPlay\":true,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":99,\"name\":\"Lux\",\"active\":true,\"attackRank\":2,\"defenseRank\":4,\"magicRank\":9,\"difficultyRank\":6,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":54,\"name\":\"Malphite\",\"active\":true,\"attackRank\":5,\"defenseRank\":9,\"magicRank\":7,\"difficultyRank\":3,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":90,\"name\":\"Malzahar\",\"active\":true,\"attackRank\":2,\"defenseRank\":2,\"magicRank\":9,\"difficultyRank\":6,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":57,\"name\":\"Maokai\",\"active\":true,\"attackRank\":3,\"defenseRank\":8,\"magicRank\":6,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":11,\"name\":\"MasterYi\",\"active\":true,\"attackRank\":10,\"defenseRank\":4,\"magicRank\":2,\"difficultyRank\":2,\"botEnabled\":true,\"freeToPlay\":true,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":21,\"name\":\"MissFortune\",\"active\":true,\"attackRank\":8,\"defenseRank\":2,\"magicRank\":5,\"difficultyRank\":3,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":62,\"name\":\"MonkeyKing\",\"active\":true,\"attackRank\":8,\"defenseRank\":5,\"magicRank\":2,\"difficultyRank\":3,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":82,\"name\":\"Mordekaiser\",\"active\":true,\"attackRank\":4,\"defenseRank\":6,\"magicRank\":7,\"difficultyRank\":3,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":25,\"name\":\"Morgana\",\"active\":true,\"attackRank\":1,\"defenseRank\":6,\"magicRank\":8,\"difficultyRank\":6,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":267,\"name\":\"Nami\",\"active\":true,\"attackRank\":4,\"defenseRank\":3,\"magicRank\":7,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":75,\"name\":\"Nasus\",\"active\":true,\"attackRank\":7,\"defenseRank\":5,\"magicRank\":6,\"difficultyRank\":2,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":111,\"name\":\"Nautilus\",\"active\":true,\"attackRank\":4,\"defenseRank\":6,\"magicRank\":6,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":76,\"name\":\"Nidalee\",\"active\":true,\"attackRank\":5,\"defenseRank\":4,\"magicRank\":7,\"difficultyRank\":7,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":56,\"name\":\"Nocturne\",\"active\":true,\"attackRank\":9,\"defenseRank\":5,\"magicRank\":2,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":20,\"name\":\"Nunu\",\"active\":true,\"attackRank\":4,\"defenseRank\":6,\"magicRank\":7,\"difficultyRank\":1,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":2,\"name\":\"Olaf\",\"active\":true,\"attackRank\":9,\"defenseRank\":5,\"magicRank\":3,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":61,\"name\":\"Orianna\",\"active\":true,\"attackRank\":4,\"defenseRank\":3,\"magicRank\":9,\"difficultyRank\":10,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":80,\"name\":\"Pantheon\",\"active\":true,\"attackRank\":9,\"defenseRank\":4,\"magicRank\":3,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":78,\"name\":\"Poppy\",\"active\":true,\"attackRank\":6,\"defenseRank\":6,\"magicRank\":5,\"difficultyRank\":7,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":133,\"name\":\"Quinn\",\"active\":true,\"attackRank\":9,\"defenseRank\":4,\"magicRank\":2,\"difficultyRank\":7,\"botEnabled\":false,\"freeToPlay\":true,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":33,\"name\":\"Rammus\",\"active\":true,\"attackRank\":4,\"defenseRank\":10,\"magicRank\":5,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":58,\"name\":\"Renekton\",\"active\":true,\"attackRank\":8,\"defenseRank\":5,\"magicRank\":2,\"difficultyRank\":3,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":107,\"name\":\"Rengar\",\"active\":true,\"attackRank\":7,\"defenseRank\":4,\"magicRank\":2,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":92,\"name\":\"Riven\",\"active\":true,\"attackRank\":8,\"defenseRank\":5,\"magicRank\":1,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":68,\"name\":\"Rumble\",\"active\":true,\"attackRank\":3,\"defenseRank\":6,\"magicRank\":8,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":13,\"name\":\"Ryze\",\"active\":true,\"attackRank\":2,\"defenseRank\":2,\"magicRank\":10,\"difficultyRank\":3,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":113,\"name\":\"Sejuani\",\"active\":true,\"attackRank\":5,\"defenseRank\":7,\"magicRank\":6,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":35,\"name\":\"Shaco\",\"active\":true,\"attackRank\":8,\"defenseRank\":4,\"magicRank\":6,\"difficultyRank\":9,\"botEnabled\":false,\"freeToPlay\":true,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":98,\"name\":\"Shen\",\"active\":true,\"attackRank\":3,\"defenseRank\":9,\"magicRank\":3,\"difficultyRank\":3,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":102,\"name\":\"Shyvana\",\"active\":true,\"attackRank\":8,\"defenseRank\":6,\"magicRank\":3,\"difficultyRank\":4,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":27,\"name\":\"Singed\",\"active\":true,\"attackRank\":4,\"defenseRank\":8,\"magicRank\":7,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":14,\"name\":\"Sion\",\"active\":true,\"attackRank\":5,\"defenseRank\":8,\"magicRank\":7,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":15,\"name\":\"Sivir\",\"active\":true,\"attackRank\":9,\"defenseRank\":3,\"magicRank\":1,\"difficultyRank\":3,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":72,\"name\":\"Skarner\",\"active\":true,\"attackRank\":7,\"defenseRank\":6,\"magicRank\":5,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":37,\"name\":\"Sona\",\"active\":true,\"attackRank\":5,\"defenseRank\":2,\"magicRank\":8,\"difficultyRank\":1,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":16,\"name\":\"Soraka\",\"active\":true,\"attackRank\":2,\"defenseRank\":5,\"magicRank\":7,\"difficultyRank\":3,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":50,\"name\":\"Swain\",\"active\":true,\"attackRank\":2,\"defenseRank\":6,\"magicRank\":9,\"difficultyRank\":5,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":134,\"name\":\"Syndra\",\"active\":true,\"attackRank\":2,\"defenseRank\":3,\"magicRank\":9,\"difficultyRank\":10,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":91,\"name\":\"Talon\",\"active\":true,\"attackRank\":9,\"defenseRank\":3,\"magicRank\":1,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":44,\"name\":\"Taric\",\"active\":true,\"attackRank\":4,\"defenseRank\":8,\"magicRank\":5,\"difficultyRank\":3,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":17,\"name\":\"Teemo\",\"active\":true,\"attackRank\":5,\"defenseRank\":3,\"magicRank\":7,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":412,\"name\":\"Thresh\",\"active\":true,\"attackRank\":5,\"defenseRank\":6,\"magicRank\":6,\"difficultyRank\":7,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":18,\"name\":\"Tristana\",\"active\":true,\"attackRank\":9,\"defenseRank\":3,\"magicRank\":5,\"difficultyRank\":3,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":48,\"name\":\"Trundle\",\"active\":true,\"attackRank\":7,\"defenseRank\":6,\"magicRank\":2,\"difficultyRank\":5,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":23,\"name\":\"Tryndamere\",\"active\":true,\"attackRank\":10,\"defenseRank\":5,\"magicRank\":2,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":4,\"name\":\"TwistedFate\",\"active\":true,\"attackRank\":6,\"defenseRank\":2,\"magicRank\":6,\"difficultyRank\":9,\"botEnabled\":false,\"freeToPlay\":true,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":29,\"name\":\"Twitch\",\"active\":true,\"attackRank\":9,\"defenseRank\":2,\"magicRank\":3,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":77,\"name\":\"Udyr\",\"active\":true,\"attackRank\":8,\"defenseRank\":7,\"magicRank\":4,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":6,\"name\":\"Urgot\",\"active\":true,\"attackRank\":8,\"defenseRank\":5,\"magicRank\":3,\"difficultyRank\":8,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":110,\"name\":\"Varus\",\"active\":true,\"attackRank\":7,\"defenseRank\":3,\"magicRank\":4,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":67,\"name\":\"Vayne\",\"active\":true,\"attackRank\":10,\"defenseRank\":1,\"magicRank\":1,\"difficultyRank\":7,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":45,\"name\":\"Veigar\",\"active\":true,\"attackRank\":2,\"defenseRank\":2,\"magicRank\":10,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":254,\"name\":\"Vi\",\"active\":true,\"attackRank\":8,\"defenseRank\":5,\"magicRank\":3,\"difficultyRank\":5,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":112,\"name\":\"Viktor\",\"active\":true,\"attackRank\":2,\"defenseRank\":5,\"magicRank\":9,\"difficultyRank\":9,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":8,\"name\":\"Vladimir\",\"active\":true,\"attackRank\":2,\"defenseRank\":6,\"magicRank\":8,\"difficultyRank\":2,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":106,\"name\":\"Volibear\",\"active\":true,\"attackRank\":7,\"defenseRank\":7,\"magicRank\":4,\"difficultyRank\":2,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":19,\"name\":\"Warwick\",\"active\":true,\"attackRank\":7,\"defenseRank\":4,\"magicRank\":4,\"difficultyRank\":2,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":101,\"name\":\"Xerath\",\"active\":true,\"attackRank\":1,\"defenseRank\":3,\"magicRank\":10,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":5,\"name\":\"XinZhao\",\"active\":true,\"attackRank\":8,\"defenseRank\":6,\"magicRank\":3,\"difficultyRank\":3,\"botEnabled\":true,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":83,\"name\":\"Yorick\",\"active\":true,\"attackRank\":6,\"defenseRank\":6,\"magicRank\":6,\"difficultyRank\":3,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":154,\"name\":\"Zac\",\"active\":true,\"attackRank\":3,\"defenseRank\":7,\"magicRank\":7,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":238,\"name\":\"Zed\",\"active\":true,\"attackRank\":9,\"defenseRank\":2,\"magicRank\":1,\"difficultyRank\":9,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":false,\"rankedPlayEnabled\":true},{\"id\":115,\"name\":\"Ziggs\",\"active\":true,\"attackRank\":2,\"defenseRank\":4,\"magicRank\":9,\"difficultyRank\":6,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":26,\"name\":\"Zilean\",\"active\":true,\"attackRank\":2,\"defenseRank\":5,\"magicRank\":8,\"difficultyRank\":4,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true},{\"id\":143,\"name\":\"Zyra\",\"active\":true,\"attackRank\":4,\"defenseRank\":3,\"magicRank\":8,\"difficultyRank\":7,\"botEnabled\":false,\"freeToPlay\":false,\"botMmEnabled\":true,\"rankedPlayEnabled\":true}]}");

        /// <summary>
        /// Region types
        /// </summary>
        public enum Region
        {
            None,
            NA,
            EUW,
            EUNE
        }

        /// <summary>
        /// Map types
        /// </summary>
        public enum Map
        {
            None,
            SummonersRiftSummer,
            SummonersRiftAutumn,
            TheProvingGrounds,
            TwistedTreelineOriginal,
            TheCrystalScar,
            TwistedTreelineCurrent,
            HowlingAbyss
        }

        /// <summary>
        /// Game mode types
        /// </summary>
        public enum GameMode
        {
            None,
            Classic,
            Dominion,
            Aram,
            Tutorial
        }

        /// <summary>
        /// Queue types
        /// </summary>
        public enum Queue
        {
            None,
            Solo5,
            Team3,
            Team5
        }

        /// <summary>
        /// Tier types
        /// </summary>
        public enum Tier
        {
            None,
            Challenger,
            Diamond,
            Platinum,
            Gold,
            Silver,
            Bronze
            //Wood
            //Dirt
        }

        /// <summary>
        /// CreepScore constructor
        /// </summary>
        /// <param name="key">Your API key</param>
        public CreepScore(string key)
        {
            champions = new List<Champion>();
            summoners = new List<Summoner>();
            apiKey = key;
            //LoadChampions(champList);
        }

        public void RetrieveChampions(Region region)
        {
            Uri uri = new Uri(baseUrl + lolPart + "/" + GetRegion(region) + "/" + "v1.1" + "/champion" + "?api_key=" + apiKey);
            BeginWebRequest(uri);
        }

        void BeginWebRequest(Uri uri)
        {
            HttpWebRequest req = WebRequest.CreateHttp(uri);
            req.BeginGetResponse(new AsyncCallback(EndWebRequest), req);
        }

        void EndWebRequest(IAsyncResult result)
        {
            HttpWebResponse resp = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                // 200 - OK
                Stream responseStream = resp.GetResponseStream();
                StreamReader readStream = new StreamReader(responseStream);
                LoadChampions((JObject)JToken.ReadFrom(new JsonTextReader(readStream)));
            }
            else if (resp.StatusCode == HttpStatusCode.BadRequest)
            {
                // 400 - Bad request
            }
            else if (resp.StatusCode == HttpStatusCode.Unauthorized)
            {
                // 401 - Unauthoriezed
            }
            else if (resp.StatusCode == HttpStatusCode.NotFound)
            {
                // 404 - Summoner not found
            }
            else if (resp.StatusCode == HttpStatusCode.InternalServerError)
            {
                // 500 - Internal server error
            }
        }

        /// <summary>
        /// Loads a champion
        /// </summary>
        /// <param name="o">json object representing a champion</param>
        public void LoadChampions(JObject o)
        {
            for (int i = 0; i < o["champions"].Count(); i++)
            {
                champions.Add(new Champion((bool)o["champions"][i]["active"],
                    (int)o["champions"][i]["attackRank"],
                    (bool)o["champions"][i]["botEnabled"],
                    (bool)o["champions"][i]["botMmEnabled"],
                    (int)o["champions"][i]["defenseRank"],
                    (int)o["champions"][i]["difficultyRank"],
                    (bool)o["champions"][i]["freeToPlay"],
                    (long)o["champions"][i]["id"],
                    (int)o["champions"][i]["magicRank"],
                    (string)o["champions"][i]["name"],
                    (bool)o["champions"][i]["rankedPlayEnabled"]));
            }
        }

        /// <summary>
        /// Gets the region
        /// </summary>
        /// <param name="region">Region</param>
        /// <returns>Returns a string representing a region</returns>
        public string GetRegion(Region region)
        {
            if (region == Region.None)
            {
                return "none";
            }
            else if (region == Region.NA)
            {
                return "na";
            }
            else if (region == Region.EUW)
            {
                return "euw";
            }
            else if (region == Region.EUNE)
            {
                return "eune";
            }
            else
            {
                return "other";
            }
        }

        /// <summary>
        /// Converts a epoch date time to a C# DateTime
        /// </summary>
        /// <param name="date">Date as a epoch time</param>
        /// <returns>A C# DateTime</returns>
        public static DateTime EpochToDateTime(long date)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(date);
        }

        /// <summary>
        /// Turns a gameMode string into a GameMode enum
        /// </summary>
        /// <param name="gameModeStr">GameMode string</param>
        /// <returns>GameMode enum</returns>
        public static GameMode SetGameMode(string gameModeStr)
        {
            if (gameModeStr == "CLASSIC")
            {
                return GameMode.Classic;
            }
            else if (gameModeStr == "ODIN")
            {
                return GameMode.Dominion;
            }
            else if (gameModeStr == "ARAM")
            {
                return GameMode.Aram;
            }
            else if (gameModeStr == "TUTORIAL")
            {
                return GameMode.Tutorial;
            }
            else
            {
                return GameMode.None;
            }
        }

        /// <summary>
        /// Tuns a mapID int into a Map enum
        /// </summary>
        /// <param name="mapInt">MapId int</param>
        /// <returns>Map enum</returns>
        public static Map SetMap(int mapInt)
        {
            if (mapInt == 1)
            {
                return Map.SummonersRiftSummer;
            }
            else if (mapInt == 2)
            {
                return Map.SummonersRiftAutumn;
            }
            else if (mapInt == 3)
            {
                return Map.TheProvingGrounds;
            }
            else if (mapInt == 4)
            {
                return Map.TwistedTreelineOriginal;
            }
            else if (mapInt == 8)
            {
                return Map.TheCrystalScar;
            }
            else if (mapInt == 10)
            {
                return Map.TwistedTreelineCurrent;
            }
            else if (mapInt == 12)
            {
                return Map.HowlingAbyss;
            }
            else
            {
                return Map.None;
            }
        }

        /// <summary>
        /// Set the Queue field
        /// </summary>
        /// <param name="queueStr">The queue type as a string</param>
        public static Queue SetQueue(string queueStr)
        {
            if (queueStr == "RANKED_SOLO_5x5")
            {
                return Queue.Solo5;
            }
            else if (queueStr == "RANKED_TEAM_3x3")
            {
                return Queue.Team3;
            }
            else if (queueStr == "RANKED_TEAM_5x5")
            {
                return Queue.Team5;
            }
            else
            {
                return Queue.None;
            }
        }

        /// <summary>
        /// Set the Tier field
        /// </summary>
        /// <param name="tierStr">The tier type as a string</param>
        public static Tier SetTier(string tierStr)
        {
            if (tierStr == "CHALLENGER")
            {
                return Tier.Challenger;
            }
            else if (tierStr == "DIAMOND")
            {
                return Tier.Diamond;
            }
            else if (tierStr == "PLATINUM")
            {
                return Tier.Platinum;
            }
            else if (tierStr == "GOLD")
            {
                return Tier.Gold;
            }
            else if (tierStr == "SILVER")
            {
                return Tier.Silver;
            }
            else if (tierStr == "BRONZE")
            {
                return Tier.Bronze;
            }
            else
            {
                return Tier.None;
            }
        }
    }
}
