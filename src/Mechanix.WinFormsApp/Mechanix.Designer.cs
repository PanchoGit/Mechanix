namespace Mechanix.WinFormsApp
{
    partial class Mechanix
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
            this.BrandTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PatentTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OwnerFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.OwnerLastNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ServiceListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BrandTextBox
            // 
            this.BrandTextBox.Location = new System.Drawing.Point(137, 35);
            this.BrandTextBox.Name = "BrandTextBox";
            this.BrandTextBox.Size = new System.Drawing.Size(159, 20);
            this.BrandTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Marca";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // YearTextBox
            // 
            this.YearTextBox.Location = new System.Drawing.Point(137, 61);
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.Size = new System.Drawing.Size(159, 20);
            this.YearTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Año";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PatentTextBox
            // 
            this.PatentTextBox.Location = new System.Drawing.Point(137, 87);
            this.PatentTextBox.Name = "PatentTextBox";
            this.PatentTextBox.Size = new System.Drawing.Size(159, 20);
            this.PatentTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Patente";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OwnerFirstNameTextBox
            // 
            this.OwnerFirstNameTextBox.Location = new System.Drawing.Point(137, 113);
            this.OwnerFirstNameTextBox.Name = "OwnerFirstNameTextBox";
            this.OwnerFirstNameTextBox.Size = new System.Drawing.Size(159, 20);
            this.OwnerFirstNameTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nombre";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OwnerLastNameTextBox
            // 
            this.OwnerLastNameTextBox.Location = new System.Drawing.Point(137, 139);
            this.OwnerLastNameTextBox.Name = "OwnerLastNameTextBox";
            this.OwnerLastNameTextBox.Size = new System.Drawing.Size(159, 20);
            this.OwnerLastNameTextBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Apellido";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ServiceListBox
            // 
            this.ServiceListBox.FormattingEnabled = true;
            this.ServiceListBox.Location = new System.Drawing.Point(137, 166);
            this.ServiceListBox.Name = "ServiceListBox";
            this.ServiceListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ServiceListBox.Size = new System.Drawing.Size(159, 95);
            this.ServiceListBox.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Servicio";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(69, 286);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(227, 23);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Guardar";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Mechanix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 370);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ServiceListBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OwnerLastNameTextBox);
            this.Controls.Add(this.OwnerFirstNameTextBox);
            this.Controls.Add(this.PatentTextBox);
            this.Controls.Add(this.YearTextBox);
            this.Controls.Add(this.BrandTextBox);
            this.Name = "Mechanix";
            this.Text = "Mechanix";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox BrandTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox YearTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PatentTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OwnerFirstNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox OwnerLastNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox ServiceListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SaveButton;
    }
}

