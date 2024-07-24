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
            btnLoadData = new Button();
            btnChooseResultFolder = new Button();
            lblResult = new Label();
            lblDataElement = new Label();
            btnFillTemplate = new Button();
            lblResultData = new Label();
            btnChooseTemplate = new Button();
            lblTemplate = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnLoadData
            // 
            btnLoadData.Location = new Point(36, 42);
            btnLoadData.Name = "btnLoadData";
            btnLoadData.Size = new Size(187, 34);
            btnLoadData.TabIndex = 0;
            btnLoadData.Text = "Загрузить данные";
            btnLoadData.UseVisualStyleBackColor = true;
            btnLoadData.Click += btnLoadData_Click;
            // 
            // btnChooseResultFolder
            // 
            btnChooseResultFolder.Enabled = false;
            btnChooseResultFolder.Location = new Point(36, 79);
            btnChooseResultFolder.Name = "btnChooseResultFolder";
            btnChooseResultFolder.Size = new Size(187, 34);
            btnChooseResultFolder.TabIndex = 2;
            btnChooseResultFolder.Text = "Вабрать папку для результата";
            btnChooseResultFolder.UseVisualStyleBackColor = true;
            btnChooseResultFolder.Click += btnChooseResultFolder_Click;
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
            // btnFillTemplate
            // 
            btnFillTemplate.Enabled = false;
            btnFillTemplate.Location = new Point(36, 153);
            btnFillTemplate.Name = "btnFillTemplate";
            btnFillTemplate.Size = new Size(187, 34);
            btnFillTemplate.TabIndex = 6;
            btnFillTemplate.Text = "Заполнить шаблон (ы)";
            btnFillTemplate.UseVisualStyleBackColor = true;
            btnFillTemplate.Click += btnFillTemplate_Click;
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
            // btnChooseTemplate
            // 
            btnChooseTemplate.Enabled = false;
            btnChooseTemplate.Location = new Point(36, 116);
            btnChooseTemplate.Name = "btnChooseTemplate";
            btnChooseTemplate.Size = new Size(187, 34);
            btnChooseTemplate.TabIndex = 8;
            btnChooseTemplate.Text = "Выбрaть шаблон";
            btnChooseTemplate.UseVisualStyleBackColor = true;
            btnChooseTemplate.Click += btnChooseTemplate_Click;
            // 
            // lblTemplate
            // 
            lblTemplate.AutoSize = true;
            lblTemplate.Location = new Point(229, 126);
            lblTemplate.Name = "lblTemplate";
            lblTemplate.Size = new Size(101, 15);
            lblTemplate.TabIndex = 9;
            lblTemplate.Text = "Выбран шаблон:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(229, 9);
            label1.Name = "label1";
            label1.Size = new Size(140, 15);
            label1.TabIndex = 10;
            label1.Text = "*загружать данные2.xlsx";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 292);
            Controls.Add(label1);
            Controls.Add(lblTemplate);
            Controls.Add(btnChooseTemplate);
            Controls.Add(lblResultData);
            Controls.Add(btnFillTemplate);
            Controls.Add(lblDataElement);
            Controls.Add(lblResult);
            Controls.Add(btnChooseResultFolder);
            Controls.Add(btnLoadData);
            Name = "Form1";
            Text = "Заполнить данные";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadData;
        private Button btnChooseResultFolder;
        private Label lblResult;
        private Label lblDataElement;
        private Button btnFillTemplate;
        private Label lblResultData;
        private Button btnChooseTemplate;
        private Label lblTemplate;
        private Label label1;
    }
}
