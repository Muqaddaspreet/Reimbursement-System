#region Assembly System.Web.Http, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// C:\Users\muqaddaspreetbhatia\Downloads\ExitProject-With-Bonus-Question\Final Exit\ReimbursementPortal\packages\Microsoft.AspNet.WebApi.Core.5.2.7\lib\net45\System.Web.Http.dll
#endregion

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace System.Web.Http
{
    //
    // Summary:
    //     Defines a command that asynchronously creates an System.Net.Http.HttpResponseMessage.
    public interface IHttpActionResult
    {
        //
        // Summary:
        //     Creates an System.Net.Http.HttpResponseMessage asynchronously.
        //
        // Parameters:
        //   cancellationToken:
        //     The token to monitor for cancellation requests.
        //
        // Returns:
        //     A task that, when completed, contains the System.Net.Http.HttpResponseMessage.
        Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken);
    }
}