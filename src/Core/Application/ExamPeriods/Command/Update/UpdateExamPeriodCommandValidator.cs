using FluentValidation;
using PastExamsHub.Base.Application.Common.Interfaces;
using PastExamsHub.Core.Application.ExamPeriods.Command.Create;
using PastExamsHub.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamPeriods.Command.Update
{
    public class UpdateExamPeriodCommandValidator : AbstractValidator<UpdateExamPeriodCommand>
    {
        readonly IBaseRepository<ExamPeriod> ExamPeriodRepository;
        public UpdateExamPeriodCommandValidator
        (
            IBaseRepository<ExamPeriod> examPeriodRepository
        )
        {
            ExamPeriodRepository = examPeriodRepository;

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate);


            RuleFor(x => x.Name)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
               .MustAsync(async (context, name, cancellation) =>
               {
                   var program = await ExamPeriodRepository.GetByUidAsync(context.Uid, cancellation);


                   if (program!=null && program?.Name != context.Name)
                   {
                       var names = ExamPeriodRepository
                       .GetQuery()
                       .Select(x =>x.Name)
                       .ToList();

                       return !names.Any(y => y == name);
                   }

                   return true;

               }).When(x => !string.IsNullOrEmpty(x.Name))
            .WithMessage("Exam period name already exist.");

        }
    }

}

