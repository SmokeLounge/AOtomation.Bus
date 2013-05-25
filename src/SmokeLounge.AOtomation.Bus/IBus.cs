// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBus.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IBus type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Bus
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IBusContract))]
    public interface IBus
    {
        #region Public Methods and Operators

        void Publish(string channelId, object message);

        void Publish(object message);

        void Subscribe(string channelId, object instance);

        void Subscribe(object instance);

        void Unsubscribe(string channelId, object instance);

        void Unsubscribe(object instance);

        #endregion
    }

    [ContractClassFor(typeof(IBus))]
    internal abstract class IBusContract : IBus
    {
        #region Public Methods and Operators

        public void Publish(string channelId, object message)
        {
            Contract.Requires<ArgumentException>(string.IsNullOrWhiteSpace(channelId) == false);
            Contract.Requires<ArgumentNullException>(message != null);

            throw new NotImplementedException();
        }

        public void Publish(object message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            throw new NotImplementedException();
        }

        public void Subscribe(string channelId, object instance)
        {
            Contract.Requires<ArgumentException>(string.IsNullOrWhiteSpace(channelId) == false);
            Contract.Requires<ArgumentNullException>(instance != null);

            throw new NotImplementedException();
        }

        public void Subscribe(object instance)
        {
            Contract.Requires<ArgumentNullException>(instance != null);

            throw new NotImplementedException();
        }

        public void Unsubscribe(string channelId, object instance)
        {
            Contract.Requires<ArgumentException>(string.IsNullOrWhiteSpace(channelId) == false);
            Contract.Requires<ArgumentNullException>(instance != null);

            throw new NotImplementedException();
        }

        public void Unsubscribe(object instance)
        {
            Contract.Requires<ArgumentNullException>(instance != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}