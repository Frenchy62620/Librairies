using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jObj = JObject.Parse(File.ReadAllText(@"json1.json"));
            jObj["body"].Where(x => (string)x["type"] == "ActionSet").First().Remove();
            var json = jObj.ToString();
            
            var jtok = JToken.Parse(File.ReadAllText(@"json1.json"));

            var filteredBody = jtok["body"].Where(j => j["type"] != null && !j["type"].Any(t => t.Value<string>() == "Action.Submit")).ToList();

            jtok["body"] = new JArray(filteredBody);

            var result = jtok.ToString();

            var list = jtok["body"].ToList();
            var result1 = jtok["body"].ToList().Select(x => x["actions"]).SelectMany(x => x["type"]).Where(y => y.Any(c => c.Value<string>() == "Action.Submit")).ToList();
        }
    }
}
