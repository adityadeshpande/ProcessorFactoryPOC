using ProcessorFactoryPOC.Interfaces;
using ProcessorFactoryPOC.Models;
using ProcessorFactoryPOC.Processors;
using ProcessorFactoryPOC.Validators;

namespace ProcessorFactoryPOC.ProcessorFactory
{
    public class SFTPProcessorFactory : IProcessorFactory
    {
        public IProcessor CreateProcessor()
        {
            return new SFTPProcessor();
        }

        public object CreatePayload(ProcessPayload payload)
        {
            return TypeValidator.ConvertTo<SftpPayload>(payload.Data);
        }
    }

    public class SftpPayload
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Port { get; set; }
    }
}