using Library.Data.Models;
using Library.Data.Repository.Interface;
using Library.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Service
{//
    public class EditorialServices : IEditorial
    {
        #region Attributes
        private readonly IEditorialRepository _repository;
        #endregion

        #region ctor
        public EditorialServices(IEditorialRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public Task<bool> DeleteEditorial(int id)
        {
            return _repository.DeleteEditorial(id);
        }

        public Editorial GetEditorial(int id)
        {
            return _repository.GetEditorial(id);
        }

        public Task<bool> InsertEditorial(Editorial data)
        {
            return _repository.InsertEditorial(data);
        }

        public List<Editorial> SelectAllEditorial()
        {
            return _repository.GetAll().ToList();
        }

        public Task<bool> UpdateEditorial(Editorial data)
        {
            return _repository.UpdateEditorial(data);
        }

        #endregion


    }
}
