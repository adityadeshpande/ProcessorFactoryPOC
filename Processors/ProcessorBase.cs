namespace ProcessorFactoryPOC.Processors
{
    public class ProcessorBase
    {
        public void Finish()
        {
            GC.Collect();
            Console.WriteLine($"Finished processing {GetType().Name} {Environment.NewLine}");
        }
    }
}