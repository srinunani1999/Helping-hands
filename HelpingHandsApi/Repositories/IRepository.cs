using HelpingHandsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHandsApi.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T GetById(int id);
        int Add(T org);
        T Update(T organization);

    }
}
