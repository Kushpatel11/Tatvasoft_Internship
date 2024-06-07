using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public class BALCommon
    {
        private readonly DALCommon _dalCommon;

        public BALCommon(DALCommon dalCommon)
        {
            _dalCommon = dalCommon;
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            return await _dalCommon.GetCountriesAsync();
        }

        public async Task<List<City>> GetCitiesAsync(int id)
        {
            return await _dalCommon.GetCitiesAsync(id);
        }

    }
}
