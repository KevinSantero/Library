using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repository.Interface
{
    public interface ILibraryRepository : IRepository<Models.Library>
    {
        #region Methods
        Task<bool> InsertLibrary(Models.Library data);

        Models.Library GetLibrary(int id);

        Task<bool> UpdateLibrary(Models.Library data);

        Task<bool> DeleteLibrary(int id);

        #endregion

    }
}
