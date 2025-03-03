SELECT 
	persons.persons_id, attendee.attendee_number, persons.lastname, persons.firstname,
	login_logout.day, login_logout.month, logYear.year, 
	(SELECT loggingTime.logDayTime FROM loggingTime WHERE login_logout.fk_login_time = loggingTime.loggingTime_id) AS Login,
	(SELECT loggingTime.logDayTime FROM loggingTime WHERE login_logout.fk_logout_time = loggingTime.loggingTime_id) AS Logout,
	(SELECT diffTime.timeSpan FROM diffTime WHERE diffTime.diffTime_id = login_logout.fk_diffTime) AS Difference
FROM persons
	JOIN attendee ON attendee.fk_persons = persons.persons_id
	JOIN login_logout ON login_logout.fk_persons_id = persons_id
	JOIN logYear ON logYear.logYear_id = login_logout.fk_year
