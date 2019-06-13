using FileCopy2000.BL;
using System.Windows;

namespace FileCopy2000
{
    public partial class AddEditDialog : Window
    {
        private MainWindow _mainWindow;
        private dialogTypes _dialogType;

        public AddEditDialog(MainWindow mainWindow, dialogTypes dialogType, Job selectedJob)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _dialogType = dialogType;

            switch (dialogType)
            {
                case dialogTypes.Add:
                    LabelTitle.Content = "Add New Job";
                    break;
                case dialogTypes.Edit:
                    LabelTitle.Content = "Edit Job";
                    FillFields(selectedJob);
                    break;
            }    
        }

        private void FillFields(Job selectedJob)
        {
            TextBoxName.Text = selectedJob.Name;
            TextBoxFromPath.Text = selectedJob.FromPath;
            TextBoxToPath.Text = selectedJob.ToPath;
        }
    }
}
