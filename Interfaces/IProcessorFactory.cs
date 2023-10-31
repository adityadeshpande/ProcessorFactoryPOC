using ProcessorFactoryPOC.Models;

namespace ProcessorFactoryPOC.Interfaces
{
    public interface IProcessorFactory
    {
        IProcessor CreateProcessor();
        object CreatePayload(ProcessPayload payload); // You can add more associated objects here
    }

}