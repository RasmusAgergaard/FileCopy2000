using FileCopy2000.BL;
using System;
using System.Collections.Generic;
using System.Windows;

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

        private void Button_Click_Run_Job(object sender, RoutedEventArgs e)
        {
            var job = (Job)ComboBoxJobs.SelectedItem;
            job.Run(TextBoxInput.Text);
        }

        private void ComboBoxJobs_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            EnableButtonsCheck();
            EnableInputCheck();
            SetLabels();
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
    }
}
