using FluentValidation;
using GestionDeMetas.Shared.DTO.Actividad;
using GestionDeMetas.Shared.DTO.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMetas.Shared.Validation
{
    public class ActividadValidation: AbstractValidator<ActividadDTO>
    {
        public ActividadValidation()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Nombre).MaximumLength(80).WithMessage("La longitud máxima es de 80");
        }
    }
    
}
