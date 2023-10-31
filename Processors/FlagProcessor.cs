using Newtonsoft.Json;
using ProcessorFactoryPOC.Interfaces;
using ProcessorFactoryPOC.Models;
using ProcessorFactoryPOC.Validators;

namespace ProcessorFactoryPOC.Processors
{
    public class FlagProcessor : ProcessorBase, IProcessor
    {
        public void Process(object payload)
        {
            var notconvertedToCustomType = TypeValidator.ConvertTo<ProcessPayload>(payload);
            dynamic data = JsonConvert.SerializeObject(notconvertedToCustomType.Data);
            Console.WriteLine($"This message was flagged. {notconvertedToCustomType.MessageId} // data:{data}");
        }
    }

}