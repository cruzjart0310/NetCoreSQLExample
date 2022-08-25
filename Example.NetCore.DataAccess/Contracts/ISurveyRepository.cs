using Example.NetCore.DataAccess.Entities;
using Example.NetCore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.NetCore.DataAccess.Contracts
{
    public interface ISurveyRepository
    {
        Task<IEnumerable<Survey>> GetAllAsync(Pagination pagination);
        Task<Result<Survey>> GetAsync(int id);
        Task<Result<Survey>> CreateAsync(Survey entity);
        Task UpdateAsync(Survey entity);
        Task DeleteAsync(int id);
        Task<bool> ExistAsync(int id);
        Task<int> GetTotalRecorsdAsync();
    }
}
