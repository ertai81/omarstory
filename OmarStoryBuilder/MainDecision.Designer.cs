namespace OmarStoryBuilder
{
    partial class MainDecision
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
            this.DecisionGroup = new System.Windows.Forms.GroupBox();
            this.ButtonAddNewDecision = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.ButtonNextDecision = new System.Windows.Forms.Button();
            this.ButtonNextDialog = new System.Windows.Forms.Button();
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
            this.TextNewResultDecision = new System.Windows.Forms.TextBox();
            this.TextNewConditionDecision = new System.Windows.Forms.TextBox();
            this.TextNewTextDecision = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboOptions = new System.Windows.Forms.ComboBox();
            this.ButtonResetAll = new System.Windows.Forms.Button();
            this.ButtonDeleteThisOption = new System.Windows.Forms.Button();
            this.DecisionGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // DecisionGroup
            // 
            this.DecisionGroup.Controls.Add(this.ButtonDeleteThisOption);
            this.DecisionGroup.Controls.Add(this.ButtonResetAll);
            this.DecisionGroup.Controls.Add(this.ButtonAddNewDecision);
            this.DecisionGroup.Controls.Add(this.ButtonReset);
            this.DecisionGroup.Controls.Add(this.ButtonNextDecision);
            this.DecisionGroup.Controls.Add(this.ButtonNextDialog);
            this.DecisionGroup.Controls.Add(this.ButtonAddDialog);
            this.DecisionGroup.Controls.Add(this.ButtonResultLosesFriend);
            this.DecisionGroup.Controls.Add(this.ButtonResultLosesStatus);
            this.DecisionGroup.Controls.Add(this.ButtonResultGetsFriend);
            this.DecisionGroup.Controls.Add(this.ButtonResultLosesObject);
            this.DecisionGroup.Controls.Add(this.ButtonChangeBackground);
            this.DecisionGroup.Controls.Add(this.ButtonResultGetsStatus);
            this.DecisionGroup.Controls.Add(this.ButtonConditionDoesntHaveFriend);
            this.DecisionGroup.Controls.Add(this.ButtonResultGetsObject);
            this.DecisionGroup.Controls.Add(this.ButtonConditionHasFriend);
            this.DecisionGroup.Controls.Add(this.ButtonConditionDoesntHaveStatus);
            this.DecisionGroup.Controls.Add(this.ButtonConditionHasStatus);
            this.DecisionGroup.Controls.Add(this.ButtonConditionDoesntHaveObject);
            this.DecisionGroup.Controls.Add(this.ButtonConditionHasObject);
            this.DecisionGroup.Controls.Add(this.label5);
            this.DecisionGroup.Controls.Add(this.ListBackground);
            this.DecisionGroup.Controls.Add(this.ListStatuses);
            this.DecisionGroup.Controls.Add(this.ListCharacters);
            this.DecisionGroup.Controls.Add(this.label6);
            this.DecisionGroup.Controls.Add(this.label4);
            this.DecisionGroup.Controls.Add(this.label3);
            this.DecisionGroup.Controls.Add(this.ListObjects);
            this.DecisionGroup.Controls.Add(this.TextNewResultDecision);
            this.DecisionGroup.Controls.Add(this.TextNewConditionDecision);
            this.DecisionGroup.Controls.Add(this.TextNewTextDecision);
            this.DecisionGroup.Controls.Add(this.label2);
            this.DecisionGroup.Controls.Add(this.ComboOptions);
            this.DecisionGroup.Location = new System.Drawing.Point(12, 12);
            this.DecisionGroup.Name = "DecisionGroup";
            this.DecisionGroup.Size = new System.Drawing.Size(822, 584);
            this.DecisionGroup.TabIndex = 1;
            this.DecisionGroup.TabStop = false;
            this.DecisionGroup.Text = "Decisión";
            // 
            // ButtonAddNewDecision
            // 
            this.ButtonAddNewDecision.Location = new System.Drawing.Point(11, 185);
            this.ButtonAddNewDecision.Name = "ButtonAddNewDecision";
            this.ButtonAddNewDecision.Size = new System.Drawing.Size(127, 48);
            this.ButtonAddNewDecision.TabIndex = 9;
            this.ButtonAddNewDecision.Text = "Añadir nueva opción";
            this.ButtonAddNewDecision.UseVisualStyleBackColor = true;
            this.ButtonAddNewDecision.Click += new System.EventHandler(this.ButtonAddNewDecision_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(11, 264);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(109, 23);
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
            // ButtonAddDialog
            // 
            this.ButtonAddDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAddDialog.Location = new System.Drawing.Point(178, 519);
            this.ButtonAddDialog.Name = "ButtonAddDialog";
            this.ButtonAddDialog.Size = new System.Drawing.Size(128, 53);
            this.ButtonAddDialog.TabIndex = 6;
            this.ButtonAddDialog.Text = "Añadir decisiones";
            this.ButtonAddDialog.UseVisualStyleBackColor = true;
            this.ButtonAddDialog.Click += new System.EventHandler(this.ButtonAddDecision_Click);
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
            // TextNewResultDecision
            // 
            this.TextNewResultDecision.Location = new System.Drawing.Point(167, 127);
            this.TextNewResultDecision.Multiline = true;
            this.TextNewResultDecision.Name = "TextNewResultDecision";
            this.TextNewResultDecision.Size = new System.Drawing.Size(127, 51);
            this.TextNewResultDecision.TabIndex = 2;
            this.TextNewResultDecision.TextChanged += new System.EventHandler(this.TextNewResultDecision_TextChanged);
            // 
            // TextNewConditionDecision
            // 
            this.TextNewConditionDecision.Location = new System.Drawing.Point(167, 54);
            this.TextNewConditionDecision.Multiline = true;
            this.TextNewConditionDecision.Name = "TextNewConditionDecision";
            this.TextNewConditionDecision.Size = new System.Drawing.Size(127, 46);
            this.TextNewConditionDecision.TabIndex = 2;
            this.TextNewConditionDecision.TextChanged += new System.EventHandler(this.TextNewConditionDecision_TextChanged);
            // 
            // TextNewTextDecision
            // 
            this.TextNewTextDecision.Location = new System.Drawing.Point(11, 93);
            this.TextNewTextDecision.Multiline = true;
            this.TextNewTextDecision.Name = "TextNewTextDecision";
            this.TextNewTextDecision.Size = new System.Drawing.Size(127, 85);
            this.TextNewTextDecision.TabIndex = 2;
            this.TextNewTextDecision.TextChanged += new System.EventHandler(this.TextNewTextDecision_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Opciones";
            // 
            // ComboOptions
            // 
            this.ComboOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboOptions.FormattingEnabled = true;
            this.ComboOptions.Location = new System.Drawing.Point(11, 39);
            this.ComboOptions.Name = "ComboOptions";
            this.ComboOptions.Size = new System.Drawing.Size(127, 21);
            this.ComboOptions.TabIndex = 0;
            this.ComboOptions.SelectedIndexChanged += new System.EventHandler(this.ComboOptions_SelectedIndexChanged);
            // 
            // ButtonResetAll
            // 
            this.ButtonResetAll.Location = new System.Drawing.Point(11, 541);
            this.ButtonResetAll.Name = "ButtonResetAll";
            this.ButtonResetAll.Size = new System.Drawing.Size(75, 23);
            this.ButtonResetAll.TabIndex = 10;
            this.ButtonResetAll.Text = "Reset todo";
            this.ButtonResetAll.UseVisualStyleBackColor = true;
            this.ButtonResetAll.Click += new System.EventHandler(this.ButtonResetAll_Click);
            // 
            // ButtonDeleteThisOption
            // 
            this.ButtonDeleteThisOption.Location = new System.Drawing.Point(11, 293);
            this.ButtonDeleteThisOption.Name = "ButtonDeleteThisOption";
            this.ButtonDeleteThisOption.Size = new System.Drawing.Size(109, 23);
            this.ButtonDeleteThisOption.TabIndex = 11;
            this.ButtonDeleteThisOption.Text = "Borrar esta opción";
            this.ButtonDeleteThisOption.UseVisualStyleBackColor = true;
            this.ButtonDeleteThisOption.Click += new System.EventHandler(this.ButtonDeleteThisOption_Click);
            // 
            // MainDecision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 588);
            this.Controls.Add(this.DecisionGroup);
            this.Name = "MainDecision";
            this.Text = "MainDecision";
            this.DecisionGroup.ResumeLayout(false);
            this.DecisionGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DecisionGroup;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonNextDecision;
        private System.Windows.Forms.Button ButtonNextDialog;
        private System.Windows.Forms.Button ButtonAddDialog;
        private System.Windows.Forms.Button ButtonResultLosesFriend;
        private System.Windows.Forms.Button ButtonResultLosesStatus;
        private System.Windows.Forms.Button ButtonResultGetsFriend;
        private System.Windows.Forms.Button ButtonResultLosesObject;
        private System.Windows.Forms.Button ButtonChangeBackground;
        private System.Windows.Forms.Button ButtonResultGetsStatus;
        private System.Windows.Forms.Button ButtonConditionDoesntHaveFriend;
        private System.Windows.Forms.Button ButtonResultGetsObject;
        private System.Windows.Forms.Button ButtonConditionHasFriend;
        private System.Windows.Forms.Button ButtonConditionDoesntHaveStatus;
        private System.Windows.Forms.Button ButtonConditionHasStatus;
        private System.Windows.Forms.Button ButtonConditionDoesntHaveObject;
        private System.Windows.Forms.Button ButtonConditionHasObject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox ListBackground;
        private System.Windows.Forms.ListBox ListStatuses;
        private System.Windows.Forms.ListBox ListCharacters;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ListObjects;
        private System.Windows.Forms.TextBox TextNewResultDecision;
        private System.Windows.Forms.TextBox TextNewConditionDecision;
        private System.Windows.Forms.TextBox TextNewTextDecision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboOptions;
        private System.Windows.Forms.Button ButtonAddNewDecision;
        private System.Windows.Forms.Button ButtonResetAll;
        private System.Windows.Forms.Button ButtonDeleteThisOption;
    }
}