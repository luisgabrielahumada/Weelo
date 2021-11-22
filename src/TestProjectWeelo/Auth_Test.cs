using Moq;
using NUnit.Framework;
using TestProjectWeelo.Helper;
using Weelo.Domain.Auth;
using Weelo.Dto.Auth;
using Weelo.Mapper.Interface;
using Weelo.Repository.Interface;
using Weelo.Services;

namespace TestProjectWeelo
{
    public class Auth_Test
    {
        private Mock<IAuthMapper> iAuthMapper;
        private Mock<IAuthRepository> iAuthRepository;
        private AuthService authService;
        [SetUp]
        public void Setup()
        {
            iAuthRepository = new Mock<IAuthRepository>();
            iAuthMapper = new Mock<IAuthMapper>();
            authService = new AuthService(iAuthMapper.Object, iAuthRepository.Object);
        }

        [Test]
        public void Login_and_Password_Success()
        {
            iAuthRepository.Setup(p => p.LoginValidate(It.IsAny<User>())).Returns(TokenDtoTest.TokenSuccessDto());
            var resp = authService.Login(It.IsAny<UserDto>());
            Assert.AreEqual(TokenDtoTest.TokenSuccessDto().Token, resp.Token);
        }

        [Test]
        public void Login_or_Password_Fail()
        {
            iAuthRepository.Setup(p => p.LoginValidate(It.IsAny<User>())).Returns(TokenDtoTest.ReturnTokenFailDto());
            var resp = authService.Login(It.IsAny<UserDto>());
            Assert.AreEqual(null, resp.Token);
        }
    }
}