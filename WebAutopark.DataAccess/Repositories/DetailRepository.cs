using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;

namespace WebAutopark.DataAccess.Repositories
{
    public class DetailRepository : ConnectionRepository, IRepository<DetailViewModel>
    {
        private const string QueryGetAll = "SELECT * FROM Details " +
                                           "ORDER BY DetailId";

        private const string QueryGetById = "SELECT * FROM Details WHERE DetailId = @id";

        private const string QueryCreate = "INSERT INTO Details (Name) VALUES(@Name)";

        private const string QueryUpdate = "UPDATE Details SET Name = @Name WHERE DetailId = @DetailId";

        private const string QueryDelete = "DELETE FROM Details WHERE DetailId = @id";

        public DetailRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<DetailViewModel> Get(int id) => await DbConnection.QueryFirstAsync<DetailViewModel>(QueryGetById, new { id });

        public async Task<IEnumerable<DetailViewModel>> GetAll() => await DbConnection.QueryAsync<DetailViewModel>(QueryGetAll);

        public async Task Create(DetailViewModel element) => await DbConnection.ExecuteAsync(QueryCreate, element);

        public async Task Update(DetailViewModel element) => await DbConnection.ExecuteAsync(QueryUpdate, element);

        public async Task Delete(int id) => await DbConnection.ExecuteAsync(QueryDelete, new { id });
    }
}
