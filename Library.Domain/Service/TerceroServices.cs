using TecnicalTestPersonas.Data.Models;
using TecnicalTestPersonas.Data.Repository.Interface;
using TecnicalTestPersonas.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnicalTestPersonas.Domain.Service
{//

    public class TerceroServices : ITercero
    {
        #region Attributes
        private readonly ITerceroRepository _repository;
        #endregion

        #region ctor
        public TerceroServices(ITerceroRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        //public Task<bool> DeleteTercero(int id)
        //{
        //    return _repository.DeleteTercero(id);
        //}

        public Tercero GetTercero(int id)
        {
            return _repository.GetTercero(id);
        }

        public Tercero GetTerceroByDocumento(string doc)
        {
            return _repository.GetAll().FirstOrDefault(x=>x.Documento== doc);
        }

        public Task<bool> InsertTercero(Tercero data)
        {
            return _repository.InsertTercero(data);
        }

        //public List<Tercero> SelectAllTercero()
        //{
        //    return _repository.GetAll().ToList();
        //}

        //public Task<bool> UpdateTercero(Tercero data)
        //{
        //    return _repository.UpdateTercero(data);
        //}

        #endregion


    }
}
