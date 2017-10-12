using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.FSM
{
    public class CStateMechine : CState, IStateMechine
    {
        public IState CurState
        {
            get { return _curState; }
        }

        public IState DefaultState
        {
            get { return _defaultState; }
            set
            {
                if(!_states.Contains(value))
                {
                    AddState(value);
                }
                _defaultState = value;
            }
        }

        public CStateMechine(string name, IState defaultState) : base(name)
        {
            _states = new List<IState>();
            _defaultState = defaultState;
        }

        public void AddState(IState state)
        {
            if(state != null && !_states.Contains(state))
            {
                _states.Add(state);
                state.Parent = this;
                if(_defaultState == null)
                {
                    _defaultState = state;
                }
            }
        }

        public void RemoveState(IState state)
        {
            if(_curState == state)
            {
                return;
            }
            if (state != null && _states.Contains(state))
            {
                _states.Remove(state);
                state.Parent = null;
                if(_defaultState == state)
                {
                    _defaultState = _states.Count > 0 ? _states[1] : null;
                }
            }
        }

        public override void UpdateCallback(float deltaTime)
        {
            if(_isTransition)
            {
                if(_t.TransitionCallback())
                {
                    DoTransition(_t);
                    _isTransition = false;
                }
                return;
            }

            base.UpdateCallback(deltaTime);

            if(_curState == null)
            {
                _curState = _defaultState;
            }

            var ts = _curState.Transitions;
            int count = ts.Count;
            for(int i = 0; i < count; i++)
            {
                var t = ts[i];
                if(t.ShouldBegin())
                {
                    _isTransition = true;
                    _t = t;
                    return;
                }
            }

            _curState.UpdateCallback(deltaTime);
        }

        public override void LateUpdateCallback(float deltaTime)
        {
            base.LateUpdateCallback(deltaTime);

            _curState.LateUpdateCallback(deltaTime);
        }

        public override void FixedUpdateCallback()
        {
            base.FixedUpdateCallback();

            _curState.FixedUpdateCallback();
        }


        public IState GetStateWithName(string name)
        {
            foreach(var s in _states)
            {
                if(s.Name == name)
                {
                    return s;
                }
            }

            return null;
        }

        public IState GetStateWithTag(string tag)
        {
            foreach(var s in _states)
            {
                if(s.Tag == tag)
                {
                    return s;
                }
            }
            return null;
        }       

        private IState _curState, _defaultState;
        private List<IState> _states;

        // 是否进行过渡            
        private bool _isTransition = false;
        // 当前正在进行的过渡
        private ITransition _t;

        /// <summary>
        /// 开始进行过渡
        /// </summary>
        private void DoTransition(ITransition t)
        {
            _curState.ExitCallback(t.To);
            _curState = t.To;
            _curState.EnterCallback(t.From);
        }
    }
}
