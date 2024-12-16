-- Find All Users for an Activity

SELECT u.Name, u.Email, addr.Street, addr.City
FROM Users u
JOIN UserActivities ua ON u.UserID = ua.UserID
JOIN Addresses addr ON u.AddressID = addr.AddressID
WHERE ua.ActivityID = 2;

