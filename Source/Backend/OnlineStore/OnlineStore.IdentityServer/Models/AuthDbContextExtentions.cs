﻿using System;
using System.Collections.Generic;
using System.Linq;
using IdentityModel;

namespace OnlineStore.IdentityServer.Models
{
    public static class AuthDbContextExtentions
    {
        public static bool ValidatePassword(this AuthDbContext dbContext, string userName, string password)
        {
            var user = dbContext.Users.FirstOrDefault(item => item.Email == userName);

            if (user == null)
                return false;

            if (user.Password == password.ToSha256())
                return true;

            return false;
        }

        public static User GetUserByUserName(this AuthDbContext dbContext, string userName)
            => dbContext.Users.FirstOrDefault(item => item.Email == userName);

        public static User GetUserByID(this AuthDbContext dbContext, string id)
            => dbContext.Users.FirstOrDefault(item => item.UserID == id);

        public static IEnumerable<UserClaim> GetUserClaimsByUserID(this AuthDbContext dbContext, string userID)
            => dbContext.UserClaims.Where(item => item.UserID == userID);

        public static void SeedInMemory(this AuthDbContext dbContext)
        {
            dbContext.Users.Add(new User("1000", "jameslogan@walla.com", "wolverine".ToSha256(), true));

            dbContext.UserClaims.AddRange(
                new UserClaim(Guid.NewGuid(), "1000", JwtClaimTypes.Subject, "1000"),
                new UserClaim(Guid.NewGuid(), "1000", JwtClaimTypes.PreferredUserName, "jameslogan"),
                new UserClaim(Guid.NewGuid(), "1000", JwtClaimTypes.Email, "jameslogan@walla.com"),
                new UserClaim(Guid.NewGuid(), "1000", JwtClaimTypes.Role, "Customer"),
                new UserClaim(Guid.NewGuid(), "1000", JwtClaimTypes.GivenName, "James"),
                new UserClaim(Guid.NewGuid(), "1000", JwtClaimTypes.MiddleName, ""),
                new UserClaim(Guid.NewGuid(), "1000", JwtClaimTypes.FamilyName, "Logan")
            );

            dbContext.Users.Add(new User("2000", "ororo_munroe@yahoo.com", "storm".ToSha256(), true));

            dbContext.UserClaims.AddRange(
                new UserClaim(Guid.NewGuid(), "2000", JwtClaimTypes.Subject, "2000"),
                new UserClaim(Guid.NewGuid(), "2000", JwtClaimTypes.PreferredUserName, "ororo_munroe"),
                new UserClaim(Guid.NewGuid(), "2000", JwtClaimTypes.Email, "ororo_munroe@yahoo.com"),
                new UserClaim(Guid.NewGuid(), "2000", JwtClaimTypes.Role, "Customer"),
                new UserClaim(Guid.NewGuid(), "2000", JwtClaimTypes.GivenName, "Ororo"),
                new UserClaim(Guid.NewGuid(), "2000", JwtClaimTypes.MiddleName, ""),
                new UserClaim(Guid.NewGuid(), "2000", JwtClaimTypes.FamilyName, "Munroe")
            );

            dbContext.SaveChanges();
        }
    }
}
