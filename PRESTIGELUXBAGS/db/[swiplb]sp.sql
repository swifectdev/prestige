
-- procedure ssortnotgrgi
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ssortnotgrgi') AND type in (N'P', N'PC'))
DROP PROCEDURE	ssortnotgrgi
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE ssortnotgrgi
	@itemp			INT	
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE 
		@vidmin 		AS INT
		, @vidmax		AS INT
	;
	
	SET @vidmin = 0;
	SET @vidmax = 0;
	
	-- GR
	SELECT @vidmin = MIN(id) FROM tgr WHERE tstatus = 1;
	SELECT @vidmax = MAX(id) FROM tgr WHERE tstatus = 1;
	
	WHILE (@vidmin <= @vidmax AND @vidmin <> 0) BEGIN
		UPDATE tgr SET
			no = dbo.fgetcode('tgr',YEAR(tdate))
		WHERE
			id = @vidmin;
		
		SELECT @vidmin = MIN(id) FROM tgr WHERE id > @vidmin AND tstatus = 1;
	END
	
	-- GI
	SELECT @vidmin = MIN(id) FROM tgi WHERE tstatus = 1;
	SELECT @vidmax = MAX(id) FROM tgi WHERE tstatus = 1;
	
	WHILE (@vidmin <= @vidmax AND @vidmin <> 0) BEGIN
		UPDATE tgi SET
			no = dbo.fgetcode('tgi',YEAR(tdate))
		WHERE
			id = @vidmin;
		
		SELECT @vidmin = MIN(id) FROM tgi WHERE id > @vidmin AND tstatus = 1;
	END
END
GO

-- procedure shtrans
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'shtrans') AND type in (N'P', N'PC'))
DROP PROCEDURE	shtrans
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE shtrans
	@itbl				NVARCHAR(16) 
	, @iidtbl			INT
	, @inotbl			NVARCHAR(64)
	, @iact				NVARCHAR(8)
	, @inote				NVARCHAR(256)
	, @iusr				INT	
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO htrans (
		tbl			
		, idtbl	
		, notbl
		, act				
		, note
		, createduser
	) VALUES (
		@itbl			
		, @iidtbl
		, @inotbl
		, @iact			
		, @inote
		, @iusr
	);
	
END
GO

-- procedure shuserlog
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'shuserlog') AND type in (N'P', N'PC'))
DROP PROCEDURE	shuserlog
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE shuserlog
	@iid_cusr				INT
	, @iact				NVARCHAR(8) 
	, @inote				NVARCHAR(256)
	, @iusr				INT	
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE 
		@vlastact 	NVARCHAR(8)
	;
	
	SELECT TOP 1 @vlastact = act FROM huserlog WHERE id_cusr = @iid_cusr ORDER BY id DESC;
	
	IF @vlastact = 'LOGIN' BEGIN
		INSERT INTO huserlog (
			id_cusr		
			, code_cusr	
			, name_cusr
			, act
			, note
			, createduser
		) VALUES (
			@iid_cusr		
			, (SELECT code FROM cusr WHERE id = @iid_cusr)	
			, (SELECT name FROM cusr WHERE id = @iid_cusr)	
			, 'LOGOUT'		
			, 'FORCE LOGOUT'
			, @iusr
		);
	END
	
	INSERT INTO huserlog (
		id_cusr		
        , code_cusr	
        , name_cusr	
        , act
		, note
		, createduser
	) VALUES (
		@iid_cusr		
		, (SELECT code FROM cusr WHERE id = @iid_cusr)	
		, (SELECT name FROM cusr WHERE id = @iid_cusr)	
		, @iact			
		, @inote
		, @iusr
	);
	
END
GO

-- procedure shmstr
-- EXEC shmstr '','','','descrip','note',1,1;

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'shmstr') AND type in (N'P', N'PC'))
DROP PROCEDURE	shmstr
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE shmstr
	@itbl				NVARCHAR(16) 
	, @iidtbl			INT
	, @inotbl			NVARCHAR(64)
	, @iact				NVARCHAR(8)
	, @inote				NVARCHAR(256)
	, @iusr				INT	
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO hmstr (
		tbl			
		, idtbl		
		, notbl
		, act			
		, note
		, createduser
	) VALUES (
		@itbl			
		, @iidtbl
		, @inotbl
		, @iact				
		, @inote
		, @iusr
	);
	
END
GO



-- procedure shconf
-- EXEC shconf '','','','descrip','note',1,1;

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'shconf') AND type in (N'P', N'PC'))
DROP PROCEDURE	shconf
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE shconf
	@itbl				NVARCHAR(16) 
	, @iidtbl			INT
	, @iact				NVARCHAR(8)
	, @inote				NVARCHAR(256)
	, @iusr				INT	
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO hconf (
		tbl			
		, idtbl		
		, act			
		, note
		, createduser
	) VALUES (
		@itbl			
		, @iidtbl		
		, @iact				
		, @inote
		, @iusr
	);
	
END
GO

-- procedure scusr
-- EXEC scusr 'UOM00001','BOX','',1,1,'new',0;

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'scusr') AND type in (N'P', N'PC'))
DROP PROCEDURE	scusr
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE scusr
	@icode					NVARCHAR(16)
	, @iname					NVARCHAR(32)
	, @iusername				NVARCHAR(32)
	, @ipass					VARCHAR(32)
	, @ishowmenu				NVARCHAR(1)
	, @iid_mcost			INT
	, @inote					NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @vdesc					VARCHAR(512);
	
	IF @iact = 'new' BEGIN
	
		INSERT INTO cusr (
			code
			, name
			, username
			, pass
			, showmenu
			, id_mcost
			, note
			, createduser
		) VALUES (
			@icode
			, @iname
			, @iusername
			, CONVERT(NVARCHAR(32),HASHBYTES('MD5', '12345'),2)
			, @ishowmenu
			, @iid_mcost
			, @inote
			, @iusr
		);
		
		SELECT TOP 1 @iid = id FROM cusr WHERE createduser = @iusr ORDER BY id DESC;
		
		INSERT INTO cusrpriv (id_cusr, id_capp, code_capp, name_capp, canopen, canadd, canupdate, candelete, canprint, createduser)
		(SELECT @iid, TA.id, TA.code, TA.name, 'Y','Y','Y','Y','Y', @iusr FROM capp TA);
			
	
	END ELSE IF @iact = 'rpass' BEGIN
		
		UPDATE cusr SET 
			pass 			= CONVERT(VARCHAR(32),HASHBYTES('MD5', '12345'),2)
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
			
	END ELSE IF @iact = 'cpass' BEGIN
		
		UPDATE cusr SET 
			pass 			= CONVERT(NVARCHAR(32),HASHBYTES('MD5', @ipass),2)
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;		
			
	END ELSE IF @iact = 'upd' BEGIN
		
		UPDATE cusr SET 
			code 			= @icode
			, name 			= @iname
			, username		= @iusername
			, showmenu		= @ishowmenu
			, id_mcost		= @iid_mcost
			, note 			= @inote
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
			
	END ELSE IF @iact = 'del' BEGIN
		
		UPDATE cusr SET 
			tstatus = 0
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
		
		UPDATE cusrpriv SET 
			tstatus = 0
		WHERE
			id_cusr = @iid
	END
	
	EXEC shconf 
		'cusr'
		, @iid
		, @iact
		, ''
		, @iusr
	;
		
END
GO


-- procedure smlocation
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'smlocation') AND type in (N'P', N'PC'))
DROP PROCEDURE	smlocation
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE smlocation
	@icode			NVARCHAR(64) 
	, @iname			NVARCHAR(128) 
	--------------------------------
	, @inote			NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @vdesc					VARCHAR(512);
		
	IF @iact = 'new' BEGIN
	
		INSERT INTO mlocation (
			 code				
			, name				
			--------------------------------
			, note				
			, createduser
		) VALUES (
			 @icode				
			, @iname				
			--------------------------------
			, @inote
			, @iusr
		);
		
		SELECT TOP 1 @iid = id FROM mlocation WHERE createduser = @iusr ORDER BY id DESC;
		
	END ELSE IF @iact = 'upd' BEGIN
		
		UPDATE mlocation SET 						
			 code			=	@icode
			, name			=	@iname
			--------------------------------
			, note			=	@inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
		
	END ELSE IF @iact = 'del' BEGIN
		
		UPDATE mlocation SET 
			tstatus = 0
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
			
	END
	
	EXEC shmstr 
		'MASTER LOKASI'
		, @iid
		, @icode
		, @iact
		, 'MASTER LOKASI'
		, @iusr
	;
END
GO

-- procedure smaccount
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'smaccount') AND type in (N'P', N'PC'))
DROP PROCEDURE	smaccount
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE smaccount
	@icode			NVARCHAR(64) 
	, @iname			NVARCHAR(128) 
	--------------------------------
	, @inote			NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @vdesc					VARCHAR(512);
		
	IF @iact = 'new' BEGIN
	
		INSERT INTO maccount (
			 code				
			, name				
			--------------------------------
			, note				
			, createduser
		) VALUES (
			 @icode				
			, @iname				
			--------------------------------
			, @inote
			, @iusr
		);
		
		SELECT TOP 1 @iid = id FROM maccount WHERE createduser = @iusr ORDER BY id DESC;
		
	END ELSE IF @iact = 'upd' BEGIN
		
		UPDATE maccount SET 						
			 code			=	@icode
			, name			=	@iname
			--------------------------------
			, note			=	@inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
		
	END ELSE IF @iact = 'del' BEGIN
		
		UPDATE maccount SET 
			tstatus = 0
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
			
	END
	
	EXEC shmstr 
		'MASTER REKENING'
		, @iid
		, @icode
		, @iact
		, 'MASTER REKENING'
		, @iusr
	;
