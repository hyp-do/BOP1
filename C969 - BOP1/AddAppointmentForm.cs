using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___BOP1
{
    public partial class AddAppointmentForm : Form
    {
        public AddAppointmentForm()
        {
            InitializeComponent();

            using (var contextCombo = new U05EiVEntities())
            {
                var customerList = contextCombo.customers.Select(c => new {
                    Display = c.customerName,
                    Value = c.customerId
                    }).ToList();
                comboBoxCustomer.DisplayMember = "Display";
                comboBoxCustomer.ValueMember = "Value";
                comboBoxCustomer.DataSource = customerList;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool saveSuccess = false;
            int newAppointmentId = Helper.CreateAppointmentId();

            int appointmentUserId = Helper.CurrentUserId(Helper.CurrentUser);

            DateTime dateTimeStart = datePickerAppointmentDate.Value.Date + dateTimePickerAppointmentStart.Value.TimeOfDay;
            DateTime dateTimeEnd = datePickerAppointmentDate.Value.Date + dateTimePickerAppointmentEnd.Value.TimeOfDay;

            dateTimeStart = dateTimeStart.ToUniversalTime();
            dateTimeEnd = dateTimeEnd.ToUniversalTime();

            using (var appointmentCreate = new U05EiVEntities())
            {
                var appointment = new appointment()
                {
                    appointmentId = newAppointmentId,
                    customerId = Convert.ToInt32(comboBoxCustomer.SelectedValue),
                    userId = Helper.CurrentUserId(Helper.CurrentUser),
                    title = textBoxAppointmentTitle.Text,
                    description = richTextBoxAppointmentDescription.Text,
                    location = textBoxAppointmentLocation.Text,
                    contact = textBoxAppointmentContact.Text,
                    type = textBoxAppointmentType.Text,
                    url = textBoxAppointmentUrl.Text,
                    start = dateTimeStart.ToUniversalTime(),
                    end = dateTimeEnd.ToUniversalTime(),
                    createDate = DateTime.Now,
                    createdBy = Helper.CurrentUser,
                    lastUpdate = DateTime.Now,
                    lastUpdateBy = Helper.CurrentUser,
                };

                try
                {
                    if (Helper.doesAppointmentOverlap(dateTimeStart, dateTimeEnd, appointmentUserId))
                    {
                        throw new AppointmentTimeException();
                    }

                    try
                    {
                        if (Helper.isAppointmentOutsideBusinessHours(dateTimeStart, dateTimeEnd))
                        {
                            throw new AppointmentTimeException();
                        }

                        try
                        {
                            appointmentCreate.appointments.Add(appointment);
                            appointmentCreate.SaveChanges();
                            saveSuccess = true;
                        }
                        catch (DbEntityValidationException ex)
                        {
                            saveSuccess = false;
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
                    catch (AppointmentTimeException ex)
                    {
                        saveSuccess = false;
                        ex.businessHoursException();
                    }
                }
                catch (AppointmentTimeException ex)
                {
                    saveSuccess = false;
                    ex.overlappingAppointmentException();
                }
            }
            if (saveSuccess == true)
            {
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

        private void AddAppointmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
             mainForm.Show();
        }
    }
}
