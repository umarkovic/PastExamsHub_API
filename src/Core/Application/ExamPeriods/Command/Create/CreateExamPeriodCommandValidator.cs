using FluentValidation;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.Courses.Commands.Create;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Command.Create
{
    public class CreateExamPeriodCommandValidator : AbstractValidator<CreateExamPeriodCommand>
    {
        readonly IBaseRepository<ExamPeriod> ExamPeriodRepository;
        public CreateExamPeriodCommandValidator
        (
            IBaseRepository<ExamPeriod> examPeriodRepository
        )
        {
            ExamPeriodRepository = examPeriodRepository;


            RuleFor(x => x.EndDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .WithMessage("Polje za završetak roka je obavezno!");


            RuleFor(x => x.StartDate)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .NotNull()
               .WithMessage("Polje za završetak roka je obavezno!");

            RuleFor(x => x.EndDate)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(x => x.StartDate).WithMessage("Datum završetka roka mora biti veći od datuma početka.");


            RuleFor(x => x.StartDate)
               .Cascade(CascadeMode.Stop)
               .LessThan(x => x.EndDate).WithMessage("Datum početka roka mora biti manji od datuma završetka.");


            RuleFor(x => x.Name)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
               .Must((context, name, cancellation) =>
               {
                   var names = ExamPeriodRepository
                   .GetQuery()
                   .Select(x => x.Name)
                   .ToList();

                   return !names.Any(y => y == name);

               }).When(x => x.Name != null)

            .WithMessage("Ispitni rok već postoji.");

        }
    }

}
