using System.Collections.Generic;
using Nethereum.RPC.Eth.DTOs.Comparers;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Xunit;

namespace Nethereum.Contracts.UnitTests
{
    public class FilterLogSortingTests
    {
        [Fact]
        public void ShouldSortBasedOnBlockNumber()
        {
            //given
            var filterLog = new FilterLog { BlockNumber = new HexBigInteger(1), TransactionIndex = new HexBigInteger(1), LogIndex = new HexBigInteger(1) };
            var filterLog2 =
                new FilterLog { BlockNumber = new HexBigInteger(2), TransactionIndex = new HexBigInteger(1), LogIndex = new HexBigInteger(1) };
            var filterLog3 =
                new FilterLog { BlockNumber = new HexBigInteger(3), TransactionIndex = new HexBigInteger(1), LogIndex = new HexBigInteger(1) };

            var list = new List<FilterLog>(new[] { filterLog3, filterLog, filterLog2 });
            list.Sort(new FilterLogBlockNumberTransactionIndexLogIndexComparer());
            Assert.Same(filterLog, list[0]);
            Assert.Same(filterLog2, list[1]);
            Assert.Same(filterLog3, list[2]);
        }

        [Fact]
        public void ShouldSortBasedOnBlockNumberAndTransactionIndex()
        {
            //given
            var filterLog = new FilterLog {BlockNumber = new HexBigInteger(1), TransactionIndex = new HexBigInteger(1), LogIndex = new HexBigInteger(1) };
            var filterLog2 =
                new FilterLog {BlockNumber = new HexBigInteger(2), TransactionIndex = new HexBigInteger(1), LogIndex = new HexBigInteger(2) };
            var filterLog3 =
                new FilterLog {BlockNumber = new HexBigInteger(2), TransactionIndex = new HexBigInteger(2), LogIndex = new HexBigInteger(2) };

            var list = new List<FilterLog>(new[] {filterLog3, filterLog, filterLog2});
            list.Sort(new FilterLogBlockNumberTransactionIndexLogIndexComparer());
            Assert.Same(filterLog, list[0]);
            Assert.Same(filterLog2, list[1]);
            Assert.Same(filterLog3, list[2]);
        }

        [Fact]
        public void ShouldSortBasedOnBlockNumberAndTransactionIndexAndLogIndex()
        {
            //given
            var filterLog = new FilterLog { BlockNumber = new HexBigInteger(1), TransactionIndex = new HexBigInteger(1), LogIndex = new HexBigInteger(1) };
            var filterLog2 = new FilterLog { BlockNumber = new HexBigInteger(2), TransactionIndex = new HexBigInteger(1), LogIndex = new HexBigInteger(2) };
            var filterLog3 = new FilterLog { BlockNumber = new HexBigInteger(2), TransactionIndex = new HexBigInteger(2), LogIndex = new HexBigInteger(3) };
            var filterLog4 = new FilterLog { BlockNumber = new HexBigInteger(2), TransactionIndex = new HexBigInteger(2), LogIndex = new HexBigInteger(4) };

            var list = new List<FilterLog>(new[] { filterLog, filterLog2, filterLog4, filterLog3  });
            list.Sort(new FilterLogBlockNumberTransactionIndexLogIndexComparer());
            Assert.Same(filterLog, list[0]);
            Assert.Same(filterLog2, list[1]);
            Assert.Same(filterLog3, list[2]);
            Assert.Same(filterLog4, list[3]);
        }
    }
}