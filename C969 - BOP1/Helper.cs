using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969___BOP1
{
    class Helper
    {
        public static int CurrentCustomerId;

        public static int CurrentAppointmentId;

        public static string CurrentUser;

        public static int ReportType;

        public static int CurrentUserId(string CurrentUser)
        {
            int userId;

            using (var contextUserId = new U05EiVEntities())
            {
                userId = contextUserId.users.FirstOrDefault(user => user.userName.ToString() == CurrentUser).userId; // Replaces a sql query and for loop to find the userId

            }

            return userId;
        }

        public static int CreateCustomerId()
        {
            int NewId = 0;

            using (var contextCreateId = new U05EiVEntities())
            {
                var customerIdList = contextCreateId.customers.Select(c => new
                {
                    c.customerId

                }).ToList();

                foreach (var customer in customerIdList)
                {
                    if (customer.customerId >= NewId)
                    {
                        NewId = customer.customerId + 1;
                    }
                }
            }
            return NewId;
        }

        public static int CreateAddressId()
        {
            int NewId = 0;

            using (var contextCreateAddressId = new U05EiVEntities())
            {
                var addressIdList = contextCreateAddressId.addresses.Select(a => new
                {
                    a.addressId

                }).ToList();

                foreach (var address in addressIdList)
                {
                    if (address.addressId >= NewId)
                    {
                        NewId = address.addressId + 1;
                    }
                }
            }
            return NewId;
        }

        public static int CreateCityId()
        {
            int NewId = 0;

            using (var contextCreateCityId = new U05EiVEntities())
            {
                var cityIdList = contextCreateCityId.cities.Select(c => new
                {
                    c.cityId

                }).ToList();

                foreach (var city in cityIdList)
                {
                    if (city.cityId >= NewId)
                    {
                        NewId = city.cityId + 1;
                    }
                }
            }
            return NewId;
        }

        public static int CreateCountryId()
        {
            int NewId = 0;

            using (var contextCreateCountryId = new U05EiVEntities())
            {
                var countryIdList = contextCreateCountryId.countries.Select(c => new
                {
                    c.countryId

                }).ToList();

                foreach (var country in countryIdList)
                {
                    if (country.countryId >= NewId)
                    {
                        NewId = country.countryId + 1;
                    }
                }
            }
            return NewId;
        }

        public static int CreateAppointmentId()
        {
            int NewId = 0;

            using (var contextCreateAppointmentId = new U05EiVEntities())
            {
                var appointmentIdList = contextCreateAppointmentId.appointments.Select(c => new
                {
                    c.appointmentId

                }).ToList();

                foreach (var appointment in appointmentIdList)
                {
                    if (appointment.appointmentId >= NewId)
                    {
                        NewId = appointment.appointmentId + 1;
                    }
                }
            }
            return NewId;
        }

        public static string createTimeStamp()
        {
            return DateTime.Now.ToString("u");
        }

        public static string convertTimeZone(string dateTime)
        {
            DateTime universalTime = DateTime.Parse(dateTime.ToString());
            DateTime localTime = universalTime.ToLocalTime();

            return localTime.ToString("MM/dd/yyyy hh:mm tt");
        }

        public static bool doesAppointmentOverlap(DateTime appointmentStartTime, DateTime appointmentEndTime, int userId)
        {
            using (var appointmentContext = new U05EiVEntities())
            {
                var appointmentStartEndList = appointmentContext.appointments.Select(appointment => new
                {
                    appointment.start,
                    appointment.end,
                    }).ToList();

                foreach (var appointment in appointmentStartEndList)
                {
                    if ((appointmentStartTime < appointment.end) && (appointment.start < appointmentEndTime))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static bool isAppointmentOutsideBusinessHours(DateTime appointmentStartTime, DateTime appointmentEndTime)
        {
            appointmentStartTime = appointmentStartTime.ToLocalTime();
            appointmentEndTime = appointmentEndTime.ToLocalTime();

            TimeSpan businessStartOfDay = TimeSpan.Parse("08:00");
            TimeSpan businessEndOfDay = TimeSpan.Parse("17:00");

            if (((appointmentStartTime.TimeOfDay > businessStartOfDay) && (appointmentStartTime.TimeOfDay < businessEndOfDay))
                && ((appointmentEndTime.TimeOfDay > businessStartOfDay) && (appointmentEndTime.TimeOfDay < businessEndOfDay)))
            {
                return false;
            }
            return true;     
        }
    }
}
