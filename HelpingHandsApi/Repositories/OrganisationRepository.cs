using HelpingHandsApi.Data;
using HelpingHandsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelpingHandsApi.Repositories
{
    public class OrganisationRepository : IRepository<Organization>
    {
        HelpingHandsApiContext _context = null;
        public OrganisationRepository(HelpingHandsApiContext context)
        {
            this._context = context;
        }
        public int Add(Organization org)
        {
            _context.Organization.Add(org);
           return _context.SaveChanges();

           
        
        }
        //this method is to check for testing
        public Organization Add2(Organization org)
        {
            _context.Organization.Add(org);
             _context.SaveChanges();
            return org;



        }
      



        public IEnumerable<Organization> Get()
        {
            var organizations= _context.Organization.ToList();

            return organizations;
            
        }

        public Organization GetById(int id)
        {
           var org= _context.Organization.FirstOrDefault(c=>c.Id==id);
            return org;
        }

        public Organization Update(Organization organization)
        {
           

            
            _context.Organization.Update(organization);
            _context.SaveChanges();
            return organization;
        }
    }
}
