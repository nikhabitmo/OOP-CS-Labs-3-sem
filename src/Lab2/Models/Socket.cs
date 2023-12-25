namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Socket
{
    public Socket(string? socketType = null, string? socketName = null)
    {
        SocketType = socketType;
        SocketName = socketName;
    }

    public string? SocketType { get; private set; }

    public string? SocketName { get; private set; }

    public static bool operator ==(Socket? socket1, Socket? socket2)
    {
        if (socket1 is null && socket2 is null) return true;
        if (socket1 is null || socket2 is null) return false;
        return socket1.SocketType == socket2.SocketType && socket1.SocketName == socket2.SocketName;
    }

    public static bool operator !=(Socket socket1, Socket socket2)
    {
        return !(socket1 == socket2);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var otherSocket = (Socket)obj;
        return this == otherSocket;
    }

    public override int GetHashCode()
    {
        return (SocketType, SocketName).GetHashCode();
    }

    public Socket Clone()
    {
        return new Socket(SocketType, SocketName);
    }
}