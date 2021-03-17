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
    public partial class UpdateAppointmentForm : Form
    {
        public UpdateAppointmentForm()
        {
            InitializeComponent();

            using (var contextCombo = new U05EiVEntities())
            {
                int customerId = contextCombo.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).customerId;
            }

            using (var updateAppointments = new U05EiVEntities())
            {
                int appointmentId = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).appointmentId;
                int userId = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).userId;
                int customerId = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).customerId;

                var appointmentTitle = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).title;
                string appointmentDescription = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).description;
                string appointmentCustomer = updateAppointments.customers.FirstOrDefault(customer => customer.customerId == customerId).customerName;
                string appointmentLocation = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).location;
                string appointmentContact = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).contact;
                string appointmentType = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).type;
                string appointmentUrl = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).url;
                var appointmentStart = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).start;
                var appointmentEnd = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).end;
                var appointmentCreateDate = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).createDate;
                var appointmentCreatedBy = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).createdBy;
                var appointmentLastUpdate = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).lastUpdate;
                var appointmentLastUpdateBy = updateAppointments.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).lastUpdateBy;

                textBoxAppointmentTitle.Text = appointmentTitle;
                richTextBoxAppointmentDescription.Text = appointmentDescription;
                textBoxAppointmentCustomer.Text = appointmentCustomer;
                textBoxAppointmentLocation.Text = appointmentLocation;
                textBoxAppointmentContact.Text = appointmentContact;
                textBoxAppointmentType.Text = appointmentType;
                textBoxAppointmentUrl.Text = appointmentUrl;
                datePickerAppointmentDate.Value = appointmentStart.Date;
                dateTimePickerAppointmentStart.Value = appointmentStart.ToLocalTime();
                dateTimePickerAppointmentEnd.Value = appointmentEnd.ToLocalTime();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (var saveUpdates = new U05EiVEntities())
            {
                int updateAppointmentId = saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).appointmentId;
                int updateUserId = saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).userId;
                int updateCustomerId = saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).customerId;

                DateTime dateTimeStart = datePickerAppointmentDate.Value.Date + dateTimePickerAppointmentStart.Value.TimeOfDay;
                DateTime dateTimeEnd = datePickerAppointmentDate.Value.Date + dateTimePickerAppointmentEnd.Value.TimeOfDay;

                saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).appointmentId = updateAppointmentId;
                //saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).customerId = Convert.ToInt32(comboBoxCustomer.SelectedValue);
                saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).description = richTextBoxAppointmentDescription.Text;
                saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).location = textBoxAppointmentLocation.Text;
                saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).contact = textBoxAppointmentContact.Text;
                saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).type = textBoxAppointmentType.Text;
                saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).url = textBoxAppointmentUrl.Text;
                saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).start = dateTimeStart.ToUniversalTime();
                saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).end = dateTimeEnd.ToUniversalTime();
               //saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).createDate = DateTime.Now;
                //saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).createdBy = Helper.CurrentUser;
                //saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).lastUpdate = DateTime.UtcNow;
                saveUpdates.appointments.FirstOrDefault(appointment => appointment.appointmentId == Helper.CurrentAppointmentId).lastUpdateBy = Helper.CurrentUser;

                try
                {
                    saveUpdates.SaveChanges();
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void UpdateAppointmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
