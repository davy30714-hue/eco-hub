namespace UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label4 = new Label();
            label3 = new Label();
            textBoxRoles = new TextBox();
            buttonClearEmp = new Button();
            buttonHistoryEmp = new Button();
            buttonDeleteEmp = new Button();
            buttonEditEmp = new Button();
            buttonAddEmp = new Button();
            dataGridViewEmp = new DataGridView();
            buttonFindEmp = new Button();
            checkBoxAvailable = new CheckBox();
            textBoxSearchId = new TextBox();
            tabPage2 = new TabPage();
            label5 = new Label();
            textBoxIdEq = new TextBox();
            buttonClearEq = new Button();
            buttonReturnEq = new Button();
            buttonAssingEq = new Button();
            buttonDeleteEq = new Button();
            buttonEditEq = new Button();
            buttonAddEq = new Button();
            dataGridViewEq = new DataGridView();
            buttonFindEq = new Button();
            checkBoxAvailableEq = new CheckBox();
            checkBoxBrokenEq = new CheckBox();
            tabPage3 = new TabPage();
            label6 = new Label();
            buttonClearExp = new Button();
            buttonReportExp = new Button();
            buttonDeleteExp = new Button();
            buttonEditExp = new Button();
            buttonAddExp = new Button();
            dataGridViewExp = new DataGridView();
            buttonFindExp = new Button();
            checkBoxIsActive = new CheckBox();
            dateTimePickerEnd = new DateTimePicker();
            label2 = new Label();
            dateTimePickerStart = new DateTimePicker();
            label1 = new Label();
            tabPage4 = new TabPage();
            label8 = new Label();
            label7 = new Label();
            buttonClearLoc = new Button();
            buttonDeleteLoc = new Button();
            buttonEditLoc = new Button();
            buttonAddLoc = new Button();
            dataGridView3 = new DataGridView();
            buttonFindLoc = new Button();
            comboBoxLocType = new ComboBox();
            textBoxIdLoc = new TextBox();
            tabPage5 = new TabPage();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            labelStatistic = new Label();
            dateTimePickerMeasEnd = new DateTimePicker();
            textBoxLocIdMeas = new TextBox();
            buttonDeleteMeas = new Button();
            buttonEditMeas = new Button();
            buttonAddMeas = new Button();
            dataGridView4 = new DataGridView();
            buttonClearMeas = new Button();
            buttonFindMeas = new Button();
            dateTimePickerMeasStart = new DateTimePicker();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmp).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEq).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewExp).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(798, 471);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(192, 255, 192);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(textBoxRoles);
            tabPage1.Controls.Add(buttonClearEmp);
            tabPage1.Controls.Add(buttonHistoryEmp);
            tabPage1.Controls.Add(buttonDeleteEmp);
            tabPage1.Controls.Add(buttonEditEmp);
            tabPage1.Controls.Add(buttonAddEmp);
            tabPage1.Controls.Add(dataGridViewEmp);
            tabPage1.Controls.Add(buttonFindEmp);
            tabPage1.Controls.Add(checkBoxAvailable);
            tabPage1.Controls.Add(textBoxSearchId);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(790, 438);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Employees";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(155, 31);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 11;
            label4.Text = "Role:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 28);
            label3.Name = "label3";
            label3.Size = new Size(25, 20);
            label3.TabIndex = 10;
            label3.Text = "Id:";
            // 
            // textBoxRoles
            // 
            textBoxRoles.Location = new Point(154, 64);
            textBoxRoles.Name = "textBoxRoles";
            textBoxRoles.Size = new Size(125, 27);
            textBoxRoles.TabIndex = 9;
            // 
            // buttonClearEmp
            // 
            buttonClearEmp.Location = new Point(622, 64);
            buttonClearEmp.Name = "buttonClearEmp";
            buttonClearEmp.Size = new Size(128, 27);
            buttonClearEmp.TabIndex = 12;
            buttonClearEmp.Text = "Clear Filters";
            buttonClearEmp.UseVisualStyleBackColor = true;
            buttonClearEmp.Click += buttonClearEmp_Click;
            // 
            // buttonHistoryEmp
            // 
            buttonHistoryEmp.Location = new Point(8, 389);
            buttonHistoryEmp.Name = "buttonHistoryEmp";
            buttonHistoryEmp.Size = new Size(198, 29);
            buttonHistoryEmp.TabIndex = 8;
            buttonHistoryEmp.Text = "History of expeditions";
            buttonHistoryEmp.UseVisualStyleBackColor = true;
            buttonHistoryEmp.Click += buttonHistoryEmp_Click;
            // 
            // buttonDeleteEmp
            // 
            buttonDeleteEmp.Location = new Point(656, 303);
            buttonDeleteEmp.Name = "buttonDeleteEmp";
            buttonDeleteEmp.Size = new Size(94, 29);
            buttonDeleteEmp.TabIndex = 7;
            buttonDeleteEmp.Text = "Delete";
            buttonDeleteEmp.UseVisualStyleBackColor = true;
            buttonDeleteEmp.Click += buttonDeleteEmp_Click;
            // 
            // buttonEditEmp
            // 
            buttonEditEmp.Location = new Point(656, 217);
            buttonEditEmp.Name = "buttonEditEmp";
            buttonEditEmp.Size = new Size(94, 29);
            buttonEditEmp.TabIndex = 6;
            buttonEditEmp.Text = "Update";
            buttonEditEmp.UseVisualStyleBackColor = true;
            buttonEditEmp.Click += buttonEditEmp_Click;
            // 
            // buttonAddEmp
            // 
            buttonAddEmp.Location = new Point(656, 115);
            buttonAddEmp.Name = "buttonAddEmp";
            buttonAddEmp.Size = new Size(94, 29);
            buttonAddEmp.TabIndex = 5;
            buttonAddEmp.Text = "Add";
            buttonAddEmp.UseVisualStyleBackColor = true;
            buttonAddEmp.Click += buttonAddEmp_Click;
            // 
            // dataGridViewEmp
            // 
            dataGridViewEmp.BackgroundColor = Color.Honeydew;
            dataGridViewEmp.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridViewEmp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmp.Location = new Point(0, 97);
            dataGridViewEmp.Name = "dataGridViewEmp";
            dataGridViewEmp.RowHeadersWidth = 51;
            dataGridViewEmp.Size = new Size(634, 274);
            dataGridViewEmp.TabIndex = 4;
            dataGridViewEmp.DataBindingComplete += dataGridViewEmp_DataBindingComplete;
            // 
            // buttonFindEmp
            // 
            buttonFindEmp.Location = new Point(507, 64);
            buttonFindEmp.Name = "buttonFindEmp";
            buttonFindEmp.Size = new Size(94, 29);
            buttonFindEmp.TabIndex = 3;
            buttonFindEmp.Text = "Find";
            buttonFindEmp.UseVisualStyleBackColor = true;
            buttonFindEmp.Click += buttonFindEmp_Click;
            // 
            // checkBoxAvailable
            // 
            checkBoxAvailable.AutoSize = true;
            checkBoxAvailable.Location = new Point(322, 69);
            checkBoxAvailable.Name = "checkBoxAvailable";
            checkBoxAvailable.Size = new Size(93, 24);
            checkBoxAvailable.TabIndex = 2;
            checkBoxAvailable.Text = "Available";
            checkBoxAvailable.UseVisualStyleBackColor = true;
            // 
            // textBoxSearchId
            // 
            textBoxSearchId.Location = new Point(6, 64);
            textBoxSearchId.Name = "textBoxSearchId";
            textBoxSearchId.Size = new Size(125, 27);
            textBoxSearchId.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(192, 255, 192);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(textBoxIdEq);
            tabPage2.Controls.Add(buttonClearEq);
            tabPage2.Controls.Add(buttonReturnEq);
            tabPage2.Controls.Add(buttonAssingEq);
            tabPage2.Controls.Add(buttonDeleteEq);
            tabPage2.Controls.Add(buttonEditEq);
            tabPage2.Controls.Add(buttonAddEq);
            tabPage2.Controls.Add(dataGridViewEq);
            tabPage2.Controls.Add(buttonFindEq);
            tabPage2.Controls.Add(checkBoxAvailableEq);
            tabPage2.Controls.Add(checkBoxBrokenEq);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(790, 438);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Equipment";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 21);
            label5.Name = "label5";
            label5.Size = new Size(25, 20);
            label5.TabIndex = 11;
            label5.Text = "Id:";
            // 
            // textBoxIdEq
            // 
            textBoxIdEq.Location = new Point(27, 50);
            textBoxIdEq.Name = "textBoxIdEq";
            textBoxIdEq.Size = new Size(125, 27);
            textBoxIdEq.TabIndex = 10;
            // 
            // buttonClearEq
            // 
            buttonClearEq.Location = new Point(592, 47);
            buttonClearEq.Name = "buttonClearEq";
            buttonClearEq.Size = new Size(132, 29);
            buttonClearEq.TabIndex = 11;
            buttonClearEq.Text = "Clear Filters";
            buttonClearEq.UseVisualStyleBackColor = true;
            buttonClearEq.Click += buttonClearEq_Click;
            // 
            // buttonReturnEq
            // 
            buttonReturnEq.Location = new Point(573, 401);
            buttonReturnEq.Name = "buttonReturnEq";
            buttonReturnEq.Size = new Size(132, 29);
            buttonReturnEq.TabIndex = 9;
            buttonReturnEq.Text = "Return to base";
            buttonReturnEq.UseVisualStyleBackColor = true;
            buttonReturnEq.Click += buttonReturnEq_Click;
            // 
            // buttonAssingEq
            // 
            buttonAssingEq.Location = new Point(375, 401);
            buttonAssingEq.Name = "buttonAssingEq";
            buttonAssingEq.Size = new Size(166, 29);
            buttonAssingEq.TabIndex = 8;
            buttonAssingEq.Text = "Assign to employee";
            buttonAssingEq.UseVisualStyleBackColor = true;
            buttonAssingEq.Click += buttonAssingEq_Click;
            // 
            // buttonDeleteEq
            // 
            buttonDeleteEq.Location = new Point(236, 401);
            buttonDeleteEq.Name = "buttonDeleteEq";
            buttonDeleteEq.Size = new Size(94, 29);
            buttonDeleteEq.TabIndex = 7;
            buttonDeleteEq.Text = "Delete";
            buttonDeleteEq.UseVisualStyleBackColor = true;
            buttonDeleteEq.Click += buttonDeleteEq_Click;
            // 
            // buttonEditEq
            // 
            buttonEditEq.Location = new Point(124, 401);
            buttonEditEq.Name = "buttonEditEq";
            buttonEditEq.Size = new Size(94, 29);
            buttonEditEq.TabIndex = 6;
            buttonEditEq.Text = "Update";
            buttonEditEq.UseVisualStyleBackColor = true;
            buttonEditEq.Click += buttonEditEq_Click;
            // 
            // buttonAddEq
            // 
            buttonAddEq.Location = new Point(8, 401);
            buttonAddEq.Name = "buttonAddEq";
            buttonAddEq.Size = new Size(94, 29);
            buttonAddEq.TabIndex = 5;
            buttonAddEq.Text = "Add";
            buttonAddEq.UseVisualStyleBackColor = true;
            buttonAddEq.Click += buttonAddEq_Click;
            // 
            // dataGridViewEq
            // 
            dataGridViewEq.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEq.Location = new Point(3, 95);
            dataGridViewEq.Name = "dataGridViewEq";
            dataGridViewEq.RowHeadersWidth = 51;
            dataGridViewEq.Size = new Size(791, 277);
            dataGridViewEq.TabIndex = 4;
            dataGridViewEq.DataBindingComplete += dataGridViewEq_DataBindingComplete;
            // 
            // buttonFindEq
            // 
            buttonFindEq.Location = new Point(476, 47);
            buttonFindEq.Name = "buttonFindEq";
            buttonFindEq.Size = new Size(94, 29);
            buttonFindEq.TabIndex = 3;
            buttonFindEq.Text = "Find";
            buttonFindEq.UseVisualStyleBackColor = true;
            buttonFindEq.Click += button1_Click;
            // 
            // checkBoxAvailableEq
            // 
            checkBoxAvailableEq.AutoSize = true;
            checkBoxAvailableEq.Location = new Point(335, 52);
            checkBoxAvailableEq.Name = "checkBoxAvailableEq";
            checkBoxAvailableEq.Size = new Size(93, 24);
            checkBoxAvailableEq.TabIndex = 2;
            checkBoxAvailableEq.Text = "Available";
            checkBoxAvailableEq.UseVisualStyleBackColor = true;
            // 
            // checkBoxBrokenEq
            // 
            checkBoxBrokenEq.AutoSize = true;
            checkBoxBrokenEq.Location = new Point(209, 53);
            checkBoxBrokenEq.Name = "checkBoxBrokenEq";
            checkBoxBrokenEq.Size = new Size(77, 24);
            checkBoxBrokenEq.TabIndex = 1;
            checkBoxBrokenEq.Text = "Broken";
            checkBoxBrokenEq.UseVisualStyleBackColor = true;
            checkBoxBrokenEq.Visible = false;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.FromArgb(192, 255, 192);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(buttonClearExp);
            tabPage3.Controls.Add(buttonReportExp);
            tabPage3.Controls.Add(buttonDeleteExp);
            tabPage3.Controls.Add(buttonEditExp);
            tabPage3.Controls.Add(buttonAddExp);
            tabPage3.Controls.Add(dataGridViewExp);
            tabPage3.Controls.Add(buttonFindExp);
            tabPage3.Controls.Add(checkBoxIsActive);
            tabPage3.Controls.Add(dateTimePickerEnd);
            tabPage3.Controls.Add(label2);
            tabPage3.Controls.Add(dateTimePickerStart);
            tabPage3.Controls.Add(label1);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(790, 438);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Expiditions";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 26);
            label6.Name = "label6";
            label6.Size = new Size(173, 20);
            label6.TabIndex = 12;
            label6.Text = "Filtering by time interval:";
            // 
            // buttonClearExp
            // 
            buttonClearExp.Location = new Point(652, 87);
            buttonClearExp.Name = "buttonClearExp";
            buttonClearExp.Size = new Size(120, 29);
            buttonClearExp.TabIndex = 13;
            buttonClearExp.Text = "Clear Filters";
            buttonClearExp.UseVisualStyleBackColor = true;
            buttonClearExp.Click += buttonClearExp_Click;
            // 
            // buttonReportExp
            // 
            buttonReportExp.Location = new Point(567, 392);
            buttonReportExp.Name = "buttonReportExp";
            buttonReportExp.Size = new Size(94, 29);
            buttonReportExp.TabIndex = 11;
            buttonReportExp.Text = "Report";
            buttonReportExp.UseVisualStyleBackColor = true;
            buttonReportExp.Click += buttonReportExp_Click;
            // 
            // buttonDeleteExp
            // 
            buttonDeleteExp.Location = new Point(242, 392);
            buttonDeleteExp.Name = "buttonDeleteExp";
            buttonDeleteExp.Size = new Size(94, 29);
            buttonDeleteExp.TabIndex = 9;
            buttonDeleteExp.Text = "Delete";
            buttonDeleteExp.UseVisualStyleBackColor = true;
            buttonDeleteExp.Click += buttonDeleteExp_Click;
            // 
            // buttonEditExp
            // 
            buttonEditExp.Location = new Point(122, 392);
            buttonEditExp.Name = "buttonEditExp";
            buttonEditExp.Size = new Size(94, 29);
            buttonEditExp.TabIndex = 8;
            buttonEditExp.Text = "Update";
            buttonEditExp.UseVisualStyleBackColor = true;
            buttonEditExp.Click += buttonEditExp_Click;
            // 
            // buttonAddExp
            // 
            buttonAddExp.Location = new Point(6, 392);
            buttonAddExp.Name = "buttonAddExp";
            buttonAddExp.Size = new Size(94, 29);
            buttonAddExp.TabIndex = 7;
            buttonAddExp.Text = "Add";
            buttonAddExp.UseVisualStyleBackColor = true;
            buttonAddExp.Click += buttonAddExp_Click;
            // 
            // dataGridViewExp
            // 
            dataGridViewExp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewExp.Location = new Point(-4, 147);
            dataGridViewExp.Name = "dataGridViewExp";
            dataGridViewExp.RowHeadersWidth = 51;
            dataGridViewExp.Size = new Size(794, 239);
            dataGridViewExp.TabIndex = 6;
            dataGridViewExp.DataBindingComplete += dataGridViewExp_DataBindingComplete;
            // 
            // buttonFindExp
            // 
            buttonFindExp.Location = new Point(540, 87);
            buttonFindExp.Name = "buttonFindExp";
            buttonFindExp.Size = new Size(94, 29);
            buttonFindExp.TabIndex = 5;
            buttonFindExp.Text = "Find";
            buttonFindExp.UseVisualStyleBackColor = true;
            buttonFindExp.Click += buttonFindExp_Click;
            // 
            // checkBoxIsActive
            // 
            checkBoxIsActive.AutoSize = true;
            checkBoxIsActive.Location = new Point(402, 92);
            checkBoxIsActive.Name = "checkBoxIsActive";
            checkBoxIsActive.Size = new Size(72, 24);
            checkBoxIsActive.TabIndex = 4;
            checkBoxIsActive.Text = "Active";
            checkBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(76, 114);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(250, 27);
            dateTimePickerEnd.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 114);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 2;
            label2.Text = "End:";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(76, 69);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(250, 27);
            dateTimePickerStart.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 67);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 0;
            label1.Text = "Start:";
            label1.Click += label1_Click;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.FromArgb(192, 255, 192);
            tabPage4.Controls.Add(label8);
            tabPage4.Controls.Add(label7);
            tabPage4.Controls.Add(buttonClearLoc);
            tabPage4.Controls.Add(buttonDeleteLoc);
            tabPage4.Controls.Add(buttonEditLoc);
            tabPage4.Controls.Add(buttonAddLoc);
            tabPage4.Controls.Add(dataGridView3);
            tabPage4.Controls.Add(buttonFindLoc);
            tabPage4.Controls.Add(comboBoxLocType);
            tabPage4.Controls.Add(textBoxIdLoc);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(790, 438);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Locations";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(199, 33);
            label8.Name = "label8";
            label8.Size = new Size(102, 20);
            label8.TabIndex = 8;
            label8.Text = "Location type:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 34);
            label7.Name = "label7";
            label7.Size = new Size(25, 20);
            label7.TabIndex = 7;
            label7.Text = "Id:";
            // 
            // buttonClearLoc
            // 
            buttonClearLoc.Location = new Point(560, 69);
            buttonClearLoc.Name = "buttonClearLoc";
            buttonClearLoc.Size = new Size(120, 29);
            buttonClearLoc.TabIndex = 9;
            buttonClearLoc.Text = "Clear Filters";
            buttonClearLoc.UseVisualStyleBackColor = true;
            buttonClearLoc.Click += buttonClearLoc_Click;
            // 
            // buttonDeleteLoc
            // 
            buttonDeleteLoc.Location = new Point(370, 376);
            buttonDeleteLoc.Name = "buttonDeleteLoc";
            buttonDeleteLoc.Size = new Size(94, 29);
            buttonDeleteLoc.TabIndex = 6;
            buttonDeleteLoc.Text = "Delete";
            buttonDeleteLoc.UseVisualStyleBackColor = true;
            buttonDeleteLoc.Click += buttonDeleteLoc_Click;
            // 
            // buttonEditLoc
            // 
            buttonEditLoc.Location = new Point(182, 376);
            buttonEditLoc.Name = "buttonEditLoc";
            buttonEditLoc.Size = new Size(94, 29);
            buttonEditLoc.TabIndex = 5;
            buttonEditLoc.Text = "Update";
            buttonEditLoc.UseVisualStyleBackColor = true;
            buttonEditLoc.Click += buttonEditLoc_Click;
            // 
            // buttonAddLoc
            // 
            buttonAddLoc.Location = new Point(8, 376);
            buttonAddLoc.Name = "buttonAddLoc";
            buttonAddLoc.Size = new Size(94, 29);
            buttonAddLoc.TabIndex = 4;
            buttonAddLoc.Text = "Add";
            buttonAddLoc.UseVisualStyleBackColor = true;
            buttonAddLoc.Click += buttonAddLoc_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(-4, 130);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(798, 221);
            dataGridView3.TabIndex = 3;
            dataGridView3.DataBindingComplete += dataGridView3_DataBindingComplete;
            // 
            // buttonFindLoc
            // 
            buttonFindLoc.Location = new Point(437, 71);
            buttonFindLoc.Name = "buttonFindLoc";
            buttonFindLoc.Size = new Size(94, 29);
            buttonFindLoc.TabIndex = 2;
            buttonFindLoc.Text = "Find";
            buttonFindLoc.UseVisualStyleBackColor = true;
            buttonFindLoc.Click += buttonFindLoc_Click;
            // 
            // comboBoxLocType
            // 
            comboBoxLocType.FormattingEnabled = true;
            comboBoxLocType.Location = new Point(200, 70);
            comboBoxLocType.Name = "comboBoxLocType";
            comboBoxLocType.Size = new Size(151, 28);
            comboBoxLocType.TabIndex = 1;
            // 
            // textBoxIdLoc
            // 
            textBoxIdLoc.Location = new Point(24, 71);
            textBoxIdLoc.Name = "textBoxIdLoc";
            textBoxIdLoc.Size = new Size(125, 27);
            textBoxIdLoc.TabIndex = 0;
            // 
            // tabPage5
            // 
            tabPage5.BackColor = Color.FromArgb(192, 255, 192);
            tabPage5.Controls.Add(label12);
            tabPage5.Controls.Add(label11);
            tabPage5.Controls.Add(label10);
            tabPage5.Controls.Add(label9);
            tabPage5.Controls.Add(labelStatistic);
            tabPage5.Controls.Add(dateTimePickerMeasEnd);
            tabPage5.Controls.Add(textBoxLocIdMeas);
            tabPage5.Controls.Add(buttonDeleteMeas);
            tabPage5.Controls.Add(buttonEditMeas);
            tabPage5.Controls.Add(buttonAddMeas);
            tabPage5.Controls.Add(dataGridView4);
            tabPage5.Controls.Add(buttonClearMeas);
            tabPage5.Controls.Add(buttonFindMeas);
            tabPage5.Controls.Add(dateTimePickerMeasStart);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(790, 438);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Measurements";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(178, 94);
            label12.Name = "label12";
            label12.Size = new Size(37, 20);
            label12.TabIndex = 15;
            label12.Text = "End:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(172, 46);
            label11.Name = "label11";
            label11.Size = new Size(43, 20);
            label11.TabIndex = 14;
            label11.Text = "Start:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(172, 26);
            label10.Name = "label10";
            label10.Size = new Size(173, 20);
            label10.TabIndex = 13;
            label10.Text = "Filtering by time interval:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 26);
            label9.Name = "label9";
            label9.Size = new Size(86, 20);
            label9.TabIndex = 9;
            label9.Text = "Location Id:";
            label9.Click += label9_Click;
            // 
            // labelStatistic
            // 
            labelStatistic.AutoSize = true;
            labelStatistic.Location = new Point(347, 395);
            labelStatistic.Name = "labelStatistic";
            labelStatistic.Size = new Size(64, 20);
            labelStatistic.TabIndex = 8;
            labelStatistic.Text = "Statistic:";
            // 
            // dateTimePickerMeasEnd
            // 
            dateTimePickerMeasEnd.Location = new Point(246, 119);
            dateTimePickerMeasEnd.Name = "dateTimePickerMeasEnd";
            dateTimePickerMeasEnd.Size = new Size(250, 27);
            dateTimePickerMeasEnd.TabIndex = 7;
            // 
            // textBoxLocIdMeas
            // 
            textBoxLocIdMeas.Location = new Point(16, 67);
            textBoxLocIdMeas.Name = "textBoxLocIdMeas";
            textBoxLocIdMeas.Size = new Size(125, 27);
            textBoxLocIdMeas.TabIndex = 6;
            // 
            // buttonDeleteMeas
            // 
            buttonDeleteMeas.Location = new Point(236, 391);
            buttonDeleteMeas.Name = "buttonDeleteMeas";
            buttonDeleteMeas.Size = new Size(94, 29);
            buttonDeleteMeas.TabIndex = 5;
            buttonDeleteMeas.Text = "Delete";
            buttonDeleteMeas.UseVisualStyleBackColor = true;
            buttonDeleteMeas.Click += buttonDeleteMeas_Click;
            // 
            // buttonEditMeas
            // 
            buttonEditMeas.Location = new Point(122, 391);
            buttonEditMeas.Name = "buttonEditMeas";
            buttonEditMeas.Size = new Size(94, 29);
            buttonEditMeas.TabIndex = 6;
            buttonEditMeas.Text = "Update";
            buttonEditMeas.UseVisualStyleBackColor = true;
            buttonEditMeas.Click += buttonEditMeas_Click;
            // 
            // buttonAddMeas
            // 
            buttonAddMeas.Location = new Point(8, 391);
            buttonAddMeas.Name = "buttonAddMeas";
            buttonAddMeas.Size = new Size(94, 29);
            buttonAddMeas.TabIndex = 4;
            buttonAddMeas.Text = "Add";
            buttonAddMeas.UseVisualStyleBackColor = true;
            buttonAddMeas.Click += buttonAddMeas_Click;
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new Point(0, 165);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.RowHeadersWidth = 51;
            dataGridView4.Size = new Size(798, 220);
            dataGridView4.TabIndex = 3;
            dataGridView4.DataBindingComplete += dataGridView4_DataBindingComplete;
            // 
            // buttonClearMeas
            // 
            buttonClearMeas.Location = new Point(578, 117);
            buttonClearMeas.Name = "buttonClearMeas";
            buttonClearMeas.Size = new Size(130, 29);
            buttonClearMeas.TabIndex = 16;
            buttonClearMeas.Text = "Clear Filters";
            buttonClearMeas.UseVisualStyleBackColor = true;
            buttonClearMeas.Click += buttonClearMeas_Click;
            // 
            // buttonFindMeas
            // 
            buttonFindMeas.Location = new Point(16, 117);
            buttonFindMeas.Name = "buttonFindMeas";
            buttonFindMeas.Size = new Size(94, 29);
            buttonFindMeas.TabIndex = 2;
            buttonFindMeas.Text = "Find";
            buttonFindMeas.UseVisualStyleBackColor = true;
            buttonFindMeas.Click += buttonFindMeas_Click;
            // 
            // dateTimePickerMeasStart
            // 
            dateTimePickerMeasStart.Location = new Point(246, 59);
            dateTimePickerMeasStart.Name = "dateTimePickerMeasStart";
            dateTimePickerMeasStart.Size = new Size(250, 27);
            dateTimePickerMeasStart.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 471);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "MainForm";
            Click += MainForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmp).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEq).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewExp).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private CheckBox checkBoxAvailable;
        private TextBox textBoxSearchId;
        private DataGridView dataGridViewEmp;
        private Button buttonFindEmp;
        private Button buttonHistoryEmp;
        private Button buttonDeleteEmp;
        private Button buttonEditEmp;
        private Button buttonAddEmp;
        private TextBox textBoxRoles;
        private Button buttonReturnEq;
        private Button buttonAssingEq;
        private Button buttonDeleteEq;
        private Button buttonEditEq;
        private Button buttonAddEq;
        private DataGridView dataGridViewEq;
        private Button buttonFindEq;
        private CheckBox checkBoxAvailableEq;
        private CheckBox checkBoxBrokenEq;
        private Button buttonReportExp;
        private Button buttonDeleteExp;
        private Button buttonEditExp;
        private Button buttonAddExp;
        private DataGridView dataGridViewExp;
        private Button buttonFindExp;
        private CheckBox checkBoxIsActive;
        private DateTimePicker dateTimePickerEnd;
        private Label label2;
        private DateTimePicker dateTimePickerStart;
        private Label label1;
        private Button buttonDeleteLoc;
        private Button buttonEditLoc;
        private Button buttonAddLoc;
        private DataGridView dataGridView3;
        private Button buttonFindLoc;
        private ComboBox comboBoxLocType;
        private TextBox textBoxIdLoc;
        private Button buttonDeleteMeas;
        private Button buttonEditMeas;
        private Button buttonAddMeas;
        private DataGridView dataGridView4;
        private Button buttonFindMeas;
        private DateTimePicker dateTimePickerMeasStart;
        private TextBox textBoxIdEq;
        private TextBox textBoxLocIdMeas;
        private Label labelStatistic;
        private DateTimePicker dateTimePickerMeasEnd;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label7;
        private Label label9;
        private Label label12;
        private Label label11;
        private Label label10;
        private Button buttonClearEmp;
        private Button buttonClearEq;
        private Button buttonClearExp;
        private Button buttonClearLoc;
        private Button buttonClearMeas;
    }
}
