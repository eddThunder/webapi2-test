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

            mockedRepo.Setup(m => m.GetByCredentials(mockUser.Username, mockUser.UserPassword)).ReturnsAsync(mockUser);

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

            mockedRepo.Setup(m => m.GetByIdAsync(mockUser.Id)).ReturnsAsync(mockUser);

            var sut = new UsersData(mockedRepo.Object);

            //Act
            var result = sut.GetById(1).Result;

            //Assert
            Assert.AreEqual(mockUser, result);
            mockedRepo.Verify(m => m.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void Insert_Should_InsertUser_OK()
        {
            var mockedRepo = new Mock<IUserRepository>();

            var mockUser = new UserBuilder().ConId(1).ConUsername("LeChuck").ConPassword("elaine").Build();

            mockedRepo.Setup(m => m.Insert(It.IsAny<Users>())).ReturnsAsync(2);

            var sut = new UsersData(mockedRepo.Object);

            //Act
            var result = sut.Insert(mockUser).Result;

            //Assert
            Assert.AreNotEqual(0, result);
            mockedRepo.Verify(m => m.Insert(mockUser), Times.Once);
        }

        //[TestMethod]
        //public void Update_ShouldUpdateUser_OK()
        //{
        //    var mockedRepo = new Mock<IUserRepository>();

        //    var mockUser = new UserBuilder().ConId(1).ConUsername("Haggis").ConPassword("rock").Build();

        //    mockedRepo.Setup(m => m.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(mockUser);
        //    mockedRepo.Setup(m => m.Update(It.IsAny<Users>())).ReturnsAsync(2);
            
        //    var sut = new UsersData(mockedRepo.Object);

        //    var insertOp = sut.Insert(mockUser).Result;

        //    var originalUser = sut.GetById(mockUser.Id).Result;

        //    //Act
        //    mockUser.Username = "Rufus";

        //    var result = sut.Update(mockUser).Result;
        //    var modifiedUser = sut.GetById(originalUser.Id).Result;

        //    //Assert
        //    Assert.AreNotEqual(originalUser, modifiedUser);
        //    mockedRepo.Verify(m => m.Update(mockUser), Times.Once);
        //}

        private IEnumerable<Users> MockedUsersList()
        {
            var userBuilder = new UserBuilder();
            var list = new List<Users>
            {
                userBuilder.ConId(1).ConUsername("edu").ConPassword("hahaaha").Build(),
                userBuilder.ConId(2).ConUsername("DonaldDuck").ConPassword("jejej").Build(),
                userBuilder.ConId(3).ConUsername("m.rajoy").ConPassword("cajab").Build()
            };

            return list;
        }
    }
}
