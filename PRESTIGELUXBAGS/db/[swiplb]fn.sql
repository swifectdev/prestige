
-- function fgetcode
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fgetcode]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fgetcode]
GO
CREATE FUNCTION fgetcode (
	@itbl			VARCHAR(32)
	, @iprefix		VARCHAR(32)
)
RETURNS VARCHAR(32)
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE 
		@vcode 			AS VARCHAR(32)
		, @vcodelst 	AS VARCHAR(32)
		, @vseqnew		AS INT
		, @vcnt			AS INT;
	
	IF @itbl = 'mconsignee'
		BEGIN
			SELECT TOP 1 @vcodelst = ISNULL(MAX(code),'')
			FROM mconsignee 
			WHERE tstatus = 1 AND LEFT(code,2) = 'CN';
			
			SELECT @vcnt = COUNT(*)
			FROM mconsignee 
			WHERE tstatus = 0 AND code NOT IN (SELECT code FROM mconsignee WHERE tstatus = 1) AND LEFT(code,2) = 'CN'; 
			
			IF @vcodelst = '' BEGIN
				SET @vcode = 'CN00001';
			END ELSE IF @vcnt > 0 BEGIN
				SELECT @vcode = MIN(code) 
				FROM mconsignee
				WHERE tstatus = 0 AND code NOT IN (SELECT code FROM mconsignee WHERE tstatus = 1) AND LEFT(code,2) = 'CN';
			END ELSE BEGIN
				
				SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
				SET @vcode = 'CN' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
			END
		END
		
	ELSE IF @itbl = 'mitem'
		BEGIN
			SELECT TOP 1 @vcodelst = ISNULL(MAX(no),'')
			FROM mitem 
			WHERE tstatus = 1;
			
			SELECT @vcnt = COUNT(*)
			FROM mitem 
			WHERE tstatus = 0 AND no NOT IN (SELECT no FROM mitem WHERE tstatus = 1); 
			
			IF @vcodelst = '' BEGIN
				SET @vcode = '000001';
			END ELSE IF @vcnt > 0 BEGIN
				SELECT @vcode = MIN(no) 
				FROM mitem
				WHERE tstatus = 0 AND no NOT IN (SELECT no FROM mitem WHERE tstatus = 1) ;
			END ELSE BEGIN
				
				SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
				SET @vcode = RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
			END
		END
	
	ELSE IF @itbl = 'mcust'
		BEGIN
			SELECT TOP 1 @vcodelst = ISNULL(MAX(code),'')
			FROM mcust 
			WHERE tstatus = 1 AND LEFT(code,2) = 'CS';
			
			SELECT @vcnt = COUNT(*)
			FROM mcust 
			WHERE tstatus = 0 AND code NOT IN (SELECT code FROM mcust WHERE tstatus = 1) AND LEFT(code,2) = 'CS'; 
			
			IF @vcodelst = '' BEGIN
				SET @vcode = 'CS00001';
			END ELSE IF @vcnt > 0 BEGIN
				SELECT @vcode = MIN(code) 
				FROM mcust
				WHERE tstatus = 0 AND code NOT IN (SELECT code FROM mcust WHERE tstatus = 1) AND LEFT(code,2) = 'CS';
			END ELSE BEGIN
				
				SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
				SET @vcode = 'CS' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
			END
		END
	ELSE IF @itbl = 'msales'
		BEGIN
			SELECT TOP 1 @vcodelst = ISNULL(MAX(code),'')
			FROM msales 
			WHERE tstatus = 1 AND LEFT(code,2) = 'SL';
			
			SELECT @vcnt = COUNT(*)
			FROM msales 
			WHERE tstatus = 0 AND code NOT IN (SELECT code FROM msales WHERE tstatus = 1) AND LEFT(code,2) = 'CS'; 
			
			IF @vcodelst = '' BEGIN
				SET @vcode = 'SL00001';
			END ELSE IF @vcnt > 0 BEGIN
				SELECT @vcode = MIN(code) 
				FROM msales
				WHERE tstatus = 0 AND code NOT IN (SELECT code FROM msales WHERE tstatus = 1) AND LEFT(code,2) = 'CS';
			END ELSE BEGIN
				
				SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
				SET @vcode = 'SL' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
			END
		END
	ELSE IF @itbl = 'mvendor'
		BEGIN
			SELECT TOP 1 @vcodelst = ISNULL(MAX(code),'')
			FROM mvendor 
			WHERE tstatus = 1 AND LEFT(code,2) = 'VN';
			
			SELECT @vcnt = COUNT(*)
			FROM mvendor 
			WHERE tstatus = 0 AND code NOT IN (SELECT code FROM mcust WHERE tstatus = 1) AND LEFT(code,2) = 'VN'; 
			
			IF @vcodelst = '' BEGIN
				SET @vcode = 'VN00001';
			END ELSE IF @vcnt > 0 BEGIN
				SELECT @vcode = MIN(code) 
				FROM mvendor
				WHERE tstatus = 0 AND code NOT IN (SELECT code FROM mcust WHERE tstatus = 1) AND LEFT(code,2) = 'VN';
			END ELSE BEGIN
				
				SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
				SET @vcode = 'VN' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
			END
		END
	ELSE IF @itbl = 'mvendor'
		BEGIN
			SELECT TOP 1 @vcodelst = ISNULL(MAX(code),'')
			FROM mvendor 
			WHERE tstatus = 1 AND LEFT(code,2) = 'VN';
			
			SELECT @vcnt = COUNT(*)
			FROM mvendor 
			WHERE tstatus = 0 AND code NOT IN (SELECT code FROM mcust WHERE tstatus = 1) AND LEFT(code,2) = 'VN'; 
			
			IF @vcodelst = '' BEGIN
				SET @vcode = 'VN00001';
			END ELSE IF @vcnt > 0 BEGIN
				SELECT @vcode = MIN(code) 
				FROM mvendor
				WHERE tstatus = 0 AND code NOT IN (SELECT code FROM mcust WHERE tstatus = 1) AND LEFT(code,2) = 'VN';
			END ELSE BEGIN
				
				SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
				SET @vcode = 'VN' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
			END
		END
	ELSE IF @itbl = 'mlocation'
		BEGIN
			SELECT TOP 1 @vcodelst = ISNULL(MAX(code),'')
			FROM mlocation 
			WHERE tstatus = 1 AND LEFT(code,2) = 'LC';
			
			SELECT @vcnt = COUNT(*)
			FROM mlocation 
			WHERE tstatus = 0 AND code NOT IN (SELECT code FROM mcust WHERE tstatus = 1) AND LEFT(code,2) = 'VN'; 
			
			IF @vcodelst = '' BEGIN
				SET @vcode = 'LC00001';
			END ELSE IF @vcnt > 0 BEGIN
				SELECT @vcode = MIN(code) 
				FROM mlocation
				WHERE tstatus = 0 AND code NOT IN (SELECT code FROM mcust WHERE tstatus = 1) AND LEFT(code,2) = 'VN';
			END ELSE BEGIN
				
				SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
				SET @vcode = 'LC' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
			END
		END
			
	ELSE IF @itbl = 'tconsign'
	 	BEGIN
	 		SELECT TOP 1 @vcodelst = ISNULL(MAX(no),'')
	 		FROM tconsign 
	 		WHERE tstatus = 1 AND no LIKE 'CN/%' + @iprefix + '/%' ;
	 		
	 		
	 		IF @vcodelst = '' BEGIN
	 			SET @vcode = 'CN/' + @iprefix + '/00001'; 
	 		END ELSE BEGIN
	 			
	 			SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
	 			SET @vcode = 'CN/' + @iprefix + '/' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
	 		END
	 	END
	ELSE IF @itbl = 'tinvoice'
	 	BEGIN
	 		SELECT TOP 1 @vcodelst = ISNULL(MAX(no),'')
	 		FROM tinvoice 
	 		WHERE tstatus = 1 AND no LIKE 'IV/%' + @iprefix + '/%' ;
	 		
	 		
	 		IF @vcodelst = '' BEGIN
	 			SET @vcode = 'IV/' + @iprefix + '/00001'; 
	 		END ELSE BEGIN
	 			
	 			SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
	 			SET @vcode = 'IV/' + @iprefix + '/' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
	 		END
	 	END
	ELSE IF @itbl = 'tpo'
	 	BEGIN
	 		SELECT TOP 1 @vcodelst = ISNULL(MAX(no),'')
	 		FROM tpo 
	 		WHERE tstatus = 1 AND no LIKE 'PO/%' + @iprefix + '/%' ;
	 		
	 		
	 		IF @vcodelst = '' BEGIN
	 			SET @vcode = 'PO/' + @iprefix + '/00001'; 
	 		END ELSE BEGIN
	 			
	 			SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
	 			SET @vcode = 'PO/' + @iprefix + '/' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
	 		END
	 	END
	ELSE IF @itbl = 'tretinvoice'
	 	BEGIN
	 		SELECT TOP 1 @vcodelst = ISNULL(MAX(no),'')
	 		FROM tretinvoice 
	 		WHERE tstatus = 1 AND no LIKE 'RV/%' + @iprefix + '/%' ;
	 		
	 		
	 		IF @vcodelst = '' BEGIN
	 			SET @vcode = 'RV/' + @iprefix + '/00001'; 
	 		END ELSE BEGIN
	 			
	 			SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
	 			SET @vcode = 'RV/' + @iprefix + '/' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
	 		END
	 	END
	ELSE IF @itbl = 'topay'
	 	BEGIN
	 		SELECT TOP 1 @vcodelst = ISNULL(MAX(no),'')
	 		FROM topay 
	 		WHERE tstatus = 1 AND no LIKE 'OP/%' + @iprefix + '/%' ;
	 		
	 		
	 		IF @vcodelst = '' BEGIN
	 			SET @vcode = 'OP/' + @iprefix + '/00001'; 
	 		END ELSE BEGIN
	 			
	 			SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
	 			SET @vcode = 'OP/' + @iprefix + '/' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
	 		END
		END
	ELSE IF @itbl = 'tpy'
	 	BEGIN
	 		SELECT TOP 1 @vcodelst = ISNULL(MAX(no),'')
	 		FROM tpy 
	 		WHERE tstatus = 1 AND no LIKE 'PY/%' + @iprefix + '/%' ;
	 		
	 		
	 		IF @vcodelst = '' BEGIN
	 			SET @vcode = 'PY/' + @iprefix + '/00001'; 
	 		END ELSE BEGIN
	 			
	 			SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
	 			SET @vcode = 'PY/' + @iprefix + '/' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
	 		END
	 	END
	ELSE IF @itbl = 'tpc'
	 	BEGIN
	 		SELECT TOP 1 @vcodelst = ISNULL(MAX(no),'')
	 		FROM tpc
	 		WHERE tstatus = 1 AND no LIKE 'PC/%' + @iprefix + '/%' ;
	 		
	 		
	 		IF @vcodelst = '' BEGIN
	 			SET @vcode = 'PC/' + @iprefix + '/00001'; 
	 		END ELSE BEGIN
	 			
	 			SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
	 			SET @vcode = 'PC/' + @iprefix + '/' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
	 		END
	 	END
	ELSE IF @itbl = 'tps'
	 	BEGIN
	 		SELECT TOP 1 @vcodelst = ISNULL(MAX(no),'')
	 		FROM tps
	 		WHERE tstatus = 1 AND no LIKE 'PS/%' + @iprefix + '/%' ;
	 		
	 		
	 		IF @vcodelst = '' BEGIN
	 			SET @vcode = 'PS/' + @iprefix + '/00001'; 
	 		END ELSE BEGIN
	 			
	 			SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
	 			SET @vcode = 'PS/' + @iprefix + '/' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
	 		END
	 	END
	ELSE IF @itbl = 'tts'
	 	BEGIN
	 		SELECT TOP 1 @vcodelst = ISNULL(MAX(no),'')
	 		FROM tts
	 		WHERE tstatus = 1 AND no LIKE 'PT/%' + @iprefix + '/%' ;
	 		
	 		
	 		IF @vcodelst = '' BEGIN
	 			SET @vcode = 'PT/' + @iprefix + '/00001'; 
	 		END ELSE BEGIN
	 			
	 			SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
	 			SET @vcode = 'PT/' + @iprefix + '/' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
	 		END
	 	END
	ELSE IF @itbl = 'tinvj'
	 	BEGIN
	 		SELECT TOP 1 @vcodelst = ISNULL(MAX(no),'')
	 		FROM tinvj 
	 		WHERE tstatus = 1 AND no LIKE 'IJ/%' + @iprefix + '/%' ;
	 		
	 		
	 		IF @vcodelst = '' BEGIN
	 			SET @vcode = 'IJ/' + @iprefix + '/00001'; 
	 		END ELSE BEGIN
	 			
	 			SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
	 			SET @vcode = 'IJ/' + @iprefix + '/' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
	 		END
	 	END
	ELSE IF @itbl = 'tpop'
	 	BEGIN
	 		SELECT TOP 1 @vcodelst = ISNULL(MAX(no),'')
	 		FROM tpop 
	 		WHERE tstatus = 1 AND no LIKE 'PP/%' + @iprefix + '/%' ;
	 		
	 		
	 		IF @vcodelst = '' BEGIN
	 			SET @vcode = 'PP/' + @iprefix + '/00001'; 
	 		END ELSE BEGIN
	 			
	 			SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
	 			SET @vcode = 'PP/' + @iprefix + '/' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
	 		END
	 	END
	ELSE IF @itbl = 'trf'
	 	BEGIN
	 		SELECT TOP 1 @vcodelst = ISNULL(MAX(no),'')
	 		FROM trf 
	 		WHERE tstatus = 1 AND no LIKE 'RF/%' + @iprefix + '/%' ;
	 		
	 		
	 		IF @vcodelst = '' BEGIN
	 			SET @vcode = 'RF/' + @iprefix + '/00001'; 
	 		END ELSE BEGIN
	 			
	 			SET @vseqnew = CAST(RIGHT(@vcodelst,5) AS INT) + 1;
	 			SET @vcode = 'RF/' + @iprefix + '/' + RIGHT(REPLICATE('0',5) + CAST(@vseqnew AS VARCHAR(5)),5);
	 		END
	 	END
