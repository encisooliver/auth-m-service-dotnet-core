using auth_project.Controllers;
using auth_project.Models;
using auth_project.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace test_user;

public class UnitTest1
{
    private readonly Mock<IUserRepository> _mockRepo;
    private readonly UserController _controller;

    public UnitTest1()
    {
        _mockRepo = new Mock<IUserRepository>();
        _controller = new UserController(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAllUsers_ReturnsOk_WithUsers()
    {
        // Arrange
        var users = new List<UserModel> { new UserModel { Id = 1, Name = "John Doe", UserName = "johndoe", Email = "john@example.com", UserTypeId = 1 } };
        _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(users);

        // Act
        var result = await _controller.GetAllUsers();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnUsers = Assert.IsType<List<UserModel>>(okResult.Value);
        Assert.Single(returnUsers);
    }

      // Test: GetAllUsers - Should return 404 Not Found when no users exist
    [Fact]
    public async Task GetAllUsers_ReturnsNotFound_WhenNoUsers()
    {
        _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<UserModel>());

        var result = await _controller.GetAllUsers();

        Assert.IsType<NotFoundObjectResult>(result);
    }

     // Test: GetUserById - Should return 200 OK with user
    [Fact]
    public async Task GetUserById_ReturnsOk_WithUser()
    {
        var user = new UserModel { Id = 1, Name = "John Doe", UserName = "johndoe", Email = "john@example.com", UserTypeId = 1 };
        _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);

        var result = await _controller.GetUserById(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnUser = Assert.IsType<UserModel>(okResult.Value);
        Assert.Equal(user.Id, returnUser.Id);
    }

    // Test: GetUserById - Should return 404 Not Found when user doesn't exist
    [Fact]
    public async Task GetUserById_ReturnsNotFound_WhenUserNotFound()
    {
        _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((UserModel)null);

        var result = await _controller.GetUserById(1);

        Assert.IsType<NotFoundObjectResult>(result);
    }

     // Test: AddUser - Should return 201 Created when user is successfully added
    [Fact]
    public async Task AddUser_ReturnsCreated_WhenUserIsAdded()
    {
        var user = new UserModel { Id = 1, Name = "John Doe", UserName = "johndoe", Email = "john@example.com", UserTypeId = 1 };
        _mockRepo.Setup(repo => repo.AddAsync(user)).ReturnsAsync(true);

        var result = await _controller.AddUser(user);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnUser = Assert.IsType<UserModel>(createdResult.Value);
        Assert.Equal(user.Id, returnUser.Id);
    }

    
    // Test: AddUser - Should return 400 Bad Request when adding fails
    [Fact]
    public async Task AddUser_ReturnsBadRequest_WhenAddFails()
    {
        var user = new UserModel { Id = 1, Name = "John Doe", UserName = "johndoe", Email = "john@example.com", UserTypeId = 1 };
        _mockRepo.Setup(repo => repo.AddAsync(user)).ReturnsAsync(false);

        var result = await _controller.AddUser(user);

        Assert.IsType<BadRequestObjectResult>(result);
    }

     // Test: UpdateUser - Should return 200 OK when update is successful
    [Fact]
    public async Task UpdateUser_ReturnsOk_WhenUpdateSuccessful()
    {
        var user = new UserModel { Id = 1, Name = "John Doe", UserName = "johndoe", Email = "john@example.com", UserTypeId = 1 };
        _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);
        _mockRepo.Setup(repo => repo.UpdateAsync(user)).ReturnsAsync(true);

        var result = await _controller.UpdateUser(1, user);

        Assert.IsType<OkObjectResult>(result);
    }

     // Test: UpdateUser - Should return 404 Not Found when user doesn't exist
    [Fact]
    public async Task UpdateUser_ReturnsNotFound_WhenUserNotFound()
    {
        var user = new UserModel { Id = 1, Name = "John Doe", UserName = "johndoe", Email = "john@example.com", UserTypeId = 1 };
        _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((UserModel)null);

        var result = await _controller.UpdateUser(1, user);

        Assert.IsType<NotFoundObjectResult>(result);
    }

     // Test: DeleteUser - Should return 200 OK when delete is successful
    [Fact]
    public async Task DeleteUser_ReturnsOk_WhenDeleteSuccessful()
    {
        var user = new UserModel { Id = 1, Name = "John Doe", UserName = "johndoe", Email = "john@example.com", UserTypeId = 1 };
        _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);
        _mockRepo.Setup(repo => repo.DeleteAsync(user)).ReturnsAsync(true);

        var result = await _controller.DeleteUser(1);

        Assert.IsType<OkObjectResult>(result);
    }

    // Test: DeleteUser - Should return 404 Not Found when user doesn't exist
    [Fact]
    public async Task DeleteUser_ReturnsNotFound_WhenUserNotFound()
    {
        _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((UserModel)null);

        var result = await _controller.DeleteUser(1);

        Assert.IsType<NotFoundObjectResult>(result);
    }
}