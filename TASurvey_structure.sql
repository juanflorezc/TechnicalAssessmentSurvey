/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : SQL Server
 Source Server Version : 13005026
 Source Host           : DESKTOP-5GILTJU\SQLEXPRESS:1433
 Source Catalog        : TASurvey
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 13005026
 File Encoding         : 65001

 Date: 25/12/2020 18:53:04
*/


-- ----------------------------
-- Table structure for question
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[question]') AND type IN ('U'))
	DROP TABLE [dbo].[question]
GO

CREATE TABLE [dbo].[question] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [text] nvarchar(200) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [updated] timestamp  NOT NULL
)
GO

ALTER TABLE [dbo].[question] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for question_order
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[question_order]') AND type IN ('U'))
	DROP TABLE [dbo].[question_order]
GO

CREATE TABLE [dbo].[question_order] (
  [question_id] int  NOT NULL,
  [survey_id] int  NOT NULL,
  [order] int  NOT NULL
)
GO

ALTER TABLE [dbo].[question_order] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for respondent
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[respondent]') AND type IN ('U'))
	DROP TABLE [dbo].[respondent]
GO

CREATE TABLE [dbo].[respondent] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] nvarchar(50) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [hashedpassword] nvarchar(100) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [email] nvarchar(254) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [created] timestamp  NOT NULL
)
GO

ALTER TABLE [dbo].[respondent] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for response
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[response]') AND type IN ('U'))
	DROP TABLE [dbo].[response]
GO

CREATE TABLE [dbo].[response] (
  [survey_response_id] int  NOT NULL,
  [question_id] int  NOT NULL,
  [respondent_id] int  NOT NULL,
  [answer] nvarchar(100) COLLATE Modern_Spanish_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[response] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for survey
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[survey]') AND type IN ('U'))
	DROP TABLE [dbo].[survey]
GO

CREATE TABLE [dbo].[survey] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] nvarchar(50) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [description] nvarchar(1000) COLLATE Modern_Spanish_CI_AS  NULL,
  [updated] timestamp  NOT NULL
)
GO

ALTER TABLE [dbo].[survey] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for survey_response
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[survey_response]') AND type IN ('U'))
	DROP TABLE [dbo].[survey_response]
GO

CREATE TABLE [dbo].[survey_response] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [survey_id] int  NOT NULL,
  [respondent_id] int  NOT NULL,
  [updated] timestamp  NOT NULL
)
GO

ALTER TABLE [dbo].[survey_response] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- View structure for responses
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[responses]') AND type IN ('V'))
	DROP VIEW [dbo].[responses]
GO

CREATE VIEW [dbo].[responses] AS SELECT         dbo.survey.name as survey, dbo.question.text as question,	dbo.respondent.name AS respondent, dbo.response.answer
FROM            dbo.question INNER JOIN
                         dbo.question_order ON dbo.question.id = dbo.question_order.question_id INNER JOIN
                         dbo.respondent ON dbo.question.id = dbo.respondent.id INNER JOIN
                         dbo.response ON dbo.question.id = dbo.response.question_id AND dbo.respondent.id = dbo.response.respondent_id INNER JOIN
                         dbo.survey ON dbo.question_order.survey_id = dbo.survey.id INNER JOIN
                         dbo.survey_response ON dbo.respondent.id = dbo.survey_response.respondent_id AND dbo.response.survey_response_id = dbo.survey_response.id AND dbo.survey.id = dbo.survey_response.survey_id
GO


-- ----------------------------
-- Procedure structure for prc_getSurvey
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[prc_getSurvey]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[prc_getSurvey]
GO

CREATE PROCEDURE [dbo].[prc_getSurvey]	
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT s.name as survey, q.text as question
	FROM survey s
	INNER JOIN question_order qr on qr.survey_id=s.id
	INNER JOIN question q on q.id=qr.question_id
	ORDER BY qr.[order]
END
GO


-- ----------------------------
-- Procedure structure for proc_setreOrder
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_setreOrder]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[proc_setreOrder]
GO

CREATE PROCEDURE [dbo].[proc_setreOrder]
	@QuestionID int, 
	@Order int
AS
BEGIN
	SET NOCOUNT ON;
	update question_order set [order]=@Order where question_id=@QuestionID;
	select * from question_order;
END
GO


-- ----------------------------
-- Primary Key structure for table question
-- ----------------------------
ALTER TABLE [dbo].[question] ADD CONSTRAINT [PK_question] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Triggers structure for table question_order
-- ----------------------------
CREATE TRIGGER [dbo].[sp_reorder]
ON [dbo].[question_order]
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE, DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select question_id,survey_id, ROW_NUMBER() over(PARTITION BY survey_id  order by survey_id) n
	into #order
	from question_order
	group by question_id,survey_id
	
	update question_order
	set question_order.[order]=tab.n
	from #order as tab
	inner join question_order on question_order.question_id=tab.question_id and question_order.survey_id=tab.survey_id

END
GO


-- ----------------------------
-- Primary Key structure for table question_order
-- ----------------------------
ALTER TABLE [dbo].[question_order] ADD CONSTRAINT [PK_question_order] PRIMARY KEY CLUSTERED ([question_id], [survey_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table respondent
-- ----------------------------
ALTER TABLE [dbo].[respondent] ADD CONSTRAINT [PK_respondent] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table response
-- ----------------------------
ALTER TABLE [dbo].[response] ADD CONSTRAINT [PK_response] PRIMARY KEY CLUSTERED ([survey_response_id], [question_id], [respondent_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table survey
-- ----------------------------
ALTER TABLE [dbo].[survey] ADD CONSTRAINT [PK_survey] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table survey_response
-- ----------------------------
ALTER TABLE [dbo].[survey_response] ADD CONSTRAINT [PK_survey_response] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table question_order
-- ----------------------------
ALTER TABLE [dbo].[question_order] ADD CONSTRAINT [fk_question_order_question_1] FOREIGN KEY ([question_id]) REFERENCES [dbo].[question] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[question_order] ADD CONSTRAINT [fk_question_order_survey_1] FOREIGN KEY ([survey_id]) REFERENCES [dbo].[survey] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table response
-- ----------------------------
ALTER TABLE [dbo].[response] ADD CONSTRAINT [fk_response_survey_response_1] FOREIGN KEY ([survey_response_id]) REFERENCES [dbo].[survey_response] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[response] ADD CONSTRAINT [fk_response_question_1] FOREIGN KEY ([question_id]) REFERENCES [dbo].[question] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[response] ADD CONSTRAINT [fk_response_respondent_1] FOREIGN KEY ([respondent_id]) REFERENCES [dbo].[respondent] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table survey_response
-- ----------------------------
ALTER TABLE [dbo].[survey_response] ADD CONSTRAINT [fk_survey_response_survey_1] FOREIGN KEY ([survey_id]) REFERENCES [dbo].[survey] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[survey_response] ADD CONSTRAINT [fk_survey_response_respondent_1] FOREIGN KEY ([respondent_id]) REFERENCES [dbo].[respondent] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

