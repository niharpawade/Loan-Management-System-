using System;

namespace LMSWeb.BusinessEntities
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public string MobileNo { get; set; }

        public string EmailId { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public int SecurityQuestionId { get; set; }
        public string Answer { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
