namespace ModelSelector
{
    partial class ModelSelectorForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.structuresExtender.SetAttributeName(this.button1, null);
            this.structuresExtender.SetAttributeTypeName(this.button1, null);
            this.structuresExtender.SetBindPropertyName(this.button1, null);
            this.button1.Location = new System.Drawing.Point(35, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Create Selection Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.createSelectionSet_Click);
            // 
            // button2
            // 
            this.structuresExtender.SetAttributeName(this.button2, null);
            this.structuresExtender.SetAttributeTypeName(this.button2, null);
            this.structuresExtender.SetBindPropertyName(this.button2, null);
            this.button2.Location = new System.Drawing.Point(374, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Select Model Objects";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.selectModelObjects_Click);
            // 
            // listView1
            // 
            this.structuresExtender.SetAttributeName(this.listView1, "modelObject.Guid");
            this.structuresExtender.SetAttributeTypeName(this.listView1, "guid");
            this.structuresExtender.SetBindPropertyName(this.listView1, null);
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(72, 105);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(379, 138);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.structuresExtender.SetAttributeName(this.label1, null);
            this.structuresExtender.SetAttributeTypeName(this.label1, null);
            this.label1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label1, null);
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Selection IDs\r\n";
            // 
            // ModelSelectorForm
            // 
            this.structuresExtender.SetAttributeName(this, "ModelObjectSelector");
            this.structuresExtender.SetAttributeTypeName(this, "string");
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(700, 1000);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ModelSelectorForm";
            this.Text = "ModelSelectorForm";
            this.Load += new System.EventHandler(this.ModelSelectorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
    }
}

