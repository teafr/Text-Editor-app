namespace Edit_text__work_with_string_
{
    partial class Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            bFix = new Button();
            textBox = new TextBox();
            bRestart = new Button();
            SuspendLayout();
            // 
            // bFix
            // 
            bFix.BackColor = Color.White;
            bFix.FlatAppearance.BorderColor = Color.DarkCyan;
            bFix.FlatAppearance.BorderSize = 4;
            bFix.FlatAppearance.MouseDownBackColor = Color.PaleTurquoise;
            bFix.FlatAppearance.MouseOverBackColor = Color.LightCyan;
            bFix.FlatStyle = FlatStyle.Flat;
            bFix.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            bFix.ForeColor = Color.Teal;
            bFix.Location = new Point(12, 360);
            bFix.Name = "bFix";
            bFix.Size = new Size(364, 68);
            bFix.TabIndex = 0;
            bFix.Text = "Fix text";
            bFix.UseVisualStyleBackColor = false;
            bFix.Click += bFix_Click;
            // 
            // textBox
            // 
            textBox.BackColor = Color.White;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Segoe UI", 12F);
            textBox.ForeColor = Color.DarkSlateGray;
            textBox.Location = new Point(12, 12);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.Size = new Size(776, 330);
            textBox.TabIndex = 1;
            // 
            // bRestart
            // 
            bRestart.BackColor = Color.White;
            bRestart.FlatAppearance.BorderColor = Color.DarkCyan;
            bRestart.FlatAppearance.BorderSize = 4;
            bRestart.FlatAppearance.MouseDownBackColor = Color.PaleTurquoise;
            bRestart.FlatAppearance.MouseOverBackColor = Color.LightCyan;
            bRestart.FlatStyle = FlatStyle.Flat;
            bRestart.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            bRestart.ForeColor = Color.Teal;
            bRestart.Location = new Point(424, 360);
            bRestart.Name = "bRestart";
            bRestart.Size = new Size(364, 68);
            bRestart.TabIndex = 2;
            bRestart.Text = "Restart";
            bRestart.UseVisualStyleBackColor = false;
            bRestart.Click += bRestart_Click;
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSeaGreen;
            ClientSize = new Size(800, 450);
            Controls.Add(bRestart);
            Controls.Add(textBox);
            Controls.Add(bFix);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Editor";
            ShowIcon = false;
            Text = "TEXT EDITOR";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bFix;
        private TextBox textBox;
        private Button bRestart;
    }
}
