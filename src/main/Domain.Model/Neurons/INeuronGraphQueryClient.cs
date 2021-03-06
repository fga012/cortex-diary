﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace works.ei8.Cortex.Diary.Domain.Model.Neurons
{
    public interface INeuronGraphQueryClient
    {
        Task<Neuron> GetNeuron(string id, CancellationToken token = default(CancellationToken));

        Task<IEnumerable<Neuron>> GetAllNeuronsByDataSubstring(string dataSubstring, CancellationToken token = default(CancellationToken));
    }
}
