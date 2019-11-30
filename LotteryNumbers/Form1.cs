using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace LotteryNumbers
{
    public partial class Lottery : Form
    {
        public Lottery()
        {
            InitializeComponent();
        }
        
        int[] myNumbers; // 로또 당첨 번호 배열 정의

        private static DateTime Delay(int MS) // Delay 함수
           // Thread.sleep 쓰면 일반적인 용도로 대기 시간 주기에는 폼이 멈춰서 불편하기 때문에
           // 화면이 멈추지 않고 딜레이를 줄 수 있게끔 하는 함수
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e) // START 버튼 클릭 이벤트
        {   
            //txtGoodLuck 보여주기
            txtGoodLuck.Visible = false;

            //txtDisplay 초기화
            txtDisplay1.Text = "";
            txtDisplay2.Text = "";
            txtDisplay3.Text = "";
            txtDisplay4.Text = "";
            txtDisplay5.Text = "";
            txtDisplay6.Text = "";
            txtDisplay7.Text = "";

            Delay(1000); // 딜레이 1초

            Random rnd = new Random(); // 랜덤 함수 선언
            myNumbers = new int[7]; // 랜덤 배열 길이 
            int tmpNumber = 0; // tmpNumber 초기화
             
            for (int i = 0; i < 7; i++)
            {
                // 숫자 랜덤
                tmpNumber = rnd.Next(1, 45);
                
                //중복 검사
                if (!myNumbers.Contains(tmpNumber))
                {
                    //배열에 i 추가
                    myNumbers[i] = tmpNumber;
                }
                else
                {
                    
                    i--; // 다시 되돌리기
                }
            }
            
            // 각 배열에 숫자 저장 및 텍스트박스로 출력
            txtDisplay1.Text = myNumbers[0].ToString();
            Delay(1000);
            txtDisplay2.Text = myNumbers[1].ToString();
            Delay(1000);
            txtDisplay3.Text = myNumbers[2].ToString();
            Delay(1000);
            txtDisplay4.Text = myNumbers[3].ToString();
            Delay(1000);
            txtDisplay5.Text = myNumbers[4].ToString();
            Delay(1000);
            txtDisplay6.Text = myNumbers[5].ToString();
            Delay(1000);
            txtDisplay7.Text = myNumbers[6].ToString();

            txtGoodLuck.Visible = true; // txtGoodLuck 띄우기

            MessageBox.Show("축하합니다!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            // 랜덤 번호가 끝나면 메세지 박스 띄우기
        }  

        // label에 타이머로 애니메이션 띄우기
        private int index = 0; 
        private void timer1_Tick(object sender, EventArgs e)
        {
            index %= imageList1.Images.Count;
            label1.Image = imageList1.Images[index++];
        }
    }
}
