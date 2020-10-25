using Library.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repository
{

    public class LibraryRepository : Repository<Models.Library>, ILibraryRepository
    {
        #region Attributes
        private readonly DataContext _context;
        #endregion

        #region Ctor

        public LibraryRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<bool> InsertLibrary(Models.Library data)
        {
            _context.Libraries.Add(data);
            return await _context.SaveChangesAsync() > 0;
        }

        public Models.Library GetLibrary(int id)
        {
            var data = _context.Libraries.FirstOrDefault(x => x.Id == id);
            return data;
        }

        public async Task<bool> UpdateLibrary(Models.Library data)
        {      
            bool result = false;
            var library = GetLibrary(data.Id);
      
            if (library != null)
            {
                library.Titulo = data.Titulo;
                library.Costo = data.Costo;
                library.PreciosSugerido = data.PreciosSugerido;
                library.Autor = data.Autor;
                library.Fecha = data.Fecha;

                _context.Libraries.Update(library);
                result= await _context.SaveChangesAsync() > 0;
            }

            return result;
        }


        public async Task<bool> DeleteLibrary(int id)
        {
            bool result = false;
            var library = GetLibrary(id);
            if (library != null)
            {
                _context.Libraries.Remove(library);
                result= await _context.SaveChangesAsync() > 0;
            }
            return result;
        }


        #endregion

    }
}
