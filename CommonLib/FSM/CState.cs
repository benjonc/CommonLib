using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.FSM
{
    public delegate void CVoidDelegate();
    public delegate void CVoidDelegateState(IState state);
    public delegate void CVoidDelegateFloat(float f);

    public class CState : IState
    {
        public event CVoidDelegateState OnEnter;
        public event CVoidDelegateState OnExit;
        public event CVoidDelegateFloat OnUpdate;
        public event CVoidDelegateFloat OnLateUpdate;
        public event CVoidDelegate OnFixedUpdate;

        public string Name
        {
            get { return _name; }
        }

        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        public IStateMechine Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public float Timer
        {
            get { return _timer; }
        }

        public List<ITransition> Transitions
        {
            get { return _transitions; }
        }

        public CState(string name)
        {
            _name = name;

        }

        public void AddTransition(ITransition t)
        {
            if(t != null && !_transitions.Contains(t))
            {
                _transitions.Add(t);
            }
        }

        public virtual void EnterCallback(IState prev)
        {
            _timer = 0;
            if (OnEnter != null)
            {
                OnEnter(prev);
            }
        }

        public virtual void ExitCallback(IState next)
        {
            if(OnExit != null)
            {
                OnExit(next);
            }
            _timer = 0;
        }

        public virtual void UpdateCallback(float deltaTime)
        {
            _timer += deltaTime;
            if (OnUpdate != null)
            {
                OnUpdate(deltaTime);
            }
        }

        public virtual void LateUpdateCallback(float deltaTime)
        {
            if (OnLateUpdate != null)
            {
                OnLateUpdate(deltaTime);
            }
        }

        public virtual void FixedUpdateCallback()
        {
            if(OnFixedUpdate != null)
            {
                OnFixedUpdate();
            }
        }

        private string _name, _tag;
        private IStateMechine _parent;
        private float _timer;
        private List<ITransition> _transitions;
    }
}
