﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BeatLeader.Models;

[Flags]
public enum ReeSabersTags {
    None = 0,
    Minimal = 1 << 1,
    ForVideos = 1 << 2,
    GPUBurner = 1 << 3,
    CustomModel = 1 << 4,
    CustomTrail = 1 << 5
}

public enum ReeSaberReaction {
    None = 0,
    Like = 1
}

public class ReeSabersReaction {
    public int Id { get; set; }
    public required string AuthorId { get; set; }
    public required Player Author { get; set; }
    public int Timeset { get; set; }

    public ReeSaberReaction Reaction { get; set; }
}

public class ReeSabersComment {
    public int Id { get; set; }

    public required string PlayerId { get; set; }
    public required Player Player { get; set; }
    public int Timeset { get; set; }
    public bool Edited { get; set; }
    public int EditTimeset { get; set; }

    public required string Value { get; set; }
    public required ICollection<ReeSabersReaction> Reactions { get; set; }
}

public class ReeSabersPreset {
    public int Id { get; set; }
    public required string OwnerId { get; set; }
    public required Player Owner { get; set; }

    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string CoverLink { get; set; }
    public required string Version { get; set; }

    public required string JsonLinks { get; set; } // comma separated
    public string? TextureLinks { get; set; } // comma separated

    public ReeSabersTags Tags { get; set; }

    public int Timeposted { get; set; }
    public int Timeupdated { get; set; }

    public int DownloadsCount { get; set; }
    public int QuestDownloadsCount { get; set; }
    public int PCDownloadsCount { get; set; }

    public int ReactionsCount { get; set; }
    public required ICollection<ReeSabersReaction> Reactions { get; set; }

    public bool CommentsDisabled { get; set; }
    public int CommentsCount { get; set; }
    public required ICollection<ReeSabersComment> Comments { get; set; }

    public int? RemixId { get; set; }
    public ReeSabersPreset? Remix { get; set; }

    [ForeignKey("RemixId")]
    public ICollection<ReeSabersPreset>? Remixes { get; set; }
}

public class ReePresetDownload {
    public int Id { get; set; }
    public int PresetId { get; set; }
    public string? Player { get; set; }
}