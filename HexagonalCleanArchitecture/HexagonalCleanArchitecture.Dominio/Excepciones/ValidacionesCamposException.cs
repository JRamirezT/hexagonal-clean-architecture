namespace HexagonalCleanArchitecture.Dominio.Excepciones;

[Serializable]
public class ValidacionesCamposException : VehiculoException
{
    public ValidacionesCamposException(string message) : base(message) { }
    protected ValidacionesCamposException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

