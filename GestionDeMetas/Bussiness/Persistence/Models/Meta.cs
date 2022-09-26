using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMetas.Bussiness.Persistence.Models
{
    public class Meta
    {
        
        public string Id { get; set; }
        public string Nombre { get; set; }     
        public DateTime FechaCreacion { set; get; }
        public List<Actividad> Actividades { get; set; }
    }
}
