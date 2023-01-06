namespace ガチャ確率計算ツール
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tryCntTextBox = new System.Windows.Forms.TextBox();
            this.tryCntLabel = new System.Windows.Forms.Label();
            this.calcButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tryCntTextBox
            // 
            this.tryCntTextBox.Location = new System.Drawing.Point(94, 66);
            this.tryCntTextBox.Name = "tryCntTextBox";
            this.tryCntTextBox.Size = new System.Drawing.Size(75, 19);
            this.tryCntTextBox.TabIndex = 0;
            // 
            // tryCntLabel
            // 
            this.tryCntLabel.AutoSize = true;
            this.tryCntLabel.Location = new System.Drawing.Point(92, 51);
            this.tryCntLabel.Name = "tryCntLabel";
            this.tryCntLabel.Size = new System.Drawing.Size(53, 12);
            this.tryCntLabel.TabIndex = 1;
            this.tryCntLabel.Text = "試行回数";
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(94, 110);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(75, 23);
            this.calcButton.TabIndex = 3;
            this.calcButton.Text = "計算";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "※排出率などは設定ファイルで変更してね。";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 217);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.tryCntLabel);
            this.Controls.Add(this.tryCntTextBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ガチャ確率計算ツール";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tryCntTextBox;
        private System.Windows.Forms.Label tryCntLabel;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.Label label1;
    }
}

