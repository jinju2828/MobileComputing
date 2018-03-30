using System;
using System.Collections.Generic;
using Microsoft;
using System.Data.SqlClient;
using System.ComponentModel;
using Q42.HueApi;
using Q42.HueApi.NET;
using Q42.HueApi.Interfaces;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; /*webclient could not be found 오류 해결*/
//using System.Windows;
//using Windows.Data.Xml.Dom;
using System.Xml; /*이걸로 Xmldocument could not be found 오류 해결*/
using static System.Net.WebClient;
using System.Web;
using static System.Net.HttpContinueDelegate;
using System.Net.Http;
//using System.Net.HttpClient;
//using Bunifu.NET;

namespace HUEControl
{
    public partial class Form1 : Form
    {

        ILocalHueClient client= new LocalHueClient("192.168.1.2");

        public Form1()
        {
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var timer = new System.Threading.Timer(a => Bulbs_control(), null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
        }


        private void Bulbs_control()
        {
           /* string L1On = null;
            string L1Bri = null;
            string L1Hue = null;
            string L1Sat = null;

            string L2On = null;
            string L2Bri = null;
            string L2Hue = null;
            string L2Sat = null;

            byte L1BriInt = 0;
            int L1HueInt = 0;
            int L1SatInt = 0;

            byte L2BriInt = 0;
            int L2HueInt = 0;
            int L2SatInt = 0;

            string NameTemp1 = null;
            bool flag1 = false;*/
            
//            int pos1 = 0;
//            int pos2 = 0;
            client.Initialize("UPPhQCrYBCyczLWhHsDAyRt8yVVY5VdB0kRMaSLN");
           // MessageBox.Show("!");   
            //------------------**********

         /*   string connectionString = "Server=JINJU\\SQLEXPRESS;Integrated security=SSPI;database=" + textBox1.Text;
            //원래는 string connectionString = "Server=MAKSYM\\SQLEXPRESS;Integrated security=SSPI;database=" + textBox1.Text; 이건데..
            //textbox1.text가 오류가뜨네요 >>해결!

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    //
                    // Open the SqlConnection.
                    //
                    con.Open();
                    // MessageBox.Show("Connection Open ! ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Test1. Can not open connection ! " + ex.Message);
                }
                //--------------------------------Read Lines with flag = 1---------------------------------
                using (SqlCommand cmd = new SqlCommand("select * from PersonID where flag = 1", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            L1On = reader["L1On"].ToString();
                            L1Bri = reader["L1Br"].ToString();
                            L1Hue = reader["L1Hue"].ToString();
                            L1Sat = reader["L1Sat"].ToString();

                            L2On = reader["L2On"].ToString();
                            L2Bri = reader["L2Br"].ToString();
                            L2Hue = reader["L2Hue"].ToString();
                            L2Sat = reader["L2Sat"].ToString();

                            NameTemp1 = reader["Name"].ToString();
                            flag1 = true;

                             //MessageBox.Show("Hier:" + L1On + L1Bri + L1Hue + L1Sat);                                                        
                        }
                    }                   
                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (flag1)
                {
                    //con.Close();
                    con.Open();
                    using (SqlCommand cmd1 = new SqlCommand("UPDATE PersonID SET flag = 0 WHERE Name = @Name", con))//, @ID, @Name, @LEyeOutcorner, @REyeOutcorner, @NoseTip, @NoseBottomL, @NoseBottomR, @ForeheadCenter)", con))
                    {
                        cmd1.Parameters.Clear();
                        cmd1.Parameters.AddWithValue("@Name", NameTemp1);

                        cmd1.ExecuteNonQuery(); // execute SQL
                        //MessageBox.Show("Person has been added! ");
                    }
                    //using (SqlCommand cmd1 = new SqlCommand("UPDATE PersonID SET flag = 1 WHERE Name = 0", con))
                    flag1 = false;
                    con.Close();
                }

            }          
            
            var command = new LightCommand();
            //command.Brightness = 21;
            
            if (L1On == "on ")
            {
               // MessageBox.Show("On!" + L1On);
                command.On = true;
                Byte.TryParse(L1Bri, out L1BriInt);
                command.Brightness = L1BriInt;
                //MessageBox.Show("" + command.Brightness);
                Int32.TryParse(L1Hue, out L1HueInt);
                command.Hue = L1HueInt;
                Int32.TryParse(L1Sat, out L1SatInt);
                command.Saturation = L1SatInt;
                client.SendCommandAsync(command, new List<string> { "1" });
            }
            if (L2On == "on ")
            {
                command.On = true;
                Byte.TryParse(L2Bri, out L2BriInt);
                command.Brightness = L2BriInt;
                Int32.TryParse(L2Hue, out L2HueInt);
                command.Hue = L2HueInt;
                Int32.TryParse(L2Sat, out L2SatInt);
                command.Saturation = L2SatInt;
                client.SendCommandAsync(command, new List<string> { "2" });
            }   */     
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            string time = DateTime.Now.ToString("HH");

            label1.Text = "Current Time is: " + DateTime.Now.ToString("HH") +"  H";

            if (time == "00" || time == "01" || time == "02" || time == "03")
            {
                var command = new LightCommand();
                command.TurnOff(); //okay
                //command.On = false;
                client.SendCommandAsync(command);
            }

            else if (time == "04" || time == "05" || time == "06" || time == "07") 
            {
                var command = new LightCommand();
                command.TurnOn().SetColor("BC8F8F"); // okay 로즈빛
                command.Brightness = 128;
                client.SendCommandAsync(command);
            }

            else if (time == "08" || time == "09" || time == "10" || time == "11")
            {
                var command = new LightCommand();
                command.TurnOn().SetColor("FF0000"); //okay 홍시빛
                command.Brightness = 128;
                client.SendCommandAsync(command);
            }

            else if (time == "12" || time == "13" || time == "14" || time == "15")
            {
                var command = new LightCommand();
                command.TurnOn().SetColor("800000"); //okay 새빨간빛
                command.Brightness = 128;
                client.SendCommandAsync(command);
            }

            else if (time == "16" || time == "17" || time == "18" || time == "19")
            {
                var command = new LightCommand();
                command.TurnOn().SetColor("FF00DD"); //okay 자주빛
                command.Brightness = 128;
                client.SendCommandAsync(command);
            }

            else
            {
                var command = new LightCommand();
                command.TurnOn().SetColor("0054FF"); // okay 푸르스름 보라빛
                command.Brightness = 128;
                client.SendCommandAsync(command);
           
            }


        }

        private  void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button6_Click_1(object sender, EventArgs e) //처음에 안됐던 이유는 double click을 하지 않아서 였다.
        {

             string weburl = "http://api.openweathermap.org/data/2.5/weather?q=" + textBox1.Text + "&mode=xml&units=imperial&APPID=15c1625f8d2317f825b8aada51d5dd9d";
             //&mode=xml&untis에서 끝내면 안되고, 위 url에서 얻은 내 key를 같이 입력해야 한다. 
             //var client = new System.Net.WebClient();
             var xml = await new WebClient().DownloadStringTaskAsync(new Uri(weburl));

             XmlDocument doc = new XmlDocument();
             doc.LoadXml(xml);
             string szTemp = doc.DocumentElement.SelectSingleNode("temperature").Attributes["value"].Value;
             double temp = (double.Parse(szTemp) - 32) * 5 / 9; //fernheit를 celcius로 바꾸기

             label1.Text = "Current temperature of this city is " + "'"+ temp.ToString("N1") +"'"+ " celcius."; 


            double degree = temp;
            if (degree >= 20 && degree <30)
            {
                MessageBox.Show("hot");
                var command = new LightCommand();
                //command.TurnOn().SetColor("FFBB00"); //20도이상은 주황불
                command.Brightness = 128;
                var result = await client.SendCommandAsync(command);
            }
            else if (degree >= 10 && degree < 20)
            {
                MessageBox.Show("cool");
                var command = new LightCommand();
                 command.TurnOn().SetColor("0054FF"); //10도 이상은 파란불
                 command.Brightness = 128;
                var result = await client.SendCommandAsync(command); 
            }
            else if (degree >= 0 && degree < 10)
            {
                MessageBox.Show("cold");
                var command = new LightCommand();
                command.TurnOn().SetColor("FF00DD"); //0도 이상은 보라불
                command.Brightness = 128;
                var result = await client.SendCommandAsync(command); 
            }
            else if (degree >= 30)
            {
                MessageBox.Show("very hot");
                var command = new LightCommand();
                command.TurnOn().SetColor("FF0000"); //30도 이상은 빨간불
                command.Brightness = 128;
                var result = await client.SendCommandAsync(command); 
            }
            else
            {
                MessageBox.Show("very cold");
                var command = new LightCommand();
                command.TurnOn().SetColor("CACACA"); //영하는 회색불
                command.Brightness = 128;
                var result = await client.SendCommandAsync(command);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var command = new LightCommand();
            command.TurnOn().SetColor("CACACA");
            command.Brightness = 128;
            client.SendCommandAsync(command);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var command = new LightCommand();
            command.TurnOff();
            client.SendCommandAsync(command);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }

       
    }

