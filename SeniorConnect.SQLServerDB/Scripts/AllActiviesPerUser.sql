-- Find All Activities for a User

SELECT a.Name, a.Description, addr.Street, addr.City
FROM Activities a
JOIN UserActivities ua ON a.ActivityID = ua.ActivityID
JOIN Addresses addr ON a.AddressID = addr.AddressID
WHERE ua.UserID = 1;
