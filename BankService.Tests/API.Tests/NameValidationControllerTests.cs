using BankService.Application.Queries.NameValidation;
using BankService.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Name_BankTransferService.Controllers;
using Xunit;

namespace BankService.Tests.API.Tests
{
    public class NameValidationControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly NameValidationController _controller;

        public NameValidationControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new NameValidationController(_mediatorMock.Object);  // Fixed asterisks
        }

        [Fact]
        public async Task ValidateName_ReturnsOkResult_WithValidResponse()
        {
            // Arrange
            var query = new ValidateNameQuery { BankCode = "FCMB", AccountNumber = "1234567890" };
            var expectedResponse = new ApiResponse
            {
                Errors = null,
                Success = true,
                Data = new AccountInfo { AccountName = "John Doe", AccountNumber = "123" }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<ValidateNameQuery>(), default))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.ValidateName(query);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Null(apiResponse.Errors);
            Assert.NotNull(apiResponse.Data);
            Assert.Equal("John Doe", ((AccountInfo)apiResponse.Data).AccountName);
        }

        [Fact]
        public async Task ValidateName_ReturnsBadRequest_WhenExceptionThrown()
        {
            // Arrange
            var query = new ValidateNameQuery { BankCode = "FCMB", AccountNumber = "1234567890" };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<ValidateNameQuery>(), default))
                .ThrowsAsync(new ArgumentException("Invalid bank code"));

            // Act
            var result = await _controller.ValidateName(query);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid bank code", badRequestResult.Value);
        }

        [Fact]
        public async Task ValidateName_ReturnsInternalServerError_WhenUnhandledExceptionThrown()
        {
            // Arrange
            var query = new ValidateNameQuery { BankCode = "FCMB", AccountNumber = "1234567890" };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<ValidateNameQuery>(), default))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _controller.ValidateName(query);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            Assert.Equal("Unexpected error", statusCodeResult.Value);
        }
    }
}

