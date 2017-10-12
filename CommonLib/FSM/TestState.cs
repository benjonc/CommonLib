using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLib.FSM;


public class TestState : CState
{
    public TestState() : base("TestState")
    {

    }

    public override void EnterCallback(IState prev)
    {
        base.EnterCallback(prev);

    }

    public override void ExitCallback(IState next)
    {
        base.ExitCallback(next);

    }

    public override void UpdateCallback(float deltaTime)
    {
        base.UpdateCallback(deltaTime);

    }

}

