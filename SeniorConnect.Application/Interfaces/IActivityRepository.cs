﻿using SeniorConnect.Domain;

namespace SeniorConnect.Application.Interfaces;
public interface IActivityRepository
{
    Task CreateActivityAsync(Activity activity);

    Task<Activity?> GetActivityByIdAsync(int activityId);

    Task<IEnumerable <Activity>> GetAllAsync();

    Task<bool> UpdateActivityAsync(Activity activity);

    Task<bool> DeleteActivityAsync(int activityId);

    //Task<List<Activity>> GetActivitiesByDateAsync(DateOnly date);
    //Task<List<Activity>> GetActivitiesByCityAsync(string city);
    //Task<List<Activity>> GetActivitiesByHostAsync(int hostUserId);

}
