using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Service.Interface
{
    public interface IEditorial
    {
        #region Methods
        Task<bool> InsertEditorial(Editorial data);
        Editorial GetEditorial(int id);
        Task<bool> UpdateEditorial(Editorial data);
        Task<bool> DeleteEditorial(int id);
       List<Editorial> SelectAllEditorial();
        #endregion
    }
}
