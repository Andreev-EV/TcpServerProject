using System.Net.Sockets;
using System.Net;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace TcpServerProject
{
    public partial class FormServer : Form
    {

        TcpListener listener = new TcpListener(IPAddress.Loopback, 10001);
        TcpClient? client;

        Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            {"Привет", "Hello" },
            {"Мир", "World" },
            {"Яблоко", "Apple" },
            {"Книга", "Book" },
            {"END", "" }
        };

        public FormServer()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                listener.Start();
                TbServerInput("Server started...");

                while (true)
                {
                    client = await listener.AcceptTcpClientAsync();
                    await Task.Run(async () => await ConnectClientAsync(client));
                }
            }
            finally
            {
                listener.Stop();
            }
        }

        async Task ConnectClientAsync(TcpClient client)
        {
            var stream = client.GetStream();
            var bufferResponse = new List<byte>();
            int bufferByte;

            while (true)
            {
                while ((bufferByte = stream.ReadByte()) != '\n')
                    bufferResponse.Add((byte)bufferByte);
                var response = Encoding.UTF8.GetString(bufferResponse.ToArray());
                if (response == "END")
                {
                    bufferResponse.Clear();
                    break;
                }
                if(dictionary.ContainsKey(response))
                {
                    Invoke((Action<string>)TbServerInput, $"Запрос по задачи с ID - {Task.CurrentId}:" + $" Какой перевод слова \"{response}\"?");
                    Invoke((Action<string>)TbServerInput, $"Server: Перевод слова \"{response}\": {dictionary[response]}");
                }
                else
                {
                    Invoke((Action<string>)TbServerInput, $"Запрос по задачи с ID - {Task.CurrentId}. " + $"Перевод для слова \"{response}\" не найден.");
                }

                await stream.WriteAsync(Encoding.UTF8.GetBytes(dictionary[response] + "\n"));
                bufferResponse.Clear();
            }

            client.Close();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            client?.Close();
            Invoke((Action<string>)TbServerInput, "Server stoped");
        }

        private void FormServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(client != null)
            {
                client.Close();
            }
        }

        public void TbServerInput(string str)
        {
                tbServer.Text += Environment.NewLine + DateTime.Now.ToShortDateString() + " " + 
                                 DateTime.Now.ToLongTimeString() + ":\t" + str;
        }
    }
}