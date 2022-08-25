using Example.NetCore.DataAccess.Base;
using Example.NetCore.DataAccess.Contracts;
using Example.NetCore.DataAccess.Entities;
using Example.NetCore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.NetCore.DataAccess.Repositories
{
    public class SurveyRepository : MainDataAccess, ISurveyRepository
    {
        public SurveyRepository(AppSettings appSettings,
        IDataAccess dataAccess) : base(appSettings, dataAccess)
        {
        }

        public async Task<Result<Survey>> CreateAsync(Survey entity)
        {
            _dataAccess.ConnectionString(_connectionStrings.Default);
            _dataAccess.StoredProcedure("GET_SURVEYS");
            _dataAccess.AddParameter("@name", entity.Name);
            return await _dataAccess.ReadSingle<Survey>();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Survey>> GetAllAsync(Pagination pagination)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Survey>> GetAsync(int id)
        {
            _dataAccess.ConnectionString(_connectionStrings.Default);
            _dataAccess.StoredProcedure("GET_SURVEY_BY_ID");
            _dataAccess.AddParameter("@id", id);
            return await _dataAccess.ReadSingle<Survey>();
        }

        public Task<int> GetTotalRecorsdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Survey entity)
        {
            throw new NotImplementedException();
        }
    }
}
