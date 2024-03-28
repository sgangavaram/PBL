using Xunit;
using Moq;
using StudentManagementService;
using StudentManagementAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Common.Models;

public class StudentControllerTests
{
    private readonly Mock<IStudentService> _mockService;
    private readonly StudentController _controller;

    public StudentControllerTests()
    {
        _mockService = new Mock<IStudentService>();
        _controller = new StudentController(_mockService.Object);
    }

    [Fact]
    public async Task GetAllStudents_ReturnsOkResult_WithStudents()
    {
        // Arrange
        var mockStudents = new List<StudentClass>
        {
            new StudentClass { StudentName = "Vinaya"},
            new StudentClass { StudentName = "Madhura"}
        };

        _mockService.Setup(service => service.GetAllStudents())
            .ReturnsAsync(mockStudents);

        // Act
        var result = await _controller.GetAllStudents();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnStudents = Assert.IsType<List<StudentClass>>(okResult.Value);
        Assert.Equal(2, returnStudents.Count);
    }
}
