namespace AllLabs
{
    partial class AllLabs
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
            this.Lab1Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lab1Button
            // 
            this.Lab1Button.Location = new System.Drawing.Point(12, 12);
            this.Lab1Button.Name = "Lab1Button";
            this.Lab1Button.Size = new System.Drawing.Size(151, 23);
            this.Lab1Button.TabIndex = 0;
            this.Lab1Button.Text = "Лабораторная Работа 1";
            this.Lab1Button.UseVisualStyleBackColor = true;
            this.Lab1Button.Click += new System.EventHandler(this.Lab1Button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AllLabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 122);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Lab1Button);
            this.Name = "AllLabs";
            this.Text = "Геометрическое Моделирование в САПР";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Button Lab1Button;

        #endregion
    }
}