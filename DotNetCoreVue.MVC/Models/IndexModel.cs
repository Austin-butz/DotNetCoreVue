using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DotNetCoreVue.MVC.Models
{
    public class IndexModel
    {
        public RescueData Rescues { get; set; } 

        public IndexModel()
        {
            RescueData file;
            using (StreamReader r = new StreamReader("rescues.json"))
            {
                string json = r.ReadToEnd();
                file = JsonSerializer.Deserialize<RescueData>(json);
            }
            Rescues = file;
        } 
    }
}