RETURN(@vcode);
END;
GO

-- function fcgetpayinv
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fcgetpayinv]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fcgetpayinv]
GO
CREATE FUNCTION dbo.fcgetpayinv
(
    @ino_trans		NVARCHAR(64)
)
RETURNS DECIMAL(19,6)
 AS
BEGIN
	DECLARE @cqty DECIMAL(19,6)
  
	SELECT @cqty = ISNULL(SUM(paytotal),0) FROM tpyd WHERE tstatus = 1
	and no_trans = @ino_trans and doctype = 'INV'
	
	RETURN ISNULL(@cqty,0);
	
END
GO

-- function fcgetpayinj
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fcgetpayinj]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fcgetpayinj]
GO
CREATE FUNCTION dbo.fcgetpayinj
(
    @ino_trans		NVARCHAR(64)
)
RETURNS DECIMAL(19,6)
 AS
BEGIN
	DECLARE @cqty DECIMAL(19,6)
  
	SELECT @cqty = ISNULL(SUM(paytotal),0) FROM tpyd WHERE tstatus = 1
	and no_trans = @ino_trans and doctype = 'INJ'
	
	RETURN ISNULL(@cqty,0);
	
END
GO

-- function fcgetpaypo
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fcgetpaypo]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fcgetpaypo]
GO
CREATE FUNCTION dbo.fcgetpaypo
(
    @ino_trans		NVARCHAR(64)
)
RETURNS DECIMAL(19,6)
 AS
