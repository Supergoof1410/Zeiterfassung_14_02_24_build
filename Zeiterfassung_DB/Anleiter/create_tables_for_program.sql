DROP TABLE IF EXISTS attendee;
DROP TABLE IF EXISTS login_logout;
DROP TABLE IF EXISTS loggingTime;
DROP TABLE IF EXISTS logYear;
DROP TABLE IF EXISTS persons;
DROP TABLE IF EXISTS diffTime;

CREATE TABLE attendee (
	attendee_id INTEGER PRIMARY KEY,
	attendee_number TEXT NOT NULL UNIQUE,
	fk_persons INTEGER NULL UNIQUE,
	FOREIGN KEY (fk_persons) REFERENCES persons (persons_id)
		ON DELETE SET NULL
);

CREATE TABLE "persons" (
	"persons_id"	INTEGER UNIQUE,
	"firstname"	TEXT NOT NULL,
	"lastname"	TEXT NOT NULL,
	"passwd"	TEXT NOT NULL UNIQUE,
	"BeginMeasure"	TEXT NOT NULL,
	"EndMeasure"	TEXT NOT NULL,
	"condition"	TEXT NOT NULL,
	"BeginWork"	TEXT NOT NULL,
	"EndWork"	TEXT NOT NULL,
	"SummaryHoursDay"	TEXT NOT NULL,
	"SummaryWeekdays"	INTEGER NOT NULL,
	PRIMARY KEY("persons_id")
);

CREATE TABLE loggingTime (
	loggingTime_id INTEGER PRIMARY KEY,
	logDayTime TEXT
);

CREATE TABLE logYear (
	logYear_id INTEGER PRIMARY KEY,
	year INTEGER UNIQUE
);

CREATE TABLE diffTime (
	"diffTime_id" INTEGER,
	"timeSpan" TEXT UNIQUE,
	PRIMARY KEY ("diffTime_id")
);

CREATE TABLE "login_logout" (
	"fk_persons_id"	INTEGER NOT NULL,
	"fk_login_time"	INTEGER,
	"fk_logout_time"	INTEGER,
	"day"	INTEGER NOT NULL,
	"month"	INTEGER NOT NULL,
	"fk_year"	INTEGER NOT NULL,
	"fk_diffTime" INTEGER,
	PRIMARY KEY("fk_persons_id","day","month","fk_year"),
	FOREIGN KEY("fk_login_time") REFERENCES "loggingTime"("loggingTime_id"),
	FOREIGN KEY("fk_persons_id") REFERENCES "persons"("persons_id"),
	FOREIGN KEY("fk_year") REFERENCES "logYear"("logYear_id"),
	FOREIGN KEY("fk_logout_time") REFERENCES "loggingTime"("loggingTime_id"),
	FOREIGN KEY("fk_diffTime") REFERENCES "diffTime" ("diffTime_id")
);

