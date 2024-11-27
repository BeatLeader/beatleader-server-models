using BeatLeader_Server.Models;
using Newtonsoft.Json;
using System.Linq.Expressions;
using static BeatLeader_Server.Utils.ResponseUtils;
using ReplayDecoder;

namespace BeatLeader_Server.Utils
{
    public class ScoreResponse
    {
        public int? Id { get; set; }
        public int BaseScore { get; set; }
        public int ModifiedScore { get; set; }
        public float Accuracy { get; set; }
        public string PlayerId { get; set; }
        public float Pp { get; set; }
        public float BonusPp { get; set; }
        public float PassPP { get; set; }
        public float AccPP { get; set; }
        public float TechPP { get; set; }
        public int Rank { get; set; }
        public int ResponseRank { get; set; }
        public string? Country { get; set; }
        public float FcAccuracy { get; set; }
        public float FcPp { get; set; }
        public float Weight { get; set; }
        public string Replay { get; set; }
        public string Modifiers { get; set; }
        public int BadCuts { get; set; }
        public int MissedNotes { get; set; }
        public int BombCuts { get; set; }
        public int WallsHit { get; set; }
        public int Pauses { get; set; }
        public bool FullCombo { get; set; }
        public string Platform { get; set; }
        public int MaxCombo { get; set; }
        public int? MaxStreak { get; set; }
        public HMD Hmd { get; set; }
        public ControllerEnum Controller { get; set; }
        public string LeaderboardId { get; set; }
        public string Timeset { get; set; }
        public int Timepost { get; set; }
        public int ReplaysWatched { get; set; }
        public int PlayCount { get; set; }
        public int LastTryTime { get; set; }
        [JsonIgnore]
        public int Priority { get; set; }
        public PlayerResponse? Player { get; set; }
        public ScoreImprovement? ScoreImprovement { get; set; }
        public RankVoting? RankVoting { get; set; }
        public ScoreMetadata? Metadata { get; set; }
        public ReplayOffsets? Offsets { get; set; }

        public void ToContext(ScoreContextExtension? extension)
        {
            if (extension == null) return;

            Weight = extension.Weight;
            Rank = extension.Rank;
            BaseScore = extension.BaseScore;
            ModifiedScore = extension.ModifiedScore;
            Accuracy = extension.Accuracy;
            Pp = extension.Pp;
            TechPP = extension.TechPP;
            PassPP = extension.PassPP;
            BonusPp = extension.BonusPp;
            Modifiers = extension.Modifiers;
        }
    }

    public class ScoreResponseWithAcc : ScoreResponse
    {
        public float AccLeft { get; set; }
        public float AccRight { get; set; }
    }

    public class ScoreResponseWithHeadsets : ScoreResponse
    {
        public string? HeadsetName { get; set; }
        public string? ControllerName { get; set; }

