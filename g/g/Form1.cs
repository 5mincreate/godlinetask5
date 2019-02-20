using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;


namespace g
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public string url = "https://reqres.in/api/users?page=1";

        private async void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label1.Text = "Статус: Выполнено";
            await LoadAsync();
        }
        private async Task LoadAsync()
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string response;

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                Class c = JsonConvert.DeserializeObject<Class>(response);
                string[] person = {Convert.ToString(c.data[0].first_name)+" "+Convert.ToString(c.data[0].last_name),
                               Convert.ToString(c.data[1].first_name)+" "+Convert.ToString(c.data[1].last_name),
                               Convert.ToString(c.data[2].first_name)+" "+Convert.ToString(c.data[2].last_name)};

                listBox1.Items.AddRange(person);

            }
            catch 
            {
                label1.Text = "Статус: Ошибка загрузки";
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Статус: Загрузка";
            if (url == "https://reqres.in/api/users?page=1")
            {
                listBox1.Items.Clear();
                url = "https://reqres.in/api/users?page=2";
                await LoadAsync();
                button1.Enabled = true;
                label1.Text = "Статус: Выполнено";
            }
            else
            {
                label1.Text = "Статус: Загрузка";
                if (url == "https://reqres.in/api/users?page=2")
                {
                    listBox1.Items.Clear();
                    url = "https://reqres.in/api/users?page=3";
                    await LoadAsync();
                    label1.Text = "Статус: Выполнено";


                }
                else
                {
                    label1.Text = "Статус: Загрузка";
                    if (url == "https://reqres.in/api/users?page=3")
                    {
                        listBox1.Items.Clear();
                        url = "https://reqres.in/api/users?page=4";
                        await LoadAsync();
                        button2.Enabled = false;
                        label1.Text = "Статус: Выполнено";

                    }
                }
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Статус: Загрузка";
            if (url == "https://reqres.in/api/users?page=2")
            {               
                listBox1.Items.Clear();
                url = "https://reqres.in/api/users?page=1";
                await LoadAsync();
                button1.Enabled = false;
                label1.Text = "Статус: Выполнено";
                
                
            }
            else
            {
                label1.Text = "Статус: Загрузка";
                if (url == "https://reqres.in/api/users?page=3")
                {                   
                    listBox1.Items.Clear();
                    url = "https://reqres.in/api/users?page=2";
                    await LoadAsync();
                    label1.Text = "Статус: Выполнено";
                    
                    
                }
                else
                {
                    label1.Text = "Статус: Загрузка";
                    if (url == "https://reqres.in/api/users?page=4")
                    {
                        listBox1.Items.Clear();
                        url = "https://reqres.in/api/users?page=3";
                        await LoadAsync();
                        button2.Enabled = true;
                        label1.Text = "Статус: Выполнено";
                       
                        
                    }
                }
            }
        }

        
    }
}
