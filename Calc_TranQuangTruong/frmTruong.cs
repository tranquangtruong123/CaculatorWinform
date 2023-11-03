using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_TranQuangTruong
{

    public partial class frmTruong : Form
    {
        string result = "";
        string result2 = "";
        string display = "";
        string history = "";
        string displayzero = "0";
        string luuhistory = "";
        List<string> collectionHistory = new List<string>();
        List<string> collectionNumber = new List<string>();
        List<string> collectionOperator = new List<string>();
        public frmTruong()
        {
            
            InitializeComponent();
        }

        
        private void button_clock_Click(object sender, EventArgs e)//Cau 10 Luu Nhat Ky
        {
            for(int i = 0; i < collectionHistory.Count; i++)
            {
                history += collectionHistory[i];
            }
            lb_history.Text = history;
            InitPainalLoad(1);

        }

        private void InitPainalLoad(int v)
        {
            if(v == 1)
            {
                panel_4.Visible = false;
             
            }
            else if(v == 2)
            {
                panel_4.Visible = true;
            }
        }

        private void bntcaculator_Click(object sender, EventArgs e)
        {
            InitPainalLoad(2);
        }

        
        private void btn_nav_click(object sender, EventArgs e)//Cau 8 Nhận số âm khi nhấn nút ± (có dấu - đằng trước)
        {
            InputNumber("n");
        }

        private void btn_zero_click(object sender, EventArgs e)
        {
            InputNumber("0");
        }

        private void InputNumber(string v)//Cau 6,Cau 2
        {
            if ((v == "+" || v == "-" || v == "x" || v == "/")){
               
                if(collectionOperator.Count() == 0)
                {
                    display += v;
                    collectionNumber.Add(result);
                    collectionOperator.Add(v);
                    string displaytmp = result;
                    lb_result.Text = FormatNumberWithCommas(displaytmp) + v;
                    result = "";
                    
                }
                else
                {
                    
                    double num1 = double.Parse(collectionNumber[0]);
                    double num2 = double.Parse(result);
                    string operator1 = collectionOperator[0];
                    string tmp = "";
                    double calculatedResult = 0;

                    switch (operator1)
                    {
                        case "+":
                            calculatedResult = num1 + num2;
                            break;
                        case "-":
                            calculatedResult = num1 - num2;
                            break;
                        case "x":
                            calculatedResult = num1 * num2;
                            break;
                        case "/":
                            calculatedResult = num1 / num2;
                            break;
                    }
                    collectionNumber.Clear();
                    collectionOperator.Clear();
                    collectionNumber.Add(calculatedResult.ToString());
                    collectionOperator.Insert(0, v); 

                    display = calculatedResult.ToString() + v;
                    lb_result.Text = display;
                    result = "";
                    display = "";
                }
            }
            else if(v.Equals(","))
            {
                    display += ",";
                    result += ".";
                    lb_display.Text = display;
            }
            else if (v.Equals("%"))//nhap phan tram
            {
                double percent;
                if (collectionNumber.Count == 0)
                {
                    percent = Double.Parse(result);
                    percent = percent / 100.0;
                    result = percent + "";
                }
                else if (collectionNumber.Count == 1)
                {
                    percent = Double.Parse(result);
                    percent = percent / 100.0;
                    result = percent + "";
                }
                lb_display.Text = FormatNumberWithCommas(result);
            }
            else if (v.Equals("n"))
            {
                double nav = Double.Parse(result.ToString()) * -1.0;
                result = nav + "";
                display = result;
                lb_display.Text = display;
            }
            else
            {
                display += v;
                result += v;
                lb_display.Text = FormatNumberWithCommas(result);
            }
            

        }

        private void btn_dot_click(object sender, EventArgs e)
        {
            InputNumber(",");
        }
        private void btn_equal_click(object sender, EventArgs e) //Cau 7. Thực hiện đúng khi nhấn nút dấu bằng(nhiều lần):
        {
            collectionNumber.Add(result);
            string tmp = "";
            string tmp2 = "";

            
            switch (collectionOperator[0])
            {
                case "+":
                    tmp = (double.Parse(collectionNumber[0]) + double.Parse(collectionNumber[1])).ToString();
                    break;
                case "-":
                    tmp = (double.Parse(collectionNumber[0]) - double.Parse(collectionNumber[1])).ToString();
                    break;
                case "x":
                    tmp = (double.Parse(collectionNumber[0]) * double.Parse(collectionNumber[1])).ToString();
                    break;
                case "/":
                    tmp = (double.Parse(collectionNumber[0]) / double.Parse(collectionNumber[1])).ToString();
                    break;
            }
            if (luuhistory == "1" && collectionHistory.Count > 0)
            {
                collectionHistory.RemoveAt(collectionHistory.Count - 1);
            }
            luuhistory = collectionNumber[0] + collectionOperator[0] + collectionNumber[1] + "\n"
                + "= "+ tmp + "\n";
            collectionHistory.Add(luuhistory);
            
            
            lb_result.Text = FormatNumberWithCommas(tmp);
            lb_display.Text = FormatNumberWithCommas(collectionNumber[0]) + collectionOperator[0] + FormatNumberWithCommas(collectionNumber[1])  + " =";
            collectionNumber[0] = tmp;
            luuhistory = "1";

            result = "";
            display = "";
        }

        private void btn_one_click(object sender, EventArgs e)
        {
            InputNumber("1");
        }

        private void btn_two_click(object sender, EventArgs e)
        {
            InputNumber("2");
        }

        private void btn_three_click(object sender, EventArgs e)
        {
            InputNumber("3");
        }

        private void btn_sum_click(object sender, EventArgs e)
        {
            InputNumber("+");
        }

        

        private void btn_for_click(object sender, EventArgs e)
        {
            InputNumber("4");
        }

        private void btn_five_click(object sender, EventArgs e)
        {
            InputNumber("5");
        }

        private void btn_six(object sender, EventArgs e)
        {
            InputNumber("6");
        }

        private void btn_sub_click(object sender, EventArgs e)
        {
            InputNumber("-");
        }

        private void btn_seven_click(object sender, EventArgs e)
        {
            InputNumber("7");
        }

        private void btn_eight_click(object sender, EventArgs e)
        {
            InputNumber("8");
        }

        private void btn_nine_clcik(object sender, EventArgs e)
        {
            InputNumber("9");
        }

        private void btn_mul_click(object sender, EventArgs e)
        {
            InputNumber("x");
        }

        private void btn_clear_click(object sender, EventArgs e)//Cau 4. Thực hiện chức năng nút C:
        {

            display = "";
            lb_display.Text = "";
            lb_result.Text = "";
            collectionNumber.Clear();
            collectionOperator.Clear();
        }

        private void btn_parket_click(object sender, EventArgs e)
        {

        }

        private void btn_percent_click(object sender, EventArgs e)
        {
            InputNumber("%");
        }

        private void btn_div_click(object sender, EventArgs e)
        {
            InputNumber("/");
        }

    
        private void Form1_Load(object sender, EventArgs e)
        {
            if (result == "")
            {
                lb_display.Text = displayzero;
            }
        }

        private void btn_history_Click(object sender, EventArgs e)
        {
            collectionHistory.Clear();
            history = "";
            lb_history.Text = history;
        }

        
        private string FormatNumberWithCommas(string numberString)//Cau 3 Nhập số thập phân, định đạng đúng
        {
            string formattedNumber;

            if (double.TryParse(numberString, out double number))
            {
                if (number % 1 == 0)
                {
                    formattedNumber = number.ToString("#,##0");
                }
                else
                {
                    formattedNumber = number.ToString("#,##0.00");
                }
            }
            else
            {
                formattedNumber = "Invalid number";
            }

            return formattedNumber;
        }

        private void deletestringpos_Click(object sender, EventArgs e)//Cau5 Xóa lùi biểu thức ( xóa từ phải sang trái)
        {
            string chuoitmp = "0";
            if (result.Length == 1)
            {
                lb_display.Text = chuoitmp;
            }
            else
            {
                result = result.Remove(result.Length - 1);
                lb_display.Text = result;
            }
        }

        
    }
}
