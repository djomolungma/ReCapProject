using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //Manage Nuget packages add FluentValidation project
    //Kullanım dökümanlarına FluentValidation ın kendi sitesinden erişebiliriz
    public class CarValidator : AbstractValidator<Car>
    {
        //kurallar Constructor ın yazılır
        public CarValidator()
        {
            //Ctrl + K sonra Ctrl + D kodları hizalamak için
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
        }
    }
}
