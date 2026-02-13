using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using Windows.Management.Deployment;

namespace nspector
{
    public partial class frmAddXboxApplication : Form
    {
        public string SelectedPackage => lstResults.SelectedItem?.ToString();


        public frmAddXboxApplication()
        {
            InitializeComponent();
            AcceptButton = tbSearch;
            Shown += (s, e) => txtFilter.Focus();
        }

        private void tbSearch_Click(object sender, EventArgs e)
        {
            string filter = txtFilter.Text.Trim();
            if (string.IsNullOrWhiteSpace(filter))
            {
                MessageBox.Show("Please enter a filter.");
                return;
            }

            lstResults.Items.Clear();

            ListAppxPackages(filter);
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

            var filteredPackages = packages.Where(p => p.Id.Name.Contains(filter)).ToList();

            foreach (var package in filteredPackages)
            {
                lstResults.Items.Add(package.Id.FamilyName);
            }
        }

    }
}
