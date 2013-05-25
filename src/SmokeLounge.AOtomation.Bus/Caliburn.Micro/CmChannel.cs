// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CmChannel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CmChannel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Bus.Caliburn.Micro
{
    using System;
    using System.Diagnostics.Contracts;

    using global::Caliburn.Micro;

    public class CmChannel : IChannel
    {
        #region Fields

        private readonly IEventAggregator eventAggregator;

        private readonly string id;

        #endregion

        #region Constructors and Destructors

        public CmChannel(string id, IEventAggregator eventAggregator)
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Requires<ArgumentNullException>(eventAggregator != null);

            this.id = id;
            this.eventAggregator = eventAggregator;
        }

        #endregion

        #region Public Properties

        public string Id
        {
            get
            {
                return this.id;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Publish(object message)
        {
            this.eventAggregator.Publish(message);
        }

        public void Subscribe(object instance)
        {
            this.eventAggregator.Subscribe(instance);
        }

        public void Unsubscribe(object instance)
        {
            this.eventAggregator.Unsubscribe(instance);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.eventAggregator != null);
            Contract.Invariant(this.id != null);
        }

        #endregion
    }
}