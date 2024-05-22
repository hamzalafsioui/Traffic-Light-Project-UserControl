namespace Traffic_Light_Project_Idea__Traffic_Light_User_Control_
{
    partial class Form1
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
            this.ctrlTrafficLight2 = new Traffic_Light_Project_Idea__Traffic_Light_User_Control_.ctrlTrafficLight();
            this.ctrlTrafficLight1 = new Traffic_Light_Project_Idea__Traffic_Light_User_Control_.ctrlTrafficLight();
            this.SuspendLayout();
            // 
            // ctrlTrafficLight2
            // 
            this.ctrlTrafficLight2.CurrentLight = Traffic_Light_Project_Idea__Traffic_Light_User_Control_.ctrlTrafficLight.lightEnum.Green;
            this.ctrlTrafficLight2.DelayBeforeOrange = 3;
            this.ctrlTrafficLight2.GreenTime = 5;
            this.ctrlTrafficLight2.Location = new System.Drawing.Point(260, 62);
            this.ctrlTrafficLight2.Name = "ctrlTrafficLight2";
            this.ctrlTrafficLight2.OrangeTime = 3;
            this.ctrlTrafficLight2.RedTime = 10;
            this.ctrlTrafficLight2.Size = new System.Drawing.Size(114, 167);
            this.ctrlTrafficLight2.TabIndex = 1;
            // 
            // ctrlTrafficLight1
            // 
            this.ctrlTrafficLight1.CurrentLight = Traffic_Light_Project_Idea__Traffic_Light_User_Control_.ctrlTrafficLight.lightEnum.Red;
            this.ctrlTrafficLight1.DelayBeforeOrange = 3;
            this.ctrlTrafficLight1.GreenTime = 5;
            this.ctrlTrafficLight1.Location = new System.Drawing.Point(79, 62);
            this.ctrlTrafficLight1.Name = "ctrlTrafficLight1";
            this.ctrlTrafficLight1.OrangeTime = 3;
            this.ctrlTrafficLight1.RedTime = 10;
            this.ctrlTrafficLight1.Size = new System.Drawing.Size(114, 167);
            this.ctrlTrafficLight1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 355);
            this.Controls.Add(this.ctrlTrafficLight2);
            this.Controls.Add(this.ctrlTrafficLight1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlTrafficLight ctrlTrafficLight1;
        private ctrlTrafficLight ctrlTrafficLight2;
    }
}

