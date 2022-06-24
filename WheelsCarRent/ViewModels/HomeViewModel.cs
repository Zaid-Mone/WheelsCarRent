using System.Collections.Generic;
using WheelsCarRent.Models;

namespace WheelsCarRent.ViewModels
{
    public class HomeViewModel
    {
        public List<CarType> CarTypes { get; set; }
        public List<Car> Cars { get; set; }
        public OurClient OurClient { get; set; }
        public List<OurClient> OurClients { get; set; }
        public FeedBack FeedBack { get; set; }
    }

}
