using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Taller.API;
using Taller.CORE.DTO;
using Xunit;

namespace KaynJungle.IntegrationTests
{
    public class UserTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient _client;

        public UserTest(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task GetUsers_GetRequest_ReturnsStatusCode200()
        {
            // Arrange
            var request = "/user";

            // Act
            var response = await _client.PostAsync(request, null);

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);      // Con FluentAssertions
            // Assert.Equal(HttpStatusCode.OK, response.StatusCode); // Sin FluentAssertions
        }

        [Fact]
        public async Task GetUsers_BadUrlRequest_ReturnsStatusCode404()
        {
            // Arrange
            var request = "/users";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Add_AddValidUser_ReturnsStatusCode200() // 500 porque la implementación del método aún no está acabada
        {
            // Arrange
            var request = new
            {
                Url  = "/user/add",
                Body = new UserDTO
                {
                    EmployeeId   = 999,
                    Username     = "testAddUser",
                    Password     = "hodlIt",
                    Dni          = "testDni",
                    Name         = "test",
                    Surnames     = "test test",
                    Phone        = "001phone",
                    EmployeeType = "mechanich",
                    Specialty    = "car"
    }
            };

            // Act
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value    = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(value == "true");
        }

    }
}