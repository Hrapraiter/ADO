
UPDATE Directors
SET first_name = N'TestComp' , last_name = N'TestEnd'
WHERE director_id = (SELECT MAX(director_id) FROM Directors)