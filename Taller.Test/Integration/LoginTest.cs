using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Taller.API;
using Xunit;

namespace KaynJungle.IntegrationTests
{
    public class LoginTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient _client;

        public LoginTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task LoginTests_LoginCorrect_ReturnsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/login",
                Body = new
                {
                    Username = "jefe",
                    Password = "f8032d5cae3de20fcec887f395ec9a6a"
                }
            };

            // Act
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value    = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            // value.Should().Be("true");       // Con FluentAssertions
            Assert.True(value == "true");       // Sin FluentAssertions
        }

        [Fact]
        public async Task LoginTests_LoginIncorrect_ReturnsFalse()
        {
            // Arrange
            var request = new
            {
                Url = "/login",
                Body = new
                {
                    Username = "jose",
                    Password = "magicTheGathering"
                }
            };

            // Act
            var response = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value    = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(value == "false");
        }

    }
}