INSERT INTO attendee (attendee_number) VALUES ('TN-01');
INSERT INTO attendee (attendee_number) VALUES ('TN-02');
INSERT INTO attendee (attendee_number) VALUES ('TN-03');
INSERT INTO attendee (attendee_number) VALUES ('TN-04');
INSERT INTO attendee (attendee_number) VALUES ('TN-05');
INSERT INTO attendee (attendee_number) VALUES ('TN-06');
INSERT INTO attendee (attendee_number) VALUES ('TN-07');
INSERT INTO attendee (attendee_number) VALUES ('TN-08');
INSERT INTO attendee (attendee_number) VALUES ('TN-09');
INSERT INTO attendee (attendee_number) VALUES ('TN-10');
INSERT INTO attendee (attendee_number) VALUES ('TN-11');
INSERT INTO attendee (attendee_number) VALUES ('TN-12');
INSERT INTO attendee (attendee_number) VALUES ('TN-13');
INSERT INTO attendee (attendee_number) VALUES ('TN-14');
INSERT INTO attendee (attendee_number) VALUES ('TN-15');
INSERT INTO attendee (attendee_number) VALUES ('TN-16');
INSERT INTO attendee (attendee_number) VALUES ('TN-17');
INSERT INTO attendee (attendee_number) VALUES ('TN-18');
INSERT INTO attendee (attendee_number) VALUES ('TN-19');
INSERT INTO attendee (attendee_number) VALUES ('TN-20');
INSERT INTO attendee (attendee_number) VALUES ('TN-21');
INSERT INTO attendee (attendee_number) VALUES ('TN-22');
INSERT INTO attendee (attendee_number) VALUES ('TN-23');
INSERT INTO attendee (attendee_number) VALUES ('TN-24');
INSERT INTO attendee (attendee_number) VALUES ('TN-25');
INSERT INTO attendee (attendee_number) VALUES ('TN-26');
INSERT INTO attendee (attendee_number) VALUES ('TN-27');
INSERT INTO attendee (attendee_number) VALUES ('TN-28');
INSERT INTO attendee (attendee_number) VALUES ('TN-29');
INSERT INTO attendee (attendee_number) VALUES ('TN-30');
INSERT INTO attendee (attendee_number) VALUES ('TN-31');
INSERT INTO attendee (attendee_number) VALUES ('TN-32');
INSERT INTO attendee (attendee_number) VALUES ('TN-33');
INSERT INTO attendee (attendee_number) VALUES ('TN-34');
INSERT INTO attendee (attendee_number) VALUES ('TN-35');
INSERT INTO attendee (attendee_number) VALUES ('TN-36');
INSERT INTO attendee (attendee_number) VALUES ('TN-37');
INSERT INTO attendee (attendee_number) VALUES ('TN-38');
INSERT INTO attendee (attendee_number) VALUES ('TN-39');
INSERT INTO attendee (attendee_number) VALUES ('TN-40');
INSERT INTO attendee (attendee_number) VALUES ('TN-41');
INSERT INTO attendee (attendee_number) VALUES ('TN-42');
INSERT INTO attendee (attendee_number) VALUES ('TN-43');
INSERT INTO attendee (attendee_number) VALUES ('TN-44');
INSERT INTO attendee (attendee_number) VALUES ('TN-45');
INSERT INTO attendee (attendee_number) VALUES ('TN-46');
INSERT INTO attendee (attendee_number) VALUES ('TN-47');
INSERT INTO attendee (attendee_number) VALUES ('TN-48');
INSERT INTO attendee (attendee_number) VALUES ('TN-49');
INSERT INTO attendee (attendee_number) VALUES ('TN-50');
INSERT INTO attendee (attendee_number) VALUES ('TN-51');
INSERT INTO attendee (attendee_number) VALUES ('TN-52');
INSERT INTO attendee (attendee_number) VALUES ('TN-53');
INSERT INTO attendee (attendee_number) VALUES ('TN-54');
INSERT INTO attendee (attendee_number) VALUES ('TN-55');
INSERT INTO attendee (attendee_number) VALUES ('TN-56');
INSERT INTO attendee (attendee_number) VALUES ('TN-57');
INSERT INTO attendee (attendee_number) VALUES ('TN-58');
INSERT INTO attendee (attendee_number) VALUES ('TN-59');
INSERT INTO attendee (attendee_number) VALUES ('TN-60');
INSERT INTO attendee (attendee_number) VALUES ('TN-61');
INSERT INTO attendee (attendee_number) VALUES ('TN-62');
INSERT INTO attendee (attendee_number) VALUES ('TN-63');
INSERT INTO attendee (attendee_number) VALUES ('TN-64');
INSERT INTO attendee (attendee_number) VALUES ('TN-65');
INSERT INTO attendee (attendee_number) VALUES ('TN-66');
INSERT INTO attendee (attendee_number) VALUES ('TN-67');
INSERT INTO attendee (attendee_number) VALUES ('TN-68');
INSERT INTO attendee (attendee_number) VALUES ('TN-69');
INSERT INTO attendee (attendee_number) VALUES ('TN-70');
INSERT INTO attendee (attendee_number) VALUES ('TN-71');
INSERT INTO attendee (attendee_number) VALUES ('TN-72');
INSERT INTO attendee (attendee_number) VALUES ('TN-73');
INSERT INTO attendee (attendee_number) VALUES ('TN-74');
INSERT INTO attendee (attendee_number) VALUES ('TN-75');
INSERT INTO attendee (attendee_number) VALUES ('TN-76');
INSERT INTO attendee (attendee_number) VALUES ('TN-77');
INSERT INTO attendee (attendee_number) VALUES ('TN-78');
INSERT INTO attendee (attendee_number) VALUES ('TN-79');
INSERT INTO attendee (attendee_number) VALUES ('TN-80');
INSERT INTO attendee (attendee_number) VALUES ('TN-81');
INSERT INTO attendee (attendee_number) VALUES ('TN-82');
INSERT INTO attendee (attendee_number) VALUES ('TN-83');
INSERT INTO attendee (attendee_number) VALUES ('TN-84');
INSERT INTO attendee (attendee_number) VALUES ('TN-85');
INSERT INTO attendee (attendee_number) VALUES ('TN-86');
INSERT INTO attendee (attendee_number) VALUES ('TN-87');
INSERT INTO attendee (attendee_number) VALUES ('TN-88');
INSERT INTO attendee (attendee_number) VALUES ('TN-89');
INSERT INTO attendee (attendee_number) VALUES ('TN-90');
INSERT INTO attendee (attendee_number) VALUES ('TN-91');
INSERT INTO attendee (attendee_number) VALUES ('TN-92');
INSERT INTO attendee (attendee_number) VALUES ('TN-93');
INSERT INTO attendee (attendee_number) VALUES ('TN-94');
INSERT INTO attendee (attendee_number) VALUES ('TN-95');
INSERT INTO attendee (attendee_number) VALUES ('TN-96');
INSERT INTO attendee (attendee_number) VALUES ('TN-97');
INSERT INTO attendee (attendee_number) VALUES ('TN-98');
INSERT INTO attendee (attendee_number) VALUES ('TN-99');

