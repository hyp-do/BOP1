using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___BOP1
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            switch (Helper.ReportType)
            {
                case 0:
                    labelReport.Text = "Number of Appointment Types";
                    using (var reportContext = new U05EiVEntities())
                    {

                        DataTable appointmentTypeTable = reportContext.DataTable("SELECT MONTH(start) as Month, COUNT(type) as 'Meeting Type', type as Type FROM appointment GROUP BY MONTH(start), type");

                        DataTable appointmentTypeTableClone = appointmentTypeTable.Clone();
                        appointmentTypeTableClone.Columns[0].DataType = typeof(string);
                        appointmentTypeTableClone.Columns[1].DataType = typeof(string);
                        appointmentTypeTableClone.Columns[2].DataType = typeof(string);

                        foreach (DataRow row in appointmentTypeTable.Rows)
                        {
                            appointmentTypeTableClone.ImportRow(row);
                        }

                        foreach (DataRow row in appointmentTypeTableClone.Rows)
                        {
                            if (row["Month"].ToString() == "1")
                            {
                                row["Month"] = "January";
                            }
                            else if (row["Month"].ToString() == "2")
                            {
                                row["Month"] = "February";
                            }
                            else if (row["Month"].ToString() == "3")
                            {
                                row["Month"] = "March";
                            }
                            else if (row["Month"].ToString() == "4")
                            {
                                row["Month"] = "April";
                            }
                            else if (row["Month"].ToString() == "5")
                            {
                                row["Month"] = "May";
                            }
                            else if (row["Month"].ToString() == "6")
                            {
                                row["Month"] = "June";
                            }
                            else if (row["Month"].ToString() == "7")
                            {
                                row["Month"] = "July";
                            }
                            else if (row["Month"].ToString() == "8")
                            {
                                row["Month"] = "August";
                            }
                            else if (row["Month"].ToString() == "9")
                            {
                                row["Month"] = "September";
                            }
                            else if (row["Month"].ToString() == "10")
                            {
                                row["Month"] = "October";
                            }
                            else if (row["Month"].ToString() == "11")
                            {
                                row["Month"] = "November";
                            }
                            else if (row["Month"].ToString() == "12")
                            {
                                row["Month"] = "December";
                            }
                        }
                        dgvReport.DataSource = appointmentTypeTableClone;
                    }

                    break;
                case 1:
                    labelReport.Text = "Consultant Schedule";

                    using (var reportContext = new U05EiVEntities())
                    {
                        var consultantScheduleList = reportContext.users.Join(reportContext.appointments,

                            consultant => consultant.userId,
                            appointment => appointment.userId,
                            (consultant, appointment) =>
                            new
                            {
                                Consultant = consultant.userName,
                                Appointment = appointment.start,
                                Contact = appointment.contact,
                                Locaiton = appointment.location

                            }).ToList();

                        dgvReport.DataSource = consultantScheduleList;
                    }
                    break;
                case 2:
                    labelReport.Text = "Number of Appointments per Customer";

                    using (var reportContext = new U05EiVEntities())
                    {
                        var customerList = reportContext.customers.GroupJoin(reportContext.appointments,
                            customer => customer.customerId,
                            appointment => appointment.customerId,
                            (customer, appointment) =>
                            new
                            {
                                Customer = customer.customerName,
                                Appointments = appointment.Count()
                            }).ToList();

                        dgvReport.DataSource = customerList;
                    }
                    break;
                default:
                    labelReport.Text = "Number of Appointment Types";
                    break;
            }
        }

        private void ReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            var mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
