using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.Model.CommonModel
{
    public class Address : ModelBase
    {
        #region Properties
        public User User { get; set; }
        public string Title { get; set; }
        public EnumValue Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Country Country { get; set; }
        //Türkiye dışında bir ülke seçilirse string olarak ülke adını alıyoruz.
        public string CountryName { get; set; }
        public City City { get; set; }
        public District District { get; set; }
        public string AddressDetail { get; set; }
        //Türkiye dışında bir ülke seçilirse string olarak alınacağından City bu şekilde tanımlandı
        public string CityName { get; set; }
        //Türkiye dışında bir ülke seçilirse string olarak alınacağından District bu şekilde tanımlandı
        public string DistrictName { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string GSMPhone { get; set; }

        #endregion

        #region Constructors
        public Address(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, User user, string title, EnumValue type, string firstName, string lastName, Country country, City city, District district, string addressDetail, string postalCode, string phone, string gsmPhone)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.User = user;
            this.Title = title;
            this.Type = type;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.City = city;
            this.District = district;
            this.AddressDetail = addressDetail;
            this.PostalCode = postalCode;
            this.Phone = phone;
            this.GSMPhone = gsmPhone;
        }

        public Address()
        {
            // TODO: Complete member initialization
        }
        #endregion
    }
}
