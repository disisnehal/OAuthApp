using System;
using System.Collections.Generic;

namespace OAuthApp.Models.DB
{
    public partial class Features
    {
        public Features()
        {
            InverseSubFeature = new HashSet<Features>();
            RoleFeaturesMap = new HashSet<RoleFeaturesMap>();
        }

        public int FeatureId { get; set; }
        public int? SubFeatureId { get; set; }
        public string Description { get; set; }
        public string UrlLink { get; set; }
        public bool? IsActive { get; set; }
        public string CreationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }

        public Features SubFeature { get; set; }
        public ICollection<Features> InverseSubFeature { get; set; }
        public ICollection<RoleFeaturesMap> RoleFeaturesMap { get; set; }
    }
}
