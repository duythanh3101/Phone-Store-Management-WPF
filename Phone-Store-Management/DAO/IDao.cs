using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.DAO
{
    public interface IDao<T>
    {
        T Get(long id);

        List<T> GetAll();

        void Add(T t);

        void Update(T t);

        void Delete(T t);
    }
}
