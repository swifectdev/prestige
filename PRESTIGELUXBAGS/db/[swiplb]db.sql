
-- TABLE swisyplb
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'swisyplb') AND type in (N'U'))
DROP TABLE swisyplb
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE swisyplb (
	id 					INT IDENTITY(1,1) NOT NULL
	, PRIMARY KEY 		(id)	
);


-- table capp
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'capp') AND type in (N'U'))
DROP TABLE capp
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE capp (
	id 					INT IDENTITY(1,1) NOT NULL
	, code 				NVARCHAR(64) NOT NULL
	, name				NVARCHAR(128) NOT NULL
	, tp				NVARCHAR(32) NOT NULL -- M : MASTER DATA, T : TRANSAKSI, C : CONFIGURATION, H : HISTORY, V : VIEW, R : REPORT, MP : MINIPOS
	, tpchild			NVARCHAR(32) DEFAULT ''
	--------------------------------
	, tstatus			INT DEFAULT 1
	, PRIMARY KEY 		(id)	
);

INSERT INTO capp (tp, code, name) VALUES ('M','maccount','Rekening');
INSERT INTO capp (tp, code, name) VALUES ('M','muom','Satuan');
INSERT INTO capp (tp, code, name) VALUES ('M','mbrand','Merk');
INSERT INTO capp (tp, code, name) VALUES ('M','mconsignee','Consignee');
INSERT INTO capp (tp, code, name) VALUES ('M','mcust','Buyer/Customer');
INSERT INTO capp (tp, code, name) VALUES ('M','mcurr','Mata Uang');
INSERT INTO capp (tp, code, name) VALUES ('M','mitem','Barang/Produk');
INSERT INTO capp (tp, code, name) VALUES ('M','mtype','Jenis');
INSERT INTO capp (tp, code, name) VALUES ('M','mvendor','Vendor');
-- INSERT INTO capp (tp, code, name) VALUES ('M','mcoa','Chart of Accounts');
INSERT INTO capp (tp, code, name) VALUES ('M','msales','Sales');
INSERT INTO capp (tp, code, name) VALUES ('M','mlocation','Lokasi');

-- INSERT INTO capp (tp, code, name) VALUES ('T','tconsign','Consignment');
INSERT INTO capp (tp, code, name) VALUES ('T','tinvoice','Invoice');
INSERT INTO capp (tp, code, name) VALUES ('T','tretinvoice','Retur Invoice');
INSERT INTO capp (tp, code, name) VALUES ('T','topay','Voucher Operasional');
-- INSERT INTO capp (tp, code, name) VALUES ('T','tje','Journal Voucher');
INSERT INTO capp (tp, code, name) VALUES ('T','tpo','Pre Order');
INSERT INTO capp (tp, code, name) VALUES ('T','tpop','Beli Putus');
INSERT INTO capp (tp, code, name) VALUES ('T','trf','Transfer Lokasi');
INSERT INTO capp (tp, code, name) VALUES ('T','tpy','Pembayaran dari Customer');
INSERT INTO capp (tp, code, name) VALUES ('T','tpc','Pembayaran ke Consignee');
INSERT INTO capp (tp, code, name) VALUES ('T','tps','Pembayaran Ke Vendor');
INSERT INTO capp (tp, code, name) VALUES ('T','tts','Pembayaran Dari Vendor');

INSERT INTO capp (tp, code, name) VALUES ('R','rsales','Laporan Penjualan');
INSERT INTO capp (tp, code, name) VALUES ('R','rcharity','Laporan Charity');
INSERT INTO capp (tp, code, name) VALUES ('R','rpreorder','Laporan Pre Order');
INSERT INTO capp (tp, code, name) VALUES ('R','rpaypending','Laporan Payment Pending');
INSERT INTO capp (tp, code, name) VALUES ('R','rstock','Laporan Stock');
INSERT INTO capp (tp, code, name) VALUES ('R','rbukubesar','Laporan Buku Besar');
INSERT INTO capp (tp, code, name) VALUES ('R','rlabarugi','Laporan Laba Rugi');


-- CONFIGURATION --
INSERT INTO capp (tp, code, name) VALUES ('C','dbconf','Database Config');
INSERT INTO capp (tp, code, name) VALUES ('C','companysetting','Company Settings');
INSERT INTO capp (tp, code, name) VALUES ('C','changepass','Change Password');
INSERT INTO capp (tp, code, name) VALUES ('C','user','User');
INSERT INTO capp (tp, code, name) VALUES ('C','userpriv','User Privelege');
INSERT INTO capp (tp, code, name) VALUES ('C','uploaddata','Upload Data');
INSERT INTO capp (tp, code, name) VALUES ('C','resettrans','Reset Transaksi');

INSERT INTO capp (tp, code, name) VALUES ('H','userlog','User Log');
INSERT INTO capp (tp, code, name) VALUES ('H','datalog','Data Log');
INSERT INTO capp (tp, code, name) VALUES ('H','translog','Transaction Log');


