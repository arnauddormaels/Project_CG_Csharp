using CG.BL.Exceptions;

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

        public Timing(int timingId, int startTime, int endTime, Product product)
        {
            TimingId = timingId;
            StartTime = startTime;
            EndTime = endTime;
            Product = product;
        }

        public int TimingId { get => _timingId; private set
            {
                if (value <= 0)
                {
                    var ex = new DomainModelException("Timing-SetTimingId-SmallerThanOne");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(TimingId)));
                    ex.Error = new Error("timingId is smaller than 1");
                    ex.Error.Values.Add(new PropertyInfo("TimingId", value));
                    throw ex;
                }
                _timingId = value;
            }
        }
        public int StartTime { get => _startTime; private set
            {
                if (value < 0)
                {
                    var ex = new DomainModelException("Timing-SetStartTime-SmallerThanZero");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(StartTime)));
                    ex.Error = new Error("startTime is smaller than 0");
                    ex.Error.Values.Add(new PropertyInfo("StartTime", value));
                    throw ex;
                }
                _startTime = value;
            }
        }
        public int EndTime { get => _endTime; private set
            {
                if (value < 0)
                {
                    var ex = new DomainModelException("Timing-SetEndTime-SmallerThanZero");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(EndTime)));
                    ex.Error = new Error("endTime is smaller than 0");
                    ex.Error.Values.Add(new PropertyInfo("EndTime", value));
                    throw ex;
                }
                _endTime = value;
            }
        }
        public Product Product { get => _product; private set
            {
                if (value == null)
                {
                    var ex = new DomainModelException("Timing-SetProduct-Null");
                    ex.Sources.Add(new ErrorSource(this.GetType().Name, nameof(Product)));
                    ex.Error = new Error("product is null ");
                    ex.Error.Values.Add(new PropertyInfo("Product", value));
                    throw ex;
                }
                _product = value;
            }
        }


    }
}