END
GO

-- procedure smconsignee
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'smconsignee') AND type in (N'P', N'PC'))
DROP PROCEDURE	smconsignee
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE smconsignee
	@icode			NVARCHAR(64) 
	, @iname			NVARCHAR(128)
	, @iktp				NVARCHAR(32)	
	, @igender			NVARCHAR(32) 
	, @ihp1				NVARCHAR(32)
	, @ihp2				NVARCHAR(32)
	, @inorek			NVARCHAR(128)
	, @ialamat			NVARCHAR(128) 
	--------------------------------
	, @inote			NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @vdesc					VARCHAR(512);
		
	IF @iact = 'new' BEGIN
	
		INSERT INTO mconsignee (
			 code				
			, name
			, ktp
			, gender			
			, hp1				
			, hp2				
			, norek				
			, alamat			
			--------------------------------
			, note				
			, createduser			
		) VALUES (
			@icode				
			, @iname
			, @iktp
			, @igender			
			, @ihp1				
			, @ihp2				
			, @inorek				
			, @ialamat			
			--------------------------------
			, @inote
			, @iusr	
		);
		
		SELECT TOP 1 @iid = id FROM mconsignee WHERE createduser = @iusr ORDER BY id DESC;
		
	END ELSE IF @iact = 'upd' BEGIN
		
		UPDATE mconsignee SET 				
			 code			=	@icode
			, name			=	@iname
			, ktp			=	@iktp
			, gender		=	@igender
			, hp1			=	@ihp1
			, hp2			=	@ihp2
			, norek			=	@inorek
			, alamat		=	@ialamat
			--------------------------------
			, note 				= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
		
	END ELSE IF @iact = 'del' BEGIN
		
		UPDATE mconsignee SET 
			tstatus = 0
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
			
	END
	
	EXEC shmstr 
		'MASTER CONSIGNEE'
		, @iid
		, @icode
		, @iact
		, 'MASTER COSIGNEE'
		, @iusr
	;
END
GO

-- procedure smcust
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'smcust') AND type in (N'P', N'PC'))
DROP PROCEDURE	smcust
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE smcust
	@icode			NVARCHAR(64) 
	, @iname			NVARCHAR(128) 
	, @igender			NVARCHAR(32) 
	, @ihp1				NVARCHAR(32)
	, @ihp2				NVARCHAR(32)
	, @iemail				NVARCHAR(64)
	, @isocmed			NVARCHAR(64)
	, @inorek			NVARCHAR(128)
	, @ialamat			NVARCHAR(128) 
	--------------------------------
	, @inote			NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @vdesc					VARCHAR(512);
		
	IF @iact = 'new' BEGIN
	
		INSERT INTO mcust (
			 code				
			, name				
			, gender			
			, hp1				
			, hp2
			, email				
			, socmed					
			, norek				
			, alamat			
			--------------------------------
			, note				
			, createduser			
		) VALUES (
			@icode				
			, @iname				
			, @igender			
			, @ihp1				
			, @ihp2		
			, @iemail				
			, @isocmed			
			, @inorek				
			, @ialamat			
			--------------------------------
			, @inote
			, @iusr	
		);
		
		SELECT TOP 1 @iid = id FROM mcust WHERE createduser = @iusr ORDER BY id DESC;
		
	END ELSE IF @iact = 'upd' BEGIN
		
		UPDATE mcust SET 				
			 code			=	@icode
			, name			=	@iname
			, gender		=	@igender
			, hp1			=	@ihp1
			, hp2			=	@ihp2
			, email			=	@iemail
			, socmed		=	@isocmed
			, norek			=	@inorek
			, alamat		=	@ialamat
			--------------------------------
			, note 				= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
		
	END ELSE IF @iact = 'del' BEGIN
		
		UPDATE mcust SET 
			tstatus = 0
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
			
	END
	
	EXEC shmstr 
		'MASTER CUSTOMER'
		, @iid
		, @icode
		, @iact
		, 'MASTER CUSTOMER'
		, @iusr
	;
END
GO

-- procedure smsales
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'smsales') AND type in (N'P', N'PC'))
DROP PROCEDURE	smsales
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE smsales
	@icode			NVARCHAR(64) 
	, @iname			NVARCHAR(128) 
	, @igender			NVARCHAR(32) 
	, @ihp1				NVARCHAR(32)
	, @ihp2				NVARCHAR(32)
	, @ialamat			NVARCHAR(128) 
	--------------------------------
	, @inote			NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @vdesc					VARCHAR(512);
		
	IF @iact = 'new' BEGIN
	
		INSERT INTO msales (
			 code				
			, name				
			, gender			
			, hp1				
			, hp2				
			, alamat			
			--------------------------------
			, note				
			, createduser			
		) VALUES (
			@icode				
			, @iname				
			, @igender			
			, @ihp1				
			, @ihp2					
			, @ialamat			
			--------------------------------
			, @inote
			, @iusr	
		);
		
		SELECT TOP 1 @iid = id FROM msales WHERE createduser = @iusr ORDER BY id DESC;
		
	END ELSE IF @iact = 'upd' BEGIN
		
		UPDATE msales SET 				
			 code			=	@icode
			, name			=	@iname
			, gender		=	@igender
			, hp1			=	@ihp1
			, hp2			=	@ihp2
			, alamat		=	@ialamat
			--------------------------------
			, note 				= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
		
	END ELSE IF @iact = 'del' BEGIN
		
		UPDATE msales SET 
			tstatus = 0
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
			
	END
	
	EXEC shmstr 
		'MASTER SALES'
		, @iid
		, @icode
		, @iact
		, 'MASTER SALES'
		, @iusr
	;
END
GO

-- procedure smcurr
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'smcurr') AND type in (N'P', N'PC'))
DROP PROCEDURE	smcurr
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE smcurr
	@icode			NVARCHAR(64) 
	, @iname			NVARCHAR(128) 
	--------------------------------
	, @inote			NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @vdesc					VARCHAR(512);
		
	IF @iact = 'new' BEGIN
	
		INSERT INTO mcurr (
			 code				
			, name		
			--------------------------------
			, note				
			, createduser			
		) VALUES (
			 @icode				
			, @iname		
			--------------------------------
			, @inote
			, @iusr		
		);
		
		SELECT TOP 1 @iid = id FROM mcurr WHERE createduser = @iusr ORDER BY id DESC;
		
	END ELSE IF @iact = 'upd' BEGIN
		
		UPDATE mcurr SET 
			code			=	@icode
			, name			=	@iname
			--------------------------------
			, note 				= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
		
	END ELSE IF @iact = 'del' BEGIN
		
		UPDATE mcurr SET 
			tstatus = 0
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
			
	END
	
	EXEC shmstr 
		'MASTER MATA UANG'
		, @iid
		, @icode
		, @iact
		, 'MASTER MATA UANG'
		, @iusr
	;
END
GO

