using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repository.Interface
{
    public interface IEditorialRepository : IRepository<Editorial>
    {
        #region Methods
        Task<bool> InsertEditorial(Models.Editorial data);
        Editorial GetEditorial(int id);
        Task<bool> UpdateEditorial(Models.Editorial data);
        Task<bool> DeleteEditorial(int id);
        #endregion
    }
}
