namespace ProcessorFactoryPOC.Interfaces
{
    public interface IProcessor
    {
        void Process(object payload);
        void Finish();
    }

}