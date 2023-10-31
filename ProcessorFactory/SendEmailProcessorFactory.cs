using ProcessorFactoryPOC.Interfaces;
using ProcessorFactoryPOC.Models;
using ProcessorFactoryPOC.Processors;
using ProcessorFactoryPOC.Validators;

namespace ProcessorFactoryPOC.ProcessorFactory
{
    public class SendEmailProcessorFactory : IProcessorFactory
    {
        public IProcessor CreateProcessor()
        {
            return new SendEmailProcessor();
        }

        public object CreatePayload(ProcessPayload payload)
        {
            var ret = TypeValidator.ConvertTo<EmailPayload>(payload.Data);
            ret.MessageId = payload.MessageId;
            return ret;
        }
    }

    public class EmailPayload
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public string MessageId { get; set; }
    }
}