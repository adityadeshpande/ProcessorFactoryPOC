using ProcessorFactoryPOC.Interfaces;
using ProcessorFactoryPOC.ProcessorFactory;

namespace ProcessorFactoryPOC.Processors
{
    public class SendEmailProcessor : ProcessorBase, IProcessor
    {
        public void Process(object payload)
        {
            if (payload is EmailPayload)
            {
                var e = payload as EmailPayload;

                //Do the logical part//

                Console.WriteLine($"Send Email -- MessageId: {e.MessageId},");
                Console.WriteLine($"Send Email -- To: {e.To}, From: {e.From}, Subject: {e.Subject}, Body: {e.Body},");
            }
        }
    }
}