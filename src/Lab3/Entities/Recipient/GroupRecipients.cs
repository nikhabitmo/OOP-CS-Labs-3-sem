using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
public class GroupRecipients : IRecipient
{
    private List<IRecipient> recipients = new List<IRecipient>();

    public void AddRecipient(IRecipient recipient)
    {
        recipients.Add(recipient);
    }

    public StatusReceivingMessage ReceiveMessage(IMessage? message)
    {
        foreach (IRecipient recipient in recipients)
        {
            recipient.ReceiveMessage(message);
        }

        return StatusReceivingMessage.Ok;
    }
}
