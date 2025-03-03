UPDATE login_logout 
SET fk_diffTime = 
(SELECT diffTime_id FROM diffTime WHERE timeSpan = '06:00')
WHERE day = 3 AND month = 12
AND fk_year = (SELECT logYear_id FROM logYear WHERE year = 2023)
AND fk_persons_id = (SELECT persons_id FROM persons JOIN attendee ON persons.persons_id = attendee.fk_persons
AND attendee.attendee_number = 'TN-03');