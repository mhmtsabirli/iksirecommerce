using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class Address : Base
    {
        public int Type { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Description { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }

        public Address CreateAddress(int id, int createuser, DateTime createdate, int edituser, DateTime editdate, int type, int countryid, int cityid, int districtid, string description, string postalcode, string phone, int userid)
        {
            Address ad = new Address();
            ad.Type = type;
            ad.CountryId = countryid;
            ad.CityId = cityid;
            ad.DistrictId = districtid;
            ad.Description = description;
            ad.PostalCode = postalcode;
            ad.Phone = phone;
            ad.UserId = userid;
            ad.CreateBase(id, createuser, createdate, edituser, editdate);
            return ad;
        }

    }
}
