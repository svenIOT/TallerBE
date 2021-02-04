using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Taller.API;
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
        public async Task UserTests__Returns()
        {
            // Arrange


            // Act


            // Assert

        }



    }
}