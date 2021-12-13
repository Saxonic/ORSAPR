
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
            this.threeFrontFanRadio = new System.Windows.Forms.RadioButton();
            this.twoFrontFanRadio = new System.Windows.Forms.RadioButton();
            this.oneFrontFanRadio = new System.Windows.Forms.RadioButton();
            this.frontFansCountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FrontFansDiameterTextBox = new System.Windows.Forms.TextBox();
            this.frontFansDiametrLabel = new System.Windows.Forms.Label();
            this.fansInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.twoApperFanRadio = new System.Windows.Forms.RadioButton();
            this.oneUpperFanRadio = new System.Windows.Forms.RadioButton();
            this.upperFansCountLabel = new System.Windows.Forms.Label();
            this.upperFansDiametrBordersLabel = new System.Windows.Forms.Label();
            this.UpperFansDiameterTextBox = new System.Windows.Forms.TextBox();
            this.upperFansDiametrLabel = new System.Windows.Forms.Label();
            this.motherboardGroupBox = new System.Windows.Forms.GroupBox();
            this.microATXRadio = new System.Windows.Forms.RadioButton();
            this.ATXRadio = new System.Windows.Forms.RadioButton();
            this.caseInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.lengthBordersLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.heightBordersLabel = new System.Windows.Forms.Label();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.LengthTextBox = new System.Windows.Forms.TextBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
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
            this.splitContainer1.Size = new System.Drawing.Size(605, 346);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 0;
            // 
            // BuildButton
            // 
            this.BuildButton.Enabled = false;
            this.BuildButton.Location = new System.Drawing.Point(198, 316);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(75, 23);
            this.BuildButton.TabIndex = 1;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.threeFrontFanRadio);
            this.groupBox1.Controls.Add(this.twoFrontFanRadio);
            this.groupBox1.Controls.Add(this.oneFrontFanRadio);
            this.groupBox1.Controls.Add(this.frontFansCountLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FrontFansDiameterTextBox);
            this.groupBox1.Controls.Add(this.frontFansDiametrLabel);
            this.groupBox1.Location = new System.Drawing.Point(3, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 67);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Передние вентиляторы";
            // 
            // threeFrontFanRadio
            // 
            this.threeFrontFanRadio.AutoSize = true;
            this.threeFrontFanRadio.Location = new System.Drawing.Point(154, 44);
            this.threeFrontFanRadio.Name = "threeFrontFanRadio";
            this.threeFrontFanRadio.Size = new System.Drawing.Size(31, 17);
            this.threeFrontFanRadio.TabIndex = 22;
            this.threeFrontFanRadio.Text = "3";
            this.threeFrontFanRadio.UseVisualStyleBackColor = true;
            this.threeFrontFanRadio.CheckedChanged += new System.EventHandler(this.frontFanCountRadio_CheckedChanged);
            // 
            // twoFrontFanRadio
            // 
            this.twoFrontFanRadio.AutoSize = true;
            this.twoFrontFanRadio.Location = new System.Drawing.Point(117, 44);
            this.twoFrontFanRadio.Name = "twoFrontFanRadio";
            this.twoFrontFanRadio.Size = new System.Drawing.Size(31, 17);
            this.twoFrontFanRadio.TabIndex = 21;
            this.twoFrontFanRadio.Text = "2";
            this.twoFrontFanRadio.UseVisualStyleBackColor = true;
            this.twoFrontFanRadio.CheckedChanged += new System.EventHandler(this.frontFanCountRadio_CheckedChanged);
            // 
            // oneFrontFanRadio
            // 
            this.oneFrontFanRadio.AutoSize = true;
            this.oneFrontFanRadio.Checked = true;
            this.oneFrontFanRadio.Location = new System.Drawing.Point(82, 44);
            this.oneFrontFanRadio.Name = "oneFrontFanRadio";
            this.oneFrontFanRadio.Size = new System.Drawing.Size(31, 17);
            this.oneFrontFanRadio.TabIndex = 20;
            this.oneFrontFanRadio.TabStop = true;
            this.oneFrontFanRadio.Text = "1";
            this.oneFrontFanRadio.UseVisualStyleBackColor = true;
            this.oneFrontFanRadio.CheckedChanged += new System.EventHandler(this.frontFanCountRadio_CheckedChanged);
            // 
            // frontFansCountLabel
            // 
            this.frontFansCountLabel.AutoSize = true;
            this.frontFansCountLabel.Location = new System.Drawing.Point(6, 46);
            this.frontFansCountLabel.Name = "frontFansCountLabel";
            this.frontFansCountLabel.Size = new System.Drawing.Size(66, 13);
            this.frontFansCountLabel.TabIndex = 19;
            this.frontFansCountLabel.Text = "Количество";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "(от 40 мм до 140 мм)";
            // 
            // FrontFansDiameterTextBox
            // 
            this.FrontFansDiameterTextBox.Location = new System.Drawing.Point(82, 18);
            this.FrontFansDiameterTextBox.Name = "FrontFansDiameterTextBox";
            this.FrontFansDiameterTextBox.Size = new System.Drawing.Size(63, 20);
            this.FrontFansDiameterTextBox.TabIndex = 17;
            this.FrontFansDiameterTextBox.TextChanged += new System.EventHandler(this.FrontFansDiameterTextBox_TextChanged);
            // 
            // frontFansDiametrLabel
            // 
            this.frontFansDiametrLabel.AutoSize = true;
            this.frontFansDiametrLabel.Location = new System.Drawing.Point(6, 21);
            this.frontFansDiametrLabel.Name = "frontFansDiametrLabel";
            this.frontFansDiametrLabel.Size = new System.Drawing.Size(69, 13);
            this.frontFansDiametrLabel.TabIndex = 16;
            this.frontFansDiametrLabel.Text = "Диаметр (E)";
            // 
            // fansInfoGroupBox
            // 
            this.fansInfoGroupBox.Controls.Add(this.twoApperFanRadio);
            this.fansInfoGroupBox.Controls.Add(this.oneUpperFanRadio);
            this.fansInfoGroupBox.Controls.Add(this.upperFansCountLabel);
            this.fansInfoGroupBox.Controls.Add(this.upperFansDiametrBordersLabel);
            this.fansInfoGroupBox.Controls.Add(this.UpperFansDiameterTextBox);
            this.fansInfoGroupBox.Controls.Add(this.upperFansDiametrLabel);
            this.fansInfoGroupBox.Location = new System.Drawing.Point(3, 175);
            this.fansInfoGroupBox.Name = "fansInfoGroupBox";
            this.fansInfoGroupBox.Size = new System.Drawing.Size(271, 69);
            this.fansInfoGroupBox.TabIndex = 5;
            this.fansInfoGroupBox.TabStop = false;
            this.fansInfoGroupBox.Text = "Верхние вентиляторы";
            // 
            // twoApperFanRadio
            // 
            this.twoApperFanRadio.AutoSize = true;
            this.twoApperFanRadio.Location = new System.Drawing.Point(117, 45);
            this.twoApperFanRadio.Name = "twoApperFanRadio";
            this.twoApperFanRadio.Size = new System.Drawing.Size(31, 17);
            this.twoApperFanRadio.TabIndex = 6;
            this.twoApperFanRadio.Text = "2";
            this.twoApperFanRadio.UseVisualStyleBackColor = true;
            this.twoApperFanRadio.CheckedChanged += new System.EventHandler(this.upperFanCountRadio_CheckedChanged);
            // 
            // oneUpperFanRadio
            // 
            this.oneUpperFanRadio.AutoSize = true;
            this.oneUpperFanRadio.Checked = true;
            this.oneUpperFanRadio.Location = new System.Drawing.Point(82, 45);
            this.oneUpperFanRadio.Name = "oneUpperFanRadio";
            this.oneUpperFanRadio.Size = new System.Drawing.Size(31, 17);
            this.oneUpperFanRadio.TabIndex = 5;
            this.oneUpperFanRadio.TabStop = true;
            this.oneUpperFanRadio.Text = "1";
            this.oneUpperFanRadio.UseVisualStyleBackColor = true;
            this.oneUpperFanRadio.CheckedChanged += new System.EventHandler(this.upperFanCountRadio_CheckedChanged);
            // 
            // upperFansCountLabel
            // 
            this.upperFansCountLabel.AutoSize = true;
            this.upperFansCountLabel.Location = new System.Drawing.Point(6, 47);
            this.upperFansCountLabel.Name = "upperFansCountLabel";
            this.upperFansCountLabel.Size = new System.Drawing.Size(66, 13);
            this.upperFansCountLabel.TabIndex = 4;
            this.upperFansCountLabel.Text = "Количество";
            // 
            // upperFansDiametrBordersLabel
            // 
            this.upperFansDiametrBordersLabel.AutoSize = true;
            this.upperFansDiametrBordersLabel.Location = new System.Drawing.Point(151, 22);
            this.upperFansDiametrBordersLabel.Name = "upperFansDiametrBordersLabel";
            this.upperFansDiametrBordersLabel.Size = new System.Drawing.Size(113, 13);
            this.upperFansDiametrBordersLabel.TabIndex = 3;
            this.upperFansDiametrBordersLabel.Text = "(от 40 мм до 140 мм)";
            // 
            // UpperFansDiameterTextBox
            // 
            this.UpperFansDiameterTextBox.Location = new System.Drawing.Point(82, 19);
            this.UpperFansDiameterTextBox.Name = "UpperFansDiameterTextBox";
            this.UpperFansDiameterTextBox.Size = new System.Drawing.Size(63, 20);
            this.UpperFansDiameterTextBox.TabIndex = 2;
            this.UpperFansDiameterTextBox.TextChanged += new System.EventHandler(this.UpperFansDiameterTextBox_TextChanged);
            // 
            // upperFansDiametrLabel
            // 
            this.upperFansDiametrLabel.AutoSize = true;
            this.upperFansDiametrLabel.Location = new System.Drawing.Point(6, 22);
            this.upperFansDiametrLabel.Name = "upperFansDiametrLabel";
            this.upperFansDiametrLabel.Size = new System.Drawing.Size(70, 13);
            this.upperFansDiametrLabel.TabIndex = 1;
            this.upperFansDiametrLabel.Text = "Диаметр (D)";
            // 
            // motherboardGroupBox
            // 
            this.motherboardGroupBox.Controls.Add(this.microATXRadio);
            this.motherboardGroupBox.Controls.Add(this.ATXRadio);
            this.motherboardGroupBox.Location = new System.Drawing.Point(3, 110);
            this.motherboardGroupBox.Name = "motherboardGroupBox";
            this.motherboardGroupBox.Size = new System.Drawing.Size(271, 63);
            this.motherboardGroupBox.TabIndex = 4;
            this.motherboardGroupBox.TabStop = false;
            this.motherboardGroupBox.Text = "Тип материнской платы";
            // 
            // microATXRadio
            // 
            this.microATXRadio.AutoSize = true;
            this.microATXRadio.Location = new System.Drawing.Point(9, 42);
            this.microATXRadio.Name = "microATXRadio";
            this.microATXRadio.Size = new System.Drawing.Size(74, 17);
            this.microATXRadio.TabIndex = 1;
            this.microATXRadio.TabStop = true;
            this.microATXRadio.Text = "micro-ATX";
            this.microATXRadio.UseVisualStyleBackColor = true;
            this.microATXRadio.CheckedChanged += new System.EventHandler(this.microATXRadio_CheckedChanged);
            // 
            // ATXRadio
            // 
            this.ATXRadio.AutoSize = true;
            this.ATXRadio.Checked = true;
            this.ATXRadio.Location = new System.Drawing.Point(9, 19);
            this.ATXRadio.Name = "ATXRadio";
            this.ATXRadio.Size = new System.Drawing.Size(46, 17);
            this.ATXRadio.TabIndex = 0;
            this.ATXRadio.TabStop = true;
            this.ATXRadio.Text = "ATX";
            this.ATXRadio.UseVisualStyleBackColor = true;
            this.ATXRadio.CheckedChanged += new System.EventHandler(this.ATXRadio_CheckedChanged);
            // 
            // caseInfoGroupBox
            // 
            this.caseInfoGroupBox.Controls.Add(this.lengthBordersLabel);
            this.caseInfoGroupBox.Controls.Add(this.label2);
            this.caseInfoGroupBox.Controls.Add(this.heightBordersLabel);
            this.caseInfoGroupBox.Controls.Add(this.WidthTextBox);
            this.caseInfoGroupBox.Controls.Add(this.LengthTextBox);
            this.caseInfoGroupBox.Controls.Add(this.lengthLabel);
            this.caseInfoGroupBox.Controls.Add(this.widthLabel);
            this.caseInfoGroupBox.Controls.Add(this.heightLabel);
            this.caseInfoGroupBox.Controls.Add(this.HeightTextBox);
            this.caseInfoGroupBox.Location = new System.Drawing.Point(3, 3);
            this.caseInfoGroupBox.Name = "caseInfoGroupBox";
            this.caseInfoGroupBox.Size = new System.Drawing.Size(271, 101);
            this.caseInfoGroupBox.TabIndex = 3;
            this.caseInfoGroupBox.TabStop = false;
            this.caseInfoGroupBox.Text = "Корпус";
            // 
            // lengthBordersLabel
            // 
            this.lengthBordersLabel.AutoSize = true;
            this.lengthBordersLabel.Location = new System.Drawing.Point(151, 52);
            this.lengthBordersLabel.Name = "lengthBordersLabel";
            this.lengthBordersLabel.Size = new System.Drawing.Size(119, 13);
            this.lengthBordersLabel.TabIndex = 20;
            this.lengthBordersLabel.Text = "(от 244 мм до 500 мм)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "(от 140 мм до 250 мм)";
            // 
            // heightBordersLabel
            // 
            this.heightBordersLabel.AutoSize = true;
            this.heightBordersLabel.Location = new System.Drawing.Point(151, 26);
            this.heightBordersLabel.Name = "heightBordersLabel";
            this.heightBordersLabel.Size = new System.Drawing.Size(119, 13);
            this.heightBordersLabel.TabIndex = 18;
            this.heightBordersLabel.Text = "(от 330 мм до 500 мм)";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(82, 75);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(63, 20);
            this.WidthTextBox.TabIndex = 17;
            this.WidthTextBox.TextChanged += new System.EventHandler(this.WidthTextBox_TextChanged);
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Location = new System.Drawing.Point(82, 49);
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(63, 20);
            this.LengthTextBox.TabIndex = 16;
            this.LengthTextBox.TextChanged += new System.EventHandler(this.LengthTextBox_TextChanged);
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(6, 52);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(56, 13);
            this.lengthLabel.TabIndex = 15;
            this.lengthLabel.Text = "Длина (В)";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(6, 78);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(62, 13);
            this.widthLabel.TabIndex = 14;
            this.widthLabel.Text = "Ширина (С)";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(6, 26);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(61, 13);
            this.heightLabel.TabIndex = 13;
            this.heightLabel.Text = "Высота (А)";
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(82, 23);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(63, 20);
            this.HeightTextBox.TabIndex = 12;
            this.HeightTextBox.TextChanged += new System.EventHandler(this.HeightTextBox_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ComputerCaseUI.Properties.Resources.Деталь;
            this.pictureBox1.InitialImage = global::ComputerCaseUI.Properties.Resources.Деталь;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(321, 346);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 346);
            this.Controls.Add(this.splitContainer1);
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
            this.motherboardGroupBox.PerformLayout();
            this.caseInfoGroupBox.ResumeLayout(false);
            this.caseInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox fansInfoGroupBox;
        private System.Windows.Forms.RadioButton twoApperFanRadio;
        private System.Windows.Forms.RadioButton oneUpperFanRadio;
        private System.Windows.Forms.Label upperFansCountLabel;
        private System.Windows.Forms.Label upperFansDiametrBordersLabel;
        private System.Windows.Forms.TextBox UpperFansDiameterTextBox;
        private System.Windows.Forms.Label upperFansDiametrLabel;
        private System.Windows.Forms.GroupBox motherboardGroupBox;
        private System.Windows.Forms.RadioButton microATXRadio;
        private System.Windows.Forms.RadioButton ATXRadio;
        private System.Windows.Forms.GroupBox caseInfoGroupBox;
        private System.Windows.Forms.Label lengthBordersLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label heightBordersLabel;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.TextBox LengthTextBox;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton threeFrontFanRadio;
        private System.Windows.Forms.RadioButton twoFrontFanRadio;
        private System.Windows.Forms.RadioButton oneFrontFanRadio;
        private System.Windows.Forms.Label frontFansCountLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FrontFansDiameterTextBox;
        private System.Windows.Forms.Label frontFansDiametrLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BuildButton;
    }
}

