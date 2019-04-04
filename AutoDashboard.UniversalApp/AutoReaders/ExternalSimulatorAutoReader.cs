using AutoDashboard.UniversalApp.Models;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AutoDashboard.UniversalApp.AutoReaders
{
    public class ExternalSimulatorAutoReader : IAutoReader
    {
        public Task<T> Get<T>() where T : IAutoReading
        {
            return Task.FromResult(default(T));
        }

        public static async Task<string> Ping(string data)
        {
            var client = new TcpClient("127.0.0.1", 8088);
            var nwStream = client.GetStream();
            var bytesToSend = Encoding.ASCII.GetBytes(data);
            await nwStream.WriteAsync(bytesToSend, 0, bytesToSend.Length);

            var bytesToRead = new byte[client.ReceiveBufferSize];
            var bytesRead = await nwStream.ReadAsync(bytesToRead, 0, client.ReceiveBufferSize);
            var output = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);

            client.Close();
            return output;
        }
    }
}
