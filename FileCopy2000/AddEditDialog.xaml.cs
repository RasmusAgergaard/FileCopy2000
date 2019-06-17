using FileCopy2000.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FileCopy2000
{
    public partial class AddEditDialog : Window
    {
        private MainWindow _mainWindow;
        private dialogTypes _dialogType;
        private int _listIndex;

        public AddEditDialog(MainWindow mainWindow, dialogTypes dialogType, Job selectedJob, int listIndex)
        {
            InitializeComponent();
            DataContext = this;

            ComboBoxType.ItemsSource = Enum.GetValues(typeof(types)).Cast<types>();

            _mainWindow = mainWindow;
            _dialogType = dialogType;
            _listIndex = listIndex;

            switch (_dialogType)
            {
                case dialogTypes.Add:
                    LabelTitle.Content = "Add New Job";
                    ButtonDeleteJob.IsEnabled = false;
                    break;
                case dialogTypes.Edit:
                    LabelTitle.Content = "Edit Job";
                    ButtonDeleteJob.IsEnabled = true;
                    FillFields(selectedJob);
                    break;
            }    
        }

        private void FillFields(Job selectedJob)
        {
            TextBoxName.Text = selectedJob.Name;
            ComboBoxType.SelectedItem = selectedJob.Type;
            TextBoxFromPath.Text = selectedJob.FromPath;
            TextBoxToPath.Text = selectedJob.ToPath;
        }

        private void ButtonSaveJob_Click(object sender, RoutedEventArgs e)
        {
            switch (_dialogType)
            {
                case dialogTypes.Add:
                    AddNewJobToList();
                    _mainWindow.SetMessage("New job added...", messageTypes.Success);
                    break;
                case dialogTypes.Edit:
                    SaveJobExistingJobToList();
                    _mainWindow.SetMessage("Job edited...", messageTypes.Success);
                    break;
            }

            UpdateSaveAndClose();
        }

        private void ButtonDeleteJob_Click(object sender, RoutedEventArgs e)
        {
            DeleteJob();
            UpdateSaveAndClose();
        }

        private void AddNewJobToList()
        {
            var newJob = new Job((types)ComboBoxType.SelectedItem, TextBoxName.Text, true);
            newJob.SetFromPath(TextBoxFromPath.Text);
            newJob.SetToPath(TextBoxToPath.Text);

            _mainWindow.Jobs.Add(newJob);
            _mainWindow.MainJobStore.SaveJobs(_mainWindow.Jobs);
        }

        private void SaveJobExistingJobToList()
        {
            var tempJob = new Job((types)ComboBoxType.SelectedItem, TextBoxName.Text, true);
            tempJob.SetFromPath(TextBoxFromPath.Text);
            tempJob.SetToPath(TextBoxToPath.Text);

            _mainWindow.Jobs[_listIndex] = tempJob;
        }

        private void DeleteJob()
        {
            _mainWindow.Jobs.RemoveAt(_listIndex);
        }

        private void UpdateSaveAndClose()
        {
            _mainWindow.UpdateComboBoxContent();
            _mainWindow.SetLabels();

            _mainWindow.MainJobStore.SaveJobs(_mainWindow.Jobs);

            Close();
        }
    }
}
