using System.Runtime.Serialization;
using System.ServiceModel;

namespace SchneiderServices.Contracts
{
    [ServiceContract]
    
    public interface IAdvancedCalculator
    {
        [OperationContract]
        [FaultContract(typeof(DivideOperationFailure))]
        [FaultContract(typeof(DivideByEvenNumberFailure))]
        CalculatorResult Calculate(CalculatorInput input);
    }

    [DataContract]
    public class DivideByEvenNumberFailure
    {
        [DataMember]
        public string Message { get; set; }
    }

    [DataContract]
    public class DivideOperationFailure
    {
        [DataMember]
        public int Number1 { get; set; }
        
        [DataMember]
        public int Number2 { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}