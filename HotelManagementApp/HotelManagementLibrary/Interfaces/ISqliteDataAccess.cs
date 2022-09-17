namespace HotelManagementLibrary.Database
{
    public interface ISqliteDataAccess
    {
        List<T> LoadData<T, U>(string sql, U parameters, string connectionStringName = "Default");
        int SaveData<T>(string sql, T parameters, string connectionStringName = "Default");
    }
}