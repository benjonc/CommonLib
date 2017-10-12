using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.FSM
{
    /// <summary>
    /// 用于状态过渡的接口
    /// </summary>
    public interface ITransition
    {
        /// <summary>
        /// 从哪个状态开始过渡
        /// </summary>
        IState From { get; set; }
        /// <summary>
        /// 要过渡到哪个状态
        /// </summary>
        IState To { get; set; }

        /// <summary>
        /// 过渡名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 过渡时的回调
        /// </summary>
        /// <returns> <c>true</c>, 过渡完成 <c>false</c>, 继续进行过渡 </returns>
        bool TransitionCallback();

        /// <summary>
        /// 是否开始过渡
        /// </summary>
        /// <returns><c>true</c>, 开始进行过渡 <c>false</c>, 不进行过渡 </returns>
        bool ShouldBegin();
    }
}
