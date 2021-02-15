using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Taller.API;
using Xunit;
using FluentAssertions;
using Taller.CORE.DTO;
using System.Text.Json;

namespace KaynJungle.IntegrationTests
{
    public class PropositionTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient _client;

        public PropositionTest(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task GetSalesPropositions_GetRequest_ReturnsStatusCode200()
        {
            // Arrange
            var request = "/proposition/sales";

            // Act
            var response = await _client.GetAsync(request);
            var value = await response.Content.ReadAsStringAsync();
            var propositions = JsonSerializer.Deserialize<List<PropositionDTO>>(value);

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);      // Con FluentAssertions
            propositions.Should().HaveCount(10);
            // Assert.Equal(HttpStatusCode.OK, response.StatusCode); // Sin FluentAssertions
            // Assert.True(propositions.Count == 10);

        }

        [Fact]
        public async Task GetSalesPropostions_BadUrlRequest_ReturnsStatusCode404()
        {
            // Arrange
            var request = "/proposition/s";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

    }
}