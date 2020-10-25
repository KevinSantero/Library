using Library.Data.Models;
using Library.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public class EditorialRepository : Repository<Editorial>, IEditorialRepository
    {

        #region Attributes
        private readonly DataContext _context;
        #endregion

        #region Ctor

        public EditorialRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<bool> InsertEditorial(Models.Editorial data)
        {
            _context.Editorials.Add(data);
            return await _context.SaveChangesAsync() > 0;
        }

        public Editorial GetEditorial(int id)
        {
            var data = _context.Editorials.FirstOrDefault(x => x.Id == id);
            return data;
        }

        public async Task<bool> UpdateEditorial(Models.Editorial data)
        {
            bool result = false;
            var editorial = GetEditorial(data.Id);

            if (editorial != null)
            {
                editorial.Nombre = data.Nombre;
              
                _context.Editorials.Update(editorial);
                result = await _context.SaveChangesAsync() > 0;
            }

            return result;
        }


        public async Task<bool> DeleteEditorial(int id)
        {
            bool result = false;
            var editorial = GetEditorial(id);
            if (editorial != null)
            {
                _context.Editorials.Remove(editorial);
                result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }


        #endregion
    }
}
