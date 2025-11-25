namespace SWE316HW1MA
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
            this.crnsTextBox = new System.Windows.Forms.TextBox();
            this.buttonU = new System.Windows.Forms.Button();
            this.buttonM = new System.Windows.Forms.Button();
            this.buttonT = new System.Windows.Forms.Button();
            this.buttonW = new System.Windows.Forms.Button();
            this.buttonR = new System.Windows.Forms.Button();
            this.summaryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.panelMap = new System.Windows.Forms.Panel();
            this.Results = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // crnsTextBox
            // 
            this.crnsTextBox.Location = new System.Drawing.Point(257, 39);
            this.crnsTextBox.Name = "crnsTextBox";
            this.crnsTextBox.Size = new System.Drawing.Size(392, 20);
            this.crnsTextBox.TabIndex = 0;
            // 
            // buttonU
            // 
            this.buttonU.Location = new System.Drawing.Point(432, 84);
            this.buttonU.Name = "buttonU";
            this.buttonU.Size = new System.Drawing.Size(39, 23);
            this.buttonU.TabIndex = 1;
            this.buttonU.Text = "U";
            this.buttonU.UseVisualStyleBackColor = true;
            this.buttonU.Click += new System.EventHandler(this.buttonU_Click);
            // 
            // buttonM
            // 
            this.buttonM.Location = new System.Drawing.Point(477, 84);
            this.buttonM.Name = "buttonM";
            this.buttonM.Size = new System.Drawing.Size(39, 23);
            this.buttonM.TabIndex = 2;
            this.buttonM.Text = "M";
            this.buttonM.UseVisualStyleBackColor = true;
            this.buttonM.Click += new System.EventHandler(this.buttonM_Click_1);
            // 
            // buttonT
            // 
            this.buttonT.Location = new System.Drawing.Point(522, 84);
            this.buttonT.Name = "buttonT";
            this.buttonT.Size = new System.Drawing.Size(39, 23);
            this.buttonT.TabIndex = 3;
            this.buttonT.Text = "T";
            this.buttonT.UseVisualStyleBackColor = true;
            this.buttonT.Click += new System.EventHandler(this.buttonT_Click_1);
            // 
            // buttonW
            // 
            this.buttonW.Location = new System.Drawing.Point(567, 84);
            this.buttonW.Name = "buttonW";
            this.buttonW.Size = new System.Drawing.Size(39, 23);
            this.buttonW.TabIndex = 4;
            this.buttonW.Text = "W";
            this.buttonW.UseVisualStyleBackColor = true;
            this.buttonW.Click += new System.EventHandler(this.buttonW_Click_1);
            // 
            // buttonR
            // 
            this.buttonR.Location = new System.Drawing.Point(612, 84);
            this.buttonR.Name = "buttonR";
            this.buttonR.Size = new System.Drawing.Size(39, 23);
            this.buttonR.TabIndex = 5;
            this.buttonR.Text = "R";
            this.buttonR.UseVisualStyleBackColor = true;
            this.buttonR.Click += new System.EventHandler(this.buttonR_Click_1);
            // 
            // summaryRichTextBox
            // 
            this.summaryRichTextBox.Location = new System.Drawing.Point(432, 113);
            this.summaryRichTextBox.Name = "summaryRichTextBox";
            this.summaryRichTextBox.Size = new System.Drawing.Size(219, 291);
            this.summaryRichTextBox.TabIndex = 6;
            this.summaryRichTextBox.Text = "";
            // 
            // panelMap
            // 
            this.panelMap.Location = new System.Drawing.Point(113, 65);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(303, 340);
            this.panelMap.TabIndex = 7;
            // 
            // Results
            // 
            this.Results.AutoSize = true;
            this.Results.Location = new System.Drawing.Point(519, 68);
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(42, 13);
            this.Results.TabIndex = 8;
            this.Results.Text = "Results";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Enter Student CRN Nunbers";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 439);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Results);
            this.Controls.Add(this.panelMap);
            this.Controls.Add(this.summaryRichTextBox);
            this.Controls.Add(this.buttonR);
            this.Controls.Add(this.buttonW);
            this.Controls.Add(this.buttonT);
            this.Controls.Add(this.buttonM);
            this.Controls.Add(this.buttonU);
            this.Controls.Add(this.crnsTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox crnsTextBox;
        private System.Windows.Forms.Button buttonU;
        private System.Windows.Forms.Button buttonM;
        private System.Windows.Forms.Button buttonT;
        private System.Windows.Forms.Button buttonW;
        private System.Windows.Forms.Button buttonR;
        private System.Windows.Forms.RichTextBox summaryRichTextBox;
        private System.Windows.Forms.Panel panelMap;
        private System.Windows.Forms.Label Results;
        private System.Windows.Forms.Label label1;
    }
}

