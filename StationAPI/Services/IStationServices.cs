using System.Collections.Generic;

namespace StationAPI
{
    public interface IStationServices<T> where T : class
    {

        List<T> GetAllRows();

        void AddRow(T entity);

        T GetRowById(int id);

        bool UpdateRow(int id, T entity);

        void DeleteRow(T entity);
    }
}