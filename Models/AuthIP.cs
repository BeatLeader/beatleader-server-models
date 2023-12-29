namespace BeatLeader.Models;

public class AuthIP {
    public int Id { get; set; }
    public required string IP { get; set; }
    public int Timestamp { get; set; }
}

public class AuthID {
    public required string Id { get; set; }
    public int Timestamp { get; set; }
}

public class CountryChange {
    public required string Id { get; set; }
    public int Timestamp { get; set; }

    public required string OldCountry { get; set; }
    public required string NewCountry { get; set; }
}

public class LoginChange {
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int Timestamp { get; set; }

    public required string OldLogin { get; set; }
    public required string NewLogin { get; set; }
}

public class LoginAttempt {
    public int Id { get; set; }
    public int Count { get; set; }
    public required string IP { get; set; }
    public int Timestamp { get; set; }
}