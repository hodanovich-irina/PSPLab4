using Lab4;
class Program
{

    static ServerObject server; // сервер
    static Thread listenThread; // потока для прослушивания
    static void Main(string[] args)
    {
        try
        {
            server = new ServerObject();
            var x = ThreadPool.QueueUserWorkItem(new WaitCallback((x)=>server.Listen()));
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            server.Disconnect();
            Console.WriteLine(ex.Message);
        }
    }
}