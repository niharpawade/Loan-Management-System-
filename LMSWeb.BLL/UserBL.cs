using LMSWeb.BusinessEntities;
using LMSWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSWeb.BLL
{
    public class UserBL
    {
        public void Save(UserEntity userEntity)
        {
            UserDAL oUserDAL = new UserDAL();
            if (userEntity.Id == -1)
            {
             
                oUserDAL.Insert(userEntity);
            }
            else
            {
                oUserDAL.Update(userEntity);
            }
        }

        public List<UserEntity> GetAllUsers()
        {
            UserDAL oUserDAL = new UserDAL();
            return oUserDAL.List();
        }

        public UserEntity Get(int id)
        {
            UserDAL oUserDAL = new UserDAL();
            return oUserDAL.Get(id);
        }
    }
}
