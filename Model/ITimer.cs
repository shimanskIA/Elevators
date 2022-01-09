using System;

namespace Model
{
    public interface ITimer
    {
        event EventHandler Tick;

        bool Enabled { get; set; }
        int Interval { get; set; }

        void Start();
        void Stop();
    }
}

