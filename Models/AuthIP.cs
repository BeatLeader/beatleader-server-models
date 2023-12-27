namespace BeatLeader.Models;

public class AuthIP {
    public int Id { get; set; }
    public string IP { get; set; } = null!;
    public int Timestamp { get; set; }
}

public class AuthID {
    public string Id { get; set; } = null!;
    public int Timestamp { get; set; }
}

public class CountryChange {
    public string Id { get; set; } = null!;
    public int Timestamp { get; set; }

    public string OldCountry { get; set; } = null!;
    public string NewCountry { get; set; } = null!;
}

public class LoginChange {
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int Timestamp { get; set; }

    public string OldLogin { get; set; } = null!;
    public string NewLogin { get; set; } = null!;
}

public class LoginAttempt {
    public int Id { get; set; }
    public int Count { get; set; }
    public string IP { get; set; } = null!;
    public int Timestamp { get; set; }
}