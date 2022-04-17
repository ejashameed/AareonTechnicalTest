using AareonTechnicalTest.Models;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DataLogger
{
    public abstract class BaseDataLogger : IDataLoggerRepository
    {
        public abstract Task<bool> LogData<T>(T log, string source, string operationCode);
        
    }
}
