using System;
using System.Collections.Generic;
using System.Text;

namespace GameBall
{
    public interface IMove
    {
        void Move(Boardforball boardforball, Gridforball gridforball);
    }
}
