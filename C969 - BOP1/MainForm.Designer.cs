namespace C969___BOP1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.buttonAddCustomer = new System.Windows.Forms.Button();
            this.buttonUpdateCustomer = new System.Windows.Forms.Button();
            this.buttonDeleteCustomer = new System.Windows.Forms.Button();
            this.groupBoxCustomers = new System.Windows.Forms.GroupBox();
            this.comboBoxReports = new System.Windows.Forms.ComboBox();
            this.groupBoxReports = new System.Windows.Forms.GroupBox();
            this.buttonViewReport = new System.Windows.Forms.Button();
            this.labelMainForm = new System.Windows.Forms.Label();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.buttonAddAppointment = new System.Windows.Forms.Button();
            this.buttonUpdateAppointment = new System.Windows.Forms.Button();
            this.buttonDeleteAppointment = new System.Windows.Forms.Button();
            this.comboBoxMonthOrWeek = new System.Windows.Forms.ComboBox();
            this.groupBoxAppointments = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.groupBoxCustomers.SuspendLayout();
            this.groupBoxReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.groupBoxAppointments.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(6, 19);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(405, 163);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            this.dgvCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellDoubleClick);
            // 
            // buttonAddCustomer
            // 
            this.buttonAddCustomer.Location = new System.Drawing.Point(174, 189);
            this.buttonAddCustomer.Name = "buttonAddCustomer";
            this.buttonAddCustomer.Size = new System.Drawing.Size(75, 23);
            this.buttonAddCustomer.TabIndex = 3;
            this.buttonAddCustomer.Text = "Add";
            this.buttonAddCustomer.UseVisualStyleBackColor = true;
            this.buttonAddCustomer.Click += new System.EventHandler(this.buttonAddCustomer_Click);
            // 
            // buttonUpdateCustomer
            // 
            this.buttonUpdateCustomer.Location = new System.Drawing.Point(255, 189);
            this.buttonUpdateCustomer.Name = "buttonUpdateCustomer";
            this.buttonUpdateCustomer.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateCustomer.TabIndex = 4;
            this.buttonUpdateCustomer.Text = "Update";
            this.buttonUpdateCustomer.UseVisualStyleBackColor = true;
            this.buttonUpdateCustomer.Click += new System.EventHandler(this.buttonUpdateCustomer_Click);
            // 
            // buttonDeleteCustomer
            // 
            this.buttonDeleteCustomer.Location = new System.Drawing.Point(336, 189);
            this.buttonDeleteCustomer.Name = "buttonDeleteCustomer";
            this.buttonDeleteCustomer.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteCustomer.TabIndex = 5;
            this.buttonDeleteCustomer.Text = "Delete";
            this.buttonDeleteCustomer.UseVisualStyleBackColor = true;
            this.buttonDeleteCustomer.Click += new System.EventHandler(this.buttonDeleteCustomer_Click);
            // 
            // groupBoxCustomers
            // 
            this.groupBoxCustomers.Controls.Add(this.dgvCustomers);
            this.groupBoxCustomers.Controls.Add(this.buttonDeleteCustomer);
            this.groupBoxCustomers.Controls.Add(this.buttonAddCustomer);
            this.groupBoxCustomers.Controls.Add(this.buttonUpdateCustomer);
            this.groupBoxCustomers.Location = new System.Drawing.Point(12, 58);
            this.groupBoxCustomers.Name = "groupBoxCustomers";
            this.groupBoxCustomers.Size = new System.Drawing.Size(449, 227);
            this.groupBoxCustomers.TabIndex = 6;
            this.groupBoxCustomers.TabStop = false;
            this.groupBoxCustomers.Text = "Customers";
            // 
            // comboBoxReports
            // 
            this.comboBoxReports.FormattingEnabled = true;
            this.comboBoxReports.Items.AddRange(new object[] {
            "Number of Appointment Types",
            "Consultant Schedule",
            "Number of Appointments per Customer"});
            this.comboBoxReports.Location = new System.Drawing.Point(22, 24);
            this.comboBoxReports.Name = "comboBoxReports";
            this.comboBoxReports.Size = new System.Drawing.Size(174, 21);
            this.comboBoxReports.TabIndex = 8;
            // 
            // groupBoxReports
            // 
            this.groupBoxReports.Controls.Add(this.buttonViewReport);
            this.groupBoxReports.Controls.Add(this.comboBoxReports);
            this.groupBoxReports.Location = new System.Drawing.Point(495, 77);
            this.groupBoxReports.Name = "groupBoxReports";
            this.groupBoxReports.Size = new System.Drawing.Size(217, 104);
            this.groupBoxReports.TabIndex = 9;
            this.groupBoxReports.TabStop = false;
            this.groupBoxReports.Text = "Reports";
            // 
            // buttonViewReport
            // 
            this.buttonViewReport.Location = new System.Drawing.Point(66, 65);
            this.buttonViewReport.Name = "buttonViewReport";
            this.buttonViewReport.Size = new System.Drawing.Size(75, 23);
            this.buttonViewReport.TabIndex = 9;
            this.buttonViewReport.Text = "View Report";
            this.buttonViewReport.UseVisualStyleBackColor = true;
            this.buttonViewReport.Click += new System.EventHandler(this.buttonViewReport_Click);
            // 
            // labelMainForm
            // 
            this.labelMainForm.AutoSize = true;
            this.labelMainForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMainForm.Location = new System.Drawing.Point(13, 22);
            this.labelMainForm.Name = "labelMainForm";
            this.labelMainForm.Size = new System.Drawing.Size(351, 25);
            this.labelMainForm.TabIndex = 10;
            this.labelMainForm.Text = "Customer and Appointment Tracker";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Location = new System.Drawing.Point(16, 43);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersVisible = false;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(664, 197);
            this.dgvAppointments.TabIndex = 1;
            this.dgvAppointments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointments_CellClick);
            this.dgvAppointments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointments_CellDoubleClick);
            this.dgvAppointments.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAppointments_CellFormatting);
            // 
            // buttonAddAppointment
            // 
            this.buttonAddAppointment.Location = new System.Drawing.Point(439, 246);
            this.buttonAddAppointment.Name = "buttonAddAppointment";
            this.buttonAddAppointment.Size = new System.Drawing.Size(75, 29);
            this.buttonAddAppointment.TabIndex = 2;
            this.buttonAddAppointment.Text = "Add";
            this.buttonAddAppointment.UseVisualStyleBackColor = true;
            this.buttonAddAppointment.Click += new System.EventHandler(this.buttonAddAppointment_Click);
            // 
            // buttonUpdateAppointment
            // 
            this.buttonUpdateAppointment.Location = new System.Drawing.Point(520, 246);
            this.buttonUpdateAppointment.Name = "buttonUpdateAppointment";
            this.buttonUpdateAppointment.Size = new System.Drawing.Size(75, 29);
            this.buttonUpdateAppointment.TabIndex = 3;
            this.buttonUpdateAppointment.Text = "Update";
            this.buttonUpdateAppointment.UseVisualStyleBackColor = true;
            this.buttonUpdateAppointment.Click += new System.EventHandler(this.buttonUpdateAppointment_Click);
            // 
            // buttonDeleteAppointment
            // 
            this.buttonDeleteAppointment.Location = new System.Drawing.Point(605, 246);
            this.buttonDeleteAppointment.Name = "buttonDeleteAppointment";
            this.buttonDeleteAppointment.Size = new System.Drawing.Size(75, 29);
            this.buttonDeleteAppointment.TabIndex = 4;
            this.buttonDeleteAppointment.Text = "Delete";
            this.buttonDeleteAppointment.UseVisualStyleBackColor = true;
            this.buttonDeleteAppointment.Click += new System.EventHandler(this.buttonDeleteAppointment_Click);
            // 
            // comboBoxMonthOrWeek
            // 
            this.comboBoxMonthOrWeek.AllowDrop = true;
            this.comboBoxMonthOrWeek.FormattingEnabled = true;
            this.comboBoxMonthOrWeek.Items.AddRange(new object[] {
            "All",
            "Day",
            "Week",
            "Month"});
            this.comboBoxMonthOrWeek.Location = new System.Drawing.Point(16, 16);
            this.comboBoxMonthOrWeek.Name = "comboBoxMonthOrWeek";
            this.comboBoxMonthOrWeek.Size = new System.Drawing.Size(127, 21);
            this.comboBoxMonthOrWeek.TabIndex = 5;
            this.comboBoxMonthOrWeek.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonthOrWeek_SelectedIndexChanged);
            // 
            // groupBoxAppointments
            // 
            this.groupBoxAppointments.Controls.Add(this.comboBoxMonthOrWeek);
            this.groupBoxAppointments.Controls.Add(this.buttonDeleteAppointment);
            this.groupBoxAppointments.Controls.Add(this.buttonUpdateAppointment);
            this.groupBoxAppointments.Controls.Add(this.buttonAddAppointment);
            this.groupBoxAppointments.Controls.Add(this.dgvAppointments);
            this.groupBoxAppointments.Location = new System.Drawing.Point(12, 291);
            this.groupBoxAppointments.Name = "groupBoxAppointments";
            this.groupBoxAppointments.Size = new System.Drawing.Size(700, 294);
            this.groupBoxAppointments.TabIndex = 7;
            this.groupBoxAppointments.TabStop = false;
            this.groupBoxAppointments.Text = "Appointment Calendar";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 611);
            this.Controls.Add(this.labelMainForm);
            this.Controls.Add(this.groupBoxReports);
            this.Controls.Add(this.groupBoxAppointments);
            this.Controls.Add(this.groupBoxCustomers);
            this.Name = "MainForm";
            this.Text = "Customer and Appointment Tracker - C969 - BOP1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.groupBoxCustomers.ResumeLayout(false);
            this.groupBoxReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.groupBoxAppointments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button buttonAddCustomer;
        private System.Windows.Forms.Button buttonUpdateCustomer;
        private System.Windows.Forms.Button buttonDeleteCustomer;
        private System.Windows.Forms.GroupBox groupBoxCustomers;
        private System.Windows.Forms.ComboBox comboBoxReports;
        private System.Windows.Forms.GroupBox groupBoxReports;
        private System.Windows.Forms.Button buttonViewReport;
        private System.Windows.Forms.Label labelMainForm;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Button buttonAddAppointment;
        private System.Windows.Forms.Button buttonUpdateAppointment;
        private System.Windows.Forms.Button buttonDeleteAppointment;
        private System.Windows.Forms.ComboBox comboBoxMonthOrWeek;
        private System.Windows.Forms.GroupBox groupBoxAppointments;
    }
}

