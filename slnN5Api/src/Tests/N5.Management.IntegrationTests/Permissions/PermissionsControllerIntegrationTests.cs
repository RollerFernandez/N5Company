using Microsoft.AspNetCore.Mvc.Testing;
using N5.Management.Permissions.Application.Commands.Definitions;
using N5.Management.Permissions.Application.Dtos.Permissions;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Xunit;

namespace N5.Management.IntegrationTests.Permissions
{
    public class PermissionsControllerIntegrationTests:  IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public PermissionsControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]

        public async Task GetPermission_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/permissions/1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task SetPermission_ReturnsCreatedPermission()
        {
            // Arrange
            var client = _factory.CreateClient();
            var command = new CreatePermissionCommand { EmployeeId = 2, PermissionTypeId=1,StartDate=DateTime.Now, EndDate=DateTime.Now };
            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/permissions", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            var returnedPermission = JsonConvert.DeserializeObject<PermissionDto>(responseString);
            Assert.Equal(command.EmployeeId, returnedPermission?.EmployeeId);
            Assert.Equal(command.PermissionTypeId, returnedPermission?.PermissionTypeId);
        }

        [Fact]
        public async Task UpdatePermission_ReturnsUpdatedPermission()
        {
            // Arrange
            var client = _factory.CreateClient();
            var command = new UpdatePermissionCommand { EmployeeId = 2, PermissionTypeId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now };
            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync("/api/permissions", content);

            // Assert
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            var returnedPermission = JsonConvert.DeserializeObject<PermissionDto>(responseString);
            Assert.Equal(command.PermissionId, returnedPermission?.Id);
        }
    }
}
