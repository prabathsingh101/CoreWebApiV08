using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Models.DTO.FeesHead
{
    [Keyless]
    public class MaxInvoiceNoModel
    {
        public string? invoiceno { get; set; }
    }
}