-- procedure smitem
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'smitem') AND type in (N'P', N'PC'))
DROP PROCEDURE	smitem
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE smitem
	@ino			NVARCHAR(64) 
	, @icode			NVARCHAR(64) 
	, @iname			NVARCHAR(256) 
	, @idtconsign		DATETIME
	, @icode_mconsign	NVARCHAR(64) 
	, @icode_mtype		NVARCHAR(64) 
	, @iqty				DECIMAL(19,6)
	, @icode_muom		NVARCHAR(64) 
	, @icode_mbrand		NVARCHAR(64) 
	, @icode_mcurrb		NVARCHAR(64) 
	, @ihrgbeli			DECIMAL(20,6) 
	, @icode_mcurrj		NVARCHAR(64) 
	, @ihrgjual			DECIMAL(20,6) 
	, @ispek			NVARCHAR(MAX) 
	--------------------------------
	, @icolor				NVARCHAR(64)
	, @isze				NVARCHAR(32)
	, @imtrl				NVARCHAR(64)
	--------------------------------
	, @icode_mlocation	NVARCHAR(64)
	--------------------------------
	, @ibasetype			NVARCHAR(8)
	, @ibasenum			NVARCHAR(128)
	--------------------------------
	, @ispec1          NVARCHAR(1)
	, @ispec2          NVARCHAR(1)
	, @ispec3          NVARCHAR(1)
	, @ispec4          NVARCHAR(1)
	, @ispec5          NVARCHAR(1)
	, @ispec6          NVARCHAR(1)
	, @ispec7          NVARCHAR(1)
	, @ispec8          NVARCHAR(1)
	, @ispec9          NVARCHAR(1)
	, @ispec10          NVARCHAR(1)
	, @ispec11          NVARCHAR(1)
	, @ispec12          NVARCHAR(1)
	, @ispec13          NVARCHAR(1)
	, @ispec14          NVARCHAR(1)
	, @ispec15          NVARCHAR(1)
	, @ispec16          NVARCHAR(1)
	, @ispec17          NVARCHAR(1)
	, @ispec18          NVARCHAR(1)
	, @ispec19          NVARCHAR(1)
	, @inotespec			NVARCHAR(256)
	, @icode_mvendor		NVARCHAR(64) 
	--------------------------------
	, @inote			NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @vdesc					VARCHAR(512);
		
	IF @iact = 'new' BEGIN
	
		INSERT INTO mitem (
			no
			, code				
			, name			
			, dtconsign
			, code_mconsign		
			, code_mtype	
			, qty
			, code_muom			
			, code_mbrand		
			, code_mcurrb		
			, hrgbeli			
			, code_mcurrj	
			, hrgjual			
			, spek				
			--------------------------------
			, color				
			, sze				
			, mtrl							
			--------------------------------
			, code_mlocation
			--------------------------------
			, basetype
			, basenum
			--------------------------------
			, spec1       
			, spec2       
			, spec3       
			, spec4       
			, spec5       
			, spec6       
			, spec7       
			, spec8       
			, spec9       
			, spec10      
			, spec11      
			, spec12      
			, spec13      
			, spec14
			, spec15
			, spec16
			, spec17
			, spec18
			, spec19			
			, notespec		
			, code_mvendor
			--------------------------------
			, note				
			, createduser		
		) VALUES (
			@ino
			, @icode				
			, @iname	
			, @idtconsign
			, @icode_mconsign		
			, @icode_mtype
			, @iqty
			, @icode_muom			
			, @icode_mbrand		
			, @icode_mcurrb		
			, @ihrgbeli			
			, @icode_mcurrj	
			, @ihrgjual			
			, @ispek	
			-------------------------------
			, @icolor				
			, @isze				
			, @imtrl			
			--------------------------------
			, @icode_mlocation
			--------------------------------
			, @ibasetype
			, @ibasenum
			--------------------------------
			, @ispec1       
			, @ispec2       
			, @ispec3       
			, @ispec4       
			, @ispec5       
			, @ispec6       
			, @ispec7       
			, @ispec8       
			, @ispec9       
			, @ispec10      
			, @ispec11      
			, @ispec12      
			, @ispec13      
			, @ispec14
			, @ispec15
			, @ispec16
			, @ispec17
			, @ispec18
			, @ispec19
			, @inotespec	
			, @icode_mvendor
			--------------------------------
			, @inote
			, @iusr		
		);
		
		SELECT TOP 1 @iid = id FROM mitem WHERE createduser = @iusr ORDER BY id DESC;
		
	END ELSE IF @iact = 'upd' BEGIN
		
		UPDATE mitem SET 					
			no				= @ino
			, code			= @icode	
			, name			= @iname
			, dtconsign		= @idtconsign
			, code_mconsign	= @icode_mconsign
			, code_mtype	= @icode_mtype
			, qty			= @iqty
			, code_muom		= @icode_muom
			, code_mbrand	= @icode_mbrand
			, code_mcurrb	= @icode_mcurrb
			, hrgbeli		= @ihrgbeli
			, code_mcurrj	= @icode_mcurrj
			, hrgjual		= @ihrgjual
			, spek			= @ispek
			--------------------------------
			, color			= @icolor	
			, sze			= @isze
			, mtrl			= @imtrl
			--------------------------------
			, code_mlocation	= @icode_mlocation
			--------------------------------
			, basetype		= @ibasetype
			, basenum		= @ibasenum
			--------------------------------
			, spec1       = @ispec1
			, spec2       = @ispec2
			, spec3       = @ispec3
			, spec4       = @ispec4
			, spec5       = @ispec5
			, spec6       = @ispec6
			, spec7       = @ispec7
			, spec8       = @ispec8
			, spec9       = @ispec9
			, spec10      = @ispec10
			, spec11      = @ispec11
			, spec12      = @ispec12
			, spec13      = @ispec13
			, spec14      = @ispec14
			, spec15      = @ispec15
			, spec16      = @ispec16
			, spec17      = @ispec17
			, spec18      = @ispec18
			, spec19      = @ispec19
			, notespec		= @inotespec
			, code_mvendor	= @icode_mvendor
			--------------------------------
			, note 				= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
		
		UPDATE mitempic SET 
			tstatus = 0
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			code = @icode;
			
	END ELSE IF @iact = 'del' BEGIN
		
		UPDATE mitem SET 
			tstatus = 0
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
			
		
		UPDATE mitempic SET 
			tstatus = 0
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			code = @icode;
			
	END
	
	EXEC shmstr 
		'MASTER BARANG'
		, @iid
		, @icode
		, @iact
		, 'MASTER BARANG'
		, @iusr
	;
END
GO


-- procedure smtype
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'smtype') AND type in (N'P', N'PC'))
DROP PROCEDURE	smtype
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE smtype
	@icode			NVARCHAR(64) 
	, @iname			NVARCHAR(128) 
	--------------------------------
	, @inote			NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @vdesc					VARCHAR(512);
		
	IF @iact = 'new' BEGIN
	
		INSERT INTO mtype (
			 code				
			, name					
			--------------------------------
			, note				
			, createduser		
		) VALUES (
			 @icode				
			, @iname	
			--------------------------------
			, @inote
			, @iusr	
		);
		
		SELECT TOP 1 @iid = id FROM mtype WHERE createduser = @iusr ORDER BY id DESC;
		
	END ELSE IF @iact = 'upd' BEGIN
		
		UPDATE mtype SET 							
			 code			=	@icode
			, name			=	@iname
			--------------------------------
			, note 				= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
		
	END ELSE IF @iact = 'del' BEGIN
		
		UPDATE mtype SET 
			tstatus = 0
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
			
	END
	
	EXEC shmstr 
		'MASTER JENIS BARANG'
		, @iid
		, @icode
		, @iact
		, 'MASTER JENIS BARANG'
		, @iusr
	;
END
GO

-- procedure smbrand
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'smbrand') AND type in (N'P', N'PC'))
DROP PROCEDURE	smbrand
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE smbrand
	@icode			NVARCHAR(64) 
	, @iname			NVARCHAR(128) 
	--------------------------------
	, @inote			NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @vdesc					VARCHAR(512);
		
	IF @iact = 'new' BEGIN
	
		INSERT INTO mbrand (
			 code				
			, name					
			--------------------------------
			, note				
			, createduser			
		) VALUES (
			@icode				
			, @iname	
			--------------------------------
			, @inote
			, @iusr		
		);
		
		SELECT TOP 1 @iid = id FROM mbrand WHERE createduser = @iusr ORDER BY id DESC;
		
	END ELSE IF @iact = 'upd' BEGIN
		
		UPDATE mbrand SET 
			code			=	@icode
			, name			=	@iname
			--------------------------------
			, note 				= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
		
	END ELSE IF @iact = 'del' BEGIN
		
		UPDATE mbrand SET 
			tstatus = 0
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
			
	END
	
	EXEC shmstr 
		'MASTER MERK'
		, @iid
		, @icode
		, @iact
		, 'MASTER MERK'
		, @iusr
	;
END
GO

-- procedure smvendor
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'smvendor') AND type in (N'P', N'PC'))
DROP PROCEDURE	smvendor
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE smvendor
	@icode			NVARCHAR(64) 
	, @iname			NVARCHAR(128) 
	, @iphone			NVARCHAR(128) 
	, @inorek			NVARCHAR(128)
	, @ialamat			NVARCHAR(128) 
	--------------------------------
	, @inote			NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @vdesc					VARCHAR(512);
		
	IF @iact = 'new' BEGIN
	
		INSERT INTO mvendor (
			 code				
			, name				
			, phone				
			, norek				
			, alamat									
			--------------------------------
			, note				
			, createduser		
		) VALUES (
			@icode				
			, @iname				
			, @iphone				
			, @inorek				
			, @ialamat	
			--------------------------------
			, @inote
			, @iusr	
		);
		
		SELECT TOP 1 @iid = id FROM mvendor WHERE createduser = @iusr ORDER BY id DESC;
		
	END ELSE IF @iact = 'upd' BEGIN
		
		UPDATE mvendor SET 
			code			=	@icode
			, name			=	@iname
			, phone			=	@iphone
			, norek			=	@inorek
			, alamat		=	@ialamat
			--------------------------------
			, note 				= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
		
	END ELSE IF @iact = 'del' BEGIN
		
		UPDATE mvendor SET 
			tstatus = 0
			, modifieduser	= @iusr
			, modifieddate	= CURRENT_TIMESTAMP
		WHERE
			id = @iid;
			
	END
	
	EXEC shmstr 
		'MASTER VENDOR'
		, @iid
		, @icode
		, @iact
		, 'MASTER VENDOR'
		, @iusr
	;
END
GO

-- procedure smcoa
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'smcoa') AND type in (N'P', N'PC'))
DROP PROCEDURE	smcoa
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE smcoa
	@icode 					NVARCHAR(15) 
	, @iname 					NVARCHAR(200)
	, @iname2 					NVARCHAR(200)
	, @iusename					NVARCHAR(1)
	, @iusename2				NVARCHAR(1)
	, @icategory				INT
	-- ######################################
	-- ######################################
	, @iid_mcoatype				INT
	, @iid_mcoap				INT
	-- ######################################
	, @iactive				NVARCHAR(1)
	, @idc				INT
	, @irpttype			NVARCHAR(1)
	, @irptcattype		NVARCHAR(128)
	, @irptcattype2		NVARCHAR(128)
	-- ######################################
	, @iid_mcurr		INT
	, @ictrlacc		NVARCHAR(1)
	, @icashacc		NVARCHAR(1)
	-- ######################################
	, @inote						NVARCHAR(256)
	, @iusr							INT	
	, @iact							VARCHAR(8)
	, @iid							INT
