namespace OmarStoryBuilder
{
    partial class Decisions
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
            this.GridDecisions = new System.Windows.Forms.DataGridView();
            this.ButtonResetFilter = new System.Windows.Forms.Button();
            this.TextFilterText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextDecisionNumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridDecisions)).BeginInit();
            this.SuspendLayout();
            // 
            // GridDecisions
            // 
            this.GridDecisions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridDecisions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridDecisions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.GridDecisions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDecisions.Location = new System.Drawing.Point(12, 58);
            this.GridDecisions.Name = "GridDecisions";
            this.GridDecisions.ReadOnly = true;
            this.GridDecisions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridDecisions.Size = new System.Drawing.Size(568, 489);
            this.GridDecisions.TabIndex = 0;
            this.GridDecisions.DoubleClick += new System.EventHandler(this.GridDecisions_DoubleClick);
            // 
            // ButtonResetFilter
            // 
            this.ButtonResetFilter.Location = new System.Drawing.Point(510, 29);
            this.ButtonResetFilter.Name = "ButtonResetFilter";
            this.ButtonResetFilter.Size = new System.Drawing.Size(70, 23);
            this.ButtonResetFilter.TabIndex = 8;
            this.ButtonResetFilter.Text = "Reset filter";
            this.ButtonResetFilter.UseVisualStyleBackColor = true;
            this.ButtonResetFilter.Click += new System.EventHandler(this.ButtonResetFilter_Click);
            // 
            // TextFilterText
            // 
            this.TextFilterText.Location = new System.Drawing.Point(284, 12);
            this.TextFilterText.Multiline = true;
            this.TextFilterText.Name = "TextFilterText";
            this.TextFilterText.Size = new System.Drawing.Size(220, 40);
            this.TextFilterText.TabIndex = 7;
            this.TextFilterText.TextChanged += new System.EventHandler(this.TextFilterText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Texto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Decision number";
            // 
            // TextDecisionNumber
            // 
            this.TextDecisionNumber.Location = new System.Drawing.Point(15, 31);
            this.TextDecisionNumber.Name = "TextDecisionNumber";
            this.TextDecisionNumber.Size = new System.Drawing.Size(100, 20);
            this.TextDecisionNumber.TabIndex = 10;
            this.TextDecisionNumber.TextChanged += new System.EventHandler(this.TextDecisionNumber_TextChanged);
            // 
            // Decisions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 559);
            this.Controls.Add(this.TextDecisionNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonResetFilter);
            this.Controls.Add(this.TextFilterText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GridDecisions);
            this.Name = "Decisions";
            this.Text = "Decisions";
            this.Load += new System.EventHandler(this.Decisions_Load);
            this.DoubleClick += new System.EventHandler(this.GridDecisions_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.GridDecisions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridDecisions;
        private System.Windows.Forms.Button ButtonResetFilter;
        private System.Windows.Forms.TextBox TextFilterText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextDecisionNumber;
    }
}