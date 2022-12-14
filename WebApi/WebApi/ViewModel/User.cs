using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class User
    {
        public System.Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string oauthSubject { get; set; }
        public string oauthIssuer { get; set; }
    }

    public class UserView
    {
        public string tokenId { get; set; }
    }
}