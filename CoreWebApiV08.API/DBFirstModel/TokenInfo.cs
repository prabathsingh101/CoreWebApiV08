using System;
using System.Collections.Generic;

namespace CoreWebApiV08.API.DBFirstModel;

public partial class TokenInfo
{
    public int Id { get; set; }

    public string Usename { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;

    public DateTime RefreshTokenExpiry { get; set; }
}
