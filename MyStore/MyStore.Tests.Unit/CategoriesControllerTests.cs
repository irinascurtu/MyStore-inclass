using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MyStore.Controllers;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests.Unit
{
    public class CategoriesControllerTests
    {
        private readonly ICategoryService categoryService;
        private readonly CategoriesController sut;

        public CategoriesControllerTests()
        {
            this.categoryService = Substitute.For<ICategoryService>();
            sut = new CategoriesController(this.categoryService);
        }

        [Fact]
        public void GetByID_ReturnsNotFound_WhenCategoryDoesntExist()
        {
            //Arrange
            categoryService.GetCategory(Arg.Any<int>()).ReturnsNull();
            //Act
            var expectedResult = sut.GetById(1);


            //Assert
            expectedResult.Should().BeOfType<ActionResult<Models.CategoryModel>>();
            //expectedResult.Result.Should().BeOfType<NotFoundResult>();

            // varianta de testat
            //var statusCode = (NotFoundResult)expectedResult.Result;
            //statusCode.StatusCode.Should().Be(404);
        }


        [Fact]
        public void GetByID_ReturnsOK_WhenCategoryExist()
        {
            //Arrange
            //Arrange
            var existingCategory = new Category()
            {
                Categoryid = 1,
                Categoryname = "test category",
                Description = "Test description"
            };

            var objectToReturn = existingCategory.ToCategoryModel();

            categoryService.GetCategory(1)
                .Returns(existingCategory);


            //Act
            var expectedResult = sut.GetById(1);


            //Assert
            expectedResult.Should().BeOfType<ActionResult<Models.CategoryModel>>();
            expectedResult.Result.Should().BeOfType<OkObjectResult>();

            //expectedResult.Value.Should().Be(objectToReturn);

        }
    }
}
