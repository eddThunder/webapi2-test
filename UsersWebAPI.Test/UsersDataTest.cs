using DataAccessLayer;
using DataAccessLayer.DataModel;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using UsersWebAPI.Test.Builders;

namespace UsersWebAPI.Test
{
    [TestClass]
    public class UsersDataTest
    {

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

            var mockUser = new UserBuilder().WithId(1).WithUsername("tsoukalos").WithPassword("aliens").Build();

            mockedRepo.Setup(m => m.GetByCredentials(mockUser.Username, mockUser.UserPassword)).ReturnsAsync(mockUser);

            var sut = new UsersData(mockedRepo.Object);

            //Act
            var result = sut.GetByCredentials(mockUser.Username, mockUser.UserPassword).Result;

            //Assert
            Assert.AreEqual(mockUser, result);
            mockedRepo.Verify(m => m.GetByCredentials(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetByIdAsync_ShouldReturn_SpecificUserBYId_OK()
        {
            //Arrange
            var mockedRepo = new Mock<IUserRepository>();

            var mockUser = new UserBuilder().WithId(1).WithUsername("guybrush").WithPassword("threeheadedmonkeys").Build();

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

            var mockUser = new UserBuilder().WithId(1).WithUsername("LeChuck").WithPassword("elaine").Build();

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
                userBuilder.WithId(1).WithUsername("edu").WithPassword("hahaaha").Build(),
                userBuilder.WithId(2).WithUsername("DonaldDuck").WithPassword("jejej").Build(),
                userBuilder.WithId(3).WithUsername("m.rajoy").WithPassword("cajab").Build()
            };

            return list;
        }
    }
}
