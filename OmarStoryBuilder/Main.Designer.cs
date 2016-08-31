namespace OmarStoryBuilder
{
    partial class Main
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
            this.DialogGroup = new System.Windows.Forms.GroupBox();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.ButtonNextDecision = new System.Windows.Forms.Button();
            this.ButtonNextDialog = new System.Windows.Forms.Button();
            this.GroupItems = new System.Windows.Forms.GroupBox();
            this.ButtonAddItem = new System.Windows.Forms.Button();
            this.RadioTypeItemBackground = new System.Windows.Forms.RadioButton();
            this.RadioTypeItemStatus = new System.Windows.Forms.RadioButton();
            this.RadioTypeItemCharacter = new System.Windows.Forms.RadioButton();
            this.RadioTypeItemObject = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TextItemName = new System.Windows.Forms.TextBox();
            this.ButtonAddDialog = new System.Windows.Forms.Button();
            this.ButtonResultLosesFriend = new System.Windows.Forms.Button();
            this.ButtonResultLosesStatus = new System.Windows.Forms.Button();
            this.ButtonResultGetsFriend = new System.Windows.Forms.Button();
            this.ButtonResultLosesObject = new System.Windows.Forms.Button();
            this.ButtonChangeBackground = new System.Windows.Forms.Button();
            this.ButtonResultGetsStatus = new System.Windows.Forms.Button();
            this.ButtonConditionDoesntHaveFriend = new System.Windows.Forms.Button();
            this.ButtonResultGetsObject = new System.Windows.Forms.Button();
            this.ButtonConditionHasFriend = new System.Windows.Forms.Button();
            this.ButtonConditionDoesntHaveStatus = new System.Windows.Forms.Button();
            this.ButtonConditionHasStatus = new System.Windows.Forms.Button();
            this.ButtonConditionDoesntHaveObject = new System.Windows.Forms.Button();
            this.ButtonConditionHasObject = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ListBackground = new System.Windows.Forms.ListBox();
            this.ListStatuses = new System.Windows.Forms.ListBox();
            this.ListCharacters = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ListObjects = new System.Windows.Forms.ListBox();
            this.TextNewResultDialog = new System.Windows.Forms.TextBox();
            this.TextNewConditionDialog = new System.Windows.Forms.TextBox();
            this.TextNewTextDialog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboCharacters = new System.Windows.Forms.ComboBox();
            this.DialogGroup.SuspendLayout();
            this.GroupItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // DialogGroup
            // 
            this.DialogGroup.Controls.Add(this.ButtonReset);
            this.DialogGroup.Controls.Add(this.ButtonNextDecision);
            this.DialogGroup.Controls.Add(this.ButtonNextDialog);
            this.DialogGroup.Controls.Add(this.GroupItems);
            this.DialogGroup.Controls.Add(this.ButtonAddDialog);
            this.DialogGroup.Controls.Add(this.ButtonResultLosesFriend);
            this.DialogGroup.Controls.Add(this.ButtonResultLosesStatus);
            this.DialogGroup.Controls.Add(this.ButtonResultGetsFriend);
            this.DialogGroup.Controls.Add(this.ButtonResultLosesObject);
            this.DialogGroup.Controls.Add(this.ButtonChangeBackground);
            this.DialogGroup.Controls.Add(this.ButtonResultGetsStatus);
            this.DialogGroup.Controls.Add(this.ButtonConditionDoesntHaveFriend);
            this.DialogGroup.Controls.Add(this.ButtonResultGetsObject);
            this.DialogGroup.Controls.Add(this.ButtonConditionHasFriend);
            this.DialogGroup.Controls.Add(this.ButtonConditionDoesntHaveStatus);
            this.DialogGroup.Controls.Add(this.ButtonConditionHasStatus);
            this.DialogGroup.Controls.Add(this.ButtonConditionDoesntHaveObject);
            this.DialogGroup.Controls.Add(this.ButtonConditionHasObject);
            this.DialogGroup.Controls.Add(this.label5);
            this.DialogGroup.Controls.Add(this.ListBackground);
            this.DialogGroup.Controls.Add(this.ListStatuses);
            this.DialogGroup.Controls.Add(this.ListCharacters);
            this.DialogGroup.Controls.Add(this.label6);
            this.DialogGroup.Controls.Add(this.label4);
            this.DialogGroup.Controls.Add(this.label3);
            this.DialogGroup.Controls.Add(this.ListObjects);
            this.DialogGroup.Controls.Add(this.TextNewResultDialog);
            this.DialogGroup.Controls.Add(this.TextNewConditionDialog);
            this.DialogGroup.Controls.Add(this.TextNewTextDialog);
            this.DialogGroup.Controls.Add(this.label2);
            this.DialogGroup.Controls.Add(this.ComboCharacters);
            this.DialogGroup.Location = new System.Drawing.Point(12, 12);
            this.DialogGroup.Name = "DialogGroup";
            this.DialogGroup.Size = new System.Drawing.Size(822, 584);
            this.DialogGroup.TabIndex = 0;
            this.DialogGroup.TabStop = false;
            this.DialogGroup.Text = "Diálogo";
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(11, 185);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 8;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // ButtonNextDecision
            // 
            this.ButtonNextDecision.Location = new System.Drawing.Point(231, 185);
            this.ButtonNextDecision.Name = "ButtonNextDecision";
            this.ButtonNextDecision.Size = new System.Drawing.Size(64, 44);
            this.ButtonNextDecision.TabIndex = 7;
            this.ButtonNextDecision.Text = "Siguiente Decisión";
            this.ButtonNextDecision.UseVisualStyleBackColor = true;
            this.ButtonNextDecision.Click += new System.EventHandler(this.ButtonNextDecision_Click);
            // 
            // ButtonNextDialog
            // 
            this.ButtonNextDialog.Location = new System.Drawing.Point(167, 185);
            this.ButtonNextDialog.Name = "ButtonNextDialog";
            this.ButtonNextDialog.Size = new System.Drawing.Size(63, 44);
            this.ButtonNextDialog.TabIndex = 7;
            this.ButtonNextDialog.Text = "Siguiente Diálogo";
            this.ButtonNextDialog.UseVisualStyleBackColor = true;
            this.ButtonNextDialog.Click += new System.EventHandler(this.ButtonNextDialog_Click);
            // 
            // GroupItems
            // 
            this.GroupItems.Controls.Add(this.ButtonAddItem);
            this.GroupItems.Controls.Add(this.RadioTypeItemBackground);
            this.GroupItems.Controls.Add(this.RadioTypeItemStatus);
            this.GroupItems.Controls.Add(this.RadioTypeItemCharacter);
            this.GroupItems.Controls.Add(this.RadioTypeItemObject);
            this.GroupItems.Controls.Add(this.label1);
            this.GroupItems.Controls.Add(this.TextItemName);
            this.GroupItems.Location = new System.Drawing.Point(11, 457);
            this.GroupItems.Name = "GroupItems";
            this.GroupItems.Size = new System.Drawing.Size(245, 117);
            this.GroupItems.TabIndex = 1;
            this.GroupItems.TabStop = false;
            this.GroupItems.Text = "Items";
            // 
            // ButtonAddItem
            // 
            this.ButtonAddItem.Location = new System.Drawing.Point(49, 38);
            this.ButtonAddItem.Name = "ButtonAddItem";
            this.ButtonAddItem.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddItem.TabIndex = 3;
            this.ButtonAddItem.Text = "Añadir";
            this.ButtonAddItem.UseVisualStyleBackColor = true;
            this.ButtonAddItem.Click += new System.EventHandler(this.ButtonAddItem_Click);
            // 
            // RadioTypeItemBackground
            // 
            this.RadioTypeItemBackground.AutoSize = true;
            this.RadioTypeItemBackground.Location = new System.Drawing.Point(156, 84);
            this.RadioTypeItemBackground.Name = "RadioTypeItemBackground";
            this.RadioTypeItemBackground.Size = new System.Drawing.Size(55, 17);
            this.RadioTypeItemBackground.TabIndex = 2;
            this.RadioTypeItemBackground.TabStop = true;
            this.RadioTypeItemBackground.Text = "Fondo";
            this.RadioTypeItemBackground.UseVisualStyleBackColor = true;
            // 
            // RadioTypeItemStatus
            // 
            this.RadioTypeItemStatus.AutoSize = true;
            this.RadioTypeItemStatus.Location = new System.Drawing.Point(156, 61);
            this.RadioTypeItemStatus.Name = "RadioTypeItemStatus";
            this.RadioTypeItemStatus.Size = new System.Drawing.Size(58, 17);
            this.RadioTypeItemStatus.TabIndex = 2;
            this.RadioTypeItemStatus.TabStop = true;
            this.RadioTypeItemStatus.Text = "Estado";
            this.RadioTypeItemStatus.UseVisualStyleBackColor = true;
            // 
            // RadioTypeItemCharacter
            // 
            this.RadioTypeItemCharacter.AutoSize = true;
            this.RadioTypeItemCharacter.Location = new System.Drawing.Point(156, 38);
            this.RadioTypeItemCharacter.Name = "RadioTypeItemCharacter";
            this.RadioTypeItemCharacter.Size = new System.Drawing.Size(72, 17);
            this.RadioTypeItemCharacter.TabIndex = 2;
            this.RadioTypeItemCharacter.TabStop = true;
            this.RadioTypeItemCharacter.Text = "Personaje";
            this.RadioTypeItemCharacter.UseVisualStyleBackColor = true;
            // 
            // RadioTypeItemObject
            // 
            this.RadioTypeItemObject.AutoSize = true;
            this.RadioTypeItemObject.Location = new System.Drawing.Point(156, 15);
            this.RadioTypeItemObject.Name = "RadioTypeItemObject";
            this.RadioTypeItemObject.Size = new System.Drawing.Size(56, 17);
            this.RadioTypeItemObject.TabIndex = 2;
            this.RadioTypeItemObject.TabStop = true;
            this.RadioTypeItemObject.Text = "Objeto";
            this.RadioTypeItemObject.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // TextItemName
            // 
            this.TextItemName.Location = new System.Drawing.Point(49, 15);
            this.TextItemName.Name = "TextItemName";
            this.TextItemName.Size = new System.Drawing.Size(100, 20);
            this.TextItemName.TabIndex = 0;
            // 
            // ButtonAddDialog
            // 
            this.ButtonAddDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAddDialog.Location = new System.Drawing.Point(167, 235);
            this.ButtonAddDialog.Name = "ButtonAddDialog";
            this.ButtonAddDialog.Size = new System.Drawing.Size(128, 53);
            this.ButtonAddDialog.TabIndex = 6;
            this.ButtonAddDialog.Text = "Añadir diálogo";
            this.ButtonAddDialog.UseVisualStyleBackColor = true;
            this.ButtonAddDialog.Click += new System.EventHandler(this.ButtonAddDialog_Click);
            // 
            // ButtonResultLosesFriend
            // 
            this.ButtonResultLosesFriend.Location = new System.Drawing.Point(704, 101);
            this.ButtonResultLosesFriend.Name = "ButtonResultLosesFriend";
            this.ButtonResultLosesFriend.Size = new System.Drawing.Size(112, 24);
            this.ButtonResultLosesFriend.TabIndex = 5;
            this.ButtonResultLosesFriend.Text = "Pierde (resultado)";
            this.ButtonResultLosesFriend.UseVisualStyleBackColor = true;
            this.ButtonResultLosesFriend.Click += new System.EventHandler(this.ButtonResultItem_Click);
            // 
            // ButtonResultLosesStatus
            // 
            this.ButtonResultLosesStatus.Location = new System.Drawing.Point(447, 406);
            this.ButtonResultLosesStatus.Name = "ButtonResultLosesStatus";
            this.ButtonResultLosesStatus.Size = new System.Drawing.Size(112, 23);
            this.ButtonResultLosesStatus.TabIndex = 5;
            this.ButtonResultLosesStatus.Text = "Pierde (resultado)";
            this.ButtonResultLosesStatus.UseVisualStyleBackColor = true;
            this.ButtonResultLosesStatus.Click += new System.EventHandler(this.ButtonResultItem_Click);
            // 
            // ButtonResultGetsFriend
            // 
            this.ButtonResultGetsFriend.Location = new System.Drawing.Point(704, 76);
            this.ButtonResultGetsFriend.Name = "ButtonResultGetsFriend";
            this.ButtonResultGetsFriend.Size = new System.Drawing.Size(112, 24);
            this.ButtonResultGetsFriend.TabIndex = 5;
            this.ButtonResultGetsFriend.Text = "Consigue (resultado)";
            this.ButtonResultGetsFriend.UseVisualStyleBackColor = true;
            this.ButtonResultGetsFriend.Click += new System.EventHandler(this.ButtonResultItem_Click);
            // 
            // ButtonResultLosesObject
            // 
            this.ButtonResultLosesObject.Location = new System.Drawing.Point(447, 101);
            this.ButtonResultLosesObject.Name = "ButtonResultLosesObject";
            this.ButtonResultLosesObject.Size = new System.Drawing.Size(112, 23);
            this.ButtonResultLosesObject.TabIndex = 5;
            this.ButtonResultLosesObject.Text = "Pierde (resultado)";
            this.ButtonResultLosesObject.UseVisualStyleBackColor = true;
            this.ButtonResultLosesObject.Click += new System.EventHandler(this.ButtonResultItem_Click);
            // 
            // ButtonChangeBackground
            // 
            this.ButtonChangeBackground.Location = new System.Drawing.Point(704, 323);
            this.ButtonChangeBackground.Name = "ButtonChangeBackground";
            this.ButtonChangeBackground.Size = new System.Drawing.Size(112, 45);
            this.ButtonChangeBackground.TabIndex = 5;
            this.ButtonChangeBackground.Text = "Cambio de escenario";
            this.ButtonChangeBackground.UseVisualStyleBackColor = true;
            this.ButtonChangeBackground.Click += new System.EventHandler(this.ButtonChangeBackground_Click);
            // 
            // ButtonResultGetsStatus
            // 
            this.ButtonResultGetsStatus.Location = new System.Drawing.Point(447, 381);
            this.ButtonResultGetsStatus.Name = "ButtonResultGetsStatus";
            this.ButtonResultGetsStatus.Size = new System.Drawing.Size(112, 23);
            this.ButtonResultGetsStatus.TabIndex = 5;
            this.ButtonResultGetsStatus.Text = "Consigue (resultado)";
            this.ButtonResultGetsStatus.UseVisualStyleBackColor = true;
            this.ButtonResultGetsStatus.Click += new System.EventHandler(this.ButtonResultItem_Click);
            // 
            // ButtonConditionDoesntHaveFriend
            // 
            this.ButtonConditionDoesntHaveFriend.Location = new System.Drawing.Point(704, 47);
            this.ButtonConditionDoesntHaveFriend.Name = "ButtonConditionDoesntHaveFriend";
            this.ButtonConditionDoesntHaveFriend.Size = new System.Drawing.Size(112, 24);
            this.ButtonConditionDoesntHaveFriend.TabIndex = 5;
            this.ButtonConditionDoesntHaveFriend.Text = "No tiene (condición)";
            this.ButtonConditionDoesntHaveFriend.UseVisualStyleBackColor = true;
            this.ButtonConditionDoesntHaveFriend.Click += new System.EventHandler(this.ButtonConditionItem_Click);
            // 
            // ButtonResultGetsObject
            // 
            this.ButtonResultGetsObject.Location = new System.Drawing.Point(447, 76);
            this.ButtonResultGetsObject.Name = "ButtonResultGetsObject";
            this.ButtonResultGetsObject.Size = new System.Drawing.Size(112, 23);
            this.ButtonResultGetsObject.TabIndex = 5;
            this.ButtonResultGetsObject.Text = "Consigue (resultado)";
            this.ButtonResultGetsObject.UseVisualStyleBackColor = true;
            this.ButtonResultGetsObject.Click += new System.EventHandler(this.ButtonResultItem_Click);
            // 
            // ButtonConditionHasFriend
            // 
            this.ButtonConditionHasFriend.Location = new System.Drawing.Point(704, 18);
            this.ButtonConditionHasFriend.Name = "ButtonConditionHasFriend";
            this.ButtonConditionHasFriend.Size = new System.Drawing.Size(112, 24);
            this.ButtonConditionHasFriend.TabIndex = 5;
            this.ButtonConditionHasFriend.Text = "Tiene (condición)";
            this.ButtonConditionHasFriend.UseVisualStyleBackColor = true;
            this.ButtonConditionHasFriend.Click += new System.EventHandler(this.ButtonConditionItem_Click);
            // 
            // ButtonConditionDoesntHaveStatus
            // 
            this.ButtonConditionDoesntHaveStatus.Location = new System.Drawing.Point(447, 352);
            this.ButtonConditionDoesntHaveStatus.Name = "ButtonConditionDoesntHaveStatus";
            this.ButtonConditionDoesntHaveStatus.Size = new System.Drawing.Size(112, 23);
            this.ButtonConditionDoesntHaveStatus.TabIndex = 5;
            this.ButtonConditionDoesntHaveStatus.Text = "No tiene (condición)";
            this.ButtonConditionDoesntHaveStatus.UseVisualStyleBackColor = true;
            this.ButtonConditionDoesntHaveStatus.Click += new System.EventHandler(this.ButtonConditionItem_Click);
            // 
            // ButtonConditionHasStatus
            // 
            this.ButtonConditionHasStatus.Location = new System.Drawing.Point(447, 323);
            this.ButtonConditionHasStatus.Name = "ButtonConditionHasStatus";
            this.ButtonConditionHasStatus.Size = new System.Drawing.Size(112, 23);
            this.ButtonConditionHasStatus.TabIndex = 5;
            this.ButtonConditionHasStatus.Text = "Tiene (condición)";
            this.ButtonConditionHasStatus.UseVisualStyleBackColor = true;
            this.ButtonConditionHasStatus.Click += new System.EventHandler(this.ButtonConditionItem_Click);
            // 
            // ButtonConditionDoesntHaveObject
            // 
            this.ButtonConditionDoesntHaveObject.Location = new System.Drawing.Point(447, 47);
            this.ButtonConditionDoesntHaveObject.Name = "ButtonConditionDoesntHaveObject";
            this.ButtonConditionDoesntHaveObject.Size = new System.Drawing.Size(112, 23);
            this.ButtonConditionDoesntHaveObject.TabIndex = 5;
            this.ButtonConditionDoesntHaveObject.Text = "No tiene (condición)";
            this.ButtonConditionDoesntHaveObject.UseVisualStyleBackColor = true;
            this.ButtonConditionDoesntHaveObject.Click += new System.EventHandler(this.ButtonConditionItem_Click);
            // 
            // ButtonConditionHasObject
            // 
            this.ButtonConditionHasObject.Location = new System.Drawing.Point(447, 18);
            this.ButtonConditionHasObject.Name = "ButtonConditionHasObject";
            this.ButtonConditionHasObject.Size = new System.Drawing.Size(112, 23);
            this.ButtonConditionHasObject.TabIndex = 5;
            this.ButtonConditionHasObject.Text = "Tiene (condición)";
            this.ButtonConditionHasObject.UseVisualStyleBackColor = true;
            this.ButtonConditionHasObject.Click += new System.EventHandler(this.ButtonConditionItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "(deben cumplirse todas)";
            // 
            // ListBackground
            // 
            this.ListBackground.FormattingEnabled = true;
            this.ListBackground.Location = new System.Drawing.Point(578, 323);
            this.ListBackground.Name = "ListBackground";
            this.ListBackground.Size = new System.Drawing.Size(120, 251);
            this.ListBackground.TabIndex = 4;
            // 
            // ListStatuses
            // 
            this.ListStatuses.FormattingEnabled = true;
            this.ListStatuses.Location = new System.Drawing.Point(321, 323);
            this.ListStatuses.Name = "ListStatuses";
            this.ListStatuses.Size = new System.Drawing.Size(120, 251);
            this.ListStatuses.TabIndex = 4;
            // 
            // ListCharacters
            // 
            this.ListCharacters.FormattingEnabled = true;
            this.ListCharacters.Location = new System.Drawing.Point(578, 20);
            this.ListCharacters.Name = "ListCharacters";
            this.ListCharacters.Size = new System.Drawing.Size(120, 290);
            this.ListCharacters.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Resultado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Condición";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Texto";
            // 
            // ListObjects
            // 
            this.ListObjects.FormattingEnabled = true;
            this.ListObjects.Location = new System.Drawing.Point(321, 19);
            this.ListObjects.Name = "ListObjects";
            this.ListObjects.Size = new System.Drawing.Size(120, 290);
            this.ListObjects.TabIndex = 4;
            // 
            // TextNewResultDialog
            // 
            this.TextNewResultDialog.Location = new System.Drawing.Point(167, 127);
            this.TextNewResultDialog.Multiline = true;
            this.TextNewResultDialog.Name = "TextNewResultDialog";
            this.TextNewResultDialog.Size = new System.Drawing.Size(127, 51);
            this.TextNewResultDialog.TabIndex = 2;
            // 
            // TextNewConditionDialog
            // 
            this.TextNewConditionDialog.Location = new System.Drawing.Point(167, 54);
            this.TextNewConditionDialog.Multiline = true;
            this.TextNewConditionDialog.Name = "TextNewConditionDialog";
            this.TextNewConditionDialog.Size = new System.Drawing.Size(127, 46);
            this.TextNewConditionDialog.TabIndex = 2;
            // 
            // TextNewTextDialog
            // 
            this.TextNewTextDialog.Location = new System.Drawing.Point(11, 93);
            this.TextNewTextDialog.Multiline = true;
            this.TextNewTextDialog.Name = "TextNewTextDialog";
            this.TextNewTextDialog.Size = new System.Drawing.Size(127, 85);
            this.TextNewTextDialog.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Personaje";
            // 
            // ComboCharacters
            // 
            this.ComboCharacters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboCharacters.FormattingEnabled = true;
            this.ComboCharacters.Location = new System.Drawing.Point(11, 39);
            this.ComboCharacters.Name = "ComboCharacters";
            this.ComboCharacters.Size = new System.Drawing.Size(127, 21);
            this.ComboCharacters.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 608);
            this.Controls.Add(this.DialogGroup);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Builder";
            this.Load += new System.EventHandler(this.Main_Load);
            this.DialogGroup.ResumeLayout(false);
            this.DialogGroup.PerformLayout();
            this.GroupItems.ResumeLayout(false);
            this.GroupItems.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DialogGroup;
        private System.Windows.Forms.GroupBox GroupItems;
        private System.Windows.Forms.Button ButtonAddItem;
        private System.Windows.Forms.RadioButton RadioTypeItemStatus;
        private System.Windows.Forms.RadioButton RadioTypeItemCharacter;
        private System.Windows.Forms.RadioButton RadioTypeItemObject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextItemName;
        private System.Windows.Forms.ListBox ListStatuses;
        private System.Windows.Forms.ListBox ListCharacters;
        private System.Windows.Forms.ListBox ListObjects;
        private System.Windows.Forms.Button ButtonResultLosesObject;
        private System.Windows.Forms.Button ButtonResultGetsObject;
        private System.Windows.Forms.Button ButtonConditionDoesntHaveObject;
        private System.Windows.Forms.Button ButtonConditionHasObject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextNewResultDialog;
        private System.Windows.Forms.TextBox TextNewConditionDialog;
        private System.Windows.Forms.TextBox TextNewTextDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboCharacters;
        private System.Windows.Forms.Button ButtonResultLosesFriend;
        private System.Windows.Forms.Button ButtonResultLosesStatus;
        private System.Windows.Forms.Button ButtonResultGetsFriend;
        private System.Windows.Forms.Button ButtonResultGetsStatus;
        private System.Windows.Forms.Button ButtonConditionDoesntHaveFriend;
        private System.Windows.Forms.Button ButtonConditionHasFriend;
        private System.Windows.Forms.Button ButtonConditionDoesntHaveStatus;
        private System.Windows.Forms.Button ButtonConditionHasStatus;
        private System.Windows.Forms.Button ButtonAddDialog;
        private System.Windows.Forms.RadioButton RadioTypeItemBackground;
        private System.Windows.Forms.Button ButtonChangeBackground;
        private System.Windows.Forms.ListBox ListBackground;
        private System.Windows.Forms.Button ButtonNextDialog;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonNextDecision;
    }
}

