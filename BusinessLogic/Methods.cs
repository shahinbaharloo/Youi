using System.Collections.Generic;
using System.Linq;
using Youi.Model;

namespace Youi.BusinessLogic
{
    class Methods
    {
        public List<string> SortAddresses(List<AllValuesToProcess> AllValues)
        {
            return AllValues.OrderBy(x => x.StreetName).Select(x => x.Address).ToList();
        }
    }
}
