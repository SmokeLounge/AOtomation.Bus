// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventAggregator.cs" company="SmokeLounge">
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
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Reflection;

    using SmokeLounge.AOtomation.Bus;

    /// <summary>
    ///     Enables loosely-coupled publication of and subscription to events.
    /// </summary>
    public class EventAggregator : IEventAggregator
    {
        #region Static Fields

        /// <summary>
        ///     The default thread marshaller used for publication;
        /// </summary>
        public static Action<Action> DefaultPublicationThreadMarshaller = action => action();

        /// <summary>
        ///     Processing of handler results on publication thread.
        /// </summary>
        public static Action<object, object> HandlerResultProcessing = (target, result) => { };

        #endregion

        #region Fields

        private readonly List<Handler> handlers = new List<Handler>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventAggregator" /> class.
        /// </summary>
        public EventAggregator()
        {
            this.PublicationThreadMarshaller = DefaultPublicationThreadMarshaller;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the default publication thread marshaller.
        /// </summary>
        /// <value>
        ///     The default publication thread marshaller.
        /// </value>
        public Action<Action> PublicationThreadMarshaller { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Publishes a message.
        /// </summary>
        /// <param name="message">
        /// The message instance.
        /// </param>
        /// <remarks>
        /// Does not marshall the the publication to any special thread by default.
        /// </remarks>
        public virtual void Publish(object message)
        {
            this.Publish(message, this.PublicationThreadMarshaller);
        }

        /// <summary>
        /// Publishes a message.
        /// </summary>
        /// <param name="message">
        /// The message instance.
        /// </param>
        /// <param name="marshal">
        /// Allows the publisher to provide a custom thread marshaller for the message publication.
        /// </param>
        public virtual void Publish(object message, Action<Action> marshal)
        {
            Handler[] toNotify;
            lock (this.handlers)
            {
                toNotify = this.handlers.ToArray();
            }

            marshal(
                () =>
                    {
                        var messageType = message.GetType();

                        var dead = toNotify.Where(handler => !handler.Handle(messageType, message)).ToList();

                        if (dead.Any())
                        {
                            lock (this.handlers)
                            {
                                foreach (var handler in dead)
                                {
                                    this.handlers.Remove(handler);
                                }
                            }
                        }
                    });
        }

        /// <summary>
        /// Subscribes an instance to all events declared through implementations of <see cref="IHandleMessage{T}"/>
        /// </summary>
        /// <param name="instance">
        /// The instance to subscribe for event publication.
        /// </param>
        public virtual void Subscribe(object instance)
        {
            lock (this.handlers)
            {
                if (this.handlers.Any(x => x.Matches(instance)))
                {
                    return;
                }

                this.handlers.Add(new Handler(instance));
            }
        }

        /// <summary>
        /// Unsubscribes the instance from all events.
        /// </summary>
        /// <param name="instance">
        /// The instance to unsubscribe.
        /// </param>
        public virtual void Unsubscribe(object instance)
        {
            lock (this.handlers)
            {
                var found = this.handlers.FirstOrDefault(x => x.Matches(instance));

                if (found != null)
                {
                    this.handlers.Remove(found);
                }
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.handlers != null);
        }

        #endregion

        private class Handler
        {
            #region Fields

            private readonly WeakReference reference;

            private readonly Dictionary<Type, MethodInfo> supportedHandlers = new Dictionary<Type, MethodInfo>();

            #endregion

            #region Constructors and Destructors

            public Handler(object handler)
            {
                Contract.Requires(handler != null);

                this.reference = new WeakReference(handler);

                var interfaces =
                    handler.GetType()
                           .GetInterfaces()
                           .Where(x => typeof(IHandleMessage).IsAssignableFrom(x) && x.IsGenericType);

                foreach (var @interface in interfaces)
                {
                    if (@interface == null)
                    {
                        continue;
                    }

                    var args = @interface.GetGenericArguments();
                    Contract.Assume(args != null);
                    var type = args.FirstOrDefault();
                    if (type == null)
                    {
                        continue;
                    }

                    var method = @interface.GetMethod("Handle");
                    this.supportedHandlers[type] = method;
                }
            }

            #endregion

            #region Public Methods and Operators

            public bool Handle(Type messageType, object message)
            {
                var target = this.reference.Target;
                if (target == null)
                {
                    return false;
                }

                foreach (var pair in this.supportedHandlers)
                {
                    Contract.Assume(pair.Key != null);
                    if (!pair.Key.IsAssignableFrom(messageType))
                    {
                        continue;
                    }

                    Contract.Assume(pair.Value != null);
                    var result = pair.Value.Invoke(target, new[] { message });
                    if (result != null)
                    {
                        HandlerResultProcessing(target, result);
                    }
                }

                return true;
            }

            public bool Matches(object instance)
            {
                return this.reference.Target == instance;
            }

            #endregion

            #region Methods

            [ContractInvariantMethod]
            private void ObjectInvariant()
            {
                Contract.Invariant(this.reference != null);
                Contract.Invariant(this.supportedHandlers != null);
            }

            #endregion
        }
    }
}