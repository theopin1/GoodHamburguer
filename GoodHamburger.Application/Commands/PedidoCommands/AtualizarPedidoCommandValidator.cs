using FluentValidation;
using GoodHamburger.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Application.Commands.PedidoCommands
{
    public class AtualizarPedidoCommandValidator : AbstractValidator<AtualizarPedidoCommand>
    {
        public AtualizarPedidoCommandValidator(DataContext context)
        {

            RuleFor(x => x.SanduicheId)
                .NotNull();

            RuleFor(x => x.AcompanhamentosIds)
                .Must(NaoTemDuplicatas)
                .WithMessage("Não é permitido acompanhamentos repetidos.");
        }

        private bool NaoTemDuplicatas(List<int>? ids)
        {
            if (ids == null) return true;
            return ids.Count == ids.Distinct().Count();
        }
    }
}
