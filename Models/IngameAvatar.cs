using System.ComponentModel.DataAnnotations;

namespace BeatLeader_Server.Models {
    public class AvatarColor
    {
        public float r { get; set; }
        public float g { get; set; }
        public float b { get; set; }
        public float a { get; set; }

        public AvatarColor(float r, float g, float b, float a) {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
    public class AvatarPart {
        public string ModelId { get; set; }
        public AvatarColor PrimaryColor { get; set; }
        public AvatarColor SecondaryColor { get; set; }
        public AvatarColor DetailColor { get; set; }

        public static string PickRandom(string[] options) {
            Random rnd = new Random();
            return options[rnd.Next(0, options.Length)];
        }

        public static AvatarColor RandomColor(int precision = 1000, int startFrom = 300) {
            Random rand = new Random();
            var r = Random01(precision, startFrom, rand);
            var g = Random01(precision, startFrom, rand);
            var b = Random01(precision, startFrom, rand);
            return new AvatarColor(r, g, b, 1);

            static float Random01(int precision, int startFrom, Random rand) {
                return rand.Next(startFrom, precision) / (float)precision;
            }
        }

        public static AvatarPart Random(string[] idOptions) {
            var result = new AvatarPart();

            result.ModelId = PickRandom(idOptions);

            result.PrimaryColor = RandomColor();
            result.SecondaryColor = RandomColor();
            result.DetailColor = RandomColor();

            return result;
        }
    }

    public class AvatarData {
        public AvatarPart HeadTop { get; set; }
        public AvatarPart FacialHair { get; set; }
        public AvatarPart Glasses { get; set; }
        public AvatarPart Eyes { get; set; }
        public AvatarPart Mouth { get; set; }
        public AvatarPart Hands { get; set; }
        public AvatarPart Clothes { get; set; }
        public string SkinColorId { get; set; }

        public static AvatarData Random() {
            var result = new AvatarData();

            result.HeadTop = AvatarPart.Random([ 
                "None",
                "BedHead",
                "Bob",
                "DoubleTrouble",
                "Emo",
                "HalfShaved",
                "Heartbreak",
                "Hippie",
                "LongBangs",
                "Loose",
                "Magician",
                "Nanny",
                "Normie",
                "OnFire",
                "PoloCap",
                "Ponytail",
                "Punk",
                "Scifi",
                "Sultan",
                "SweatBand",
                "Untidy",
                "WetHair",
                "Windswept",
                "WinterHat",
                "Wizard"
            ]);
            result.FacialHair = AvatarPart.Random([ 
                "None",
                "Beard01",
                "Moustache01",
                "Moustache02"
            ]);
            result.Glasses = AvatarPart.Random([
                "None",
                "Glasses01",
                "Glasses02"
            ]);
            result.Mouth = AvatarPart.Random([ 
                "Mouth1",
                "Mouth2",
                "Mouth3",
                "Mouth4",
                "Mouth5",
                "Mouth6",
                "Mouth7",
                "Mouth8",
                "Mouth9",
                "Mouth10",
                "Mouth11",
                "Mouth12"
            ]);
            result.Hands = AvatarPart.Random([ 
                "BareHands",
                "Fingerless"
            ]);
            result.Clothes = AvatarPart.Random([ 
                "Basket",
                "Dress",
                "Hoodie",
                "Jacket",
                "Jumpsuit",
                "Rock",
                "Tracksuit",
                "Vest"
            ]);

            result.Eyes = AvatarPart.Random([
                "Eyes1",
                "Eyes2",
                "Eyes3",
                "Eyes4",
                "Eyes5",
                "Eyes6",
                "Eyes7",
                "Eyes8",
                "Eyes9",
                "Eyes10",
                "Eyes11"
            ]);

            result.SkinColorId = AvatarPart.PickRandom([
                "Default",
                "Light",
                "Mid",
                "Brown",
                "DarkBrown",
                "Black",
                "Alien",
                "Smurf",
                "Zombie",
                "Purple"
             ]);

            return result;
        }
    }

    public class IngameAvatar {
        public int Id { get; set; }
        [StringLength(25, MinimumLength = 0)]
        public string PlayerID { get; set; }
        public string Value { get; set; }
    }
}
