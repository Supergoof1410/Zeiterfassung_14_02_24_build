using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Arbeitszeiterfassung_TN.TimeManager
{

    static internal class CheckInternetConnection
    {
        static readonly HttpClient client = new();

        static string? stream;

        static internal async Task<string> CheckConnection()
        {
            try
            {
                stream = await client.GetStringAsync(@"http://www.google.de");
                return stream;
            }
            catch
            {
                return stream!;
            }
        }
    }
}
