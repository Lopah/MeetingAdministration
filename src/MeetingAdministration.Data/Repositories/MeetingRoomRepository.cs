using AutoMapper;
using MeetingAdministration.Core.Interfaces;
using MeetingAdministration.Core.Models;
using MeetingAdministration.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingAdministration.Data.Repositories
{
    public class MeetingRoomRepository : IMeetingRoomRepository
    {
        private readonly MeetingDbContext _context;
        private readonly IMapper _mapper;

        public MeetingRoomRepository(MeetingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<MeetingRoomModel> AddAsync(MeetingRoomModel entity)
        {
            var mapped = _mapper.Map<MeetingRoom>(entity);
            await _context.MeetingRooms.AddAsync(mapped);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<MeetingRoomModel> DeleteAsync(MeetingRoomModel entity)
        {
            var mapped = _mapper.Map<MeetingRoom>(entity);
            _context.MeetingRooms.Remove(mapped);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<IList<MeetingRoomModel>> GetAllAsync()
        {
            var returned = await _context.MeetingRooms.ToListAsync();

            return returned.Select(x => _mapper.Map<MeetingRoomModel>(x)).ToList();
        }

        public async Task<IList<MeetingRoomModel>> GetByIsVideoConference(bool isVideoConference)
        {
            var returned = await _context.MeetingRooms
                .Where(e => e.IsVideoConference == isVideoConference)
                .ToListAsync();

            return returned.Select(x => _mapper.Map<MeetingRoomModel>(x)).ToList();
        }

        public async Task<IList<MeetingRoomModel>> GetByNameAsync(string name)
        {
            var returned = await _context.MeetingRooms
                .Where(e => e.Name == name)
                .ToListAsync();

            return returned.Select(x => _mapper.Map<MeetingRoomModel>(x)).ToList();
        }

        public async Task<IList<MeetingRoomModel>> GetByRoomCodeAsync(string code)
        {
            var returned = await _context.MeetingRooms
                .Where(e => e.Code == code)
                .ToListAsync();

            return returned.Select(x => _mapper.Map<MeetingRoomModel>(x)).ToList();
        }

        public async Task<MeetingRoomModel> UpdateAsync(MeetingRoomModel entity)
        {
            var mapped = _mapper.Map<MeetingRoom>(entity);
            _context.MeetingRooms.Update(mapped);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
