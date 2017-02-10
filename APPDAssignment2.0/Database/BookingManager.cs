using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public void confirmBooking(Cart inCart) //Added this
        {
            List<DbParameter> parameterList = new List<DbParameter>();

            string sql = "UPDATE BOOKING SET NRIC = @NRIC, BookingDate = @BookingDate WHERE ResourceID = @Resource AND SlotDate = @SlotDate AND TimeSlotStart = @StartTime";
            foreach (var Booking in inCart.Cart_)
            {
                parameterList.Clear();
                parameterList.Add(base.GetParameter("@NRIC", Booking.NRIC));
                parameterList.Add(base.GetParameter("@BookingDate", Booking.BookingDate));
                parameterList.Add(base.GetParameter("@Resource", Booking.ResourceID));
                parameterList.Add(base.GetParameter("@SlotDate", Booking.SlotDate));
                parameterList.Add(base.GetParameter("@StartTime", Booking.StartTime));
                base.ExecuteScalar(sql, parameterList);
            }
        } //end
        public bool checkAvail(int ResourceID, DateTime? Slotdate, string STime)
        {
            Boolean canBook = true;
            List<DbParameter> parameterList = new List<DbParameter>();

            string sql = "SELECT BookingDate FROM BOOKING WHERE ResourceID = @Resource AND SlotDate = @SlotDate AND TimeSlotStart = @StartTime";

            parameterList.Clear();
            parameterList.Add(base.GetParameter("@Resource", ResourceID));
            parameterList.Add(base.GetParameter("@SlotDate", Slotdate));
            parameterList.Add(base.GetParameter("@StartTime", STime));

            using (DbDataReader dataReader = base.GetDataReader(sql, parameterList, CommandType.Text))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        if (!(dataReader["BookingDate"] is DBNull))
                        {
                            MessageBox.Show("This Timeslot is Unavailable");
                            canBook = false;
                            break;
                        }
                    }
                    return canBook;
                }
                return canBook;
            }
        }
        public List<Booking> prevBookings(string NRIC)
        {
            List<DbParameter> parameterList = new List<DbParameter>();
            List<Booking> previousbookings = new List<Booking>();
            Booking previousbooking;

            string sql = "SELECT ResourceID, SlotDate, TimeSlotStart, TimeSlotEnd FROM BOOKING WHERE NRIC = @NRIC";

            parameterList.Clear();
            parameterList.Add(base.GetParameter("@NRIC", NRIC));

            using (DbDataReader dataReader = base.GetDataReader(sql, parameterList, CommandType.Text))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        previousbooking = new Booking();
                        int R_ID = (int)dataReader["ResourceID"];

                        string sqlStatement = "SELECT ResourceName FROM RESOURCE WHERE ResourceID = @Resource_ID";

                        List<DbParameter> PList = new List<DbParameter>();

                        PList.Clear();
                        PList.Add(base.GetParameter("@Resource_ID", R_ID));

                        using ( DbDataReader dReader = base.GetDataReader(sqlStatement, PList, CommandType.Text))
                        {
                            if (dReader != null && dReader.HasRows)
                            {
                                while (dReader.Read())
                                {
                                    previousbooking.ResourceName = (string)dReader["ResourceName"];
                                }
                            }
                        }

                        previousbooking.SlotDate = (DateTime?)dataReader["SlotDate"];
                        previousbooking.StartTime = (string)dataReader["TimeSlotStart"].ToString();
                        previousbooking.EndTime = (string)dataReader["TimeSlotEnd"].ToString();
                        previousbookings.Add(previousbooking);
                    }
                }
                return previousbookings;
            }
        }
    }
}
