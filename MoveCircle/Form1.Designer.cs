namespace MoveCircle
{
    partial class FormBallGame
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
            components = new System.ComponentModel.Container();
            SplitContainer1 = new SplitContainer();
            SelectPictureBox = new PictureBox();
            label5 = new Label();
            textTimer = new TextBox();
            label4 = new Label();
            label3 = new Label();
            RestartButton = new Button();
            label2 = new Label();
            label1 = new Label();
            textHunt = new TextBox();
            MainPictureBox = new PictureBox();
            Timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)SplitContainer1).BeginInit();
            SplitContainer1.Panel1.SuspendLayout();
            SplitContainer1.Panel2.SuspendLayout();
            SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SelectPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainPictureBox).BeginInit();
            SuspendLayout();
            // 
            // SplitContainer1
            // 
            SplitContainer1.Dock = DockStyle.Fill;
            SplitContainer1.Location = new Point(0, 0);
            SplitContainer1.Name = "SplitContainer1";
            SplitContainer1.Orientation = Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            SplitContainer1.Panel1.Controls.Add(SelectPictureBox);
            SplitContainer1.Panel1.Controls.Add(label5);
            SplitContainer1.Panel1.Controls.Add(textTimer);
            SplitContainer1.Panel1.Controls.Add(label4);
            SplitContainer1.Panel1.Controls.Add(label3);
            SplitContainer1.Panel1.Controls.Add(RestartButton);
            SplitContainer1.Panel1.Controls.Add(label2);
            SplitContainer1.Panel1.Controls.Add(label1);
            SplitContainer1.Panel1.Controls.Add(textHunt);
            // 
            // SplitContainer1.Panel2
            // 
            SplitContainer1.Panel2.Controls.Add(MainPictureBox);
            SplitContainer1.Size = new Size(1182, 753);
            SplitContainer1.SplitterDistance = 70;
            SplitContainer1.TabIndex = 0;
            // 
            // SelectPictureBox
            // 
            SelectPictureBox.BackColor = Color.White;
            SelectPictureBox.Location = new Point(464, 8);
            SelectPictureBox.Name = "SelectPictureBox";
            SelectPictureBox.Size = new Size(390, 55);
            SelectPictureBox.TabIndex = 16;
            SelectPictureBox.TabStop = false;
            SelectPictureBox.MouseClick += SelectPictureBox1_MouseClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1149, 27);
            label5.Name = "label5";
            label5.Size = new Size(24, 20);
            label5.TabIndex = 15;
            label5.Text = "秒";
            // 
            // textTimer
            // 
            textTimer.Font = new Font("メイリオ", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 128);
            textTimer.Location = new Point(1038, 13);
            textTimer.Name = "textTimer";
            textTimer.Size = new Size(100, 48);
            textTimer.TabIndex = 14;
            textTimer.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(987, 26);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 13;
            label4.Text = "記録：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(135, 41);
            label3.Name = "label3";
            label3.Size = new Size(324, 20);
            label3.TabIndex = 12;
            label3.Text = "↓下のエリアをクリックするとボールの位置が変わります";
            // 
            // RestartButton
            // 
            RestartButton.Font = new Font("メイリオ", 9F);
            RestartButton.Location = new Point(881, 20);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new Size(100, 35);
            RestartButton.TabIndex = 11;
            RestartButton.Text = "再スタート";
            RestartButton.UseVisualStyleBackColor = true;
            RestartButton.Click += RestartButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(138, 14);
            label2.Name = "label2";
            label2.Size = new Size(321, 20);
            label2.TabIndex = 8;
            label2.Text = "下の背景に表示された漢字と同じ色の円をクリック→";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(84, 28);
            label1.Name = "label1";
            label1.Size = new Size(48, 20);
            label1.TabIndex = 7;
            label1.Text = "を探せ";
            // 
            // textHunt
            // 
            textHunt.Font = new Font("メイリオ", 16F, FontStyle.Regular, GraphicsUnit.Point, 128);
            textHunt.Location = new Point(21, 14);
            textHunt.Name = "textHunt";
            textHunt.Size = new Size(55, 47);
            textHunt.TabIndex = 6;
            textHunt.TextAlign = HorizontalAlignment.Center;
            // 
            // MainPictureBox
            // 
            MainPictureBox.BackColor = Color.White;
            MainPictureBox.Dock = DockStyle.Fill;
            MainPictureBox.Location = new Point(0, 0);
            MainPictureBox.Name = "MainPictureBox";
            MainPictureBox.Size = new Size(1182, 679);
            MainPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            MainPictureBox.TabIndex = 0;
            MainPictureBox.TabStop = false;
            // 
            // Timer1
            // 
            Timer1.Interval = 20;
            Timer1.Tick += Timer1_Tick;
            // 
            // FormBallGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(SplitContainer1);
            Name = "FormBallGame";
            Text = "間違いボール探し";
            Load += FormBallGame_Load;
            SplitContainer1.Panel1.ResumeLayout(false);
            SplitContainer1.Panel1.PerformLayout();
            SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitContainer1).EndInit();
            SplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SelectPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer SplitContainer1;
        private Label label3;
        private Button RestartButton;
        private Label label2;
        private Label label1;
        private TextBox textHunt;
        private PictureBox SelectPictureBox;
        private Label label5;
        private TextBox textTimer;
        private Label label4;
        private PictureBox MainPictureBox;
        private System.Windows.Forms.Timer Timer1;
    }
}
