using Core.Enums;
using Core.Models;

namespace Core.Responses
{
    public record AddAccountResponse
    {
        public AddAccountStatus Status { get; set; }
        public AccountInfo NewlyAddedAccountInfo { get; set; } = null!;
    }
}
