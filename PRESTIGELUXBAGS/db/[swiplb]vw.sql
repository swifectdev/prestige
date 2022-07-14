 -- VIEW vtinvoice
 IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[vtinvoice]'))
 DROP VIEW vtinvoice
 GO
 SET ANSI_NULLS ON
 GO
 SET QUOTED_IDENTIFIER ON
 GO
 CREATE VIEW vtinvoice
 AS
 	SELECT
 		TA.id 				
	, TA.no				
	, TA.tdate				
	, TA.tdate2			
	, TA.doctype		
	, TA.sales			
	, TA.docstat			
	-- ######################################
	, TA.code_mcust	
	, TA.name_mcust		
	, TA.hp1				
	, TA.hp2					
	, TA.alamat			
	, TA.gender			
	-- ######################################
	, TA.no_tconsign		
	, TA.code_mconsignee	
	, TA.name_mitem			
	, TA.code_mitem		
	, TA.qty					
	, TA.code_mcurrb			
	, TA.hrgbeli				
	, TA.code_mcurrj				
	, TA.hrgjual				
	, TA.profit				
	-- ######################################
	, TA.payvia				
	, TA.inforek			
	, TA.tglbyr			
	-- ######################################
	, TA.note			
	, dbo.fgetaccessories(TD.code) 'notes_accessories'
	, (SELECT TOP 1 picData FROM mitempic TX WHERE TX.code = TA.code_mitem AND TX.tstatus = 1 and picOrder = 1) 'picture'
	, TA.sendby
 	FROM
 		tinvoice TA INNER JOIN mitem TD ON TA.code_mitem = TD.code
 	WHERE 1=1
 		AND TA.tstatus = 1 AND TD.tstatus = 1
 GO

 -- VIEW vtretinvoice
 IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[vtretinvoice]'))
 DROP VIEW vtretinvoice
 GO
 SET ANSI_NULLS ON
 GO
 SET QUOTED_IDENTIFIER ON
 GO
 CREATE VIEW vtretinvoice
 AS
 	SELECT
 		TA.id 				
	, TA.no				
	, TA.tdate				
	, TA.tdate 'tdate2'
	, TA.doctype		
	, TA.sales			
	, TA.docstat			
	-- ######################################
	, TA.code_mcust	
	, TB.name_mcust		
	, TB.hp1				
	, TB.hp2					
	, TB.alamat			
	, TB.gender			
	-- ######################################
	, TB.no_tconsign		
	, TB.code_mconsignee	
	, TB.name_mitem			
	, TB.code_mitem		
	, TB.qty					
	, TB.code_mcurrb			
	, TB.hrgbeli				
	, TB.code_mcurrj				
	, TB.hrgjual				
	, TB.profit				
	-- ######################################
	, TA.payvia				
	, TA.inforek			
	, TA.tglbyr			
	-- ######################################
	, TA.note			
	, dbo.fgetaccessories(TB.code_mitem) 'notes_accessories'
	, (SELECT TOP 1 picData FROM mitempic TX WHERE TX.code = TB.code_mitem AND TX.tstatus = 1 and picOrder = 1) 'picture'
	, TB.sendby
 	FROM
 		tretinvoice TA
		INNER JOIN tinvoice TB ON TA.no_tinvoice = TB.no
 	WHERE 1=1
 		AND TA.tstatus = 1 AND TB.tstatus = 1
 GO



 
  -- VIEW vcharity
 IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[vcharity]'))
 DROP VIEW vcharity
 GO
 SET ANSI_NULLS ON
 GO
 SET QUOTED_IDENTIFIER ON
 GO
 CREATE VIEW vcharity
 AS
 	SELECT
 	TA.id 				
	, TA.no				
	, TA.tdate			
	, TA.jenis			
	, TA.code_maccount	
	-- ######################################
	, TA.ongkir			
	, TA.total			
	-- ######################################
	, TA.note		
	, TB.id_topayh			
	, TB.no_topayh			
	, TB.dsc				
	-- ######################################
	, TB.total	'total_detail'			
	-- ######################################
	, TB.note	'note_detail'
	, TC.name 'username'
 	FROM
 		topay TA
		INNER JOIN topayd TB ON TA.id = TB.id_topayh
		INNER JOIN cusr TC ON TA.createduser = TC.id
 	WHERE 1=1
 		AND TA.tstatus = 1 AND TB.tstatus = 1
 GO


  -- VIEW vitem
 IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[vitem]'))
 DROP VIEW vitem
 GO
 SET ANSI_NULLS ON
 GO
 SET QUOTED_IDENTIFIER ON
 GO
 CREATE VIEW vitem
 AS
 	SELECT
 	TA.no
	,	TA.code			
	, TA.name				
	, TA.dtconsign			
	, TA.code_mconsign		
	, TA.code_mtype		
	, TA.qty				
	, TA.code_muom			
	, TA.code_mbrand		
	, TA.code_mcurrb		
	, TA.hrgbeli			
	, TA.code_mcurrj		
	, TA.hrgjual			
	, TA.spek				
	--------------------------------
	, TA.color				
	, TA.sze				
	, TA.mtrl				
	--------------------------------
	, TA.code_mlocation	
	--------------------------------
	, TA.itemstatus		
	--------------------------------
	, TA.basetype			
	, TA.basenum			
	--------------------------------
	, TA.spec1          
	, TA.spec2          
	, TA.spec3          
	, TA.spec4          
	, TA.spec5          
	, TA.spec6          
	, TA.spec7          
	, TA.spec8          
	, TA.spec9          
	, TA.spec10          
	, TA.spec11          
	, TA.spec12          
	, TA.spec13          
	, TA.spec14          
	, TA.spec15          
	, TA.spec16          
	, TA.notespec
	, TB.name 'name_mconsignee'
	, TB.hp1
	, TB.alamat
	, TC.name 'name_mbrand'
	, TD.name 'username'
 	FROM
 		mitem TA
 		INNER JOIN mconsignee TB ON TA.code_mconsign = TB.code
		INNER JOIN mbrand TC ON TA.code_mbrand = TC.code
		INNER JOIN cusr TD ON TA.createduser = TD.id
 	WHERE 1=1
 		AND TB.tstatus = 1 AND TA.tstatus = 1
 GO
 
   -- VIEW vpenjualan
 IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[vpenjualan]'))
 DROP VIEW vpenjualan
 GO
 SET ANSI_NULLS ON
 GO
 SET QUOTED_IDENTIFIER ON
 GO
 CREATE VIEW vpenjualan
 AS
 	SELECT
 	TA.id 				
	, TA.no				
	, TA.tdate			
	, TA.tdate2			
	, TA.doctype		
	, TA.sales			
	, TA.docstat			
	-- ######################################
	, TA.code_mcust		
	, TA.name_mcust		
	, TA.hp1				
	, TA.hp2				
	, TA.alamat				
	, TA.gender				
	-- ######################################
	, TA.no_tconsign
	, TA.code_mconsignee
	, TF.name 'name_mconsignee'
	, TA.name_mitem		
	, TA.code_mitem		
	, TA.qty				
	, TA.code_mcurrb		
	, TA.hrgbeli			
	, TA.code_mcurrj		
	, TA.hrgjual			
	, TA.profit				
	-- ######################################
	, TA.payvia				
	, TA.inforek			
	, TA.tglbyr				
	-- ######################################
	, TA.note		
	, TC.name 'username'
	, TD.sze
	, (SELECT TOP 1 picData FROM mitempic TX WHERE TX.code = TA.code_mitem AND TX.tstatus = 1 and picOrder = 1) 'picture'
	, TD.name 'name_mtype'
	, dbo.fgetdatepayinvoice(TA.no) 'paydate'
	, TA.dp
 	FROM
 		tinvoice TA
		INNER JOIN cusr TC ON TA.createduser = TC.id
		-- LEFT JOIN tconsign TB ON TA.no_tconsign = TB.no
		INNER JOIN mitem TD ON TA.code_mitem = TD.code
		INNER JOIN mtype TE ON TD.code_mtype = TE.code
		INNER JOIN mconsignee TF ON TD.code_mconsign = TF.code
 	WHERE 1=1
 		AND TA.tstatus = 1 AND TC.tstatus = 1
 GO


   -- VIEW vpreorder
 IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[vpreorder]'))
 DROP VIEW vpreorder
 GO
 SET ANSI_NULLS ON
 GO
 SET QUOTED_IDENTIFIER ON
 GO
 CREATE VIEW vpreorder
 AS
 	SELECT
 	TA.id 				
	, TA.no				
	, TA.tdate			
	, TA.tdate2			
	, TA.docstat		
	-- ######################################
	, TA.code_mcust		
	, TA.name_mcust		
	, TA.hp1			
	, TA.hp2			
	, TA.alamat			
	, TA.gender			
	, TA.norek				
	, TA.catat				
	-- ######################################
	, TA.code_mitem			
	, TA.name_mitem			
	, TA.code_mtype			
	, TA.qty				
	, TA.code_muom			
	, TA.code_mbrand		
	, TA.spek_mitem			
	-- ######################################
	, TA.code_mcurrb		
	, TA.hrgbeli			
	, TA.code_mcurrj		
	, TA.hrgjual			
	-- ######################################
	, TA.payvia				
	, TA.inforek			
	, TA.tglbyr				
	-- ######################################
	, TA.note	
	, TD.sze
	, TC.username
	, (SELECT TOP 1 picData FROM mitempic TX WHERE TX.code = TA.code_mitem AND TX.tstatus = 1 and picOrder = 1) 'picture'
 	FROM
 		tpo TA
		INNER JOIN cusr TC ON TA.createduser = TC.id
		INNER JOIN mitem TD ON TA.code_mitem = TD.code
 	WHERE 1=1
 		AND TA.tstatus = 1 AND TC.tstatus = 1
 GO
 
