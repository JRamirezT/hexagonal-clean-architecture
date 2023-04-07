using HexagonalCleanArchitecture.Dominio.Excepciones;
using HexagonalCleanArchitecture.Dominio.Recursos;

namespace HexagonalCleanArchitecture.Dominio.Servicios.Vehiculo;

public class ServicioVehiculo
{
    readonly List<Entidades.Vehiculo> listaVehiculos = new();
    const string MarcaNoPermitida = "string";

    public void GuardarVehiculo(Entidades.Vehiculo vehiculo)
    {
        ValidarMarca(vehiculo.Marca);
        listaVehiculos.Add(vehiculo);
    }

    private static void ValidarMarca(string Marca)
    {
        if (Marca.ToLower().Equals(MarcaNoPermitida))
        {
            throw new VehiculoException(string.Format(RecursosAplicacion.VehiculoMarcaNoPermitida, MarcaNoPermitida));
        }
    }
}
