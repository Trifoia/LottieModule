using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Trifoia.Lottie
{
    public class Interop
    {
        private readonly IJSRuntime _jsRuntime;

        public Interop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    }
}