AS
	BEGIN
	
	DECLARE @vidh INT;
		
				
		IF @iact = 'new' BEGIN
			INSERT INTO mcoa (
				code 					
				, name 
				, name2
				, usename
				, usename2
				, category
				, id_mcoatype
				, id_mcoap
				, active
				, dc
				, rpttype	
				, rptcattype
				, rptcattype2
				, id_mcurr
				, ctrlacc
				, cashacc
                , note	
				, createduser
			) VALUES (
				@icode 					
				, @iname 	
				, @iname2
				, @iusename
				, @iusename2
				, @icategory
				, @iid_mcoatype
				, @iid_mcoap
				, @iactive
				, @idc
				, @irpttype	
				, @irptcattype
				, @irptcattype2
				, @iid_mcurr
				, @ictrlacc
				, @icashacc
                , @inote	
				, @iusr
			);
			
			SELECT TOP 1 @iid  = id FROM mcoa WHERE createduser = @iusr ORDER BY id DESC ;
				
		END ELSE IF @iact = 'upd' BEGIN
			
			UPDATE mcoa SET 
				code 					= @icode
				, name 				= @iname
				, name2				= @iname2
				, usename			= @iusename
				, usename2			= @iusename2
				, category			= @icategory
				, id_mcoatype		= @iid_mcoatype
				, id_mcoap			= @iid_mcoap
				, active			= @iactive
				, dc				= @idc
				, rpttype			= @irpttype
				, rptcattype		= @irptcattype
				, rptcattype2		= @irptcattype2
				, id_mcurr			= @iid_mcurr
				, ctrlacc			= @ictrlacc
				, cashacc			= @icashacc
                , note	            = @inote
			WHERE 
				id = @iid;
				
		END ELSE IF @iact = 'del' BEGIN
		
			UPDATE mcoa SET 
				tstatus = 0
			WHERE 
				id = @iid;
		
		END
		
		EXEC shmstr 
		'CHART OF ACCOUNTS'
		, @iid
		, @icode
		, @iact
		, ''
		, @iusr
   END
GO

-- procedure stconsign
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stconsign') AND type in (N'P', N'PC'))
DROP PROCEDURE	stconsign
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stconsign
		@ino					NVARCHAR(64) 
		, @itdate					DATETIME 
		, @itdate2					DATETIME 
		-- ######################################
		, @icode_mconsignee		NVARCHAR(32)
		, @iname_mconsignee		NVARCHAR(128)
		, @ihp1					NVARCHAR(64)
		, @ihp2					NVARCHAR(64)
		, @ialamat				NVARCHAR(128) 
		, @igender				NVARCHAR(32)
		, @inorek				NVARCHAR(128)
		, @icatat					NVARCHAR(256) 
		-- ######################################
		, @icode_mitem			NVARCHAR(128)
		, @iname_mitem			NVARCHAR(128)
		, @icode_mtype			NVARCHAR(64)
		, @iqty					DECIMAL(19,6)
		, @icode_muom			NVARCHAR(128)
		, @icode_mbrand			NVARCHAR(128)
		, @ispek_mitem			NVARCHAR(512)
		-- ######################################
		, @icode_mcurrb			NVARCHAR(32)
		, @ihrgbeli				DECIMAL(20,6) 
		, @icode_mcurrj			NVARCHAR(32)
		, @ihrgjual				DECIMAL(20,6) 
		-- ######################################
		, @inote				NVARCHAR(256)
		, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			INSERT INTO tconsign (
				 no					
				, tdate
				, tdate2				
				-- ######################################
				, code_mconsignee		
				, name_mconsignee		
				, hp1					
				, hp2					
				, alamat
				, gender
				, norek
				, catat					
				-- ######################################
				, code_mitem			
				, name_mitem	
				, code_mtype			
				, qty
				, code_muom
				, code_mbrand	
				, spek_mitem
				-- ######################################
				, code_mcurrb			
				, hrgbeli				
				, code_mcurrj			
				, hrgjual						
				-- ######################################
				, note				
			, createduser	
			) VALUES (
				@ino					
				, @itdate
				, @itdate2				
				-- ######################################
				, @icode_mconsignee		
				, @iname_mconsignee		
				, @ihp1					
				, @ihp2					
				, @ialamat	
				, @igender
				, @inorek
				, @icatat					
				-- ######################################
				, @icode_mitem			
				, @iname_mitem	
				, @icode_mtype	
				, @iqty
				, @icode_muom
				, @icode_mbrand	
				, @ispek_mitem
				-- ######################################
				, @icode_mcurrb			
				, @ihrgbeli				
				, @icode_mcurrj			
				, @ihrgjual		
				-- ######################################
				, @inote
			, @iusr	
			);
			
			SELECT TOP 1id = @iid FROM tconsign ORDER BY id DESC;
				
		END ELSE IF @iact = 'upd' BEGIN
			
			UPDATE tconsign SET 
				no				=	@ino	
				, tdate				=	@itdate
				, tdate2			=	@itdate2
				-- ######################################
				, code_mconsignee	=	@icode_mconsignee
				, name_mconsignee	=	@iname_mconsignee
				, hp1				=	@ihp1
				, hp2				=	@ihp2
				, alamat			=	@ialamat
				, gender			= 	@igender
				, norek			 	= 	@inorek
				, catat				=	@icatat
				-- ######################################
				, code_mitem		=	@icode_mitem
				, name_mitem		=	@iname_mitem
				, code_mtype		=	@icode_mtype
				, qty				= 	@iqty
				, code_muom			= 	@icode_muom
				, code_mbrand		= 	@icode_mbrand
				, spek_mitem		= 	@ispek_mitem
				-- ######################################
				, code_mcurrb		=	@icode_mcurrb
				, hrgbeli			=	@ihrgbeli
				, code_mcurrj		=	@icode_mcurrj
				, hrgjual			=	@ihrgjual
				-- ######################################
				, note 				= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				id = @iid;
		
			UPDATE tconsignpic SET 
				tstatus = 0
				, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				no_tconsign = @ino;
				
		END ELSE IF @iact = 'del' BEGIN
		
			UPDATE tconsign SET 
				tstatus = 0
				, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				id = @iid;
			
			UPDATE tconsignpic SET 
				tstatus = 0
				, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				no_tconsign = @ino;
	
		END;
		
		EXEC shtrans 
		'CONSIGNMENT'
		, @iid
		, @ino
		, @iact
		, 'CONSIGNMENT'
		, @iusr
END
GO

-- procedure stpop
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stpop') AND type in (N'P', N'PC'))
DROP PROCEDURE	stpop
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stpop
	 @ino					NVARCHAR(64) 
	, @itdate				DATETIME 
	, @idocstat				NVARCHAR(64)
	, @isales				NVARCHAR(128)
	-- ######################################
	, @icode_mvendor		VARCHAR(64)
	, @iname_mvendor		VARCHAR(128)
	, @ihp1					NVARCHAR(64)
	, @ialamat				NVARCHAR(128) 
	, @inorek				NVARCHAR(128)
	-- ######################################
	, @icode_mitem			NVARCHAR(128)
	, @iname_mitem			NVARCHAR(256)
	, @icode_mtype			NVARCHAR(64)
	, @iqty					DECIMAL(19,6) 
	, @icode_muom			NVARCHAR(64)
	, @icode_mbrand			NVARCHAR(64)
	, @ispek_mitem			NVARCHAR(512)
	-- ######################################
	, @icode_mcurrb			NVARCHAR(16)
	, @ihrgbeli				DECIMAL(19,6)
	, @icode_mcurrj			NVARCHAR(16)
	, @ihrgjual				DECIMAL(19,6) 
	-- ######################################
	, @inote				NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
	AS
	BEGIN
		IF @iact = 'new' BEGIN
			INSERT INTO tpop (
				no					
				, tdate					
				, docstat		
				, sales						
				-- ######################################
				, code_mvendor		
				, name_mvendor		
				, hp1					
				, alamat	
				, norek
				-- ######################################
				, code_mitem			
				, name_mitem			
				, code_mtype			
				, qty				
				, code_muom			
				, code_mbrand			
				, spek_mitem			
				-- ######################################
				, code_mcurrb				
				, hrgbeli					
				, code_mcurrj				
				, hrgjual					
				-- ######################################
				, note				
				, createduser	
			) VALUES (
				@ino					
				, @itdate			
				, @idocstat		
				, @isales
				-- ######################################
				, @icode_mvendor		
				, @iname_mvendor		
				, @ihp1					
				, @ialamat	
				, @inorek
				-- ######################################
				, @icode_mitem			
				, @iname_mitem			
				, @icode_mtype			
				, @iqty				
				, @icode_muom			
				, @icode_mbrand			
				, @ispek_mitem			
				-- ######################################
				, @icode_mcurrb				
				, @ihrgbeli					
				, @icode_mcurrj				
				, @ihrgjual	
				-- ######################################
				, @inote
				, @iusr	
			);
			
			SELECT TOP 1id = @iid FROM tpop ORDER BY id DESC;
				
		END ELSE IF @iact = 'upd' BEGIN
			
			UPDATE tpop SET 
				 no				= @ino
				, tdate			= @itdate
				, docstat		= @idocstat
				, sales			= @isales
				-- ######################################
				, code_mvendor	= @icode_mvendor
				, name_mvendor	= @iname_mvendor
				, hp1			= @ihp1	
				, alamat		= @ialamat	
				, norek 		= @inorek
				-- ######################################
				, code_mitem	= @icode_mitem	
				, name_mitem	= @iname_mitem	
				, code_mtype	= @icode_mtype	
				, qty			= @iqty
				, code_muom		= @icode_muom
				, code_mbrand	= @icode_mbrand	
				, spek_mitem	= @ispek_mitem	
				-- ######################################
				, code_mcurrb	= @icode_mcurrb		
				, hrgbeli		= @ihrgbeli		
				, code_mcurrj	= @icode_mcurrj			
				, hrgjual		= @ihrgjual
				-- ######################################
				, note 			= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				id = @iid;
			
			UPDATE tpoppic SET
				tstatus = 0 
			WHERE 	
				no_tpop = @ino
				AND tstatus = 1;
		
		END ELSE IF @iact = 'del' BEGIN
		
			UPDATE tpop SET
				tstatus = 0 
			WHERE 	
				id = @iid
				AND tstatus = 1;
				
			UPDATE tpoppic SET
				tstatus = 0 
			WHERE 	
				no_tpop = @ino
				AND tstatus = 1;
	
		END;
		
		EXEC shtrans 
		'PEMBELIAN PUTUS'
		, @iid
		, @ino
		, @iact
		, 'PEMBELIAN PUTUS'
		, @iusr
