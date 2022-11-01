using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy.Contracts
{
    public interface IMyList : IAddRemoveCollection
    {
        public int Used { get; }
    }
}
