
namespace ComputerCaseUI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BuildButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.frontFansComboBox = new System.Windows.Forms.ComboBox();
            this.frontFansCountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.frontFansDiameterTextBox = new System.Windows.Forms.TextBox();
            this.frontFansDiametrLabel = new System.Windows.Forms.Label();
            this.fansInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.upperFansComboBox = new System.Windows.Forms.ComboBox();
            this.upperFansCountLabel = new System.Windows.Forms.Label();
            this.upperFansDiameterBordersLabel = new System.Windows.Forms.Label();
            this.upperFansDiameterTextBox = new System.Windows.Forms.TextBox();
            this.upperFansDiametrLabel = new System.Windows.Forms.Label();
            this.motherboardGroupBox = new System.Windows.Forms.GroupBox();
            this.motherboardComboBox = new System.Windows.Forms.ComboBox();
            this.caseInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.lengthBordersLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.heightBordersLabel = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.fansInfoGroupBox.SuspendLayout();
            this.motherboardGroupBox.SuspendLayout();
            this.caseInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BuildButton);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.fansInfoGroupBox);
            this.splitContainer1.Panel1.Controls.Add(this.motherboardGroupBox);
            this.splitContainer1.Panel1.Controls.Add(this.caseInfoGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(876, 482);
            this.splitContainer1.SplitterDistance = 414;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(297, 462);
            this.BuildButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(112, 35);
            this.BuildButton.TabIndex = 1;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.frontFansComboBox);
            this.groupBox1.Controls.Add(this.frontFansCountLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.frontFansDiameterTextBox);
            this.groupBox1.Controls.Add(this.frontFansDiametrLabel);
            this.groupBox1.Location = new System.Drawing.Point(4, 349);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(405, 103);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Передние вентиляторы";
            // 
            // frontFansComboBox
            // 
            this.frontFansComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frontFansComboBox.FormattingEnabled = true;
            this.frontFansComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.frontFansComboBox.Location = new System.Drawing.Point(123, 66);
            this.frontFansComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.frontFansComboBox.Name = "frontFansComboBox";
            this.frontFansComboBox.Size = new System.Drawing.Size(92, 28);
            this.frontFansComboBox.TabIndex = 20;
            this.frontFansComboBox.SelectedIndexChanged += new System.EventHandler(this.FrontFansComboBox_SelectedIndexChanged);
            // 
            // frontFansCountLabel
            // 
            this.frontFansCountLabel.AutoSize = true;
            this.frontFansCountLabel.Location = new System.Drawing.Point(9, 71);
            this.frontFansCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.frontFansCountLabel.Name = "frontFansCountLabel";
            this.frontFansCountLabel.Size = new System.Drawing.Size(100, 20);
            this.frontFansCountLabel.TabIndex = 19;
            this.frontFansCountLabel.Text = "Количество";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "(от 40 мм до 140 мм)";
            // 
            // frontFansDiameterTextBox
            // 
            this.frontFansDiameterTextBox.Location = new System.Drawing.Point(123, 28);
            this.frontFansDiameterTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.frontFansDiameterTextBox.Name = "frontFansDiameterTextBox";
            this.frontFansDiameterTextBox.Size = new System.Drawing.Size(92, 26);
            this.frontFansDiameterTextBox.TabIndex = 17;
            this.frontFansDiameterTextBox.TextChanged += new System.EventHandler(this.ParametersTextChanged);
            // 
            // frontFansDiametrLabel
            // 
            this.frontFansDiametrLabel.AutoSize = true;
            this.frontFansDiametrLabel.Location = new System.Drawing.Point(9, 32);
            this.frontFansDiametrLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.frontFansDiametrLabel.Name = "frontFansDiametrLabel";
            this.frontFansDiametrLabel.Size = new System.Drawing.Size(102, 20);
            this.frontFansDiametrLabel.TabIndex = 16;
            this.frontFansDiametrLabel.Text = "Диаметр (E)";
            // 
            // fansInfoGroupBox
            // 
            this.fansInfoGroupBox.Controls.Add(this.upperFansComboBox);
            this.fansInfoGroupBox.Controls.Add(this.upperFansCountLabel);
            this.fansInfoGroupBox.Controls.Add(this.upperFansDiameterBordersLabel);
            this.fansInfoGroupBox.Controls.Add(this.upperFansDiameterTextBox);
            this.fansInfoGroupBox.Controls.Add(this.upperFansDiametrLabel);
            this.fansInfoGroupBox.Location = new System.Drawing.Point(4, 240);
            this.fansInfoGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fansInfoGroupBox.Name = "fansInfoGroupBox";
            this.fansInfoGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fansInfoGroupBox.Size = new System.Drawing.Size(406, 108);
            this.fansInfoGroupBox.TabIndex = 5;
            this.fansInfoGroupBox.TabStop = false;
            this.fansInfoGroupBox.Text = "Верхние вентиляторы";
            // 
            // upperFansComboBox
            // 
            this.upperFansComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.upperFansComboBox.FormattingEnabled = true;
            this.upperFansComboBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.upperFansComboBox.Location = new System.Drawing.Point(123, 68);
            this.upperFansComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upperFansComboBox.Name = "upperFansComboBox";
            this.upperFansComboBox.Size = new System.Drawing.Size(92, 28);
            this.upperFansComboBox.TabIndex = 5;
            this.upperFansComboBox.SelectedIndexChanged += new System.EventHandler(this.UpperFansComboBox_SelectedIndexChanged);
            // 
            // upperFansCountLabel
            // 
            this.upperFansCountLabel.AutoSize = true;
            this.upperFansCountLabel.Location = new System.Drawing.Point(9, 72);
            this.upperFansCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.upperFansCountLabel.Name = "upperFansCountLabel";
            this.upperFansCountLabel.Size = new System.Drawing.Size(100, 20);
            this.upperFansCountLabel.TabIndex = 4;
            this.upperFansCountLabel.Text = "Количество";
            // 
            // upperFansDiameterBordersLabel
            // 
            this.upperFansDiameterBordersLabel.AutoSize = true;
            this.upperFansDiameterBordersLabel.Location = new System.Drawing.Point(226, 34);
            this.upperFansDiameterBordersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.upperFansDiameterBordersLabel.Name = "upperFansDiameterBordersLabel";
            this.upperFansDiameterBordersLabel.Size = new System.Drawing.Size(166, 20);
            this.upperFansDiameterBordersLabel.TabIndex = 3;
            this.upperFansDiameterBordersLabel.Text = "(от 40 мм до 140 мм)";
            // 
            // upperFansDiameterTextBox
            // 
            this.upperFansDiameterTextBox.Location = new System.Drawing.Point(123, 29);
            this.upperFansDiameterTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upperFansDiameterTextBox.Name = "upperFansDiameterTextBox";
            this.upperFansDiameterTextBox.Size = new System.Drawing.Size(92, 26);
            this.upperFansDiameterTextBox.TabIndex = 2;
            this.upperFansDiameterTextBox.TextChanged += new System.EventHandler(this.ParametersTextChanged);
            // 
            // upperFansDiametrLabel
            // 
            this.upperFansDiametrLabel.AutoSize = true;
            this.upperFansDiametrLabel.Location = new System.Drawing.Point(9, 34);
            this.upperFansDiametrLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.upperFansDiametrLabel.Name = "upperFansDiametrLabel";
            this.upperFansDiametrLabel.Size = new System.Drawing.Size(103, 20);
            this.upperFansDiametrLabel.TabIndex = 1;
            this.upperFansDiametrLabel.Text = "Диаметр (D)";
            // 
            // motherboardGroupBox
            // 
            this.motherboardGroupBox.Controls.Add(this.motherboardComboBox);
            this.motherboardGroupBox.Location = new System.Drawing.Point(4, 169);
            this.motherboardGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.motherboardGroupBox.Name = "motherboardGroupBox";
            this.motherboardGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.motherboardGroupBox.Size = new System.Drawing.Size(406, 71);
            this.motherboardGroupBox.TabIndex = 4;
            this.motherboardGroupBox.TabStop = false;
            this.motherboardGroupBox.Text = "Тип материнской платы";
            // 
            // motherboardComboBox
            // 
            this.motherboardComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.motherboardComboBox.FormattingEnabled = true;
            this.motherboardComboBox.Items.AddRange(new object[] {
            "ATX",
            "Micro-ATX"});
            this.motherboardComboBox.Location = new System.Drawing.Point(14, 29);
            this.motherboardComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.motherboardComboBox.Name = "motherboardComboBox";
            this.motherboardComboBox.Size = new System.Drawing.Size(180, 28);
            this.motherboardComboBox.TabIndex = 0;
            this.motherboardComboBox.SelectedIndexChanged += new System.EventHandler(this.MotherboardComboBox_SelectedIndexChanged);
            // 
            // caseInfoGroupBox
            // 
            this.caseInfoGroupBox.Controls.Add(this.lengthBordersLabel);
            this.caseInfoGroupBox.Controls.Add(this.label2);
            this.caseInfoGroupBox.Controls.Add(this.heightBordersLabel);
            this.caseInfoGroupBox.Controls.Add(this.widthTextBox);
            this.caseInfoGroupBox.Controls.Add(this.lengthTextBox);
            this.caseInfoGroupBox.Controls.Add(this.lengthLabel);
            this.caseInfoGroupBox.Controls.Add(this.widthLabel);
            this.caseInfoGroupBox.Controls.Add(this.heightLabel);
            this.caseInfoGroupBox.Controls.Add(this.heightTextBox);
            this.caseInfoGroupBox.Location = new System.Drawing.Point(4, 5);
            this.caseInfoGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.caseInfoGroupBox.Name = "caseInfoGroupBox";
            this.caseInfoGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.caseInfoGroupBox.Size = new System.Drawing.Size(406, 155);
            this.caseInfoGroupBox.TabIndex = 3;
            this.caseInfoGroupBox.TabStop = false;
            this.caseInfoGroupBox.Text = "Корпус";
            // 
            // lengthBordersLabel
            // 
            this.lengthBordersLabel.AutoSize = true;
            this.lengthBordersLabel.Location = new System.Drawing.Point(226, 80);
            this.lengthBordersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lengthBordersLabel.Name = "lengthBordersLabel";
            this.lengthBordersLabel.Size = new System.Drawing.Size(175, 20);
            this.lengthBordersLabel.TabIndex = 20;
            this.lengthBordersLabel.Text = "(от 244 мм до 500 мм)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "(от 140 мм до 250 мм)";
            // 
            // heightBordersLabel
            // 
            this.heightBordersLabel.AutoSize = true;
            this.heightBordersLabel.Location = new System.Drawing.Point(226, 40);
            this.heightBordersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.heightBordersLabel.Name = "heightBordersLabel";
            this.heightBordersLabel.Size = new System.Drawing.Size(175, 20);
            this.heightBordersLabel.TabIndex = 18;
            this.heightBordersLabel.Text = "(от 330 мм до 500 мм)";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(123, 115);
            this.widthTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(92, 26);
            this.widthTextBox.TabIndex = 17;
            this.widthTextBox.TextChanged += new System.EventHandler(this.ParametersTextChanged);
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(123, 75);
            this.lengthTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(92, 26);
            this.lengthTextBox.TabIndex = 16;
            this.lengthTextBox.TextChanged += new System.EventHandler(this.ParametersTextChanged);
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(9, 80);
            this.lengthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(83, 20);
            this.lengthLabel.TabIndex = 15;
            this.lengthLabel.Text = "Длина (В)";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(9, 120);
            this.widthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(92, 20);
            this.widthLabel.TabIndex = 14;
            this.widthLabel.Text = "Ширина (С)";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(9, 40);
            this.heightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(91, 20);
            this.heightLabel.TabIndex = 13;
            this.heightLabel.Text = "Высота (А)";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(123, 35);
            this.heightTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(92, 26);
            this.heightTextBox.TabIndex = 12;
            this.heightTextBox.TextChanged += new System.EventHandler(this.ParametersTextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ComputerCaseUI.Properties.Resources.Деталь;
            this.pictureBox1.InitialImage = global::ComputerCaseUI.Properties.Resources.Деталь;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(456, 482);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.AutoPopDelay = 0;
            this.toolTip1.InitialDelay = 1;
            this.toolTip1.ReshowDelay = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 482);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(898, 538);
            this.MinimumSize = new System.Drawing.Size(898, 538);
            this.Name = "MainForm";
            this.Text = "ComputerCase";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.fansInfoGroupBox.ResumeLayout(false);
            this.fansInfoGroupBox.PerformLayout();
            this.motherboardGroupBox.ResumeLayout(false);
            this.caseInfoGroupBox.ResumeLayout(false);
            this.caseInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox fansInfoGroupBox;
        private System.Windows.Forms.Label upperFansCountLabel;
        private System.Windows.Forms.Label upperFansDiameterBordersLabel;
        private System.Windows.Forms.TextBox upperFansDiameterTextBox;
        private System.Windows.Forms.Label upperFansDiametrLabel;
        private System.Windows.Forms.GroupBox motherboardGroupBox;
        private System.Windows.Forms.GroupBox caseInfoGroupBox;
        private System.Windows.Forms.Label lengthBordersLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label heightBordersLabel;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label frontFansCountLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox frontFansDiameterTextBox;
        private System.Windows.Forms.Label frontFansDiametrLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.ComboBox frontFansComboBox;
        private System.Windows.Forms.ComboBox upperFansComboBox;
        private System.Windows.Forms.ComboBox motherboardComboBox;
    }
}

