using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using Windows.Management.Deployment;

namespace nspector
{
    public partial class frmAddXboxApplication : Form
    {

        private Timer _debounceTimer;

        public class PackageItem
        {
            public string FamilyName { get; set; }
            public string DisplayName { get; set; }

            public override string ToString()
            {
                return DisplayName;
            }
        }

        public PackageItem SelectedPackage => lstResults.SelectedItem as PackageItem;


        public frmAddXboxApplication()
        {
            InitializeComponent();
            AcceptButton = btnOK;
            Shown += (s, e) => txtFilter.Focus();

            _debounceTimer = new Timer();
            _debounceTimer.Interval = 350;
            _debounceTimer.Tick += DebounceTimer_Tick;
        }

        private void lstResults_DoubleClick(object sender, EventArgs e)
        {
            if (lstResults.SelectedItem != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedItem != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a package.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ListAppxPackages(string filter = "")
        {
            lstResults.Items.Clear();

            var packageManager = new PackageManager();
            var packages = packageManager.FindPackagesForUser("");

            var filteredPackages = packages.Where(p => p.DisplayName.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var package in filteredPackages)
            {            
                // Create a tuple of (FamilyName, DisplayName)
                var item = Tuple.Create(package.DisplayName, package.Id.FamilyName);

                // Add tuple to ListBox
                lstResults.Items.Add(new PackageItem
                {
                    DisplayName = package.DisplayName,
                    FamilyName = package.Id.FamilyName
                });
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            // Restart the timer on every keystroke
            _debounceTimer.Stop();
            _debounceTimer.Start();
        }

        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            // Stop the timer to prevent repeated firing
            _debounceTimer.Stop();

            string filter = txtFilter.Text.Trim();

            lstResults.Items.Clear();
            ListAppxPackages(filter);

            if (lstResults.Items.Count == 1)
                lstResults.SelectedIndex = 0;
        }
    }
}
