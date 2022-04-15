using AareonTechnicalTest.Models;
using System;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DataLogger
{
    public interface IDataLoggerRepository
    {
        Task<Boolean> LogData(AuditLog log);
    }
}
