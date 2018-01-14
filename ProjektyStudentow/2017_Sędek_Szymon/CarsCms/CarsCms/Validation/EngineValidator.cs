using CarsCms.Models;
using FluentValidation;

namespace CarsCms.Validation
{
    public class EngineValidator : AbstractValidator<Engine>
    {
        public EngineValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Pole nazwa silnika nie może być puste");
            RuleFor(x => x.Name).Must(name => Costam(name)).WithMessage("cost tam");
            RuleFor(x => x.EngineCapacity).Must((x, capacity) => CheckEngineAndCapacityRule(capacity, x))
                .WithMessage("hgddhghdchg");
        }

        private bool Costam(string name)
        {
            return true;
        }

        private bool CheckEngineAndCapacityRule(int cap, Engine engine)
        {
            if (cap > 1598 && cap < 1601)
                return engine.Weight > 650;
            return true;
        }
        
    }
}