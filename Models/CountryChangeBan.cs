namespace BeatLeader_Server.Models
{
    public class CountryChangeBan
    {
        public int Id { get; set; }
        public string PlayerId { get; set; }
        public int Timeset { get; set; }
    }

    public class UsernamePfpChangeBan
    {
        public int Id { get; set; }
        public string PlayerId { get; set; }
        public int Timeset { get; set; }
    }
}
