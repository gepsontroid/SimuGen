namespace SampleDataExporter
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnTab = new System.Windows.Forms.Button();
            this.btJSON = new System.Windows.Forms.Button();
            this.btnSQL = new System.Windows.Forms.Button();
            this.btnXML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(244, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "COMMA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTab
            // 
            this.btnTab.Location = new System.Drawing.Point(368, 123);
            this.btnTab.Name = "btnTab";
            this.btnTab.Size = new System.Drawing.Size(94, 29);
            this.btnTab.TabIndex = 1;
            this.btnTab.Text = "TAB";
            this.btnTab.UseVisualStyleBackColor = true;
            this.btnTab.Click += new System.EventHandler(this.btnTab_Click);
            // 
            // btJSON
            // 
            this.btJSON.Location = new System.Drawing.Point(496, 123);
            this.btJSON.Name = "btJSON";
            this.btJSON.Size = new System.Drawing.Size(94, 29);
            this.btJSON.TabIndex = 2;
            this.btJSON.Text = "JSON";
            this.btJSON.UseVisualStyleBackColor = true;
            this.btJSON.Click += new System.EventHandler(this.btJSON_Click);
            // 
            // btnSQL
            // 
            this.btnSQL.Location = new System.Drawing.Point(619, 123);
            this.btnSQL.Name = "btnSQL";
            this.btnSQL.Size = new System.Drawing.Size(94, 29);
            this.btnSQL.TabIndex = 3;
            this.btnSQL.Text = "SQL";
            this.btnSQL.UseVisualStyleBackColor = true;
            this.btnSQL.Click += new System.EventHandler(this.btnSQL_Click);
            // 
            // btnXML
            // 
            this.btnXML.Location = new System.Drawing.Point(244, 186);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(94, 29);
            this.btnXML.TabIndex = 4;
            this.btnXML.Text = "XML";
            this.btnXML.UseVisualStyleBackColor = true;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnXML);
            this.Controls.Add(this.btnSQL);
            this.Controls.Add(this.btJSON);
            this.Controls.Add(this.btnTab);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button btnTab;
        private Button btJSON;
        private Button btnSQL;
        private Button btnXML;
    }
}