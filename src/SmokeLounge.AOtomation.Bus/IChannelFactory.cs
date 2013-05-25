// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IChannelFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IChannelFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Bus
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IChannelFactoryContract))]
    public interface IChannelFactory
    {
        #region Public Methods and Operators

        IChannel Create(string channelId);

        #endregion
    }

    [ContractClassFor(typeof(IChannelFactory))]
    internal abstract class IChannelFactoryContract : IChannelFactory
    {
        #region Public Methods and Operators

        public IChannel Create(string channelId)
        {
            Contract.Requires<ArgumentNullException>(channelId != null);
            Contract.Ensures(Contract.Result<IChannel>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}