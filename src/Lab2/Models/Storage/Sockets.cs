using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Storage;

public class Sockets
{
    public Sockets()
    {
        AvailableSockets.Add(new Socket("LGA 1851", "Intel V1"));
        AvailableSockets.Add(new Socket("LGA 1700", "Intel V"));
        AvailableSockets.Add(new Socket("LGA 1200", "Intel H5"));
        AvailableSockets.Add(new Socket("LGA 2066", "Intel R4"));
        AvailableSockets.Add(new Socket("LGA 1151", "Intel H4"));
        AvailableSockets.Add(new Socket("AM4", "AMDAM4"));
        AvailableSockets.Add(new Socket("TR4", "AMDTR4"));
        AvailableSockets.Add(new Socket("sTRX4", "AMDsTRX4"));
        AvailableSockets.Add(new Socket("sWRX8", "AMDsWRX8"));
        AvailableSockets.Add(new Socket("AM5", "AMDAM5"));
    }

    public ICollection<Socket> AvailableSockets { get; } = new List<Socket>();

    public void AddSocket(Socket socket)
    {
        AvailableSockets.Add(socket);
    }

    public Socket? FindSocketByName(string socketName)
    {
        return AvailableSockets.FirstOrDefault(socket => socket.SocketName == socketName);
    }
}