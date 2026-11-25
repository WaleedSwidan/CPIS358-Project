namespace UddahWebApp.Models
{
    // one tool (equipment) that can be rented. Entity Framework makes a table from this class
    public class Tool
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public double pricePerDay { get; set; }
        public double deposit { get; set; }

        public Tool()
        {
        }
    }
}