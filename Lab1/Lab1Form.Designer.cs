namespace Lab1
{
    partial class Lab1Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lab1Form));
            this.ImagePanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.FileToolStrip = new System.Windows.Forms.ToolStripSplitButton();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStrip = new System.Windows.Forms.ToolStripSplitButton();
            this.повернутьНа90ГрадусовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поЧасовойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.противЧасовойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImagePanel
            // 
            this.ImagePanel.Location = new System.Drawing.Point(12, 28);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(776, 410);
            this.ImagePanel.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.FileToolStrip, this.EditToolStrip});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // FileToolStrip
            // 
            this.FileToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FileToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.открытьToolStripMenuItem, this.сохранитьToolStripMenuItem, this.сохранитьКакToolStripMenuItem, this.закрытьToolStripMenuItem});
            this.FileToolStrip.Image = ((System.Drawing.Image) (resources.GetObject("FileToolStrip.Image")));
            this.FileToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileToolStrip.Name = "FileToolStrip";
            this.FileToolStrip.Size = new System.Drawing.Size(52, 22);
            this.FileToolStrip.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // EditToolStrip
            // 
            this.EditToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EditToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.повернутьНа90ГрадусовToolStripMenuItem});
            this.EditToolStrip.Image = ((System.Drawing.Image) (resources.GetObject("EditToolStrip.Image")));
            this.EditToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditToolStrip.Name = "EditToolStrip";
            this.EditToolStrip.Size = new System.Drawing.Size(103, 22);
            this.EditToolStrip.Text = "Редактировать";
            // 
            // повернутьНа90ГрадусовToolStripMenuItem
            // 
            this.повернутьНа90ГрадусовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.поЧасовойToolStripMenuItem, this.противЧасовойToolStripMenuItem});
            this.повернутьНа90ГрадусовToolStripMenuItem.Name = "повернутьНа90ГрадусовToolStripMenuItem";
            this.повернутьНа90ГрадусовToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.повернутьНа90ГрадусовToolStripMenuItem.Text = "Повернуть на 90 градусов";
            // 
            // поЧасовойToolStripMenuItem
            // 
            this.поЧасовойToolStripMenuItem.Name = "поЧасовойToolStripMenuItem";
            this.поЧасовойToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.поЧасовойToolStripMenuItem.Text = "По часовой";
            this.поЧасовойToolStripMenuItem.Click += new System.EventHandler(this.поЧасовойToolStripMenuItem_Click);
            // 
            // противЧасовойToolStripMenuItem
            // 
            this.противЧасовойToolStripMenuItem.Name = "противЧасовойToolStripMenuItem";
            this.противЧасовойToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.противЧасовойToolStripMenuItem.Text = "Против часовой";
            this.противЧасовойToolStripMenuItem.Click += new System.EventHandler(this.противЧасовойToolStripMenuItem_Click);
            // 
            // Lab1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ImagePanel);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Lab1Form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.Lab1Form_Load);
            this.Resize += new System.EventHandler(this.Lab1Form_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripSplitButton FileToolStrip;

        private System.Windows.Forms.ToolStripSplitButton EditToolStrip;

        private System.Windows.Forms.ToolStripMenuItem повернутьНа90ГрадусовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поЧасовойToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem противЧасовойToolStripMenuItem;

        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;

        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;

        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;

        private System.Windows.Forms.ToolStrip toolStrip1;

        private System.Windows.Forms.Panel ImagePanel;

        #endregion
    }
}