END
GO

-- procedure stinvoice
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stinvoice') AND type in (N'P', N'PC'))
DROP PROCEDURE	stinvoice
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stinvoice
	 @ino					NVARCHAR(64) 
	, @itdate				DATETIME
	, @itdate2				DATETIME
	, @idoctype			NVARCHAR(128) 
	, @isales					NVARCHAR(128)
	-- ######################################
	, @icode_mcust		VARCHAR(64)
	, @iname_mcust		VARCHAR(128)
	, @ihp1					NVARCHAR(64)
	, @ihp2					NVARCHAR(64)
	, @ialamat				NVARCHAR(128)
	, @igender				NVARCHAR(32)
	-- ######################################
	, @ino_tconsign				NVARCHAR(64) 
	, @icode_mconsignee		VARCHAR(64)
	, @iname_mitem			NVARCHAR(128)
	, @icode_mitem		VARCHAR(64)
	, @iqty					DECIMAL(19,6)
	, @icode_mcurrb				NVARCHAR(32)
	, @ihrgbeli					DECIMAL(19,6) 
	, @icode_mcurrj				NVARCHAR(32)
	, @ihrgjual					DECIMAL(19,6) 
	, @iprofit				DECIMAL(19,6)
	, @iprofitbuyer				DECIMAL(19,6)
	-- ######################################
	, @ipayvia				NVARCHAR(128) 
	, @iinforek				NVARCHAR(128) 
	, @itglbyr				DATETIME 
	, @idp					DECIMAL(19,6)
	-- ######################################
	, @isendby			NVARCHAR(128)
	, @ivoucher			NVARCHAR(128)
	, @igrdtotal		DECIMAL(19,6)
	-- ######################################
	, @inote				NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
	AS
	BEGIN
		IF @iact = 'new' BEGIN
			INSERT INTO tinvoice (
				no					
				, tdate
				, tdate2
				, doctype			
				, sales						
				-- ######################################
				, code_mcust		
				, name_mcust		
				, hp1				
				, hp2				
				, alamat			
				, gender			
				-- ######################################
				, no_tconsign		
				, code_mconsignee	
				, name_mitem
				, code_mitem	
				, qty
				, code_mcurrb		
				, hrgbeli			
				, code_mcurrj		
				, hrgjual			
				, profit
				, profitbuyer
				-- ######################################
				, payvia			
				, inforek			
				, tglbyr			
				, dp
				-- ######################################
				, sendby
				, voucher
				, grdtotal
				-- ######################################
				, note				
			, createduser	
			) VALUES (
				@ino					
				, @itdate
				, @itdate2
				, @idoctype			
				, @isales							
				-- ######################################
				, @icode_mcust		
				, @iname_mcust		
				, @ihp1				
				, @ihp2				
				, @ialamat			
				, @igender			
				-- ######################################
				, @ino_tconsign		
				, @icode_mconsignee
				, @iname_mitem
				, @icode_mitem
				, @iqty
				, @icode_mcurrb		
				, @ihrgbeli			
				, @icode_mcurrj		
				, @ihrgjual			
				, @iprofit
				, @iprofitbuyer
				-- ######################################
				, @ipayvia			
				, @iinforek			
				, @itglbyr	
				, @idp
				-- ######################################
				, @isendby
				, @ivoucher
				, @igrdtotal
				-- ######################################
				, @inote
			, @iusr	
			);
			
			SELECT TOP 1id = @iid FROM tinvoice ORDER BY id DESC;
				
		END ELSE IF @iact = 'upd' BEGIN
			
			UPDATE tinvoice SET 
				 no					= @ino
				, tdate				= @itdate
				, tdate2				= @itdate2
				, doctype			= @idoctype
				, sales				= @isales
				-- ######################################
				, code_mcust		= @icode_mcust
				, name_mcust		= @iname_mcust
				, hp1				= @ihp1
				, hp2				= @ihp2
				, alamat			= @ialamat
				, gender			= @igender
				-- ######################################
				, no_tconsign		= @ino_tconsign
				, code_mconsignee	= @icode_mconsignee
				, name_mitem		= @iname_mitem
				, code_mitem		= @icode_mitem
				, qty				= @iqty
				, code_mcurrb		= @icode_mcurrb
				, hrgbeli			= @ihrgbeli
				, code_mcurrj		= @icode_mcurrj
				, hrgjual			= @ihrgjual
				, profit			= @iprofit
				, profitbuyer			= @iprofitbuyer
				-- ######################################
				, payvia			= @ipayvia
				, inforek			= @iinforek
				, tglbyr			= @itglbyr
				, dp			 	= @idp
				-- ######################################
				, sendby			= @isendby
				, voucher			= @ivoucher
				, grdtotal			= @igrdtotal
				-- ######################################
				, note 				= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				id = @iid;
				
			UPDATE tinvoicepic SET
				tstatus = 0 
			WHERE 	
				no_tinvoice = @ino
				AND tstatus = 1;
		
		END ELSE IF @iact = 'del' BEGIN
		
			UPDATE tinvoice SET
				tstatus = 0 
			WHERE 	
				id = @iid
				AND tstatus = 1;
			
			UPDATE tinvoicepic SET
				tstatus = 0 
			WHERE 	
				no_tinvoice = @ino
				AND tstatus = 1;
	
		END;
		
		EXEC shtrans 
		'INVOICE PENJUALAN'
		, @iid
		, @ino
		, @iact
		, 'INVOICE PENJUALAN'
		, @iusr
END
GO

-- procedure stretinvoice
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stretinvoice') AND type in (N'P', N'PC'))
DROP PROCEDURE	stretinvoice
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stretinvoice
		@ino					NVARCHAR(64) 
		, @itdate				DATETIME 
		, @idoctype			NVARCHAR(128) 
		, @idoctype2			NVARCHAR(128) 
		, @isales					NVARCHAR(128) 
		-- ######################################
		, @ino_tinvoice				NVARCHAR(64)
		-- ######################################
		, @ipayvia				NVARCHAR(128) 
		, @iinforek				NVARCHAR(128) 
		, @itglbyr				DATETIME 
		-- ######################################
		, @inote				NVARCHAR(256)
		, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			INSERT INTO tretinvoice (
				no					
				, tdate				
				, doctype		
				, doctype2
				, sales						
				-- ######################################
				, no_tinvoice				
				-- ######################################
				, payvia				
				, inforek				
				, tglbyr												
				-- ######################################
				, note				
			, createduser	
			) VALUES (
				@ino					
				, @itdate				
				, @idoctype
				, @idoctype2
				, @isales						
				-- ######################################
				, @ino_tinvoice				
				-- ######################################
				, @ipayvia				
				, @iinforek				
				, @itglbyr	
				-- ######################################
				, @inote
			, @iusr
			);
			
			SELECT TOP 1id = @iid FROM tretinvoice ORDER BY id DESC;
				
		END ELSE IF @iact = 'upd' BEGIN
			
			UPDATE tretinvoice SET 
				 no				=	@ino	
				, tdate				=	@itdate
				, doctype			=	@idoctype
				, doctype2			= 	@idoctype2
				, sales				=	@isales
				-- ######################################
				, no_tinvoice		=	@ino_tinvoice
				-- ######################################
				, payvia			=	@ipayvia
				, inforek			=	@iinforek
				, tglbyr			=	@itglbyr
				-- ######################################
				, note 				= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				id = @iid;
			
			UPDATE tretinvoicepic SET 
				tstatus = 0
			WHERE 
				no_tretinvoice = @ino;
		
		END ELSE IF @iact = 'del' BEGIN
		
			UPDATE tretinvoice SET 
				tstatus = 0
			WHERE 
				id = @iid;
			
			UPDATE tretinvoicepic SET 
				tstatus = 0
			WHERE 
				no_tretinvoice = @ino;
		
	
		END;
		
		EXEC shtrans 
		'RETUR PENJUALAN'
		, @iid
		, @ino
		, @iact
		, 'RETUR PENJUALAN'
		, @iusr
