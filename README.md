# Extending and Adding New Processes

This readme provides instructions for extending or adding new processes to the existing codebase. To do so, follow these steps:

## Step 1: Update ProcessorTypeEnum

To add a new process, you should first update the ProcessorTypeEnum enumeration with a new enum value that represents the new processor. This will ensure that the code can distinguish and handle the new processor type.

    public enum ProcessorTypeEnum
    {
	    // Existing processor types
	    Type1,
	    Type2,
	    
	    // Add your new processor type here
	    NewType
    }

## Step 2: Implement ProcessorFactory

You will need to add a new class that implements the IProcessorFactory interface. This class will be responsible for creating instances of the new processor.

    public class NewProcessorFactory : IProcessorFactory
    {
	    public IProcessor CreateProcessor(ProcessorTypeEnum type)
	    {	
		    return new NewTypeProcessor();
	    }
    }

## Step 3: Implement the New Processor
Create a new class that implements the ProcessorBase and IProcessor interfaces. This class should encapsulate the behavior of your new processor.

    public class NewTypeProcessor : ProcessorBase, IProcessor
    {
	    // Implement the required methods and properties
	    // ...
    }

## Step 4: Update ProcessorFactoryClient

In the ProcessorFactoryClient class, update the GetFactory method to include the new processor type. This will ensure that the factory can create instances of the new processor.

    public class ProcessorFactoryClient
    {
	    public IProcessorFactory GetFactory()
	    {
		    switch (type)
		    {
		    case ProcessorTypeEnum.Type1:
			    return new Type1ProcessorFactory();
			    // ...
		    // ...
		    case ProcessorTypeEnum.NewType:
			    return new NewProcessorFactory(); // Use the factory for the new processor type
		    case default:
			    // ...
			// ...
		    }
	    }
	    // ...
    }

  

By following these steps, you can extend the existing codebase to include a new processor type. Make sure to implement the specific behavior for the new processor in the NewTypeProcessor class, and your code will be ready to handle the new process.
