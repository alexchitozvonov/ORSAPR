namespace TrafficConeBuilder.UI
{
    partial class TrafficConeForm
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
            this.startKompasButton = new System.Windows.Forms.Button();
            this.closeKompasButton = new System.Windows.Forms.Button();
            this.buildConeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.baseWidthTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.coneWidthTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.baseHeightTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lowerHoleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.baseConeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // startKompasButton
            // 
            this.startKompasButton.Location = new System.Drawing.Point(7, 28);
            this.startKompasButton.Margin = new System.Windows.Forms.Padding(4);
            this.startKompasButton.Name = "startKompasButton";
            this.startKompasButton.Size = new System.Drawing.Size(120, 42);
            this.startKompasButton.TabIndex = 0;
            this.startKompasButton.Text = "Start Kompas";
            this.startKompasButton.UseVisualStyleBackColor = true;
            this.startKompasButton.Click += new System.EventHandler(this.StartKompasButton_Click);
            // 
            // closeKompasButton
            // 
            this.closeKompasButton.Location = new System.Drawing.Point(158, 28);
            this.closeKompasButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeKompasButton.Name = "closeKompasButton";
            this.closeKompasButton.Size = new System.Drawing.Size(127, 42);
            this.closeKompasButton.TabIndex = 1;
            this.closeKompasButton.Text = "Close Kompas";
            this.closeKompasButton.UseVisualStyleBackColor = true;
            this.closeKompasButton.Click += new System.EventHandler(this.CloseKompasButton_Click);
            // 
            // buildConeButton
            // 
            this.buildConeButton.Location = new System.Drawing.Point(17, 352);
            this.buildConeButton.Margin = new System.Windows.Forms.Padding(4);
            this.buildConeButton.Name = "buildConeButton";
            this.buildConeButton.Size = new System.Drawing.Size(270, 42);
            this.buildConeButton.TabIndex = 2;
            this.buildConeButton.Text = "Build";
            this.buildConeButton.UseVisualStyleBackColor = true;
            this.buildConeButton.Click += new System.EventHandler(this.BuildConeButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.closeKompasButton);
            this.groupBox1.Controls.Add(this.startKompasButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(6, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(290, 89);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CAD Controls";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.baseWidthTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.coneWidthTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.baseHeightTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lowerHoleTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.baseConeTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(6, 100);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(290, 244);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameters";
            // 
            // baseWidthTextBox
            // 
            this.baseWidthTextBox.Location = new System.Drawing.Point(142, 204);
            this.baseWidthTextBox.Name = "baseWidthTextBox";
            this.baseWidthTextBox.Size = new System.Drawing.Size(139, 27);
            this.baseWidthTextBox.TabIndex = 12;
            this.baseWidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Base width (e):";
            // 
            // coneWidthTextBox
            // 
            this.coneWidthTextBox.Location = new System.Drawing.Point(142, 159);
            this.coneWidthTextBox.Name = "coneWidthTextBox";
            this.coneWidthTextBox.Size = new System.Drawing.Size(139, 27);
            this.coneWidthTextBox.TabIndex = 10;
            this.coneWidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cone width (d):";
            // 
            // baseHeightTextBox
            // 
            this.baseHeightTextBox.Location = new System.Drawing.Point(142, 116);
            this.baseHeightTextBox.Name = "baseHeightTextBox";
            this.baseHeightTextBox.Size = new System.Drawing.Size(139, 27);
            this.baseHeightTextBox.TabIndex = 8;
            this.baseHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Base height (c):";
            // 
            // lowerHoleTextBox
            // 
            this.lowerHoleTextBox.Location = new System.Drawing.Point(142, 73);
            this.lowerHoleTextBox.Name = "lowerHoleTextBox";
            this.lowerHoleTextBox.Size = new System.Drawing.Size(139, 27);
            this.lowerHoleTextBox.TabIndex = 6;
            this.lowerHoleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Lower hole (a):";
            // 
            // baseConeTextBox
            // 
            this.baseConeTextBox.Location = new System.Drawing.Point(142, 29);
            this.baseConeTextBox.Name = "baseConeTextBox";
            this.baseConeTextBox.Size = new System.Drawing.Size(139, 27);
            this.baseConeTextBox.TabIndex = 4;
            this.baseConeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Base cone (b):";
            // 
            // TrafficConeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 402);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buildConeButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "TrafficConeForm";
            this.Text = "Traffic Cone Builder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startKompasButton;
        private System.Windows.Forms.Button closeKompasButton;
        private System.Windows.Forms.Button buildConeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox baseWidthTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox coneWidthTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox baseHeightTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lowerHoleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox baseConeTextBox;
        private System.Windows.Forms.Label label1;
    }
}

