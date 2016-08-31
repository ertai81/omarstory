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
            this.GridDecisions.Location = new System.Drawing.Point(12, 12);
            this.GridDecisions.Name = "GridDecisions";
            this.GridDecisions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridDecisions.Size = new System.Drawing.Size(568, 535);
            this.GridDecisions.TabIndex = 0;
            this.GridDecisions.DoubleClick += new System.EventHandler(this.GridDecisions_DoubleClick);
            // 
            // Decisions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 559);
            this.Controls.Add(this.GridDecisions);
            this.Name = "Decisions";
            this.Text = "Decisions";
            this.Load += new System.EventHandler(this.Decisions_Load);
            this.DoubleClick += new System.EventHandler(this.GridDecisions_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.GridDecisions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridDecisions;
    }
}