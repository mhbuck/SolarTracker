namespace SolarTracker.Models
{
    public class MotionDetail
    {
        // I took flying guesses at the data types. Can easily just all be strings.
        public string Command { get; set; }
        public decimal Heading { get; set; }
        public decimal Elevation { get; set; }
    }
}