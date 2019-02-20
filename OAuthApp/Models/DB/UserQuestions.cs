using System;
using System.Collections.Generic;

namespace OAuthApp.Models.DB
{
    public partial class UserQuestions
    {
        public int UserQuestionId { get; set; }
        public int? UserLogInId { get; set; }
        public int? QuestionId { get; set; }
        public string Answer { get; set; }
        public bool? IsActive { get; set; }
        public string CreationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }

        public Questions Question { get; set; }
        public UserLogIn UserLogIn { get; set; }
    }
}
