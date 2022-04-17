using AareonTechnicalTest.DataServices;
using AareonTechnicalTest.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
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
        public async override Task<bool> LogData<T>(T newData,string source, string operationCode)
        {
            var auditLog = new AuditLog()
            {
                Source = source,
                CreatedDateTime = DateTime.Now,
                TransactionDateTime = DateTime.Now,                               
                OperationType = operationCode,               
                Content = JsonConvert.SerializeObject(newData)
            };

            await _dbContext.AuditLogs.AddAsync(auditLog);
            var result = await _dbContext.SaveChangesAsync();
            if(result > 0)
                return true;
             
            return false;
        }
    }
}
