using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___BOP1
{
    public partial class MainForm : Form
    {
        U05EiVEntities context = new U05EiVEntities();

        private int currentCustomerIndex = -1;

        private int currentAppointmentIndex = -1;

        DateTime currentDate;

        public MainForm()
        {
            InitializeComponent();

            currentDate = DateTime.UtcNow.Date;

            comboBoxMonthOrWeek.SelectedIndex = 0;

            context.customers.Load();
            BindingSource customerSource = new BindingSource();
            var customerBindingList = new BindingList<customer>(context.customers.Local.ToBindingList());
            customerSource.DataSource = customerBindingList;
            dgvCustomers.DataSource = customerSource;

            dgvCustomers.Columns["customerId"].HeaderText = "Customer ID";
            dgvCustomers.Columns["customerName"].HeaderText = "Name";
            dgvCustomers.Columns["addressId"].Visible = false;
            dgvCustomers.Columns["active"].HeaderText = "Active";
            dgvCustomers.Columns["createDate"].Visible = false;
            dgvCustomers.Columns["createdBy"].Visible = false;
            dgvCustomers.Columns["lastUpdate"].Visible = false;
            dgvCustomers.Columns["lastUpdateBy"].Visible = false;
            dgvCustomers.Columns["address"].Visible = false;
            dgvCustomers.Columns["appointments"].Visible = false;



            dgvAppointments.Columns["appointmentId"].HeaderText = "Appointment ID";
            dgvAppointments.Columns["customerId"].Visible = false;
            dgvAppointments.Columns["userId"].Visible = false;
            dgvAppointments.Columns["title"].HeaderText = "Title";
            dgvAppointments.Columns["description"].HeaderText = "Description";
            dgvAppointments.Columns["location"].HeaderText = "Location";
            dgvAppointments.Columns["contact"].HeaderText = "Coanct";
            dgvAppointments.Columns["type"].HeaderText = "Type";
            dgvAppointments.Columns["url"].HeaderText = "Url";
            dgvAppointments.Columns["start"].HeaderText = "Start";
            dgvAppointments.Columns["end"].HeaderText = "End";
            dgvAppointments.Columns["createDate"].Visible = false;
            dgvAppointments.Columns["createdBy"].Visible = false;
            dgvAppointments.Columns["lastUpdate"].Visible = false;
            dgvAppointments.Columns["lastUpdateBy"].Visible = false;
            dgvAppointments.Columns["customer"].Visible = false;
            dgvAppointments.Columns["user"].Visible = false;

            


            Helper.ReportType = -1;
            comboBoxReports.SelectedIndex = 0;
        }

        private void calendarDisplayDay()
        {
            using (var dayContext = new U05EiVEntities())
            {
                var appointmentDay = dayContext.appointments.SqlQuery("SELECT * FROM appointment WHERE DATE(start) = DATE(CURDATE());").ToList();
                dgvAppointments.DataSource = appointmentDay;

            }

        }

        private void calendarDisplayWeek()
        {
    

            using (var weekContext = new U05EiVEntities())
            {
                var appointmentWeek = weekContext.appointments.SqlQuery("SELECT * FROM appointment WHERE WEEK(start) = WEEK(CURDATE());").ToList();
                dgvAppointments.DataSource = appointmentWeek;
            }
        }

        private void calendarDisplayMonth()
        {
 

            using (var monthContext = new U05EiVEntities())
            {
                var appointmentMonth = monthContext.appointments.SqlQuery("SELECT * FROM appointment WHERE MONTH(start) = MONTH(CURDATE());").ToList();
                dgvAppointments.DataSource = appointmentMonth;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            appointmentReminder(dgvAppointments);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        static void appointmentReminder(DataGridView appointmentCalendar)
        {
            foreach (DataGridViewRow row in appointmentCalendar.Rows)
            {
                DateTime timeOfLogIn = DateTime.UtcNow.ToLocalTime();
                DateTime appointmentStart = DateTime.Parse(row.Cells[9].Value.ToString()).ToLocalTime();
                TimeSpan timeUntilAppointment = timeOfLogIn - appointmentStart;
                if (timeUntilAppointment.TotalMinutes >= -15 && timeUntilAppointment.TotalMinutes < 1)
                {
                    MessageBox.Show($"Reminder: You have an upcoming meeting with {row.Cells[6].Value.ToString()} at {DateTime.Parse(row.Cells[9].Value.ToString()).ToLocalTime().ToString()}");
                }
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentCustomerIndex = dgvCustomers.CurrentCell.RowIndex;

            Helper.CurrentCustomerId = (int)dgvCustomers.Rows[currentCustomerIndex].Cells[0].Value; 
        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentAppointmentIndex = dgvAppointments.CurrentCell.RowIndex;

            Helper.CurrentAppointmentId = (int)dgvAppointments.Rows[currentAppointmentIndex].Cells[0].Value;
        }

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomer = new AddCustomerForm();
            this.Hide();
            addCustomer.Show();
        }

        private void buttonUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (currentCustomerIndex >= 0)
            {
                UpdateCustomerForm updateCustomer = new UpdateCustomerForm();
                this.Hide();
                updateCustomer.Show();
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }

        private void buttonDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (currentCustomerIndex >= 0)
            {
                using (var deleteCustomer = new U05EiVEntities())
                {
                    int customerId = deleteCustomer.customers.FirstOrDefault(customer => customer.customerId == Helper.CurrentCustomerId).customerId;
                    int customerAddressId = deleteCustomer.customers.FirstOrDefault(customer => customer.customerId == Helper.CurrentCustomerId).addressId;
                    int customerCityId = deleteCustomer.addresses.FirstOrDefault(address => address.addressId == customerAddressId).cityId;
                    int customerCountryId = deleteCustomer.cities.FirstOrDefault(city => city.cityId == customerCityId).countryId;

                    var customerToBeDeleted = deleteCustomer.customers.FirstOrDefault(c => c.customerId == Helper.CurrentCustomerId);
                    var addressToBeDeleted = deleteCustomer.addresses.FirstOrDefault(c => c.addressId == Helper.CurrentCustomerId);
                    var cityToBeDeleted = deleteCustomer.cities.FirstOrDefault(c => c.cityId == Helper.CurrentCustomerId);
                    var countryToBeDeleted = deleteCustomer.countries.FirstOrDefault(c => c.countryId == Helper.CurrentCustomerId);

                    deleteCustomer.customers.Remove(customerToBeDeleted);

                    deleteCustomer.SaveChanges();
                }

                context = new U05EiVEntities();
                context.customers.Load();
                BindingSource customerSource = new BindingSource();
                var customerBindingList = new BindingList<customer>(context.customers.Local.ToBindingList());
                customerSource.DataSource = customerBindingList;

                dgvCustomers.DataSource = customerSource;
                dgvCustomers.Update();
                dgvCustomers.Refresh();
            }
        }

        private void buttonAddAppointment_Click(object sender, EventArgs e)
        {
            AddAppointmentForm addAppointment = new AddAppointmentForm();
            this.Hide();
            addAppointment.Show();
        }

        private void buttonUpdateAppointment_Click(object sender, EventArgs e)
        {
            if (currentAppointmentIndex >= 0)
            {
                UpdateAppointmentForm updateAppointment = new UpdateAppointmentForm();
               this.Hide();
                updateAppointment.Show();
            }
            else
            {
                MessageBox.Show("Please select an appointment to update.");
            }
        }

        private void buttonDeleteAppointment_Click(object sender, EventArgs e)
        {
            if (currentAppointmentIndex >= 0)
            {
                using (var deleteAppointment = new U05EiVEntities())
                {
                    int appointmentId = deleteAppointment.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).appointmentId;

                    var appointmentToBeDeleted = deleteAppointment.appointments.FirstOrDefault(c => c.appointmentId == Helper.CurrentAppointmentId);

                    deleteAppointment.appointments.Remove(appointmentToBeDeleted);

                    deleteAppointment.SaveChanges();
                }

                if (comboBoxMonthOrWeek.SelectedIndex == 0)
                {
                    dgvAppointments.Refresh();
                    context.appointments.Load();
                    BindingSource appointmentSource = new BindingSource();
                    var appointmentBindingList = new BindingList<appointment>(context.appointments.Local.ToBindingList());
                    appointmentSource.DataSource = appointmentBindingList;
                    dgvAppointments.DataSource = appointmentSource;
                }
                else if (comboBoxMonthOrWeek.SelectedIndex == 1)
                {
                    calendarDisplayDay();
                }
                else if (comboBoxMonthOrWeek.SelectedIndex == 2)
                {
                    calendarDisplayWeek();
                }
                else if (comboBoxMonthOrWeek.SelectedIndex == 3)
                {
                    calendarDisplayMonth();
                }
            }
        }

        private void dgvAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                DateTime value = (DateTime)e.Value;
                switch (value.Kind)
                {
                    case DateTimeKind.Local:
                        break;
                    case DateTimeKind.Unspecified:
                        e.Value = DateTime.SpecifyKind(value, DateTimeKind.Utc).ToLocalTime();
                        break;
                    case DateTimeKind.Utc:
                        e.Value = value.ToLocalTime();
                        break;
                }
            }
        }

        private void buttonViewReport_Click(object sender, EventArgs e)
        {
            switch (comboBoxReports.SelectedIndex)
            {
                case 0:
                    Helper.ReportType = 0;
                    break;
                case 1:
                    Helper.ReportType = 1;
                    break;
                case 2:
                    Helper.ReportType = 2;
                    break;
            }
            var reportForm = new ReportForm();
            this.Hide();
            reportForm.Show();
        }

        private void comboBoxMonthOrWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new U05EiVEntities())
            {
                context.appointments.Load();
                BindingSource appointmentSource = new BindingSource();
                var appointmentBindingList = new BindingList<appointment>(context.appointments.Local.ToBindingList());

                if (comboBoxMonthOrWeek.SelectedIndex == 0)
                {

                    appointmentSource.DataSource = appointmentBindingList;  
                    dgvAppointments.DataSource = appointmentSource;

                }
                else if (comboBoxMonthOrWeek.SelectedIndex == 1)
                {
                    calendarDisplayDay();
                }
                else if (comboBoxMonthOrWeek.SelectedIndex == 2)
                {
                    calendarDisplayWeek();
                }
                else if (comboBoxMonthOrWeek.SelectedIndex == 3)
                {
                    calendarDisplayMonth();
                }
            }
        }

        private void dgvAppointments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currentAppointmentIndex >= 0)
            {
                UpdateAppointmentForm updateAppointment = new UpdateAppointmentForm();
                this.Hide();
                updateAppointment.Show();
            }
            else
            {
                MessageBox.Show("Please select an appointment to update.");
            }
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currentCustomerIndex >= 0)
            {
                UpdateCustomerForm updateCustomer = new UpdateCustomerForm();
                this.Hide();
                updateCustomer.Show();
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }
    }
}
