using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMetas.Shared.DTO.Meta
{
    public class DetalleMetaDTO:MetaDTO
    {
        public double porcentajeAvance { get; set; }
        public int actividadesConcluidas { get; set; }
        public int totalActividades { get; set; }
    }
}
