namespace MoveCircle
{
    public partial class FormBallGame : Form
    {
        // クラス共通の変数
        private Bitmap? canvas;              // 画面下の描画領域  
        private string correctText = "荻";   // 正解の文字：1つだけ 
        private string mistakeText = "萩";   // 間違いの文字：ボールの個数分並ぶ
        //private Ball balls;                // ボールを管理　[List 5]までの処理
        private Ball[] balls;                // 配列として複数のボールを管理
        private string[] kanjis;             // ボールに描く漢字の配列
        private Brush[] ballColor = new[]    // ボールの色、５個分配列で定義
                                    {
                                        Brushes.LightPink,      // 薄いピンク
                                        Brushes.LightBlue,      // 薄い青
                                        Brushes.LightGray,      // 薄い灰色
                                        Brushes.LightCoral,     // 薄い珊瑚色
                                        Brushes.LightGreen,      // 薄い緑
                                        Brushes.Orange,    // オレンジ
                                        Brushes.Yellow,    // 赤
                                     };

        // 色の詳細はこちら： https://docs.microsoft.com/ja-jp/dotnet/api/system.drawing.brushes?view=dotnet-plat-ext-6.0
        private string fontName;            // 表示する漢字のフォント名
        private double nowTime = 0.0;        // 経過時間
        private int ballCount = 7;           // ボールの数
        private int randomResult = 0;        // 正解の番号:0～ボールの数のいずれか

                  
        public FormBallGame()
        {
            InitializeComponent();
        }



 　　// 上のPictureBoxコントロールに円を描いてみる
        private void DrawCircleSelectPictureBox()
        {
            var height = SelectPictureBox.Height;           // 高さをselectPictureBoxから取得
            var width = SelectPictureBox.Width;             // 幅をselectPictureBoxから取得
            var selectCanvas = new Bitmap(width, height);   // 幅×高さでキャンバス作成
            using var g = Graphics.FromImage(selectCanvas); // キャンバスに絵を書く準備
                                                            //g.FillEllipse(Brushes.LightBlue,                // [List 1] 円を書きます。薄い青で
                                                            //  0, 0, height, height);                      // (0,0)の位置に高さ：height,幅：height
            for (int i = 0; i < ballCount; i++)
            {
                g.FillEllipse(ballColor[i], i * height, 0, height, height);
            }

            SelectPictureBox.Image = selectCanvas;          // キャンバスに書いた絵をImageに設定
        }   // using 指定がされた変数　g はこの時点で破棄する処理が内部的に呼ばれます。


   　// 下のPictureBoxに描画する              
        private void DrawMainPictureBox(Brush color, string text)
        {
            //描画先とするImageオブジェクトをmainPictureBoxの幅×高さの大きさで作成する
            canvas ??= new Bitmap(MainPictureBox.Width, MainPictureBox.Height);
            using var g = Graphics.FromImage(canvas);  // キャンバスに絵を書く準備
            //背景に引数で指定した文字列を描画する
            g.DrawString(text,                             // 描画する文字列
                        new Font(textHunt.Font.FontFamily, // フォント名(textHuntと同じ)
                                MainPictureBox.Height / 2),  // フォントサイズ(高さの半分)
                        color,                           // 描画する色(灰色)
                        MainPictureBox.Width / 6,            // x座標(横位置)(0~横幅の1/6で調整)
                        -MainPictureBox.Height / 12           // Y座標(縦位置)(0~縦幅の1/12で調整)
                        );
            MainPictureBox.Image = canvas;                 // キャンバスに書いた絵をImageに設定
        }   // using 指定がされた変数　g はこの時点で破棄する処理が内部的に呼ばれます。




        // フォームが起動した時（Load時）、呼ばれるイベントハンドラー
        private void FormBallGame_Load(object sender, EventArgs e)
        {
            DrawCircleSelectPictureBox();     // 上のPictureBoxに円を描く[List 2]
            DrawMainPictureBox(Brushes.Gray, correctText); // 下のPictureBoxに円を描く[List 3]
            textHunt.Text = correctText;      // 正解の文字を設定
            fontName = textHunt.Font.Name;    // textHuntに設定したフォントと同じフォントにする
                                              // ボールクラスのインスタンス作成
                                              // [List 5] ボールが１つの時
                                              // balls = new Ball(MainPictureBox, canvas, Brushes.LightBlue, correctText, fontName);
                                              //balls.PutCircle(100, 100);    // [List 5] ボールが１つの時
            balls = new Ball[ballCount];    // ballsをballCount分配列として用意
            // 漢字の設定
            kanjis = new string[ballCount];
            for (int i = 0; i < ballCount; i++)
            {
                kanjis[i] = mistakeText; // 間違いの文字をセット
            }
            randomResult = new Random().Next(ballCount); // ボールの数分の乱数を取得
            kanjis[randomResult] = correctText;          // ランダムな位置に正解の文字をセット
            // ballCount分のBallインスタンスを生成、背景色をballColor, 表示する漢字もkanjisに用意
            for (int i = 0; i < ballCount; i++)
            {
                balls[i] = new Ball(MainPictureBox, canvas, ballColor[i], kanjis[i], fontName);
            }
            //balls.PutCircle(100, 100);    // [List 5] ボールが１つの時
            // ランダムな位置ににballCount個のボールを置く
            for (int i = 0; i < ballCount; i++)
            {
                balls[i].PutCircle(new Random().Next(MainPictureBox.Width),
                                    new Random().Next(MainPictureBox.Height));
            }

            // タイマーをスタートさせる
            nowTime = 0.0;
            Timer1.Start();
        }



        // 上のピクチャーボックスが押された時、呼ばれるイベントハンドラ
        private void SelectPictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            // 押されたX座標で正解判定
            //<判定> 押されたボタンがマウスの左ボタン？
            if (e.Button == MouseButtons.Left)
            {
                // どの円を選択したかを計算で算出（クリックしたX座標の位置/PictureBoxの横幅)
                int selectCircle = e.X / SelectPictureBox.Height;
                if (randomResult == selectCircle) // 正解の円を選んだ
                {
                    Timer1.Stop();
                    DrawMainPictureBox(Brushes.Gold, "◎"); // 正解
                }

                else // 失敗
                {
                    // 移動の割合を減少させる
                    for (int i = 0; i < ballCount; i++)
                    {
                        balls[i].Pitch -= balls[i].Pitch / 2; // 移動の割合を半分にする
                    }
                    nowTime = nowTime + 10; // ペナルティー
                    DrawMainPictureBox(Brushes.Red, correctText);   // 赤で正解の文字を背景に強調
                }
            }
        }


        // 再スタートボタンが押された時、呼ばれるイベントハンドラ
        private void RestartButton_Click(object sender, EventArgs e)
        {
            // 処理内容が FormBallGame_Load と同じであるためそのまま呼ぶ
            canvas = null;      // 画面下の描画領域を初期化
            FormBallGame_Load(sender, e);
        }



        // タイマーが動いている時、呼ばれるイベントハンドラ
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //balls.Move();     // [List 5] ボールが１つの時
            // ballCount分ループしてMove()を実行
            for (int i = 0; i < ballCount; i++)
            {
                balls[i].Move();
            }

            nowTime += 0.02;
            textTimer.Text = nowTime.ToString("0.00");
        }
    }
}
