using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using TaxService.Controllers;
using TaxService.Entities;
using TaxService.Exceptions;
using TaxService.MappingProfiles;
using TaxService.Models;
using TaxService.Services.Interfaces;
using TaxService.Services;
using Xunit;
using Microsoft.Extensions.Options;
using TaxService.Helpers;

namespace TaxServiceTests
{
    public class OrderTaxControllerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<TaxRateController>> _mockLogger;

        public OrderTaxControllerTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
               mc.AddProfile(new DefaultMappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();

            _mockLogger = new Mock<ILogger<TaxRateController>>();            
        }

        [Fact]
        public void Get_ReturnsOkResult_WhenToCountryProvidedAndValid()
        {
            //Arrange
            var orderTax = new OrderTax();

            var serviceMock = new Mock<ITaxCalculatorService>();
            serviceMock.Setup(o => o.GetSalesTaxForOrder(It.IsAny<Order>())).ReturnsAsync(orderTax);  

            var appSettingsMock = new Mock<IOptions<AppSettings>>();

            // Act
            var controller = new OrderTaxController(_mockLogger.Object, _mapper, serviceMock.Object, appSettingsMock.Object);
            var result = controller.GetOrderTax(new OrderTaxRequestDto { ToCountry = "US" }).Result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Get_ThrowsOrderTaxNotFoundException_WhenToCountryNotProvided()
        {
            //Arrange
            OrderTax orderTax = null;

            var serviceMock = new Mock<ITaxCalculatorService>();
            serviceMock.Setup(o => o.GetSalesTaxForOrder(It.IsAny<Order>())).ReturnsAsync(orderTax);

            var appSettingsMock = new Mock<IOptions<AppSettings>>();

            var controller = new OrderTaxController(_mockLogger.Object, _mapper, serviceMock.Object, appSettingsMock.Object);

            // Act + Assert
            await Assert.ThrowsAsync<OrderTaxNotFoundException>(() => controller.GetOrderTax(new OrderTaxRequestDto()));
        }
    }
}
