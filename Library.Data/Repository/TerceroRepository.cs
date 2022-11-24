using TecnicalTestPersonas.Data.Models;
using TecnicalTestPersonas.Data.Repository.Interface;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnicalTestPersonas.Data.Repository
{
    public class TerceroRepository : Repository<Tercero>, ITerceroRepository
    {

        #region Attributes
        private readonly DataContext _context;
        #endregion

        #region Ctor

        public TerceroRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<bool> InsertTercero(Models.Tercero data)
        {
            _context.Terceros.Add(data);
            return await _context.SaveChangesAsync() > 0;
        }

        public Tercero GetTercero(int id)
        {
            var data = _context.Terceros.FirstOrDefault(x => x.Id == id);
            return data;
        }

        //public async Task<bool> UpdateTercero(Models.Tercero data)
        //{
        //    bool result = false;
        //    var Tercero = GetTercero(data.Id);

        //    if (Tercero != null)
        //    {
        //        Tercero.Nombre = data.Nombre;
              
        //        _context.Terceros.Update(Tercero);
        //        result = await _context.SaveChangesAsync() > 0;
        //    }

        //    return result;
        //}


        //public async Task<bool> DeleteTercero(int id)
        //{
        //    bool result = false;
        //    var Tercero = GetTercero(id);
        //    if (Tercero != null)
        //    {
        //        _context.Terceros.Remove(Tercero);
        //        result = await _context.SaveChangesAsync() > 0;
        //    }
        //    return result;
        //}


        #endregion
    }
}
