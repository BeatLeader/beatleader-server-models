namespace BeatLeader_Server.Models
{
    public enum RichPresenceActivityStatus {
        Offline,
        Online,
        Playing
    }
    public class RichPresence
    {
        public int Id { get; set; }
        public RichPresenceActivityStatus ActivityStatus { get; set; }
    }
}