END
GO

-- procedure stopay
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stopay') AND type in (N'P', N'PC'))
DROP PROCEDURE	stopay
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stopay
		@ino					NVARCHAR(64) 
		, @itdate				DATETIME 
		, @ijenis				NVARCHAR(64)
		, @icode_maccount		NVARCHAR(64)
		-- ######################################
		, @itotal				DECIMAL(20,6) 
		-- ######################################
		, @inote				NVARCHAR(256)
		, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			INSERT INTO topay (
				no				
				, tdate			
				, jenis				
				, code_maccount		
				-- ######################################
				, total				
				-- ######################################
				, note				
			, createduser		
			) VALUES (
				@ino				
				, @itdate			
				, @ijenis				
				, @icode_maccount		
				-- ######################################
				, @itotal	
				-- ######################################
				, @inote
			, @iusr
			);
			
			SELECT TOP 1id = @iid FROM topay ORDER BY id DESC;
				
		END ELSE IF @iact = 'upd' BEGIN
			
			UPDATE topay SET 
				no			=	@ino	
				, tdate			=	@itdate
				, jenis			=	@ijenis
				, code_maccount	=	@icode_maccount
				-- ######################################
				, total			=	@itotal
				-- ######################################
			WHERE 
				id = @iid;
		
			UPDATE topayd SET
				tstatus = 0 
			WHERE 	
				id_topayh = @iid
				AND tstatus = 1;
				
		END ELSE IF @iact = 'del' BEGIN
		
			UPDATE topay SET 
				tstatus = 0
			WHERE 
				id = @iid;
		
			UPDATE topayd SET
				tstatus = 0 
			WHERE 	
				id_topayh = @iid
				AND tstatus = 1;
	
		END;
		
		EXEC shtrans 
		'VOUCHER BIAYA'
		, @iid
		, @ino
		, @iact
		, 'VOUCHER BIAYA'
		, @iusr
END
GO


-- procedure stopayd
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stopayd') AND type in (N'P', N'PC'))
DROP PROCEDURE	stopayd
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stopayd
	@ino_topayh			NVARCHAR(64) 
	, @idsc					NVARCHAR(512) 
	-- ######################################
	, @itotal				DECIMAL(20,6) 
	-- ######################################
	, @inote				NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			SELECT TOP 1 @iid = id FROM topay WHERE createduser = @iusr ORDER BY id DESC ;
		END 
		
		INSERT INTO topayd (
			id_topayh
			, no_topayh			
			, dsc				
			-- ######################################
			, total				
			-- ######################################
			, note				
			, createduser	
		) VALUES (
			@iid
			, @ino_topayh			
			, @idsc				
			-- ######################################
			, @itotal				
			-- ######################################
			, @inote
			, @iusr
		);

END
GO



-- procedure stpo
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stpo') AND type in (N'P', N'PC'))
DROP PROCEDURE	stpo
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stpo
		@ino					NVARCHAR(64) 
		, @itdate					DATETIME 
		, @itdate2					DATETIME 
		-- ######################################
		, @icode_mcust		NVARCHAR(32)
		, @iname_mcust		NVARCHAR(128)
		, @ihp1					NVARCHAR(64)
		, @ihp2					NVARCHAR(64)
		, @ialamat				NVARCHAR(128) 
		, @igender				NVARCHAR(32)
		, @inorek				NVARCHAR(128)
		, @icatat					NVARCHAR(256) 
		-- ######################################
		, @icode_mitem			NVARCHAR(128)
		, @iname_mitem			NVARCHAR(128)
		, @icode_mtype			NVARCHAR(64)
		, @iqty					DECIMAL(19,6)
		, @icode_muom			NVARCHAR(128)
		, @icode_mbrand			NVARCHAR(128)
		, @ispek_mitem			NVARCHAR(512)
		-- ######################################
		, @icode_mcurrb			NVARCHAR(32)
		, @ihrgbeli				DECIMAL(20,6) 
		, @icode_mcurrj			NVARCHAR(32)
		, @ihrgjual				DECIMAL(20,6) 
		-- ######################################
		, @ipayvia				NVARCHAR(128) 
	, @iinforek				NVARCHAR(128) 
	, @itglbyr				DATETIME 
	, @idp					DECIMAL(19,6) 
	-- ######################################
		, @inote				NVARCHAR(256)
		, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			INSERT INTO tpo (
				 no					
				, tdate	
				, tdate2
				-- ######################################
				, code_mcust		
				, name_mcust
				, hp1					
				, hp2					
				, alamat
				, gender
				, norek
				, catat					
				-- ######################################
				, code_mitem			
				, name_mitem	
				, code_mtype			
				, qty
				, code_muom
				, code_mbrand	
				, spek_mitem
				-- ######################################
				, code_mcurrb			
				, hrgbeli				
				, code_mcurrj			
				, hrgjual						
				-- ######################################
				, payvia			
				, inforek			
				, tglbyr
				, dp
				-- ######################################
				, note				
			, createduser	
			) VALUES (
				@ino					
				, @itdate		
				, @itdate2
				-- ######################################
				, @icode_mcust		
				, @iname_mcust		
				, @ihp1					
				, @ihp2					
				, @ialamat	
				, @igender
				, @inorek
				, @icatat					
				-- ######################################
				, @icode_mitem			
				, @iname_mitem	
				, @icode_mtype	
				, @iqty
				, @icode_muom
				, @icode_mbrand	
				, @ispek_mitem
				-- ######################################
				, @icode_mcurrb			
				, @ihrgbeli				
				, @icode_mcurrj			
				, @ihrgjual		
				-- ######################################
				, @ipayvia			
				, @iinforek			
				, @itglbyr
				, @idp
				, @inote
			, @iusr	
			);
			
			SELECT TOP 1id = @iid FROM tpo ORDER BY id DESC;
				
		END ELSE IF @iact = 'upd' BEGIN
			
			UPDATE tpo SET 
				no				=	@ino	
				, tdate				=	@itdate
				, tdate2				=	@itdate2
				-- ######################################
				, code_mcust	=	@icode_mcust
				, name_mcust	=	@iname_mcust
				, hp1				=	@ihp1
				, hp2				=	@ihp2
				, alamat			=	@ialamat
				, gender			= 	@igender
				, norek			 	= 	@inorek
				, catat				=	@icatat
				-- ######################################
				, code_mitem		=	@icode_mitem
				, name_mitem		=	@iname_mitem
				, code_mtype		=	@icode_mtype
				, qty				= 	@iqty
				, code_muom			= 	@icode_muom
				, code_mbrand		= 	@icode_mbrand
				, spek_mitem		= 	@ispek_mitem
				-- ######################################
				, code_mcurrb		=	@icode_mcurrb
				, hrgbeli			=	@ihrgbeli
				, code_mcurrj		=	@icode_mcurrj
				, hrgjual			=	@ihrgjual
				-- ######################################
				, payvia			= @ipayvia
				, inforek			= @iinforek
				, tglbyr			= @itglbyr
				, dp			 	= @idp
				-- ######################################
				, note 				= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				id = @iid;
		
				UPDATE tpopic SET 
				tstatus = 0
				, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				code = @icode_mitem;
				
		END ELSE IF @iact = 'del' BEGIN
		
			UPDATE tpo SET 
				tstatus = 0
				, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				id = @iid;
			
			UPDATE tpopic SET 
				tstatus = 0
				, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				code = @icode_mitem;
	
		END;
		
		EXEC shtrans 
		'PREODER'
		, @iid
		, @ino
		, @iact
		, 'PREODER'
		, @iusr
END
GO

-- procedure stinvj
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stinvj') AND type in (N'P', N'PC'))
DROP PROCEDURE	stinvj
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stinvj
		@ino					NVARCHAR(64) 
		, @itdate				DATETIME 
		, @icode_mcust			NVARCHAR(64)
		-- ######################################
		, @itotal				DECIMAL(20,6) 
		-- ######################################
		, @inote				NVARCHAR(256)
		, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			INSERT INTO tinvj (
				no				
				, tdate		
				, code_mcust
				-- ######################################
				, total				
				-- ######################################
				, note				
			, createduser		
			) VALUES (
				@ino				
				, @itdate				
				, @icode_mcust
				-- ######################################
				, @itotal	
				-- ######################################
				, @inote
			, @iusr
			);
			
			SELECT TOP 1id = @iid FROM tinvj ORDER BY id DESC;
				
		END ELSE IF @iact = 'upd' BEGIN
			
			UPDATE tinvj SET 
				no				=	@ino	
				, tdate			=	@itdate
				, code_mcust	= @icode_mcust
				-- ######################################
				, total			=	@itotal
				-- ######################################
				, note 				= @inote
				, modifieduser		= @iusr
				, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				id = @iid;
		
			UPDATE tinvjd SET
				tstatus = 0 
			WHERE 	
				id_tinvjh = @iid
				AND tstatus = 1;
				
		END ELSE IF @iact = 'del' BEGIN
		
			UPDATE tinvj SET 
				tstatus = 0
			WHERE 
				id = @iid;
		
			UPDATE tinvjd SET
				tstatus = 0 
			WHERE 	
				id_tinvjh = @iid
				AND tstatus = 1;
	
		END;
		
		EXEC shtrans 
		'INVOICE JASA'
		, @iid
		, @ino
		, @iact
		, 'INVOICE JASA'
		, @iusr
