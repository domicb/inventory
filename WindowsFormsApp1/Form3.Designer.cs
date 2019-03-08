namespace WindowsFormsApp1
{
    partial class Form3
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textKg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.textBoxPadre = new System.Windows.Forms.TextBox();
            this.buttonModify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Producto Padre",
            "Producto Hijo"});
            this.comboBox1.Location = new System.Drawing.Point(106, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de producto";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(106, 66);
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(252, 20);
            this.textDescription.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción";
            // 
            // textSize
            // 
            this.textSize.Location = new System.Drawing.Point(106, 105);
            this.textSize.Name = "textSize";
            this.textSize.Size = new System.Drawing.Size(252, 20);
            this.textSize.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tamaño";
            // 
            // textKg
            // 
            this.textKg.Location = new System.Drawing.Point(106, 143);
            this.textKg.Name = "textKg";
            this.textKg.Size = new System.Drawing.Size(100, 20);
            this.textKg.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Peso en Kg";
            // 
            // textPrice
            // 
            this.textPrice.Location = new System.Drawing.Point(106, 185);
            this.textPrice.Name = "textPrice";
            this.textPrice.Size = new System.Drawing.Size(100, 20);
            this.textPrice.TabIndex = 8;
            this.textPrice.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Precio";
            // 
            // textQuantity
            // 
            this.textQuantity.Location = new System.Drawing.Point(106, 225);
            this.textQuantity.Name = "textQuantity";
            this.textQuantity.Size = new System.Drawing.Size(100, 20);
            this.textQuantity.TabIndex = 10;
            this.textQuantity.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cantidad";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(410, 146);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(118, 55);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(407, 30);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 13;
            // 
            // textBoxPadre
            // 
            this.textBoxPadre.Location = new System.Drawing.Point(250, 28);
            this.textBoxPadre.Name = "textBoxPadre";
            this.textBoxPadre.Size = new System.Drawing.Size(157, 20);
            this.textBoxPadre.TabIndex = 14;
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(430, 222);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(75, 23);
            this.buttonModify.TabIndex = 15;
            this.buttonModify.Text = "Modificar";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 257);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.textBoxPadre);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textKg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textKg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.TextBox textBoxPadre;
        private System.Windows.Forms.Button buttonModify;
    }
}