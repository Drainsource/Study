namespace HotelManagementLibrary.Interfaces
{
    public interface IDataAccess
    {
        List<T> LoadData<T, U>(string sql, U parameters, string connectionStringName = "Default", dynamic options = null);
        int SaveData<T>(string sql, T parameters, string connectionStringName = "Default", dynamic options = null);
    }
}