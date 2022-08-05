namespace bytebank_ATENDIMENTO.bytebank.Exceptions
{

    [Serializable]
    public class ByteBankException : Exception
    {
        public ByteBankException() { }
        public ByteBankException(string message) : base(message) { }
        public ByteBankException(string message, Exception inner) : base("Ocorreu uma Exceção: " + message, inner) { }
        protected ByteBankException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }   
}
