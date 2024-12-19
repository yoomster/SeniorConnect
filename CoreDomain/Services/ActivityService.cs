using SeniorConnect.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.Domain.Services
{
    public class ActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public static void RegisterActivity (object registerDto, object userDto)
        {
            throw new NotImplementedException();
            //if statement for validation, if true, create
        }

        //An activity cannot contain more than the maximum number of participants
        //A reservation cannot be canceled for free less than 24 hours before the session starts
    }
}
