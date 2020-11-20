using DonarService.Models;
using HelpingHandsApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonarService.Repositories
{
    public class DonorRepository : IRepository<Donar>
    {
        DonarsServiceContext _context = null;
        HelpingHandsApiContext organizationcontext = null;
        public DonorRepository(DonarsServiceContext context,HelpingHandsApiContext helpingHandsApiContext)
        {
            _context = context;
            organizationcontext = helpingHandsApiContext;
        }


        public int Add(Donar donar)
        {
            var organisation = organizationcontext.Organization.Find(donar.organization_Id);
            if (organisation != null)
            {
                _context.Add(donar);
                return _context.SaveChanges();
            }
             return -1;
            

           
           
        }
        public Donar Add2(Donar donar)
        {
            var organisation = organizationcontext.Organization.Find(donar.organization_Id);
            if (organisation != null)
            {
                _context.Add(donar);
                 _context.SaveChanges();
            }
            return donar;




        }



        public Donar GetById(int id)
        {
           // var donar = _context.Donardetails.Find(id);
            var donar = _context.Donardetails.FirstOrDefault(cw=>cw.DonorId==id);

            return donar;
        }

        public IEnumerable<Donar> Get()
        {
            return _context.Donardetails.ToList();
            
        }


    }
}
