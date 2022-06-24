
namespace Pokemon_Simulator.Windows
{
    partial class ItemWindow
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
            this.LstBxItems = new System.Windows.Forms.ListBox();
            this.LblCurrItem = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.LblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LstBxItems
            // 
            this.LstBxItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstBxItems.FormattingEnabled = true;
            this.LstBxItems.ItemHeight = 29;
            this.LstBxItems.Location = new System.Drawing.Point(12, 60);
            this.LstBxItems.Name = "LstBxItems";
            this.LstBxItems.ScrollAlwaysVisible = true;
            this.LstBxItems.Size = new System.Drawing.Size(375, 265);
            this.LstBxItems.TabIndex = 0;
            this.LstBxItems.SelectedIndexChanged += new System.EventHandler(this.LstBxItems_SelectedIndexChanged);
            // 
            // LblCurrItem
            // 
            this.LblCurrItem.AutoSize = true;
            this.LblCurrItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCurrItem.Location = new System.Drawing.Point(12, 18);
            this.LblCurrItem.Name = "LblCurrItem";
            this.LblCurrItem.Size = new System.Drawing.Size(166, 29);
            this.LblCurrItem.TabIndex = 1;
            this.LblCurrItem.Text = "Current Item: ";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnAdd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnAdd.Location = new System.Drawing.Point(39, 456);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(123, 57);
            this.BtnAdd.TabIndex = 17;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnClear.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnClear.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnClear.Location = new System.Drawing.Point(228, 456);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(123, 57);
            this.BtnClear.TabIndex = 18;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LblDescription.Location = new System.Drawing.Point(12, 337);
            this.LblDescription.MaximumSize = new System.Drawing.Size(400, 200);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(127, 26);
            this.LblDescription.TabIndex = 19;
            this.LblDescription.Text = "Description:";
            // 
            // ItemWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(399, 535);
            this.Controls.Add(this.LblDescription);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.LblCurrItem);
            this.Controls.Add(this.LstBxItems);
            this.MinimumSize = new System.Drawing.Size(417, 582);
            this.Name = "ItemWindow";
            this.Text = "ItemWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LstBxItems;
        private System.Windows.Forms.Label LblCurrItem;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Label LblDescription;
    }
}