using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hw1_calculator
{
    public partial class Form1 : Form
    {
        string calculator = null, previousvalue = null, currentvalue=null;
        Double Result = 0;
        bool flag = false;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
            label1.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0) //去掉最後一個數
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button buttonNumber = sender as Button;
            if (textBox1.Text == "0")
            {
                textBox1.Text = buttonNumber.Text;
            }
            else
            {
                if (textBox1.Text.Contains (".") && buttonNumber.Text == ".")
                {
                    textBox1.Text = textBox1.Text;
                }
                else
                {
                    textBox1.Text += buttonNumber.Text;
                    currentvalue = textBox1.Text;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            label1.Text = "";  
            previousvalue = null;
            flag = false;
            currentvalue = null;
            calculator = null;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(-Convert.ToDouble(textBox1.Text)); //將字串轉為double加負號在轉為字串
        }

        private void buttoncalculator_click(object sender, EventArgs e)
        {

            //Button buttoncalculator = sender as Button; //獲取當前點擊的button
            Button buttoncalculator = (Button)sender;
            if(flag == false)
            {
                flag = true;
                previousvalue = textBox1.Text;
                calculator = buttoncalculator.Text;
                label1.Text = previousvalue + calculator;
                textBox1.Text = "";
            }
            else
            {
        
                button16.PerformClick();
                calculator = buttoncalculator.Text;
                //label1.Text = previousvalue + calculator;
                label1.Text = Result.ToString();
                textBox1.Text = "";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {

            if(calculator == null)
                return;
            Double Getpreviousvalue = Double.Parse(previousvalue);
            Double Getnextvalue = Double.Parse(currentvalue);
            //flag = false;
            switch (calculator)
            {
                case "+":
                    Result = Getpreviousvalue + Getnextvalue;
                    break;
                case "-":
                    Result = Getpreviousvalue - Getnextvalue;
                    break;
                case "*":
                    Result = Getpreviousvalue * Getnextvalue;
                    break;
                case "/":
                    if (Getnextvalue != 0)
                    {
                        Result = Getpreviousvalue / Getnextvalue;
                        break;
                    }
                    else
                    {
                        textBox1.Text = "0";
                        label1.Text = "";
                        previousvalue = "";
                        MessageBox.Show("除數不可為零,請重新輸入");
                        break;
                    }
                default:
                    break;
            }
            label1.Text = "";
            textBox1.Text = Result.ToString();
            previousvalue = Result.ToString();

        }
    }
}
