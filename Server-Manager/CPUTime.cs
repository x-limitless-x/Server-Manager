using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Manager
{
    public class CpuTime : IDisposable
    {
        private PerformanceCounter _counter;
        private DateTime _lastcheck;
        private float _lastvalue;

        public float Value
        {
            get
            {
                if ((DateTime.Now - _lastcheck).TotalMilliseconds > 950)
                {
                    _lastvalue = _counter.NextValue();
                    _lastcheck = DateTime.Now;
                }
                return _lastvalue;
            }
        }

        public CpuTime()
        {
            _counter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
            _counter.NextValue();
            _lastcheck = DateTime.Now;
        }

        ~CpuTime()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_counter != null)
            {
                _counter.Dispose();
                _counter = null;
            }
        }

        public override string ToString()
        {
            return string.Format("{0:0.00}%", Value);
        }
    }
}
