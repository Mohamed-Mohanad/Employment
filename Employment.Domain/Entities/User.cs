using Employment.Domain.Primitives;
using Microsoft.AspNetCore.Identity;

namespace Employment.Domain.Entities
{
    public class User : IdentityUser<Guid>, IAuditableEntity
    {
        public string FullName { get; private set; } = null!;
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }

        public User()
        {

        }

        public User(string fullName, string userName, string email, string phoneNumber)
        {
            FullName = fullName;
            UserName = userName;
            NormalizedUserName = userName.ToUpper();
            Email = email;
            NormalizedEmail = email.ToUpper();
            PhoneNumber = phoneNumber;
        }

        public void SetFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("FullName cannot be empty.");

            FullName = fullName;
        }

        public void SetUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("Username cannot be empty.");

            UserName = userName;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Invalid email address.");

            Email = email;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be empty.");

            PhoneNumber = phoneNumber;
        }

        public void ConfirmEmail()
        {
            EmailConfirmed = true;
        }

        public void SetTwoFactorEnabled(bool isEnabled)
        {
            TwoFactorEnabled = isEnabled;
        }

        public void SetLockout(bool isEnabled, DateTimeOffset? lockoutEnd = null)
        {
            LockoutEnabled = isEnabled;
            LockoutEnd = lockoutEnd;
        }
    }
}