-- table cusr
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'cusr') AND type in (N'U'))
DROP TABLE cusr
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE cusr (
	id 					INT IDENTITY(1,1) NOT NULL
	, code 				NVARCHAR(64) NOT NULL
	, name				NVARCHAR(128) NOT NULL
	, username			NVARCHAR(128) NOT NULL
	, pass				NVARCHAR(128) NOT NULL
	, showmenu			NVARCHAR(1)
	, id_mcost			INT
	--------------------------------
	, approver			NVARCHAR(1)
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)		
);

INSERT INTO cusr (code,name,username,pass,showmenu, id_mcost) VALUES ('admin','admin','admin',CONVERT(NVARCHAR(32),HASHBYTES('MD5', 'admin'),2), 'Y',1);

-- DEFAULT REGISTERED USERS
INSERT INTO cusr (code,name,username,pass,showmenu, id_mcost) VALUES ('dicky','dicky','dicky',CONVERT(NVARCHAR(32),HASHBYTES('MD5', '12345'),2), 'Y',1);
INSERT INTO cusr (code,name,username,pass,showmenu, id_mcost) VALUES ('tika','tika','tika',CONVERT(NVARCHAR(32),HASHBYTES('MD5', '12345'),2), 'Y',1);
INSERT INTO cusr (code,name,username,pass,showmenu, id_mcost) VALUES ('ria','ria','ria',CONVERT(NVARCHAR(32),HASHBYTES('MD5', '12345'),2), 'Y',1);
INSERT INTO cusr (code,name,username,pass,showmenu, id_mcost) VALUES ('adel','adel','adel',CONVERT(NVARCHAR(32),HASHBYTES('MD5', '12345'),2), 'Y',1);
INSERT INTO cusr (code,name,username,pass,showmenu, id_mcost) VALUES ('agustin','agustin','agustin',CONVERT(NVARCHAR(32),HASHBYTES('MD5', '12345'),2), 'Y',1);
INSERT INTO cusr (code,name,username,pass,showmenu, id_mcost) VALUES ('pauji','pauji','pauji',CONVERT(NVARCHAR(32),HASHBYTES('MD5', '12345'),2), 'Y',1);
INSERT INTO cusr (code,name,username,pass,showmenu, id_mcost) VALUES ('aho','aho','aho',CONVERT(NVARCHAR(32),HASHBYTES('MD5', '12345'),2), 'Y',1);
INSERT INTO cusr (code,name,username,pass,showmenu, id_mcost) VALUES ('tina','tina','tina',CONVERT(NVARCHAR(32),HASHBYTES('MD5', '12345'),2), 'Y',1);
INSERT INTO cusr (code,name,username,pass,showmenu, id_mcost) VALUES ('fauzi','fauzi','fauzi',CONVERT(NVARCHAR(32),HASHBYTES('MD5', '12345'),2), 'Y',1);


-- table cusrpriv
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'cusrpriv') AND type in (N'U'))
DROP TABLE cusrpriv
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE cusrpriv (
	id 					INT IDENTITY(1,1) NOT NULL
	, id_cusr			INT NOT NULL
	, id_capp			INT NOT NULL
	, code_capp			NVARCHAR(64) NOT NULL
	, name_capp			NVARCHAR(128) NOT NULL
	, canopen				NVARCHAR(1)
	, canadd				NVARCHAR(1)
	, canupdate				NVARCHAR(1)
	, candelete				NVARCHAR(1)
	, canprint				NVARCHAR(1)
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)		
);

INSERT INTO cusrpriv (id_cusr, id_capp, code_capp, name_capp, canopen, canadd, candelete, canupdate, canprint)
(SELECT TA.id, TB.id, TB.code, TB.name, 'Y', 'Y','Y','Y','Y' FROM cusr TA, capp TB);


