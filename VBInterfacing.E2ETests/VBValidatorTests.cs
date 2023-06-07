using VBInterfacing.Models;

namespace VBInterfacing.E2ETests
{
    using VBUserValidator;
    public class VbValidatorTests
    {
        private _IUserValidator _userValidator; 
        private _IUserValidator _dbUserValidator;
        private User _user;

        public VbValidatorTests()
        {
            _userValidator = new UserValidatorBaseClass();
            _dbUserValidator = new DbUserValidatorClass();
            _user = new User() { Id = Guid.NewGuid(), Username = "TestUser", Password = "", Phone = "1234567890"};
        }
        
        [Fact]
        public void GivenAValidUser_UserValidatorReturnsTrue()
        {
            //Arrange
            _user.Password = "pass";

            //Act
            var validationResult = _userValidator.IsUserValid(_user.Username, _user.Password);

            //Assert
            Assert.True(validationResult, "Base Validation was false when true was expected!");
        }

        [Fact]
        public void GivenAnInvalidUser_UserValidatorReturnsFalse()
        {
            //Arrange
            _user.Password = "";

            //Act
            var validationResult = _userValidator.IsUserValid(_user.Username, _user.Password);

            //Assert
            Assert.False(validationResult, "Base Validation was true when false was expected!");
        }

        [Fact]
        public void GivenAValidUser_DbUserValidatorReturnsTrue()
        {
            //Arrange
            _user.Password = "password!";

            //Act
            var validationResult = _dbUserValidator.IsUserValid(_user.Username, _user.Password);

            //Assert
            Assert.True(validationResult, "Base Validation was false when true was expected!");
        }

        [Fact]
        public void GivenAnInvalidUser_DbUserValidatorReturnsFalse()
        {
            //Arrange
            _user.Password = "password";

            //Act
            var validationResult = _dbUserValidator.IsUserValid(_user.Username, _user.Password);

            //Assert
            Assert.False(validationResult, "Base Validation was true when false was expected!");
        }
    }
}