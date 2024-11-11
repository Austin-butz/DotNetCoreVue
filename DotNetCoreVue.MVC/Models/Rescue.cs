namespace DotNetCoreVue.MVC.Models
{
    public class Rescue
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Directors { get; set; }
        public string Area { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public bool IsNonProfit { get; set; }
    }

    public class RescueData
    {
        public List<Shelter> shelters { get; set; }

        public class Shelter
        {
            public string name { get; set; }
            public string director { get; set; }
            public string location { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public string website { get; set; }
            public string status { get; set; }
            public IEnumerable<double> coordinates { get; set; }
            public string species { get; set; }
        }
    }
}
