namespace Easter.Models.Workshops
{
    using System.Collections.Generic;
    using System.Linq;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes.Contracts;
    using Easter.Models.Eggs.Contracts;
    using Contracts;
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            List<IDye> dyes = bunny.Dyes.Where(d => d.IsFinished() == false).ToList();

            while (egg.EnergyRequired > 0 && bunny.Energy > 0 && dyes.Count > 0)
            {
                IDye dye = dyes.First();
                egg.GetColored();
                dye.Use();
                bunny.Work();
                if (dye.IsFinished())
                {
                    dyes.RemoveAt(0);
                }
            }
        }
    }
}
