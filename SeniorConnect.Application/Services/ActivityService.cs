using SeniorConnect.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.Application.Services
{
    internal class ActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public static void RegisterActivity(object activity)
        {
            throw new NotImplementedException();
            //if statement for validation, if true, create
        }



        //An activity cannot contain more than the maximum number of participants
        //A reservation cannot be canceled for free less than 24 hours before the session starts
    }
}