-- TABLE csetting
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'csetting') AND type in (N'U'))
DROP TABLE csetting
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE csetting (
	id 					INT IDENTITY(1,1) NOT NULL
	, name				NVARCHAR(128) NOT NULL
	, intvl				INT DEFAULT 0
	, decvl				DECIMAL(19,6) DEFAULT 0 
	, strvl				NVARCHAR(256)
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

INSERT INTO csetting (name, intvl, decvl, strvl) VALUES ('jeniscompany','0','0','KAWASAN BERIKAT');
INSERT INTO csetting (name, intvl, decvl, strvl) VALUES ('company','0','0','SWIFECT');
INSERT INTO csetting (name, intvl, decvl, strvl) VALUES ('owner','0','0','SWIFECT');
INSERT INTO csetting (name, intvl, decvl, strvl) VALUES ('alamat','0','0','JAKARTA');
INSERT INTO csetting (name, intvl, decvl, strvl) VALUES ('noijintpb','0','0','');
INSERT INTO csetting (name, intvl, decvl, strvl) VALUES ('phone','0','0','');
INSERT INTO csetting (name, intvl, decvl, strvl) VALUES ('fax','0','0','');
INSERT INTO csetting (name, intvl, decvl, strvl) VALUES ('npwp','0','0','');
INSERT INTO csetting (name, intvl, decvl, strvl) VALUES ('negara','0','0','INDONESIA');
INSERT INTO csetting (name, intvl, decvl, strvl) VALUES ('logolocation','0','0','');
INSERT INTO csetting (name, intvl, decvl, strvl) VALUES ('decimal','2','0','');
INSERT INTO csetting (name, intvl, decvl, strvl) VALUES ('companycode','0','0','N');


-- TABLE hmstr
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'hmstr') AND type in (N'U'))
DROP TABLE hmstr
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE hmstr (
	id 					INT IDENTITY(1,1) NOT NULL
	, tbl				NVARCHAR(16) NOT NULL
	, idtbl				INT
	, notbl				NVARCHAR(64) 
	, act				NVARCHAR(8) NOT NULL -- new, upd, del
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE htrans
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'htrans') AND type in (N'U'))
DROP TABLE htrans
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE htrans (
	id 					INT IDENTITY(1,1) NOT NULL
	, tbl				NVARCHAR(16) NOT NULL
	, idtbl				INT
	, notbl				NVARCHAR(64) 
	, act				NVARCHAR(8) NOT NULL -- new, upd, del
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE huserlog
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'huserlog') AND type in (N'U'))
DROP TABLE huserlog
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE huserlog (
	id 					INT IDENTITY(1,1) NOT NULL
	, id_cusr			INT
	, code_cusr			NVARCHAR(64) NOT NULL
	, name_cusr			NVARCHAR(128) NOT NULL
	, act				NVARCHAR(8) NOT NULL -- LOGIN / LOGOUT
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE hconf
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'hconf') AND type in (N'U'))
DROP TABLE hconf
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE hconf (
	id 					INT IDENTITY(1,1) NOT NULL
	, tbl				NVARCHAR(16) NOT NULL
	, idtbl				INT
	, act				NVARCHAR(8) NOT NULL -- BARU, MODIF, HAPUS
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE mlocation
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'mlocation') AND type in (N'U'))
DROP TABLE mlocation
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE mlocation (
	id 					INT IDENTITY(1,1) NOT NULL								
	, code				NVARCHAR(64) NOT NULL
	, name				NVARCHAR(128) NULL
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

INSERT INTO mlocation (code, name) VALUES ('DEFAULT','LOKASI UTAMA');

-- TABLE maccount
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'maccount') AND type in (N'U'))
DROP TABLE maccount
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE maccount (
	id 					INT IDENTITY(1,1) NOT NULL								
	, code				NVARCHAR(64) NOT NULL
	, name			NVARCHAR(128) NULL
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE muom
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'muom') AND type in (N'U'))
DROP TABLE muom
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE muom (
	id 					INT IDENTITY(1,1) NOT NULL								
	, code				NVARCHAR(64) NOT NULL
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

INSERT INTO muom (code) VALUES ('PCS');
INSERT INTO muom (code) VALUES ('SET');
INSERT INTO muom (code) VALUES ('LITER');
INSERT INTO muom (code) VALUES ('GRAM');

-- TABLE mbrand
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'mbrand') AND type in (N'U'))
DROP TABLE mbrand
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE mbrand (
	id 					INT IDENTITY(1,1) NOT NULL								
	, code				NVARCHAR(64) NOT NULL
	, name			NVARCHAR(128) NULL
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

INSERT INTO mbrand (code, name) VALUES ('CH','CHANEL');
INSERT INTO mbrand (code, name) VALUES ('LV','LOUIS VUITTON');
INSERT INTO mbrand (code, name) VALUES ('FD','FENDI');
INSERT INTO mbrand (code, name) VALUES ('PR','PRADA');
INSERT INTO mbrand (code, name) VALUES ('TB','TORY BURCH');
INSERT INTO mbrand (code, name) VALUES ('GC','GUCCI');
INSERT INTO mbrand (code, name) VALUES ('HM','HERMES');

-- TABLE mconsignee
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'mconsignee') AND type in (N'U'))
DROP TABLE mconsignee
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE mconsignee (
	id 					INT IDENTITY(1,1) NOT NULL								
	, code				NVARCHAR(64) NULL
	, name				NVARCHAR(128) NULL
	, ktp				NVARCHAR(32) NULL
	, gender			NVARCHAR(32) NULL
	, hp1				NVARCHAR(32)
	, hp2				NVARCHAR(32)
	, norek				NVARCHAR(128)
	, alamat			NVARCHAR(128) NULL
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE mcust
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'mcust') AND type in (N'U'))
DROP TABLE mcust
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE mcust (
	id 					INT IDENTITY(1,1) NOT NULL								
	, code				NVARCHAR(64) NULL
	, name				NVARCHAR(128) NULL
	, gender			NVARCHAR(32) NULL
	, hp1				NVARCHAR(32)
	, hp2				NVARCHAR(32)
	, email				NVARCHAR(64)
	, socmed			NVARCHAR(64)
	, norek				NVARCHAR(128)
	, alamat			NVARCHAR(128) NULL
	--------------------------------
	, balance			DECIMAL(19,6) DEFAULT 0
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE msales
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'msales') AND type in (N'U'))
DROP TABLE msales
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE msales (
	id 					INT IDENTITY(1,1) NOT NULL								
	, code				NVARCHAR(64) NULL
	, name				NVARCHAR(128) NULL
	, gender			NVARCHAR(32) NULL
	, hp1				NVARCHAR(32)
	, hp2				NVARCHAR(32)
	, alamat			NVARCHAR(128) NULL
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE mcurr
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'mcurr') AND type in (N'U'))
DROP TABLE mcurr
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE mcurr (
	id 					INT IDENTITY(1,1) NOT NULL								
	, code				NVARCHAR(64) NOT NULL
	, name			NVARCHAR(128) NULL
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

INSERT INTO mcurr (code, name) VALUES ('IDR','Rupiah');
INSERT INTO mcurr (code, name) VALUES ('USD','Dollar');
INSERT INTO mcurr (code, name) VALUES ('SGD','Singapore Dollar');
INSERT INTO mcurr (code, name) VALUES ('HKD','HK Dollar');
INSERT INTO mcurr (code, name) VALUES ('AUD','Aus Dollar');
INSERT INTO mcurr (code, name) VALUES ('CNY','Chinese Yuan');
INSERT INTO mcurr (code, name) VALUES ('KRW','Korean Won');
INSERT INTO mcurr (code, name) VALUES ('JPY','Japanese Yen');


-- TABLE mitem
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'mitem') AND type in (N'U'))
DROP TABLE mitem
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE mitem (
	id 					INT IDENTITY(1,1) NOT NULL								
	, code				NVARCHAR(64) NOT NULL
	, name				NVARCHAR(256) NULL
	, dtconsign			DATETIME
	, code_mconsign		NVARCHAR(64) NULL
	, code_mtype		NVARCHAR(64) NULL
	, qty				DECIMAL(19,6) DEFAULT 0
	, code_muom			NVARCHAR(64) NULL
	, code_mbrand		NVARCHAR(64) NULL
	, code_mcurrb		NVARCHAR(64) NULL
	, hrgbeli			DECIMAL(19,6) DEFAULT 0
	, code_mcurrj		NVARCHAR(64) NULL
	, hrgjual			DECIMAL(19,6) DEFAULT 0
	, spek				NVARCHAR(MAX) NULL
	--------------------------------
	, color				NVARCHAR(64)
	, sze				NVARCHAR(32)
	, mtrl				NVARCHAR(64)
	--------------------------------
	, code_mlocation	NVARCHAR(64)
	--------------------------------
	, itemstatus		NVARCHAR(1) DEFAULT 'O'
	--------------------------------
	, basetype			NVARCHAR(8) DEFAULT 'ITEM'
	, basenum			NVARCHAR(128)
	--------------------------------
	, spec1          NVARCHAR(1) DEFAULT 'N' -- ORI BOX
	, spec2          NVARCHAR(1) DEFAULT 'N' -- ORI DUSTBAG
	, spec3          NVARCHAR(1) DEFAULT 'N' -- AUTHENTICITY CARD
	, spec4          NVARCHAR(1) DEFAULT 'N' -- MIRROR
	, spec5          NVARCHAR(1) DEFAULT 'N' -- BOOKLET
	, spec6          NVARCHAR(1) DEFAULT 'N' -- RECEIPT
	, spec7          NVARCHAR(1) DEFAULT 'N' -- STRAP
	, spec8          NVARCHAR(1) DEFAULT 'N' -- PADLOCK
	, spec9          NVARCHAR(1) DEFAULT 'N' -- KEY
	, spec10          NVARCHAR(1) DEFAULT 'N' -- DUST BAG PENGGANTI
	, spec11          NVARCHAR(1) DEFAULT 'N' -- CONTROL NUMBER
	, spec12          NVARCHAR(1) DEFAULT 'N' -- TAG
	, spec13          NVARCHAR(1) DEFAULT 'N' -- PAPER BAG
	, spec14          NVARCHAR(1) DEFAULT 'N' -- RAINCOAT
	, spec15          NVARCHAR(1) DEFAULT 'N' -- CAMELIA
	, spec16          NVARCHAR(1) DEFAULT 'N' -- RIBBON/PITA
	, spec17          NVARCHAR(1) DEFAULT 'N' -- SAMPLE LEATHER
	, spec18          NVARCHAR(1) DEFAULT 'N' -- COPY RECEIPT
	, spec19          NVARCHAR(1) DEFAULT 'N' -- LAP
	, notespec			NVARCHAR(256) -- LAIN2
	--------------------------------
	, stock			DECIMAL(19,6) DEFAULT 0
	--------------------------------
	, code_mvendor		NVARCHAR(64) NULL
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE mitempic
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'mitempic') AND type in (N'U'))
DROP TABLE mitempic
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE mitempic (
	id 					INT IDENTITY(1,1) NOT NULL								
	, code				NVARCHAR(64) NOT NULL
	--------------------------------
	, picOrder			INT
	, picName				NVARCHAR(128)
	, picData			IMAGE
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE mtype
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'mtype') AND type in (N'U'))
DROP TABLE mtype
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE mtype (
	id 					INT IDENTITY(1,1) NOT NULL								
	, code				NVARCHAR(64) NOT NULL
	, name				NVARCHAR(128) NULL
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

INSERT INTO mtype (code, name) VALUES ('BG','BAGS');
INSERT INTO mtype (code, name) VALUES ('JW','JEWELLERY');
INSERT INTO mtype (code, name) VALUES ('CL','CLOTHING');
INSERT INTO mtype (code, name) VALUES ('WT','WATCHES');
INSERT INTO mtype (code, name) VALUES ('AC','ACCESSORIES');
INSERT INTO mtype (code, name) VALUES ('SH','SHOES');
INSERT INTO mtype (code, name) VALUES ('SP','SUPLEMEN');

-- TABLE mvendor
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'mvendor') AND type in (N'U'))
DROP TABLE mvendor
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE mvendor (
	id 					INT IDENTITY(1,1) NOT NULL								
	, code				NVARCHAR(64) NOT NULL
	, name				NVARCHAR(128) NULL
	, phone				NVARCHAR(128) NULL
	, norek				NVARCHAR(128)
	, alamat			NVARCHAR(128) NULL
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE mcoatype
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'mcoatype') AND type in (N'U'))
DROP TABLE mcoatype
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE mcoatype (
	id 						INT IDENTITY(1,1) NOT NULL
	, code 					NVARCHAR(15) NOT NULL
	, name 					NVARCHAR(200) NOT NULL
	--------------------------------
	, rpttype			NVARCHAR(1)
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

INSERT INTO mcoatype (code, name, rpttype) VALUES ('1','AK..A', 'B');
INSERT INTO mcoatype (code, name, rpttype) VALUES ('2','KEWAJIBAN', 'B');
INSERT INTO mcoatype (code, name, rpttype) VALUES ('3','MODAL', 'B');
INSERT INTO mcoatype (code, name, rpttype) VALUES ('4','PENJUALAN', 'R');
INSERT INTO mcoatype (code, name, rpttype) VALUES ('5','HPP', 'R');
INSERT INTO mcoatype (code, name, rpttype) VALUES ('6','BIAYA OPERASIONAL','R');
INSERT INTO mcoatype (code, name, rpttype) VALUES ('7','PENDAPATAN LAIN-LAIN', 'R');

-- TABLE mcoa
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'mcoa') AND type in (N'U'))
DROP TABLE mcoa
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE mcoa (
	id 						INT IDENTITY(1,1) NOT NULL
	, code 					NVARCHAR(15) NOT NULL
	, name 					NVARCHAR(200) NOT NULL
	, name2 					NVARCHAR(200)
	, usename				NVARCHAR(1)
	, usename2				NVARCHAR(1)
	, category				INT
	-- ######################################
	, id_mcoatype			INT
	, id_mcoap				INT
	-- ######################################
	, active				NVARCHAR(1)
	, balance				DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, dc					INT
	, rpttype			NVARCHAR(1)
	, rptcattype			NVARCHAR(256)
	, rptcattype2			NVARCHAR(256)
	, bgnbalance			DECIMAL(19,6) DEFAULT 0
	--------------------------------
	-- ADD 24/06/2020
	, opbaldbrp			DECIMAL(19,6) DEFAULT 0
	, opbalcrrp			DECIMAL(19,6) DEFAULT 0
	, opbaldbva			DECIMAL(19,6) DEFAULT 0
	, opbalcrva			DECIMAL(19,6) DEFAULT 0
	--------------------------------
	, id_mcurr			INT
	, ctrlacc			NVARCHAR(1)
	, cashacc			NVARCHAR(1)
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);


