namespace nspector
{
    partial class frmAddXboxApplication
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
            tbSearch = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            btnOK = new System.Windows.Forms.Button();
            txtFilter = new System.Windows.Forms.TextBox();
            lstResults = new System.Windows.Forms.ListBox();
            SuspendLayout();
            // 
            // tbSearch
            // 
            tbSearch.Location = new System.Drawing.Point(118, 12);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new System.Drawing.Size(75, 23);
            tbSearch.TabIndex = 1;
            tbSearch.Text = "Search";
            tbSearch.UseVisualStyleBackColor = true;
            tbSearch.Click += tbSearch_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(93, 415);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(12, 415);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(75, 23);
            btnOK.TabIndex = 3;
            btnOK.Text = "Ok";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // txtFilter
            // 
            txtFilter.Location = new System.Drawing.Point(12, 12);
            txtFilter.Name = "txtFilter";
            txtFilter.PlaceholderText = "Wildcard...";
            txtFilter.Size = new System.Drawing.Size(100, 23);
            txtFilter.TabIndex = 0;
            // 
            // lstResults
            // 
            lstResults.FormattingEnabled = true;
            lstResults.Location = new System.Drawing.Point(12, 41);
            lstResults.Name = "lstResults";
            lstResults.Size = new System.Drawing.Size(776, 364);
            lstResults.TabIndex = 2;
            lstResults.DoubleClick += lstResults_DoubleClick;
            // 
            // frmAddXboxApplication
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(lstResults);
            Controls.Add(txtFilter);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Controls.Add(tbSearch);
            Name = "frmAddXboxApplication";
            Text = "frmAddXboxApplication";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button tbSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ListBox lstResults;
    }
}