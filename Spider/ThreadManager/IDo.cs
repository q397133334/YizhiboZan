using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Camouflage.Common.ThreadManager
{
    public interface IDo : IDisposable
    {
        /// <summary>
        /// 开始接口
        /// </summary>
        void Start();
        /// <summary>
        /// 调度优先级
        /// </summary>
        int Priority { get; set; }
        /// <summary>
        /// 实体模型
        /// </summary>
        object Data { get; set; }

        ThreadManager threadManager { get; set; }
    }
}
