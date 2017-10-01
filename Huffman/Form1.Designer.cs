namespace Huffman
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.операцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построитьКодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.декодироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_file = new System.Windows.Forms.Label();
            this.richTextBox_result = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_averageCodeLength = new System.Windows.Forms.Label();
            this.label_tableLegend = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.операцииToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.открытьToolStripMenuItem.Text = "Открыть...";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // операцииToolStripMenuItem
            // 
            this.операцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.построитьКодToolStripMenuItem,
            this.декодироватьToolStripMenuItem});
            this.операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            this.операцииToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.операцииToolStripMenuItem.Text = "Операции";
            // 
            // построитьКодToolStripMenuItem
            // 
            this.построитьКодToolStripMenuItem.Name = "построитьКодToolStripMenuItem";
            this.построитьКодToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.построитьКодToolStripMenuItem.Text = "Построить код";
            this.построитьКодToolStripMenuItem.Click += new System.EventHandler(this.построитьКодToolStripMenuItem_Click);
            // 
            // декодироватьToolStripMenuItem
            // 
            this.декодироватьToolStripMenuItem.Name = "декодироватьToolStripMenuItem";
            this.декодироватьToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.декодироватьToolStripMenuItem.Text = "Декодировать";
            this.декодироватьToolStripMenuItem.Click += new System.EventHandler(this.декодироватьToolStripMenuItem_Click);
            // 
            // label_file
            // 
            this.label_file.AutoSize = true;
            this.label_file.Location = new System.Drawing.Point(13, 28);
            this.label_file.Name = "label_file";
            this.label_file.Size = new System.Drawing.Size(92, 13);
            this.label_file.TabIndex = 1;
            this.label_file.Text = "Файл не выбран";
            // 
            // richTextBox_result
            // 
            this.richTextBox_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_result.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_result.Location = new System.Drawing.Point(16, 70);
            this.richTextBox_result.Name = "richTextBox_result";
            this.richTextBox_result.Size = new System.Drawing.Size(708, 334);
            this.richTextBox_result.TabIndex = 2;
            this.richTextBox_result.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.Location = new System.Drawing.Point(730, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(278, 334);
            this.dataGridView1.TabIndex = 3;
            // 
            // label_averageCodeLength
            // 
            this.label_averageCodeLength.AutoSize = true;
            this.label_averageCodeLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_averageCodeLength.Location = new System.Drawing.Point(13, 47);
            this.label_averageCodeLength.Name = "label_averageCodeLength";
            this.label_averageCodeLength.Size = new System.Drawing.Size(0, 13);
            this.label_averageCodeLength.TabIndex = 4;
            // 
            // label_tableLegend
            // 
            this.label_tableLegend.AutoSize = true;
            this.label_tableLegend.Location = new System.Drawing.Point(727, 47);
            this.label_tableLegend.Name = "label_tableLegend";
            this.label_tableLegend.Size = new System.Drawing.Size(103, 13);
            this.label_tableLegend.TabIndex = 5;
            this.label_tableLegend.Text = "Таблица символов";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 416);
            this.Controls.Add(this.label_tableLegend);
            this.Controls.Add(this.label_averageCodeLength);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.richTextBox_result);
            this.Controls.Add(this.label_file);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Код Хаффмана";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.Label label_file;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem операцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem построитьКодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem декодироватьToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox_result;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_averageCodeLength;
        private System.Windows.Forms.Label label_tableLegend;
    }
}

