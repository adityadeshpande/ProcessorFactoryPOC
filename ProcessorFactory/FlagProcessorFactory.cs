using ProcessorFactoryPOC.Interfaces;
using ProcessorFactoryPOC.Models;
using ProcessorFactoryPOC.Processors;

namespace ProcessorFactoryPOC.ProcessorFactory
{
    public class FlagProcessorFactory : IProcessorFactory
    {
        public IProcessor CreateProcessor()
        {
            return new FlagProcessor();
        }

        public object CreatePayload(ProcessPayload payload)
        {
            // Do not change the Payload as send as is.
            return payload;
        }
    }
}