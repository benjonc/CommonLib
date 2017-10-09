using System;
using System.Collections.Generic;

namespace CommonLib.Event
{
    // todo: 待优化
    //   用内存换参数
    public delegate void VoidDelegate(MyEventArgs args);
    public class MyEventArgs : EventArgs
    {
        // 几种基本类型集合
        private List<int> _intPar;
        private List<bool> _boolPar;
        private List<string> _strPar;
        private List<float> _floatPar;

        public List<int> IntPar { get { return _intPar; } }
        public List<bool> BoolPar { get { return _boolPar; } }
        public List<string> StrPar { get { return _strPar; } }
        public List<float> FloatPar { get { return _floatPar; } }
        public MyEventArgs()
        {
            _intPar = new List<int>();
            _boolPar = new List<bool>();
            _strPar = new List<string>();
            _floatPar = new List<float>();
        }
        public void AddInt(int value)
        {
            _intPar.Add(value);
        }
        public void AddBool(bool value)
        {
            _boolPar.Add(value);
        }
        public void AddFloat(float value)
        {
            _floatPar.Add(value);
        }
        public void AddStr(string value)
        {
            _strPar.Add(value);
        }
    }

    public class EventMgr
    {
        #region Single
        private EventMgr() { Init(); }
        private static EventMgr _ins;
        public static EventMgr Ins
        {
            get
            {
                if (_ins == null) _ins = new EventMgr();
                return _ins;
            }
        }
        #endregion

        private Dictionary<string, List<VoidDelegate>> _events;

        private void Init()
        {
            _events = new Dictionary<string, List<VoidDelegate>>();
        }
        
        public void RegistEvent(string eventName, VoidDelegate voidDelegate)
        {
            if(_events == null) _events = new Dictionary<string, List<VoidDelegate>>();
            if(_events.ContainsKey(eventName))
                _events[eventName].Add(voidDelegate);
            else
            {
                List<VoidDelegate> ds = new List<VoidDelegate>();
                ds.Add(voidDelegate);
                _events.Add(eventName, ds);
            }
        }

        public void NotifyEvent(string eventName, MyEventArgs args)
        {
            if (_events == null || _events[eventName] == null) return;
            foreach(var e in _events[eventName])
            {
                e(args);
            }
        }

        public void RemoveEvent(string eventName, VoidDelegate d)
        {
            if (_events == null || _events[eventName] == null) return;
            if(_events.ContainsKey(eventName) && _events[eventName].Contains(d))
            {
                _events[eventName].Remove(d);
            }
        }
    }

}
