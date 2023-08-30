using Application.Features.ProgramingLanguage.Commands.CreateProgramingLanguages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage
{
    public class CreateProgramingLanguageCommandValidator : AbstractValidator<CreateProgramingLanguageCommand>
    {
        public CreateProgramingLanguageCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).NotNull();
        }
    }
}
