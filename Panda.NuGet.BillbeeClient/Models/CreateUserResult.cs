﻿namespace Panda.NuGet.BillbeeClient.Models
{
    /// <summary>
    /// Result of a create user request
    /// </summary>
    public class CreateUserResult
    {
        /// <summary>
        /// Password, that was given for the user. This can't be recovered afterwards.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Internal id this user was given
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Url to allow the user an one time login, without password
        /// </summary>
        public string? OneTimeLoginUrl { get; set; }
    }
}
