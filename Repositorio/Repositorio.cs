using Microsoft.EntityFrameworkCore;
using ProyectoASll.Data;
using ProyectoASll.Repositorio.IRepositorio;
using System.Linq.Expressions;

namespace ProyectoASll.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        //relacionamos esta clase con el DBCONTEXT
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbset;

        //crear nuestro constructor
        public Repositorio(ApplicationDbContext context)
        {
            _context = context;
            this.dbset = _context.Set<T>();
        }

        public async Task Agregar(T entidad)
        {
            await dbset.AddAsync(entidad); //inserta los registros a la tabla de acuerdo a la entidad
        }

        public void Eliminar(T entidad)
        {
            dbset.Remove(entidad); //elimina un registro
        }

        public void EliminarRango(IEnumerable<T> entidad)
        {
            dbset.RemoveRange(entidad); //elimina un grupo de reistros
        }

        public async Task<T> Obtener(int id)
        {
            return await dbset.FindAsync(id); //genera un tipo select pero filtra solo por el id
        }

        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>> filtro = null, string incluirpropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbset;
            if (filtro != null)
            {
                query = query.Where(filtro); // select * from where
            }
            if (incluirpropiedades != null)
            {
                foreach (var incluirprop in incluirpropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirprop);  //incluye por ejemplo las propiedades de bodega con oriductos con bodega
                }
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirpropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbset;
            if (filtro != null)
            {
                query = query.Where(filtro); // select * from where
            }
            if (incluirpropiedades != null)
            {
                foreach (var incluirprop in incluirpropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirprop);  //incluye por ejemplo las propiedades de bodega con oriductos con bodega
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query); //ordenar los datos
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }
    }
}
