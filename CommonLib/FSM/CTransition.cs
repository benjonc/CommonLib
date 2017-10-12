using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.FSM
{
    public delegate bool CTransitionDelegate();
    public class CTransition : ITransition
    {
        public event CTransitionDelegate OnTransition;
        public event CTransitionDelegate OnCheck;

        public IState From
        {
            get { return _from; }
            set { _from = value; }
        }

        public IState To
        {
            get { return _to; }
            set { _to = value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public CTransition(string name, IState from, IState to)
        {
            _name = name;
            _from = from;
            _to = to;
        }

        public bool TransitionCallback()
        {
            if(OnTransition != null)
            {
                return OnTransition();
            }
            return true;
        }

        public bool ShouldBegin()
        {
            if(OnCheck != null)
            {
                return OnCheck();
            }
            return false;
        }

        private IState _from, _to;
        private string _name;
    }
}
