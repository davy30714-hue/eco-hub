using System;
using System.Drawing;
using System.Windows.Forms;
using Data.Models;
using UI.ViewModels;
using Services;

namespace UI
{
    public partial class MainForm : Form
    {
        private EmployeesViewModel _empVM;
        private EquipmentViewModel _equipVM;
        private ExpeditionViewModel _expVM;
        private LocationViewModel _locVM;
        private MeasurementViewModel _measVM;

        public MainForm(
            EmployeeService empService,
            EquipmentService equipService,
            ExpeditionService expService,
            LocationService locService,
            MeasurementService measService)
        {
            InitializeComponent();

            _empVM = new EmployeesViewModel(empService);
            _equipVM = new EquipmentViewModel(equipService);
            _expVM = new ExpeditionViewModel(expService);
            _locVM = new LocationViewModel(locService);
            _measVM = new MeasurementViewModel(measService);

            dataGridViewEmp.DataSource = _empVM.EmployeesList;
            dataGridViewEq.DataSource = _equipVM.EquipmentList;
            dataGridViewExp.DataSource = _expVM.ExpeditionList;
            dataGridView3.DataSource = _locVM.LocationList;
            dataGridView4.DataSource = _measVM.MeasurementList;

            ConfigureEditableGrid(dataGridViewEmp);
            ConfigureEditableGrid(dataGridViewEq);
            ConfigureEditableGrid(dataGridViewExp);
            ConfigureEditableGrid(dataGridView3);
            ConfigureEditableGrid(dataGridView4);

            _empVM.LoadData();
            _equipVM.LoadData();
            _expVM.LoadData();
            _locVM.LoadData();
            _measVM.LoadData();

            if (comboBoxLocType.Items.Count == 0) comboBoxLocType.Items.AddRange(new string[] { "Ліс", "Річка", "Озеро", "Степ" });
        }

        private void MainForm_Load(object sender, EventArgs e) { }

        private void buttonAddEmp_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                _empVM.EmployeesList.EndEdit();

                Employees selectedRow = null;
                if (dataGridViewEmp.CurrentRow?.DataBoundItem is Employees current)
                {
                    selectedRow = current;
                }

