using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static APPDAssignment2._0.DataModels;

namespace APPDAssignment2._0.Database
{
    public class DatabaseManager : DatabaseConnection
    {
        public List<Category> Categories { get; set; }
        public List<Resource> Resources { get; set; }
        public List<Booking> Bookings { get; set; }

        public DatabaseManager()
        {
            this.Categories = GetCategories();
            this.Resources = GetResources();
            this.Bookings = GetBookings();
        }

        public List<Category> GetCategories()
        {
            List<Category> CategoryList = new List<Category>();
            Category oneCategory = null;

            List<DbParameter> ParameterList = new List<DbParameter>();
            string sql = "SELECT CatID, CatName, CatPrice FROM CATEGORY";
            using (DbDataReader dataReader = base.GetDataReader(sql, ParameterList, CommandType.Text))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        oneCategory = new Category();
                        oneCategory.CategoryID = (int)dataReader["CatID"];
                        oneCategory.CategoryName = (string)dataReader["CatName"];
                        oneCategory.Price = (decimal)dataReader["CatPrice"];
                        CategoryList.Add(oneCategory);
                    }
                }
            }

            return CategoryList;
         }

        public List<Resource> GetResources()
        {
            List<Resource> ResourceList = new List<Resource>();
            Resource oneResource = null;

            List<DbParameter> ParameterList = new List<DbParameter>();
            string sql = "SELECT ResourceID, ResourceName, CatID, Image FROM [RESOURCE]";
            using (DbDataReader dataReader = base.GetDataReader(sql, ParameterList, CommandType.Text))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        oneResource = new Resource();
                        oneResource.ResourceID = (int)dataReader["ResourceID"];
                        oneResource.ResourceName = (string)dataReader["ResourceName"];
                        oneResource.CategoryID = (int)dataReader["CatID"];
                        if (dataReader["Image"] is System.DBNull)
                        {
                            byte[] nullArray = new byte[1];
                            oneResource.Images = nullArray;
                        }
                        else
                        {
                            oneResource.Images = (byte[])dataReader["Image"];
                        }
                        ResourceList.Add(oneResource);
                    }
                }
            }

            return ResourceList;
        }

        public List<Booking> GetBookings()
        {
            List<Booking> BookingList = new List<Booking>();
            Booking oneBooking = null;

            List<DbParameter> ParameterList = new List<DbParameter>();
            string sql = "SELECT BookingID, SlotDate, ResourceID, TimeSlotStart, TimeSlotEnd, BookedBy, BookingDate FROM BOOKING";
            using (DbDataReader dataReader = base.GetDataReader(sql, ParameterList, CommandType.Text))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        oneBooking = new Booking();
                        oneBooking.BookingID = (int)dataReader["BookingID"];
                        oneBooking.ResourceID = (int)dataReader["ResourceID"];
                        oneBooking.SlotDate = (DateTime?)dataReader["SlotDate"];
                        oneBooking.StartTime = (string)dataReader["TimeSlotStart"].ToString();
                        oneBooking.EndTime = (string)dataReader["TimeSlotEnd"].ToString();
                        if (dataReader["BookedBy"] is System.DBNull)
                        {
                            oneBooking.BookedBy = "";
                        }
                        else
                        {
                            oneBooking.BookedBy = (string)dataReader["BookedBy"];
                        }
                        if (dataReader["BookingDate"] is System.DBNull)
                        {
                            oneBooking.BookingDate = null;
                        }
                        else
                        {
                            oneBooking.BookingDate = (DateTime?)dataReader["BookingDate"];
                        }
                        BookingList.Add(oneBooking);
                    }
                }
            }

            return BookingList;
        }
    }
}
