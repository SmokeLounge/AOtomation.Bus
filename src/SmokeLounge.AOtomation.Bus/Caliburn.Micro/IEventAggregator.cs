// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEventAggregator.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Enables loosely-coupled publication of and subscription to events.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Caliburn.Micro
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AOtomation.Bus;

    /// <summary>
    ///     Enables loosely-coupled publication of and subscription to events.
    /// </summary>
    [ContractClass(typeof(IEventAggregatorContract))]
    public interface IEventAggregator
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the default publication thread marshaller.
        /// </summary>
        /// <value>
        ///     The default publication thread marshaller.
        /// </value>
        Action<Action> PublicationThreadMarshaller { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Publishes a message.
        /// </summary>
        /// <param name="message">
        /// The message instance.
        /// </param>
        /// <remarks>
        /// Uses the default thread marshaller during publication.
        /// </remarks>
        void Publish(object message);

        /// <summary>
        /// Publishes a message.
        /// </summary>
        /// <param name="message">
        /// The message instance.
        /// </param>
        /// <param name="marshal">
        /// Allows the publisher to provide a custom thread marshaller for the message publication.
        /// </param>
        void Publish(object message, Action<Action> marshal);

        /// <summary>
        /// Subscribes an instance to all events declared through implementations of <see cref="IHandleMessage{T}"/>
        /// </summary>
        /// <param name="instance">
        /// The instance to subscribe for event publication.
        /// </param>
        void Subscribe(object instance);

        /// <summary>
        /// Unsubscribes the instance from all events.
        /// </summary>
        /// <param name="instance">
        /// The instance to unsubscribe.
        /// </param>
        void Unsubscribe(object instance);

        #endregion
    }

    [ContractClassFor(typeof(IEventAggregator))]
    internal abstract class IEventAggregatorContract : IEventAggregator
    {
        #region Public Properties

        public Action<Action> PublicationThreadMarshaller
        {
            get
            {
                Contract.Ensures(Contract.Result<Action<Action>>() != null);

                throw new NotImplementedException();
            }

            set
            {
                Contract.Requires<ArgumentNullException>(value != null);

                throw new NotImplementedException();
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Publish(object message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            throw new NotImplementedException();
        }

        public void Publish(object message, Action<Action> marshal)
        {
            Contract.Requires<ArgumentNullException>(message != null);
            Contract.Requires<ArgumentNullException>(marshal != null);

            throw new NotImplementedException();
        }

        public void Subscribe(object instance)
        {
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