        public void FillNames() {
            HeadsetName = Hmd switch {
                HMD.rift => "Oculus Rift",
                HMD.riftS => "Oculus Rift S", 
                HMD.quest => "Meta Quest",
                HMD.quest2 => "Meta Quest 2",
                HMD.quest3 => "Meta Quest 3",
                HMD.quest3s => "Meta Quest 3S",
                HMD.questPro => "Meta Quest Pro",
                HMD.vive => "HTC Vive",
                HMD.vivePro => "HTC Vive Pro",
                HMD.vivePro2 => "HTC Vive Pro 2",
                HMD.viveCosmos => "HTC Vive Cosmos",
                HMD.viveElite => "HTC Vive Elite",
                HMD.viveFocus => "HTC Vive Focus",
                HMD.viveDvt => "HTC Vive DVT",
                HMD.wmr => "WMR",
                HMD.hpReverb => "HP Reverb",
                HMD.samsungWmr => "Samsung Odyssey",
                HMD.lenovoExplorer => "Lenovo Explorer",
                HMD.acerWmr => "Acer WMR",
                HMD.dellVisor => "Dell Visor",
                HMD.asusWmr => "ASUS WMR",
                HMD.picoNeo2 => "Pico Neo 2",
                HMD.picoNeo3 => "Pico Neo 3",
                HMD.picoNeo4 => "Pico Neo 4",
                HMD.pimax8k => "Pimax 8K",
                HMD.pimax5k => "Pimax 5K",
                HMD.pimaxArtisan => "Pimax Artisan",
                HMD.pimaxCrystal => "Pimax Crystal",
                HMD.index => "Valve Index",
                HMD.psvr2 => "PlayStation VR2",
                HMD.varjoaero => "Varjo Aero",
                HMD.bigscreenbeyond => "Bigscreen Beyond",
                HMD.controllable => "Controllable",
                _ => null
            };

            ControllerName = Controller switch {
                ControllerEnum.oculustouch => "Oculus Touch",
                ControllerEnum.oculustouch2 => "Oculus Touch 2",
                ControllerEnum.quest2 => "Oculus Touch",
                ControllerEnum.vive => "Vive Wands",
                ControllerEnum.vivePro => "Vive Pro Wands",
                ControllerEnum.wmr => "WMR Controllers",
                ControllerEnum.odyssey => "Odyssey Controllers",
                ControllerEnum.hpMotion => "HP Motion",
                ControllerEnum.picoNeo3 => "Pico Neo 3 Controllers",
                ControllerEnum.picoNeo2 => "Pico Neo 2 Controllers", 
                ControllerEnum.vivePro2 => "Vive Pro 2 Wands",
                ControllerEnum.miramar => "Oculus Touch",
                ControllerEnum.disco => "Disco",
                ControllerEnum.questPro => "Touch Pro",
                ControllerEnum.viveTracker => "Vive Tracker",
                ControllerEnum.viveTracker2 => "Vive Tracker 2",
                ControllerEnum.knuckles => "Knuckles",
                ControllerEnum.nolo => "Nolo",
                ControllerEnum.picophoenix => "Pico Phoenix",
                ControllerEnum.hands => "Hands",
                ControllerEnum.viveTracker3 => "Vive Tracker 3",
                ControllerEnum.pimax => "Pimax",
                ControllerEnum.huawei => "Huawei",
                ControllerEnum.polaris => "Polaris",
                ControllerEnum.tundra => "Tundra",
                ControllerEnum.cry => "Cry",
                ControllerEnum.e4 => "E4",
                ControllerEnum.gamepad => "Gamepad",
                ControllerEnum.joycon => "Joy-Con",
                ControllerEnum.steamdeck => "Steam Deck",
                ControllerEnum.etee => "Etee",
                ControllerEnum.quest3 => "Quest 3 Touch",
                ControllerEnum.contactglove => "Contact Glove",
                ControllerEnum.viveCosmos => "Cosmos Controllers",
                _ => null
            };
        }
    }

    public class ScoreResponseWithMyScore : ScoreResponseWithAcc
    {
        public ScoreResponseWithAcc? MyScore { get; set; }
        public LeaderboardContexts ValidContexts { get; set; }

        public CompactLeaderboardResponse Leaderboard { get; set; }
    }

    public class AttemptResponseWithMyScore : ScoreResponseWithAcc
    {
        public ScoreResponseWithAcc? MyScore { get; set; }
        public EndType EndType { get; set; }
        public int AttemptsCount { get; set; }
        public float Time { get; set; }
        public float StartTime { get; set; }

        public CompactLeaderboardResponse Leaderboard { get; set; }
    }

    public class ScoreContextExtensionResponse
    {
        public int Id { get; set; }
        public string PlayerId { get; set; }
        
        public float Weight { get; set; }
        public int Rank { get; set; }
        public int BaseScore { get; set; }
        public int ModifiedScore { get; set; }
        public float Accuracy { get; set; }
        public float Pp { get; set; }
        public float PassPP { get; set; }
        public float AccPP { get; set; }
        public float TechPP { get; set; }
        public float BonusPp { get; set; }
        public string? Modifiers { get; set; }

        public LeaderboardContexts Context { get; set; }
        public ScoreImprovement? ScoreImprovement { get; set; }
    }

