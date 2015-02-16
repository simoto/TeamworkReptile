﻿namespace TeamWorkGame.Interfaces
{
    using System;

    public interface IUserInterface
    {
        event EventHandler OnLeftPressed;

        event EventHandler OnRightPressed;

        event EventHandler OnActionPressed;

        void ProcessInput();
    }
}