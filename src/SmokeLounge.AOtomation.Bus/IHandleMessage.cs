// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHandleMessage.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IHandleMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AOtomation.Bus
{
    using System;
    using System.Diagnostics.Contracts;

    public interface IHandleMessage
    {
    }

    [ContractClass(typeof(IHandleMessageContract<>))]
    public interface IHandleMessage<T> : IHandleMessage
        where T : class
    {
        #region Public Methods and Operators

        void Handle(T message);

        #endregion
    }

    [ContractClassFor(typeof(IHandleMessage<>))]
    internal abstract class IHandleMessageContract<T> : IHandleMessage<T>
        where T : class
    {
        #region Public Methods and Operators

        public void Handle(T message)
        {
            Contract.Requires<ArgumentNullException>(message != null);

            throw new NotImplementedException();
        }

        #endregion
    }
}