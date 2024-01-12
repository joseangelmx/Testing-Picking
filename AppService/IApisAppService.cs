using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing_picking.Models.TransferInbound;

namespace testing_picking.AppService
{
    public interface IApisAppService
    {
        Task<string> GetBearerTokenAsync(string username, string password);
        Task<TransferInboundReturn> TransferInboundAsync(TransferRequest requestData, string bearerToken);
    }
}
