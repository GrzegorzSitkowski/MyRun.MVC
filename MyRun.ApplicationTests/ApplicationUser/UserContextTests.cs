using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using FluentAssertions;

namespace MyRun.Application.ApplicationUser.Tests
{
    public class UserContextTests
    {
        [Fact()]
        public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
        {
            //arrange
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Email, "test@test.com")
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
            {
                User = user
            });

            var userContext = new UserContext(httpContextAccessorMock.Object);
            //arrange

            //act
            var currentUser = userContext.GetCurrentUser();
            //act

            //arrange
            currentUser.Should().NotBeNull();
            currentUser!.Id.Should().Be("1");
            currentUser.Email.Should().Be("test@test.com");
            //arrange
        }
    }
}