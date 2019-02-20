using System;
using System.Collections.Generic;

namespace OAuthApp.Models.DB
{
    public partial class Role
    {
        public Role()
        {
            RoleFeaturesMap = new HashSet<RoleFeaturesMap>();
            UserLogIn = new HashSet<UserLogIn>();
        }

        public int RoleId { get; set; }
        public string RoleType { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string CreationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }

        public ICollection<RoleFeaturesMap> RoleFeaturesMap { get; set; }
        public ICollection<UserLogIn> UserLogIn { get; set; }
    }
}