BEGIN
	DECLARE @cqty DECIMAL(19,6)
  
	SELECT @cqty = ISNULL(SUM(paytotal),0) FROM tpyd WHERE tstatus = 1
	and no_trans = @ino_trans and doctype = 'PO'
	
	RETURN ISNULL(@cqty,0);
	
END
GO

-- function fcgetpaycons
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fcgetpaycons]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fcgetpaycons]
GO
CREATE FUNCTION dbo.fcgetpaycons
(
    @ino_trans		NVARCHAR(64)
)
RETURNS DECIMAL(19,6)
 AS
BEGIN
	DECLARE @cqty DECIMAL(19,6)
  
	SELECT @cqty = ISNULL(SUM(paytotal),0) FROM tpcd WHERE tstatus = 1
	and no_trans = @ino_trans and doctype = 'CNS'
	
	RETURN ISNULL(@cqty,0);
	
END
GO

-- function fcgetpayvend
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fcgetpayvend]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fcgetpayvend]
GO
CREATE FUNCTION dbo.fcgetpayvend
(
    @ino_trans		NVARCHAR(64)
)
RETURNS DECIMAL(19,6)
 AS
BEGIN
	DECLARE @cqty DECIMAL(19,6)
  
	SELECT @cqty = ISNULL(SUM(paytotal),0) FROM tpsd WHERE tstatus = 1
	and no_trans = @ino_trans and doctype = 'VND'
	
	RETURN ISNULL(@cqty,0);
	
