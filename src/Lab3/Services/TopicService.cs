using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class TopicService
{
    public TopicService(IList<Topic> topics)
    {
        Topics = topics;
    }

    public IList<Topic> Topics { get; private set; } = new List<Topic>();
}