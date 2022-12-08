using System;
using NUnit.Framework;
using Moq;
using GMAPI4;
using GMAPI4.Models;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture]
    public class ApiTDD
    {
        Mock<IGymServices<object>> serviceMock;
        TestServices testServices;
        Mock<IGymServices<Location>> locationServiceMock;
        LocationTestServices testLocationServices;

        int id = 2;
        object tempObject = "object";
        Location location = new Location();

        [SetUp]
        public void SetUp()
        {
            serviceMock = new Mock<IGymServices<object>>();
            testServices = new TestServices(serviceMock.Object);

            locationServiceMock = new Mock<IGymServices<Location>>();
            testLocationServices = new LocationTestServices(locationServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            serviceMock = null;
            testServices = null;
        }

        [Test]
        public void Test_ReadAll_CalledGetAllRowsOnce_WhenCalled()
        {
            //Arrange

            //Act
            testServices.ReadAll();

            //Assert
            serviceMock.Verify(a => a.GetAllRows(), Times.Once);
        }

        [Test]
        public void Test_ReadAll_GetAllRowsReturnsList_WhenStubbed()
        {
            //Arrange
            serviceMock.Setup(a => a.GetAllRows()).Returns(new List<object>());

            //Act
            List<object> objects = testServices.ReadAll();

            //Assert
            Assert.IsInstanceOf<List<object>>(objects);
        }

        [Test]
        public void Test_ReadAll_GetAllRowsReturnsListOfNonEmpty_WhenStubbed()
        {
            //Arrange
            serviceMock.Setup(a => a.GetAllRows()).Returns(new List<object> { new Object(), new Object() });

            //Act
            List<object> objects = testServices.ReadAll();

            //Assert
            Assert.IsNotEmpty(objects);
        }

        [Test]
        public void Test_ReadById_CalledGetRowByIdOnce_WhenCalled()
        {
            //Arrange

            //Act
            testServices.ReadById(id);

            //Assert
            serviceMock.Verify(a => a.GetRowById(id), Times.Once);
        }

        [Test]
        public void Test_ReadById_GetRowByIdReturnsObject_WhenStubbed()
        {
            //Arrange
            serviceMock.Setup(a => a.GetRowById(id)).Returns("object");

            //Act
            object obj = testServices.ReadById(id);

            //Assert
            Assert.IsInstanceOf<object>(obj);
        }

        [Test]
        public void Test_AddItem_CalledAddRowOnce_WhenCalled()
        {
            //Arrange


            //Act
            testServices.AddItem(tempObject);

            //Assert
            serviceMock.Verify(a => a.AddRow(tempObject), Times.Once);
        }

        [Test]
        public void Test_UpdateItem_CalledUpdateRowOnce_WhenCalled()
        {
            //Arrange

            //Act
            testServices.UpdateItem(id, tempObject);

            //Assert
            serviceMock.Verify(a => a.UpdateRow(id, tempObject), Times.Once);
        }

        [Test]
        public void Test_UpdateItem_UpdateRowReturnsTrue_WhenStubbed()
        {
            //Arrange
            serviceMock.Setup(a => a.UpdateRow(id, tempObject)).Returns(true);

            //Act
            bool hasRun = testServices.UpdateItem(id, tempObject);

            //Assert
            Assert.IsTrue(hasRun);
        }

        [Test]
        public void Test_DeleteItem_CalledDeleteRowOnce_WhenCalled()
        {
            //Arrange

            //Act
            testServices.DeleteItem(tempObject);

            //Assert
            serviceMock.Verify(a => a.DeleteRow(tempObject), Times.Once);
        }

        [Test]
        public void Test_ReadAll_CalledGetAllRowsOnce_WhenCalledWithLocation()
        {
            //Arrange

            //Act
            testLocationServices.ReadAll();

            //Assert
            locationServiceMock.Verify(a => a.GetAllRows(), Times.Once);
        }

        [Test]
        public void Test_ReadAll_GetAllRowsReturnsListOfLocations_WhenCalled()
        {
            //Arrange
            locationServiceMock.Setup(a => a.GetAllRows()).Returns(new List<Location>());

            //Act
            object locations = testLocationServices.ReadAll();

            //Assert
            Assert.IsInstanceOf<List<Location>>(locations);
        }

        [Test]
        public void Test_ReadById_CalledGetAllRowsOnce_WhenCalledWithLocation()
        {
            //Arrange

            //Act
            object location = testLocationServices.ReadById(id);

            //Assert
            locationServiceMock.Verify(a => a.GetRowById(id), Times.Once);
        }

        [Test]
        public void Test_ReadById_GetRowByIdReturnsALocation_WhenStubbed()
        {
            //Arrange
            locationServiceMock.Setup(a => a.GetRowById(id)).Returns(new Location());

            //Act
            object location = testLocationServices.ReadById(id);

            //Assert
            Assert.IsInstanceOf<Location>(location);
        }

        [Test]
        public void Test_AddItem_CalledAddRowOnce_WhenCalledWithLocation()
        {
            //Arrange

            //Act
            testLocationServices.AddItem(location);

            //Assert
            locationServiceMock.Verify(a => a.AddRow(location), Times.Once);
        }

        [Test]
        public void Test_UpdateItem_CalledUpdateRowOnce_WhenCalledWithLocation()
        {
            //Arrange

            //Act
            testLocationServices.UpdateItem(id, location);

            //Assert
            locationServiceMock.Verify(a => a.UpdateRow(id, location), Times.Once);
        }

        [Test]
        public void Test_UpdateItem_UpdateRowReturnsTrue_WhenStubbedWithLocation()
        {
            //Arrange
            locationServiceMock.Setup(a => a.UpdateRow(id, location)).Returns(true);

            //Act
            bool hasRun = testLocationServices.UpdateItem(id, location);

            //Assert
            Assert.IsTrue(hasRun);
        }

        [Test]
        public void Test_DeleteItem_CalledUpdateRowOnce_WhenCalledWithLocation()
        {
            //Arrange

            //Act
            testLocationServices.DeleteItem(location);

            //Assert
            locationServiceMock.Verify(a => a.DeleteRow(location), Times.Once);
        }
    }
}
