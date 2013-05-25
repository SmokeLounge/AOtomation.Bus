// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBusAdapter.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IBusAdapter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Bus
{
    using System;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(IBusAdapterContract))]
    public interface IBusAdapter
    {
        #region Public Methods and Operators

        IChannel CreateChannel(string channelId);

        #endregion
    }

    [ContractClassFor(typeof(IBusAdapter))]
    internal abstract class IBusAdapterContract : IBusAdapter
    {
        #region Public Methods and Operators

        public IChannel CreateChannel(string channelId)
        {
            Contract.Requires<ArgumentNullException>(channelId != null);
            Contract.Ensures(Contract.Result<IChannel>() != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}