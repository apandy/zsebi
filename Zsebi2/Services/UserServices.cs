using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zsebi2.DataLayer;
using Zsebi2.Models;

namespace Zsebi2.Services
{
    public class UserServices : IUserServices
    {
        private const string EmailKey = "Email";
        private const string PasswordHashKey = "PasswordHash";
        private readonly SiteContext _context;

        public UserServices(SiteContext context)
        {
            _context = context;
        }

        public async Task<UserModel> GetAdminUser()
        {
            var options = await GetAdminUserOptions();
            if (options.Count == 0)
                return null;
            return new UserModel(GetValue(options, EmailKey), GetValue(options, PasswordHashKey));
        }

        private Task<List<Option>> GetAdminUserOptions()
        {
            return _context.Options
                .Where(e => e.Name == EmailKey || e.Name == PasswordHashKey)
                .ToListAsync();
        }

        public async Task SaveAdminUser(string email, string password)
        {
            var options = await GetAdminUserOptions();
            var emailOptions = GetOrCreateEmailOptions(options, EmailKey);
            var passwordHash = GetOrCreateEmailOptions(options, PasswordHashKey);
            var user = new UserModel(email, "");
            user.EncryptPassword(password);
            emailOptions.Value = user.Email;
            passwordHash.Value = user.PasswordHash;
            await _context.SaveChangesAsync();
        }

        private Option GetOrCreateEmailOptions(List<Option> options, string name)
        {
            var option = options.FirstOrDefault(e => e.Name == name);
            if (option != null)
                return option;
            option = new Option
            {
                Name = name
            };
            _context.Add(option);
            return option;
        }

        private static string GetValue(List<Option> options, string name)
        {
            return options.Where(e => e.Name == name).Select(e => e.Value).FirstOrDefault();
        }
    }
}
