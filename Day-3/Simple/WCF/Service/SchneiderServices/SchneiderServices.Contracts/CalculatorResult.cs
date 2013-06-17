using System.Runtime.Serialization;

namespace SchneiderServices.Contracts
{
    [DataContract]
    public class CalculatorResult
    {
        [DataMember]
        public int Number1 { get; set; }
        [DataMember]
        public int Number2 { get; set; }
        [DataMember]
        public string Operation { get; set; }
        [DataMember]
        public int Result { get; set; }

        public override string ToString()
        {
            return string.Format("Number1={0}, Number2={1}, Operation={2}, Result={3}", Number1, Number2, Operation,
                                 Result);
        }
    }
}