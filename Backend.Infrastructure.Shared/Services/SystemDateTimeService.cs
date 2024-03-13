using Backend.Application.Interfaces.Shared;
using System;

namespace Backend.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}