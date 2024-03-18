using Microsoft.AspNetCore.SignalR;

namespace Sales.Api.Dtos
{
    public class DtosBase
    {
        public int UserId { get; set; }
        public DateTime ChangeDate { get; set; }

    }
}
