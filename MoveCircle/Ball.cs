using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveCircle
{
    internal class Ball
    {
     // クラスに必要な情報の定義

        // 非公開で外部からは変更することができない値
        private const int radius = 40; // 円の半径、初期値の値は変更できません
        private string kanji;          // 表示する漢字
        private string fontName;       // 表示する漢字のフォント名
        private Brush brushColor;      // 塗りつぶす色
        private PictureBox pictureBox; // 描画するPictureBox
        private Bitmap canvas;         // 描画するキャンバス
        private Point position = new Point(0, 0);   // 位置(初期値 X=0,Y=0)
        private Point previous = new Point(0, 0);  // 以前の位置(初期値 X=0,Y=0)
        private Point direction = new Point(1, 1); // 移動方向(初期値 X=1(右),Y=1(下))

        // 公開し外部から触ることができる値
        public int Pitch { get; set; } = radius / 2;    // 移動の割合


        // Ballコンストラクタ
        // 5つの引数を指定しクラスの内部に保持する。
        // 5つの引数は、描画するPictureBox、描画するキャンバス、
        // 塗りつぶす色、表示する漢字、フォント名
        public Ball(PictureBox pb, Bitmap cv, Brush cl, string st, string fn)
        {
            // 内部で使用する変数に引数の値で初期値を設定
            pictureBox = pb;        // 描画するPictureBox
            canvas = cv;        // 描画するキャンバス
            brushColor = cl;        // 塗りつぶす色
            kanji = st;        // 表示する漢字
            fontName = fn;        // 漢字のフォント名の初期設定
        }
        // 指定した位置にボールを描く
        public void PutCircle(int x, int y)
        {
            // 現在の位置を記憶
            position.X = x;
            position.Y = y;
            using var g = Graphics.FromImage(canvas);

            //円を brushColorで指定された色で描く
            g.FillEllipse(brushColor, x, y, radius * 2, radius * 2);
            //文字列を描画する
            g.DrawString(kanji, new Font(fontName, radius / 2 + 4),
                Brushes.Black, x + 14, y + 14, new StringFormat());
            pictureBox.Image = canvas;  //MainPictureBoxに表示する
        }

        // 指定した位置のボールを消す（白で描く）
        public void DeleteCircle()
        {
            // 初めて呼ばれて以前の値が無い時(previous == (0,0))は、今の新しい値を設定
            previous = (previous == new Point(0, 0)) ? position : previous;
            using Graphics g = Graphics.FromImage(canvas);
            //円を白で描く
            g.FillEllipse(Brushes.White, previous.X, previous.Y, radius * 2, radius * 2);
            pictureBox.Image = canvas;//MainPictureBoxに表示する
        }
        // 指定した位置にボールを動かす
        public void Move()
        {
            // ①以前の表示を削除
            DeleteCircle();
            // ②新しい移動先の計算
            var x = position.X + Pitch * direction.X;
            var y = position.Y + Pitch * direction.Y;
            // ③壁で跳ね返る補正
            if (x >= pictureBox?.Width - radius * 2) // 右端に来た場合の判定
            {
                direction.X = -1;    // 進む方向を反転（左方向）
            }
            if (x <= 0) // 左端に来た場合の判定
            {
                direction.X = +1;    // 進む方向を反転（右方向）
            }
            if (y >= pictureBox?.Height - radius * 2) // 下端に来た場合の判定
            {
                direction.Y = -1;    // 進む方向を反転（上方向）
            }
            if (y <= 0) // 上端に来た場合の判定
            {
                direction.Y = +1;   // 進む方向を反転（下方向）
            }
            // ④跳ね返り補正を反映した値で新しい位置を計算
            position.X = x + direction.X;     // x新しいx座標 + 方向(右:+1/左:-1)
            position.Y = y + direction.Y;     // y新しいy座標 + 方向(下:+1/上:-1)
            // ⑤新しい位置に描画
            PutCircle(position.X, position.Y);
            // ⑥新しい位置を以前の値として記憶
            previous = position;
        }
    }
}
