using System.Net;
using System.IO;
using RestSharp.Authenticators;
using RestSharp;


namespace EZtranslate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public async void button1_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =
    {
        { "x-rapidapi-host", "google-translate1.p.rapidapi.com" },
        { "x-rapidapi-key", "8d477c3a60msh209f98ad40efe94p1fd16ajsn22799631e9cd" },
    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "source", "rus" },
        { "target", "en" },
        { "q", textBox1.Text },
    }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();
                //  Console.WriteLine(body);
                textBox2.Text = body;
            }

        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}