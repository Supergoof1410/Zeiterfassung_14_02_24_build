/*Insert test data for login*/
INSERT INTO login_logout 
	(fk_persons_id, fk_login_time, day, month, fk_year)
VALUES
	((SELECT persons_id	FROM persons JOIN attendee ON persons.persons_id = attendee.fk_persons WHERE attendee.attendee_number = 'TN-03'),
	 (SELECT loggingTime_id FROM loggingTime WHERE logDayTime = '8:30'), 3, 12, 
	 (SELECT logYear_id FROM logYear WHERE year = 2023));
	 
/*Insert test data for logout*/
UPDATE login_logout SET 
	fk_logout_time = (SELECT loggingTime_id FROM loggingTime WHERE logDayTime = '14:30')
WHERE 
	day = 3 
AND month = 12 
AND fk_year = (SELECT logYear_id FROM logYear WHERE year = 2023)
AND fk_persons_id = (SELECT persons_id	FROM persons JOIN attendee ON persons.persons_id = attendee.fk_persons WHERE attendee.attendee_number = 'TN-03');