namespace InsSandServerRunner
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
            this.button1 = new System.Windows.Forms.Button();
            this.mapCommand = new System.Windows.Forms.TextBox();
            this.serverArgs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.CheckpointScenarios = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckpointHardcoreScenarios = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button1.Location = new System.Drawing.Point(748, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 73);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mapCommand
            // 
            this.mapCommand.Location = new System.Drawing.Point(13, 337);
            this.mapCommand.Name = "mapCommand";
            this.mapCommand.Size = new System.Drawing.Size(854, 22);
            this.mapCommand.TabIndex = 1;
            this.mapCommand.Text = "Canyon?Scenario=Scenario_Crossing_Checkpoint_Security?";
            // 
            // serverArgs
            // 
            this.serverArgs.Location = new System.Drawing.Point(13, 391);
            this.serverArgs.Name = "serverArgs";
            this.serverArgs.Size = new System.Drawing.Size(854, 22);
            this.serverArgs.TabIndex = 2;
            this.serverArgs.Text = "-Port=27102 -QueryPort=27131 -log -noeac -hostname=ChillGame";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Map and scenario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Other server arguments";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(781, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(86, 16);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Server Guide";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(728, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 33);
            this.button2.TabIndex = 6;
            this.button2.Text = "Open server folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CheckpointScenarios
            // 
            this.CheckpointScenarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CheckpointScenarios.FormattingEnabled = true;
            this.CheckpointScenarios.Items.AddRange(new object[] {
            "Canyon",
            "Bab",
            "Farmhouse",
            "Town",
            "Sinjar",
            "Ministry",
            "Compound",
            "Precinct",
            "Oilfield",
            "Mountain",
            "PowerPlant",
            "Tell",
            "Buhriz"});
            this.CheckpointScenarios.Location = new System.Drawing.Point(13, 76);
            this.CheckpointScenarios.Name = "CheckpointScenarios";
            this.CheckpointScenarios.Size = new System.Drawing.Size(121, 24);
            this.CheckpointScenarios.TabIndex = 7;
            this.CheckpointScenarios.SelectedIndexChanged += new System.EventHandler(this.CheckpointScenarios_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Checkpoint";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Checkpoint Hardcore";
            // 
            // CheckpointHardcoreScenarios
            // 
            this.CheckpointHardcoreScenarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CheckpointHardcoreScenarios.FormattingEnabled = true;
            this.CheckpointHardcoreScenarios.Items.AddRange(new object[] {
            "Canyon",
            "Bab",
            "Farmhouse",
            "Town",
            "Sinjar",
            "Ministry",
            "Compound",
            "Precinct",
            "Oilfield",
            "Mountain",
            "PowerPlant",
            "Tell",
            "Buhriz"});
            this.CheckpointHardcoreScenarios.Location = new System.Drawing.Point(140, 76);
            this.CheckpointHardcoreScenarios.Name = "CheckpointHardcoreScenarios";
            this.CheckpointHardcoreScenarios.Size = new System.Drawing.Size(121, 24);
            this.CheckpointHardcoreScenarios.TabIndex = 9;
            this.CheckpointHardcoreScenarios.SelectedIndexChanged += new System.EventHandler(this.CheckpointScenarios_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 504);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CheckpointHardcoreScenarios);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CheckpointScenarios);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverArgs);
            this.Controls.Add(this.mapCommand);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox mapCommand;
        private System.Windows.Forms.TextBox serverArgs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox CheckpointScenarios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CheckpointHardcoreScenarios;
    }
}