END
GO


-- function fgetaccessories
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fgetaccessories]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].fgetaccessories
GO
CREATE FUNCTION dbo.fgetaccessories
(
	@iidtrans NVARCHAR(128)

)
RETURNS NVARCHAR(MAX)
 AS
BEGIN
	DECLARE @listStr NVARCHAR(MAX)
	;
	
	SELECT @listStr = COALESCE(@listStr+',' ,'') + A.spec FROM (
		SELECT 'ORIGINAL BOX' AS 'spec'
		FROM mitem T0 WHERE T0.spec1 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'ORIGINAL DUSTBAG'
		FROM mitem T0 WHERE T0.spec2 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'AUTHENTICITY CARD'
		FROM mitem T0 WHERE T0.spec3 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'MIRROR'
		FROM mitem T0 WHERE T0.spec4 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'BOOKLET'
		FROM mitem T0 WHERE T0.spec5 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'RECEIPT'
		FROM mitem T0 WHERE T0.spec6 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'STRAP'
		FROM mitem T0 WHERE T0.spec7 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'PADLOCK'
		FROM mitem T0 WHERE T0.spec8 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'KEY'
		FROM mitem T0 WHERE T0.spec9 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'DUSTBAG PENGGANTI'
		FROM mitem T0 WHERE T0.spec10 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'HOLLOW'
		FROM mitem T0 WHERE T0.spec11 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'TAG'
		FROM mitem T0 WHERE T0.spec12 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'PAPERBAG'
		FROM mitem T0 WHERE T0.spec13 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'RAINCOAT'
		FROM mitem T0 WHERE T0.spec14 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'CAMELIA'
		FROM mitem T0 WHERE T0.spec15 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'RIBBON/PITA'
		FROM mitem T0 WHERE T0.spec16 = 'Y' AND code = @iidtrans 
		UNION ALL
		SELECT 'SAMPLE LEATHER'
		FROM mitem T0 WHERE T0.spec17 = 'Y' AND code = @iidtrans 
		UNION ALL
		SELECT 'COPY RECEIPT'
		FROM mitem T0 WHERE T0.spec18 = 'Y' AND code = @iidtrans
		UNION ALL
		SELECT 'LAP'
		FROM mitem T0 WHERE T0.spec19 = 'Y' AND code = @iidtrans	
		UNION ALL
		SELECT ISNULL(T0.notespec,'')
		FROM mitem T0 WHERE code = @iidtrans		) A
		;
	
	RETURN @listStr;
	
END
GO

-- function fgetdatepayinvoice
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fgetdatepayinvoice]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fgetdatepayinvoice]
GO
CREATE FUNCTION dbo.fgetdatepayinvoice
(
    @ino_trans		NVARCHAR(64)
)
RETURNS DATETIME
 AS
BEGIN
	DECLARE @cqty DATETIME
  
	SELECT @cqty = T1.tdate FROM tpcd T0 INNER JOIN tpc T1 ON T0.id_tpch = T1.id WHERE T0.tstatus = 1
	AND T1.tstatus = 1
	and T0.no_trans = @ino_trans and doctype = 'CNS'
	
	RETURN @cqty;
	
END
GO