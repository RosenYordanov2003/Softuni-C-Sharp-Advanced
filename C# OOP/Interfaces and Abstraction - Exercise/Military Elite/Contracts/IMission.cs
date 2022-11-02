using Military_Elite.Enums;

namespace Military_Elite.Contracts
{
    public interface IMission
    {
        public string CodeName { get;}
        public State State { get;}
        void CompleteMission();
    }
}
