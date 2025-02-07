using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeatLeader_Server.Models {
    [Flags]
    public enum MapperStatus {
        None = 0,
        Verified = 1 << 1,
        Curator = 1 << 2,
        Ranked = 1 << 3,
        Team = 1 << 4,
    }
    public class Mapper : TrackedEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string Name { get; set; }
        [StringLength(200, MinimumLength = 0)]
        public string Avatar { get; set; }
        public bool? Curator { get; set; }
        public bool VerifiedMapper { get; set; }
        [StringLength(200, MinimumLength = 0)]
        public string? PlaylistUrl { get; set; }

        public ICollection<Song>? Songs { get; set; }
        public MapperStatus Status { get; set; }

        public Player? Player { get; set; }

        public static Mapper MapperFromBeatSaverUser(UserDetail mapper) {
            return new Mapper {
                Id = mapper.Id,
                Name = mapper.Name,
                Avatar = mapper.Avatar,
                Curator = mapper.Curator,
                VerifiedMapper = mapper.VerifiedMapper,
                PlaylistUrl = mapper.PlaylistUrl,
            };
        }

        public void UpdateFromBeatSaverUser(UserDetail mapper) {
            Name = mapper.Name;
            Avatar = mapper.Avatar;
            Curator = mapper.Curator;
            VerifiedMapper = mapper.VerifiedMapper;
            PlaylistUrl = mapper.PlaylistUrl;

            if (Curator == true) {
                Status |= MapperStatus.Curator;
            } else {
                Status &= ~MapperStatus.Curator;
            }
            if (VerifiedMapper) {
                Status |= MapperStatus.Verified;
            } else {
                Status &= ~MapperStatus.Verified;
            }
        }
    }
}
