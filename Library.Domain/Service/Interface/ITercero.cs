using TecnicalTestPersonas.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TecnicalTestPersonas.Domain.Service.Interface
{
    public interface ITercero
    {
        #region Methods
        Task<bool> InsertTercero(Tercero data);
        Tercero GetTercero(int id);

        Tercero GetTerceroByDocumento(string doc);
        // Task<bool> UpdateTercero(Tercero data);
        // Task<bool> DeleteTercero(int id);
        //List<Tercero> SelectAllTercero();
        #endregion
    }
}
