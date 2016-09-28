// Copyright 2014 The Rector & Visitors of the University of Virginia
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Linq;
using System.Collections.ObjectModel;

using Newtonsoft.Json;
using SensusUI.Inputs;

namespace SensusService.Probes.User.Scripts
{
    public class Script
    {
        #region Properties
        public ScriptRunner Runner { get; }

        public string Id { get; }        

        public ObservableCollection<InputGroup> InputGroups { get; }

        /// <summary>
        /// Time at which the script was run. On Android this happens in the background at the scheduled/triggered
        /// time. On iOS this is the triggering time (for trigger-based scripts), and the time that the 
        /// UILocalNotification appears in the notifications tray (for scheduled scripts).
        /// </summary>
        public DateTimeOffset? RunTimestamp { get; set; }

        public Datum PreviousDatum { get; set; }

        public Datum CurrentDatum { get; set; }

        [JsonIgnore]
        public bool Valid => InputGroups.Count == 0 || InputGroups.All(inputGroup => inputGroup.Valid);

        [JsonIgnore]
        // TODO:  Does this provide the correct age when _runTimestamp is set by window-triggering, which uses DateTime objects.
        public TimeSpan? Age => DateTimeOffset.UtcNow - RunTimestamp;

        public DateTime ExpirationDate { get; set; }
        #endregion

        #region Constructors
        public Script(Script script): this(script.Runner)
        {            
            InputGroups   = new ObservableCollection<InputGroup>(script.InputGroups);
            RunTimestamp  = script.RunTimestamp;
            PreviousDatum = script.PreviousDatum;
            CurrentDatum  = script.CurrentDatum;
        }

        public Script(ScriptRunner runner)
        {
            Runner      = runner;
            Id          = Guid.NewGuid().ToString();
            InputGroups = new ObservableCollection<InputGroup>();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Checks whether the current and another script share a parent script.
        /// </summary>
        /// <returns><c>true</c>, if parent script is shared, <c>false</c> otherwise.</returns>
        public bool SharesParentScriptWith(Script script)
        {
            return Runner.Script.Id == script.Runner.Script.Id;
        }
        #endregion
    }
}