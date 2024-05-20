using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKonva.Helpers
{
    public class SequencerSingleton
    {

        public static Lazy<SequencerSingleton> Instance { get; private set; } = 
            new Lazy<SequencerSingleton>(() => new SequencerSingleton());

        public EventHandler OnStageLoaded { get; set; }
        public EventHandler OnLayerLoaded { get; set; }

    }
}
