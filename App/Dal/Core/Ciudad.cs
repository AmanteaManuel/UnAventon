using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Core
{
    public class Ciudad:DalBase
    {
        private const string GET_ALL_BY_PROVINCIA_ID = @" SELECT * FROM Ciudad where ProvinciaId = {0}
                                                            order by Ciudad.Descripcion asc";

        public DataSet GetAllByProvinciaId(int provId)
        {
            this.SelectCommandText = string.Format(GET_ALL_BY_PROVINCIA_ID, provId);
            return this.Load();
        }
    }
}
