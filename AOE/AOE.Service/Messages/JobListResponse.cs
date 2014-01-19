using AOE.Service.ViewModels;
using System.Collections.Generic;

namespace AOE.Service.Messages
{
    public class JobListResponse
    {
        public List<JobViewModel> Jobs { get; set; }
    }
}
