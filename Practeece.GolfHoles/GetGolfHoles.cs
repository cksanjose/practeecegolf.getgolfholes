using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Practeece.GolfHoles
{
    public static class GetGolfHoles
    {
        [FunctionName("GetGolfHoles")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("Request for golf holes");

            string[] skillLevels = {"beginner", "intermediate", "advanced"};

            // parse query parameter
            string skillLevel = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "skillLevel", true) == 0)
                .Value;

            // Get request body
            dynamic data = await req.Content.ReadAsAsync<object>();

            // Set name to query string or body data
            skillLevel = skillLevel ?? data?.skillLevel;

            if (skillLevel != null && skillLevels.Contains(skillLevel))
            {
                return req.CreateResponse(HttpStatusCode.OK, "Your skill level is " + skillLevel);
            }

            return req.CreateResponse(HttpStatusCode.BadRequest,
                "Please pass a valid skill level on the query string or in the request body");
        }
    }
}
