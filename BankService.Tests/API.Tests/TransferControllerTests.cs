using BankService.Application.Command.Transfers;
using BankService.Domain.Dto;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Name_BankTransferService.Controllers;
using System.Collections.Generic;
using Xunit;

namespace BankService.Tests.API.Tests
{
    public class TransferControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly TransferController _controller;

        public TransferControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new TransferController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Transfer_ReturnsOkResult_WithValidResponse()
        {
            // Arrange
            var command = new CreateTransferCommand
            {
                SenderAccountNumber = "1234567890",
                ReceiverAccountNumber = "0987654321",
                Amount = 1000m,
                BankCode = "FCMB"
            };

            var expectedResponse = new ApiResponse
            {
                Success = true,
                Message = "Transfer successful",
                Data = new { TransactionId = "TX12345" }
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateTransferCommand>(), default))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Transfer(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Transfer successful", apiResponse.Message);
            Assert.NotNull(apiResponse.Data);
            Assert.Equal("TX12345", ((dynamic)apiResponse.Data).TransactionId);
        }
        [Fact]
        public async Task Transfer_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var command = new CreateTransferCommand
            {
                SenderAccountNumber = "",
                ReceiverAccountNumber = "43444444",
                Amount = -10000m,
                BankCode = "FCMB"
            };

            // Act
            var result = await _controller.Transfer(command);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var validationErrors = Assert.IsType<List<FluentValidation.Results.ValidationFailure>>(badRequestResult.Value);

            // Assert on specific validation errors
            Assert.Contains(validationErrors, e =>
                e.PropertyName == "SenderAccountNumber" &&
                e.ErrorMessage == "'Sender Account Number' must not be empty.");

            Assert.Contains(validationErrors, e =>
                e.PropertyName == "ReceiverAccountNumber" &&
                e.ErrorMessage == "'Receiver Account Number' must be 10 characters in length.");

            Assert.Contains(validationErrors, e =>
                e.PropertyName == "Amount" &&
                e.ErrorMessage == "'Amount' must be greater than '0'.");
        }



        [Fact]
        public async Task Transfer_ReturnsInternalServerError_WhenUnhandledExceptionOccurs()
        {
            // Arrange
            var command = new CreateTransferCommand
            {
                SenderAccountNumber = "1234567890",
                ReceiverAccountNumber = "0987654321",
                Amount = 1000m,
                BankCode = "FCMB"
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateTransferCommand>(), default))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _controller.Transfer(command);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            Assert.Equal("Unexpected error", statusCodeResult.Value);
        }
    }
    public class ValidationError
    {
        public string Property { get; set; }
        public string Error { get; set; }
    }
}
