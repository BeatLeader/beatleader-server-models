﻿using OpenIddict.EntityFrameworkCore.Models;

namespace BeatLeader.Models;

public class DeveloperProfile {
    public int Id { get; set; }
    public required ICollection<OpenIddictEntityFrameworkCoreApplication> OauthApps { get; set; }
}