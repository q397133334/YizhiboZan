using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Camouflage.Common.ThreadManager
{
    public class ThreadManager
    {
        private Hashtable m_already;

        private List<IDo> m_workload;

        private IDo m_base;

        private string m_outputPath;

        private long m_startTime = 0;

        private Done m_done = new Done();

        private bool m_quit;

        enum Status { STATUS_FAILED, STATUS_SUCCESS, STATUS_QUEUED };


        public ThreadManager()
        {
            this.reset();
        }

        /// <summary>
		/// Call to reset from a previous run of the spider
		/// </summary>
		public void reset()
        {
            m_already = new Hashtable();
            m_workload = new List<IDo>();
            m_quit = false;
        }

        public void addURL(IDo _do)
        {
            Monitor.Enter(this);
            if (!m_already.Contains(_do))
            {
                //m_already.Add(_do, Status.STATUS_QUEUED);

                m_workload.Add(_do);
            }
            Monitor.Pulse(this);
            Monitor.Exit(this);
        }

        public IDo BaseURL
        {
            get { return m_base; }
            set { m_base = value; }
        }

        public string OutputPath
        {
            get
            {
                return m_outputPath;
            }
            set
            {
                m_outputPath = value;
            }
        }

        public bool Quit
        {
            get
            {
                return m_quit;
            }
            set
            {
                m_quit = value;
            }
        }

        public Done SpiderDone
        {
            get
            {
                return m_done;
            }
        }

        public IDo ObtainWork()
        {
            Monitor.Enter(this);
            while (m_workload.Count < 1)
            {
                Monitor.Wait(this);
            }
            IDo next = m_workload.OrderBy(m => m.Priority).FirstOrDefault();
            m_workload.Remove(next);
            Monitor.Exit(this);
            return next;
        }

        private List<DocumentWorker> dw = new List<DocumentWorker>();

        public void Start(int threads)
        {
            // init the spider
            m_quit = false;

            //m_base = baseURI;
            //addURL(m_base);
            m_startTime = System.DateTime.Now.Ticks; ;
            m_done.Reset();

            // startup the threads

            for (int i = 1; i <= threads; i++)
            {
                DocumentWorker worker = new DocumentWorker(this);
                worker.Number = i;
                worker.start();
            }

            // now wait to be done

            m_done.WaitBegin();
            m_done.WaitDone();
        }
    }
}
