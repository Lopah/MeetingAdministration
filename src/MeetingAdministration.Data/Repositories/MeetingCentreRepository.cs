using AutoMapper;
using MeetingAdministration.Core.Models;
using MeetingAdministration.Core.Repositories;
using MeetingAdministration.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingAdministration.Data.Repositories
{
    public class MeetingCentreRepository : IMeetingCentreRepository
    {
        private readonly MeetingDbContext _context;
        private readonly IMapper _mapper;

        public MeetingCentreRepository(MeetingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<MeetingCentreModel> AddAsync(MeetingCentreModel entity)
        {
            var mapped = _mapper.Map<MeetingCentre>(entity);

            await _context.MeetingCentres.AddAsync(mapped);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<MeetingCentreModel> DeleteAsync(MeetingCentreModel entity)
        {
            var mapped = _mapper.Map<MeetingCentre>(entity);

            _context.MeetingCentres.Remove(mapped);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IList<MeetingCentreModel>> GetAllAsync()
        {
            var returned = await _context.MeetingCentres.ToListAsync();

            return returned.Select(x => _mapper.Map<MeetingCentreModel>(x)).ToList();
        }

        public async Task<IList<MeetingCentreModel>> GetByCodeAsync(string code)
        {
            var returned = await _context.MeetingCentres
                .Where(x => x.Code == code)
                .ToListAsync();

            return returned.Select(x => _mapper.Map<MeetingCentreModel>(x)).ToList();
        }

        public async Task<IList<MeetingCentreModel>> GetByNameAsync(string name)
        {
            var returned = await _context.MeetingCentres
                .Where(x => x.Name == name)
                .ToListAsync();

            return returned.Select(x => _mapper.Map<MeetingCentreModel>(x)).ToList();
        }

        public async Task<MeetingCentreModel> UpdateAsync(MeetingCentreModel entity)
        {
            var mapped = _mapper.Map<MeetingCentre>(entity);
            _context.MeetingCentres.Update(mapped);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
