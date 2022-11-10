using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;

class Program
{
    private const string host = "127.0.0.1";
    private const int port = 8888;
    static TcpClient client;
    static NetworkStream stream;

    static void Main(string[] args)
    {
        Console.WriteLine("Введите матрицу: ");
        string matrix = Console.ReadLine();
        Console.WriteLine("Введите вектор: ");
        string vector = Console.ReadLine();
        client = new TcpClient();
        try
        {
            client.Connect(host, port); //подключение клиента
            stream = client.GetStream(); // получаем поток

            string message = matrix + "\n"+vector;
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);

            Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
            receiveThread.Start(); //старт потока
            Console.WriteLine("Добро пожаловать!");
            matrix = "";
            vector = "";
            SendMessage();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Disconnect();
        }
    }
    // отправка сообщений
    static void SendMessage()
    {
        Console.WriteLine("Ваш результат");
        Console.ReadLine();
        Console.WriteLine("Введите матрицу: ");
        string matrix = Console.ReadLine();
        Console.WriteLine("Введите вектор: ");
        string vector = Console.ReadLine();

        while (true)
        {
            string message = matrix +"\n" + vector;
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
    }
    // получение сообщений
    static void ReceiveMessage()
    {
        while (true)
        {
            try
            {
                byte[] data = new byte[64]; // буфер для получаемых данных
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);

                string message = builder.ToString();
                Console.WriteLine(message);//вывод сообщения
            }
            catch
            {
                Console.WriteLine("Подключение прервано!"); //соединение было прервано
                Console.ReadLine();
                Disconnect();
            }
        }
    }

    static void Disconnect()
    {
        if (stream != null)
            stream.Close();//отключение потока
        if (client != null)
            client.Close();//отключение клиента
        Environment.Exit(0); //завершение процесса
    }
}