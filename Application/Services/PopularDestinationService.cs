﻿using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repository_Interfaces;
using Application.Models;


namespace Application.Services
{
    public class PopularDestinationService : IPopularDestinationService
    {
        private readonly IPopularDestinationRepository _popularDestinationRepository;

        public PopularDestinationService(IPopularDestinationRepository popularDestinationRepository)
        {
            _popularDestinationRepository = popularDestinationRepository;
        }
        public async Task<List<PopularDestination>> GetAllAsync()
        {
            var popularDestinations = await _popularDestinationRepository.GetAllAsync();

            if (popularDestinations.Count == 0)
            {
                throw new EntityNotFoundException(Constant.PopularDestinationsNotFoundError);
            }

            return popularDestinations;
        }
    }
}
