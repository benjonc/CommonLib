using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.FSM
{
    /// <summary>
    /// 状态机接口
    /// </summary>
    public interface IStateMechine
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        IState CurState { get; }
        /// <summary>
        /// 默认状态
        /// </summary>
        IState DefaultState { get; set; }
        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="state"> 需要被添加的状态 </param>
        void AddState(IState state);
        /// <summary>
        /// 删除状态
        /// </summary>
        /// <param name="state"> 要被删除的状态 </param>
        void RemoveState(IState state);
        /// <summary>
        /// 通过 tag 获取状态
        /// </summary>
        /// <param name="tag"> 状态的 tag 值 </param>
        /// <returns> 查找到的状态 </returns>
        IState GetStateWithTag(string tag);
        /// <summary>
        /// 通过 name 获取状态
        /// </summary>
        /// <param name="name"> 状态的 name 值 </param>
        /// <returns> 查找到的状态 </returns>
        IState GetStateWithName(string name);

    }
}
