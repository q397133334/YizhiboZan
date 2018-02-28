using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Camouflage.Common.ThreadManager
{
    public class DocumentWorker : IDisposable
    {
        private IDo m_ido;

        /// <summary>
        /// The spider that this thread "works for"
        /// </summary>
        // 
        private ThreadManager t_manager;

        /// <summary>
        /// The thread that is being used.
        /// </summary>
        private Thread m_thread;

        /// <summary>
        /// The thread number, used to identify this worker.
        /// </summary>
        // 线程编号，用来标识当前的工作线程
        private int m_number;


        public enum Status { SUCCESS, ERROR }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="spider">The spider that owns this worker.</param>
        // 构造函数，参数表示拥有当前工作线程的蜘蛛程序
        public DocumentWorker(ThreadManager manager)
        {
            t_manager = manager;
        }

        /// <summary>
		/// This method is the main loop for the spider threads.
		/// This method will wait for URL's to become available, 
		/// and then process them. 
		/// </summary>
		public void Process()
        {
            while (!t_manager.Quit)
            {

                m_ido = t_manager.ObtainWork();
                t_manager.SpiderDone.WorkerBegin();
                m_ido.threadManager = t_manager;
                m_ido.Start();
                m_ido.Dispose();
                t_manager.SpiderDone.WorkerEnd();
            }
        }

        /// <summary>
        /// Start the thread.
        /// </summary>
        public void start()
        {
            ThreadStart ts = new ThreadStart(this.Process);
            m_thread = new Thread(ts);
            m_thread.Start();
        }

        public void AddDo(IDo _do)
        {
            t_manager.addURL(_do);
        }

        public void Dispose()
        {
            if (m_thread != null)
            {
                m_thread.Abort();
            }
            this.t_manager = null;
        }

        /// <summary>
        /// The thread number. Used only to identify this thread.
        /// </summary>
        public int Number
        {
            get
            {
                return m_number;
            }

            set
            {
                m_number = value;
            }

        }

        public ThreadManager ThreadManager
        {
            get
            {
                return t_manager;
            }

            set
            {
                t_manager = value;
            }
        }
    }


}
