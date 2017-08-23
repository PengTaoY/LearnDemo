

using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
namespace ToolSite.Entity
{
	public class Config
	{
		public static string DefaultDb = "ething_shop";
		public static string ConnStr = "Server=47.93.25.49;Port=3306;Database=ething_shop;Uid=ething;Pwd=ething@2017;";
	}
		
	public partial class Carmaintainitemfee
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public string Id { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long CarID { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ItemID { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal Price { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal HourlyPrice { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("CarID", this.CarID),
				 new MySqlParameter("ItemID", this.ItemID),
				 new MySqlParameter("price", this.Price),
				 new MySqlParameter("HourlyPrice", this.HourlyPrice),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO carmaintainitemfee(CarID, ItemID, price, HourlyPrice, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?CarID, ?ItemID, ?price, ?HourlyPrice, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("id", this.Id),
				 new MySqlParameter("CarID", this.CarID),
				 new MySqlParameter("ItemID", this.ItemID),
				 new MySqlParameter("price", this.Price),
				 new MySqlParameter("HourlyPrice", this.HourlyPrice),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE carmaintainitemfee SET CarID = ?CarID, ItemID = ?ItemID, price = ?price, HourlyPrice = ?HourlyPrice, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM carmaintainitemfee WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static Carmaintainitemfee GetById(int id)
        {
            string sql = string.Format("SELECT * FROM carmaintainitemfee WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<Carmaintainitemfee> list = new DatatableFill<Carmaintainitemfee>().FillModel(table);
            //List<Carmaintainitemfee> list = Mapper.DynamicMap<IDataReader, List<Carmaintainitemfee>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<Carmaintainitemfee> GetList()
        {
            string sql = "SELECT * FROM carmaintainitemfee";
            DataTable table = DBHelper.GetDateTable(sql);
			List<Carmaintainitemfee> list = new DatatableFill<Carmaintainitemfee>().FillModel(table);
            //List<Carmaintainitemfee> list = Mapper.DynamicMap<IDataReader, List<Carmaintainitemfee>>(table.CreateDataReader());
            return list;

        }

		public static List<Carmaintainitemfee> Find(string where)
        {
            string sql = string.Format("SELECT * FROM carmaintainitemfee WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<Carmaintainitemfee>().FillModel(table);
        }

        public static List<Carmaintainitemfee> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM carmaintainitemfee WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<Carmaintainitemfee> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<Carmaintainitemfee> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class DDealer
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string DealerName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ServiceLevel { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsTeaProvide { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsHighQuality { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsWifi { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsEfficiency { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Phone { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ProviceId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProviceName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProvinceIndexLetter { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CityId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CityName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DistrictId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string DistrictName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Address { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsAudate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Audatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string AboutUsHtml { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string AboutUsText { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CreateDate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string UpdateDate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string OpenTime { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CloseTime { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string MainImg { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ParentDealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Recommend { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string BrandNameExt { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string GrabAddress { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsDel { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string GrabBrandName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int IsSlove { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerType { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("DealerName", this.DealerName),
				 new MySqlParameter("ServiceLevel", this.ServiceLevel),
				 new MySqlParameter("IsTeaProvide", this.IsTeaProvide),
				 new MySqlParameter("IsHighQuality", this.IsHighQuality),
				 new MySqlParameter("IsWifi", this.IsWifi),
				 new MySqlParameter("IsEfficiency", this.IsEfficiency),
				 new MySqlParameter("Phone", this.Phone),
				 new MySqlParameter("ProviceId", this.ProviceId),
				 new MySqlParameter("ProviceName", this.ProviceName),
				 new MySqlParameter("ProvinceIndexLetter", this.ProvinceIndexLetter),
				 new MySqlParameter("CityId", this.CityId),
				 new MySqlParameter("CityName", this.CityName),
				 new MySqlParameter("DistrictId", this.DistrictId),
				 new MySqlParameter("DistrictName", this.DistrictName),
				 new MySqlParameter("Address", this.Address),
				 new MySqlParameter("IsAudate", this.IsAudate),
				 new MySqlParameter("audatedate", this.Audatedate),
				 new MySqlParameter("AboutUsHtml", this.AboutUsHtml),
				 new MySqlParameter("AboutUsText", this.AboutUsText),
				 new MySqlParameter("CreateDate", this.CreateDate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("UpdateDate", this.UpdateDate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("OpenTime", this.OpenTime),
				 new MySqlParameter("CloseTime", this.CloseTime),
				 new MySqlParameter("MainImg", this.MainImg),
				 new MySqlParameter("ParentDealerId", this.ParentDealerId),
				 new MySqlParameter("Recommend", this.Recommend),
				 new MySqlParameter("BrandNameExt", this.BrandNameExt),
				 new MySqlParameter("GrabAddress", this.GrabAddress),
				 new MySqlParameter("IsDel", this.IsDel),
				 new MySqlParameter("GrabBrandName", this.GrabBrandName),
				 new MySqlParameter("IsSlove", this.IsSlove),
				 new MySqlParameter("DealerType", this.DealerType)
			};

			string sql = "INSERT INTO d_dealer(DealerId, DealerName, ServiceLevel, IsTeaProvide, IsHighQuality, IsWifi, IsEfficiency, Phone, ProviceId, ProviceName, ProvinceIndexLetter, CityId, CityName, DistrictId, DistrictName, Address, IsAudate, audatedate, AboutUsHtml, AboutUsText, CreateDate, CreateUserId, UpdateDate, UpdateUserId, OpenTime, CloseTime, MainImg, ParentDealerId, Recommend, BrandNameExt, GrabAddress, IsDel, GrabBrandName, IsSlove, DealerType) VALUES(?DealerId, ?DealerName, ?ServiceLevel, ?IsTeaProvide, ?IsHighQuality, ?IsWifi, ?IsEfficiency, ?Phone, ?ProviceId, ?ProviceName, ?ProvinceIndexLetter, ?CityId, ?CityName, ?DistrictId, ?DistrictName, ?Address, ?IsAudate, ?audatedate, ?AboutUsHtml, ?AboutUsText, ?CreateDate, ?CreateUserId, ?UpdateDate, ?UpdateUserId, ?OpenTime, ?CloseTime, ?MainImg, ?ParentDealerId, ?Recommend, ?BrandNameExt, ?GrabAddress, ?IsDel, ?GrabBrandName, ?IsSlove, ?DealerType)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("DealerName", this.DealerName),
				 new MySqlParameter("ServiceLevel", this.ServiceLevel),
				 new MySqlParameter("IsTeaProvide", this.IsTeaProvide),
				 new MySqlParameter("IsHighQuality", this.IsHighQuality),
				 new MySqlParameter("IsWifi", this.IsWifi),
				 new MySqlParameter("IsEfficiency", this.IsEfficiency),
				 new MySqlParameter("Phone", this.Phone),
				 new MySqlParameter("ProviceId", this.ProviceId),
				 new MySqlParameter("ProviceName", this.ProviceName),
				 new MySqlParameter("ProvinceIndexLetter", this.ProvinceIndexLetter),
				 new MySqlParameter("CityId", this.CityId),
				 new MySqlParameter("CityName", this.CityName),
				 new MySqlParameter("DistrictId", this.DistrictId),
				 new MySqlParameter("DistrictName", this.DistrictName),
				 new MySqlParameter("Address", this.Address),
				 new MySqlParameter("IsAudate", this.IsAudate),
				 new MySqlParameter("audatedate", this.Audatedate),
				 new MySqlParameter("AboutUsHtml", this.AboutUsHtml),
				 new MySqlParameter("AboutUsText", this.AboutUsText),
				 new MySqlParameter("CreateDate", this.CreateDate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("UpdateDate", this.UpdateDate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("OpenTime", this.OpenTime),
				 new MySqlParameter("CloseTime", this.CloseTime),
				 new MySqlParameter("MainImg", this.MainImg),
				 new MySqlParameter("ParentDealerId", this.ParentDealerId),
				 new MySqlParameter("Recommend", this.Recommend),
				 new MySqlParameter("BrandNameExt", this.BrandNameExt),
				 new MySqlParameter("GrabAddress", this.GrabAddress),
				 new MySqlParameter("IsDel", this.IsDel),
				 new MySqlParameter("GrabBrandName", this.GrabBrandName),
				 new MySqlParameter("IsSlove", this.IsSlove),
				 new MySqlParameter("DealerType", this.DealerType)
			};

			string sql = "UPDATE d_dealer SET DealerId = ?DealerId, DealerName = ?DealerName, ServiceLevel = ?ServiceLevel, IsTeaProvide = ?IsTeaProvide, IsHighQuality = ?IsHighQuality, IsWifi = ?IsWifi, IsEfficiency = ?IsEfficiency, Phone = ?Phone, ProviceId = ?ProviceId, ProviceName = ?ProviceName, ProvinceIndexLetter = ?ProvinceIndexLetter, CityId = ?CityId, CityName = ?CityName, DistrictId = ?DistrictId, DistrictName = ?DistrictName, Address = ?Address, IsAudate = ?IsAudate, audatedate = ?audatedate, AboutUsHtml = ?AboutUsHtml, AboutUsText = ?AboutUsText, CreateDate = ?CreateDate, CreateUserId = ?CreateUserId, UpdateDate = ?UpdateDate, UpdateUserId = ?UpdateUserId, OpenTime = ?OpenTime, CloseTime = ?CloseTime, MainImg = ?MainImg, ParentDealerId = ?ParentDealerId, Recommend = ?Recommend, BrandNameExt = ?BrandNameExt, GrabAddress = ?GrabAddress, IsDel = ?IsDel, GrabBrandName = ?GrabBrandName, IsSlove = ?IsSlove, DealerType = ?DealerType WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM d_dealer WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static DDealer GetById(int id)
        {
            string sql = string.Format("SELECT * FROM d_dealer WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealer> list = new DatatableFill<DDealer>().FillModel(table);
            //List<DDealer> list = Mapper.DynamicMap<IDataReader, List<DDealer>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<DDealer> GetList()
        {
            string sql = "SELECT * FROM d_dealer";
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealer> list = new DatatableFill<DDealer>().FillModel(table);
            //List<DDealer> list = Mapper.DynamicMap<IDataReader, List<DDealer>>(table.CreateDataReader());
            return list;

        }

		public static List<DDealer> Find(string where)
        {
            string sql = string.Format("SELECT * FROM d_dealer WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<DDealer>().FillModel(table);
        }

        public static List<DDealer> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM d_dealer WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<DDealer> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<DDealer> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class DDealerappointmentdiscountday
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public string DayDiscountId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string DiscountName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DiscountType { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal Discount { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Startdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Enddate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte Enable { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("DayDiscountId", this.DayDiscountId),
				 new MySqlParameter("DiscountName", this.DiscountName),
				 new MySqlParameter("DiscountType", this.DiscountType),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("discount", this.Discount),
				 new MySqlParameter("startdate", this.Startdate),
				 new MySqlParameter("enddate", this.Enddate),
				 new MySqlParameter("Enable", this.Enable),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO d_dealerappointmentdiscountday(DayDiscountId, DiscountName, DiscountType, DealerId, discount, startdate, enddate, Enable, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?DayDiscountId, ?DiscountName, ?DiscountType, ?DealerId, ?discount, ?startdate, ?enddate, ?Enable, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("DayDiscountId", this.DayDiscountId),
				 new MySqlParameter("DiscountName", this.DiscountName),
				 new MySqlParameter("DiscountType", this.DiscountType),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("discount", this.Discount),
				 new MySqlParameter("startdate", this.Startdate),
				 new MySqlParameter("enddate", this.Enddate),
				 new MySqlParameter("Enable", this.Enable),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE d_dealerappointmentdiscountday SET DayDiscountId = ?DayDiscountId, DiscountName = ?DiscountName, DiscountType = ?DiscountType, DealerId = ?DealerId, discount = ?discount, startdate = ?startdate, enddate = ?enddate, Enable = ?Enable, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM d_dealerappointmentdiscountday WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static DDealerappointmentdiscountday GetById(int id)
        {
            string sql = string.Format("SELECT * FROM d_dealerappointmentdiscountday WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealerappointmentdiscountday> list = new DatatableFill<DDealerappointmentdiscountday>().FillModel(table);
            //List<DDealerappointmentdiscountday> list = Mapper.DynamicMap<IDataReader, List<DDealerappointmentdiscountday>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<DDealerappointmentdiscountday> GetList()
        {
            string sql = "SELECT * FROM d_dealerappointmentdiscountday";
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealerappointmentdiscountday> list = new DatatableFill<DDealerappointmentdiscountday>().FillModel(table);
            //List<DDealerappointmentdiscountday> list = Mapper.DynamicMap<IDataReader, List<DDealerappointmentdiscountday>>(table.CreateDataReader());
            return list;

        }

		public static List<DDealerappointmentdiscountday> Find(string where)
        {
            string sql = string.Format("SELECT * FROM d_dealerappointmentdiscountday WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<DDealerappointmentdiscountday>().FillModel(table);
        }

        public static List<DDealerappointmentdiscountday> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM d_dealerappointmentdiscountday WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<DDealerappointmentdiscountday> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<DDealerappointmentdiscountday> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class DDealerappointmentdiscounttime
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public string TimeDiscountId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string DayDiscountId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string TimeSpanId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("TimeDiscountId", this.TimeDiscountId),
				 new MySqlParameter("DayDiscountId", this.DayDiscountId),
				 new MySqlParameter("TimeSpanId", this.TimeSpanId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO d_dealerappointmentdiscounttime(TimeDiscountId, DayDiscountId, TimeSpanId, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?TimeDiscountId, ?DayDiscountId, ?TimeSpanId, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("TimeDiscountId", this.TimeDiscountId),
				 new MySqlParameter("DayDiscountId", this.DayDiscountId),
				 new MySqlParameter("TimeSpanId", this.TimeSpanId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE d_dealerappointmentdiscounttime SET TimeDiscountId = ?TimeDiscountId, DayDiscountId = ?DayDiscountId, TimeSpanId = ?TimeSpanId, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM d_dealerappointmentdiscounttime WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static DDealerappointmentdiscounttime GetById(int id)
        {
            string sql = string.Format("SELECT * FROM d_dealerappointmentdiscounttime WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealerappointmentdiscounttime> list = new DatatableFill<DDealerappointmentdiscounttime>().FillModel(table);
            //List<DDealerappointmentdiscounttime> list = Mapper.DynamicMap<IDataReader, List<DDealerappointmentdiscounttime>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<DDealerappointmentdiscounttime> GetList()
        {
            string sql = "SELECT * FROM d_dealerappointmentdiscounttime";
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealerappointmentdiscounttime> list = new DatatableFill<DDealerappointmentdiscounttime>().FillModel(table);
            //List<DDealerappointmentdiscounttime> list = Mapper.DynamicMap<IDataReader, List<DDealerappointmentdiscounttime>>(table.CreateDataReader());
            return list;

        }

		public static List<DDealerappointmentdiscounttime> Find(string where)
        {
            string sql = string.Format("SELECT * FROM d_dealerappointmentdiscounttime WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<DDealerappointmentdiscounttime>().FillModel(table);
        }

        public static List<DDealerappointmentdiscounttime> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM d_dealerappointmentdiscounttime WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<DDealerappointmentdiscounttime> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<DDealerappointmentdiscounttime> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class DDealerappointmenttimespan
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public string TimeSpanId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int LimitPersonCount { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public TimeSpan Starttime { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public TimeSpan Endtime { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("TimeSpanId", this.TimeSpanId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("LimitPersonCount", this.LimitPersonCount),
				 new MySqlParameter("starttime", this.Starttime),
				 new MySqlParameter("endtime", this.Endtime),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO d_dealerappointmenttimespan(TimeSpanId, DealerId, LimitPersonCount, starttime, endtime, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?TimeSpanId, ?DealerId, ?LimitPersonCount, ?starttime, ?endtime, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("TimeSpanId", this.TimeSpanId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("LimitPersonCount", this.LimitPersonCount),
				 new MySqlParameter("starttime", this.Starttime),
				 new MySqlParameter("endtime", this.Endtime),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE d_dealerappointmenttimespan SET TimeSpanId = ?TimeSpanId, DealerId = ?DealerId, LimitPersonCount = ?LimitPersonCount, starttime = ?starttime, endtime = ?endtime, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM d_dealerappointmenttimespan WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static DDealerappointmenttimespan GetById(int id)
        {
            string sql = string.Format("SELECT * FROM d_dealerappointmenttimespan WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealerappointmenttimespan> list = new DatatableFill<DDealerappointmenttimespan>().FillModel(table);
            //List<DDealerappointmenttimespan> list = Mapper.DynamicMap<IDataReader, List<DDealerappointmenttimespan>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<DDealerappointmenttimespan> GetList()
        {
            string sql = "SELECT * FROM d_dealerappointmenttimespan";
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealerappointmenttimespan> list = new DatatableFill<DDealerappointmenttimespan>().FillModel(table);
            //List<DDealerappointmenttimespan> list = Mapper.DynamicMap<IDataReader, List<DDealerappointmenttimespan>>(table.CreateDataReader());
            return list;

        }

		public static List<DDealerappointmenttimespan> Find(string where)
        {
            string sql = string.Format("SELECT * FROM d_dealerappointmenttimespan WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<DDealerappointmenttimespan>().FillModel(table);
        }

        public static List<DDealerappointmenttimespan> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM d_dealerappointmenttimespan WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<DDealerappointmenttimespan> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<DDealerappointmenttimespan> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class DDealerappointmenttimespanpersons
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public string TimeSpanPersonsId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string TimeSpanId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Appointmentdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CurrentPersonCount { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("TimeSpanPersonsId", this.TimeSpanPersonsId),
				 new MySqlParameter("TimeSpanId", this.TimeSpanId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("appointmentdate", this.Appointmentdate),
				 new MySqlParameter("CurrentPersonCount", this.CurrentPersonCount),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO d_dealerappointmenttimespanpersons(TimeSpanPersonsId, TimeSpanId, DealerId, appointmentdate, CurrentPersonCount, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?TimeSpanPersonsId, ?TimeSpanId, ?DealerId, ?appointmentdate, ?CurrentPersonCount, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("TimeSpanPersonsId", this.TimeSpanPersonsId),
				 new MySqlParameter("TimeSpanId", this.TimeSpanId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("appointmentdate", this.Appointmentdate),
				 new MySqlParameter("CurrentPersonCount", this.CurrentPersonCount),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE d_dealerappointmenttimespanpersons SET TimeSpanPersonsId = ?TimeSpanPersonsId, TimeSpanId = ?TimeSpanId, DealerId = ?DealerId, appointmentdate = ?appointmentdate, CurrentPersonCount = ?CurrentPersonCount, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM d_dealerappointmenttimespanpersons WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static DDealerappointmenttimespanpersons GetById(int id)
        {
            string sql = string.Format("SELECT * FROM d_dealerappointmenttimespanpersons WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealerappointmenttimespanpersons> list = new DatatableFill<DDealerappointmenttimespanpersons>().FillModel(table);
            //List<DDealerappointmenttimespanpersons> list = Mapper.DynamicMap<IDataReader, List<DDealerappointmenttimespanpersons>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<DDealerappointmenttimespanpersons> GetList()
        {
            string sql = "SELECT * FROM d_dealerappointmenttimespanpersons";
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealerappointmenttimespanpersons> list = new DatatableFill<DDealerappointmenttimespanpersons>().FillModel(table);
            //List<DDealerappointmenttimespanpersons> list = Mapper.DynamicMap<IDataReader, List<DDealerappointmenttimespanpersons>>(table.CreateDataReader());
            return list;

        }

		public static List<DDealerappointmenttimespanpersons> Find(string where)
        {
            string sql = string.Format("SELECT * FROM d_dealerappointmenttimespanpersons WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<DDealerappointmenttimespanpersons>().FillModel(table);
        }

        public static List<DDealerappointmenttimespanpersons> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM d_dealerappointmenttimespanpersons WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<DDealerappointmenttimespanpersons> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<DDealerappointmenttimespanpersons> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class DDealercheckin
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int CheckinId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string DealerName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ServiceLevel { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ManufacturerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Linkman { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Phone { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ProviceId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProviceName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CityId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CityName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DistrictId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string DistrictName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Address { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Duties { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Remark { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string BrandName { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("CheckinId", this.CheckinId),
				 new MySqlParameter("DealerName", this.DealerName),
				 new MySqlParameter("ServiceLevel", this.ServiceLevel),
				 new MySqlParameter("ManufacturerId", this.ManufacturerId),
				 new MySqlParameter("Linkman", this.Linkman),
				 new MySqlParameter("Phone", this.Phone),
				 new MySqlParameter("ProviceId", this.ProviceId),
				 new MySqlParameter("ProviceName", this.ProviceName),
				 new MySqlParameter("CityId", this.CityId),
				 new MySqlParameter("CityName", this.CityName),
				 new MySqlParameter("DistrictId", this.DistrictId),
				 new MySqlParameter("DistrictName", this.DistrictName),
				 new MySqlParameter("Address", this.Address),
				 new MySqlParameter("Duties", this.Duties),
				 new MySqlParameter("Remark", this.Remark),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("BrandName", this.BrandName)
			};

			string sql = "INSERT INTO d_dealercheckin(CheckinId, DealerName, ServiceLevel, ManufacturerId, Linkman, Phone, ProviceId, ProviceName, CityId, CityName, DistrictId, DistrictName, Address, Duties, Remark, createdate, CreateUserId, updatedate, UpdateUserId, BrandName) VALUES(?CheckinId, ?DealerName, ?ServiceLevel, ?ManufacturerId, ?Linkman, ?Phone, ?ProviceId, ?ProviceName, ?CityId, ?CityName, ?DistrictId, ?DistrictName, ?Address, ?Duties, ?Remark, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?BrandName)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("CheckinId", this.CheckinId),
				 new MySqlParameter("DealerName", this.DealerName),
				 new MySqlParameter("ServiceLevel", this.ServiceLevel),
				 new MySqlParameter("ManufacturerId", this.ManufacturerId),
				 new MySqlParameter("Linkman", this.Linkman),
				 new MySqlParameter("Phone", this.Phone),
				 new MySqlParameter("ProviceId", this.ProviceId),
				 new MySqlParameter("ProviceName", this.ProviceName),
				 new MySqlParameter("CityId", this.CityId),
				 new MySqlParameter("CityName", this.CityName),
				 new MySqlParameter("DistrictId", this.DistrictId),
				 new MySqlParameter("DistrictName", this.DistrictName),
				 new MySqlParameter("Address", this.Address),
				 new MySqlParameter("Duties", this.Duties),
				 new MySqlParameter("Remark", this.Remark),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("BrandName", this.BrandName)
			};

			string sql = "UPDATE d_dealercheckin SET CheckinId = ?CheckinId, DealerName = ?DealerName, ServiceLevel = ?ServiceLevel, ManufacturerId = ?ManufacturerId, Linkman = ?Linkman, Phone = ?Phone, ProviceId = ?ProviceId, ProviceName = ?ProviceName, CityId = ?CityId, CityName = ?CityName, DistrictId = ?DistrictId, DistrictName = ?DistrictName, Address = ?Address, Duties = ?Duties, Remark = ?Remark, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, BrandName = ?BrandName WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM d_dealercheckin WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static DDealercheckin GetById(int id)
        {
            string sql = string.Format("SELECT * FROM d_dealercheckin WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealercheckin> list = new DatatableFill<DDealercheckin>().FillModel(table);
            //List<DDealercheckin> list = Mapper.DynamicMap<IDataReader, List<DDealercheckin>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<DDealercheckin> GetList()
        {
            string sql = "SELECT * FROM d_dealercheckin";
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealercheckin> list = new DatatableFill<DDealercheckin>().FillModel(table);
            //List<DDealercheckin> list = Mapper.DynamicMap<IDataReader, List<DDealercheckin>>(table.CreateDataReader());
            return list;

        }

		public static List<DDealercheckin> Find(string where)
        {
            string sql = string.Format("SELECT * FROM d_dealercheckin WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<DDealercheckin>().FillModel(table);
        }

        public static List<DDealercheckin> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM d_dealercheckin WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<DDealercheckin> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<DDealercheckin> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class DDealerrelationbrand
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public string Id { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int BrandId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int SubBrandId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CreateDate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string UpdateDate { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("BrandId", this.BrandId),
				 new MySqlParameter("SubBrandId", this.SubBrandId),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("CreateDate", this.CreateDate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("UpdateDate", this.UpdateDate)
			};

			string sql = "INSERT INTO d_dealerrelationbrand(DealerId, BrandId, SubBrandId, CreateUserId, CreateDate, UpdateUserId, UpdateDate) VALUES(?DealerId, ?BrandId, ?SubBrandId, ?CreateUserId, ?CreateDate, ?UpdateUserId, ?UpdateDate)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("id", this.Id),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("BrandId", this.BrandId),
				 new MySqlParameter("SubBrandId", this.SubBrandId),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("CreateDate", this.CreateDate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("UpdateDate", this.UpdateDate)
			};

			string sql = "UPDATE d_dealerrelationbrand SET DealerId = ?DealerId, BrandId = ?BrandId, SubBrandId = ?SubBrandId, CreateUserId = ?CreateUserId, CreateDate = ?CreateDate, UpdateUserId = ?UpdateUserId, UpdateDate = ?UpdateDate WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM d_dealerrelationbrand WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static DDealerrelationbrand GetById(int id)
        {
            string sql = string.Format("SELECT * FROM d_dealerrelationbrand WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealerrelationbrand> list = new DatatableFill<DDealerrelationbrand>().FillModel(table);
            //List<DDealerrelationbrand> list = Mapper.DynamicMap<IDataReader, List<DDealerrelationbrand>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<DDealerrelationbrand> GetList()
        {
            string sql = "SELECT * FROM d_dealerrelationbrand";
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealerrelationbrand> list = new DatatableFill<DDealerrelationbrand>().FillModel(table);
            //List<DDealerrelationbrand> list = Mapper.DynamicMap<IDataReader, List<DDealerrelationbrand>>(table.CreateDataReader());
            return list;

        }

		public static List<DDealerrelationbrand> Find(string where)
        {
            string sql = string.Format("SELECT * FROM d_dealerrelationbrand WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<DDealerrelationbrand>().FillModel(table);
        }

        public static List<DDealerrelationbrand> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM d_dealerrelationbrand WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<DDealerrelationbrand> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<DDealerrelationbrand> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class DDealeruser
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("UserId", this.UserId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO d_dealeruser(DealerId, UserId, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?DealerId, ?UserId, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("UserId", this.UserId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE d_dealeruser SET DealerId = ?DealerId, UserId = ?UserId, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM d_dealeruser WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static DDealeruser GetById(int id)
        {
            string sql = string.Format("SELECT * FROM d_dealeruser WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealeruser> list = new DatatableFill<DDealeruser>().FillModel(table);
            //List<DDealeruser> list = Mapper.DynamicMap<IDataReader, List<DDealeruser>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<DDealeruser> GetList()
        {
            string sql = "SELECT * FROM d_dealeruser";
            DataTable table = DBHelper.GetDateTable(sql);
			List<DDealeruser> list = new DatatableFill<DDealeruser>().FillModel(table);
            //List<DDealeruser> list = Mapper.DynamicMap<IDataReader, List<DDealeruser>>(table.CreateDataReader());
            return list;

        }

		public static List<DDealeruser> Find(string where)
        {
            string sql = string.Format("SELECT * FROM d_dealeruser WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<DDealeruser>().FillModel(table);
        }

        public static List<DDealeruser> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM d_dealeruser WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<DDealeruser> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<DDealeruser> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class DManufacturer
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int ManufacturerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ManufacturerName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ManufacturerId", this.ManufacturerId),
				 new MySqlParameter("ManufacturerName", this.ManufacturerName),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("UserId", this.UserId)
			};

			string sql = "INSERT INTO d_manufacturer(ManufacturerId, ManufacturerName, createdate, CreateUserId, updatedate, UpdateUserId, UserId) VALUES(?ManufacturerId, ?ManufacturerName, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?UserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ManufacturerId", this.ManufacturerId),
				 new MySqlParameter("ManufacturerName", this.ManufacturerName),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("UserId", this.UserId)
			};

			string sql = "UPDATE d_manufacturer SET ManufacturerId = ?ManufacturerId, ManufacturerName = ?ManufacturerName, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, UserId = ?UserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM d_manufacturer WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static DManufacturer GetById(int id)
        {
            string sql = string.Format("SELECT * FROM d_manufacturer WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<DManufacturer> list = new DatatableFill<DManufacturer>().FillModel(table);
            //List<DManufacturer> list = Mapper.DynamicMap<IDataReader, List<DManufacturer>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<DManufacturer> GetList()
        {
            string sql = "SELECT * FROM d_manufacturer";
            DataTable table = DBHelper.GetDateTable(sql);
			List<DManufacturer> list = new DatatableFill<DManufacturer>().FillModel(table);
            //List<DManufacturer> list = Mapper.DynamicMap<IDataReader, List<DManufacturer>>(table.CreateDataReader());
            return list;

        }

		public static List<DManufacturer> Find(string where)
        {
            string sql = string.Format("SELECT * FROM d_manufacturer WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<DManufacturer>().FillModel(table);
        }

        public static List<DManufacturer> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM d_manufacturer WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<DManufacturer> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<DManufacturer> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class MCarmaintain
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int CarMaintainId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CarId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Mails { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Months { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string MaintainTime { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("CarMaintainId", this.CarMaintainId),
				 new MySqlParameter("CarId", this.CarId),
				 new MySqlParameter("Mails", this.Mails),
				 new MySqlParameter("Months", this.Months),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("MaintainTime", this.MaintainTime)
			};

			string sql = "INSERT INTO m_carmaintain(CarMaintainId, CarId, Mails, Months, createdate, CreateUserId, updatedate, UpdateUserId, MaintainTime) VALUES(?CarMaintainId, ?CarId, ?Mails, ?Months, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?MaintainTime)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("CarMaintainId", this.CarMaintainId),
				 new MySqlParameter("CarId", this.CarId),
				 new MySqlParameter("Mails", this.Mails),
				 new MySqlParameter("Months", this.Months),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("MaintainTime", this.MaintainTime)
			};

			string sql = "UPDATE m_carmaintain SET CarMaintainId = ?CarMaintainId, CarId = ?CarId, Mails = ?Mails, Months = ?Months, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, MaintainTime = ?MaintainTime WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM m_carmaintain WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static MCarmaintain GetById(int id)
        {
            string sql = string.Format("SELECT * FROM m_carmaintain WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<MCarmaintain> list = new DatatableFill<MCarmaintain>().FillModel(table);
            //List<MCarmaintain> list = Mapper.DynamicMap<IDataReader, List<MCarmaintain>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<MCarmaintain> GetList()
        {
            string sql = "SELECT * FROM m_carmaintain";
            DataTable table = DBHelper.GetDateTable(sql);
			List<MCarmaintain> list = new DatatableFill<MCarmaintain>().FillModel(table);
            //List<MCarmaintain> list = Mapper.DynamicMap<IDataReader, List<MCarmaintain>>(table.CreateDataReader());
            return list;

        }

		public static List<MCarmaintain> Find(string where)
        {
            string sql = string.Format("SELECT * FROM m_carmaintain WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<MCarmaintain>().FillModel(table);
        }

        public static List<MCarmaintain> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM m_carmaintain WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<MCarmaintain> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<MCarmaintain> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class MCarmaintaindetail
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int CarMaintaiDetailId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CarMaintainId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ItemId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Status { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("CarMaintaiDetailId", this.CarMaintaiDetailId),
				 new MySqlParameter("CarMaintainId", this.CarMaintainId),
				 new MySqlParameter("ItemId", this.ItemId),
				 new MySqlParameter("Status", this.Status),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO m_carmaintaindetail(CarMaintaiDetailId, CarMaintainId, ItemId, Status, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?CarMaintaiDetailId, ?CarMaintainId, ?ItemId, ?Status, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("CarMaintaiDetailId", this.CarMaintaiDetailId),
				 new MySqlParameter("CarMaintainId", this.CarMaintainId),
				 new MySqlParameter("ItemId", this.ItemId),
				 new MySqlParameter("Status", this.Status),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE m_carmaintaindetail SET CarMaintaiDetailId = ?CarMaintaiDetailId, CarMaintainId = ?CarMaintainId, ItemId = ?ItemId, Status = ?Status, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM m_carmaintaindetail WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static MCarmaintaindetail GetById(int id)
        {
            string sql = string.Format("SELECT * FROM m_carmaintaindetail WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<MCarmaintaindetail> list = new DatatableFill<MCarmaintaindetail>().FillModel(table);
            //List<MCarmaintaindetail> list = Mapper.DynamicMap<IDataReader, List<MCarmaintaindetail>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<MCarmaintaindetail> GetList()
        {
            string sql = "SELECT * FROM m_carmaintaindetail";
            DataTable table = DBHelper.GetDateTable(sql);
			List<MCarmaintaindetail> list = new DatatableFill<MCarmaintaindetail>().FillModel(table);
            //List<MCarmaintaindetail> list = Mapper.DynamicMap<IDataReader, List<MCarmaintaindetail>>(table.CreateDataReader());
            return list;

        }

		public static List<MCarmaintaindetail> Find(string where)
        {
            string sql = string.Format("SELECT * FROM m_carmaintaindetail WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<MCarmaintaindetail>().FillModel(table);
        }

        public static List<MCarmaintaindetail> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM m_carmaintaindetail WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<MCarmaintaindetail> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<MCarmaintaindetail> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class MClientfavoritedealer
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long ClientId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO m_clientfavoritedealer(DealerId, ClientId, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?DealerId, ?ClientId, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE m_clientfavoritedealer SET DealerId = ?DealerId, ClientId = ?ClientId, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM m_clientfavoritedealer WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static MClientfavoritedealer GetById(int id)
        {
            string sql = string.Format("SELECT * FROM m_clientfavoritedealer WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<MClientfavoritedealer> list = new DatatableFill<MClientfavoritedealer>().FillModel(table);
            //List<MClientfavoritedealer> list = Mapper.DynamicMap<IDataReader, List<MClientfavoritedealer>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<MClientfavoritedealer> GetList()
        {
            string sql = "SELECT * FROM m_clientfavoritedealer";
            DataTable table = DBHelper.GetDateTable(sql);
			List<MClientfavoritedealer> list = new DatatableFill<MClientfavoritedealer>().FillModel(table);
            //List<MClientfavoritedealer> list = Mapper.DynamicMap<IDataReader, List<MClientfavoritedealer>>(table.CreateDataReader());
            return list;

        }

		public static List<MClientfavoritedealer> Find(string where)
        {
            string sql = string.Format("SELECT * FROM m_clientfavoritedealer WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<MClientfavoritedealer>().FillModel(table);
        }

        public static List<MClientfavoritedealer> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM m_clientfavoritedealer WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<MClientfavoritedealer> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<MClientfavoritedealer> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class MClientfavoriteproduct
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public long ProductId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long ClientId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO m_clientfavoriteproduct(ProductId, ClientId, DealerId, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?ProductId, ?ClientId, ?DealerId, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE m_clientfavoriteproduct SET ProductId = ?ProductId, ClientId = ?ClientId, DealerId = ?DealerId, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM m_clientfavoriteproduct WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static MClientfavoriteproduct GetById(int id)
        {
            string sql = string.Format("SELECT * FROM m_clientfavoriteproduct WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<MClientfavoriteproduct> list = new DatatableFill<MClientfavoriteproduct>().FillModel(table);
            //List<MClientfavoriteproduct> list = Mapper.DynamicMap<IDataReader, List<MClientfavoriteproduct>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<MClientfavoriteproduct> GetList()
        {
            string sql = "SELECT * FROM m_clientfavoriteproduct";
            DataTable table = DBHelper.GetDateTable(sql);
			List<MClientfavoriteproduct> list = new DatatableFill<MClientfavoriteproduct>().FillModel(table);
            //List<MClientfavoriteproduct> list = Mapper.DynamicMap<IDataReader, List<MClientfavoriteproduct>>(table.CreateDataReader());
            return list;

        }

		public static List<MClientfavoriteproduct> Find(string where)
        {
            string sql = string.Format("SELECT * FROM m_clientfavoriteproduct WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<MClientfavoriteproduct>().FillModel(table);
        }

        public static List<MClientfavoriteproduct> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM m_clientfavoriteproduct WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<MClientfavoriteproduct> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<MClientfavoriteproduct> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class MDealerprovinceuser
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int ProvinceId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProvinceId", this.ProvinceId),
				 new MySqlParameter("UserId", this.UserId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO m_dealerprovinceuser(ProvinceId, UserId, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?ProvinceId, ?UserId, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProvinceId", this.ProvinceId),
				 new MySqlParameter("UserId", this.UserId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE m_dealerprovinceuser SET ProvinceId = ?ProvinceId, UserId = ?UserId, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM m_dealerprovinceuser WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static MDealerprovinceuser GetById(int id)
        {
            string sql = string.Format("SELECT * FROM m_dealerprovinceuser WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<MDealerprovinceuser> list = new DatatableFill<MDealerprovinceuser>().FillModel(table);
            //List<MDealerprovinceuser> list = Mapper.DynamicMap<IDataReader, List<MDealerprovinceuser>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<MDealerprovinceuser> GetList()
        {
            string sql = "SELECT * FROM m_dealerprovinceuser";
            DataTable table = DBHelper.GetDateTable(sql);
			List<MDealerprovinceuser> list = new DatatableFill<MDealerprovinceuser>().FillModel(table);
            //List<MDealerprovinceuser> list = Mapper.DynamicMap<IDataReader, List<MDealerprovinceuser>>(table.CreateDataReader());
            return list;

        }

		public static List<MDealerprovinceuser> Find(string where)
        {
            string sql = string.Format("SELECT * FROM m_dealerprovinceuser WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<MDealerprovinceuser>().FillModel(table);
        }

        public static List<MDealerprovinceuser> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM m_dealerprovinceuser WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<MDealerprovinceuser> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<MDealerprovinceuser> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class MDealerregionprovince
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int ProvinceId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ChinaRegionId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProvinceId", this.ProvinceId),
				 new MySqlParameter("ChinaRegionId", this.ChinaRegionId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO m_dealerregionprovince(ProvinceId, ChinaRegionId, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?ProvinceId, ?ChinaRegionId, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProvinceId", this.ProvinceId),
				 new MySqlParameter("ChinaRegionId", this.ChinaRegionId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE m_dealerregionprovince SET ProvinceId = ?ProvinceId, ChinaRegionId = ?ChinaRegionId, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM m_dealerregionprovince WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static MDealerregionprovince GetById(int id)
        {
            string sql = string.Format("SELECT * FROM m_dealerregionprovince WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<MDealerregionprovince> list = new DatatableFill<MDealerregionprovince>().FillModel(table);
            //List<MDealerregionprovince> list = Mapper.DynamicMap<IDataReader, List<MDealerregionprovince>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<MDealerregionprovince> GetList()
        {
            string sql = "SELECT * FROM m_dealerregionprovince";
            DataTable table = DBHelper.GetDateTable(sql);
			List<MDealerregionprovince> list = new DatatableFill<MDealerregionprovince>().FillModel(table);
            //List<MDealerregionprovince> list = Mapper.DynamicMap<IDataReader, List<MDealerregionprovince>>(table.CreateDataReader());
            return list;

        }

		public static List<MDealerregionprovince> Find(string where)
        {
            string sql = string.Format("SELECT * FROM m_dealerregionprovince WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<MDealerregionprovince>().FillModel(table);
        }

        public static List<MDealerregionprovince> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM m_dealerregionprovince WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<MDealerregionprovince> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<MDealerregionprovince> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class MDealerregionuser
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int UserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ChinaRegionId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("UserId", this.UserId),
				 new MySqlParameter("ChinaRegionId", this.ChinaRegionId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO m_dealerregionuser(UserId, ChinaRegionId, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?UserId, ?ChinaRegionId, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("UserId", this.UserId),
				 new MySqlParameter("ChinaRegionId", this.ChinaRegionId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE m_dealerregionuser SET UserId = ?UserId, ChinaRegionId = ?ChinaRegionId, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM m_dealerregionuser WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static MDealerregionuser GetById(int id)
        {
            string sql = string.Format("SELECT * FROM m_dealerregionuser WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<MDealerregionuser> list = new DatatableFill<MDealerregionuser>().FillModel(table);
            //List<MDealerregionuser> list = Mapper.DynamicMap<IDataReader, List<MDealerregionuser>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<MDealerregionuser> GetList()
        {
            string sql = "SELECT * FROM m_dealerregionuser";
            DataTable table = DBHelper.GetDateTable(sql);
			List<MDealerregionuser> list = new DatatableFill<MDealerregionuser>().FillModel(table);
            //List<MDealerregionuser> list = Mapper.DynamicMap<IDataReader, List<MDealerregionuser>>(table.CreateDataReader());
            return list;

        }

		public static List<MDealerregionuser> Find(string where)
        {
            string sql = string.Format("SELECT * FROM m_dealerregionuser WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<MDealerregionuser>().FillModel(table);
        }

        public static List<MDealerregionuser> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM m_dealerregionuser WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<MDealerregionuser> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<MDealerregionuser> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class MExpress
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int ExpressId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ExpressName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal ExpressFee { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ExpressId", this.ExpressId),
				 new MySqlParameter("ExpressName", this.ExpressName),
				 new MySqlParameter("ExpressFee", this.ExpressFee),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO m_express(ExpressId, ExpressName, ExpressFee, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?ExpressId, ?ExpressName, ?ExpressFee, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ExpressId", this.ExpressId),
				 new MySqlParameter("ExpressName", this.ExpressName),
				 new MySqlParameter("ExpressFee", this.ExpressFee),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE m_express SET ExpressId = ?ExpressId, ExpressName = ?ExpressName, ExpressFee = ?ExpressFee, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM m_express WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static MExpress GetById(int id)
        {
            string sql = string.Format("SELECT * FROM m_express WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<MExpress> list = new DatatableFill<MExpress>().FillModel(table);
            //List<MExpress> list = Mapper.DynamicMap<IDataReader, List<MExpress>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<MExpress> GetList()
        {
            string sql = "SELECT * FROM m_express";
            DataTable table = DBHelper.GetDateTable(sql);
			List<MExpress> list = new DatatableFill<MExpress>().FillModel(table);
            //List<MExpress> list = Mapper.DynamicMap<IDataReader, List<MExpress>>(table.CreateDataReader());
            return list;

        }

		public static List<MExpress> Find(string where)
        {
            string sql = string.Format("SELECT * FROM m_express WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<MExpress>().FillModel(table);
        }

        public static List<MExpress> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM m_express WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<MExpress> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<MExpress> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class MMaintainitem
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int ItemId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ItemName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int MaintainItemType { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ImageUrl { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ItemId", this.ItemId),
				 new MySqlParameter("ItemName", this.ItemName),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("MaintainItemType", this.MaintainItemType),
				 new MySqlParameter("ImageUrl", this.ImageUrl)
			};

			string sql = "INSERT INTO m_maintainitem(ItemId, ItemName, createdate, CreateUserId, updatedate, UpdateUserId, MaintainItemType, ImageUrl) VALUES(?ItemId, ?ItemName, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?MaintainItemType, ?ImageUrl)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ItemId", this.ItemId),
				 new MySqlParameter("ItemName", this.ItemName),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("MaintainItemType", this.MaintainItemType),
				 new MySqlParameter("ImageUrl", this.ImageUrl)
			};

			string sql = "UPDATE m_maintainitem SET ItemId = ?ItemId, ItemName = ?ItemName, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, MaintainItemType = ?MaintainItemType, ImageUrl = ?ImageUrl WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM m_maintainitem WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static MMaintainitem GetById(int id)
        {
            string sql = string.Format("SELECT * FROM m_maintainitem WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<MMaintainitem> list = new DatatableFill<MMaintainitem>().FillModel(table);
            //List<MMaintainitem> list = Mapper.DynamicMap<IDataReader, List<MMaintainitem>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<MMaintainitem> GetList()
        {
            string sql = "SELECT * FROM m_maintainitem";
            DataTable table = DBHelper.GetDateTable(sql);
			List<MMaintainitem> list = new DatatableFill<MMaintainitem>().FillModel(table);
            //List<MMaintainitem> list = Mapper.DynamicMap<IDataReader, List<MMaintainitem>>(table.CreateDataReader());
            return list;

        }

		public static List<MMaintainitem> Find(string where)
        {
            string sql = string.Format("SELECT * FROM m_maintainitem WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<MMaintainitem>().FillModel(table);
        }

        public static List<MMaintainitem> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM m_maintainitem WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<MMaintainitem> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<MMaintainitem> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class MMycar
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int MyCarId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long ClientId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CarId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Buydate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CurrentMails { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CarNumber { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsDefault { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ProviceId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CityId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string VIN { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string EngineNo { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("MyCarId", this.MyCarId),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("CarId", this.CarId),
				 new MySqlParameter("buydate", this.Buydate),
				 new MySqlParameter("CurrentMails", this.CurrentMails),
				 new MySqlParameter("CarNumber", this.CarNumber),
				 new MySqlParameter("IsDefault", this.IsDefault),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("ProviceId", this.ProviceId),
				 new MySqlParameter("CityId", this.CityId),
				 new MySqlParameter("VIN", this.VIN),
				 new MySqlParameter("EngineNo", this.EngineNo)
			};

			string sql = "INSERT INTO m_mycar(MyCarId, ClientId, CarId, buydate, CurrentMails, CarNumber, IsDefault, createdate, CreateUserId, updatedate, UpdateUserId, ProviceId, CityId, VIN, EngineNo) VALUES(?MyCarId, ?ClientId, ?CarId, ?buydate, ?CurrentMails, ?CarNumber, ?IsDefault, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?ProviceId, ?CityId, ?VIN, ?EngineNo)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("MyCarId", this.MyCarId),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("CarId", this.CarId),
				 new MySqlParameter("buydate", this.Buydate),
				 new MySqlParameter("CurrentMails", this.CurrentMails),
				 new MySqlParameter("CarNumber", this.CarNumber),
				 new MySqlParameter("IsDefault", this.IsDefault),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("ProviceId", this.ProviceId),
				 new MySqlParameter("CityId", this.CityId),
				 new MySqlParameter("VIN", this.VIN),
				 new MySqlParameter("EngineNo", this.EngineNo)
			};

			string sql = "UPDATE m_mycar SET MyCarId = ?MyCarId, ClientId = ?ClientId, CarId = ?CarId, buydate = ?buydate, CurrentMails = ?CurrentMails, CarNumber = ?CarNumber, IsDefault = ?IsDefault, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, ProviceId = ?ProviceId, CityId = ?CityId, VIN = ?VIN, EngineNo = ?EngineNo WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM m_mycar WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static MMycar GetById(int id)
        {
            string sql = string.Format("SELECT * FROM m_mycar WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<MMycar> list = new DatatableFill<MMycar>().FillModel(table);
            //List<MMycar> list = Mapper.DynamicMap<IDataReader, List<MMycar>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<MMycar> GetList()
        {
            string sql = "SELECT * FROM m_mycar";
            DataTable table = DBHelper.GetDateTable(sql);
			List<MMycar> list = new DatatableFill<MMycar>().FillModel(table);
            //List<MMycar> list = Mapper.DynamicMap<IDataReader, List<MMycar>>(table.CreateDataReader());
            return list;

        }

		public static List<MMycar> Find(string where)
        {
            string sql = string.Format("SELECT * FROM m_mycar WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<MMycar>().FillModel(table);
        }

        public static List<MMycar> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM m_mycar WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<MMycar> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<MMycar> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class OAppointment
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public string AppointmentCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int MyCarId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ClientId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CarNumber { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ClientName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Cellphone { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte Gender { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Status { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime AppointmentDate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal Totalprice { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int PayStatus { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Paydate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Contact { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int AppointmentType { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Discription { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Mails { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CarId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CarName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CarBrand { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CarLine { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string MainImageUrl { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string BuyDate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int PayType { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string TradeCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string RefundCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ConfirmRemark { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string FinishRemark { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Finishdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal Tradefee { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime AppointmentEndDate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string FaultReason { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string FaultImages { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string AppointmentTimeDetailId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int PayTypeDetail { get; set; }
		/// <summary>
        /// 我的优惠券id
        /// </summary>
		public string CouponCode { get; set; }
		/// <summary>
        /// 优惠券优惠金额
        /// </summary>
		public decimal CouponDiscountFee { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("AppointmentCode", this.AppointmentCode),
				 new MySqlParameter("MyCarId", this.MyCarId),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("CarNumber", this.CarNumber),
				 new MySqlParameter("ClientName", this.ClientName),
				 new MySqlParameter("Cellphone", this.Cellphone),
				 new MySqlParameter("Gender", this.Gender),
				 new MySqlParameter("Status", this.Status),
				 new MySqlParameter("AppointmentDate", this.AppointmentDate),
				 new MySqlParameter("totalprice", this.Totalprice),
				 new MySqlParameter("PayStatus", this.PayStatus),
				 new MySqlParameter("paydate", this.Paydate),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("Contact", this.Contact),
				 new MySqlParameter("AppointmentType", this.AppointmentType),
				 new MySqlParameter("Discription", this.Discription),
				 new MySqlParameter("Mails", this.Mails),
				 new MySqlParameter("CarId", this.CarId),
				 new MySqlParameter("CarName", this.CarName),
				 new MySqlParameter("CarBrand", this.CarBrand),
				 new MySqlParameter("CarLine", this.CarLine),
				 new MySqlParameter("MainImageUrl", this.MainImageUrl),
				 new MySqlParameter("BuyDate", this.BuyDate),
				 new MySqlParameter("PayType", this.PayType),
				 new MySqlParameter("TradeCode", this.TradeCode),
				 new MySqlParameter("RefundCode", this.RefundCode),
				 new MySqlParameter("ConfirmRemark", this.ConfirmRemark),
				 new MySqlParameter("FinishRemark", this.FinishRemark),
				 new MySqlParameter("finishdate", this.Finishdate),
				 new MySqlParameter("tradefee", this.Tradefee),
				 new MySqlParameter("AppointmentEndDate", this.AppointmentEndDate),
				 new MySqlParameter("FaultReason", this.FaultReason),
				 new MySqlParameter("FaultImages", this.FaultImages),
				 new MySqlParameter("AppointmentTimeDetailId", this.AppointmentTimeDetailId),
				 new MySqlParameter("PayTypeDetail", this.PayTypeDetail),
				 new MySqlParameter("CouponCode", this.CouponCode),
				 new MySqlParameter("CouponDiscountFee", this.CouponDiscountFee)
			};

			string sql = "INSERT INTO o_appointment(AppointmentCode, MyCarId, ClientId, DealerId, CarNumber, ClientName, Cellphone, Gender, Status, AppointmentDate, totalprice, PayStatus, paydate, createdate, CreateUserId, updatedate, UpdateUserId, Contact, AppointmentType, Discription, Mails, CarId, CarName, CarBrand, CarLine, MainImageUrl, BuyDate, PayType, TradeCode, RefundCode, ConfirmRemark, FinishRemark, finishdate, tradefee, AppointmentEndDate, FaultReason, FaultImages, AppointmentTimeDetailId, PayTypeDetail, CouponCode, CouponDiscountFee) VALUES(?AppointmentCode, ?MyCarId, ?ClientId, ?DealerId, ?CarNumber, ?ClientName, ?Cellphone, ?Gender, ?Status, ?AppointmentDate, ?totalprice, ?PayStatus, ?paydate, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?Contact, ?AppointmentType, ?Discription, ?Mails, ?CarId, ?CarName, ?CarBrand, ?CarLine, ?MainImageUrl, ?BuyDate, ?PayType, ?TradeCode, ?RefundCode, ?ConfirmRemark, ?FinishRemark, ?finishdate, ?tradefee, ?AppointmentEndDate, ?FaultReason, ?FaultImages, ?AppointmentTimeDetailId, ?PayTypeDetail, ?CouponCode, ?CouponDiscountFee)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("AppointmentCode", this.AppointmentCode),
				 new MySqlParameter("MyCarId", this.MyCarId),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("CarNumber", this.CarNumber),
				 new MySqlParameter("ClientName", this.ClientName),
				 new MySqlParameter("Cellphone", this.Cellphone),
				 new MySqlParameter("Gender", this.Gender),
				 new MySqlParameter("Status", this.Status),
				 new MySqlParameter("AppointmentDate", this.AppointmentDate),
				 new MySqlParameter("totalprice", this.Totalprice),
				 new MySqlParameter("PayStatus", this.PayStatus),
				 new MySqlParameter("paydate", this.Paydate),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("Contact", this.Contact),
				 new MySqlParameter("AppointmentType", this.AppointmentType),
				 new MySqlParameter("Discription", this.Discription),
				 new MySqlParameter("Mails", this.Mails),
				 new MySqlParameter("CarId", this.CarId),
				 new MySqlParameter("CarName", this.CarName),
				 new MySqlParameter("CarBrand", this.CarBrand),
				 new MySqlParameter("CarLine", this.CarLine),
				 new MySqlParameter("MainImageUrl", this.MainImageUrl),
				 new MySqlParameter("BuyDate", this.BuyDate),
				 new MySqlParameter("PayType", this.PayType),
				 new MySqlParameter("TradeCode", this.TradeCode),
				 new MySqlParameter("RefundCode", this.RefundCode),
				 new MySqlParameter("ConfirmRemark", this.ConfirmRemark),
				 new MySqlParameter("FinishRemark", this.FinishRemark),
				 new MySqlParameter("finishdate", this.Finishdate),
				 new MySqlParameter("tradefee", this.Tradefee),
				 new MySqlParameter("AppointmentEndDate", this.AppointmentEndDate),
				 new MySqlParameter("FaultReason", this.FaultReason),
				 new MySqlParameter("FaultImages", this.FaultImages),
				 new MySqlParameter("AppointmentTimeDetailId", this.AppointmentTimeDetailId),
				 new MySqlParameter("PayTypeDetail", this.PayTypeDetail),
				 new MySqlParameter("CouponCode", this.CouponCode),
				 new MySqlParameter("CouponDiscountFee", this.CouponDiscountFee)
			};

			string sql = "UPDATE o_appointment SET AppointmentCode = ?AppointmentCode, MyCarId = ?MyCarId, ClientId = ?ClientId, DealerId = ?DealerId, CarNumber = ?CarNumber, ClientName = ?ClientName, Cellphone = ?Cellphone, Gender = ?Gender, Status = ?Status, AppointmentDate = ?AppointmentDate, totalprice = ?totalprice, PayStatus = ?PayStatus, paydate = ?paydate, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, Contact = ?Contact, AppointmentType = ?AppointmentType, Discription = ?Discription, Mails = ?Mails, CarId = ?CarId, CarName = ?CarName, CarBrand = ?CarBrand, CarLine = ?CarLine, MainImageUrl = ?MainImageUrl, BuyDate = ?BuyDate, PayType = ?PayType, TradeCode = ?TradeCode, RefundCode = ?RefundCode, ConfirmRemark = ?ConfirmRemark, FinishRemark = ?FinishRemark, finishdate = ?finishdate, tradefee = ?tradefee, AppointmentEndDate = ?AppointmentEndDate, FaultReason = ?FaultReason, FaultImages = ?FaultImages, AppointmentTimeDetailId = ?AppointmentTimeDetailId, PayTypeDetail = ?PayTypeDetail, CouponCode = ?CouponCode, CouponDiscountFee = ?CouponDiscountFee WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM o_appointment WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static OAppointment GetById(int id)
        {
            string sql = string.Format("SELECT * FROM o_appointment WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<OAppointment> list = new DatatableFill<OAppointment>().FillModel(table);
            //List<OAppointment> list = Mapper.DynamicMap<IDataReader, List<OAppointment>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<OAppointment> GetList()
        {
            string sql = "SELECT * FROM o_appointment";
            DataTable table = DBHelper.GetDateTable(sql);
			List<OAppointment> list = new DatatableFill<OAppointment>().FillModel(table);
            //List<OAppointment> list = Mapper.DynamicMap<IDataReader, List<OAppointment>>(table.CreateDataReader());
            return list;

        }

		public static List<OAppointment> Find(string where)
        {
            string sql = string.Format("SELECT * FROM o_appointment WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<OAppointment>().FillModel(table);
        }

        public static List<OAppointment> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM o_appointment WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<OAppointment> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<OAppointment> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class OAppointmentcomment
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public long CommentId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string AppointmentCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int AppointmentType { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CommentContent { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CommetScore { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long ReplyCommentId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int PlatformScore { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ServiceScore { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("CommentId", this.CommentId),
				 new MySqlParameter("AppointmentCode", this.AppointmentCode),
				 new MySqlParameter("AppointmentType", this.AppointmentType),
				 new MySqlParameter("CommentContent", this.CommentContent),
				 new MySqlParameter("CommetScore", this.CommetScore),
				 new MySqlParameter("ReplyCommentId", this.ReplyCommentId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("PlatformScore", this.PlatformScore),
				 new MySqlParameter("ServiceScore", this.ServiceScore)
			};

			string sql = "INSERT INTO o_appointmentcomment(CommentId, AppointmentCode, AppointmentType, CommentContent, CommetScore, ReplyCommentId, createdate, CreateUserId, updatedate, UpdateUserId, PlatformScore, ServiceScore) VALUES(?CommentId, ?AppointmentCode, ?AppointmentType, ?CommentContent, ?CommetScore, ?ReplyCommentId, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?PlatformScore, ?ServiceScore)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("CommentId", this.CommentId),
				 new MySqlParameter("AppointmentCode", this.AppointmentCode),
				 new MySqlParameter("AppointmentType", this.AppointmentType),
				 new MySqlParameter("CommentContent", this.CommentContent),
				 new MySqlParameter("CommetScore", this.CommetScore),
				 new MySqlParameter("ReplyCommentId", this.ReplyCommentId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("PlatformScore", this.PlatformScore),
				 new MySqlParameter("ServiceScore", this.ServiceScore)
			};

			string sql = "UPDATE o_appointmentcomment SET CommentId = ?CommentId, AppointmentCode = ?AppointmentCode, AppointmentType = ?AppointmentType, CommentContent = ?CommentContent, CommetScore = ?CommetScore, ReplyCommentId = ?ReplyCommentId, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, PlatformScore = ?PlatformScore, ServiceScore = ?ServiceScore WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM o_appointmentcomment WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static OAppointmentcomment GetById(int id)
        {
            string sql = string.Format("SELECT * FROM o_appointmentcomment WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<OAppointmentcomment> list = new DatatableFill<OAppointmentcomment>().FillModel(table);
            //List<OAppointmentcomment> list = Mapper.DynamicMap<IDataReader, List<OAppointmentcomment>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<OAppointmentcomment> GetList()
        {
            string sql = "SELECT * FROM o_appointmentcomment";
            DataTable table = DBHelper.GetDateTable(sql);
			List<OAppointmentcomment> list = new DatatableFill<OAppointmentcomment>().FillModel(table);
            //List<OAppointmentcomment> list = Mapper.DynamicMap<IDataReader, List<OAppointmentcomment>>(table.CreateDataReader());
            return list;

        }

		public static List<OAppointmentcomment> Find(string where)
        {
            string sql = string.Format("SELECT * FROM o_appointmentcomment WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<OAppointmentcomment>().FillModel(table);
        }

        public static List<OAppointmentcomment> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM o_appointmentcomment WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<OAppointmentcomment> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<OAppointmentcomment> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class OAppointmentdetail
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int AppointmentDetailId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string AppointmentCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CarMaintaiDetailId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal Price { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal Hourlypay { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string MaintainItemName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal DiscountHourlyPay { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal Discount { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("AppointmentDetailId", this.AppointmentDetailId),
				 new MySqlParameter("AppointmentCode", this.AppointmentCode),
				 new MySqlParameter("CarMaintaiDetailId", this.CarMaintaiDetailId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("price", this.Price),
				 new MySqlParameter("hourlypay", this.Hourlypay),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("MaintainItemName", this.MaintainItemName),
				 new MySqlParameter("DiscountHourlyPay", this.DiscountHourlyPay),
				 new MySqlParameter("Discount", this.Discount)
			};

			string sql = "INSERT INTO o_appointmentdetail(AppointmentDetailId, AppointmentCode, CarMaintaiDetailId, DealerId, price, hourlypay, createdate, CreateUserId, updatedate, UpdateUserId, MaintainItemName, DiscountHourlyPay, Discount) VALUES(?AppointmentDetailId, ?AppointmentCode, ?CarMaintaiDetailId, ?DealerId, ?price, ?hourlypay, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?MaintainItemName, ?DiscountHourlyPay, ?Discount)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("AppointmentDetailId", this.AppointmentDetailId),
				 new MySqlParameter("AppointmentCode", this.AppointmentCode),
				 new MySqlParameter("CarMaintaiDetailId", this.CarMaintaiDetailId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("price", this.Price),
				 new MySqlParameter("hourlypay", this.Hourlypay),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("MaintainItemName", this.MaintainItemName),
				 new MySqlParameter("DiscountHourlyPay", this.DiscountHourlyPay),
				 new MySqlParameter("Discount", this.Discount)
			};

			string sql = "UPDATE o_appointmentdetail SET AppointmentDetailId = ?AppointmentDetailId, AppointmentCode = ?AppointmentCode, CarMaintaiDetailId = ?CarMaintaiDetailId, DealerId = ?DealerId, price = ?price, hourlypay = ?hourlypay, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, MaintainItemName = ?MaintainItemName, DiscountHourlyPay = ?DiscountHourlyPay, Discount = ?Discount WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM o_appointmentdetail WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static OAppointmentdetail GetById(int id)
        {
            string sql = string.Format("SELECT * FROM o_appointmentdetail WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<OAppointmentdetail> list = new DatatableFill<OAppointmentdetail>().FillModel(table);
            //List<OAppointmentdetail> list = Mapper.DynamicMap<IDataReader, List<OAppointmentdetail>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<OAppointmentdetail> GetList()
        {
            string sql = "SELECT * FROM o_appointmentdetail";
            DataTable table = DBHelper.GetDateTable(sql);
			List<OAppointmentdetail> list = new DatatableFill<OAppointmentdetail>().FillModel(table);
            //List<OAppointmentdetail> list = Mapper.DynamicMap<IDataReader, List<OAppointmentdetail>>(table.CreateDataReader());
            return list;

        }

		public static List<OAppointmentdetail> Find(string where)
        {
            string sql = string.Format("SELECT * FROM o_appointmentdetail WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<OAppointmentdetail>().FillModel(table);
        }

        public static List<OAppointmentdetail> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM o_appointmentdetail WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<OAppointmentdetail> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<OAppointmentdetail> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class OAppointmentdrive
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public string AppointmentCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerCarId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CarId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CarLineId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CarBrandId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string DealerName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CarName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CarLineName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CarBrandName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string MainImageUrl { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CarPrice { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int EarnestMoney { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long ClientId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ClientName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Cellphone { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime AppointmentDate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int PayStatus { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Paydate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Discription { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Status { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CarNumber { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Sex { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Gender { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ProvinceId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProvinceName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CityId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CityName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int AppointmentDriveType { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("AppointmentCode", this.AppointmentCode),
				 new MySqlParameter("DealerCarId", this.DealerCarId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("CarId", this.CarId),
				 new MySqlParameter("CarLineId", this.CarLineId),
				 new MySqlParameter("CarBrandId", this.CarBrandId),
				 new MySqlParameter("DealerName", this.DealerName),
				 new MySqlParameter("CarName", this.CarName),
				 new MySqlParameter("CarLineName", this.CarLineName),
				 new MySqlParameter("CarBrandName", this.CarBrandName),
				 new MySqlParameter("MainImageUrl", this.MainImageUrl),
				 new MySqlParameter("CarPrice", this.CarPrice),
				 new MySqlParameter("EarnestMoney", this.EarnestMoney),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("ClientName", this.ClientName),
				 new MySqlParameter("Cellphone", this.Cellphone),
				 new MySqlParameter("AppointmentDate", this.AppointmentDate),
				 new MySqlParameter("PayStatus", this.PayStatus),
				 new MySqlParameter("paydate", this.Paydate),
				 new MySqlParameter("Discription", this.Discription),
				 new MySqlParameter("Status", this.Status),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("CarNumber", this.CarNumber),
				 new MySqlParameter("sex", this.Sex),
				 new MySqlParameter("Gender", this.Gender),
				 new MySqlParameter("ProvinceId", this.ProvinceId),
				 new MySqlParameter("ProvinceName", this.ProvinceName),
				 new MySqlParameter("CityId", this.CityId),
				 new MySqlParameter("CityName", this.CityName),
				 new MySqlParameter("AppointmentDriveType", this.AppointmentDriveType)
			};

			string sql = "INSERT INTO o_appointmentdrive(AppointmentCode, DealerCarId, DealerId, CarId, CarLineId, CarBrandId, DealerName, CarName, CarLineName, CarBrandName, MainImageUrl, CarPrice, EarnestMoney, ClientId, ClientName, Cellphone, AppointmentDate, PayStatus, paydate, Discription, Status, createdate, CreateUserId, updatedate, UpdateUserId, CarNumber, sex, Gender, ProvinceId, ProvinceName, CityId, CityName, AppointmentDriveType) VALUES(?AppointmentCode, ?DealerCarId, ?DealerId, ?CarId, ?CarLineId, ?CarBrandId, ?DealerName, ?CarName, ?CarLineName, ?CarBrandName, ?MainImageUrl, ?CarPrice, ?EarnestMoney, ?ClientId, ?ClientName, ?Cellphone, ?AppointmentDate, ?PayStatus, ?paydate, ?Discription, ?Status, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?CarNumber, ?sex, ?Gender, ?ProvinceId, ?ProvinceName, ?CityId, ?CityName, ?AppointmentDriveType)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("AppointmentCode", this.AppointmentCode),
				 new MySqlParameter("DealerCarId", this.DealerCarId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("CarId", this.CarId),
				 new MySqlParameter("CarLineId", this.CarLineId),
				 new MySqlParameter("CarBrandId", this.CarBrandId),
				 new MySqlParameter("DealerName", this.DealerName),
				 new MySqlParameter("CarName", this.CarName),
				 new MySqlParameter("CarLineName", this.CarLineName),
				 new MySqlParameter("CarBrandName", this.CarBrandName),
				 new MySqlParameter("MainImageUrl", this.MainImageUrl),
				 new MySqlParameter("CarPrice", this.CarPrice),
				 new MySqlParameter("EarnestMoney", this.EarnestMoney),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("ClientName", this.ClientName),
				 new MySqlParameter("Cellphone", this.Cellphone),
				 new MySqlParameter("AppointmentDate", this.AppointmentDate),
				 new MySqlParameter("PayStatus", this.PayStatus),
				 new MySqlParameter("paydate", this.Paydate),
				 new MySqlParameter("Discription", this.Discription),
				 new MySqlParameter("Status", this.Status),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("CarNumber", this.CarNumber),
				 new MySqlParameter("sex", this.Sex),
				 new MySqlParameter("Gender", this.Gender),
				 new MySqlParameter("ProvinceId", this.ProvinceId),
				 new MySqlParameter("ProvinceName", this.ProvinceName),
				 new MySqlParameter("CityId", this.CityId),
				 new MySqlParameter("CityName", this.CityName),
				 new MySqlParameter("AppointmentDriveType", this.AppointmentDriveType)
			};

			string sql = "UPDATE o_appointmentdrive SET AppointmentCode = ?AppointmentCode, DealerCarId = ?DealerCarId, DealerId = ?DealerId, CarId = ?CarId, CarLineId = ?CarLineId, CarBrandId = ?CarBrandId, DealerName = ?DealerName, CarName = ?CarName, CarLineName = ?CarLineName, CarBrandName = ?CarBrandName, MainImageUrl = ?MainImageUrl, CarPrice = ?CarPrice, EarnestMoney = ?EarnestMoney, ClientId = ?ClientId, ClientName = ?ClientName, Cellphone = ?Cellphone, AppointmentDate = ?AppointmentDate, PayStatus = ?PayStatus, paydate = ?paydate, Discription = ?Discription, Status = ?Status, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, CarNumber = ?CarNumber, sex = ?sex, Gender = ?Gender, ProvinceId = ?ProvinceId, ProvinceName = ?ProvinceName, CityId = ?CityId, CityName = ?CityName, AppointmentDriveType = ?AppointmentDriveType WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM o_appointmentdrive WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static OAppointmentdrive GetById(int id)
        {
            string sql = string.Format("SELECT * FROM o_appointmentdrive WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<OAppointmentdrive> list = new DatatableFill<OAppointmentdrive>().FillModel(table);
            //List<OAppointmentdrive> list = Mapper.DynamicMap<IDataReader, List<OAppointmentdrive>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<OAppointmentdrive> GetList()
        {
            string sql = "SELECT * FROM o_appointmentdrive";
            DataTable table = DBHelper.GetDateTable(sql);
			List<OAppointmentdrive> list = new DatatableFill<OAppointmentdrive>().FillModel(table);
            //List<OAppointmentdrive> list = Mapper.DynamicMap<IDataReader, List<OAppointmentdrive>>(table.CreateDataReader());
            return list;

        }

		public static List<OAppointmentdrive> Find(string where)
        {
            string sql = string.Format("SELECT * FROM o_appointmentdrive WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<OAppointmentdrive>().FillModel(table);
        }

        public static List<OAppointmentdrive> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM o_appointmentdrive WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<OAppointmentdrive> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<OAppointmentdrive> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class OAppointmenttrack
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int TrackId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ActionType { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string AppointmentCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("TrackId", this.TrackId),
				 new MySqlParameter("ActionType", this.ActionType),
				 new MySqlParameter("AppointmentCode", this.AppointmentCode),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO o_appointmenttrack(TrackId, ActionType, AppointmentCode, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?TrackId, ?ActionType, ?AppointmentCode, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("TrackId", this.TrackId),
				 new MySqlParameter("ActionType", this.ActionType),
				 new MySqlParameter("AppointmentCode", this.AppointmentCode),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE o_appointmenttrack SET TrackId = ?TrackId, ActionType = ?ActionType, AppointmentCode = ?AppointmentCode, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM o_appointmenttrack WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static OAppointmenttrack GetById(int id)
        {
            string sql = string.Format("SELECT * FROM o_appointmenttrack WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<OAppointmenttrack> list = new DatatableFill<OAppointmenttrack>().FillModel(table);
            //List<OAppointmenttrack> list = Mapper.DynamicMap<IDataReader, List<OAppointmenttrack>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<OAppointmenttrack> GetList()
        {
            string sql = "SELECT * FROM o_appointmenttrack";
            DataTable table = DBHelper.GetDateTable(sql);
			List<OAppointmenttrack> list = new DatatableFill<OAppointmenttrack>().FillModel(table);
            //List<OAppointmenttrack> list = Mapper.DynamicMap<IDataReader, List<OAppointmenttrack>>(table.CreateDataReader());
            return list;

        }

		public static List<OAppointmenttrack> Find(string where)
        {
            string sql = string.Format("SELECT * FROM o_appointmenttrack WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<OAppointmenttrack>().FillModel(table);
        }

        public static List<OAppointmenttrack> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM o_appointmenttrack WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<OAppointmenttrack> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<OAppointmenttrack> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class OOrder
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public string OrderCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long ClientId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal TotalPrice { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int PayStatus { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Paydate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int OrderStatus { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int PayType { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string PayCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int OrderType { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ReceiverName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Cellphone { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ProvinceId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProvinceName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CityId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CityName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DistrictId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string DistrictName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Address { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Postcode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string InvoiceTitle { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ClientRemark { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime SendProductDate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string TradeCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string RefundCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal TradeFee { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int PayTypeDetail { get; set; }
		/// <summary>
        /// 我的优惠券id
        /// </summary>
		public string CouponCode { get; set; }
		/// <summary>
        /// 优惠券优惠金额
        /// </summary>
		public decimal CouponDiscountFee { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("OrderCode", this.OrderCode),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("TotalPrice", this.TotalPrice),
				 new MySqlParameter("PayStatus", this.PayStatus),
				 new MySqlParameter("paydate", this.Paydate),
				 new MySqlParameter("OrderStatus", this.OrderStatus),
				 new MySqlParameter("PayType", this.PayType),
				 new MySqlParameter("PayCode", this.PayCode),
				 new MySqlParameter("OrderType", this.OrderType),
				 new MySqlParameter("ReceiverName", this.ReceiverName),
				 new MySqlParameter("Cellphone", this.Cellphone),
				 new MySqlParameter("ProvinceId", this.ProvinceId),
				 new MySqlParameter("ProvinceName", this.ProvinceName),
				 new MySqlParameter("CityId", this.CityId),
				 new MySqlParameter("CityName", this.CityName),
				 new MySqlParameter("DistrictId", this.DistrictId),
				 new MySqlParameter("DistrictName", this.DistrictName),
				 new MySqlParameter("Address", this.Address),
				 new MySqlParameter("Postcode", this.Postcode),
				 new MySqlParameter("InvoiceTitle", this.InvoiceTitle),
				 new MySqlParameter("ClientRemark", this.ClientRemark),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("SendProductDate", this.SendProductDate),
				 new MySqlParameter("TradeCode", this.TradeCode),
				 new MySqlParameter("RefundCode", this.RefundCode),
				 new MySqlParameter("TradeFee", this.TradeFee),
				 new MySqlParameter("PayTypeDetail", this.PayTypeDetail),
				 new MySqlParameter("CouponCode", this.CouponCode),
				 new MySqlParameter("CouponDiscountFee", this.CouponDiscountFee)
			};

			string sql = "INSERT INTO o_order(OrderCode, ClientId, DealerId, TotalPrice, PayStatus, paydate, OrderStatus, PayType, PayCode, OrderType, ReceiverName, Cellphone, ProvinceId, ProvinceName, CityId, CityName, DistrictId, DistrictName, Address, Postcode, InvoiceTitle, ClientRemark, createdate, CreateUserId, updatedate, UpdateUserId, SendProductDate, TradeCode, RefundCode, TradeFee, PayTypeDetail, CouponCode, CouponDiscountFee) VALUES(?OrderCode, ?ClientId, ?DealerId, ?TotalPrice, ?PayStatus, ?paydate, ?OrderStatus, ?PayType, ?PayCode, ?OrderType, ?ReceiverName, ?Cellphone, ?ProvinceId, ?ProvinceName, ?CityId, ?CityName, ?DistrictId, ?DistrictName, ?Address, ?Postcode, ?InvoiceTitle, ?ClientRemark, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?SendProductDate, ?TradeCode, ?RefundCode, ?TradeFee, ?PayTypeDetail, ?CouponCode, ?CouponDiscountFee)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("OrderCode", this.OrderCode),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("TotalPrice", this.TotalPrice),
				 new MySqlParameter("PayStatus", this.PayStatus),
				 new MySqlParameter("paydate", this.Paydate),
				 new MySqlParameter("OrderStatus", this.OrderStatus),
				 new MySqlParameter("PayType", this.PayType),
				 new MySqlParameter("PayCode", this.PayCode),
				 new MySqlParameter("OrderType", this.OrderType),
				 new MySqlParameter("ReceiverName", this.ReceiverName),
				 new MySqlParameter("Cellphone", this.Cellphone),
				 new MySqlParameter("ProvinceId", this.ProvinceId),
				 new MySqlParameter("ProvinceName", this.ProvinceName),
				 new MySqlParameter("CityId", this.CityId),
				 new MySqlParameter("CityName", this.CityName),
				 new MySqlParameter("DistrictId", this.DistrictId),
				 new MySqlParameter("DistrictName", this.DistrictName),
				 new MySqlParameter("Address", this.Address),
				 new MySqlParameter("Postcode", this.Postcode),
				 new MySqlParameter("InvoiceTitle", this.InvoiceTitle),
				 new MySqlParameter("ClientRemark", this.ClientRemark),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("SendProductDate", this.SendProductDate),
				 new MySqlParameter("TradeCode", this.TradeCode),
				 new MySqlParameter("RefundCode", this.RefundCode),
				 new MySqlParameter("TradeFee", this.TradeFee),
				 new MySqlParameter("PayTypeDetail", this.PayTypeDetail),
				 new MySqlParameter("CouponCode", this.CouponCode),
				 new MySqlParameter("CouponDiscountFee", this.CouponDiscountFee)
			};

			string sql = "UPDATE o_order SET OrderCode = ?OrderCode, ClientId = ?ClientId, DealerId = ?DealerId, TotalPrice = ?TotalPrice, PayStatus = ?PayStatus, paydate = ?paydate, OrderStatus = ?OrderStatus, PayType = ?PayType, PayCode = ?PayCode, OrderType = ?OrderType, ReceiverName = ?ReceiverName, Cellphone = ?Cellphone, ProvinceId = ?ProvinceId, ProvinceName = ?ProvinceName, CityId = ?CityId, CityName = ?CityName, DistrictId = ?DistrictId, DistrictName = ?DistrictName, Address = ?Address, Postcode = ?Postcode, InvoiceTitle = ?InvoiceTitle, ClientRemark = ?ClientRemark, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, SendProductDate = ?SendProductDate, TradeCode = ?TradeCode, RefundCode = ?RefundCode, TradeFee = ?TradeFee, PayTypeDetail = ?PayTypeDetail, CouponCode = ?CouponCode, CouponDiscountFee = ?CouponDiscountFee WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM o_order WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static OOrder GetById(int id)
        {
            string sql = string.Format("SELECT * FROM o_order WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrder> list = new DatatableFill<OOrder>().FillModel(table);
            //List<OOrder> list = Mapper.DynamicMap<IDataReader, List<OOrder>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<OOrder> GetList()
        {
            string sql = "SELECT * FROM o_order";
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrder> list = new DatatableFill<OOrder>().FillModel(table);
            //List<OOrder> list = Mapper.DynamicMap<IDataReader, List<OOrder>>(table.CreateDataReader());
            return list;

        }

		public static List<OOrder> Find(string where)
        {
            string sql = string.Format("SELECT * FROM o_order WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<OOrder>().FillModel(table);
        }

        public static List<OOrder> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM o_order WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<OOrder> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<OOrder> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class OOrdercardetail
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int OrderCarDetailId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string OrderCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long DealerCarId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal Carprice { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal BargainPrice { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int TotalCount { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal TotalCarPrice { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal TotalBargainPrice { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CarId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProductName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProductSubName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string PickCarEndDate { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("OrderCarDetailId", this.OrderCarDetailId),
				 new MySqlParameter("OrderCode", this.OrderCode),
				 new MySqlParameter("DealerCarId", this.DealerCarId),
				 new MySqlParameter("carprice", this.Carprice),
				 new MySqlParameter("BargainPrice", this.BargainPrice),
				 new MySqlParameter("TotalCount", this.TotalCount),
				 new MySqlParameter("TotalCarPrice", this.TotalCarPrice),
				 new MySqlParameter("TotalBargainPrice", this.TotalBargainPrice),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("CarId", this.CarId),
				 new MySqlParameter("ProductName", this.ProductName),
				 new MySqlParameter("ProductSubName", this.ProductSubName),
				 new MySqlParameter("PickCarEndDate", this.PickCarEndDate)
			};

			string sql = "INSERT INTO o_ordercardetail(OrderCarDetailId, OrderCode, DealerCarId, carprice, BargainPrice, TotalCount, TotalCarPrice, TotalBargainPrice, createdate, CreateUserId, updatedate, UpdateUserId, CarId, ProductName, ProductSubName, PickCarEndDate) VALUES(?OrderCarDetailId, ?OrderCode, ?DealerCarId, ?carprice, ?BargainPrice, ?TotalCount, ?TotalCarPrice, ?TotalBargainPrice, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?CarId, ?ProductName, ?ProductSubName, ?PickCarEndDate)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("OrderCarDetailId", this.OrderCarDetailId),
				 new MySqlParameter("OrderCode", this.OrderCode),
				 new MySqlParameter("DealerCarId", this.DealerCarId),
				 new MySqlParameter("carprice", this.Carprice),
				 new MySqlParameter("BargainPrice", this.BargainPrice),
				 new MySqlParameter("TotalCount", this.TotalCount),
				 new MySqlParameter("TotalCarPrice", this.TotalCarPrice),
				 new MySqlParameter("TotalBargainPrice", this.TotalBargainPrice),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("CarId", this.CarId),
				 new MySqlParameter("ProductName", this.ProductName),
				 new MySqlParameter("ProductSubName", this.ProductSubName),
				 new MySqlParameter("PickCarEndDate", this.PickCarEndDate)
			};

			string sql = "UPDATE o_ordercardetail SET OrderCarDetailId = ?OrderCarDetailId, OrderCode = ?OrderCode, DealerCarId = ?DealerCarId, carprice = ?carprice, BargainPrice = ?BargainPrice, TotalCount = ?TotalCount, TotalCarPrice = ?TotalCarPrice, TotalBargainPrice = ?TotalBargainPrice, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, CarId = ?CarId, ProductName = ?ProductName, ProductSubName = ?ProductSubName, PickCarEndDate = ?PickCarEndDate WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM o_ordercardetail WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static OOrdercardetail GetById(int id)
        {
            string sql = string.Format("SELECT * FROM o_ordercardetail WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrdercardetail> list = new DatatableFill<OOrdercardetail>().FillModel(table);
            //List<OOrdercardetail> list = Mapper.DynamicMap<IDataReader, List<OOrdercardetail>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<OOrdercardetail> GetList()
        {
            string sql = "SELECT * FROM o_ordercardetail";
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrdercardetail> list = new DatatableFill<OOrdercardetail>().FillModel(table);
            //List<OOrdercardetail> list = Mapper.DynamicMap<IDataReader, List<OOrdercardetail>>(table.CreateDataReader());
            return list;

        }

		public static List<OOrdercardetail> Find(string where)
        {
            string sql = string.Format("SELECT * FROM o_ordercardetail WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<OOrdercardetail>().FillModel(table);
        }

        public static List<OOrdercardetail> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM o_ordercardetail WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<OOrdercardetail> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<OOrdercardetail> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class OOrdercart
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public long ProductId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long ClientId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Amount { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("Amount", this.Amount),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("DealerId", this.DealerId)
			};

			string sql = "INSERT INTO o_ordercart(ProductId, ClientId, Amount, createdate, CreateUserId, updatedate, UpdateUserId, DealerId) VALUES(?ProductId, ?ClientId, ?Amount, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?DealerId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("Amount", this.Amount),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("DealerId", this.DealerId)
			};

			string sql = "UPDATE o_ordercart SET ProductId = ?ProductId, ClientId = ?ClientId, Amount = ?Amount, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, DealerId = ?DealerId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM o_ordercart WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static OOrdercart GetById(int id)
        {
            string sql = string.Format("SELECT * FROM o_ordercart WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrdercart> list = new DatatableFill<OOrdercart>().FillModel(table);
            //List<OOrdercart> list = Mapper.DynamicMap<IDataReader, List<OOrdercart>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<OOrdercart> GetList()
        {
            string sql = "SELECT * FROM o_ordercart";
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrdercart> list = new DatatableFill<OOrdercart>().FillModel(table);
            //List<OOrdercart> list = Mapper.DynamicMap<IDataReader, List<OOrdercart>>(table.CreateDataReader());
            return list;

        }

		public static List<OOrdercart> Find(string where)
        {
            string sql = string.Format("SELECT * FROM o_ordercart WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<OOrdercart>().FillModel(table);
        }

        public static List<OOrdercart> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM o_ordercart WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<OOrdercart> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<OOrdercart> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class OOrderexpress
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int OrderExpressId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string OrderCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ExpressId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ExpressCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("OrderExpressId", this.OrderExpressId),
				 new MySqlParameter("OrderCode", this.OrderCode),
				 new MySqlParameter("ExpressId", this.ExpressId),
				 new MySqlParameter("ExpressCode", this.ExpressCode),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO o_orderexpress(OrderExpressId, OrderCode, ExpressId, ExpressCode, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?OrderExpressId, ?OrderCode, ?ExpressId, ?ExpressCode, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("OrderExpressId", this.OrderExpressId),
				 new MySqlParameter("OrderCode", this.OrderCode),
				 new MySqlParameter("ExpressId", this.ExpressId),
				 new MySqlParameter("ExpressCode", this.ExpressCode),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE o_orderexpress SET OrderExpressId = ?OrderExpressId, OrderCode = ?OrderCode, ExpressId = ?ExpressId, ExpressCode = ?ExpressCode, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM o_orderexpress WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static OOrderexpress GetById(int id)
        {
            string sql = string.Format("SELECT * FROM o_orderexpress WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrderexpress> list = new DatatableFill<OOrderexpress>().FillModel(table);
            //List<OOrderexpress> list = Mapper.DynamicMap<IDataReader, List<OOrderexpress>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<OOrderexpress> GetList()
        {
            string sql = "SELECT * FROM o_orderexpress";
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrderexpress> list = new DatatableFill<OOrderexpress>().FillModel(table);
            //List<OOrderexpress> list = Mapper.DynamicMap<IDataReader, List<OOrderexpress>>(table.CreateDataReader());
            return list;

        }

		public static List<OOrderexpress> Find(string where)
        {
            string sql = string.Format("SELECT * FROM o_orderexpress WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<OOrderexpress>().FillModel(table);
        }

        public static List<OOrderexpress> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM o_orderexpress WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<OOrderexpress> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<OOrderexpress> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class OOrdernumber
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int Id { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string OrderNo { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string OrderName { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("orderNo", this.OrderNo),
				 new MySqlParameter("orderName", this.OrderName)
			};

			string sql = "INSERT INTO o_ordernumber(orderNo, orderName) VALUES(?orderNo, ?orderName)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("id", this.Id),
				 new MySqlParameter("orderNo", this.OrderNo),
				 new MySqlParameter("orderName", this.OrderName)
			};

			string sql = "UPDATE o_ordernumber SET orderNo = ?orderNo, orderName = ?orderName WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM o_ordernumber WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static OOrdernumber GetById(int id)
        {
            string sql = string.Format("SELECT * FROM o_ordernumber WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrdernumber> list = new DatatableFill<OOrdernumber>().FillModel(table);
            //List<OOrdernumber> list = Mapper.DynamicMap<IDataReader, List<OOrdernumber>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<OOrdernumber> GetList()
        {
            string sql = "SELECT * FROM o_ordernumber";
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrdernumber> list = new DatatableFill<OOrdernumber>().FillModel(table);
            //List<OOrdernumber> list = Mapper.DynamicMap<IDataReader, List<OOrdernumber>>(table.CreateDataReader());
            return list;

        }

		public static List<OOrdernumber> Find(string where)
        {
            string sql = string.Format("SELECT * FROM o_ordernumber WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<OOrdernumber>().FillModel(table);
        }

        public static List<OOrdernumber> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM o_ordernumber WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<OOrdernumber> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<OOrdernumber> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class OOrderproductdetail
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int OrderProducDetailtId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string OrderCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long ProductId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal Price { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int TotalCount { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal TotalPrice { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int OrderStatus { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProductRemark { get; set; }
		/// <summary>
        /// 来自广告Id
        /// </summary>
		public string AdPlanDetailId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("OrderProducDetailtId", this.OrderProducDetailtId),
				 new MySqlParameter("OrderCode", this.OrderCode),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("Price", this.Price),
				 new MySqlParameter("TotalCount", this.TotalCount),
				 new MySqlParameter("TotalPrice", this.TotalPrice),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("OrderStatus", this.OrderStatus),
				 new MySqlParameter("ProductRemark", this.ProductRemark),
				 new MySqlParameter("AdPlanDetailId", this.AdPlanDetailId)
			};

			string sql = "INSERT INTO o_orderproductdetail(OrderProducDetailtId, OrderCode, ProductId, Price, TotalCount, TotalPrice, createdate, CreateUserId, updatedate, UpdateUserId, OrderStatus, ProductRemark, AdPlanDetailId) VALUES(?OrderProducDetailtId, ?OrderCode, ?ProductId, ?Price, ?TotalCount, ?TotalPrice, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?OrderStatus, ?ProductRemark, ?AdPlanDetailId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("OrderProducDetailtId", this.OrderProducDetailtId),
				 new MySqlParameter("OrderCode", this.OrderCode),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("Price", this.Price),
				 new MySqlParameter("TotalCount", this.TotalCount),
				 new MySqlParameter("TotalPrice", this.TotalPrice),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("OrderStatus", this.OrderStatus),
				 new MySqlParameter("ProductRemark", this.ProductRemark),
				 new MySqlParameter("AdPlanDetailId", this.AdPlanDetailId)
			};

			string sql = "UPDATE o_orderproductdetail SET OrderProducDetailtId = ?OrderProducDetailtId, OrderCode = ?OrderCode, ProductId = ?ProductId, Price = ?Price, TotalCount = ?TotalCount, TotalPrice = ?TotalPrice, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, OrderStatus = ?OrderStatus, ProductRemark = ?ProductRemark, AdPlanDetailId = ?AdPlanDetailId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM o_orderproductdetail WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static OOrderproductdetail GetById(int id)
        {
            string sql = string.Format("SELECT * FROM o_orderproductdetail WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrderproductdetail> list = new DatatableFill<OOrderproductdetail>().FillModel(table);
            //List<OOrderproductdetail> list = Mapper.DynamicMap<IDataReader, List<OOrderproductdetail>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<OOrderproductdetail> GetList()
        {
            string sql = "SELECT * FROM o_orderproductdetail";
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrderproductdetail> list = new DatatableFill<OOrderproductdetail>().FillModel(table);
            //List<OOrderproductdetail> list = Mapper.DynamicMap<IDataReader, List<OOrderproductdetail>>(table.CreateDataReader());
            return list;

        }

		public static List<OOrderproductdetail> Find(string where)
        {
            string sql = string.Format("SELECT * FROM o_orderproductdetail WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<OOrderproductdetail>().FillModel(table);
        }

        public static List<OOrderproductdetail> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM o_orderproductdetail WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<OOrderproductdetail> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<OOrderproductdetail> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class OOrdertrack
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public long TrackId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ActionType { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string OrderCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("TrackId", this.TrackId),
				 new MySqlParameter("ActionType", this.ActionType),
				 new MySqlParameter("OrderCode", this.OrderCode),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO o_ordertrack(TrackId, ActionType, OrderCode, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?TrackId, ?ActionType, ?OrderCode, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("TrackId", this.TrackId),
				 new MySqlParameter("ActionType", this.ActionType),
				 new MySqlParameter("OrderCode", this.OrderCode),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE o_ordertrack SET TrackId = ?TrackId, ActionType = ?ActionType, OrderCode = ?OrderCode, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM o_ordertrack WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static OOrdertrack GetById(int id)
        {
            string sql = string.Format("SELECT * FROM o_ordertrack WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrdertrack> list = new DatatableFill<OOrdertrack>().FillModel(table);
            //List<OOrdertrack> list = Mapper.DynamicMap<IDataReader, List<OOrdertrack>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<OOrdertrack> GetList()
        {
            string sql = "SELECT * FROM o_ordertrack";
            DataTable table = DBHelper.GetDateTable(sql);
			List<OOrdertrack> list = new DatatableFill<OOrdertrack>().FillModel(table);
            //List<OOrdertrack> list = Mapper.DynamicMap<IDataReader, List<OOrdertrack>>(table.CreateDataReader());
            return list;

        }

		public static List<OOrdertrack> Find(string where)
        {
            string sql = string.Format("SELECT * FROM o_ordertrack WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<OOrdertrack>().FillModel(table);
        }

        public static List<OOrdertrack> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM o_ordertrack WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<OOrdertrack> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<OOrdertrack> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PBrowsehistories
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int RecordId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ClientId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ProductId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Times { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("RecordId", this.RecordId),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("Times", this.Times),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO p_browsehistories(RecordId, ClientId, ProductId, Times, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?RecordId, ?ClientId, ?ProductId, ?Times, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("RecordId", this.RecordId),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("Times", this.Times),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE p_browsehistories SET RecordId = ?RecordId, ClientId = ?ClientId, ProductId = ?ProductId, Times = ?Times, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_browsehistories WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PBrowsehistories GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_browsehistories WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PBrowsehistories> list = new DatatableFill<PBrowsehistories>().FillModel(table);
            //List<PBrowsehistories> list = Mapper.DynamicMap<IDataReader, List<PBrowsehistories>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PBrowsehistories> GetList()
        {
            string sql = "SELECT * FROM p_browsehistories";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PBrowsehistories> list = new DatatableFill<PBrowsehistories>().FillModel(table);
            //List<PBrowsehistories> list = Mapper.DynamicMap<IDataReader, List<PBrowsehistories>>(table.CreateDataReader());
            return list;

        }

		public static List<PBrowsehistories> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_browsehistories WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PBrowsehistories>().FillModel(table);
        }

        public static List<PBrowsehistories> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_browsehistories WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PBrowsehistories> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PBrowsehistories> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PCategory
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int CategoryId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CategoryName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ParentCategoryId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Level { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DisplaySeq { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsDelete { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsRecommend { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string WapImgUrl { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string AppImgUrl { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("CategoryId", this.CategoryId),
				 new MySqlParameter("CategoryName", this.CategoryName),
				 new MySqlParameter("ParentCategoryId", this.ParentCategoryId),
				 new MySqlParameter("Level", this.Level),
				 new MySqlParameter("DisplaySeq", this.DisplaySeq),
				 new MySqlParameter("IsDelete", this.IsDelete),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("IsRecommend", this.IsRecommend),
				 new MySqlParameter("WapImgUrl", this.WapImgUrl),
				 new MySqlParameter("AppImgUrl", this.AppImgUrl)
			};

			string sql = "INSERT INTO p_category(CategoryId, CategoryName, ParentCategoryId, Level, DisplaySeq, IsDelete, createdate, CreateUserId, updatedate, UpdateUserId, IsRecommend, WapImgUrl, AppImgUrl) VALUES(?CategoryId, ?CategoryName, ?ParentCategoryId, ?Level, ?DisplaySeq, ?IsDelete, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?IsRecommend, ?WapImgUrl, ?AppImgUrl)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("CategoryId", this.CategoryId),
				 new MySqlParameter("CategoryName", this.CategoryName),
				 new MySqlParameter("ParentCategoryId", this.ParentCategoryId),
				 new MySqlParameter("Level", this.Level),
				 new MySqlParameter("DisplaySeq", this.DisplaySeq),
				 new MySqlParameter("IsDelete", this.IsDelete),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("IsRecommend", this.IsRecommend),
				 new MySqlParameter("WapImgUrl", this.WapImgUrl),
				 new MySqlParameter("AppImgUrl", this.AppImgUrl)
			};

			string sql = "UPDATE p_category SET CategoryId = ?CategoryId, CategoryName = ?CategoryName, ParentCategoryId = ?ParentCategoryId, Level = ?Level, DisplaySeq = ?DisplaySeq, IsDelete = ?IsDelete, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, IsRecommend = ?IsRecommend, WapImgUrl = ?WapImgUrl, AppImgUrl = ?AppImgUrl WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_category WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PCategory GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_category WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PCategory> list = new DatatableFill<PCategory>().FillModel(table);
            //List<PCategory> list = Mapper.DynamicMap<IDataReader, List<PCategory>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PCategory> GetList()
        {
            string sql = "SELECT * FROM p_category";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PCategory> list = new DatatableFill<PCategory>().FillModel(table);
            //List<PCategory> list = Mapper.DynamicMap<IDataReader, List<PCategory>>(table.CreateDataReader());
            return list;

        }

		public static List<PCategory> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_category WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PCategory>().FillModel(table);
        }

        public static List<PCategory> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_category WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PCategory> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PCategory> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PDealercar
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public long DealerCarId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int BrandId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int LineId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CarId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal CarPrice { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal EarnestMoney { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsPublish { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Inventory { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Sales { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int TotalComments { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int TotalCommentsPositive { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int TotalCommentsModerate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int TotalCommentsNegative { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProductName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProductSubName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CarTypeId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProductRemark { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsDelete { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime PublishDateTime { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int SubBrandId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("DealerCarId", this.DealerCarId),
				 new MySqlParameter("BrandId", this.BrandId),
				 new MySqlParameter("LineId", this.LineId),
				 new MySqlParameter("CarId", this.CarId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("CarPrice", this.CarPrice),
				 new MySqlParameter("EarnestMoney", this.EarnestMoney),
				 new MySqlParameter("IsPublish", this.IsPublish),
				 new MySqlParameter("Inventory", this.Inventory),
				 new MySqlParameter("Sales", this.Sales),
				 new MySqlParameter("TotalComments", this.TotalComments),
				 new MySqlParameter("TotalCommentsPositive", this.TotalCommentsPositive),
				 new MySqlParameter("TotalCommentsModerate", this.TotalCommentsModerate),
				 new MySqlParameter("TotalCommentsNegative", this.TotalCommentsNegative),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("ProductName", this.ProductName),
				 new MySqlParameter("ProductSubName", this.ProductSubName),
				 new MySqlParameter("CarTypeId", this.CarTypeId),
				 new MySqlParameter("ProductRemark", this.ProductRemark),
				 new MySqlParameter("IsDelete", this.IsDelete),
				 new MySqlParameter("PublishDateTime", this.PublishDateTime),
				 new MySqlParameter("SubBrandId", this.SubBrandId)
			};

			string sql = "INSERT INTO p_dealercar(DealerCarId, BrandId, LineId, CarId, DealerId, CarPrice, EarnestMoney, IsPublish, Inventory, Sales, TotalComments, TotalCommentsPositive, TotalCommentsModerate, TotalCommentsNegative, createdate, CreateUserId, updatedate, UpdateUserId, ProductName, ProductSubName, CarTypeId, ProductRemark, IsDelete, PublishDateTime, SubBrandId) VALUES(?DealerCarId, ?BrandId, ?LineId, ?CarId, ?DealerId, ?CarPrice, ?EarnestMoney, ?IsPublish, ?Inventory, ?Sales, ?TotalComments, ?TotalCommentsPositive, ?TotalCommentsModerate, ?TotalCommentsNegative, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?ProductName, ?ProductSubName, ?CarTypeId, ?ProductRemark, ?IsDelete, ?PublishDateTime, ?SubBrandId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("DealerCarId", this.DealerCarId),
				 new MySqlParameter("BrandId", this.BrandId),
				 new MySqlParameter("LineId", this.LineId),
				 new MySqlParameter("CarId", this.CarId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("CarPrice", this.CarPrice),
				 new MySqlParameter("EarnestMoney", this.EarnestMoney),
				 new MySqlParameter("IsPublish", this.IsPublish),
				 new MySqlParameter("Inventory", this.Inventory),
				 new MySqlParameter("Sales", this.Sales),
				 new MySqlParameter("TotalComments", this.TotalComments),
				 new MySqlParameter("TotalCommentsPositive", this.TotalCommentsPositive),
				 new MySqlParameter("TotalCommentsModerate", this.TotalCommentsModerate),
				 new MySqlParameter("TotalCommentsNegative", this.TotalCommentsNegative),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("ProductName", this.ProductName),
				 new MySqlParameter("ProductSubName", this.ProductSubName),
				 new MySqlParameter("CarTypeId", this.CarTypeId),
				 new MySqlParameter("ProductRemark", this.ProductRemark),
				 new MySqlParameter("IsDelete", this.IsDelete),
				 new MySqlParameter("PublishDateTime", this.PublishDateTime),
				 new MySqlParameter("SubBrandId", this.SubBrandId)
			};

			string sql = "UPDATE p_dealercar SET DealerCarId = ?DealerCarId, BrandId = ?BrandId, LineId = ?LineId, CarId = ?CarId, DealerId = ?DealerId, CarPrice = ?CarPrice, EarnestMoney = ?EarnestMoney, IsPublish = ?IsPublish, Inventory = ?Inventory, Sales = ?Sales, TotalComments = ?TotalComments, TotalCommentsPositive = ?TotalCommentsPositive, TotalCommentsModerate = ?TotalCommentsModerate, TotalCommentsNegative = ?TotalCommentsNegative, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, ProductName = ?ProductName, ProductSubName = ?ProductSubName, CarTypeId = ?CarTypeId, ProductRemark = ?ProductRemark, IsDelete = ?IsDelete, PublishDateTime = ?PublishDateTime, SubBrandId = ?SubBrandId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_dealercar WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PDealercar GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_dealercar WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PDealercar> list = new DatatableFill<PDealercar>().FillModel(table);
            //List<PDealercar> list = Mapper.DynamicMap<IDataReader, List<PDealercar>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PDealercar> GetList()
        {
            string sql = "SELECT * FROM p_dealercar";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PDealercar> list = new DatatableFill<PDealercar>().FillModel(table);
            //List<PDealercar> list = Mapper.DynamicMap<IDataReader, List<PDealercar>>(table.CreateDataReader());
            return list;

        }

		public static List<PDealercar> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_dealercar WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PDealercar>().FillModel(table);
        }

        public static List<PDealercar> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_dealercar WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PDealercar> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PDealercar> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PDealerproduct
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int DealerProductId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ProductId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsPublish { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string PublishDate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int TotalComments { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int TotalCommentsPositive { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int TotalCommentsModerate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int TotalCommentsNegative { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Inventory { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Sales { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("DealerProductId", this.DealerProductId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("IsPublish", this.IsPublish),
				 new MySqlParameter("PublishDate", this.PublishDate),
				 new MySqlParameter("TotalComments", this.TotalComments),
				 new MySqlParameter("TotalCommentsPositive", this.TotalCommentsPositive),
				 new MySqlParameter("TotalCommentsModerate", this.TotalCommentsModerate),
				 new MySqlParameter("TotalCommentsNegative", this.TotalCommentsNegative),
				 new MySqlParameter("Inventory", this.Inventory),
				 new MySqlParameter("Sales", this.Sales),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO p_dealerproduct(DealerProductId, DealerId, ProductId, IsPublish, PublishDate, TotalComments, TotalCommentsPositive, TotalCommentsModerate, TotalCommentsNegative, Inventory, Sales, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?DealerProductId, ?DealerId, ?ProductId, ?IsPublish, ?PublishDate, ?TotalComments, ?TotalCommentsPositive, ?TotalCommentsModerate, ?TotalCommentsNegative, ?Inventory, ?Sales, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("DealerProductId", this.DealerProductId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("IsPublish", this.IsPublish),
				 new MySqlParameter("PublishDate", this.PublishDate),
				 new MySqlParameter("TotalComments", this.TotalComments),
				 new MySqlParameter("TotalCommentsPositive", this.TotalCommentsPositive),
				 new MySqlParameter("TotalCommentsModerate", this.TotalCommentsModerate),
				 new MySqlParameter("TotalCommentsNegative", this.TotalCommentsNegative),
				 new MySqlParameter("Inventory", this.Inventory),
				 new MySqlParameter("Sales", this.Sales),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE p_dealerproduct SET DealerProductId = ?DealerProductId, DealerId = ?DealerId, ProductId = ?ProductId, IsPublish = ?IsPublish, PublishDate = ?PublishDate, TotalComments = ?TotalComments, TotalCommentsPositive = ?TotalCommentsPositive, TotalCommentsModerate = ?TotalCommentsModerate, TotalCommentsNegative = ?TotalCommentsNegative, Inventory = ?Inventory, Sales = ?Sales, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_dealerproduct WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PDealerproduct GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_dealerproduct WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PDealerproduct> list = new DatatableFill<PDealerproduct>().FillModel(table);
            //List<PDealerproduct> list = Mapper.DynamicMap<IDataReader, List<PDealerproduct>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PDealerproduct> GetList()
        {
            string sql = "SELECT * FROM p_dealerproduct";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PDealerproduct> list = new DatatableFill<PDealerproduct>().FillModel(table);
            //List<PDealerproduct> list = Mapper.DynamicMap<IDataReader, List<PDealerproduct>>(table.CreateDataReader());
            return list;

        }

		public static List<PDealerproduct> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_dealerproduct WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PDealerproduct>().FillModel(table);
        }

        public static List<PDealerproduct> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_dealerproduct WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PDealerproduct> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PDealerproduct> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PGroup
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int GroupId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CategoryId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string GroupName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string GroupSubName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("GroupId", this.GroupId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("CategoryId", this.CategoryId),
				 new MySqlParameter("GroupName", this.GroupName),
				 new MySqlParameter("GroupSubName", this.GroupSubName),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO p_group(GroupId, DealerId, CategoryId, GroupName, GroupSubName, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?GroupId, ?DealerId, ?CategoryId, ?GroupName, ?GroupSubName, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("GroupId", this.GroupId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("CategoryId", this.CategoryId),
				 new MySqlParameter("GroupName", this.GroupName),
				 new MySqlParameter("GroupSubName", this.GroupSubName),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE p_group SET GroupId = ?GroupId, DealerId = ?DealerId, CategoryId = ?CategoryId, GroupName = ?GroupName, GroupSubName = ?GroupSubName, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_group WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PGroup GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_group WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PGroup> list = new DatatableFill<PGroup>().FillModel(table);
            //List<PGroup> list = Mapper.DynamicMap<IDataReader, List<PGroup>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PGroup> GetList()
        {
            string sql = "SELECT * FROM p_group";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PGroup> list = new DatatableFill<PGroup>().FillModel(table);
            //List<PGroup> list = Mapper.DynamicMap<IDataReader, List<PGroup>>(table.CreateDataReader());
            return list;

        }

		public static List<PGroup> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_group WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PGroup>().FillModel(table);
        }

        public static List<PGroup> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_group WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PGroup> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PGroup> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PGroupproperty
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int GroupPropertyId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int GroupId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string PropertyName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("GroupPropertyId", this.GroupPropertyId),
				 new MySqlParameter("GroupId", this.GroupId),
				 new MySqlParameter("PropertyName", this.PropertyName),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO p_groupproperty(GroupPropertyId, GroupId, PropertyName, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?GroupPropertyId, ?GroupId, ?PropertyName, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("GroupPropertyId", this.GroupPropertyId),
				 new MySqlParameter("GroupId", this.GroupId),
				 new MySqlParameter("PropertyName", this.PropertyName),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE p_groupproperty SET GroupPropertyId = ?GroupPropertyId, GroupId = ?GroupId, PropertyName = ?PropertyName, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_groupproperty WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PGroupproperty GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_groupproperty WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PGroupproperty> list = new DatatableFill<PGroupproperty>().FillModel(table);
            //List<PGroupproperty> list = Mapper.DynamicMap<IDataReader, List<PGroupproperty>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PGroupproperty> GetList()
        {
            string sql = "SELECT * FROM p_groupproperty";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PGroupproperty> list = new DatatableFill<PGroupproperty>().FillModel(table);
            //List<PGroupproperty> list = Mapper.DynamicMap<IDataReader, List<PGroupproperty>>(table.CreateDataReader());
            return list;

        }

		public static List<PGroupproperty> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_groupproperty WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PGroupproperty>().FillModel(table);
        }

        public static List<PGroupproperty> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_groupproperty WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PGroupproperty> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PGroupproperty> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PProduct
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public long ProductId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CategoryId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProductCode { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProductName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string ProductSubName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string MainImageUrl { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal Price { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsPlantOfOrigin { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int BrandId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string BrandName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsNoReasonReturn { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ProductBandId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public byte IsDelete { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Recommend { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("CategoryId", this.CategoryId),
				 new MySqlParameter("ProductCode", this.ProductCode),
				 new MySqlParameter("ProductName", this.ProductName),
				 new MySqlParameter("ProductSubName", this.ProductSubName),
				 new MySqlParameter("MainImageUrl", this.MainImageUrl),
				 new MySqlParameter("price", this.Price),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("IsPlantOfOrigin", this.IsPlantOfOrigin),
				 new MySqlParameter("BrandId", this.BrandId),
				 new MySqlParameter("BrandName", this.BrandName),
				 new MySqlParameter("IsNoReasonReturn", this.IsNoReasonReturn),
				 new MySqlParameter("ProductBandId", this.ProductBandId),
				 new MySqlParameter("IsDelete", this.IsDelete),
				 new MySqlParameter("Recommend", this.Recommend)
			};

			string sql = "INSERT INTO p_product(ProductId, CategoryId, ProductCode, ProductName, ProductSubName, MainImageUrl, price, createdate, CreateUserId, updatedate, UpdateUserId, IsPlantOfOrigin, BrandId, BrandName, IsNoReasonReturn, ProductBandId, IsDelete, Recommend) VALUES(?ProductId, ?CategoryId, ?ProductCode, ?ProductName, ?ProductSubName, ?MainImageUrl, ?price, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?IsPlantOfOrigin, ?BrandId, ?BrandName, ?IsNoReasonReturn, ?ProductBandId, ?IsDelete, ?Recommend)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("CategoryId", this.CategoryId),
				 new MySqlParameter("ProductCode", this.ProductCode),
				 new MySqlParameter("ProductName", this.ProductName),
				 new MySqlParameter("ProductSubName", this.ProductSubName),
				 new MySqlParameter("MainImageUrl", this.MainImageUrl),
				 new MySqlParameter("price", this.Price),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("IsPlantOfOrigin", this.IsPlantOfOrigin),
				 new MySqlParameter("BrandId", this.BrandId),
				 new MySqlParameter("BrandName", this.BrandName),
				 new MySqlParameter("IsNoReasonReturn", this.IsNoReasonReturn),
				 new MySqlParameter("ProductBandId", this.ProductBandId),
				 new MySqlParameter("IsDelete", this.IsDelete),
				 new MySqlParameter("Recommend", this.Recommend)
			};

			string sql = "UPDATE p_product SET ProductId = ?ProductId, CategoryId = ?CategoryId, ProductCode = ?ProductCode, ProductName = ?ProductName, ProductSubName = ?ProductSubName, MainImageUrl = ?MainImageUrl, price = ?price, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, IsPlantOfOrigin = ?IsPlantOfOrigin, BrandId = ?BrandId, BrandName = ?BrandName, IsNoReasonReturn = ?IsNoReasonReturn, ProductBandId = ?ProductBandId, IsDelete = ?IsDelete, Recommend = ?Recommend WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_product WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PProduct GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_product WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProduct> list = new DatatableFill<PProduct>().FillModel(table);
            //List<PProduct> list = Mapper.DynamicMap<IDataReader, List<PProduct>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PProduct> GetList()
        {
            string sql = "SELECT * FROM p_product";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProduct> list = new DatatableFill<PProduct>().FillModel(table);
            //List<PProduct> list = Mapper.DynamicMap<IDataReader, List<PProduct>>(table.CreateDataReader());
            return list;

        }

		public static List<PProduct> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_product WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PProduct>().FillModel(table);
        }

        public static List<PProduct> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_product WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PProduct> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PProduct> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PProductbrand
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int BrandId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string BrandName { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string IndexLetter { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("BrandId", this.BrandId),
				 new MySqlParameter("BrandName", this.BrandName),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("IndexLetter", this.IndexLetter)
			};

			string sql = "INSERT INTO p_productbrand(BrandId, BrandName, createdate, CreateUserId, updatedate, UpdateUserId, IndexLetter) VALUES(?BrandId, ?BrandName, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?IndexLetter)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("BrandId", this.BrandId),
				 new MySqlParameter("BrandName", this.BrandName),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("IndexLetter", this.IndexLetter)
			};

			string sql = "UPDATE p_productbrand SET BrandId = ?BrandId, BrandName = ?BrandName, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, IndexLetter = ?IndexLetter WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_productbrand WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PProductbrand GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_productbrand WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductbrand> list = new DatatableFill<PProductbrand>().FillModel(table);
            //List<PProductbrand> list = Mapper.DynamicMap<IDataReader, List<PProductbrand>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PProductbrand> GetList()
        {
            string sql = "SELECT * FROM p_productbrand";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductbrand> list = new DatatableFill<PProductbrand>().FillModel(table);
            //List<PProductbrand> list = Mapper.DynamicMap<IDataReader, List<PProductbrand>>(table.CreateDataReader());
            return list;

        }

		public static List<PProductbrand> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_productbrand WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PProductbrand>().FillModel(table);
        }

        public static List<PProductbrand> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_productbrand WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PProductbrand> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PProductbrand> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PProductcar
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public long ProductId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int LineId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("LineId", this.LineId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO p_productcar(ProductId, LineId, createdate, CreateUserId, updatedate, UpdateUserId) VALUES(?ProductId, ?LineId, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("LineId", this.LineId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE p_productcar SET ProductId = ?ProductId, LineId = ?LineId, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_productcar WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PProductcar GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_productcar WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductcar> list = new DatatableFill<PProductcar>().FillModel(table);
            //List<PProductcar> list = Mapper.DynamicMap<IDataReader, List<PProductcar>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PProductcar> GetList()
        {
            string sql = "SELECT * FROM p_productcar";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductcar> list = new DatatableFill<PProductcar>().FillModel(table);
            //List<PProductcar> list = Mapper.DynamicMap<IDataReader, List<PProductcar>>(table.CreateDataReader());
            return list;

        }

		public static List<PProductcar> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_productcar WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PProductcar>().FillModel(table);
        }

        public static List<PProductcar> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_productcar WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PProductcar> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PProductcar> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PProductcomment
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int ProductCommentId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long ProductId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Type { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CommentGrade { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string OrderId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string CommentContent { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Clicklike { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int Reply { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Username { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string HeadImgUrl { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CommetType { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ClientId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerCarId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int PlatformScore { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int ServiceScore { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductCommentId", this.ProductCommentId),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("type", this.Type),
				 new MySqlParameter("comment_grade", this.CommentGrade),
				 new MySqlParameter("OrderId", this.OrderId),
				 new MySqlParameter("comment_content", this.CommentContent),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("clicklike", this.Clicklike),
				 new MySqlParameter("reply", this.Reply),
				 new MySqlParameter("Username", this.Username),
				 new MySqlParameter("HeadImgUrl", this.HeadImgUrl),
				 new MySqlParameter("CommetType", this.CommetType),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("DealerCarId", this.DealerCarId),
				 new MySqlParameter("PlatformScore", this.PlatformScore),
				 new MySqlParameter("ServiceScore", this.ServiceScore),
				 new MySqlParameter("DealerId", this.DealerId)
			};

			string sql = "INSERT INTO p_productcomment(ProductCommentId, ProductId, type, comment_grade, OrderId, comment_content, createdate, CreateUserId, updatedate, UpdateUserId, clicklike, reply, Username, HeadImgUrl, CommetType, ClientId, DealerCarId, PlatformScore, ServiceScore, DealerId) VALUES(?ProductCommentId, ?ProductId, ?type, ?comment_grade, ?OrderId, ?comment_content, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?clicklike, ?reply, ?Username, ?HeadImgUrl, ?CommetType, ?ClientId, ?DealerCarId, ?PlatformScore, ?ServiceScore, ?DealerId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductCommentId", this.ProductCommentId),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("type", this.Type),
				 new MySqlParameter("comment_grade", this.CommentGrade),
				 new MySqlParameter("OrderId", this.OrderId),
				 new MySqlParameter("comment_content", this.CommentContent),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("clicklike", this.Clicklike),
				 new MySqlParameter("reply", this.Reply),
				 new MySqlParameter("Username", this.Username),
				 new MySqlParameter("HeadImgUrl", this.HeadImgUrl),
				 new MySqlParameter("CommetType", this.CommetType),
				 new MySqlParameter("ClientId", this.ClientId),
				 new MySqlParameter("DealerCarId", this.DealerCarId),
				 new MySqlParameter("PlatformScore", this.PlatformScore),
				 new MySqlParameter("ServiceScore", this.ServiceScore),
				 new MySqlParameter("DealerId", this.DealerId)
			};

			string sql = "UPDATE p_productcomment SET ProductCommentId = ?ProductCommentId, ProductId = ?ProductId, type = ?type, comment_grade = ?comment_grade, OrderId = ?OrderId, comment_content = ?comment_content, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, clicklike = ?clicklike, reply = ?reply, Username = ?Username, HeadImgUrl = ?HeadImgUrl, CommetType = ?CommetType, ClientId = ?ClientId, DealerCarId = ?DealerCarId, PlatformScore = ?PlatformScore, ServiceScore = ?ServiceScore, DealerId = ?DealerId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_productcomment WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PProductcomment GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_productcomment WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductcomment> list = new DatatableFill<PProductcomment>().FillModel(table);
            //List<PProductcomment> list = Mapper.DynamicMap<IDataReader, List<PProductcomment>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PProductcomment> GetList()
        {
            string sql = "SELECT * FROM p_productcomment";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductcomment> list = new DatatableFill<PProductcomment>().FillModel(table);
            //List<PProductcomment> list = Mapper.DynamicMap<IDataReader, List<PProductcomment>>(table.CreateDataReader());
            return list;

        }

		public static List<PProductcomment> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_productcomment WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PProductcomment>().FillModel(table);
        }

        public static List<PProductcomment> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_productcomment WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PProductcomment> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PProductcomment> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PProductdetail
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public long ProductId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string Description { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string OtherDesc { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("Description", this.Description),
				 new MySqlParameter("OtherDesc", this.OtherDesc),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("updatedate", this.Updatedate)
			};

			string sql = "INSERT INTO p_productdetail(ProductId, Description, OtherDesc, CreateUserId, createdate, UpdateUserId, updatedate) VALUES(?ProductId, ?Description, ?OtherDesc, ?CreateUserId, ?createdate, ?UpdateUserId, ?updatedate)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("Description", this.Description),
				 new MySqlParameter("OtherDesc", this.OtherDesc),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("updatedate", this.Updatedate)
			};

			string sql = "UPDATE p_productdetail SET ProductId = ?ProductId, Description = ?Description, OtherDesc = ?OtherDesc, CreateUserId = ?CreateUserId, createdate = ?createdate, UpdateUserId = ?UpdateUserId, updatedate = ?updatedate WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_productdetail WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PProductdetail GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_productdetail WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductdetail> list = new DatatableFill<PProductdetail>().FillModel(table);
            //List<PProductdetail> list = Mapper.DynamicMap<IDataReader, List<PProductdetail>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PProductdetail> GetList()
        {
            string sql = "SELECT * FROM p_productdetail";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductdetail> list = new DatatableFill<PProductdetail>().FillModel(table);
            //List<PProductdetail> list = Mapper.DynamicMap<IDataReader, List<PProductdetail>>(table.CreateDataReader());
            return list;

        }

		public static List<PProductdetail> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_productdetail WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PProductdetail>().FillModel(table);
        }

        public static List<PProductdetail> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_productdetail WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PProductdetail> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PProductdetail> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PProductgroup
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int GroupPropertyId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long ProductId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string PropertyValue { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("GroupPropertyId", this.GroupPropertyId),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("PropertyValue", this.PropertyValue),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "INSERT INTO p_productgroup(GroupPropertyId, ProductId, PropertyValue, CreateUserId, createdate, updatedate, UpdateUserId) VALUES(?GroupPropertyId, ?ProductId, ?PropertyValue, ?CreateUserId, ?createdate, ?updatedate, ?UpdateUserId)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("GroupPropertyId", this.GroupPropertyId),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("PropertyValue", this.PropertyValue),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId)
			};

			string sql = "UPDATE p_productgroup SET GroupPropertyId = ?GroupPropertyId, ProductId = ?ProductId, PropertyValue = ?PropertyValue, CreateUserId = ?CreateUserId, createdate = ?createdate, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_productgroup WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PProductgroup GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_productgroup WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductgroup> list = new DatatableFill<PProductgroup>().FillModel(table);
            //List<PProductgroup> list = Mapper.DynamicMap<IDataReader, List<PProductgroup>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PProductgroup> GetList()
        {
            string sql = "SELECT * FROM p_productgroup";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductgroup> list = new DatatableFill<PProductgroup>().FillModel(table);
            //List<PProductgroup> list = Mapper.DynamicMap<IDataReader, List<PProductgroup>>(table.CreateDataReader());
            return list;

        }

		public static List<PProductgroup> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_productgroup WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PProductgroup>().FillModel(table);
        }

        public static List<PProductgroup> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_productgroup WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PProductgroup> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PProductgroup> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PProductimage
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int ProductImageId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long ProductId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string SmallImage { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string GeneralImage { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string BigImage { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductImageId", this.ProductImageId),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("SmallImage", this.SmallImage),
				 new MySqlParameter("GeneralImage", this.GeneralImage),
				 new MySqlParameter("BigImage", this.BigImage),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("createdate", this.Createdate)
			};

			string sql = "INSERT INTO p_productimage(ProductImageId, ProductId, SmallImage, GeneralImage, BigImage, CreateUserId, createdate) VALUES(?ProductImageId, ?ProductId, ?SmallImage, ?GeneralImage, ?BigImage, ?CreateUserId, ?createdate)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductImageId", this.ProductImageId),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("SmallImage", this.SmallImage),
				 new MySqlParameter("GeneralImage", this.GeneralImage),
				 new MySqlParameter("BigImage", this.BigImage),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("createdate", this.Createdate)
			};

			string sql = "UPDATE p_productimage SET ProductImageId = ?ProductImageId, ProductId = ?ProductId, SmallImage = ?SmallImage, GeneralImage = ?GeneralImage, BigImage = ?BigImage, CreateUserId = ?CreateUserId, createdate = ?createdate WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_productimage WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PProductimage GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_productimage WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductimage> list = new DatatableFill<PProductimage>().FillModel(table);
            //List<PProductimage> list = Mapper.DynamicMap<IDataReader, List<PProductimage>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PProductimage> GetList()
        {
            string sql = "SELECT * FROM p_productimage";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductimage> list = new DatatableFill<PProductimage>().FillModel(table);
            //List<PProductimage> list = Mapper.DynamicMap<IDataReader, List<PProductimage>>(table.CreateDataReader());
            return list;

        }

		public static List<PProductimage> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_productimage WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PProductimage>().FillModel(table);
        }

        public static List<PProductimage> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_productimage WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PProductimage> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PProductimage> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class PProductsale
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int ProductSaleId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public long ProductId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal SalePrice { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime StartDate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime EndDate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string SaleTitle { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string SaleSubTitle { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string SaleBriefDescription { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public string SaleDescripton { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Createdate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int CreateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public DateTime Updatedate { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int UpdateUserId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public int DealerId { get; set; }
		/// <summary>
        /// 
        /// </summary>
		public decimal DiscountRate { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductSaleId", this.ProductSaleId),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("SalePrice", this.SalePrice),
				 new MySqlParameter("StartDate", this.StartDate),
				 new MySqlParameter("EndDate", this.EndDate),
				 new MySqlParameter("SaleTitle", this.SaleTitle),
				 new MySqlParameter("SaleSubTitle", this.SaleSubTitle),
				 new MySqlParameter("SaleBriefDescription", this.SaleBriefDescription),
				 new MySqlParameter("SaleDescripton", this.SaleDescripton),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("DiscountRate", this.DiscountRate)
			};

			string sql = "INSERT INTO p_productsale(ProductSaleId, ProductId, SalePrice, StartDate, EndDate, SaleTitle, SaleSubTitle, SaleBriefDescription, SaleDescripton, createdate, CreateUserId, updatedate, UpdateUserId, DealerId, DiscountRate) VALUES(?ProductSaleId, ?ProductId, ?SalePrice, ?StartDate, ?EndDate, ?SaleTitle, ?SaleSubTitle, ?SaleBriefDescription, ?SaleDescripton, ?createdate, ?CreateUserId, ?updatedate, ?UpdateUserId, ?DealerId, ?DiscountRate)";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("ProductSaleId", this.ProductSaleId),
				 new MySqlParameter("ProductId", this.ProductId),
				 new MySqlParameter("SalePrice", this.SalePrice),
				 new MySqlParameter("StartDate", this.StartDate),
				 new MySqlParameter("EndDate", this.EndDate),
				 new MySqlParameter("SaleTitle", this.SaleTitle),
				 new MySqlParameter("SaleSubTitle", this.SaleSubTitle),
				 new MySqlParameter("SaleBriefDescription", this.SaleBriefDescription),
				 new MySqlParameter("SaleDescripton", this.SaleDescripton),
				 new MySqlParameter("createdate", this.Createdate),
				 new MySqlParameter("CreateUserId", this.CreateUserId),
				 new MySqlParameter("updatedate", this.Updatedate),
				 new MySqlParameter("UpdateUserId", this.UpdateUserId),
				 new MySqlParameter("DealerId", this.DealerId),
				 new MySqlParameter("DiscountRate", this.DiscountRate)
			};

			string sql = "UPDATE p_productsale SET ProductSaleId = ?ProductSaleId, ProductId = ?ProductId, SalePrice = ?SalePrice, StartDate = ?StartDate, EndDate = ?EndDate, SaleTitle = ?SaleTitle, SaleSubTitle = ?SaleSubTitle, SaleBriefDescription = ?SaleBriefDescription, SaleDescripton = ?SaleDescripton, createdate = ?createdate, CreateUserId = ?CreateUserId, updatedate = ?updatedate, UpdateUserId = ?UpdateUserId, DealerId = ?DealerId, DiscountRate = ?DiscountRate WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM p_productsale WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static PProductsale GetById(int id)
        {
            string sql = string.Format("SELECT * FROM p_productsale WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductsale> list = new DatatableFill<PProductsale>().FillModel(table);
            //List<PProductsale> list = Mapper.DynamicMap<IDataReader, List<PProductsale>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<PProductsale> GetList()
        {
            string sql = "SELECT * FROM p_productsale";
            DataTable table = DBHelper.GetDateTable(sql);
			List<PProductsale> list = new DatatableFill<PProductsale>().FillModel(table);
            //List<PProductsale> list = Mapper.DynamicMap<IDataReader, List<PProductsale>>(table.CreateDataReader());
            return list;

        }

		public static List<PProductsale> Find(string where)
        {
            string sql = string.Format("SELECT * FROM p_productsale WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<PProductsale>().FillModel(table);
        }

        public static List<PProductsale> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM p_productsale WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<PProductsale> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<PProductsale> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class TTest
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int Id { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] {
			};

			string sql = "INSERT INTO t_test() VALUES()";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("id", this.Id)
			};

			string sql = "UPDATE t_test SET  WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM t_test WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static TTest GetById(int id)
        {
            string sql = string.Format("SELECT * FROM t_test WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<TTest> list = new DatatableFill<TTest>().FillModel(table);
            //List<TTest> list = Mapper.DynamicMap<IDataReader, List<TTest>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<TTest> GetList()
        {
            string sql = "SELECT * FROM t_test";
            DataTable table = DBHelper.GetDateTable(sql);
			List<TTest> list = new DatatableFill<TTest>().FillModel(table);
            //List<TTest> list = Mapper.DynamicMap<IDataReader, List<TTest>>(table.CreateDataReader());
            return list;

        }

		public static List<TTest> Find(string where)
        {
            string sql = string.Format("SELECT * FROM t_test WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<TTest>().FillModel(table);
        }

        public static List<TTest> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM t_test WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<TTest> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<TTest> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

	public partial class Tmp2
    {
		#region Field
		/// <summary>
        /// 
        /// </summary>
		public int Id { get; set; }
		#endregion

		public int Save()
		{
			MySqlParameter[] paras = new MySqlParameter[] {
			};

			string sql = "INSERT INTO tmp2() VALUES()";
		return DBHelper.NoneQuery(sql, paras);
		}
		
		public int Update()
        {

            MySqlParameter[] paras = new MySqlParameter[] { 
				 new MySqlParameter("id", this.Id)
			};

			string sql = "UPDATE tmp2 SET  WHERE id = ?id";
            return DBHelper.NoneQuery(sql, paras);

        }

		public static int Delete(int id)
        {
            string sql = string.Format("DELETE FROM tmp2 WHERE id = {0}", id);
            return DBHelper.NoneQuery(sql);

        }

		public static Tmp2 GetById(int id)
        {
            string sql = string.Format("SELECT * FROM tmp2 WHERE id = {0}", id);
            DataTable table = DBHelper.GetDateTable(sql);
			List<Tmp2> list = new DatatableFill<Tmp2>().FillModel(table);
            //List<Tmp2> list = Mapper.DynamicMap<IDataReader, List<Tmp2>>(table.CreateDataReader());
            if (list == null || list.Count == 0) return null;
            return list[0];
        }

		public static List<Tmp2> GetList()
        {
            string sql = "SELECT * FROM tmp2";
            DataTable table = DBHelper.GetDateTable(sql);
			List<Tmp2> list = new DatatableFill<Tmp2>().FillModel(table);
            //List<Tmp2> list = Mapper.DynamicMap<IDataReader, List<Tmp2>>(table.CreateDataReader());
            return list;

        }

		public static List<Tmp2> Find(string where)
        {
            string sql = string.Format("SELECT * FROM tmp2 WHERE {0};", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return new DatatableFill<Tmp2>().FillModel(table);
        }

        public static List<Tmp2> Find(string field, string prop)
        {
            return Find(string.Format(" {0} = '{1}' ", field, prop));

        }

        public static bool Exist(string field, string prop)
        {
            int n = Count(field, prop);
            return n > 0 ? true : false;
        }

        public static int Count(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM tmp2 WHERE {0}", where);
            DataTable table = DBHelper.GetDateTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public static int Count(string field, string prop)
        {
            return Count(string.Format(" {0} = '{1}' ", field, prop));
        }

        public static int Count()
        {
            return Count(" 1 = 1 ");
        }

        public static List<Tmp2> Find(int index, int size, ref int count)
        {
            count = Count(" 1 = 1 ");
            string sql = string.Format(" 1 = 1 Order by id desc  LIMIT {0}, {1} ", index * size , size);
            return Find(sql);
        }

        public static List<Tmp2> Find(string field, string prop, int index, int size, ref int count)
        {
            count = Count(field, prop);
            string sql = string.Format(" {0} = {1} Order by id desc LIMIT {2}, {3} ", field, prop, index, size);
            return Find(sql);
        }
    }

}

