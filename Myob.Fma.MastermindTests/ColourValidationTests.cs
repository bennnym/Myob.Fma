using System.Collections.Generic;
using Myob.Fma.Mastermind.GameServices.Input.Validations.InputValidations;
using Myob.Fma.Mastermind.GameServices.Input.Validator;
using Xunit;

namespace Myob.Fma.MastermindTests
{
    public class ColourValidationTests
    {
        private readonly InputValidator _inputValidatorColor;

        public ColourValidationTests()
        {
            _inputValidatorColor = new InputValidator(
                new List<IValidation>()
                {
                    new ColourValidation(),
                });
        }
        
        [Theory]
        [InlineData("red orange, orange orange")]
        [InlineData("red red,blue,orange")]
        [InlineData("purple blue green yellow")]
        public void Should_Return_True_When_User_Has_Entered_Valid_Colours(string input)
        {
            // Act
            var validationResult = _inputValidatorColor.GetValidationResults(input);

            // Assert
            Assert.True(validationResult.IsValid);
        }
        
        [Theory]
        [InlineData("red PINK, orange orange")]
        [InlineData("red red,WHITE,orange")]
        [InlineData("purple blue GREY yellow")]
        public void Should_Return_False_When_User_Has_Entered_Invalid_Colours(string input)
        {
            // Act
            var validationResult = _inputValidatorColor.GetValidationResults(input);

            // Assert
            Assert.False(validationResult.IsValid);
        }
    }
}