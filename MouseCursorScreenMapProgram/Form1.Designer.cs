
namespace MouseCursorScreenMapProgram
{
  partial class CursorRegionToKey
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
      this.components = new System.ComponentModel.Container();
      this.mouseX = new System.Windows.Forms.Label();
      this.mouseY = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.labelTop = new System.Windows.Forms.Label();
      this.labelBottom = new System.Windows.Forms.Label();
      this.labelLeft = new System.Windows.Forms.Label();
      this.labelRight = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // mouseX
      // 
      this.mouseX.AutoSize = true;
      this.mouseX.Location = new System.Drawing.Point(541, 13);
      this.mouseX.Name = "mouseX";
      this.mouseX.Size = new System.Drawing.Size(32, 13);
      this.mouseX.TabIndex = 0;
      this.mouseX.Text = "mx: 0";
      // 
      // mouseY
      // 
      this.mouseY.AutoSize = true;
      this.mouseY.Location = new System.Drawing.Point(541, 26);
      this.mouseY.Name = "mouseY";
      this.mouseY.Size = new System.Drawing.Size(32, 13);
      this.mouseY.TabIndex = 1;
      this.mouseY.Text = "my: 0";
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 10;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // labelTop
      // 
      this.labelTop.AutoSize = true;
      this.labelTop.Location = new System.Drawing.Point(280, 9);
      this.labelTop.Name = "labelTop";
      this.labelTop.Size = new System.Drawing.Size(22, 13);
      this.labelTop.TabIndex = 2;
      this.labelTop.Text = "top";
      this.labelTop.Click += new System.EventHandler(this.label1_Click);
      // 
      // labelBottom
      // 
      this.labelBottom.AutoSize = true;
      this.labelBottom.Location = new System.Drawing.Point(280, 299);
      this.labelBottom.Name = "labelBottom";
      this.labelBottom.Size = new System.Drawing.Size(39, 13);
      this.labelBottom.TabIndex = 3;
      this.labelBottom.Text = "bottom";
      // 
      // labelLeft
      // 
      this.labelLeft.AutoSize = true;
      this.labelLeft.Location = new System.Drawing.Point(12, 146);
      this.labelLeft.Name = "labelLeft";
      this.labelLeft.Size = new System.Drawing.Size(21, 13);
      this.labelLeft.TabIndex = 4;
      this.labelLeft.Text = "left";
      // 
      // labelRight
      // 
      this.labelRight.AutoSize = true;
      this.labelRight.Location = new System.Drawing.Point(590, 146);
      this.labelRight.Name = "labelRight";
      this.labelRight.Size = new System.Drawing.Size(27, 13);
      this.labelRight.TabIndex = 5;
      this.labelRight.Text = "right";
      // 
      // CursorRegionToKey
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 321);
      this.Controls.Add(this.labelRight);
      this.Controls.Add(this.labelLeft);
      this.Controls.Add(this.labelBottom);
      this.Controls.Add(this.labelTop);
      this.Controls.Add(this.mouseY);
      this.Controls.Add(this.mouseX);
      this.DoubleBuffered = true;
      this.Name = "CursorRegionToKey";
      this.Text = "Form1";
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label mouseX;
    private System.Windows.Forms.Label mouseY;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label labelTop;
    private System.Windows.Forms.Label labelBottom;
    private System.Windows.Forms.Label labelLeft;
    private System.Windows.Forms.Label labelRight;
  }
}

