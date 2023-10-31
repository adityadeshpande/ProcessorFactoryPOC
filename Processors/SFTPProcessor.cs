using ProcessorFactoryPOC.Interfaces;
using ProcessorFactoryPOC.ProcessorFactory;
using ProcessorFactoryPOC.Validators;

namespace ProcessorFactoryPOC.Processors
{
    public class SFTPProcessor : ProcessorBase, IProcessor
    {
        public void Process(object payload)
        {
            if (TypeValidator.CanBeCastedAs<SftpPayload>(payload))
            {
                var x = payload as SftpPayload;

                //Do the logical part//

                Console.WriteLine($"File with Id:{x.Id} moved to --> {x.Name}'s SFTP location --> {x.Port}.");
            }
            else
            {
                TypeValidator.GenerateException<SftpPayload>(payload);
            }
        }
    }
}