namespace CG.BL.Models
{
    public class Timing
    {
        private int _timingId;
        private int _startTime;
        private int _endTime;
        private Product _product;

        public Timing(int startTime, int endTime, Product product)
        {
            StartTime = startTime;
            EndTime = endTime;
            Product = product;
        }

        public Timing(int timingId, int startTime, int endTime)
        {
            TimingId = timingId;
            StartTime = startTime;
            EndTime = endTime;
        }

        public Timing(int timingId, int startTime, int endTime, Product product) : this(startTime, endTime, product)
        {
                TimingId = timingId;    
        }

        public int TimingId { get => _timingId; private set => _timingId = value; }
        public int StartTime { get => _startTime; private set => _startTime = value; }
        public int EndTime { get => _endTime; private set => _endTime = value; }
        public Product Product { get => _product; private set => _product = value; }
    
    
    }
}
