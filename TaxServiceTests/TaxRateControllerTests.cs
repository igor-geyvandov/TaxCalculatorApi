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
    public class TaxRateControllerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<TaxRateController>> _mockLogger;

        public TaxRateControllerTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
               mc.AddProfile(new DefaultMappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();

            _mockLogger = new Mock<ILogger<TaxRateController>>();            
        }

        [Fact]
        public void Get_ReturnsOkResult_WhenZipProvidedAndValid()
        {
            //Arrange
            TaxRate taxRate = new TaxRate { CombinedRate = 10 };

            var serviceMock = new Mock<ITaxCalculatorService>();
            serviceMock.Setup(o => o.GetTaxRateForLocation(It.IsAny<Location>())).ReturnsAsync(taxRate);  

            var appSettingsMock = new Mock<IOptions<AppSettings>>();

            // Act
            TaxRateController controller = new TaxRateController(_mockLogger.Object, _mapper, serviceMock.Object, appSettingsMock.Object);
            var result = controller.GetTaxRate(new TaxRateRequestDto { Zip = "33602" }).Result;

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Get_ThrowsTaxRateNotFoundException_WhenZipNotValid()
        {
            //Arrange
            TaxRate taxRate = null;

            var serviceMock = new Mock<ITaxCalculatorService>();
            serviceMock.Setup(o => o.GetTaxRateForLocation(It.IsAny<Location>())).ReturnsAsync(taxRate);

            var appSettingsMock = new Mock<IOptions<AppSettings>>();

            TaxRateController controller = new TaxRateController(_mockLogger.Object, _mapper, serviceMock.Object, appSettingsMock.Object);

            // Act + Assert
            await Assert.ThrowsAsync<TaxRateNotFoundException>(() => controller.GetTaxRate(new TaxRateRequestDto { Zip = "00000" }));
        }

        [Fact]
        public async void Get_ThrowsTaxRateNotFoundException_WhenZipNotProvided()
        {
            //Arrange
            TaxRate taxRate = null;

            var serviceMock = new Mock<ITaxCalculatorService>();
            serviceMock.Setup(o => o.GetTaxRateForLocation(It.IsAny<Location>())).ReturnsAsync(taxRate);

            var appSettingsMock = new Mock<IOptions<AppSettings>>();

            TaxRateController controller = new TaxRateController(_mockLogger.Object, _mapper, serviceMock.Object, appSettingsMock.Object);

            // Act + Assert
            await Assert.ThrowsAsync<TaxRateNotFoundException>(() => controller.GetTaxRate(new TaxRateRequestDto()));
        }
    }
}
