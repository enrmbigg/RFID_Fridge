namespace RFID_Fridge
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RemoveChk = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.foodTxt = new System.Windows.Forms.TextBox();
            this.tagTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.attachedTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.output1chk = new System.Windows.Forms.CheckBox();
            this.ledChk = new System.Windows.Forms.CheckBox();
            this.antennaChk = new System.Windows.Forms.CheckBox();
            this.output0Chk = new System.Windows.Forms.CheckBox();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.tbxContents = new System.Windows.Forms.TextBox();
            this.keyboardCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RemoveChk);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.keyboardCheckBox);
            this.groupBox1.Controls.Add(this.attachedTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.output1chk);
            this.groupBox1.Controls.Add(this.ledChk);
            this.groupBox1.Controls.Add(this.antennaChk);
            this.groupBox1.Controls.Add(this.output0Chk);
            this.groupBox1.Location = new System.Drawing.Point(277, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 371);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RFID Fridge";
            // 
            // RemoveChk
            // 
            this.RemoveChk.AutoSize = true;
            this.RemoveChk.Location = new System.Drawing.Point(6, 105);
            this.RemoveChk.Name = "RemoveChk";
            this.RemoveChk.Size = new System.Drawing.Size(89, 17);
            this.RemoveChk.TabIndex = 3;
            this.RemoveChk.Text = "Remove Item";
            this.RemoveChk.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.foodTxt);
            this.groupBox2.Controls.Add(this.tagTxt);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(9, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 237);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Item";
            // 
            // foodTxt
            // 
            this.foodTxt.Location = new System.Drawing.Point(88, 45);
            this.foodTxt.Name = "foodTxt";
            this.foodTxt.ReadOnly = true;
            this.foodTxt.Size = new System.Drawing.Size(95, 20);
            this.foodTxt.TabIndex = 1;
            // 
            // tagTxt
            // 
            this.tagTxt.Location = new System.Drawing.Point(88, 19);
            this.tagTxt.Name = "tagTxt";
            this.tagTxt.ReadOnly = true;
            this.tagTxt.Size = new System.Drawing.Size(95, 20);
            this.tagTxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Item:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "RFID ID:";
            // 
            // attachedTxt
            // 
            this.attachedTxt.Location = new System.Drawing.Point(65, 27);
            this.attachedTxt.Name = "attachedTxt";
            this.attachedTxt.ReadOnly = true;
            this.attachedTxt.Size = new System.Drawing.Size(181, 20);
            this.attachedTxt.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Attached:";
            // 
            // output1chk
            // 
            this.output1chk.AutoSize = true;
            this.output1chk.Location = new System.Drawing.Point(179, 82);
            this.output1chk.Name = "output1chk";
            this.output1chk.Size = new System.Drawing.Size(67, 17);
            this.output1chk.TabIndex = 13;
            this.output1chk.Text = "Output 1";
            this.output1chk.UseVisualStyleBackColor = true;
            this.output1chk.CheckedChanged += new System.EventHandler(this.output1chk_CheckedChanged);
            // 
            // ledChk
            // 
            this.ledChk.AutoSize = true;
            this.ledChk.Location = new System.Drawing.Point(6, 82);
            this.ledChk.Name = "ledChk";
            this.ledChk.Size = new System.Drawing.Size(86, 17);
            this.ledChk.TabIndex = 12;
            this.ledChk.Text = "Led Enabled";
            this.ledChk.UseVisualStyleBackColor = true;
            this.ledChk.CheckedChanged += new System.EventHandler(this.ledChk_CheckedChanged);
            // 
            // antennaChk
            // 
            this.antennaChk.AutoSize = true;
            this.antennaChk.Location = new System.Drawing.Point(6, 59);
            this.antennaChk.Name = "antennaChk";
            this.antennaChk.Size = new System.Drawing.Size(72, 17);
            this.antennaChk.TabIndex = 3;
            this.antennaChk.Text = "Fridge On";
            this.antennaChk.UseVisualStyleBackColor = true;
            this.antennaChk.CheckedChanged += new System.EventHandler(this.antennaChk_CheckedChanged);
            // 
            // output0Chk
            // 
            this.output0Chk.AutoSize = true;
            this.output0Chk.Location = new System.Drawing.Point(98, 82);
            this.output0Chk.Name = "output0Chk";
            this.output0Chk.Size = new System.Drawing.Size(67, 17);
            this.output0Chk.TabIndex = 11;
            this.output0Chk.Text = "Output 0";
            this.output0Chk.UseVisualStyleBackColor = true;
            this.output0Chk.CheckedChanged += new System.EventHandler(this.output0Chk_CheckedChanged);
            // 
            // ResetBtn
            // 
            this.ResetBtn.Location = new System.Drawing.Point(277, 389);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(246, 23);
            this.ResetBtn.TabIndex = 19;
            this.ResetBtn.Text = "Remove All Items";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // tbxContents
            // 
            this.tbxContents.Location = new System.Drawing.Point(12, 12);
            this.tbxContents.Multiline = true;
            this.tbxContents.Name = "tbxContents";
            this.tbxContents.Size = new System.Drawing.Size(259, 400);
            this.tbxContents.TabIndex = 20;
            // 
            // keyboardCheckBox
            // 
            this.keyboardCheckBox.AutoSize = true;
            this.keyboardCheckBox.Location = new System.Drawing.Point(98, 105);
            this.keyboardCheckBox.Name = "keyboardCheckBox";
            this.keyboardCheckBox.Size = new System.Drawing.Size(148, 17);
            this.keyboardCheckBox.TabIndex = 14;
            this.keyboardCheckBox.Text = "Keyboard Output Enabled";
            this.keyboardCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 424);
            this.Controls.Add(this.tbxContents);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RFID-Fridge";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox output1chk;
        private System.Windows.Forms.CheckBox ledChk;
        private System.Windows.Forms.CheckBox output0Chk;
        private System.Windows.Forms.TextBox attachedTxt;
        private System.Windows.Forms.CheckBox antennaChk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tagTxt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox foodTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox RemoveChk;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.TextBox tbxContents;
        private System.Windows.Forms.CheckBox keyboardCheckBox;
    }
}

