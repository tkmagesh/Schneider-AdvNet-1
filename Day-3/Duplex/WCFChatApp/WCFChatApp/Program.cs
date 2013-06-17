using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using WCFChatApp.Contracts;
using WCFChatApp.Implementations;

namespace WCFChatApp
{
    namespace Contracts
    {
        [ServiceContract(CallbackContract = typeof(IChatClientCallback))]
        public interface IChatService
        {
            [OperationContract]
            void Login(string name);

            [OperationContract]
            void SendMessage(string message);

            [OperationContract]
            void Logout();
        }

        [ServiceContract]
        public interface IChatClientCallback
        {
            [OperationContract]
            void ReceiveMessage(string message);
        }
    }


    namespace Implementations
    {
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
        public class ChatService : IChatService
        {
            private IDictionary<string,IChatClientCallback> callbacks = new Dictionary<string, IChatClientCallback>(); 
            public void Login(string name)
            {
                Console.WriteLine(name + " logged in");
                var clientCallback = OperationContext.Current.GetCallbackChannel<IChatClientCallback>();
                callbacks.Add(name,clientCallback);
            }

            public void SendMessage(string message)
            {
                foreach (var chatClientCallback in callbacks)
                {
                    var current = OperationContext.Current.GetCallbackChannel<IChatClientCallback>();
                    if (chatClientCallback.Value != current)
                        chatClientCallback.Value.ReceiveMessage(message);
                }
            }

            public void Logout()
            {

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var chatServiceInstance = new ChatService();
            var host = new ServiceHost(chatServiceInstance);
            host.Open();
            Console.WriteLine("Service running.. Hit ENTER to shutdown");
            Console.ReadLine();
            host.Close();
        }
    }
}
