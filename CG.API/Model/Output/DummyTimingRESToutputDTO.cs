namespace CG.API.Model.Output
{
    public class DummyTimingRESToutputDTO
    {
        public int TimingId { get; set; }
        public string BoterImgUrl { get; set; }
        public string FamaImgUrl { get; set; }
        public string BoterName { get; set; }
        public string FamaName { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }

        public DummyTimingRESToutputDTO(int timingId, string boterImgUrl, string famaImgUrl, string boterName, string famaName, string beginTime, string endTime)
        {
            TimingId = timingId;
            BoterImgUrl = boterImgUrl;
            FamaImgUrl = famaImgUrl;
            BoterName = boterName;
            FamaName = famaName;
            BeginTime = beginTime;
            EndTime = endTime;
        }
    }
}