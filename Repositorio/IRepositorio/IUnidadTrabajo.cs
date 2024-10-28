namespace ProyectoASll.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        //generar una referencia a  los repositorios individuales de marcas
        IMarcaRepositorio MarcaRepositorio { get; }
        //creamos un metodo asincrono para guardar los cambios
        Task Guardar();
    }
}
