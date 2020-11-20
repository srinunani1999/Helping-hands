using HelpingHandsApi.Data;
using HelpingHandsApi.Models;
using HelpingHandsApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace OrganizationServiceTest
{
    public class Tests
    {
        List<Organization> organizations = new List<Organization>();
        IQueryable<Organization> orgdata;
        Mock<DbSet<Organization>> mockSet;
        Mock<HelpingHandsApiContext> orgcontextmock;
        [SetUp]
        public void Setup()
        {

            organizations = new List<Organization>()
            {
                new Organization(){Id=1,OrganizationName="tnt",TotalDonations="10000"},
                new Organization(){Id=2,OrganizationName="ynt",TotalDonations="20000"},
                new Organization(){Id=3,OrganizationName="hnt",TotalDonations="30000"},
                new Organization(){Id=4,OrganizationName="pnt",TotalDonations="40000"}

            };
            orgdata = organizations.AsQueryable();
            mockSet = new Mock<DbSet<Organization>>();
          
            mockSet.As<IQueryable<Organization>>().Setup(m => m.Provider).Returns(orgdata.Provider);
            mockSet.As<IQueryable<Organization>>().Setup(m => m.Expression).Returns(orgdata.Expression);
            mockSet.As<IQueryable<Organization>>().Setup(m => m.ElementType).Returns(orgdata.ElementType);
            mockSet.As<IQueryable<Organization>>().Setup(m => m.GetEnumerator()).Returns(orgdata.GetEnumerator());
            var p = new DbContextOptions<HelpingHandsApiContext>();
            orgcontextmock = new Mock<HelpingHandsApiContext>(p);
            orgcontextmock.Setup(x => x.Organization).Returns(mockSet.Object);

        }

        [Test]
        public void GetAllTest()
        {
            var OrganizationsRepo = new OrganisationRepository(orgcontextmock.Object);
            var orglist = OrganizationsRepo.Get();
            Assert.AreEqual(4, orglist.Count());




        }
        [Test]
        public void GetByIdTest()
        {
            var orgrepo = new OrganisationRepository(orgcontextmock.Object);
            var org = orgrepo.GetById(4);
          
            Assert.AreEqual(4, org.Id);

        }
        [Test]
        public void PostOrganizationTest()
        {
            var orgrepo = new OrganisationRepository(orgcontextmock.Object);
            var org = orgrepo.Add2(new Organization() { Id = 9, OrganizationName = "tnt", TotalDonations = "10000" });

            Assert.AreEqual(9, org.Id);

        }


    }
}