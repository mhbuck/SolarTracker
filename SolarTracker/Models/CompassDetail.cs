namespace SolarTracker.Models
{
    public class CompassDetail
    {
        // I took flying guesses at the data types. Can easily just all be strings.
        public int ImpId { get; set; }
        public decimal Heading { get; set; }
        public decimal Pitch { get; set; }
        public decimal Roll { get; set; }
        public decimal SolarAzimuth { get; set; }
        public decimal SolarElevation { get; set; }
        public decimal ImpVoltage { get; set; }
    }
}