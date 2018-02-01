using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Practeece.GolfHoles.models;

namespace Practeece.GolfHoles
{
    public static class GetGolfSwingResult
    {
        [FunctionName("GetGolfSwingResult")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            // Sample body data
            /* 
                {
                  "skillLevel": "advanced",
                  "swingCount": 1,	
                  "golfHole": {
                    "holeId": 1,
                    "distance": 510,
                    "par": 5,
                    "skill": "Advance",
                    "hazard": "None",
                    "averageSwingsToGreen": 4
                  }
                }             
             */

            log.Info("A golf swing was made so return what the result is.");

            // Get request body
            GolfSwing data = await req.Content.ReadAsAsync<GolfSwing>();

            // Set name to query string or body data
            if (data != null)
            {
                return req.CreateResponse(HttpStatusCode.OK, $"Nice swing at {data.SkillLevel} level");
            }

            return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a valid golf swing data in the request body");
        }
    }
}
