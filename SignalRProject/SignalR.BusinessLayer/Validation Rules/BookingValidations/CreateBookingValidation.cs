using FluentValidation;
using SignalR.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Validation_Rules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon alanı boş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi alanı boş geçilemez!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez!");

            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Lütfen isim alanına en az 5 karakter veri girişi yapınız!").MaximumLength(50).WithMessage("Lütfen isim alanına en fazla 50 karakter veri girişi yapınız!");
            RuleFor(x => x.Description).MinimumLength(1).WithMessage("Lütfen açıklama alanına en az 1 karakter veri girişi yapınız!").MaximumLength(500).WithMessage("Lütfen açıklama alanına en fazla 500 karakter veri girişi yapınız!");
        }
    }
}
