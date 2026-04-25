using GoodHamburger.Application.Dtos;
using GoodHamburger.Infra.Data;
using GoodHamburger.Infra.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Application.Queries
{
    public class CardapioQueryHandler : IRequestHandler<CardapioQuery, CardapioDto>
    {
        private readonly DataContext _dataContext;

        public CardapioQueryHandler(DataContext dataContext)
        {  
            _dataContext = dataContext; 
        }

        public async Task<CardapioDto> Handle(CardapioQuery query, CancellationToken cancellationToken)
        {
            var sanduiches = await _dataContext.Sanduiches.ToListAsync();

            var acompanhamentos = await _dataContext.Acompanhamentos.ToListAsync();

            return new CardapioDto
            {
                Sanduiches = sanduiches,
                Acompanhamentos = acompanhamentos
            };
        }
    }
}
