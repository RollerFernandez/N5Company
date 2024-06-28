using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using N5.Management.Permissions.Api.Controllers;
using N5.Management.Permissions.Application.Commands.Definitions;
using N5.Management.Permissions.Application.Dtos.Permissions;
using N5.Management.Permissions.Application.Queries.Definitions;

namespace N5.Management.UnitTests.Permissions
{
    public class PermissionsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly PermissionsController _controller;

        public PermissionsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new PermissionsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetPermission_ShouldReturnOkResult_WhenPermissionExists()
        {
            // Arrange
            int permissionId = 1;
            var expectedPermission = new PermissionDto { Id = permissionId};
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPermissionQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedPermission);

            // Act
            var result = await _controller.GetPermission(permissionId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<PermissionDto>(okResult.Value);
            Assert.Equal(expectedPermission.Id, returnValue.Id);
        }

        [Fact]
        public async Task SetPermission_ShouldReturnOkResult_WhenCommandIsValid()
        {
            // Arrange
            var command = new CreatePermissionCommand {EmployeeId=3,PermissionTypeId=1,StartDate=DateTime.Now,EndDate=DateTime.UtcNow,Reason="Sin razon" };
            var expectedResult = new PermissionDto { EmployeeId = 3, PermissionTypeId = 1, StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Reason = "Sin razon" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreatePermissionCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.SetPermission(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<PermissionDto>(okResult.Value);
            Assert.Equal(expectedResult.Id, returnValue.Id);
            Assert.Equal(expectedResult.Employee.Name, returnValue.Employee.Name);
            Assert.Equal(expectedResult.PermissionType.Name, returnValue.PermissionType.Name);
        }

        [Fact]
        public async Task UpdatePermission_ShouldReturnOkResult_WhenCommandIsValid()
        {
            // Arrange
            var command = new UpdatePermissionCommand { EmployeeId = 3, PermissionTypeId = 1, StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Reason = "Sin razon" };
            var expectedResult = new PermissionDto { EmployeeId = 3, PermissionTypeId = 1, StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Reason = "Sin razon" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdatePermissionCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.UpdatePermission(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<PermissionDto>(okResult.Value);
            Assert.Equal(expectedResult.Id, returnValue.Id);
            Assert.Equal(expectedResult.Employee.Name, returnValue.Employee.Name);
        }
    }
}
