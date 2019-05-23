using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.DAO
{
    public interface IDao<T>
    {
        T Get(int id);

        List<T> GetAll();

        void Add(T obj);

        void Update(T obj);

        void Delete(T obj);
    }
}
