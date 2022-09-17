namespace HotelManagementLibrary.Interfaces
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T, U>(string sql, U parameters, string connectionStringName = "Default", bool isStoredProcedure = false);
        int SaveData<T>(string sql, T parameters, string connectionStringName = "Default", bool isStoredProcedure = false);
    }
}