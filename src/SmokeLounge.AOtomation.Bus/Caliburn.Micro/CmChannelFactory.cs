// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CmChannelFactory.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CmChannelFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Bus.Caliburn.Micro
{
    using global::Caliburn.Micro;

    public class CmChannelFactory : IChannelFactory
    {
        #region Public Methods and Operators

        public IChannel Create(string channelId)
        {
            return new CmChannel(channelId, new EventAggregator());
        }

        #endregion
    }
}