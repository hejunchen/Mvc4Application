using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvc4DataTransfer
{
    public class EmployeeDTO
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Name { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public string FullName { get { return string.Format("{0} {1} {2}", FirstName, MiddleName, LastName); } }
        public DateTime BirthDate { get; set; }
        public int Age 
        { 
            //compare the birthday in this year with birth date to get the exact number of age.
            get 
            {
                DateTime BirthDate_In_This_Year = new DateTime(DateTime.Today.Year, BirthDate.Month, BirthDate.Day);
                if (BirthDate_In_This_Year > DateTime.Today)
                    return DateTime.Today.Year - BirthDate.Year - 1;
                else
                    return DateTime.Today.Year - BirthDate.Year;
            } 
        }
        public string Gender { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberType { get; set; }
        public string EmailAddress { get; set; }
        public Boolean EmailPromotion { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvinceName { get; set; }
        public string PostalCode { get; set; }
        public string CountryRegionName { get; set; }
        public string FullAddress
        { 
            get 
            {
                string address = "";

                if (!string.IsNullOrEmpty(AddressLine2))
                    address += AddressLine2 + ", ";

                address += string.Format("{0}, {1}, {2}, {3}, {4}", AddressLine1, City, StateProvinceName, CountryRegionName, PostalCode);

                return address;

            } 
        }        
    

    }
}
