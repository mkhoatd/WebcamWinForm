
namespace WebCamWinForm2020
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblVideoDevices = new System.Windows.Forms.Label();
            ddlVideoDevices = new System.Windows.Forms.ComboBox();
            lblAzureStorageConnectionString = new System.Windows.Forms.Label();
            txtAzureStorageConnectionString = new System.Windows.Forms.TextBox();
            btnRecord = new System.Windows.Forms.Button();
            statusStrip = new System.Windows.Forms.StatusStrip();
            lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            recordingTimer = new System.Windows.Forms.Timer(components);
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblVideoDevices
            // 
            lblVideoDevices.AutoSize = true;
            lblVideoDevices.Location = new System.Drawing.Point(12, 9);
            lblVideoDevices.Name = "lblVideoDevices";
            lblVideoDevices.Size = new System.Drawing.Size(100, 20);
            lblVideoDevices.TabIndex = 0;
            lblVideoDevices.Text = "Video Source:";
            // 
            // ddlVideoDevices
            // 
            ddlVideoDevices.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ddlVideoDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ddlVideoDevices.FormattingEnabled = true;
            ddlVideoDevices.Location = new System.Drawing.Point(12, 32);
            ddlVideoDevices.Name = "ddlVideoDevices";
            ddlVideoDevices.Size = new System.Drawing.Size(943, 28);
            ddlVideoDevices.TabIndex = 1;
            ddlVideoDevices.SelectedIndexChanged += ddlVideoDevices_SelectedIndexChanged;
            // 
            // lblAzureStorageConnectionString
            // 
            lblAzureStorageConnectionString.AutoSize = true;
            lblAzureStorageConnectionString.Location = new System.Drawing.Point(12, 63);
            lblAzureStorageConnectionString.Name = "lblAzureStorageConnectionString";
            lblAzureStorageConnectionString.Size = new System.Drawing.Size(263, 20);
            lblAzureStorageConnectionString.TabIndex = 6;
            lblAzureStorageConnectionString.Text = "Azure Blob Storage Connection String:";
            // 
            // txtAzureStorageConnectionString
            // 
            txtAzureStorageConnectionString.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtAzureStorageConnectionString.Location = new System.Drawing.Point(12, 86);
            txtAzureStorageConnectionString.Name = "txtAzureStorageConnectionString";
            txtAzureStorageConnectionString.Size = new System.Drawing.Size(943, 27);
            txtAzureStorageConnectionString.TabIndex = 7;
            // 
            // btnRecord
            // 
            btnRecord.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRecord.Location = new System.Drawing.Point(832, 119);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new System.Drawing.Size(123, 41);
            btnRecord.TabIndex = 8;
            btnRecord.Text = "Record";
            btnRecord.UseVisualStyleBackColor = true;
            btnRecord.Click += btnRecord_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblStatus });
            statusStrip.Location = new System.Drawing.Point(0, 652);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(967, 26);
            statusStrip.TabIndex = 9;
            statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(124, 20);
            lblStatus.Text = "Strip Status Label";
            lblStatus.Click += lblStatus_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            pictureBox1.Location = new System.Drawing.Point(12, 244);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(814, 405);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // recordingTimer
            // 
            recordingTimer.Interval = 17;
            recordingTimer.Tick += recordingTimer_Tick;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(12, 133);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(814, 27);
            textBox1.TabIndex = 11;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(12, 183);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(814, 27);
            textBox2.TabIndex = 12;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(967, 678);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(statusStrip);
            Controls.Add(btnRecord);
            Controls.Add(txtAzureStorageConnectionString);
            Controls.Add(lblAzureStorageConnectionString);
            Controls.Add(ddlVideoDevices);
            Controls.Add(lblVideoDevices);
            Name = "Form1";
            Text = "Webcam App (Demo)";
            Load += Form1_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblVideoDevices;
        private System.Windows.Forms.ComboBox ddlVideoDevices;
        private System.Windows.Forms.Label lblAzureStorageConnectionString;
        private System.Windows.Forms.TextBox txtAzureStorageConnectionString;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer recordingTimer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

