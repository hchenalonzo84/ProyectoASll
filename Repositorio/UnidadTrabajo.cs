using ProyectoASll.Data;
using ProyectoASll.Repositorio.IRepositorio;

namespace ProyectoASll.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        //crear una variable para relacionar la informacion con el ApplicationDBContext
        private readonly ApplicationDbContext _context;
        //creamos una propiedad para obtener y modificar la informacion de marca
        public IMarcaRepositorio MarcaRepositorio { get; private set; }

        public UnidadTrabajo()
        {
            //inicializamos la propiedad creada de la marca
            MarcaRepositorio = new MarcaRepositorio(_context);
        }

        public void Dispose()
        {
            _context.Dispose(); //libera lo que esta en memoria que no estamos utilizando

        }

        public async Task Guardar()
        {
            await _context.SaveChangesAsync(); //Guardamos los cambios y los podemos referenciar en cualquier parte del proyecto
        }
    }
}
