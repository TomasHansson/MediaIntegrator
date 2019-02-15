namespace Laboration4
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
            this.startIntegrationButton = new System.Windows.Forms.Button();
            this.integrationInProgressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startIntegrationButton
            // 
            this.startIntegrationButton.Location = new System.Drawing.Point(117, 32);
            this.startIntegrationButton.Name = "startIntegrationButton";
            this.startIntegrationButton.Size = new System.Drawing.Size(146, 23);
            this.startIntegrationButton.TabIndex = 0;
            this.startIntegrationButton.Text = "Starta integrering";
            this.startIntegrationButton.UseVisualStyleBackColor = true;
            this.startIntegrationButton.Click += new System.EventHandler(this.StartIntegrationButton_Click);
            // 
            // integrationInProgressLabel
            // 
            this.integrationInProgressLabel.AutoSize = true;
            this.integrationInProgressLabel.Location = new System.Drawing.Point(142, 70);
            this.integrationInProgressLabel.Name = "integrationInProgressLabel";
            this.integrationInProgressLabel.Size = new System.Drawing.Size(96, 13);
            this.integrationInProgressLabel.TabIndex = 1;
            this.integrationInProgressLabel.Text = "Integrering pågår...";
            this.integrationInProgressLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 111);
            this.Controls.Add(this.integrationInProgressLabel);
            this.Controls.Add(this.startIntegrationButton);
            this.MaximumSize = new System.Drawing.Size(420, 150);
            this.MinimumSize = new System.Drawing.Size(420, 150);
            this.Name = "MainForm";
            this.Text = "Media Integrator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startIntegrationButton;
        private System.Windows.Forms.Label integrationInProgressLabel;
    }
}

