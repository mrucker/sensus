﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SensusService.Probes.User
{
    public class ScriptDatum : Datum
    {
        public override string DisplayDetail
        {
            get { throw new NotImplementedException(); }
        }

        public ScriptDatum(Probe probe, DateTimeOffset timestamp)
            : base(probe, timestamp)
        {
        }
    }
}
