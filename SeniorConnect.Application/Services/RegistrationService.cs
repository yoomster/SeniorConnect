﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.Application.Services
{
    public class RegistrationService
    {
        //A reservation cannot be canceled for free less than 24 hours before the session starts

        //public void ReserveSpot(Participant participant)
        //{
        //    if (_participants.Count() >= _maxParticipants)
        //    {
        //        //todo: he system displays a message indicating that the activity is full. 
        //        throw new InvalidOperationException ("maximum participants reached");
        //    }
        //    else
        //    {
        //        _participants.Add(participant);
        //        //Add the activity ID to participant 
        //        participant.AddActivityToList(_id);
        //    }
        //}

        //public void CancelReservation(Participant participant)
        //    {
        //        var utcTimeNow = DateTime.UtcNow;
        //        const int minHours = 24;
        //        bool canNotCancel = (_date.ToDateTime(_startTime) - utcTimeNow).TotalHours < minHours;

        //        if (canNotCancel)
        //        {
        //            //button for canceling reservation is disabled
        //            throw new Exception("Cannot cancel reservation too close to session");
        //        }

        //        _participants.Remove(participant);
        //    }
    }
}