INSERT INTO loggingTime (logDayTime) VALUES ('8:30');
INSERT INTO loggingTime (logDayTime) VALUES ('8:45');
INSERT INTO loggingTime (logDayTime) VALUES ('9:00');
INSERT INTO loggingTime (logDayTime) VALUES ('9:15');
INSERT INTO loggingTime (logDayTime) VALUES ('9:30');
INSERT INTO loggingTime (logDayTime) VALUES ('9:45');
INSERT INTO loggingTime (logDayTime) VALUES ('10:00');
INSERT INTO loggingTime (logDayTime) VALUES ('10:15');
INSERT INTO loggingTime (logDayTime) VALUES ('10:30');
INSERT INTO loggingTime (logDayTime) VALUES ('10:45');
INSERT INTO loggingTime (logDayTime) VALUES ('11:00');
INSERT INTO loggingTime (logDayTime) VALUES ('11:15');
INSERT INTO loggingTime (logDayTime) VALUES ('11:30');
INSERT INTO loggingTime (logDayTime) VALUES ('11:45');
INSERT INTO loggingTime (logDayTime) VALUES ('12:00');
INSERT INTO loggingTime (logDayTime) VALUES ('12:15');
INSERT INTO loggingTime (logDayTime) VALUES ('12:30');
INSERT INTO loggingTime (logDayTime) VALUES ('12:45');
INSERT INTO loggingTime (logDayTime) VALUES ('13:00');
INSERT INTO loggingTime (logDayTime) VALUES ('13:15');
INSERT INTO loggingTime (logDayTime) VALUES ('13:30');
INSERT INTO loggingTime (logDayTime) VALUES ('13:45');
INSERT INTO loggingTime (logDayTime) VALUES ('14:00');
INSERT INTO loggingTime (logDayTime) VALUES ('14:15');
INSERT INTO loggingTime (logDayTime) VALUES ('14:30');

INSERT INTO diffTime (timeSpan) VALUES ('00:15');
INSERT INTO diffTime (timeSpan) VALUES ('00:30');
INSERT INTO diffTime (timeSpan) VALUES ('00:45');
INSERT INTO diffTime (timeSpan) VALUES ('01:00');
INSERT INTO diffTime (timeSpan) VALUES ('01:15');
INSERT INTO diffTime (timeSpan) VALUES ('01:30');
INSERT INTO diffTime (timeSpan) VALUES ('01:45');
INSERT INTO diffTime (timeSpan) VALUES ('02:00');
INSERT INTO diffTime (timeSpan) VALUES ('02:15');
INSERT INTO diffTime (timeSpan) VALUES ('02:30');
INSERT INTO diffTime (timeSpan) VALUES ('02:45');
INSERT INTO diffTime (timeSpan) VALUES ('03:00');
INSERT INTO diffTime (timeSpan) VALUES ('03:15');
INSERT INTO diffTime (timeSpan) VALUES ('03:30');
INSERT INTO diffTime (timeSpan) VALUES ('03:45');
INSERT INTO diffTime (timeSpan) VALUES ('04:00');
INSERT INTO diffTime (timeSpan) VALUES ('04:15');
INSERT INTO diffTime (timeSpan) VALUES ('04:30');
INSERT INTO diffTime (timeSpan) VALUES ('04:45');
INSERT INTO diffTime (timeSpan) VALUES ('05:00');
INSERT INTO diffTime (timeSpan) VALUES ('05:15');
INSERT INTO diffTime (timeSpan) VALUES ('05:30');
INSERT INTO diffTime (timeSpan) VALUES ('05:45');
INSERT INTO diffTime (timeSpan) VALUES ('06:00');

INSERT INTO logYear (year) VALUES (2023);
INSERT INTO logYear (year) VALUES (2024);
INSERT INTO logYear (year) VALUES (2025);
INSERT INTO logYear (year) VALUES (2026);
INSERT INTO logYear (year) VALUES (2027);
INSERT INTO logYear (year) VALUES (2028);
INSERT INTO logYear (year) VALUES (2029);
INSERT INTO logYear (year) VALUES (2030);
INSERT INTO logYear (year) VALUES (2031);
INSERT INTO logYear (year) VALUES (2032);


