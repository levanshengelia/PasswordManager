﻿using Core.Enums;
using Core.Responses.Contracts;
using Db.Models;

namespace Core.Responses
{
    public class GetUserAccountsResponse : IResponseResult
    {
        public ResponseStatus Status { get; set; }
        public string? ErrorMessage { get; set; }
        public List<AccountInfo> Accounts { get; set; } = null!;
    }
}
