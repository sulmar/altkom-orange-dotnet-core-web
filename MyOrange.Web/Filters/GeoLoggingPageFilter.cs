using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyOrange.Web.Filters
{

    public class Geo
    {
        public string ip { get; set; }
        public string type { get; set; }
        public string continent_code { get; set; }
        public string continent_name { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string region_code { get; set; }
        public string region_name { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public Location location { get; set; }
    }

    public class Location
    {
        public int geoname_id { get; set; }
        public string capital { get; set; }
        public Language[] languages { get; set; }
        public string country_flag { get; set; }
        public string country_flag_emoji { get; set; }
        public string country_flag_emoji_unicode { get; set; }
        public string calling_code { get; set; }
        public bool is_eu { get; set; }
    }

    public class Language
    {
        public string code { get; set; }
        public string name { get; set; }
        public string native { get; set; }
    }


    public interface IGeoService
    {
        Task<Geo> GetCountry(string ipAddress);
    }

    public class GeoService : IGeoService
    {
        // https://ipstack.com/
        private readonly string apiKey = "yourapikey";

        private readonly IHttpClientFactory _httpClientFactory;

        public GeoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Geo> GetCountry(string ipAddress)
        {
            var client = _httpClientFactory.CreateClient("ipstack");

            string url = $"{ipAddress}?access_key={apiKey}";

            var json = await client.GetStringAsync(url);
            Geo data = JsonSerializer.Deserialize<Geo>(json);
            return data;
        }
    }

    public class GeoLoggingPageFilter : IAsyncPageFilter
    {
        private readonly IDiagnosticContext _diagnosticContext;
        private readonly IGeoService _geoService;

        public GeoLoggingPageFilter(IDiagnosticContext diagnosticContext, IGeoService geoService)
        {
            _diagnosticContext = diagnosticContext;
            _geoService = geoService;
        }

        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4();

                var geo = await _geoService.GetCountry(ipAddress.ToString());

                if (geo != null && geo.ip != null)
                    _diagnosticContext.Set("Geo", geo, destructureObjects: true);

            await next.Invoke();
        }

        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            return Task.CompletedTask;
        }
    }
}
