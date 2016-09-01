namespace OmarStoryBuilder
{
    partial class Dialogs
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
            this.GridDialogs = new System.Windows.Forms.DataGridView();
            this.ComboCharactersFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextFilterText = new System.Windows.Forms.TextBox();
            this.ButtonResetFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridDialogs)).BeginInit();
            this.SuspendLayout();
            // 
            // GridDialogs
            // 
            this.GridDialogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridDialogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridDialogs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.GridDialogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDialogs.Location = new System.Drawing.Point(12, 55);
            this.GridDialogs.Name = "GridDialogs";
            this.GridDialogs.ReadOnly = true;
            this.GridDialogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridDialogs.Size = new System.Drawing.Size(467, 488);
            this.GridDialogs.TabIndex = 0;
            this.GridDialogs.DoubleClick += new System.EventHandler(this.GridDialogs_DoubleClick);
            // 
            // ComboCharactersFilter
            // 
            this.ComboCharactersFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboCharactersFilter.FormattingEnabled = true;
            this.ComboCharactersFilter.Location = new System.Drawing.Point(12, 28);
            this.ComboCharactersFilter.Name = "ComboCharactersFilter";
            this.ComboCharactersFilter.Size = new System.Drawing.Size(121, 21);
            this.ComboCharactersFilter.TabIndex = 1;
            this.ComboCharactersFilter.SelectedIndexChanged += new System.EventHandler(this.ComboCharactersFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Personaje";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Texto";
            // 
            // TextFilterText
            // 
            this.TextFilterText.Location = new System.Drawing.Point(183, 9);
            this.TextFilterText.Multiline = true;
            this.TextFilterText.Name = "TextFilterText";
            this.TextFilterText.Size = new System.Drawing.Size(220, 40);
            this.TextFilterText.TabIndex = 4;
            this.TextFilterText.TextChanged += new System.EventHandler(this.TextFilterText_TextChanged);
            // 
            // ButtonResetFilter
            // 
            this.ButtonResetFilter.Location = new System.Drawing.Point(409, 26);
            this.ButtonResetFilter.Name = "ButtonResetFilter";
            this.ButtonResetFilter.Size = new System.Drawing.Size(70, 23);
            this.ButtonResetFilter.TabIndex = 5;
            this.ButtonResetFilter.Text = "Reset filter";
            this.ButtonResetFilter.UseVisualStyleBackColor = true;
            this.ButtonResetFilter.Click += new System.EventHandler(this.ButtonResetFilter_Click);
            // 
            // Dialogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 555);
            this.Controls.Add(this.ButtonResetFilter);
            this.Controls.Add(this.TextFilterText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboCharactersFilter);
            this.Controls.Add(this.GridDialogs);
            this.Name = "Dialogs";
            this.Text = "Diálogos";
            this.Load += new System.EventHandler(this.Dialogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridDialogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridDialogs;
        private System.Windows.Forms.ComboBox ComboCharactersFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextFilterText;
        private System.Windows.Forms.Button ButtonResetFilter;
    }
}