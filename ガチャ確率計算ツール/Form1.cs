using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ガチャ確率計算ツール
{
    public partial class Form1 : Form
    {
        // 排出率
        private double emissionRate = 0.00;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 計算ボタンClickイベント
        /// </summary>
        private void calcButton_Click(object sender, EventArgs e)
        {
            // 設定ファイルから設定値を取得
            try
            {
                GetSettingsValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"設定ファイルの読み取り中にエラーが発生しました。\n{ex}",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }


            // 排出率をチェック
            if (emissionRate == 0.00)
            {
                MessageBox.Show("設定ファイルに排出率が規定されていないか0%に設定されているため、\n計算を中止します。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }


            // 試行回数をチェックして取得
            if (tryCntTextBox.Text == null || tryCntTextBox.Text == "")
            {
                MessageBox.Show("試行回数を入力してください。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            int tryTimes;
            if (int.TryParse(tryCntTextBox.Text, out tryTimes) == false)
            {
                MessageBox.Show("試行回数は数値で入力してください。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (tryTimes <= 0)
            {
                MessageBox.Show("試行回数は0より大きい数値で入力してください。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }


            // ガチャの取得確率を計算
            double result;
            try
            {
                result = CalcGettingRatio(tryTimes);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"取得確率の計算中にエラーが発生しました。\n\n{ex}",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }


            // 結果を表示
            MessageBox.Show($"{tryTimes}回引いて少なくとも1枚あたる確率は、\n{result}%です。",
                            "結果",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            tryCntTextBox.Clear();
        }



        /// <summary>
        /// 設定ファイルから設定値を取得するメソッド
        /// </summary>
        private void GetSettingsValue()
        {
            string line;

            try
            {
                // 3つ上の階層にあるSettingsフォルダ配下の設定ファイルパスを取得
                string currentFolderPath = Directory.GetCurrentDirectory();
                string settingsFilePath = GetParentFolderPath(currentFolderPath, 3) + @"\Settings\Settings.ini";

                // 設定ファイルを読み込む
                using (StreamReader sr = new StreamReader(settingsFilePath))
                {
                    // 全行読み込む
                    while ((line = sr.ReadLine()) != null)
                    {
                        // 一行ずつ読み込み、対象の文字列があれば値を取得し、変数に代入
                        if (line.Contains("EmissionRate") == true)
                        {
                            emissionRate = double.Parse(line.Substring(12).Replace("=", "").Replace(" ", ""));
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// n個上の階層パスを取得するメソッド
        /// </summary>
        /// <param name="path">基点となるパス</param>
        /// <param name="n">何個上に行くかを指定</param>
        private string GetParentFolderPath(string path, int n)
        {
            // n回ループ
            for (int i = 0; i < n; i++)
            {
                path = path.Substring(0, path.LastIndexOf("\\"));
            }

            // インデックスを返却
            return path;
        }



        /// <summary>
        /// ガチャの取得確率を計算するメソッド
        /// </summary>
        private double CalcGettingRatio(int times)
        {
            // n回引いて1枚も取得できない確率を計算
            // (1- 排出率)のn乗
            double ratio = Math.Pow(1 - emissionRate, times);

            // n回引いて少なくとも1枚は取得できる確率を計算
            // (1 - 1枚も取得できない確率)
            ratio = 1 - ratio;

            // %用に数値を変換して値を返却
            double per = Math.Round(ratio * 100, 1);
            return per;
        }
    }

}
