using AareonTechnicalTest.DataServices;
using AareonTechnicalTest.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AareonTechnicalTest.DataLogger
{
    public class SqlLiteDataLogger : BaseDataLogger
    {
        private readonly ApplicationContext _dbContext;                
        public SqlLiteDataLogger(ApplicationContext dbcontext)
        {
            _dbContext = dbcontext;            
        }
        public async override Task<bool> LogData(AuditLog log)
        {            
            await _dbContext.AuditLogs.AddAsync(log);
            var result = await _dbContext.SaveChangesAsync();
            if(result > 0)
                return true;
             
            return false;
        }
    }
}
