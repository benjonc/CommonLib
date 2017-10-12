using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.FSM
{
    /// <summary>
    /// 状态接口
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// 状态名
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 状态标签
        /// </summary>
        string Tag { get; set; }
        /// <summary>
        /// 状态的状态机
        /// </summary>
        IStateMechine Parent { get; set; }
        /// <summary>
        /// 从进入状态开始计算的时长
        /// </summary>
        float Timer { get; }

        /// <summary>
        /// 状态过渡
        /// </summary>
        List<ITransition> Transitions { get; }

        /// <summary>
        /// 进入状态
        /// </summary>
        /// <param name="state"> 上一个状态 </param>
        void EnterCallback(IState prev);
        /// <summary>
        /// 离开状态
        /// </summary>
        /// <param name="state"> 下一个状态 </param>
        void ExitCallback(IState next);
        /// <summary>
        /// update 回调
        /// </summary>
        /// <param name="deltaTime"> Time.deltaTime </param>
        void UpdateCallback(float deltaTime);
        /// <summary>
        /// LateUpdate 回调
        /// </summary>
        /// <param name="deltaTime"> Time.deltaTime </param>
        void LateUpdateCallback(float deltaTime);
        /// <summary>
        /// FixedUpdate 回调
        /// </summary>
        void FixedUpdateCallback();
    }
}
