namespace TestClient
{
    partial class TestClient
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
            this.btnSendCommands = new System.Windows.Forms.Button();
            this.tbCommands = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSendCommands
            // 
            this.btnSendCommands.Location = new System.Drawing.Point(80, 234);
            this.btnSendCommands.Name = "btnSendCommands";
            this.btnSendCommands.Size = new System.Drawing.Size(110, 23);
            this.btnSendCommands.TabIndex = 0;
            this.btnSendCommands.Text = "&Send Commands";
            this.btnSendCommands.UseVisualStyleBackColor = true;
            this.btnSendCommands.Click += new System.EventHandler(this.btnSendCommands_Click);
            // 
            // tbCommands
            // 
            this.tbCommands.Location = new System.Drawing.Point(12, 57);
            this.tbCommands.Multiline = true;
            this.tbCommands.Name = "tbCommands";
            this.tbCommands.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbCommands.Size = new System.Drawing.Size(178, 171);
            this.tbCommands.TabIndex = 1;
            this.tbCommands.Text = "5 3 \r\n1 1 E \r\nRFRFRFRF \r\n3 2 N \r\nFRRFLLFFRRFLL \r\n0 3 W \r\nLLFFFLFLFL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Earth Command Center";
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(285, 57);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(178, 171);
            this.tbResult.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Result";
            // 
            // TestClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 292);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.tbCommands);
            this.Controls.Add(this.btnSendCommands);
            this.Name = "TestClient";
            this.Text = "Martian Robots Test Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendCommands;
        private System.Windows.Forms.TextBox tbCommands;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label label2;
    }
}

