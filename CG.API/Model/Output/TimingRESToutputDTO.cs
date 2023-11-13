using CG.BL.Models;

namespace CG.API.Model.Output
{
    public class TimingRESToutputDTO
    {
        public int TimingId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public ProductRESToutputDTO Product { get; set; }

        public TimingRESToutputDTO(int timingId, TimeSpan startTime, TimeSpan endTime, ProductRESToutputDTO product)
        {
            TimingId = timingId;
            StartTime = startTime;
            EndTime = endTime;
            Product = product;
        }
    }
}