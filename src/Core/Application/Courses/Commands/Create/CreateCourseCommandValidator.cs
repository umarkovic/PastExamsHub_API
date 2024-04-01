using FluentValidation;
using PastExamsHub.Core.Application.Users.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Courses.Commands.Create
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();


            RuleFor(x => x.Name)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
              .NotNull()
              .WithMessage("Polje za unos imena je obavezno!");


            RuleFor(x => x.StudyYear)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
              .NotNull()
              .WithMessage("Polje za unos imena je obavezno!!");

            RuleFor(x => x.LecturerUid)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .NotNull()
               .WithMessage("Polje za unos imena je obavezno!!");
        }
    }
}
