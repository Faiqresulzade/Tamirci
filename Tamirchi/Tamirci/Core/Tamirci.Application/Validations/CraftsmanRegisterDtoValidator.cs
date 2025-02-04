using FluentValidation;
using Tamirci.Application.DTOs;

namespace Tamirci.Application.Validations;

public class CraftsmanRegisterDtoValidator : AbstractValidator<CraftsmanRegisterDto>
{
    public CraftsmanRegisterDtoValidator()
    {
        RuleFor(craftsman => craftsman.Name).NotEmpty().MinimumLength(3).MaximumLength(20).WithName("Ad");
        RuleFor(craftsman => craftsman.Surname).NotEmpty().MaximumLength(20).MinimumLength(2).WithName("Soyad");
        RuleFor(craftsman => craftsman.Email).NotEmpty().MaximumLength(40).MinimumLength(6).EmailAddress().WithName("Gmail adressi");
        RuleFor(craftsman => craftsman.Password).NotEmpty().MinimumLength(6).WithName("giriş kodu");
        RuleFor(craftsman => craftsman.ConfirmPassword)
            .NotEmpty().MinimumLength(6).Equal(x => x.Password)
            .WithName("giriş kodu təkrarı").WithMessage("kod ilə kod təkrarı eyni deyil! ");
    }
}
