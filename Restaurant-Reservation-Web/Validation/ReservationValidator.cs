using FluentValidation;
using Restaurant_Reservation_Web.DTOs;

namespace Restaurant_Reservation_Web.Validation;

public class ReservationValidator : AbstractValidator<ReservationDto>
{
    public ReservationValidator()
    {
        RuleFor(x => x.CustomerId)
            .GreaterThan(0)
            .WithMessage("CustomerId must be a valid positive integer.");
        
        RuleFor(x => x.RestaurantId)
            .GreaterThan(0)
            .WithMessage("RestaurantId must be a valid positive integer.");
        
        RuleFor(x => x.TableId)
            .GreaterThan(0)
            .When(x => x.TableId.HasValue)
            .WithMessage("TableId must be a valid positive integer if provided.");
        
        RuleFor(x => x.ReservationDate)
            .GreaterThan(DateTime.Now)
            .WithMessage("Reservation date must be in the future.")
            .LessThanOrEqualTo(DateTime.Now.AddYears(1))
            .WithMessage("Reservation date cannot be more than one year in advance.");
        
        RuleFor(x => x.PartySize)
            .GreaterThan(0)
            .WithMessage("Party size must be at least 1.")
            .LessThanOrEqualTo(20)
            .WithMessage("Party size cannot exceed 20 guests."); 
    }
}