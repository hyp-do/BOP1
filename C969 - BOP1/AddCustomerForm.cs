using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___BOP1
{
    public partial class AddCustomerForm : Form
    {
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

        public AddCustomerForm()
        {
            InitializeComponent();

            using (var contextCombo = new U05EiVEntities())
            {
                var cityList = contextCombo.cities.Select(c => new {
                    Display = c.city1,
                    Value = c.cityId
                    }).ToList(); // Replaces a foreach statement and SQL query for city and cityId. 
                listBoxCustomerCity.DisplayMember = "Display";
                listBoxCustomerCity.ValueMember = "Value";
                listBoxCustomerCity.DataSource = cityList;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool canISave = allowCustomerCreation();
            bool isPhoneReal = ValidatePhoneNumber();
            bool isPostalCodeReal = ValidatePostalCode();
              
            if (canISave == false)
            {
                MessageBox.Show("Please enter information in all required fields");
            }
            else if (isPostalCodeReal == false)
            {
                MessageBox.Show("Postal codes can only contain 1-9 and -");
            }
            else if (isPhoneReal == false)
            {
                MessageBox.Show("Phone numbers can only contain 1-9, '-', '+', '(', ')', and '.'. Please use a common Phone Number format. ");
            }
            else 
            {
                int newAddressId = Helper.CreateAddressId();

                using (var customerCreate = new U05EiVEntities())
                {
                    var customer = new customer()
                    {
                        customerId = Helper.CreateCustomerId(),
                        customerName = textBoxCustomerName.Text.ToString(),
                        addressId = newAddressId,
                        active = true,
                        createDate = DateTime.Parse(Helper.createTimeStamp()),
                        createdBy = Helper.CurrentUser,
                        lastUpdate = DateTime.Parse(Helper.createTimeStamp()),
                        lastUpdateBy = Helper.CurrentUser
                    };

                    var address = new address()
                    {
                        addressId = newAddressId,
                        address1 = textBoxCustomerAddress1.Text,
                        address2 = textBoxCustomerAddress2.Text,
                        postalCode = textBoxCustomerPostalCode.Text,
                        phone = textBoxCustomerPhone.Text,
                        cityId = Convert.ToInt32(listBoxCustomerCity.SelectedValue),
                        createDate = DateTime.Parse(Helper.createTimeStamp()),
                        createdBy = Helper.CurrentUser,
                        lastUpdate = DateTime.Parse(Helper.createTimeStamp()),
                        lastUpdateBy = Helper.CurrentUser
                    };

                    try
                    {
                        customerCreate.addresses.Add(address);
                        customerCreate.customers.Add(customer);
                        customerCreate.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var eve in ex.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw;
                    }
                }

                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void AddCustomerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
