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
            AcceptButton = btnOK;
            Shown += (s, e) => txtFilter.Focus();
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

            var filteredPackages = packages.Where(p => p.Id.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var package in filteredPackages)
            {
                lstResults.Items.Add(package.Id.FamilyName);
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string filter = txtFilter.Text.Trim();

            lstResults.Items.Clear();

            ListAppxPackages(filter);
            if (lstResults.Items.Count == 1)
                lstResults.SelectedIndex = 0;
        }
    }
}
