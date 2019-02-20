using System;
using System.Collections.Generic;

namespace OAuthApp.Models.DB
{
    public partial class UserLogIn
    {
        public UserLogIn()
        {
            UserQuestions = new HashSet<UserQuestions>();
        }

        public int UserLogInId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public string CreationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }

        public Role Role { get; set; }
        public ICollection<UserQuestions> UserQuestions { get; set; }
    }
}
