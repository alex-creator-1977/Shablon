namespace Shablon
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
            button1 = new Button();
            button3 = new Button();
            lblResult = new Label();
            lblDataElement = new Label();
            button2 = new Button();
            lblResultData = new Label();
            button4 = new Button();
            lblTemplate = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(36, 42);
            button1.Name = "button1";
            button1.Size = new Size(187, 34);
            button1.TabIndex = 0;
            button1.Text = "Загрузить данные";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(36, 79);
            button3.Name = "button3";
            button3.Size = new Size(187, 34);
            button3.TabIndex = 2;
            button3.Text = "Вабрать папку для результата";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(229, 89);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(107, 15);
            lblResult.TabIndex = 4;
            lblResult.Text = "Путь к результату:";
            // 
            // lblDataElement
            // 
            lblDataElement.AutoSize = true;
            lblDataElement.Location = new Point(229, 52);
            lblDataElement.Name = "lblDataElement";
            lblDataElement.Size = new Size(124, 15);
            lblDataElement.TabIndex = 5;
            lblDataElement.Text = "Загружено объектов:";
            // 
            // button2
            // 
            button2.Location = new Point(36, 153);
            button2.Name = "button2";
            button2.Size = new Size(187, 34);
            button2.TabIndex = 6;
            button2.Text = "Заполнить шаблон (ы)";
            button2.UseVisualStyleBackColor = true;
            // 
            // lblResultData
            // 
            lblResultData.AutoSize = true;
            lblResultData.Location = new Point(229, 163);
            lblResultData.Name = "lblResultData";
            lblResultData.Size = new Size(132, 15);
            lblResultData.TabIndex = 7;
            lblResultData.Text = "Заполнено шаблонов:";
            // 
            // button4
            // 
            button4.Location = new Point(36, 116);
            button4.Name = "button4";
            button4.Size = new Size(187, 34);
            button4.TabIndex = 8;
            button4.Text = "Выбрть шаблон";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // lblTemplate
            // 
            lblTemplate.AutoSize = true;
            lblTemplate.Location = new Point(229, 126);
            lblTemplate.Name = "lblTemplate";
            lblTemplate.Size = new Size(98, 15);
            lblTemplate.TabIndex = 9;
            lblTemplate.Text = "Вабран шаблон:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 210);
            Controls.Add(lblTemplate);
            Controls.Add(button4);
            Controls.Add(lblResultData);
            Controls.Add(button2);
            Controls.Add(lblDataElement);
            Controls.Add(lblResult);
            Controls.Add(button3);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Заполнить данные";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button3;
        private Label lblResult;
        private Label lblDataElement;
        private Button button2;
        private Label lblResultData;
        private Button button4;
        private Label lblTemplate;
    }
}
