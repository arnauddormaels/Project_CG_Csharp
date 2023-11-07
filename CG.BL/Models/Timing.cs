namespace CG.BL.Models
{
    public class Timing
    {
        private int _timingId;
        private TimeSpan _startTime;
        private TimeSpan _endTime;
        private Product _product;

        public Timing(TimeSpan startTime, TimeSpan endTime, Product product)
        {
            StartTime = startTime;
            EndTime = endTime;
            Product = product;
        }

        public Timing(int timingId, TimeSpan startTime, TimeSpan endTime, Product product) : this(startTime, endTime, product)
        {
                TimingId = timingId;    
        }

        public int TimingId { get => _timingId; private set => _timingId = value; }
        public TimeSpan StartTime { get => _startTime; private set => _startTime = value; }
        public TimeSpan EndTime { get => _endTime; private set => _endTime = value; }
        public Product Product { get => _product; private set => _product = value; }
    
    
    }
}
