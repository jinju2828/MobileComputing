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
namespace HUEControl
{
    public partial class Form2 : Form
    {
        ILocalHueClient client = new LocalHueClient("192.168.1.2");

        public Form2()
        {
            InitializeComponent();
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

           /* string connectionString = "Server=JINJU\\SQLEXPRESS;Integrated security=SSPI;database=" ;
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
                    MessageBox.Show("Can not open connection ! " + ex.Message);
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
            } */
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            var command = new LightCommand();
            command.TurnOn().SetColor("CACACA");
            command.Brightness = 128;
            client.SendCommandAsync(command);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            var command = new LightCommand();
            command.TurnOff();
            client.SendCommandAsync(command);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var timer = new System.Threading.Timer(a => Bulbs_control(), null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            var command = new LightCommand();
            command.TransitionTime = TimeSpan.FromMilliseconds(1000);
            command.TurnOn().SetColor("90ee90");
            command.Brightness = 100;
            client.SendCommandAsync(command);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            var command = new LightCommand();
            command.TransitionTime = TimeSpan.FromMilliseconds(1000);
            command.TurnOn().SetColor("000080");
            command.Brightness = 100;
            client.SendCommandAsync(command);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            var command = new LightCommand();
            command.TurnOff();
            client.SendCommandAsync(command);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            var command = new LightCommand();
            command.TransitionTime = TimeSpan.FromMilliseconds(1000);
            command.TurnOn().SetColor("ffdab9");
            command.Brightness = 60;
            client.SendCommandAsync(command);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            while (true)
            {
                
                var command = new LightCommand();
           
                command.TurnOn().SetColor("ff7f50");
                command.Alert = Alert.Once;
                command.Brightness = 128;
                client.SendCommandAsync(command);
                System.Threading.Thread.Sleep(10);
                command.TurnOn().SetColor("ffb6c1");
                command.Alert = Alert.Once;
                command.Brightness = 128;
                client.SendCommandAsync(command);
                System.Threading.Thread.Sleep(10);
                command.TurnOn().SetColor("ffbb00");
                command.Alert = Alert.Once;
                command.Brightness = 128;
                client.SendCommandAsync(command);
                System.Threading.Thread.Sleep(10);
                command.TurnOn().SetColor("800000");
                command.Alert = Alert.Once;
                command.Brightness = 128;
                client.SendCommandAsync(command);
                System.Threading.Thread.Sleep(10);
                command.TurnOn().SetColor("808000");
                command.Alert = Alert.Once;
                command.Brightness = 128;
                client.SendCommandAsync(command);
                System.Threading.Thread.Sleep(10);
                command.TurnOn().SetColor("1e90ff");
                command.Alert = Alert.Once;
                command.Brightness = 128;
                client.SendCommandAsync(command);
                System.Threading.Thread.Sleep(10);

            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            var command = new LightCommand();
            command.TransitionTime = TimeSpan.FromMilliseconds(1000);
            command.TurnOn().SetColor("ff7f50");
            command.Brightness = 128;
            client.SendCommandAsync(command);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            var command = new LightCommand();
            command.TransitionTime = TimeSpan.FromMilliseconds(1000);
            command.TurnOn().SetColor("ffb6c1");
            command.Brightness = 100;
            client.SendCommandAsync(command);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            var command = new LightCommand();
            command.TransitionTime = TimeSpan.FromMilliseconds(1000);
            command.TurnOn().SetColor("cd5c5c");
            command.Brightness = 100;
            client.SendCommandAsync(command);
        }
    }
}
