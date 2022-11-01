using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy.Contracts
{
    public interface IAddRemoveCollection : IAddCollection
    {
        string Remove();
    }
}