END
GO


-- procedure stinvjd
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stinvjd') AND type in (N'P', N'PC'))
DROP PROCEDURE	stinvjd
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stinvjd
	@ino_tinvjh			NVARCHAR(64) 
	, @idsc					NVARCHAR(512) 
	, @iqty					DECIMAL(19,6)
	, @iprice				DECIMAL(19,6)
	-- ######################################
	, @itotal				DECIMAL(19,6) 
	-- ######################################
	, @inote				NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			SELECT TOP 1 @iid = id FROM tinvj WHERE createduser = @iusr ORDER BY id DESC ;
		END 
		
		INSERT INTO tinvjd (
			id_tinvjh
			, no_tinvjh			
			, dsc	
			, qty
			, price
			-- ######################################
			, total				
			-- ######################################
			, note				
			, createduser	
		) VALUES (
			@iid
			, @ino_tinvjh			
			, @idsc				
			, @iqty
			, @iprice
			-- ######################################
			, @itotal				
			-- ######################################
			, @inote
			, @iusr
		);

END
GO

-- procedure strf
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'strf') AND type in (N'P', N'PC'))
DROP PROCEDURE	strf
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE strf
		 @ino					NVARCHAR(64)
		, @itdate					DATETIME
		, @icode_mlocationfr		NVARCHAR(64)
		, @icode_mlocationto		NVARCHAR(64)
		-- ######################################
		, @icode_mitem			NVARCHAR(128)
		, @iname_mitem			NVARCHAR(256)
		, @icode_mtype			NVARCHAR(64)
		, @iqty				DECIMAL(19,6) 
		, @icode_muom			NVARCHAR(64)
		, @icode_mbrand			NVARCHAR(64)
		, @ispek_mitem			NVARCHAR(512)
		, @icode_mconsignee		NVARCHAR(128)
		-- ######################################
		, @inote				NVARCHAR(256)
		, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
	AS
	BEGIN
		IF @iact = 'new' BEGIN
			INSERT INTO trf (
				no				
				, tdate				
				, code_mlocationfr	
				, code_mlocationto		
				-- ######################################
				, code_mitem	
				, name_mitem		
				, code_mtype	
				, qty			
				, code_muom			
				, code_mbrand			
				, spek_mitem			
				, code_mconsignee		
				-- ######################################
				, note				
			, createduser	
			) VALUES (
				@ino				
				, @itdate				
				, @icode_mlocationfr	
				, @icode_mlocationto		
				-- ######################################
				, @icode_mitem	
				, @iname_mitem		
				, @icode_mtype	
				, @iqty			
				, @icode_muom			
				, @icode_mbrand			
				, @ispek_mitem			
				, @icode_mconsignee					
				-- ######################################
				, @inote
			, @iusr	
			);
			
			SELECT TOP 1id = @iid FROM trf ORDER BY id DESC;
				
		END ELSE IF @iact = 'upd' BEGIN
			
			UPDATE trf SET 
				no						= @ino
				, tdate					= @itdate
				, code_mlocationfr		= @icode_mlocationfr
				, code_mlocationto		= @icode_mlocationto
				-- ######################################
				, code_mitem			= @icode_mitem
				, name_mitem			= @iname_mitem
				, code_mtype			= @icode_mtype
				, qty					= @iqty 
				, code_muom				= @icode_muom
				, code_mbrand			= @icode_mbrand
				, spek_mitem			= @ispek_mitem
				, code_mconsignee		= @icode_mconsignee
				-- ######################################
				, note 				= @inote
			, modifieduser		= @iusr
			, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				id = @iid;
		
		END ELSE IF @iact = 'del' BEGIN
		
			UPDATE trf SET
				tstatus = 0 
			WHERE 	
				id = @iid
				AND tstatus = 1;
	
		END;
		
		EXEC shtrans 
		'TRANSFER LOKASI'
		, @iid
		, @ino
		, @iact
		, ''
		, @iusr
END
GO

-- procedure stpy
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stpy') AND type in (N'P', N'PC'))
DROP PROCEDURE	stpy
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stpy
		 @ino				NVARCHAR(64)
	, @itdate				DATETIME 
	, @ipaytype				NVARCHAR(64)
	, @icode_mcust				NVARCHAR(64)
	, @icode_maccount		NVARCHAR(64)
	-- ######################################
	, @iongkirtotal			DECIMAL(19,6) 
	, @itotalinv			DECIMAL(19,6) 
	, @itotal				DECIMAL(19,6) 
		-- ######################################
	, @inote				NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			INSERT INTO tpy (
				no				
				, tdate			
				, paytype		
				, code_mcust	
				, code_maccount	
				-- ######################################
				, ongkirtotal	
				, totalinv		
				, total			
				-- ######################################
				, note				
			, createduser		
			) VALUES (
				@ino				
				, @itdate			
				, @ipaytype		
				, @icode_mcust	
				, @icode_maccount		
				-- ######################################
				, @iongkirtotal	
				, @itotalinv		
				, @itotal		
				-- ######################################
				, @inote
			, @iusr
			);
			
			SELECT TOP 1id = @iid FROM tpy ORDER BY id DESC;
				
		END ELSE IF @iact = 'upd' BEGIN
			
			UPDATE tpy SET 
				no					= @ino
				, tdate				= @itdate
				, paytype			= @ipaytype
				, code_mcust		= @icode_mcust
				, code_maccount		= @icode_maccount
				-- ######################################
				, ongkirtotal		= @iongkirtotal
				, totalinv			= @itotalinv
				, total				= @itotal
				-- ######################################
				, note 				= @inote
				, modifieduser		= @iusr
				, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				id = @iid;
		
			UPDATE tpyd SET
				tstatus = 0 
			WHERE 	
				id_tpyh = @iid
				AND tstatus = 1;
				
		END ELSE IF @iact = 'del' BEGIN
		
			UPDATE tpy SET 
				tstatus = 0
			WHERE 
				id = @iid;
		
			UPDATE tpyd SET
				tstatus = 0 
			WHERE 	
				id_tpyh = @iid
				AND tstatus = 1;
	
		END;
		
		EXEC shtrans 
		'PAYMENT FROM CUSTOMER/BUYER'
		, @iid
		, @ino
		, @iact
		, ''
		, @iusr
END
GO


-- procedure stpyd
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stpyd') AND type in (N'P', N'PC'))
DROP PROCEDURE	stpyd
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stpyd
	@ino_tpyh			NVARCHAR(64) 
	-- #####################################
	, @idoctype			NVARCHAR(8)
	, @ino_trans			NVARCHAR(64)
	, @itdate_trans			NVARCHAR(64)
	, @icode_mcust		NVARCHAR(64)
	, @icode_mitem		NVARCHAR(64)
	, @iongkir			DECIMAL(19,6) 
	, @igrdtotal_trans		DECIMAL(19,6)
	, @ipaytotal			DECIMAL(19,6)
	-- ######################################
	, @inote				NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			SELECT TOP 1 @iid = id FROM tpy WHERE createduser = @iusr ORDER BY id DESC ;
		END 
		
		INSERT INTO tpyd (
			 id_tpyh		
			, no_tpyh		
			-- #####################################
			, doctype		
			, no_trans		
			, tdate_trans	
			, code_mcust
			, code_mitem
			, ongkir		
			, grdtotal_trans
			, paytotal		
			-- ######################################
			, note				
			, createduser	
		) VALUES (
			@iid
			, @ino_tpyh		
			-- #####################################
			, @idoctype		
			, @ino_trans		
			, @itdate_trans
			, @icode_mcust
			, @icode_mitem
			, @iongkir		
			, @igrdtotal_trans
			, @ipaytotal					
			-- ######################################
			, @inote
			, @iusr
		);

END
GO

-- procedure stpc
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stpc') AND type in (N'P', N'PC'))
DROP PROCEDURE	stpc
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stpc
		 @ino				NVARCHAR(64)
	, @itdate				DATETIME 
	, @ipaytype				NVARCHAR(64)
	, @icode_mconsignee				NVARCHAR(64)
	, @icode_maccount		NVARCHAR(64)
	-- ######################################
	, @itotalinv			DECIMAL(19,6) 
	, @itotal				DECIMAL(19,6) 
		-- ######################################
	, @inote				NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			INSERT INTO tpc (
				no				
				, tdate			
				, paytype		
				, code_mconsignee
				, code_maccount	
				-- ######################################
				, totalinv		
				, total			
				-- ######################################
				, note				
			, createduser		
			) VALUES (
				@ino				
				, @itdate			
				, @ipaytype		
				, @icode_mconsignee	
				, @icode_maccount		
				-- ######################################
				, @itotalinv		
				, @itotal		
				-- ######################################
				, @inote
			, @iusr
			);
			
			SELECT TOP 1id = @iid FROM tpc ORDER BY id DESC;
				
		END ELSE IF @iact = 'upd' BEGIN
			
			UPDATE tpc SET 
				no					= @ino
				, tdate				= @itdate
				, paytype			= @ipaytype
				, code_mconsignee		= @icode_mconsignee
				, code_maccount		= @icode_maccount
				-- ######################################
				, totalinv			= @itotalinv
				, total				= @itotal
				-- ######################################
				, note 				= @inote
				, modifieduser		= @iusr
				, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				id = @iid;
		
			UPDATE tpcd SET
				tstatus = 0 
			WHERE 	
				id_tpch = @iid
				AND tstatus = 1;
				
		END ELSE IF @iact = 'del' BEGIN
		
			UPDATE tpc SET 
				tstatus = 0
			WHERE 
				id = @iid;
		
			UPDATE tpcd SET
				tstatus = 0 
			WHERE 	
				id_tpch = @iid
				AND tstatus = 1;
	
		END;
		
		EXEC shtrans 
		'PAYMENT TO CONSIGNEE'
		, @iid
		, @ino
		, @iact
		, ''
		, @iusr
