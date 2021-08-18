using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using WebAutopark.Core.Entities;
using WebAutopark.DataAccess.Repositories.Base;

namespace WebAutopark.DataAccess.Repositories
{
    public class VehicleRepository : ConnectionRepository<Vehicle>, IRepository<Vehicle>
    {
        private const string QueryGetAll = "SELECT V.*, VT.VehicleTypeId AS VTId, VT.TypeName, VT.TaxCoeff "
                                           + "FROM Vehicles AS V "
                                           + "INNER JOIN VehicleTypes AS VT ON V.VehicleTypeId = VT.VehicleTypeId";

        private const string QueryGetById = "SELECT V.*, VT.VehicleTypeId AS VTId, VT.TypeName, VT.TaxCoeff "
                                            + "FROM Vehicles AS V "
                                            + "INNER JOIN VehicleTypes AS VT ON V.VehicleTypeId = VT.VehicleTypeId "
                                            + "WHERE V.VehicleId = @id";

        private const string QueryCreate = "INSERT INTO Vehicles ("
                                           + "VehicleTypeId, ModelName, RegistrationNumber, Weight, ManufactureYear, "
                                           + "Mileage, Color, EngineType, EngineCapacity, EngineConsumption, EnergyTankCapacity) "
                                           + "VALUES("
                                           + "@VehicleTypeId, @ModelName, @RegistrationNumber, @Weight, @ManufactureYear, "
                                           + "@Mileage, @Color, @EngineType, @EngineCapacity, @EngineConsumption, @EnergyTankCapacity)";


        private const string QueryUpdate = "UPDATE Vehicles SET "
                                           + "VehicleTypeId = @VehicleTypeId, "
                                           + "ModelName = @ModelName, "
                                           + "RegistrationNumber = @RegistrationNumber, "
                                           + "Weight = @Weight, "
                                           + "ManufactureYear = @ManufactureYear, "
                                           + "Mileage = @Mileage, "
                                           + "Color = @Color, "
                                           + "EngineType = @EngineType, "
                                           + "EngineCapacity = @EngineCapacity, "
                                           + "EngineConsumption = @EngineConsumption, "
                                           + "EnergyTankCapacity = @EnergyTankCapacity "
                                           + "WHERE VehicleId = @VehicleId";

        private const string QueryDelete = "DELETE FROM Vehicles WHERE VehicleId = @id";

        public VehicleRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<Vehicle> Get(int id) => await DbConnection.QueryFirstAsync<Vehicle>(QueryGetById, new { id });

        public async Task<IEnumerable<Vehicle>> GetAll() => await DbConnection.QueryAsync<Vehicle>(QueryGetAll);

        public async Task Create(Vehicle element) => await DbConnection.ExecuteAsync(QueryCreate, element);

        public async Task Update(Vehicle element) => await DbConnection.ExecuteAsync(QueryUpdate, element);

        public async Task Delete(int id) => await DbConnection.ExecuteAsync(QueryDelete, new { id });
    }
}
