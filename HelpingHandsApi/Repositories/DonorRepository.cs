using HelpingHandsApi.Data;
using HelpingHandsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHandsApi.Repositories
{
    public class DonorRepository : IRepository<Donar>
    {
        HelpingHandsApiContext _context = null;
        public DonorRepository(HelpingHandsApiContext context)
        {
            _context = context;
        }
        

        public int Add(Donar donar)
        {
            throw new NotImplementedException();
        }

       

        public Donar GetById(int id)
        {
            throw new NotImplementedException();
        }

         public IEnumerable<Donar> Get()
        {
            throw new NotImplementedException();
        }

     


        public Donar Update(Donar org, double sum)
        {
            throw new NotImplementedException();
        }

        public Donar Update( Donar organization)
        {
            throw new NotImplementedException();
        }
    }
}