    public class ScoreResponseWithMyScoreAndContexts : ScoreResponseWithMyScore
    {
        public ICollection<ScoreContextExtensionResponse> ContextExtensions { get; set; }
    }

    public static class ScoreResponseQuery
    {
        public static Expression<Func<Score, ScoreResponseWithMyScore>> SelectWithMyScore()
        {
            return s => new ScoreResponseWithMyScore
            {
                Id = s.Id,
                BaseScore = s.BaseScore,
                ModifiedScore = s.ModifiedScore,
                PlayerId = s.PlayerId,
                Accuracy = s.Accuracy,
                Pp = s.Pp,
                PassPP = s.PassPP,
                AccPP = s.AccPP,
                TechPP = s.TechPP,
                FcAccuracy = s.FcAccuracy,
                FcPp = s.FcPp,
                BonusPp = s.BonusPp,
                Rank = s.Rank,
                Replay = s.Replay,
                Modifiers = s.Modifiers,
                BadCuts = s.BadCuts,
                MissedNotes = s.MissedNotes,
                BombCuts = s.BombCuts,
                WallsHit = s.WallsHit,
                Pauses = s.Pauses,
                FullCombo = s.FullCombo,
                Hmd = s.Hmd,
                Controller = s.Controller,
                MaxCombo = s.MaxCombo,
                Timeset = s.Timeset,
                ReplaysWatched = s.AnonimusReplayWatched + s.AuthorizedReplayWatched,
                Timepost = s.Timepost,
                LeaderboardId = s.LeaderboardId,
                Platform = s.Platform,
                Player = new PlayerResponse
                {
                    Id = s.Player.Id,
                    Name = s.Player.Name,
                    Alias = s.Player.Alias,
                    Platform = s.Player.Platform,
                    Avatar = s.Player.Avatar,
                    Country = s.Player.Country,

                    Pp = s.Player.Pp,
                    Rank = s.Player.Rank,
                    CountryRank = s.Player.CountryRank,
                    Role = s.Player.Role,
                    Socials = s.Player.Socials,
                    PatreonFeatures = s.Player.PatreonFeatures,
                    ProfileSettings = s.Player.ProfileSettings,
                    ClanOrder = s.Player.ClanOrder,
                    Clans = s.Player.Clans.Select(c => new ClanResponse { Id = c.Id, Tag = c.Tag, Color = c.Color })
                },
                ScoreImprovement = s.ScoreImprovement,
                RankVoting = s.RankVoting,
                Metadata = s.Metadata,
                Country = s.Country,
                Offsets = s.ReplayOffsets,
                Leaderboard = new CompactLeaderboardResponse
                {
                    Id = s.LeaderboardId,
                    Song = new CompactSongResponse {
                        Id = s.Leaderboard.Song.Id,
                        Hash = s.Leaderboard.Song.Hash,
                        Name = s.Leaderboard.Song.Name,
            
                        SubName = s.Leaderboard.Song.SubName,
                        Author = s.Leaderboard.Song.Author,
                        Mapper = s.Leaderboard.Song.Mapper,
                        MapperId = s.Leaderboard.Song.MapperId,
                        CollaboratorIds = s.Leaderboard.Song.CollaboratorIds,
                        CoverImage = s.Leaderboard.Song.CoverImage,
                        FullCoverImage = s.Leaderboard.Song.FullCoverImage,
                        Bpm = s.Leaderboard.Song.Bpm,
                        Duration = s.Leaderboard.Song.Duration,
                    },
                    Difficulty = new DifficultyResponse
                    {
                        Id = s.Leaderboard.Difficulty.Id,
                        Value = s.Leaderboard.Difficulty.Value,
                        Mode = s.Leaderboard.Difficulty.Mode,
                        DifficultyName = s.Leaderboard.Difficulty.DifficultyName,
                        ModeName = s.Leaderboard.Difficulty.ModeName,
                        Status = s.Leaderboard.Difficulty.Status,
                        ModifierValues = s.Leaderboard.Difficulty.ModifierValues,
                        ModifiersRating = s.Leaderboard.Difficulty.ModifiersRating,
                        NominatedTime = s.Leaderboard.Difficulty.NominatedTime,
                        QualifiedTime = s.Leaderboard.Difficulty.QualifiedTime,
                        RankedTime = s.Leaderboard.Difficulty.RankedTime,

                        Stars = s.Leaderboard.Difficulty.Stars,
                        PredictedAcc = s.Leaderboard.Difficulty.PredictedAcc,
                        PassRating = s.Leaderboard.Difficulty.PassRating,
                        AccRating = s.Leaderboard.Difficulty.AccRating,
                        TechRating = s.Leaderboard.Difficulty.TechRating,
                        Type = s.Leaderboard.Difficulty.Type,

                        Njs = s.Leaderboard.Difficulty.Njs,
                        Nps = s.Leaderboard.Difficulty.Nps,
                        Notes = s.Leaderboard.Difficulty.Notes,
                        Bombs = s.Leaderboard.Difficulty.Bombs,
                        Walls = s.Leaderboard.Difficulty.Walls,
                        MaxScore = s.Leaderboard.Difficulty.MaxScore,
                        Duration = s.Leaderboard.Difficulty.Duration,

                        Requirements = s.Leaderboard.Difficulty.Requirements,
                    }
                },
                Weight = s.Weight,
                AccLeft = s.AccLeft,
                AccRight = s.AccRight,
                MaxStreak = s.MaxStreak
            };
        }

