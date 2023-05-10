using FluentAssertions.Equivalency;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.Infrastructure.Identity
{
    public class LocalizedIdentityErrorDescriber:IdentityErrorDescriber
    {
        private const string Password = "Password";
        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Code = "Password",
                Description = "Hasło i potwierdzone hasło są różne"
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {

                Code = "Password",
                Description = "Hasło musi  zawierać przynajmniej jedną liczbę"

            };
        }
    }
}
