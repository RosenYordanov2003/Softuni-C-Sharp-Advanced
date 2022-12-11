
namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        private const double DefaultPrice = 4.00;
        public Gingerbread(string delicacyName) : base(delicacyName, DefaultPrice){}
    }
}
