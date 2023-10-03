using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using System.Net;
using System.Net.Http.Json;

namespace MyStore.Tests.Integration
{
    public class CategoriesControllerTests : IClassFixture<StoreApiFactory<Program>>
    {
        private readonly HttpClient httpClient;

        public CategoriesControllerTests(StoreApiFactory<Program> apiFactory)
        {
            apiFactory.ClientOptions.BaseAddress = new Uri("https://localhost:7018/api/");
            httpClient = apiFactory.CreateClient();
        }

        [Fact]
        public async void Get_ReturnsNotFound_WhenCategoryDoesntExist()
        {

            //Arrange
            Random rnd = new Random();
            int ID = rnd.Next(30, 100);

            //Act
            //"https://localhost:7018/api/ + /categories/3
            var response = await httpClient.GetAsync($"categories/{ID}");

            var problem = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();

            problem!.Title.Should().Be("Not Found");
            problem.Status.Should().Be(404);
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        }

        [Fact]
        public async void Get_ReturnsOK_WhenCategoryExist()
        {

            //Arrange
            Random rnd = new Random();
            int ID = rnd.Next(1, 8);

            //Act
            //"https://localhost:7018/api/ + /categories/3
            var response = await httpClient.GetAsync($"categories/{ID}");

            var actualData = await response.Content.ReadFromJsonAsync<CategoryModel>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }
    }
}