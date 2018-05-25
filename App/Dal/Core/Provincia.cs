using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Core
{
    public class Provincia: DalBase
    {
        private const string GET_ALL = @"SELECT * FROM Provincia
	                                        order by Provincia.Descripcion asc";

        public DataSet GetAll()
        {
            this.SelectCommandText = string.Format(GET_ALL);
            return this.Load();
        }
    }
}
