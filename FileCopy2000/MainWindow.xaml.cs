using FileCopy2000.BL;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace FileCopy2000
{
    public partial class MainWindow : Window
    {
        public List<Job> JobsToDisplay { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            var jobStore = new JobStore();
            JobsToDisplay = jobStore.Jobs;
        }

        private void ButtonAddNewJob_Click(object sender, RoutedEventArgs e)
        {
            var job = new Job(types.Copy, "null", false);
            var addEditDialog = new AddEditDialog(this, dialogTypes.Add, job);
            addEditDialog.ShowDialog();
        }

        private void ButtonEditJob_Click(object sender, RoutedEventArgs e)
        {
            var addEditDialog = new AddEditDialog(this, dialogTypes.Edit, (Job)ComboBoxJobs.SelectedItem);
            addEditDialog.ShowDialog();
        }

        private void Button_Click_Run_Job(object sender, RoutedEventArgs e)
        {
            var job = (Job)ComboBoxJobs.SelectedItem;
            job.Run(TextBoxInput.Text);
            SetMessage("Job ran successfully", messageTypes.Success);
        }

        private void ComboBoxJobs_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ValidCheckAndSetMessage();
            EnableButtonsCheck();
            EnableInputCheck();
            SetLabels();
        }

        private void ValidCheckAndSetMessage()
        {
            var job = (Job)ComboBoxJobs.SelectedItem;

            if (job.IsValid())
            {
                SetMessage("", messageTypes.Normal);
            }
            else
            {
                SetMessage("Warning: Selected job is not valid", messageTypes.Warning);

            }
        }

        private void EnableButtonsCheck()
        {
            if (ComboBoxJobs.SelectedItem == null)
            {
                ButtonRunJob.IsEnabled = false;
                ButtonEditJob.IsEnabled = false;
            }
            else
            {
                ButtonRunJob.IsEnabled = true;
                ButtonEditJob.IsEnabled = true;
            }
        }

        private void EnableInputCheck()
        {
            var job = (Job)ComboBoxJobs.SelectedItem;

            if (job.RequiresInput)
            {
                TextBoxInput.IsEnabled = true;
            }
            else
            {
                TextBoxInput.IsEnabled = false;
            }
        }

        private void SetLabels()
        {
            var job = (Job)ComboBoxJobs.SelectedItem;
            LabelJobType.Content = job.Type.ToString();
            LabelFromPath.Content = job.FromPath;
            LabelToPath.Content = job.ToPath;
        }

        private void SetMessage(string message, messageTypes messageType)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                LabelMessage.Content = "Ready...";
            }
            else
            {
                LabelMessage.Content = message;
            }

            switch (messageType)
            {
                case messageTypes.Normal:
                    LabelMessage.Foreground = new SolidColorBrush(Colors.Black);
                    LabelMessage.Background = new SolidColorBrush(Colors.White);
                    break;
                case messageTypes.Success:
                    LabelMessage.Foreground = new SolidColorBrush(Colors.White);
                    LabelMessage.Background = new SolidColorBrush(Colors.Green);
                    break;
                case messageTypes.Warning:
                    LabelMessage.Foreground = new SolidColorBrush(Colors.Black);
                    LabelMessage.Background = new SolidColorBrush(Colors.Yellow);
                    break;
                case messageTypes.Error:
                    LabelMessage.Foreground = new SolidColorBrush(Colors.White);
                    LabelMessage.Background = new SolidColorBrush(Colors.Red);
                    break;
            }

            
        }


    }
}
