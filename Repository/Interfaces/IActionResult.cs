using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc
{
    //
    // Resumo:
    //     Defines a contract that represents the result of an action method.
    public interface IActionResult
    {
        //
        // Resumo:
        //     Executes the result operation of the action method asynchronously. This method
        //     is called by MVC to process the result of an action method.
        //
        // Parâmetros:
        //   context:
        //     The context in which the result is executed. The context information includes
        //     information about the action that was executed and request information.
        //
        // Devoluções:
        //     A task that represents the asynchronous execute operation.
        Task ExecuteResultAsync(ActionContext context);
    }
}