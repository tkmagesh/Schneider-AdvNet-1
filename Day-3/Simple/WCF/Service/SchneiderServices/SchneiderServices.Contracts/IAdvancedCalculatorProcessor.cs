using System.ServiceModel;

namespace SchneiderServices.Contracts
{
    [ServiceContract]
    public interface IAdvancedCalculatorProcessor
    {
        [OperationContract(IsOneWay = true, Name = "Process")]
        void Calculate(CalculatorInput input);
    }
}