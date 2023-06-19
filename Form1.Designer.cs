namespace TcpServerProject
{
    partial class FormServer
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
            btnStart = new Button();
            btnEnd = new Button();
            gpbServer = new GroupBox();
            tbServer = new TextBox();
            gpbServer.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(44, 22);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(141, 32);
            btnStart.TabIndex = 0;
            btnStart.Text = "Запуск";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnEnd
            // 
            btnEnd.Location = new Point(44, 75);
            btnEnd.Name = "btnEnd";
            btnEnd.Size = new Size(141, 29);
            btnEnd.TabIndex = 1;
            btnEnd.Text = "Стоп";
            btnEnd.UseVisualStyleBackColor = true;
            btnEnd.Click += btnEnd_Click;
            // 
            // gpbServer
            // 
            gpbServer.Controls.Add(btnStart);
            gpbServer.Controls.Add(btnEnd);
            gpbServer.Location = new Point(527, 21);
            gpbServer.Name = "gpbServer";
            gpbServer.Size = new Size(232, 119);
            gpbServer.TabIndex = 2;
            gpbServer.TabStop = false;
            gpbServer.Text = "Управление сервером";
            // 
            // tbServer
            // 
            tbServer.Location = new Point(12, 21);
            tbServer.Multiline = true;
            tbServer.Name = "tbServer";
            tbServer.ScrollBars = ScrollBars.Vertical;
            tbServer.Size = new Size(488, 417);
            tbServer.TabIndex = 3;
            // 
            // FormServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbServer);
            Controls.Add(gpbServer);
            Name = "FormServer";
            Text = "FormServer";
            FormClosed += FormServer_FormClosed;
            gpbServer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnEnd;
        private GroupBox gpbServer;
        private TextBox tbServer;
    }
}