using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol.Core
{
    [Serializable]
    public class ItemViajeAsistido
    {
        public int dueñoId { get; set; } 

        public int ciudadOrigenId { get; set; }

        public int ciudadDestinoId { get; set; }

        public bool SiPagado { get; set; }

        public DateTime Fecha { get; set; }
    }
}
