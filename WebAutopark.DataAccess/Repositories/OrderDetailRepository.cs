using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;
using WebAutopark.DataAccess.Repositories.Specification;

namespace WebAutopark.DataAccess.Repositories
{
    public class OrderDetailRepository : ConnectionRepository<OrderDetail>, IRepository<OrderDetail>
    {
        public OrderDetailRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }
        public async Task<OrderDetail> Get(int id)
        {
            var collection = await DbConnection.QueryAsync<OrderDetail, Detail, OrderDetail>
            (
                QueryGetById, (orderElement, detail) =>
                {
                    orderElement.Detail = detail;
                    return orderElement;
                },
                splitOn: "OrderDetailId",
                param: new { id }
            );

            return collection.First();
        }
        public async Task<IEnumerable<OrderDetail>> GetAll() =>
            await DbConnection.QueryAsync<OrderDetail, Detail, OrderDetail>
            (
                QueryGetAll, (orderElement, detail) =>
                {
                    orderElement.Detail = detail;
                    return orderElement;
                },
                splitOn: "OrderDetailId"
            );

        public async Task Create(OrderDetail element) => await DbConnection.ExecuteAsync(QueryCreate, element);

        public async Task Update(OrderDetail element) => await DbConnection.ExecuteAsync(QueryUpdate, element);

        public async Task Delete(int id) => await DbConnection.ExecuteAsync(QueryDelete, id);
    }
}
