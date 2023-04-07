namespace HexagonalCleanArchitecture.Dominio.Excepciones;

[Serializable]
public class VehiculoException : Exception
{
    public VehiculoException() { }
    public VehiculoException(string message) : base(message) { }
    public VehiculoException(string message, System.Exception inner) : base(message, inner) { }
    protected VehiculoException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

