﻿using InfoTemTuiFly.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace InfoTemTuiFly.Tests.Controller
{
    public class AirportsControllerTest : ControllerTestBase
    {
        [Test]
        public void AirportsControllerTest_GetAll_Test()
        {
            //Arrange
            _airportService.GetAll().Returns(new List<Airport>());

            //Act
            var result = airportsController.Index();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [Test]
        public void AirportsControllerTest_GetAll_Create()
        {
            //Arrange
            //Act
            var result = airportsController.Create();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [Test]
        public void AirportsControllerTest_GetAll_Create_AirPort()
        {
            //Arrange
            var airport = new Airport() { Id = 1, Name = "Airport" };
            _airportService.Save(airport).Returns(airport);
            //Act
            var result = airportsController.Create(new Models.AirportViewModel(airport));

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
        }

        [Test]
        public void AirportsControllerTest_Details_Id_Null_Test()
        {
            //Arrange
            //Act
            var result = airportsController.Details(null);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(BadRequestResult), result.GetType());
        }

        [Test]
        public void AirportsControllerTest_Details_Id_NotNull_NotFound_Test()
        {
            //Arrange
            Airport airport = null;
            _airportService.GetById(Arg.Any<int>()).Returns(airport);

            //Act
            var result = airportsController.Details(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(NotFoundResult), result.GetType());
        }

        [Test]
        public void AirportsControllerTest_Details_Id_NotNull_Found_Test()
        {
            //Arrange
            var airport = new Airport() { Id = 1 };
            _airportService.GetById(Arg.Any<int>()).Returns(airport);

            //Act
            var result = airportsController.Details(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        // The Details Method and Edit are the some
    }
}