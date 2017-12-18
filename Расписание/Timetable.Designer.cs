namespace Расписание
{
    partial class Timetable
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.week = new System.Windows.Forms.RadioButton();
            this.month = new System.Windows.Forms.RadioButton();
            this.dataGridTimeTable = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTimeTable = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTimeWork = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTimeTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1064, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // week
            // 
            this.week.AutoSize = true;
            this.week.Location = new System.Drawing.Point(759, 40);
            this.week.Name = "week";
            this.week.Size = new System.Drawing.Size(63, 17);
            this.week.TabIndex = 1;
            this.week.TabStop = true;
            this.week.Text = "Неделя";
            this.week.UseVisualStyleBackColor = true;
            // 
            // month
            // 
            this.month.AutoSize = true;
            this.month.Location = new System.Drawing.Point(759, 63);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(58, 17);
            this.month.TabIndex = 2;
            this.month.TabStop = true;
            this.month.Text = "Месяц";
            this.month.UseVisualStyleBackColor = true;
            this.month.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // dataGridTimeTable
            // 
            this.dataGridTimeTable.AllowUserToDeleteRows = false;
            this.dataGridTimeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTimeTable.Location = new System.Drawing.Point(12, 40);
            this.dataGridTimeTable.Name = "dataGridTimeTable";
            this.dataGridTimeTable.Size = new System.Drawing.Size(735, 440);
            this.dataGridTimeTable.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(757, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Составить графиг начиная с";
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Location = new System.Drawing.Point(918, 92);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(132, 20);
            this.dateTimeStart.TabIndex = 11;
            this.dateTimeStart.Value = new System.DateTime(2017, 12, 18, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(756, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "График";
            // 
            // comboBoxTimeTable
            // 
            this.comboBoxTimeTable.FormattingEnabled = true;
            this.comboBoxTimeTable.Location = new System.Drawing.Point(918, 121);
            this.comboBoxTimeTable.Name = "comboBoxTimeTable";
            this.comboBoxTimeTable.Size = new System.Drawing.Size(132, 21);
            this.comboBoxTimeTable.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(759, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Составить расписание";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(756, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Режим работы заведения";
            // 
            // comboBoxTimeWork
            // 
            this.comboBoxTimeWork.FormattingEnabled = true;
            this.comboBoxTimeWork.Location = new System.Drawing.Point(918, 154);
            this.comboBoxTimeWork.Name = "comboBoxTimeWork";
            this.comboBoxTimeWork.Size = new System.Drawing.Size(132, 21);
            this.comboBoxTimeWork.TabIndex = 16;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(760, 220);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Сохранить расписание ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(817, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Timetable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 493);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBoxTimeWork);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBoxTimeTable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimeStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridTimeTable);
            this.Controls.Add(this.month);
            this.Controls.Add(this.week);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Timetable";
            this.Text = "График работы";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTimeTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.RadioButton week;
        private System.Windows.Forms.RadioButton month;
        private System.Windows.Forms.DataGridView dataGridTimeTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTimeTable;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxTimeWork;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
    }
}

