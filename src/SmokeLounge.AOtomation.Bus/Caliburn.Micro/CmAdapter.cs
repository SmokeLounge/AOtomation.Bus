// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CmAdapter.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CmAdapter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Bus.Caliburn.Micro
{
    public class CmAdapter : IBusAdapter
    {
        #region Fields

        private readonly CmChannelFactory cmChannelFactory;

        #endregion

        #region Constructors and Destructors

        public CmAdapter()
        {
            this.cmChannelFactory = new CmChannelFactory();
        }

        #endregion

        #region Public Methods and Operators

        public IChannel CreateChannel(string channelId)
        {
            return this.cmChannelFactory.Create(channelId);
        }

        #endregion
    }
}