        public static Expression<Func<Score, ScoreResponseWithAcc>> SelectWithAcc() 
        {
            return s => new ScoreResponseWithAcc
            {
                Id = s.Id,
                BaseScore = s.BaseScore,
                ModifiedScore = s.ModifiedScore,
                PlayerId = s.PlayerId,
                Accuracy = s.Accuracy,
                Pp = s.Pp,
                PassPP = s.PassPP,
                AccPP = s.AccPP,
                TechPP = s.TechPP,
                FcAccuracy = s.FcAccuracy,
                FcPp = s.FcPp,
                BonusPp = s.BonusPp,
                Rank = s.Rank,
                Replay = s.Replay,
                Modifiers = s.Modifiers,
                BadCuts = s.BadCuts,
                MissedNotes = s.MissedNotes,
                BombCuts = s.BombCuts,
                WallsHit = s.WallsHit,
                Pauses = s.Pauses,
                FullCombo = s.FullCombo,
                Hmd = s.Hmd,
                Controller = s.Controller,
                MaxCombo = s.MaxCombo,
                Timeset = s.Timeset,
                ReplaysWatched = s.AnonimusReplayWatched + s.AuthorizedReplayWatched,
                Timepost = s.Timepost,
                LeaderboardId = s.LeaderboardId,
                Platform = s.Platform,
                Player = new PlayerResponse
                {
                    Id = s.Player.Id,
                    Name = s.Player.Name,
                    Alias = s.Player.Alias,
                    Platform = s.Player.Platform,
                    Avatar = s.Player.Avatar,
                    Country = s.Player.Country,

                    Pp = s.Player.Pp,
                    Rank = s.Player.Rank,
                    CountryRank = s.Player.CountryRank,
                    Role = s.Player.Role,
                    Socials = s.Player.Socials,
                    PatreonFeatures = s.Player.PatreonFeatures,
                    ProfileSettings = s.Player.ProfileSettings,
                    ClanOrder = s.Player.ClanOrder,
                    Clans = s.Player.Clans.Select(c => new ClanResponse { Id = c.Id, Tag = c.Tag, Color = c.Color })
                },
                ScoreImprovement = s.ScoreImprovement,
                RankVoting = s.RankVoting,
                Metadata = s.Metadata,
                Country = s.Country,
                Offsets = s.ReplayOffsets,
                Weight = s.Weight,
                AccLeft = s.AccLeft,
                AccRight = s.AccRight,
                MaxStreak = s.MaxStreak
            };
        }
    }
}