-- TABLE tconsign
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tconsign') AND type in (N'U'))
DROP TABLE tconsign
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tconsign (
	id 						INT IDENTITY(1,1) NOT NULL	
	, no					NVARCHAR(64) NOT NULL
	, tdate					DATETIME NOT NULL
	, tdate2					DATETIME NOT NULL
	, docstat				NVARCHAR(64) DEFAULT 'O'
	-- ######################################
	, code_mconsignee		VARCHAR(64)
	, name_mconsignee		VARCHAR(128)
	, hp1					NVARCHAR(64)
	, hp2					NVARCHAR(64)
	, alamat				NVARCHAR(128) NULL
	, gender				NVARCHAR(32)
	, norek					NVARCHAR(128)
	, catat					NVARCHAR(256) NULL
	-- ######################################
	, code_mitem			NVARCHAR(128)
	, name_mitem			NVARCHAR(256)
	, code_mtype			NVARCHAR(64)
	, qty				DECIMAL(19,6) DEFAULT 0
	, code_muom			NVARCHAR(64)
	, code_mbrand			NVARCHAR(64)
	, spek_mitem			NVARCHAR(512) DEFAULT NULL
	-- ######################################
	, code_mcurrb				NVARCHAR(16)
	, hrgbeli					DECIMAL(19,6) DEFAULT 0
	, code_mcurrj				NVARCHAR(16)
	, hrgjual					DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tconsignpic
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tconsignpic') AND type in (N'U'))
DROP TABLE tconsignpic
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tconsignpic (
	id 					INT IDENTITY(1,1) NOT NULL								
	, no_tconsign		NVARCHAR(64)
	, code				NVARCHAR(64) NOT NULL
	--------------------------------
	, picOrder			INT
	, picName				NVARCHAR(128)
	, picData			IMAGE
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tpo
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tpo') AND type in (N'U'))
DROP TABLE tpo
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tpo (
	id 						INT IDENTITY(1,1) NOT NULL	
	, no					NVARCHAR(64) NOT NULL
	, tdate					DATETIME NOT NULL
	, tdate2					DATETIME NOT NULL
	, docstat				NVARCHAR(64) DEFAULT 'O'
	-- ######################################
	, code_mcust		VARCHAR(64)
	, name_mcust		VARCHAR(128)
	, hp1					NVARCHAR(64)
	, hp2					NVARCHAR(64)
	, alamat				NVARCHAR(128) NULL
	, gender				NVARCHAR(32)
	, norek					NVARCHAR(128)
	, catat					NVARCHAR(256) NULL
	-- ######################################
	, code_mitem			NVARCHAR(128)
	, name_mitem			NVARCHAR(256)
	, code_mtype			NVARCHAR(64)
	, qty				DECIMAL(19,6) DEFAULT 0
	, code_muom			NVARCHAR(64)
	, code_mbrand			NVARCHAR(64)
	, spek_mitem			NVARCHAR(512) DEFAULT NULL
	-- ######################################
	, code_mcurrb				NVARCHAR(16)
	, hrgbeli					DECIMAL(19,6) DEFAULT 0
	, code_mcurrj				NVARCHAR(16)
	, hrgjual					DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, payvia				NVARCHAR(128) NULL
	, inforek				NVARCHAR(128) NULL
	, tglbyr				DATETIME NOT NULL
	, dp				DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tpopic
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tpopic') AND type in (N'U'))
DROP TABLE tpopic
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tpopic (
	id 					INT IDENTITY(1,1) NOT NULL								
	, no_tpo		NVARCHAR(64)
	, code				NVARCHAR(64) NOT NULL
	--------------------------------
	, picOrder			INT
	, picName				NVARCHAR(128)
	, picData			IMAGE
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tinvj
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tinvj') AND type in (N'U'))
DROP TABLE tinvj
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tinvj (
	id 					INT IDENTITY(1,1) NOT NULL	
	, no				NVARCHAR(64) NOT NULL
	, tdate				DATETIME NOT NULL
	, code_mcust		NVARCHAR(64)
	, total				DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tinvjd
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tinvjd') AND type in (N'U'))
DROP TABLE tinvjd
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tinvjd (
	id 					INT IDENTITY(1,1) NOT NULL	
	, id_tinvjh		INT
	, no_tinvjh		NVARCHAR(64) NOT NULL
	, dsc				NVARCHAR(256) NOT NULL
	, qty				DECIMAL(19,6) DEFAULT 0
	, price				DECIMAL(19,6) DEFAULT 0
	, total				DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tpop
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tpop') AND type in (N'U'))
DROP TABLE tpop
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tpop (
	id 						INT IDENTITY(1,1) NOT NULL	
	, no					NVARCHAR(64) NOT NULL
	, tdate					DATETIME NOT NULL
	, docstat				NVARCHAR(64)
	, sales					NVARCHAR(128) NULL
	-- ######################################
	, code_mvendor			VARCHAR(64)
	, name_mvendor			VARCHAR(128)
	, hp1					NVARCHAR(64)
	, alamat				NVARCHAR(128) NULL
	, norek					NVARCHAR(128)
	-- ######################################
	, code_mitem			NVARCHAR(128)
	, name_mitem			NVARCHAR(256)
	, code_mtype			NVARCHAR(64)
	, qty					DECIMAL(19,6) DEFAULT 0
	, code_muom				NVARCHAR(64)
	, code_mbrand			NVARCHAR(64)
	, spek_mitem			NVARCHAR(512) DEFAULT NULL
	-- ######################################
	, code_mcurrb			NVARCHAR(16)
	, hrgbeli				DECIMAL(19,6) DEFAULT 0
	, code_mcurrj			NVARCHAR(16)
	, hrgjual				DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note					NVARCHAR(256)
	, tstatus				INT DEFAULT 1
	, createduser			INT 
	, createddate			DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 			INT
	, modifieddate			DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tpoppic
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tpoppic') AND type in (N'U'))
DROP TABLE tpoppic
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tpoppic (
	id 					INT IDENTITY(1,1) NOT NULL								
	, no_tpop		NVARCHAR(64)
	, code				NVARCHAR(64) NOT NULL
	--------------------------------
	, picOrder			INT
	, picName				NVARCHAR(128)
	, picData			IMAGE
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tinvoice
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tinvoice') AND type in (N'U'))
DROP TABLE tinvoice
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tinvoice (
	id 						INT IDENTITY(1,1) NOT NULL	
	, no					NVARCHAR(64) NOT NULL
	, tdate				DATETIME NOT NULL
	, tdate2				DATETIME NOT NULL
	, doctype			NVARCHAR(128) DEFAULT 'O'
	, sales					NVARCHAR(128) NULL
	, docstat				NVARCHAR(64)
	-- ######################################
	, code_mcust		VARCHAR(64)
	, name_mcust		VARCHAR(128)
	, hp1					NVARCHAR(64)
	, hp2					NVARCHAR(64)
	, alamat				NVARCHAR(128) NULL
	, gender				NVARCHAR(32)
	-- ######################################
	, no_tconsign				NVARCHAR(64)
	, code_mconsignee		VARCHAR(64)
	, code_mitem		VARCHAR(64)
	, name_mitem			NVARCHAR(128)
	, qty					DECIMAL(19,6) DEFAULT 0
	, code_mcurrb				NVARCHAR(32)
	, hrgbeli					DECIMAL(19,6) DEFAULT 0
	, code_mcurrj				NVARCHAR(32)
	, hrgjual					DECIMAL(19,6) DEFAULT 0
	, profit				DECIMAL(19,6) DEFAULT 0
	, profitbuyer				DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, payvia				NVARCHAR(128) NULL
	, inforek				NVARCHAR(128) NULL
	, tglbyr				DATETIME NOT NULL
	, dp				DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, sendby			NVARCHAR(128)
	, voucher			NVARCHAR(128)
	-- ######################################
	, grdtotal			DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tinvoicepic
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tinvoicepic') AND type in (N'U'))
DROP TABLE tinvoicepic
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tinvoicepic (
	id 					INT IDENTITY(1,1) NOT NULL								
	, no_tinvoice		NVARCHAR(64)
	, code				NVARCHAR(64) NOT NULL
	--------------------------------
	, picOrder			INT
	, picName				NVARCHAR(128)
	, picData			IMAGE
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tretinvoice
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tretinvoice') AND type in (N'U'))
DROP TABLE tretinvoice
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tretinvoice (
	id 						INT IDENTITY(1,1) NOT NULL	
	, no					NVARCHAR(64) NOT NULL
	, tdate				DATETIME NOT NULL
	, doctype			NVARCHAR(128) NULL
	, sales					NVARCHAR(128) NULL
	, docstat				NVARCHAR(64)
	, docstat2				NVARCHAR(64)
	-- ######################################
	, code_mcust		VARCHAR(32) NULL
	-- ######################################
	, no_tinvoice				NVARCHAR(64)
	-- ######################################
	, payvia				NVARCHAR(128) NULL
	, inforek				NVARCHAR(128) NULL
	, tglbyr				DATETIME NOT NULL
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tretinvoicepic
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tretinvoicepic') AND type in (N'U'))
DROP TABLE tretinvoicepic
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tretinvoicepic (
	id 					INT IDENTITY(1,1) NOT NULL								
	, no_tretinvoice		NVARCHAR(64)
	, code				NVARCHAR(64) NOT NULL
	--------------------------------
	, picOrder			INT
	, picName				NVARCHAR(128)
	, picData			IMAGE
	--------------------------------
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE trf
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'trf') AND type in (N'U'))
DROP TABLE trf
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE trf (
	id 						INT IDENTITY(1,1) NOT NULL	
	, no					NVARCHAR(64) NOT NULL
	, tdate					DATETIME NOT NULL
	, code_mlocationfr		NVARCHAR(64) NULL
	, code_mlocationto		NVARCHAR(64) NULL
	-- ######################################
	, code_mitem			NVARCHAR(128)
	, name_mitem			NVARCHAR(256)
	, code_mtype			NVARCHAR(64)
	, qty				DECIMAL(19,6) DEFAULT 0
	, code_muom			NVARCHAR(64)
	, code_mbrand			NVARCHAR(64)
	, spek_mitem			NVARCHAR(512) DEFAULT NULL
	, code_mconsignee		NVARCHAR(128)
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE topay
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'topay') AND type in (N'U'))
DROP TABLE topay
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE topay (
	id 					INT IDENTITY(1,1) NOT NULL	
	, no				NVARCHAR(64) NOT NULL
	, tdate			DATETIME NOT NULL
	, jenis				NVARCHAR(64)
	, code_maccount		NVARCHAR(64)
	-- ######################################
	, ongkir			DECIMAL(19,6) DEFAULT 0
	, total				DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE topayd
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'topayd') AND type in (N'U'))
DROP TABLE topayd
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE topayd (
	id 					INT IDENTITY(1,1) NOT NULL	
	, id_topayh			INT
	, no_topayh			NVARCHAR(64) NOT NULL
	, dsc				NVARCHAR(512) NULL
	-- ######################################
	, total				DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);


-- TABLE tpy
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tpy') AND type in (N'U'))
DROP TABLE tpy
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tpy (
	id 					INT IDENTITY(1,1) NOT NULL	
	, no				NVARCHAR(64) NOT NULL
	, tdate			DATETIME NOT NULL
	, paytype			NVARCHAR(64)
	, code_mcust				NVARCHAR(64)
	, code_maccount		NVARCHAR(64)
	-- ######################################
	, ongkirtotal			DECIMAL(19,6) DEFAULT 0
	, totalinv			DECIMAL(19,6) DEFAULT 0
	, total				DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tpyd
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tpyd') AND type in (N'U'))
DROP TABLE tpyd
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tpyd (
	id 					INT IDENTITY(1,1) NOT NULL	
	, id_tpyh			INT
	, no_tpyh			NVARCHAR(64) NOT NULL
	-- #####################################
	, doctype			NVARCHAR(8)
	, no_trans			NVARCHAR(64)
	, tdate_trans			NVARCHAR(64)
	, code_mcust		NVARCHAR(64)
	, code_mitem		NVARCHAR(64)
	, ongkir			DECIMAL(19,6) DEFAULT 0
	, grdtotal_trans		DECIMAL(19,6) DEFAULT 0
	, paytotal			DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);


-- TABLE tpc
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tpc') AND type in (N'U'))
DROP TABLE tpc
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tpc (
	id 					INT IDENTITY(1,1) NOT NULL	
	, no				NVARCHAR(64) NOT NULL
	, tdate			DATETIME NOT NULL
	, paytype			NVARCHAR(64)
	, code_mconsignee				NVARCHAR(64)
	, code_maccount		NVARCHAR(64)
	-- ######################################
	, totalinv			DECIMAL(19,6) DEFAULT 0
	, total				DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tpcd
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tpcd') AND type in (N'U'))
DROP TABLE tpcd
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tpcd (
	id 					INT IDENTITY(1,1) NOT NULL	
	, id_tpch			INT
	, no_tpch			NVARCHAR(64) NOT NULL
	-- #####################################
	, doctype			NVARCHAR(8)
	, no_trans			NVARCHAR(64)
	, tdate_trans			NVARCHAR(64)
	, code_mconsignee		NVARCHAR(64)
	, code_mitem		NVARCHAR(64)
	, grdtotal_trans		DECIMAL(19,6) DEFAULT 0
	, paytotal			DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);


-- TABLE tps
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tps') AND type in (N'U'))
DROP TABLE tps
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tps (
	id 					INT IDENTITY(1,1) NOT NULL	
	, no				NVARCHAR(64) NOT NULL
	, tdate			DATETIME NOT NULL
	, paytype			NVARCHAR(64)
	, code_mvendor				NVARCHAR(64)
	, code_maccount		NVARCHAR(64)
	-- ######################################
	, totalinv			DECIMAL(19,6) DEFAULT 0
	, total				DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tpsd
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tpsd') AND type in (N'U'))
DROP TABLE tpsd
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tpsd (
	id 					INT IDENTITY(1,1) NOT NULL	
	, id_tpsh			INT
	, no_tpsh			NVARCHAR(64) NOT NULL
	-- #####################################
	, doctype			NVARCHAR(8)
	, no_trans			NVARCHAR(64)
	, tdate_trans			NVARCHAR(64)
	, code_mvendor		NVARCHAR(64)
	, code_mitem		NVARCHAR(64)
	, grdtotal_trans		DECIMAL(19,6) DEFAULT 0
	, paytotal			DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE tts
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'tts') AND type in (N'U'))
DROP TABLE tts
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE tts (
	id 					INT IDENTITY(1,1) NOT NULL	
	, no				NVARCHAR(64) NOT NULL
	, tdate			DATETIME NOT NULL
	, paytype			NVARCHAR(64)
	, code_mvendor				NVARCHAR(64)
	, code_maccount		NVARCHAR(64)
	-- ######################################
	, totalinv			DECIMAL(19,6) DEFAULT 0
	, total				DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);

-- TABLE ttsd
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ttsd') AND type in (N'U'))
DROP TABLE ttsd
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE ttsd (
	id 					INT IDENTITY(1,1) NOT NULL	
	, id_ttsh			INT
	, no_ttsh			NVARCHAR(64) NOT NULL
	-- #####################################
	, doctype			NVARCHAR(8)
	, no_trans			NVARCHAR(64)
	, tdate_trans			NVARCHAR(64)
	, code_mvendor		NVARCHAR(64)
	, code_mitem		NVARCHAR(64)
	, grdtotal_trans		DECIMAL(19,6) DEFAULT 0
	, paytotal			DECIMAL(19,6) DEFAULT 0
	-- ######################################
	, note				NVARCHAR(256)
	, tstatus			INT DEFAULT 1
	, createduser		INT 
	, createddate		DATETIME DEFAULT CURRENT_TIMESTAMP
	, modifieduser 		INT
	, modifieddate		DATETIME
	, PRIMARY KEY (id)	
);