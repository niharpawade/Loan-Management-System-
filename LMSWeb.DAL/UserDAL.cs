using LMSWeb.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSWeb.DAL
{
    public class UserDAL
    {
        public void Insert(UserEntity userEntity)
        {
            using (var dbContext = new LoanManagementSystemEntities())
            {
                tbl_LMSUser dbUser = new tbl_LMSUser();
                dbUser.Name = userEntity.Name;
                dbUser.Password = userEntity.Password;
                dbUser.MobileNo = userEntity.MobileNo;
                dbUser.EmailId = userEntity.EmailId;
                dbUser.Role = userEntity.Role;
                dbUser.IsActive = userEntity.IsActive;
                dbUser.IsLocked = userEntity.IsLocked;
                dbUser.SecurityQuestionId = userEntity.SecurityQuestionId;
                dbUser.Answer = userEntity.Answer;
                dbContext.tbl_LMSUser.Add(dbUser);
                dbContext.SaveChanges();
            }
        }

        public List<UserEntity> List()
        {
            List<UserEntity> users = new List<UserEntity>();

            using (var dbContext = new LoanManagementSystemEntities())
            {
                var dbUsers = dbContext.tbl_LMSUser.ToList();

                foreach (var dbUser in dbUsers)
                {
                    UserEntity userEntity = new UserEntity();
                    userEntity.Name = dbUser.Name;
                    userEntity.MobileNo = dbUser.MobileNo;
                    userEntity.EmailId = dbUser.EmailId;
                    userEntity.Id = dbUser.Id;
                    users.Add(userEntity);
                }// end of for
            }// end of using
            return users;
        }//end of method

        public UserEntity Get(int id)
        {
            UserEntity userEntity = new UserEntity();
            using (var dbContext = new LoanManagementSystemEntities())
            {
                var dbUser= dbContext.tbl_LMSUser.Where(user => user.Id == id).FirstOrDefault();
                userEntity.Id = dbUser.Id;
                userEntity.Name = dbUser.Name;
                userEntity.Password = dbUser.Password;
                userEntity.MobileNo = dbUser.MobileNo;
                userEntity.EmailId = dbUser.EmailId;
                userEntity.Role = dbUser.Role;
                userEntity.SecurityQuestionId = dbUser.SecurityQuestionId.Value;
                userEntity.Answer = dbUser.Answer;

            }
            return userEntity;

        }

        public void Update(UserEntity userEntity)
        {
            using (var dbContext = new LoanManagementSystemEntities())
            {
                var existingDBUser = dbContext.tbl_LMSUser.Where(u => u.Id == userEntity.Id).FirstOrDefault();
                UpdateDBUserInfo(ref existingDBUser, ref userEntity);
                //existingDBUser.Name = userEntity.Name;
                //existingDBUser.Password = userEntity.Password;
                //existingDBUser.MobileNo = userEntity.MobileNo;
                //existingDBUser.EmailId = userEntity.EmailId;
                //existingDBUser.Role = userEntity.Role;
                //existingDBUser.IsActive = userEntity.IsActive;
                //existingDBUser.IsLocked = userEntity.IsLocked;
                //existingDBUser.SecurityQuestionId = userEntity.SecurityQuestionId;
                //existingDBUser.Answer = userEntity.Answer;
                //existingDBUser.CreatedDate = DateTime.Now;
                //existingDBUser.CreatedBy="1";
                dbContext.SaveChanges();
            }
        }


        private void UpdateDBUserInfo(ref tbl_LMSUser existingDBUser,ref UserEntity userEntity)
        {
            existingDBUser.Name = userEntity.Name;
            existingDBUser.Password = userEntity.Password;
            existingDBUser.MobileNo = userEntity.MobileNo;
            existingDBUser.EmailId = userEntity.EmailId;
            existingDBUser.Role = userEntity.Role;
            existingDBUser.IsActive = userEntity.IsActive;
            existingDBUser.IsLocked = userEntity.IsLocked;
            existingDBUser.SecurityQuestionId = userEntity.SecurityQuestionId;
            existingDBUser.Answer = userEntity.Answer;
            existingDBUser.CreatedDate = DateTime.Now;
            existingDBUser.CreatedBy = "1";

        }
    }
}
