using System;
using System.Collections.Generic;

namespace OAuthApp.Models.DB
{
    public partial class RoleFeaturesMap
    {
        public int RoleFeaturesMapId { get; set; }
        public int? RoleId { get; set; }
        public int? FeatureId { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string CreationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }

        public Features Role { get; set; }
        public Role RoleNavigation { get; set; }
    }
}
