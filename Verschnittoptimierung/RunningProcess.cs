using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Verschnittoptimierung
{
    public class RunningProcess
    {
        // true = a process exists -> can be continued when state=waiting, and no other process should be started beneath the existing one
        public Boolean existing;
        // 0 = waiting, 1 = running
        public int state;
        // param 0 = do only one step, 1 = do all remaining steps
        public int param;

        public Thread thread;

        // type of thread (Greedy1, Greedy2, ..)
        // 0=default, 1=greedy1
        public int type;

        public AutoResetEvent autoResetEvent;

        public Boolean firstStep;

        public RunningProcess()
        {
            // basic configuration (no process existing)
            this.existing = false;
            this.state = 0;
            this.param = 0;
            this.type = 0;
            this.autoResetEvent = new AutoResetEvent(false);
            this.firstStep = true;
        }
    }
}
