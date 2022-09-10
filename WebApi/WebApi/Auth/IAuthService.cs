using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using WebApi.ViewModels;

namespace WebApi.Auth
{

    public interface IAuthService
    {
        Task<User> Authenticate(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload);
    }

    public class AuthService : IAuthService
    {
        public AuthService()
        {
            this.Refresh();
        }
        private static IList<User> _users = new List<User>();
        public async Task<User> Authenticate(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload)
        {
            await Task.Delay(1);
            return this.FindUserOrAdd(payload);
        }

        private User FindUserOrAdd(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload)
        {
            var u = _users.Where(x => x.email == payload.Email).FirstOrDefault();
            if (u == null)
            {
                u = new User()
                {
                    id = Guid.NewGuid(),
                    name = payload.Name,
                    email = payload.Email,
                    oauthSubject = payload.Subject,
                    oauthIssuer = payload.Issuer
                };
                _users.Add(u);
            }
            this.PrintUsers();
            return u;
        }

        private void PrintUsers()
        {
            string s = String.Empty;
            foreach (var u in _users) s += "\n[" + u.email + "]";
            Services.Helpers.SimpleLogger.Log(s);
        }

        private void Refresh()
        {
            if (_users.Count == 0)
            {
                _users.Add(new User() { id = Guid.NewGuid(), name = "Test Person1", email = "testperson1@gmail.com" });
                _users.Add(new User() { id = Guid.NewGuid(), name = "Test Person2", email = "testperson2@gmail.com" });
                _users.Add(new User() { id = Guid.NewGuid(), name = "Beshoy Demian", email = "beshoy.basily@gmail.com" });
                this.PrintUsers();
            }
        }
    }
}
