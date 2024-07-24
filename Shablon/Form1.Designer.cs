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
            btnLoadSettings = new Button();
            btnSaveSettings = new Button();
            SuspendLayout();
            // 
            // btnLoadData
            // 
            btnLoadData.Location = new Point(28, 101);
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
            btnChooseResultFolder.Location = new Point(28, 137);
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
            lblResult.Location = new Point(221, 147);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(107, 15);
            lblResult.TabIndex = 4;
            lblResult.Text = "Путь к результату:";
            // 
            // lblDataElement
            // 
            lblDataElement.AutoSize = true;
            lblDataElement.Location = new Point(221, 111);
            lblDataElement.Name = "lblDataElement";
            lblDataElement.Size = new Size(92, 15);
            lblDataElement.TabIndex = 5;
            lblDataElement.Text = "Путь к данным:";
            // 
            // btnFillTemplate
            // 
            btnFillTemplate.Enabled = false;
            btnFillTemplate.Location = new Point(28, 209);
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
            lblResultData.Location = new Point(221, 219);
            lblResultData.Name = "lblResultData";
            lblResultData.Size = new Size(132, 15);
            lblResultData.TabIndex = 7;
            lblResultData.Text = "Заполнено шаблонов:";
            // 
            // btnChooseTemplate
            // 
            btnChooseTemplate.Enabled = false;
            btnChooseTemplate.Location = new Point(28, 173);
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
            lblTemplate.Location = new Point(221, 183);
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
            // btnLoadSettings
            // 
            btnLoadSettings.Location = new Point(28, 29);
            btnLoadSettings.Name = "btnLoadSettings";
            btnLoadSettings.Size = new Size(187, 34);
            btnLoadSettings.TabIndex = 11;
            btnLoadSettings.Text = "Загрузить настройки";
            btnLoadSettings.UseVisualStyleBackColor = true;
            btnLoadSettings.Click += btnLoadSettings_Click;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(28, 65);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(187, 34);
            btnSaveSettings.TabIndex = 12;
            btnSaveSettings.Text = "Сохранить настройки";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 292);
            Controls.Add(btnSaveSettings);
            Controls.Add(btnLoadSettings);
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
        private Button btnLoadSettings;
        private Button btnSaveSettings;
    }
}
