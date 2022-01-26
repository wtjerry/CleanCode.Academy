// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginService.cs" company="bbv Software Services AG">
//   Copyright (c) 2014 - 2020
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CleanCode.Naming.ExceptionsForControlFlow
{
    using System.Collections.Generic;

    public class LoginService
    {
        private readonly IDictionary<string, string> knownUsers;
        private readonly ITokenGenerator tokenGenerator;

        public LoginService(IDictionary<string, string> knownUsers, ITokenGenerator tokenGenerator)
        {
            this.knownUsers = knownUsers;
            this.tokenGenerator = tokenGenerator;
        }

        public Either<string, Token> Login(string username, string password)
        {
            if (!this.UserExists(username))
            {
                return Either<string, Token>.Left("User not found");
            }

            if (this.PasswordIsCorrect(username, password))
            {
                return Either<string, Token>.Right(this.tokenGenerator.Get());
            }

            return Either<string, Token>.Left("Password wrong");

        }

        private bool PasswordIsCorrect(string username, string password) =>
            this.knownUsers[username] == password;

        private bool UserExists(string username) =>
            this.knownUsers.ContainsKey(username);
    }
}