                _empVM.AddFromGrid(selectedRow);
                MessageBox.Show("Employee saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\nDetails: {ex.InnerException?.Message ?? ex.ToString()}", "Add Employee Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditEmp_Click(object sender, EventArgs e)
        {
            try
            {
                _empVM.SaveUpdatesFromGrid();
                MessageBox.Show("Employees updated.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonDeleteEmp_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmp.CurrentRow?.DataBoundItem is Employees selected)
            {
                if (MessageBox.Show($"Delete {selected.FullName}?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    _empVM.DeleteEmployee(selected);
            }
        }

        private void buttonFindEmp_Click(object sender, EventArgs e)
        {
            _empVM.Search(textBoxSearchId.Text, textBoxRoles.Text, checkBoxAvailable.Checked);
        }

        private void buttonHistoryEmp_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmp.CurrentRow?.DataBoundItem is Employees selected)
            {
                string info = _empVM.GetEmployeeHistoryInfo(selected);
                MessageBox.Show(info, $"History: {selected.FullName}");
            }
        }

        private void dataGridViewEmp_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HideColumn(dataGridViewEmp, "ExpeditionTeams");
            HideColumn(dataGridViewEmp, "Equipment");
            dataGridViewEmp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _equipVM.Search(null, checkBoxBrokenEq.Checked, checkBoxAvailableEq.Checked);
        }

        private void buttonAddEq_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                _equipVM.EquipmentList.EndEdit();

                Equipment selectedRow = null;
                if (dataGridViewEq.CurrentRow?.DataBoundItem is Equipment current)
                {
                    selectedRow = current;
                }

                _equipVM.AddFromGrid(selectedRow);
                MessageBox.Show("New equipment saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\nDetails: {ex.InnerException?.Message ?? ex.ToString()}", "Add Equipment Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditEq_Click(object sender, EventArgs e)
        {
            try
            {
                _equipVM.SaveUpdatesFromGrid();
                MessageBox.Show("Equipment updated.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonDeleteEq_Click(object sender, EventArgs e)
        {
            if (dataGridViewEq.CurrentRow?.DataBoundItem is Equipment selected)
            {
                if (MessageBox.Show($"Delete {selected.Name}?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    _equipVM.DeleteEquipment(selected);
            }
        }

        private void buttonReturnEq_Click(object sender, EventArgs e)
        {
            if (dataGridViewEq.CurrentRow?.DataBoundItem is Equipment selected)
            {
                try
                {
                    _equipVM.ReturnToStorage(selected);
                    MessageBox.Show("Returned!");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void buttonAssingEq_Click(object sender, EventArgs e)
        {
            if (dataGridViewEq.CurrentRow?.DataBoundItem is Equipment selected)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Employee ID:", "Assign");
                if (int.TryParse(input, out int empId))
                {
                    try
                    {
                        _equipVM.AssignToEmployee(selected, empId);
                        MessageBox.Show("Assigned!");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void buttonFindExp_Click(object sender, EventArgs e)
        {
            _expVM.Search(null, dateTimePickerStart.Value, dateTimePickerEnd.Value, checkBoxIsActive.Checked);
        }

        private void buttonAddExp_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                dataGridViewExp.EndEdit();

                Expeditions selectedRow = null;
                if (dataGridViewExp.CurrentRow?.DataBoundItem is Expeditions current)
                {
                    selectedRow = current;
                }

                _expVM.AddFromGrid(selectedRow);
                MessageBox.Show("Expedition saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditExp_Click(object sender, EventArgs e)
        {
            try
            {
                _expVM.SaveUpdatesFromGrid();
                MessageBox.Show("Expeditions updated.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonDeleteExp_Click(object sender, EventArgs e)
        {
            if (dataGridViewExp.CurrentRow?.DataBoundItem is Expeditions selected)
            {
                if (MessageBox.Show("Delete expedition?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    _expVM.DeleteExpedition(selected);
            }
        }

        private void buttonReportExp_Click(object sender, EventArgs e)
        {
            if (dataGridViewExp.CurrentRow?.DataBoundItem is Expeditions selected)
            {
                MessageBox.Show(_expVM.GetReportInfo(selected), "Report");
            }
        }

        private void buttonFindLoc_Click(object sender, EventArgs e)
        {
            _locVM.Search(textBoxIdLoc.Text, comboBoxLocType.Text);
        }

        private void buttonAddLoc_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                dataGridView3.EndEdit();

                Locations selectedRow = null;
                if (dataGridView3.CurrentRow?.DataBoundItem is Locations current)
                {
                    selectedRow = current;
                }

                _locVM.AddFromGrid(selectedRow);
                MessageBox.Show("Location saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditLoc_Click(object sender, EventArgs e)
        {
            try
            {
                _locVM.SaveUpdatesFromGrid();
                MessageBox.Show("Locations updated.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonDeleteLoc_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow?.DataBoundItem is Locations selected)
            {
                if (MessageBox.Show($"Delete {selected.Name}?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    _locVM.DeleteLocation(selected);
            }
        }

        private void buttonFindMeas_Click(object sender, EventArgs e)
        {
            _measVM.Search(textBoxLocIdMeas.Text, dateTimePickerMeasStart.Value, dateTimePickerMeasEnd.Value);

            string stats = _measVM.GetStatistics(textBoxLocIdMeas.Text, dateTimePickerMeasStart.Value, dateTimePickerMeasEnd.Value);
            labelStatistic.Text = stats;
        }

        private void buttonAddMeas_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                dataGridView4.EndEdit();

                Measurements selectedRow = null;
                if (dataGridView4.CurrentRow?.DataBoundItem is Measurements current)
                {
                    selectedRow = current;
                }

                _measVM.AddFromGrid(selectedRow);
                MessageBox.Show("Measurement saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteMeas_Click(object sender, EventArgs e)
        {
            if (dataGridView4.CurrentRow?.DataBoundItem is Measurements selected)
            {
                if (MessageBox.Show("Delete measurement?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    _measVM.DeleteMeasurement(selected);
            }
        }

        private void buttonEditMeas_Click(object sender, EventArgs e)
        {
            try
            {
                _measVM.SaveUpdatesFromGrid();
                MessageBox.Show("Measurements updated.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void ConfigureEditableGrid(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = true;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = false;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void HideColumn(DataGridView dgv, string colName)
        {
            if (dgv.Columns[colName] != null) dgv.Columns[colName].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void dataGridViewEq_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HideColumn(dataGridViewEq, "Employee");
            HideColumn(dataGridViewEq, "Measurements");
            dataGridViewEq.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridViewEq.Columns["LastCalibrationDate"] != null)
                dataGridViewEq.Columns["LastCalibrationDate"].DefaultCellStyle.Format = "d";
        }

        private void dataGridView3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HideColumn(dataGridView3, "Expeditions");
            HideColumn(dataGridView3, "Measurements");
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView4_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HideColumn(dataGridView4, "Location");
            HideColumn(dataGridView4, "Expedition");
            HideColumn(dataGridView4, "Equipment");
            HideColumn(dataGridView4, "Employee");
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridViewExp_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HideColumn(dataGridViewExp, "Location");
            HideColumn(dataGridViewExp, "ExpeditionTeams");
            HideColumn(dataGridViewExp, "ExpeditionReport");
            HideColumn(dataGridViewExp, "ExpeditionReports");
            HideColumn(dataGridViewExp, "Measurements");
            dataGridViewExp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridViewExp.Columns["StartDate"] != null)
                dataGridViewExp.Columns["StartDate"].DefaultCellStyle.Format = "d";
            if (dataGridViewExp.Columns["EndDate"] != null)
                dataGridViewExp.Columns["EndDate"].DefaultCellStyle.Format = "d";
        }

        private void label9_Click(object sender, EventArgs e) { }

        private void buttonClearEmp_Click(object sender, EventArgs e)
        {
            textBoxSearchId.Clear();
            textBoxRoles.Clear();
            checkBoxAvailable.Checked = false;
            _empVM.LoadData();
        }

        private void buttonClearEq_Click(object sender, EventArgs e)
        {
            textBoxIdEq.Clear();
            checkBoxAvailableEq.Checked = false;
            _equipVM.LoadData();
        }

        private void buttonClearExp_Click(object sender, EventArgs e)
        {
            checkBoxIsActive.Checked = false;
            dateTimePickerStart.Value = DateTime.Today.AddMonths(-1);
            dateTimePickerEnd.Value = DateTime.Today;
            _expVM.LoadData();
        }

        private void buttonClearLoc_Click(object sender, EventArgs e)
        {
            textBoxIdLoc.Clear();
            comboBoxLocType.SelectedIndex = -1;
            _locVM.LoadData();
        }

        private void buttonClearMeas_Click(object sender, EventArgs e)
        {
            textBoxLocIdMeas.Clear();
            dateTimePickerMeasStart.Value = DateTime.Today.AddMonths(-1);
            dateTimePickerMeasEnd.Value = DateTime.Today;
            _measVM.LoadData();
            labelStatistic.Text = "Statistic:";
        }
    }
}
