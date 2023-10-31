namespace ProcessorFactoryPOC.Models
{
    public class ProcessPayload
    {
        public ProcessorTypeEnum ProcessorType { get; set; }
        public string MessageId { get; set; }
        public dynamic Data { get; set; }
    }
}