-- view rptLapGB --(STORED PROCEDURE)
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'rptLapGB') AND type in (N'P', N'PC'))
DROP PROCEDURE	rptLapGB
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- EXEC rptLapGB '20200101','20201231'
CREATE PROCEDURE rptLapGB
	-- Add the parameters for the stored procedure here
	@datefrom datetime,
	@dateto datetime
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT linenum, NoPendaftaran, iddetail, idbc23, qty2
	INTO #GB
	FROM vwLapPosisiBrgGB


	select A.idbc23, A.JENIS, A.NoPendaftaran, A.TglPendaftaran, A.Kode, A.SERI,
		A.Nama, A.Satuan, A.Qty, A.CIF, 
		A.JENIS2, A.NoPendaftaranBC, A.TglDaftarBC, A.KODE2, A.NAMA2, A.UoM,
		 A.QTY2, A.CIF2,
		A.qty - 
		(select SUM(ISNULL(QTY2,0)) from #GB t2 where t2.linenum<=A.linenum 
		and A.NoPendaftaran = t2.NoPendaftaran and A.iddetail = t2.iddetail and A.idbc23 = t2.idbc23) as runbal
	 from vwLapPosisiBrgGB A WHERE A.TglPendaftaran BETWEEN @datefrom AND @dateto
	 -- where t1.NoPendaftaran = '004748' --and kode = 'CN 34 JTN473'

	 drop table #GB
END
GO