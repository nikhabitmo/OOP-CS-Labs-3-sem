// using Itmo.ObjectOrientedProgramming.Lab3.Entities.Recipient;
// using Itmo.ObjectOrientedProgramming.Lab3.Models;
// using Microsoft.Extensions.Logging;
//
// namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;
//
// public class DisplayBuilder : IDisplayBuilder
// {
//     private Priority _priority;
//     private ILogger<DisplayRecipient> _logger;
//     private IDisplayDecorator _displayDriver = new DisplayDriver();
//
//     public DisplayBuilder()
//     {
//         var loggerFactory = new LoggerFactory();
//         _logger = loggerFactory.CreateLogger<DisplayRecipient>();
//         loggerFactory.Dispose();
//     }
//
//     public DisplayBuilder(Priority priority, ILogger<DisplayRecipient> logger)
//     {
//         _priority = priority;
//         _logger = logger;
//     }
//
//     public IReceiverBuilder WithPriority(Priority priority)
//     {
//         _priority = priority;
//         return this;
//     }
//
//     public IDisplayBuilder WithDisplayDriver(IDisplayDecorator displayDriver)
//     {
//         _displayDriver = displayDriver;
//         return this;
//     }
//
//     public IRecipient Build()
//     {
//         return new DisplayRecipient(_priority, _logger, _displayDriver);
//     }
// }