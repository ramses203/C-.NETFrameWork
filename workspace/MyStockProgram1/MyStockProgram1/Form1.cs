using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStockProgram1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            loginButton.Click += LoginButton_Click;
            codeListButton.Click += CodeListButtonClick;
            axKHOpenAPI1.OnEventConnect += API_OnEventConnect;

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("버튼이 눌렸습니다.");
            // 로그인창 띄우기
            axKHOpenAPI1.CommConnect(); //axKHOpenAPI1 이 참조변수를 이용해서 키움증권에서 데이터를 받아올수 있게된다.
        }
        
        private void CodeListButtonClick(object sender, EventArgs e)
        {
            // 인자값으로 null을 전달하면 전체 종목조회가능
            string codeList = axKHOpenAPI1.GetCodeListByMarket(null);
            Console.WriteLine(codeList);
            string[] codeArray = codeList.Split(';');

            foreach(string code in codeArray)
            {
                string itemName = axKHOpenAPI1.GetMasterCodeName(code);
                Console.WriteLine(code + ' ' + itemName);
            }


            // 총 코드갯수 나타내는 부분
            int WordCount = 1;
            foreach(char i in codeList)
            {
                if (i == ';') { WordCount++; } 
            }
            Console.WriteLine("총 종목코드는 "+ WordCount+" 개 입니다.");




        }

        private void API_OnEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            Console.WriteLine("사용자가 로그인 시도를 했습니다.");
            if (e.nErrCode == 0)
            {
                Console.WriteLine("로그인 성공");
            }else
            {
                Console.WriteLine("로그인 실패");
            }
        }


    }
}
