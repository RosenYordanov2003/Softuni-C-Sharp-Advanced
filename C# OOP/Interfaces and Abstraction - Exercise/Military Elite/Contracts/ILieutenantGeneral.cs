using System.Collections.Generic;


namespace Military_Elite.Contracts
{
    public interface ILieutenantGeneral:IPrivate
    {
        public Dictionary<int,IPrivate> Privates { get; }
    }
}
