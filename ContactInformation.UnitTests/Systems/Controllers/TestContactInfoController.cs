using Xunit;
using ContactInformation.Api.Controllers;
using ContactInformation.Api.Services;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;

namespace ContactInformation.UnitTests.Systems.Controllers;

public class TestContactInfoController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        ////Arrange
        //var contactInfoController = new ContactInfoController();

        ////Act
        //var result = (OkObjectResult) await contactInfoController.Get();

        ////Assert
        //result.StatusCode.Should().Be(200);
    }


    [Fact]
    public async Task Get_OnSuccess_InvokeContactInfoService()
    {
        //Arrange
        var mockContactInfoService = new Mock<IContactInfoService>();
        mockContactInfoService
            .Setup(service => service.ListContactInfo())
            .ReturnsAsync(new List<ContactInformation.Api.Models.ContactInfo>());

        var contactInfoController = new ContactInfoController(mockContactInfoService.Object, null);

        //Act
        var result = await contactInfoController.List();
        //Assert
        mockContactInfoService.Verify(service => service.ListContactInfo(), Times.Once());

    }
}