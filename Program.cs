using ProcessorFactoryPOC.Models;

namespace ProcessorFactoryPOC
{
    internal class Program
    {
        private const string msgId = "ASDFQWER....POIULKJH=";
        private static IProcessorFactoryClient client;
        static void Main(string[] args)
        {
            InitalizeClient();

            Case1();
            Case2();
            Case3();
            // Refer Readme.md for 'Extending and Adding New Processes'

            Console.ReadLine();
        }

        private static void InitalizeClient()
        {
            client = new ProcessorFactoryClient(); //Can be dependency injected as a service. 
        }

        private static void Case1()
        {
            /// Case 1
            Console.WriteLine("Case: SendEmail");
            client.Execute(new ProcessPayload()
            {
                ProcessorType = ProcessorTypeEnum.SendEmail,
                MessageId = msgId,
                Data = new { Body = "<--EMAIL MESSAGE BODY-->", From = "somebody@domain.com", To = "me@domain.com", Subject = "<--EMAIL MESSAGE SUBJECT-->" }
            });
        }

        private static void Case2()
        {
            /// Case 2
            Console.WriteLine("Case: MoveToSFTP");
            client.Execute(new ProcessPayload()
            {
                ProcessorType = ProcessorTypeEnum.MoveToSFTP,
                MessageId = msgId,
                Data = new { Id = 1, Name = "FirstName LastName", Port = "127.0.0.1" }
            });
        }
        private static void Case3()
        {
            /// Case 3
            Console.WriteLine("Case: Flag");
            client.Execute(new ProcessPayload()
            {
                ProcessorType = ProcessorTypeEnum.Flag,
                MessageId = msgId,
                Data = "custom messge to add while flagging"
            });
        }

    }
}

