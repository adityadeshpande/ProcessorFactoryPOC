using ProcessorFactoryPOC.Interfaces;
using ProcessorFactoryPOC.Models;
using ProcessorFactoryPOC.ProcessorFactory;

namespace ProcessorFactoryPOC
{
    public interface IProcessorFactoryClient
    {
        void Execute(ProcessPayload _payload);
    }

    public class ProcessorFactoryClient : IProcessorFactoryClient
    {
        public void Execute(ProcessPayload _payload)
        {
            IProcessorFactory factory = GetFactory(_payload.ProcessorType);

            IProcessor processor = factory.CreateProcessor();
            var payload = factory.CreatePayload(_payload);

            processor.Process(payload);
            processor.Finish();

        }

        private IProcessorFactory GetFactory(ProcessorTypeEnum type)
        {
            switch (type)
            {
                case ProcessorTypeEnum.SendEmail:
                    return new SendEmailProcessorFactory();
                case ProcessorTypeEnum.MoveToSFTP:
                    return new SFTPProcessorFactory();
                case ProcessorTypeEnum.Flag:
                    return new FlagProcessorFactory();
                default:
                    throw new ArgumentException("Unsupported processor type: " + type);
            }
        }
    }

}