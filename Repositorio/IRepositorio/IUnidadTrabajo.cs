namespace ProyectoASll.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IMarcaRepositorio MarcaRepositorio { get; }
    }
}
