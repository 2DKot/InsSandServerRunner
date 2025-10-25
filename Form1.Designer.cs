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
            this.mapCommand.Text = "Canyon?Scenario=Scenario_Crossing_Checkpoint_Security?\r\n";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 504);
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
    }
}

