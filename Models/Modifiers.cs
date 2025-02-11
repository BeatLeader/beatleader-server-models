using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeatLeader_Server.Models
{
    public class ModifiersRating 
    {
        public int Id { get; set; }

        public float SSPredictedAcc { get; set; }
        public float SSPassRating { get; set; }
        public float SSAccRating { get; set; }
        public float SSTechRating { get; set; }
        public float SSStars { get; set; }

        public float FSPredictedAcc { get; set; }
        public float FSPassRating { get; set; }
        public float FSAccRating { get; set; }
        public float FSTechRating { get; set; }
        public float FSStars { get; set; }
        public float SFPredictedAcc { get; set; }
        public float SFPassRating { get; set; }
        public float SFAccRating { get; set; }
        public float SFTechRating { get; set; }
        public float SFStars { get; set; }

        public float BFSPredictedAcc { get; set; }
        public float BFSPassRating { get; set; }
        public float BFSAccRating { get; set; }
        public float BFSTechRating { get; set; }
        public float BFSStars { get; set; }
        public float BSFPredictedAcc { get; set; }
        public float BSFPassRating { get; set; }
        public float BSFAccRating { get; set; }
        public float BSFTechRating { get; set; }
        public float BSFStars { get; set; }
    }

    public class ModifiersMap
    {
        [Key]
        public int ModifierId { get; set; }

        public float DA { get; set; } = 0.0f;
        public float FS { get; set; } = 0.20f;
        public float SF { get; set; } = 0.36f;
        public float SS { get; set; } = -0.3f;
        public float GN { get; set; } = 0.04f;
        public float NA { get; set; } = -0.3f;
        public float NB { get; set; } = -0.2f;
        public float NF { get; set; } = -0.5f;
        public float NO { get; set; } = -0.2f;
        public float PM { get; set; } = 0.0f;
        public float SC { get; set; } = 0.0f;
        public float SA { get; set; } = 0.0f;
        public float OP { get; set; } = -0.5f;

        [NotMapped]
        public float EZ { get; set; } = -0.4f;
        [NotMapped]
        public float HD { get; set; } = 0.05f;
        [NotMapped]
        public float SMC { get; set; } = 0.07f;
        [NotMapped]
        public float OHP { get; set; } = 0.0f;

        public static ModifiersMap RankedMap() {
            return new ModifiersMap {
                DA = 0.0f,
                FS = 0.20f * 2,
                SF = 0.36f * 2,
                SS = -0.3f,
                GN = 0.00f,
                NA = -0.3f,
                NB = -0.2f,
                NF = -1.0f,
                NO = -0.2f,
                PM = 0.0f,
                SC = 0.0f,
                SA = 0.0f,
                OP = -0.5f,
            };
        }

        public static ModifiersMap ReBeatMap() {
            return new ModifiersMap {
                FS = 0.07f,
                SF = 0.15f,
                SS = -0.5f,
                PM = 0.12f,
                DA = 0.0f,
                GN = 0.0f,
                NA = -0.7f,
                NB = -0.4f,
                NO = -0.4f,
                SC = 0.0f,
                SA = 0.0f,
                NF = -0.5f,
                OP = -0.5f,
            };
        }

        public bool EqualTo(ModifiersMap? other) {
            return other != null && DA == other.DA && FS == other.FS && SS == other.SS && SF == other.SF && GN == other.GN && NA == other.NA && NB == other.NB && NF == other.NF && NO == other.NO && PM == other.PM && SC == other.SC && SA == other.SA && OP == other.OP;
        }
    }
}
