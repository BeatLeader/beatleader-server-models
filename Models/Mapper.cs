using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeatLeader_Server.Models {
    public class Mapper
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
        }
    }
}
