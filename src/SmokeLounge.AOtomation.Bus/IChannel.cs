// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IChannel.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IChannel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Bus
{
    public interface IChannel
    {
        #region Public Properties

        string Id { get; }

        #endregion

        #region Public Methods and Operators

        void Publish(object message);

        void Subscribe(object instance);

        void Unsubscribe(object instance);

        #endregion
    }
}