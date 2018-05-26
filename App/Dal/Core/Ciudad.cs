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

        private const string GET_INSTANCE_BY_ID = @"SELECT * FROM Ciudad
	                                                WHERE Id = {0}";

        public DataSet GetAllByProvinciaId(int provId)
        {
            this.SelectCommandText = string.Format(GET_ALL_BY_PROVINCIA_ID, provId);
            return this.Load();
        }

        public DataSet GetInstanceById(int id)
        {
            this.SelectCommandText = string.Format(GET_INSTANCE_BY_ID, id);
            return this.Load();
        }
    }
}
