using TecnicalTestPersonas.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TecnicalTestPersonas.Data.Repository.Interface
{
    public interface ITerceroRepository : IRepository<Tercero>
    {
        #region Methods
        Task<bool> InsertTercero(Models.Tercero data);
        Tercero GetTercero(int id);
        //Task<bool> UpdateTercero(Models.Tercero data);
        //Task<bool> DeleteTercero(int id);
        #endregion
    }
}
