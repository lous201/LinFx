﻿using LinFx;
using LinFx.Extensions.EventBus;
using LinFx.Extensions.EventBus.RabbitMQ;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EventBusBuilderExtensions
    {
        public static EventBusOptionsBuilder UseRabbitMQ(
            [NotNull] this EventBusOptionsBuilder optionsBuilder,
            [NotNull] Action<RabbitMqEventBusOptions> optionsAction)
        {
            Check.NotNull(optionsBuilder, nameof(optionsBuilder));
            Check.NotNull(optionsAction, nameof(optionsAction));

            optionsBuilder.Fx.Services.Configure(optionsAction);

            var options = new RabbitMqEventBusOptions();
            optionsAction?.Invoke(options);
            optionsBuilder.Fx.AddRabbitMQ(x =>
            {
                x.Host = options.Host;
                x.UserName = options.UserName;
                x.Password = options.Password;
            });

            optionsBuilder.Fx.Services.AddSingleton<IEventBus, RabbitMqDistributedEventBus>();

            return optionsBuilder;
        }
    }
}
