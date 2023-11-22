using CG.BL.Models;

namespace CG.API.Model.Output
{
    public class TimingRESToutputDTO
    {
        public int TimingId { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public ProductRESToutputDTO Product { get; set; }
        public TimingRESToutputDTO(int timingId, int startTime, int endTime, ProductRESToutputDTO product)
        {
            TimingId = timingId;
            StartTime = startTime;
            EndTime = endTime;
            Product = product;
        }
    }
}