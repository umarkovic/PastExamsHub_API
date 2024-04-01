using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.Exams.Command.Create
{
    public class CreateExamCommandValidator : AbstractValidator<CreateExamCommand>
    {
        readonly IBaseRepository<ExamPeriod> ExamPeriodRepository;
        public CreateExamCommandValidator
       (
            IBaseRepository<ExamPeriod> examPeriodRepository
       )
    {
            ExamPeriodRepository = examPeriodRepository;


            RuleFor(x => x.ExamDate)
                .Cascade(CascadeMode.Stop)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage("Polje za datum odrzavanja ispita je obavezno!");

            RuleFor(x => x.PeriodUid)
               .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty().WithMessage("Ispitni rok nije izabran.");

            RuleFor(x => x.CourseUid)
               .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty().WithMessage("Predmet  nije izabran.");



            RuleFor(x => x.Type)
                 .NotNull()
                 .NotEmpty().WithMessage("Polje za tip ispita nije izabrano.");

            RuleFor(x => x.File)
                .NotNull()
                .NotEmpty().WithMessage("Dokument ili slika ispita je obavezno!");


        }
    }
}
