using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Dto;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.DataModel;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UsersWebAPI.Test.Builders;

namespace UsersWebAPI.Test
{
    [TestClass]
    public class UsersDataTest
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetAllUsersAsync_Should_Return_AllUsers_OK()
        {
            //Arrange
            var mockedList = MockedUsersList();

            var mockedRepo = new Mock<IUserRepository>();

            mockedRepo.Setup(m => m.GetAllUsersAsync()).ReturnsAsync(mockedList);

            //Subject under test...
            var sut = new UsersData(mockedRepo.Object);

            //Act
            var result = sut.GetAllUsersAsync().Result;

            //Assert
            Assert.AreEqual(mockedList, result);
            mockedRepo.Verify(m => m.GetAllUsersAsync(), Times.Once);
        }

        [TestMethod]
        public void GetByCredentials_Should_Return_User_OK()
        {
            //Arrange
            var mockedRepo = new Mock<IUserRepository>();

            var mockUser = new UserBuilder().ConId(1).ConUsername("tsoukalos").ConPassword("aliens").Build();

            mockedRepo.Setup(m => m.GetByCredentials(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(mockUser);

            var sut = new UsersData(mockedRepo.Object);

            //Act
            var result = sut.GetByCredentials(mockUser.Username, mockUser.UserPassword).Result;

            //Assert
            Assert.AreEqual(mockUser, result);
            mockedRepo.Verify(m => m.GetByCredentials(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetByIdAsync()
        {
            //Arrange
            var mockedRepo = new Mock<IUserRepository>();

            var mockUser = new UserBuilder().ConId(1).ConUsername("guybrush").ConPassword("threeheadedmonkeys").Build();

            mockedRepo.Setup(m => m.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(mockUser);

            var sut = new UsersData(mockedRepo.Object);

            //Act
            var result = sut.GetById(mockUser.Id).Result;

            //Assert
            Assert.AreEqual(mockUser, result);
            mockedRepo.Verify(m => m.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }

        public void Insert()
        {
            var mockedRepo = new Mock<IUserRepository>();

            var mockUser = new UserBuilder().ConId(1).ConUsername("guybrush").ConPassword("threeheadedmonkeys").Build();

            mockedRepo.Setup(m => m.Insert(It.IsAny<Users>()));

            var sut = new UsersData(mockedRepo.Object);

            //Act
            var result = sut.GetById(mockUser.Id).Result;

            //Assert
            Assert.AreEqual(mockUser, result);
            mockedRepo.Verify(m => m.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }

        //public Task Update(Users user)
        //{
        //    throw new NotImplementedException();
        //}

        private IEnumerable<Users> MockedUsersList()
        {
            var userBuilder = new UserBuilder();
            var list = new List<Users>
            {
                userBuilder.ConId(1).ConUsername("edu").ConPassword("hahaaha").Build(),
                userBuilder.ConId(1).ConUsername("donaldtduck").ConPassword("jejej").Build(),
                userBuilder.ConId(1).ConUsername("m.rajoy").ConPassword("cajab").Build()
            };

            return list;
        }
    }
}
