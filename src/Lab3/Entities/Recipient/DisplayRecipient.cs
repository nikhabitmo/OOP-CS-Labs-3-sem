using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
public class DisplayRecipient : IRecipient
{
    private readonly Display.Display _display;

    public DisplayRecipient(Display.Display display)
    {
        _display = display;
    }

    public ConsoleColor Color { get; set; } = ConsoleColor.White;

    public StatusReceivingMessage ReceiveMessage(IMessage? message)
    {
        if (message == null)
        {
            return StatusReceivingMessage.Error;
        }

        ConsoleColor textColor = Color;

        _display.ShowMessage($"{message.Head}: {message.Body}", textColor);

        return StatusReceivingMessage.Ok;
    }
}