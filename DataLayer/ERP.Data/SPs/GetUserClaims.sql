-- =============================================

-- Author:		<Author,,Name>

-- Create date: <Create Date,,>

-- Description:	<Description,,>

-- =============================================

ALTER PROCEDURE GetUserClaims

	@UserEmail nvarchar(50)

AS

SELECT UR.USERID as UserID , UR.UserReferenceID as UserReferenceID, UT.TypeCode  as UserType ,UT.[UrlContextID] ,

UC.[AreaName],uc.[ControllerName],uc.[ActionName] ,

( SELECT US.[Value] WHERE US.[Key]='THEME' AND US.UserID=UR.UserID) as ThemeSkin

 FROM [dbo].[Users] UR

INNER JOIN [dbo].[UserTypes] UT(NOLOCK) ON UT.[ID]=UR.UserTypeID

INNER JOIN  [dbo].[UrlContexts] UC(NOLOCK) on UC.[UrlContextID]=UT.[UrlContextID]

LEFT OUTER JOIN [dbo].[SystemSettingMaster] US(NOLOCK) ON US.UserID =UR.UserID 

 WHERe UR.[Email]=@UserEmail
