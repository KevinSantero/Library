using Library.Data.Models;
using Library.Data.Repository.Interface;
using Library.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Service
{
    public class LibraryServices : ILibrary
    {
        #region Attributes
        private readonly ILibraryRepository _repository;
        #endregion

        #region ctor
        public LibraryServices(ILibraryRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public Task<bool> DeleteLibrary(int id)
        {
            return _repository.DeleteLibrary(id);
        }

        public Data.Models.Library GetLibrary(int id)
        {
            return _repository.GetLibrary(id);
        }

        public Task<bool> InsertLibrary(Data.Models.Library data)
        {
            return _repository.InsertLibrary(data);
        }

        public Task<bool> UpdateLibrary(Data.Models.Library data)
        {
            return _repository.UpdateLibrary(data);
        }

        public List<Data.Models.Library> SelectAllLibrary()
        {
            return _repository.GetAll().ToList();
        }
    }
}
