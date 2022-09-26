using FluentValidation;
using GestionDeMetas.Shared.DTO.Meta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeMetas.Shared.Validations
{
    public class MetaValidation: AbstractValidator<MetaDTO>
    {

        public MetaValidation()
        {

            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Nombre).MaximumLength(80).WithMessage("La longitud máxima es de 80");
            
        }
    }
}
