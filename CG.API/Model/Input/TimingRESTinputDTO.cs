using CG.API.Model.Output;

namespace CG.API.Model.Input
{
    public class TimingRESTinputDTO
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        //voorlopig met productid dan een productobject - uitbreiding als we producten zullen aanpassen etc...
        public  int ProductId {  get; set; }
        public ProductRESTinputDTO Product { get; set; }

        public TimingRESTinputDTO(int startTime, int endTime, int productId)
        {
            StartTime = startTime;
            EndTime = endTime;
            ProductId = productId;
        }
    }
}
