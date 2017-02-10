using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static APPDAssignment2._0.DataModels;

namespace APPDAssignment2._0.Database
{
    public class BookingManager : DatabaseConnection
    {
        public Boolean SaveUserInformation(User inUser)
        {
            List<DbParameter> parameterList = new List<DbParameter>();

            string sql = "INSERT INTO [USER] (NRIC, UserName, Password) VALUES (@NRIC_,@Username_,@Password_)";
   
            foreach (var newUser in inUser.NewUser_)
            {
                parameterList.Clear();
                parameterList.Add(base.GetParameter("@NRIC_", newUser.NRIC));
                parameterList.Add(base.GetParameter("@Username_", newUser.Username));
                parameterList.Add(base.GetParameter("@Password_", newUser.Password));
                base.ExecuteScalar(sql, parameterList);
            }
            return true;
        }//End of SaveOrderAndOrderDetails

    }
}
