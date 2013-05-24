// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bus.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the Bus type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Bus
{
    using System.Collections.Concurrent;

    public class Bus : IBus
    {
        #region Fields

        private readonly IBusAdapter busAdapter;

        private readonly ConcurrentDictionary<string, IChannel> channels;

        private readonly IChannel generalChannel;

        #endregion

        #region Constructors and Destructors

        public Bus(IBusAdapter busAdapter)
        {
            this.busAdapter = busAdapter;
            this.channels = new ConcurrentDictionary<string, IChannel>();
            this.generalChannel = this.busAdapter.CreateChannel(string.Empty);
        }

        #endregion

        #region Public Methods and Operators

        public void Publish(string channelId, object message)
        {
            IChannel channel;
            if (!this.channels.TryGetValue(channelId, out channel))
            {
                return;
            }

            channel.Publish(message);
        }

        public void Publish(object message)
        {
            this.generalChannel.Publish(message);
            foreach (var channel in this.channels.Values)
            {
                channel.Publish(message);
            }
        }

        public void Subscribe(string channelId, object instance)
        {
            var channel = this.channels.GetOrAdd(channelId, newChannelId => this.busAdapter.CreateChannel(newChannelId));
            channel.Subscribe(instance);
        }

        public void Subscribe(object instance)
        {
            this.generalChannel.Subscribe(instance);
            foreach (var channel in this.channels.Values)
            {
                channel.Subscribe(instance);
            }
        }

        public void Unsubscribe(string channelId, object instance)
        {
            IChannel channel;
            if (this.channels.TryGetValue(channelId, out channel))
            {
                channel.Unsubscribe(instance);
            }
        }

        public void Unsubscribe(object instance)
        {
            this.generalChannel.Unsubscribe(instance);
            foreach (var channel in this.channels.Values)
            {
                channel.Unsubscribe(instance);
            }
        }

        #endregion
    }
}