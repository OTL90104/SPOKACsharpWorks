using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPOKACsharpWorks
{
    class Program
    {
        #region GEPT成績輸入機的結構
        public struct Elementary
        {
            public int id;
            public int listening;
            public int reading;
        }
        #endregion
        #region 划酒拳的列舉
        public enum Status
        {
            USERWIN,
            COMWIN
        }
        #endregion
        #region 訂書系統的結構
        public struct Book
        {
            public string title;
            public int price;
            public int amount;
        }
        #endregion

        static void Main(string[] args)
        {
            bool start = true;
            //start == true--->執行程式
            //start == false--->結束程式

            String start_menu = "0";
            //進入各選單，或-1離開程式

            String function_out = "a";
            //function_out==-1-->離開各項功能


            //<主程式開始>
            while (start)
            {
                Console.WriteLine("");
                Console.WriteLine("\t      主選單");
                Console.WriteLine("\t-------------------");
                Console.WriteLine("\t 1：\t任意大小寫轉換");
                Console.WriteLine("\t 2：\t輸入n個正整數，找出最大值、最小值和平均值");
                Console.WriteLine("\t 3：\t樂透機");
                Console.WriteLine("\t 4：\tGEPT成績輸入機");
                Console.WriteLine("\t 5：\t划酒拳");
                Console.WriteLine("\t 6：\t訂書系統 ver.csv");
                Console.WriteLine("\t 7：\t訂書系統 ver.html");
                Console.WriteLine("\t-1：\t結束程式");
                start_menu = Console.ReadLine();

                #region 功能一：任意大小寫轉換
                if (start_menu == "1")
                {
                    start_menu = "0";
                    function_out = "0";
                    while (function_out != "-1")
                    {
                        Console.Clear();

                        //<任意大小寫轉換>
                        string input;
                        Console.WriteLine("Please input a word or sentance, I can convert uppercase to lowercase or lowercase to uppercase：");
                        input = Console.ReadLine();

                        for (int i = 0; i < input.Length; i++)
                        {
                            if (input[i] >= 65 && input[i] <= 90)
                            {
                                char x = (char)(input[i] + 32);
                                Console.Write(x);
                            }
                            else if (input[i] >= 97 && input[i] <= 122)
                            {
                                char x = (char)(input[i] - 32);
                                Console.Write(x);
                            }
                            else if (input[i] == 32)
                            {
                                char x = (char)input[i];
                                Console.Write(x);
                            }
                        }
                        string conti = "0";
                        while (conti == "0")
                        {
                            Console.WriteLine("\n=====================");
                            Console.WriteLine("convert again?? (1 : YES/2 : NO)");
                            conti = Console.ReadLine();

                            if (conti == "1")
                            {
                                Console.Clear();
                                function_out = "0";
                            }
                            else if (conti == "2")
                            {
                                Console.Clear();
                                function_out = "-1";
                            }
                            else
                            {
                                Console.WriteLine("\n母湯喔!! (1 : YES/2 : NO)");
                                conti = "0";
                            }
                        }
                    }
                }
                #endregion
                #region 功能二：輸入n個正整數，找出最大值、最小值和平均值
                else if (start_menu == "2")
                {
                    start_menu = "0";
                    function_out = "0";
                    Console.Clear();
                    String temp;
                    while (function_out != "-1")
                    {
                        //<輸入n個正整數，找出最大值、最小值和平均值>
                        int[] grade = new int[1];
                        int num = 0;
                        int counter = 0;
                        int max = 0;
                        int min = 2147483647;
                        double sum = 0;

                        while (num != -1)
                        {
                            Console.WriteLine("請輸入n個正整數n (0 < n < 2147483647)，輸入-1即可結束輸入程序");
                            num = int.Parse(Console.ReadLine());
                            if (num != -1)
                            {
                                grade[counter] = num;
                                Array.Resize(ref grade, grade.Length + 1);
                                counter++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        counter = 0;
                        do
                        {
                            if (grade[counter] < min)
                            {
                                min = grade[counter];
                            }
                            else if (grade[counter] > max)
                            {
                                max = grade[counter];
                            }
                            counter++;
                        } while (counter != grade.Length - 1);

                        for (int i = 0; i < grade.Length; i++)
                        {
                            sum += grade[i];
                        }
                        double mean = sum / (grade.Length - 1);

                        Console.WriteLine($"你輸入的個數是{grade.Length - 1}");
                        Console.WriteLine($"你輸入的最大值是{max}");
                        Console.WriteLine($"你輸入的最小值是{min}");
                        Console.WriteLine($"你輸入的平均值是{mean}");
                        Console.WriteLine("=========================");
                        Console.WriteLine("\n輸入1重來一次/-1離開");
                        temp = Console.ReadLine();
                        if (temp == "1")
                        {
                            Console.Clear();
                        }
                        else if (temp == "-1")
                        {
                            Console.Clear();
                            function_out = "-1";
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("母湯喔~要輸入-1才給你離開~");
                            function_out = "a";
                        }
                    }
                }
                #endregion
                #region 功能三：樂透機
                else if (start_menu == "3")
                {
                    start_menu = "0";
                    function_out = "0";

                    while (function_out != "-1")
                    {
                        Console.Clear();

                        //<樂透機>
                        int startGame = 1;
                        while (startGame == 1)
                        {
                            Console.WriteLine("歡迎來到樂透兌獎機!!!");
                            Console.WriteLine("請輸入六個數字並以,隔開(1~49)：");
                            string input = Console.ReadLine();
                            bool inputOK = false;
                            int[] tempNum;
                            int[] user = { -1, -1, -1, -1, -1, -1 };

                            //切割成數字同時檢查有無輸入錯誤，若無誤即存入使用者的陣列中
                            while (inputOK == false)
                            {
                                tempNum = SplitNum(input);
                                for (int i = 0; i < tempNum.Length; i++)
                                {
                                    if (tempNum[i] == -1 || Array.IndexOf(tempNum, tempNum[i]) != Array.LastIndexOf(tempNum, tempNum[i]))
                                    {
                                        Console.WriteLine("母湯喔!輸入錯誤!請輸入六個數字並以,隔開：");
                                        input = Console.ReadLine();
                                        inputOK = false;
                                        break;
                                    }
                                    else
                                    {
                                        user[i] = tempNum[i];
                                        inputOK = true;
                                    }
                                }
                            }

                            //電腦產生六個不重複的數字
                            int[] com = GiveLottery();

                            //輸出結果
                            Console.WriteLine("======公布結果======");
                            Console.WriteLine("你輸入的數字：");
                            for (int i = 0; i < 6; i++)
                            {
                                if (i == 5)
                                {
                                    Console.Write(user[i]);
                                }
                                else
                                {
                                    Console.Write(user[i] + ",");
                                }
                            }
                            Console.WriteLine("\n=====================");
                            Console.WriteLine("電腦輸入的數字：");
                            for (int i = 0; i < 6; i++)
                            {
                                if (i == 5)
                                {
                                    Console.Write(com[i]);
                                }
                                else
                                {
                                    Console.Write(com[i] + ",");
                                }
                            }

                            //比對結果
                            int counter = 0;
                            Console.WriteLine("\n=====================");
                            for (int i = 0; i < 6; i++)
                            {
                                for (int j = 0; j < 6; j++)
                                {
                                    if (user[i] == com[j])
                                    {
                                        counter++;
                                    }
                                }
                            }
                            Console.WriteLine($"共猜對{counter}個數字!!");

                            if (counter > 0)
                            {
                                counter = 0;
                                Console.WriteLine("你猜中的數字有：");
                                for (int i = 0; i < 6; i++)
                                {
                                    for (int j = 0; j < 6; j++)
                                    {
                                        if (user[i] == com[j])
                                        {
                                            counter++;
                                            Console.Write(user[i] + " ");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("槓龜啦~~~~~~~~~哈哈哈");
                            }
                            string conti = "0";
                            while (conti == "0")
                            {
                                Console.WriteLine("\n=====================");
                                Console.WriteLine("要重新玩嗎?? (1 : YES/2 : NO)");
                                conti = Console.ReadLine();

                                if (conti == "1")
                                {
                                    Console.Clear();
                                    startGame = 1;
                                }
                                else if (conti == "2")
                                {
                                    startGame = 2;
                                    function_out = "-1";
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("\n母湯喔!! (1 : YES/2 : NO)");
                                    conti = "0";
                                }
                            }
                        }
                    }
                }
                #endregion
                #region 功能四：GEPT成績輸入機
                else if (start_menu == "4")
                {
                    start_menu = "0";
                    function_out = "0";

                    while (function_out != "-1")
                    {
                        Console.Clear();

                        //<GEPT成績輸入機>
                        bool start4 = true;
                        //start4 == true--->執行程式
                        //start4 == false--->結束程式

                        String start_menu4 = "0";
                        //進入各選單，或-1離開程式

                        String function_out4 = "a";
                        //function_out4==-1-->離開各項功能

                        Elementary[] elementary = new Elementary[1];
                        //建立一個elementary結構的陣列

                        //<主程式開始>
                        while (start4)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("\t  GEPT成績輸入機");
                            Console.WriteLine("\t-------------------");
                            Console.WriteLine("\t 1：\t輸入成績");
                            Console.WriteLine("\t 2：\t統計資料");
                            Console.WriteLine("\t 3：\t修改資料");
                            Console.WriteLine("\t-1：\t回主選單");
                            start_menu4 = Console.ReadLine();

                            #region 功能一：輸入成績
                            if (start_menu4 == "1")
                            {
                                start_menu4 = "0";
                                function_out4 = "0";
                                while (function_out4 != "-1")
                                {
                                    Console.Clear();

                                    //<輸入成績的程式>
                                    for (int i = 0; function_out4 != "-1"; i++)
                                    {
                                        while (function_out4 != "-1")
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine($"請輸入第{i + 1}位學生的聽力分數：(0~120，或輸入-1離開)");
                                            elementary[i].listening = int.Parse(Console.ReadLine());
                                            if (elementary[i].listening == -1)
                                            {
                                                Console.Clear();
                                                function_out4 = "-1";
                                                start_menu4 = "0";
                                            }
                                            else if (elementary[i].listening < 0 || elementary[i].listening > 120)
                                            {
                                                Console.WriteLine("===聽力成績輸入錯誤===");
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }

                                        while (function_out4 != "-1")
                                        {
                                            Console.WriteLine($"請輸入第{i + 1}位學生的閱讀分數：(0~120，或輸入-1離開)");
                                            elementary[i].reading = int.Parse(Console.ReadLine());
                                            if (elementary[i].reading == -1)
                                            {
                                                Console.Clear();
                                                function_out4 = "-1";
                                                start_menu4 = "0";
                                            }
                                            else if (elementary[i].reading < 0 || elementary[i].reading > 120)
                                            {
                                                Console.WriteLine("===閱讀成績輸入錯誤===");
                                            }
                                            else
                                            {
                                                elementary[i].id = (i + 1);
                                                Console.Clear();
                                                break;
                                            }
                                        }
                                        //如果聽力閱讀都輸入正確，陣列才會多出一格。(所以離開前一定會多出一格裝-1)
                                        if (function_out4 != "-1")
                                        {
                                            Array.Resize(ref elementary, elementary.Length + 1);
                                        }
                                    }
                                }
                            }
                            #endregion
                            #region 功能二：資料統計
                            else if (start_menu4 == "2")
                            {
                                start_menu4 = "0";
                                function_out4 = "0";
                                Console.Clear();
                                String temp;
                                while (function_out4 != "-1")
                                {
                                    temp = "0";
                                    //<列印成績的程式 >                       
                                    Console.WriteLine("");
                                    Console.WriteLine("\t學生編號\t聽力成績\t閱讀成績\t總成績\t");
                                    for (int i = 0; i < elementary.Length - 1; i++)
                                    {
                                        Console.WriteLine("\t---------------------------------------------------------");
                                        Console.WriteLine($"\t{elementary[i].id}\t\t{elementary[i].listening}\t\t{elementary[i].reading}\t\t{elementary[i].listening + elementary[i].reading}\t");
                                    }
                                    //elementary.Length - 1是因為離開會多一格為了輸入-1

                                    Console.WriteLine("\n輸入-1離開");
                                    temp = Console.ReadLine();
                                    if (temp == "-1")
                                    {
                                        Console.Clear();
                                        function_out4 = "-1";
                                        start_menu4 = "0";
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("母湯喔~要輸入-1才給你離開~");
                                        function_out4 = "a";
                                    }
                                }
                            }
                            #endregion
                            #region 功能三：修改成績
                            else if (start_menu4 == "3")
                            {
                                start_menu4 = "0";
                                function_out4 = "0";
                                int num = 0;

                                while (function_out4 != "-1")
                                {
                                    Console.Clear();

                                    //<修改成績的程式>
                                    while (function_out4 != "-1")
                                    {
                                        int tempNum = 0;
                                        while (function_out4 != "-1")
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("請問你要修改第幾號學生的資料? (或-1離開)");
                                            num = int.Parse(Console.ReadLine());
                                            if (num == -1)
                                            {
                                                Console.Clear();
                                                function_out4 = "-1";
                                                start_menu4 = "0";
                                            }
                                            else if (num >= elementary.Length)
                                            {
                                                Console.WriteLine("===查無此資料===");
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                break;
                                            }
                                        }
                                        while (function_out4 != "-1")
                                        {
                                            Console.WriteLine($"第{num}位學生的聽力成績改為： (或-1離開)");
                                            tempNum = int.Parse(Console.ReadLine());
                                            if (tempNum == -1)
                                            {
                                                Console.Clear();
                                                function_out4 = "-1";
                                                start_menu4 = "0";
                                            }
                                            else if (tempNum < 0 || tempNum > 120)
                                            {
                                                Console.WriteLine("===聽力成績輸入錯誤===");
                                            }
                                            else
                                            {
                                                elementary[num - 1].listening = tempNum;
                                                tempNum = 0;
                                                break;
                                            }
                                        }
                                        while (function_out4 != "-1")
                                        {
                                            Console.WriteLine($"第{num}位學生的閱讀成績改為： (或-1離開)");
                                            tempNum = int.Parse(Console.ReadLine());
                                            if (tempNum == -1)
                                            {
                                                Console.Clear();
                                                function_out4 = "-1";
                                                start_menu4 = "0";
                                            }
                                            else if (tempNum < 0 || tempNum > 120)
                                            {
                                                Console.WriteLine("===閱讀成績輸入錯誤===");
                                            }
                                            else
                                            {
                                                elementary[num - 1].reading = tempNum;
                                                tempNum = 0;
                                                Console.Clear();
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                            #region 結束程式
                            else if (start_menu4 == "-1")
                            {
                                start4 = false;
                                function_out = "-1";
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("母湯喔~要輸入-1才給你離開~");
                            }
                            #endregion
                        }

                    }
                }
                #endregion
                #region 功能五：划酒拳
                else if (start_menu == "5")
                {
                    start_menu = "0";
                    function_out = "0";

                    while (function_out != "-1")
                    {
                        Console.Clear();

                        //<划酒拳>
                        int play = 0;
                        while (play != 1 || play != 2)
                        {
                            Console.WriteLine("Do you want to play a game? (1：Yes/2：No)");
                            String playAgame = Console.ReadLine();
                            if (playAgame == "1")
                            {
                                play = 1;
                                Console.Clear();
                            }
                            else if (playAgame == "2")
                            {
                                play = 2;
                                function_out = "-1";
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                play = 0;
                            }

                            while (play == 1)
                            {
                                Random rndNum = new Random();
                                int order = rndNum.Next(0, 2);
                                int usercounter = 0;
                                int comcounter = 0;
                                int userNum1 = 0;
                                int userNum2 = 0;
                                int userAns = 0;
                                Status gameStatus = Status.USERWIN;
                                Console.WriteLine("=====GAME START=====");

                                if (order == 0)
                                {
                                    gameStatus = Status.USERWIN;
                                    Console.WriteLine("You First");
                                }
                                else if (order == 1)
                                {
                                    gameStatus = Status.COMWIN;
                                    Console.WriteLine("COM First");
                                }
                                while (!(usercounter == 2 || comcounter == 2))
                                {
                                    int comNum1 = rndNum.Next(0, 2);
                                    comNum1 *= 5;
                                    int comNum2 = rndNum.Next(0, 2);
                                    comNum2 *= 5;
                                    int comAns = rndNum.Next(0, 5);
                                    comAns *= 5;

                                    if (gameStatus == Status.USERWIN)
                                    {
                                        Console.WriteLine("Please Guess");
                                        Console.WriteLine("Please input left number (0/5)：");
                                        userNum1 = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Please input right number (0/5)：");
                                        userNum2 = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Please input the number you guess (0/5/10/15/20)：");
                                        userAns = int.Parse(Console.ReadLine());
                                        if ((userNum1 + userNum2 + comNum1 + comNum2) == userAns)
                                        {
                                            Console.WriteLine($"Your number：{userNum1}，{userNum2}");
                                            Console.WriteLine($"COM's number：{comNum1}，{comNum2}");
                                            Console.WriteLine($"Your answer：{userAns}");
                                            Console.WriteLine("=====YOU WIN!!=====");
                                            Console.WriteLine("");
                                            gameStatus = Status.USERWIN;
                                            usercounter++;
                                            comcounter = 0;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Your number：{userNum1}，{userNum2}");
                                            Console.WriteLine($"COM's number：{comNum1}，{comNum2}");
                                            Console.WriteLine($"Your answer：{userAns}");
                                            Console.WriteLine("=====It's COM's turn!!=====");
                                            Console.WriteLine("");
                                            usercounter = 0;
                                            comcounter = 0;
                                            gameStatus = Status.COMWIN;
                                        }
                                    }
                                    if (gameStatus == Status.COMWIN)
                                    {
                                        Console.WriteLine("Computer Guess");
                                        Console.WriteLine("Please input left number (0/5)：");
                                        userNum1 = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Please input right number (0/5)：");
                                        userNum2 = int.Parse(Console.ReadLine());
                                        if ((userNum1 + userNum2 + comNum1 + comNum2) == comAns)
                                        {
                                            Console.WriteLine($"Your number：{userNum1}，{userNum2}");
                                            Console.WriteLine($"COM's number：{comNum1}，{comNum2}");
                                            Console.WriteLine($"COM's answer：{comAns}");
                                            Console.WriteLine("=====YOU LOSE!!=====");
                                            Console.WriteLine("");
                                            gameStatus = Status.COMWIN;
                                            usercounter = 0;
                                            comcounter++;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Your number：{userNum1}，{userNum2}");
                                            Console.WriteLine($"COM's number：{comNum1}，{comNum2}");
                                            Console.WriteLine($"COM's answer：{comAns}");
                                            Console.WriteLine("=====It's your turn!!=====");
                                            Console.WriteLine("");
                                            usercounter = 0;
                                            comcounter = 0;
                                            gameStatus = Status.USERWIN;
                                        }
                                    }
                                    if (usercounter == 2)
                                    {
                                        Console.WriteLine("******MISSION COMPLETED!!!******");
                                        play = 0;
                                    }
                                    else if (comcounter == 2)
                                    {
                                        Console.WriteLine("******GAME OVER!!!******");
                                        play = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
                #region 功能六：訂書系統 ver.csv
                else if (start_menu == "6")
                {
                    start_menu = "0";
                    function_out = "0";

                    while (function_out != "-1")
                    {
                        Console.Clear();

                        //<訂書系統 ver.csv>
                        //詢問要輸入幾筆資料
                        int num = -1;
                        while (num == -1)
                        {
                            Console.WriteLine("請問你要輸入幾筆資料?");
                            num = CheckNumbooking(Console.ReadLine());
                            if (num == -1)
                            {
                                Console.WriteLine("母湯喔!輸入錯誤喔!!");
                            }
                        }

                        //將資料存入結構中
                        Book[] book = new Book[num];
                        int counter = 0;
                        int index = num;

                        while (counter < index)
                        {
                            //輸入書名
                            num = -1;
                            Book tempBook;
                            tempBook.title = "";
                            tempBook.price = 0;
                            tempBook.amount = 0;

                            Console.WriteLine("請輸入書名：");
                            tempBook.title = Console.ReadLine();

                            //輸入價錢
                            while (num == -1)
                            {
                                Console.WriteLine("請輸入價錢：");
                                num = CheckNumbooking(Console.ReadLine());
                                if (num == -1)
                                {
                                    Console.WriteLine("母湯喔!輸入錯誤喔!!");
                                }
                                tempBook.price = num;
                            }
                            num = -1;
                            //輸入數量
                            while (num == -1)
                            {
                                Console.WriteLine("請輸入數量：");
                                num = CheckNumbooking(Console.ReadLine());
                                if (num == -1)
                                {
                                    Console.WriteLine("母湯喔!輸入錯誤喔!!");
                                }
                                tempBook.amount = num;
                            }
                            book[counter] = tempBook;
                            counter++;
                        }

                        //將結構存入string的陣列中，以儲存檔案
                        String[] bookString = new string[index];
                        for (int i = 0; i < index; i++)
                        {
                            bookString[i] = $"{book[i].title},{book[i].price},{book[i].amount}";
                        }

                        //檔案建立：如果檔案已經存在的話就刪掉建立新的
                        string path = $"Booking_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.csv";
                        SaveInputToCsv(bookString, path);
                        Console.WriteLine(path);

                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine("標題,價錢,數量");
                        for (int i = 0; i < index; i++)
                        {
                            stringBuilder.AppendLine(bookString[i]);
                        }

                        File.WriteAllText(path, stringBuilder.ToString(), Encoding.UTF8);

                        string conti = "0";
                        while (conti == "0")
                        {
                            Console.WriteLine("\n=====================");
                            Console.WriteLine("要重新建立新檔案嗎?? (1 : YES/2 : NO)");
                            conti = Console.ReadLine();

                            if (conti == "1")
                            {
                                Console.Clear();

                            }
                            else if (conti == "2")
                            {
                                function_out = "-1";
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("\n母湯喔!! (1 : YES/2 : NO)");
                                conti = "0";
                            }
                        }
                    }
                }
                #endregion
                #region 功能七：訂書系統 ver.html
                else if (start_menu == "7")
                {
                    start_menu = "0";
                    function_out = "0";

                    while (function_out != "-1")
                    {
                        Console.Clear();

                        //<訂書系統 ver.html>
                        //詢問要輸入幾筆資料
                        int num = -1;
                        while (num == -1)
                        {
                            Console.WriteLine("請問你要輸入幾筆資料?(至少三筆)");
                            num = CheckNum3(Console.ReadLine());
                            if (num == -1)
                            {
                                Console.WriteLine("母湯喔!輸入錯誤喔!!");
                            }
                        }

                        //將資料存入結構中
                        Book[] book = new Book[num];
                        int counter = 0;
                        int index = num;

                        while (counter < index)
                        {
                            //輸入書名
                            num = -1;
                            Book tempBook;
                            tempBook.title = "";
                            tempBook.price = -1;
                            tempBook.amount = -1;

                            Console.WriteLine("請輸入書名：");
                            tempBook.title = Console.ReadLine();

                            //輸入價錢
                            while (tempBook.price == -1)
                            {
                                Console.WriteLine("請輸入價錢：");
                                tempBook.price = CheckNumbooking(Console.ReadLine());
                                if (tempBook.price == -1)
                                {
                                    Console.WriteLine("母湯喔!輸入錯誤喔!!");
                                }
                            }

                            //輸入數量
                            while (tempBook.amount == -1)
                            {
                                Console.WriteLine("請輸入數量：");
                                tempBook.amount = CheckNumbooking(Console.ReadLine());
                                if (tempBook.amount == -1)
                                {
                                    Console.WriteLine("母湯喔!輸入錯誤喔!!");
                                }
                            }
                            book[counter] = tempBook;
                            counter++;
                        }

                        StringBuilder stringBuilder = new StringBuilder();
                        try
                        {
                            string headPath = "head.txt";
                            if (File.Exists(headPath))
                            {
                                string[] head = File.ReadAllLines(headPath);
                                for (int i = 0; i < head.Length; i++)
                                {
                                    stringBuilder.AppendLine(head[i]);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }

                        for (int i = 0; i < index; i++)
                        {
                            stringBuilder.AppendLine("<tr>");
                            stringBuilder.AppendLine($"<td>{book[i].title}</td>");
                            stringBuilder.AppendLine($"<td>{book[i].price}</td>");
                            stringBuilder.AppendLine($"<td>{book[i].amount}</td>");
                            stringBuilder.AppendLine("</tr>");
                        }

                        stringBuilder.AppendLine("</table>");
                        stringBuilder.AppendLine("</body>");
                        stringBuilder.AppendLine("</html>");

                        //檔案建立：如果檔案已經存在的話就刪掉建立新的
                        string path = $"Booking_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.html";
                        SaveInputToHtml(stringBuilder.ToString(), path);
                        Console.WriteLine(path);

                        File.WriteAllText(path, stringBuilder.ToString(), Encoding.UTF8);

                        string conti = "0";
                        while (conti == "0")
                        {
                            Console.WriteLine("\n=====================");
                            Console.WriteLine("要重新建立新檔案嗎?? (1 : YES/2 : NO)");
                            conti = Console.ReadLine();

                            if (conti == "1")
                            {
                                Console.Clear();

                            }
                            else if (conti == "2")
                            {
                                function_out = "-1";
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("\n母湯喔!! (1 : YES/2 : NO)");
                                conti = "0";
                            }
                        }
                    }
                }
                #endregion
                #region 結束程式
                else if (start_menu == "-1")
                {
                    start = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("母湯喔~要輸入-1才給你離開~");
                }
                #endregion
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        #region 樂透機專用function
        /// <summary>
        /// 一個字串輸入後，先以逗點切成小字串，再去除空白並判斷是否可轉成數字，最後裝入一個數字陣列中輸出。
        /// </summary>
        /// <param name="input">一個字串</param>
        /// <returns>一個數字的陣列</returns>
        public static int[] SplitNum(string input)
        {
            string[] arrayString = input.Split(',');
            int[] arrayError = { -1, -1, -1 };
            if (arrayString.Length == 6)
            {
                int[] arrayNum = { -1, -1, -1, -1, -1, -1 };
                for (int i = 0; i < 6; i++)
                {
                    arrayNum[i] = CheckNum(arrayString[i].Trim());
                }
                return arrayNum;
            }
            return arrayError;
        }
        /// <summary>
        /// 判斷字串能不能被轉成int，正確的話回傳int數字，錯的話回傳-1
        /// </summary>
        /// <param name="splitedString">輸入裁減過的字串</param>
        /// <returns>回傳int</returns>
        public static int CheckNum(string splitedString)
        {
            int numOK;
            if (int.TryParse(splitedString, out numOK) && numOK > 0 && numOK < 50)
            {
                return numOK;
            }
            return -1;
        }
        /// <summary>
        /// 電腦產生六個不重複的數字
        /// </summary>
        /// <returns>int陣列</returns>
        public static int[] GiveLottery()
        {
            Random rnd = new Random();
            int[] com = new int[6];
            for (int i = 0; i < 6; i++)
            {
                com[i] = rnd.Next(1, 50);
                while (Array.IndexOf(com, com[i]) != Array.LastIndexOf(com, com[i]))
                {
                    com[i] = rnd.Next(1, 50);
                }
            }
            return com;
        }
        #endregion
        #region 訂書系統 ver.csv function
        public static int CheckNumbooking(string input)
        {
            int num;
            if (int.TryParse(input, out num) && num > 0)
            {
                return num;
            }
            return -1;
        }

        public static void SaveInputToCsv(String[] bookString, string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllLines(path, bookString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion
        #region 訂書系統 ver.html專用 function
        public static int CheckNum3(string input)
        {
            int num;
            if (int.TryParse(input, out num) && num >= 3)
            {
                return num;
            }
            return -1;
        }
        public static void SaveInputToHtml(string bookString, string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllText(path, bookString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion
    }
}
