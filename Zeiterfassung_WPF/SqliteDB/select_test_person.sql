SELECT 
	attendee.attendee_number, persons.firstname, persons.lastname, 
	(SELECT loggingTime.logDayTime FROM loggingTime WHERE loggingTime.loggingTime_id = login_logout.fk_login_time) AS Login,
	(SELECT loggingTime.logDayTime FROM loggingTime WHERE loggingTime.loggingTime_id = login_logout.fk_logout_time) AS Logout,
	login_logout.day, login_logout.month, 
	(SELECT logYear.year FROM logYear WHERE logYear.logYear_id = login_logout.fk_year) AS Year,
	(SELECT diffTime.timeSpan FROM diffTime WHERE diffTime_id = login_logout.fk_diffTime) AS Worktime
FROM login_logout, attendee
	JOIN persons ON login_logout.fk_persons_id = persons.persons_id
WHERE attendee.attendee_number = 'TN-31'
AND persons.persons_id = attendee.fk_persons


