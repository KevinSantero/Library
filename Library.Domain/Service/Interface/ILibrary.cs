using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Service.Interface
{
    public interface ILibrary
    {

        #region Methods
        Task<bool> InsertLibrary(Data.Models.Library data);

        Data.Models.Library GetLibrary(int id);

        Task<bool> UpdateLibrary(Data.Models.Library data);

        Task<bool> DeleteLibrary(int id);

        List<Data.Models.Library> SelectAllLibrary();

        #endregion
    }
}
