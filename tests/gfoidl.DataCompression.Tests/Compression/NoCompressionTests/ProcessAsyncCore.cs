﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace gfoidl.DataCompression.Tests.Compression.NoCompressionTests
{
    public class ProcessAsyncCore : Base
    {
        [Test]
        public async Task Data_given_as_IAsyncEnumerable___OK()
        {
            var sut      = new NoCompression();
            var data     = RawDataForTrendAsync();
            var expected = RawDataForTrend().ToList();

            var actual = new List<DataPoint>();
            await foreach (DataPoint dp in sut.ProcessAsync(data))
                actual.Add(dp);

            CollectionAssert.AreEqual(expected, actual);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Cancellation_after_two_items___OK()
        {
            var sut      = new NoCompression();
            var data     = RawDataForTrendAsync();
            var expected = RawDataForTrend().Take(2).ToList();
            var cts      = new CancellationTokenSource();

            var actual = new List<DataPoint>();
            int idx    = 0;

            Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await foreach (DataPoint dp in sut.ProcessAsync(data, cts.Token))
                {
                    actual.Add(dp);
                    idx++;

                    if (idx == 2) cts.Cancel();
                }
            });

            CollectionAssert.AreEqual(actual, expected);
        }
        //---------------------------------------------------------------------
        [Test]
        public async Task Data_IAsyncEnumerable_with_maxDeltaX___OK()
        {
            var sut      = new NoCompression();
            var data     = RawDataForMaxDeltaAsync();
            var expected = RawDataForMaxDelta().ToList();

            var actual = new List<DataPoint>();
            await foreach (DataPoint dp in sut.ProcessAsync(data))
                actual.Add(dp);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
