using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___BOP1
{
    public partial class UpdateCustomerForm : Form
    {
        U05EiVEntities updateCustomerContext = new U05EiVEntities();

        bool checkChanged;


        private bool allowCustomerCreation()
        {
            return (!(string.IsNullOrWhiteSpace(textBoxCustomerName.Text))) &&
                   (!(string.IsNullOrWhiteSpace(textBoxCustomerAddress1.Text))) &&
                   (!(string.IsNullOrWhiteSpace(textBoxCustomerPostalCode.Text))) &&
                   (!(string.IsNullOrWhiteSpace(textBoxCustomerPhone.Text)));

        }

        private bool ValidatePhoneNumber()
        {
            bool isPhoneOkay = false;

            string phoneRegEx = @"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$";

            if (!Regex.IsMatch(textBoxCustomerPhone.Text, phoneRegEx))
            {
                return isPhoneOkay;
            }
            else
            {
                isPhoneOkay = true;

            }
            return isPhoneOkay;
        }

        private bool ValidatePostalCode()
        {
            bool isPostalCodeOkay = false;

            string postalCodeRegEx = @"(?i)^[a-z0-9][a-z0-9\- ]{0,10}[a-z0-9]$";
            if (!Regex.IsMatch(textBoxCustomerPostalCode.Text, postalCodeRegEx))
            {
                return isPostalCodeOkay;
            }
            else
            {
                isPostalCodeOkay = true;

            }
            return isPostalCodeOkay;

        }

        public UpdateCustomerForm()
        {
            InitializeComponent();

            using (U05EiVEntities c = new U05EiVEntities())
            {
                // Querying customer information
                string customerId = c.customers.FirstOrDefault(customer => customer.customerId == Helper.CurrentCustomerId).customerId.ToString();
                string customerName = c.customers.FirstOrDefault(customer => customer.customerId == Helper.CurrentCustomerId).customerName.ToString();
                bool customerActive = c.customers.FirstOrDefault(customer => customer.customerId == Helper.CurrentCustomerId).active;

                // Querying Customer Address Information
                string customerAddressId = c.customers.FirstOrDefault(customer => customer.customerId == Helper.CurrentCustomerId).addressId.ToString();
                string customerAddress1 = c.addresses.FirstOrDefault(address => address.addressId.ToString() == customerAddressId).address1;
                string customerAddress2 = c.addresses.FirstOrDefault(address => address.addressId.ToString() == customerAddressId).address2;
                string customerPostalCode = c.addresses.FirstOrDefault(address => address.addressId.ToString() == customerAddressId).postalCode;
                string customerPhone = c.addresses.FirstOrDefault(address => address.addressId.ToString() == customerAddressId).phone;

                // Querying Customer City Information
                string customerCityId = c.addresses.FirstOrDefault(address => address.addressId.ToString() == customerAddressId).cityId.ToString();
                string customerCity1 = c.cities.FirstOrDefault(city => city.cityId.ToString() == customerCityId).city1.ToString();

                // Querying Customer Country Information
                string customerCountryId = c.cities.FirstOrDefault(city => city.cityId.ToString() == customerCityId).countryId.ToString();
                string customerCountry1 = c.countries.FirstOrDefault(country => country.countryId.ToString() == customerCountryId).country1.ToString();

                // Displaying Customer Address, Country, and City Information
                textBoxCustomerId.Text = customerId;
                textBoxAddressId.Text = customerAddressId;
                textBoxCustomerName.Text = customerName;
                checkBoxActive.Checked = customerActive;
                textBoxCustomerAddress1.Text = customerAddress1;
                textBoxCustomerAddress2.Text = customerAddress2;
                textBoxCustomerPostalCode.Text = customerPostalCode;
               // textBoxCustomerCity.Text = customerCity1;
               // textBoxCustomerCountry.Text = customerCountry1;
                textBoxCustomerPhone.Text = customerPhone;
            }

            using (U05EiVEntities cityContext = new U05EiVEntities())
            {
                var cityList = cityContext.cities.Select(c => new { 
                    Display = c.city1,
                    Value = c.cityId }).ToList();
                listBoxCustomerCity.DisplayMember = "Display";
                listBoxCustomerCity.ValueMember = "Value";
                listBoxCustomerCity.DataSource = cityList;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool canISave = allowCustomerCreation();
            bool isPhoneValid = ValidatePhoneNumber();
            bool isPostalCodeValid = ValidatePostalCode();

            if (canISave == false)
            {
                MessageBox.Show("Please enter information in all required fields");
            }
            else if (isPostalCodeValid == false)
            {
                MessageBox.Show("Postal codes can only contain 1-9 and -");
            }
            else if (isPhoneValid == false)
            {
                MessageBox.Show("Phone numbers can only contain 1-9, '-', '+', '(', ')', and '.'. Please use a common Phone Number format. ");
            }
            else
            {
                using (var customerSave = new U05EiVEntities())
                {
                    int customerId = customerSave.customers.FirstOrDefault(customer => customer.customerId == Helper.CurrentCustomerId).customerId;
                    int customerAddressId = customerSave.customers.FirstOrDefault(customer => customer.customerId == Helper.CurrentCustomerId).addressId;
                    int customerCityId = customerSave.addresses.FirstOrDefault(address => address.addressId == customerAddressId).cityId;
                    // string customerCountryId = customerSave.cities.FirstOrDefault(city => city.cityId == customerCityId).countryId.ToString();

                    customerSave.customers.FirstOrDefault(customer => customer.customerId == Helper.CurrentCustomerId).customerName = textBoxCustomerName.Text;
                    customerSave.customers.FirstOrDefault(customer => customer.customerId == Helper.CurrentCustomerId).active = checkBoxActive.Checked;
                    customerSave.addresses.FirstOrDefault(address => address.addressId == customerAddressId).address1 = textBoxCustomerAddress1.Text;
                    customerSave.addresses.FirstOrDefault(address => address.addressId == customerAddressId).address2 = textBoxCustomerAddress2.Text;
                    customerSave.addresses.FirstOrDefault(address => address.addressId == customerAddressId).postalCode = textBoxCustomerPostalCode.Text;
                    customerSave.addresses.FirstOrDefault(address => address.addressId == customerAddressId).phone = textBoxCustomerPhone.Text;
                    customerSave.addresses.FirstOrDefault(address => address.cityId == customerCityId).cityId = Convert.ToInt32(listBoxCustomerCity.SelectedValue);

                    customerSave.SaveChanges();
                }

                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
        }

        private void checkBoxActive_CheckedChanged(object sender, EventArgs e)
        {
            checkChanged = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void UpdateCustomerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
