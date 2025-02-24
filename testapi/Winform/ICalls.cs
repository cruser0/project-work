using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Winform.Entities;

namespace Winform
{
    public interface ICalls<T>
    {
            //ICollection<T> GetAll();
            //T GetById(int id);
            T Create(T entity);
            T Update(int id, T entity);
            T Delete(int id);
    }
}
