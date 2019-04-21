using DataAccessLayer;
using DataAccessLayer.DataModel;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebAPI.Test.Builders;

namespace UsersWebAPI.Test
{
    [TestClass]
    public class RoleDataTest
    {
        public void GetAllRoles_ShouldReturnAllRoles_OK()
        {
            var mockedList = MockedRoleList();

            var mockedRepo = new Mock<IRoleRepository>();

            mockedRepo.Setup(m => m.GetAllRoles()).ReturnsAsync(mockedList);

            //Subject under test...
            var sut = new RoleData(mockedRepo.Object);

            //Act
            var result = sut.GetAllRoles().Result;

            //Assert
            Assert.AreEqual(mockedList, result);
            mockedRepo.Verify(m => m.GetAllRoles(), Times.Once);
        }

        private List<Roles> MockedRoleList()
        {
            var builder = new RoleBuilder();

            List<Roles> roleList = new List<Roles>
            {
                builder.WithId(1).WithName("PAGE_1").Build(),
                builder.WithId(2).WithName("PAGE_2").Build()
            };

            return roleList;
        }
    }
}
