using Cmms.Domain.Exceptions;
using Cwk.Domain.Validators.UserProfileValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmms.Domain.Entities
{
    public class UserProfileBasicInfo
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string Phone { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string CurrentCity { get; private set; }


        public static UserProfileBasicInfo CreateBasicInfo(string firstName, string lastName, string emailAddress,
             string phone, DateTime dateOfBirth, string currentCity)
        {
            var validator = new UserProfileBasicInfoValidator();

            var objToValidate = new UserProfileBasicInfo
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                Phone = phone,
                DateOfBirth = dateOfBirth,
                CurrentCity = currentCity
            };

            var validationResult = validator.Validate(objToValidate);

            if (validationResult.IsValid) 
                return objToValidate;

            var exception = new UserProfileNotValidException("The user profile is not valid");
            foreach (var error in validationResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }

            throw exception;
        }
    }
}
