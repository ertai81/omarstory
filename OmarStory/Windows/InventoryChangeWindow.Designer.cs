namespace OmarStory.Windows
{
    partial class InventoryChangeWindow
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
            this.TextInventoryChange = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TextInventoryChange
            // 
            this.TextInventoryChange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextInventoryChange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextInventoryChange.Location = new System.Drawing.Point(12, 12);
            this.TextInventoryChange.Name = "TextInventoryChange";
            this.TextInventoryChange.Size = new System.Drawing.Size(255, 96);
            this.TextInventoryChange.TabIndex = 0;
            this.TextInventoryChange.Text = "";
            // 
            // InventoryChangeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 120);
            this.Controls.Add(this.TextInventoryChange);
            this.Name = "InventoryChangeWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventario";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextInventoryChange;
    }
}