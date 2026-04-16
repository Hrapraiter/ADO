USE PV_522_Import;
GO
CREATE OR ALTER FUNCTION LearningDaysFormat(@learning_days AS TINYINT , @spaser AS NVARCHAR(8) = N',') RETURNS NVARCHAR(15)
AS 
BEGIN
	DECLARE @format_LD AS NVARCHAR(15) = N'';

	-- Вариант 1
	--DECLARE @Weekdays_F AS TABLE
	--(
	--	day_id		TINYINT PRIMARY KEY,
	--	day_name	NCHAR(2) NOT NULL
	--);
	--INSERT @Weekdays_F (day_id , day_name) VALUES
	--(1 , N'Пн'),(2 , N'Вт'),(3 , N'Ср'),(4 , N'Чт'),
	--(5 , N'Пт'),(6 , N'Сб'),(7 , N'Вс');
	--DECLARE @bit_counter AS TINYINT = 0;
	--WHILE @bit_counter <= 6
	--BEGIN
	--	DECLARE @temp_day AS NCHAR(2) = (SELECT day_name FROM @Weekdays_F WHERE day_id = @bit_counter + 1);
	--	IF @learning_days & POWER(2 , @bit_counter) > 0
	--		SET @format_LD = FORMATMESSAGE(N'%s%s' , @format_LD , IIF(@format_LD = N'' , @temp_day , FORMATMESSAGE(N',%s' , @temp_day)));
	--	SET @bit_counter += 1;
	--END

	--Вариант 2

	IF @learning_days & POWER(2 , 0) > 0 SET @format_LD = FORMATMESSAGE(N'%s%s' , @format_LD , N'Пн');
	IF @learning_days & POWER(2 , 1) > 0 SET @format_LD = FORMATMESSAGE(N'%s%s' , @format_LD , IIF(@format_LD = N'' , N'Вт' , FORMATMESSAGE(N'%sВт',@spaser)));  
	IF @learning_days & POWER(2 , 2) > 0 SET @format_LD = FORMATMESSAGE(N'%s%s' , @format_LD , IIF(@format_LD = N'' , N'Ср' , FORMATMESSAGE(N'%sСр',@spaser)));  
	IF @learning_days & POWER(2 , 3) > 0 SET @format_LD = FORMATMESSAGE(N'%s%s' , @format_LD , IIF(@format_LD = N'' , N'Чт' , FORMATMESSAGE(N'%sЧт',@spaser)));  
	IF @learning_days & POWER(2 , 4) > 0 SET @format_LD = FORMATMESSAGE(N'%s%s' , @format_LD , IIF(@format_LD = N'' , N'Пт' , FORMATMESSAGE(N'%sПт',@spaser)));  
	IF @learning_days & POWER(2 , 5) > 0 SET @format_LD = FORMATMESSAGE(N'%s%s' , @format_LD , IIF(@format_LD = N'' , N'Сб' , FORMATMESSAGE(N'%sСб',@spaser)));  
	IF @learning_days & POWER(2 , 6) > 0 SET @format_LD = FORMATMESSAGE(N'%s%s' , @format_LD , IIF(@format_LD = N'' , N'Вс' , FORMATMESSAGE(N'%sВс',@spaser)));  

	RETURN @format_LD
END