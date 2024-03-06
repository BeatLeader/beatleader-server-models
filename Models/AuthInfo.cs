namespace BeatLeader_Server.Models
{
    public class AuthInfo
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public byte[] Salt { get; set; } = new byte[] { };
        public string Hint { get; set; } = "";
    }
}