END
GO


-- procedure stpcd
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stpcd') AND type in (N'P', N'PC'))
DROP PROCEDURE	stpcd
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stpcd
	@ino_tpch			NVARCHAR(64) 
	-- #####################################
	, @idoctype			NVARCHAR(8)
	, @ino_trans			NVARCHAR(64)
	, @itdate_trans			NVARCHAR(64)
	, @icode_mconsignee		NVARCHAR(64)
	, @icode_mitem		NVARCHAR(64)
	, @igrdtotal_trans		DECIMAL(19,6)
	, @ipaytotal			DECIMAL(19,6)
	-- ######################################
	, @inote				NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			SELECT TOP 1 @iid = id FROM tpc WHERE createduser = @iusr ORDER BY id DESC ;
		END 
		
		INSERT INTO tpcd (
			 id_tpch		
			, no_tpch		
			-- #####################################
			, doctype		
			, no_trans		
			, tdate_trans	
			, code_mconsignee
			, code_mitem
			, grdtotal_trans
			, paytotal		
			-- ######################################
			, note				
			, createduser	
		) VALUES (
			@iid
			, @ino_tpch		
			-- #####################################
			, @idoctype		
			, @ino_trans		
			, @itdate_trans
			, @icode_mconsignee
			, @icode_mitem
			, @igrdtotal_trans
			, @ipaytotal					
			-- ######################################
			, @inote
			, @iusr
		);

END
GO

-- procedure stps
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stps') AND type in (N'P', N'PC'))
DROP PROCEDURE	stps
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stps
		 @ino				NVARCHAR(64)
	, @itdate				DATETIME 
	, @ipaytype				NVARCHAR(64)
	, @icode_mvendor				NVARCHAR(64)
	, @icode_maccount		NVARCHAR(64)
	-- ######################################
	, @itotalinv			DECIMAL(19,6) 
	, @itotal				DECIMAL(19,6) 
		-- ######################################
	, @inote				NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			INSERT INTO tps (
				no				
				, tdate			
				, paytype		
				, code_mvendor
				, code_maccount	
				-- ######################################
				, totalinv		
				, total			
				-- ######################################
				, note				
			, createduser		
			) VALUES (
				@ino				
				, @itdate			
				, @ipaytype		
				, @icode_mvendor
				, @icode_maccount		
				-- ######################################
				, @itotalinv		
				, @itotal		
				-- ######################################
				, @inote
			, @iusr
			);
			
			SELECT TOP 1id = @iid FROM tps ORDER BY id DESC;
				
		END ELSE IF @iact = 'upd' BEGIN
			
			UPDATE tps SET 
				no					= @ino
				, tdate				= @itdate
				, paytype			= @ipaytype
				, code_mvendor		= @icode_mvendor
				, code_maccount		= @icode_maccount
				-- ######################################
				, totalinv			= @itotalinv
				, total				= @itotal
				-- ######################################
				, note 				= @inote
				, modifieduser		= @iusr
				, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				id = @iid;
		
			UPDATE tpsd SET
				tstatus = 0 
			WHERE 	
				id_tpsh = @iid
				AND tstatus = 1;
				
		END ELSE IF @iact = 'del' BEGIN
		
			UPDATE tps SET 
				tstatus = 0
			WHERE 
				id = @iid;
		
			UPDATE tpsd SET
				tstatus = 0 
			WHERE 	
				id_tpsh = @iid
				AND tstatus = 1;
	
		END;
		
		EXEC shtrans 
		'PAYMENT TO VENDOR'
		, @iid
		, @ino
		, @iact
		, ''
		, @iusr
END
GO


-- procedure stpsd
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stpsd') AND type in (N'P', N'PC'))
DROP PROCEDURE	stpsd
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stpsd
	@ino_tpsh			NVARCHAR(64) 
	-- #####################################
	, @idoctype			NVARCHAR(8)
	, @ino_trans			NVARCHAR(64)
	, @itdate_trans			NVARCHAR(64)
	, @icode_mvendor		NVARCHAR(64)
	, @icode_mitem		NVARCHAR(64)
	, @igrdtotal_trans		DECIMAL(19,6)
	, @ipaytotal			DECIMAL(19,6)
	-- ######################################
	, @inote				NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			SELECT TOP 1 @iid = id FROM tps WHERE createduser = @iusr ORDER BY id DESC ;
		END 
		
		INSERT INTO tpsd (
			 id_tpsh		
			, no_tpsh		
			-- #####################################
			, doctype		
			, no_trans		
			, tdate_trans	
			, code_mvendor
			, code_mitem
			, grdtotal_trans
			, paytotal		
			-- ######################################
			, note				
			, createduser	
		) VALUES (
			@iid
			, @ino_tpsh		
			-- #####################################
			, @idoctype		
			, @ino_trans		
			, @itdate_trans
			, @icode_mvendor
			, @icode_mitem
			, @igrdtotal_trans
			, @ipaytotal					
			-- ######################################
			, @inote
			, @iusr
		);

END
GO

-- procedure stts
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'stts') AND type in (N'P', N'PC'))
DROP PROCEDURE	stts
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stts
		 @ino				NVARCHAR(64)
	, @itdate				DATETIME 
	, @ipaytype				NVARCHAR(64)
	, @icode_mvendor				NVARCHAR(64)
	, @icode_maccount		NVARCHAR(64)
	-- ######################################
	, @itotalinv			DECIMAL(19,6) 
	, @itotal				DECIMAL(19,6) 
		-- ######################################
	, @inote				NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			INSERT INTO tts (
				no				
				, tdate			
				, paytype		
				, code_mvendor
				, code_maccount	
				-- ######################################
				, totalinv		
				, total			
				-- ######################################
				, note				
			, createduser		
			) VALUES (
				@ino				
				, @itdate			
				, @ipaytype		
				, @icode_mvendor
				, @icode_maccount		
				-- ######################################
				, @itotalinv		
				, @itotal		
				-- ######################################
				, @inote
			, @iusr
			);
			
			SELECT TOP 1id = @iid FROM tts ORDER BY id DESC;
				
		END ELSE IF @iact = 'upd' BEGIN
			
			UPDATE tts SET 
				no					= @ino
				, tdate				= @itdate
				, paytype			= @ipaytype
				, code_mvendor		= @icode_mvendor
				, code_maccount		= @icode_maccount
				-- ######################################
				, totalinv			= @itotalinv
				, total				= @itotal
				-- ######################################
				, note 				= @inote
				, modifieduser		= @iusr
				, modifieddate		= CURRENT_TIMESTAMP
			WHERE 
				id = @iid;
		
			UPDATE ttsd SET
				tstatus = 0 
			WHERE 	
				id_ttsh = @iid
				AND tstatus = 1;
				
		END ELSE IF @iact = 'del' BEGIN
		
			UPDATE tts SET 
				tstatus = 0
			WHERE 
				id = @iid;
		
			UPDATE ttsd SET
				tstatus = 0 
			WHERE 	
				id_ttsh = @iid
				AND tstatus = 1;
	
		END;
		
		EXEC shtrans 
		'PAYMENT DARI VENDOR'
		, @iid
		, @ino
		, @iact
		, ''
		, @iusr
END
GO


-- procedure sttsd
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'sttsd') AND type in (N'P', N'PC'))
DROP PROCEDURE	sttsd
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sttsd
	@ino_ttsh			NVARCHAR(64) 
	-- #####################################
	, @idoctype			NVARCHAR(8)
	, @ino_trans			NVARCHAR(64)
	, @itdate_trans			NVARCHAR(64)
	, @icode_mvendor		NVARCHAR(64)
	, @icode_mitem		NVARCHAR(64)
	, @igrdtotal_trans		DECIMAL(19,6)
	, @ipaytotal			DECIMAL(19,6)
	-- ######################################
	, @inote				NVARCHAR(256)
	, @iusr					INT	
	, @iact					VARCHAR(8)
	, @iid					INT
AS
	BEGIN
		IF @iact = 'new' BEGIN
			SELECT TOP 1 @iid = id FROM tts WHERE createduser = @iusr ORDER BY id DESC ;
		END 
		
		INSERT INTO ttsd (
			 id_ttsh		
			, no_ttsh		
			-- #####################################
			, doctype		
			, no_trans		
			, tdate_trans	
			, code_mvendor
			, code_mitem
			, grdtotal_trans
			, paytotal		
			-- ######################################
			, note				
			, createduser	
		) VALUES (
			@iid
			, @ino_ttsh	
			-- #####################################
			, @idoctype		
			, @ino_trans		
			, @itdate_trans
			, @icode_mvendor
			, @icode_mitem
			, @igrdtotal_trans
			, @ipaytotal					
			-- ######################################
			, @inote
			, @iusr
		);

END
GO