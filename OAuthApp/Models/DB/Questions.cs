using System;
using System.Collections.Generic;

namespace OAuthApp.Models.DB
{
    public partial class Questions
    {
        public Questions()
        {
            UserQuestions = new HashSet<UserQuestions>();
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }
        public bool? IsActive { get; set; }
        public string CreationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }

        public ICollection<UserQuestions> UserQuestions { get; set; }
    }
}
