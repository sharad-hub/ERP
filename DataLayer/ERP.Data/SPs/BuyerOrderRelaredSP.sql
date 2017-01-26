-- =============================================

-- Author:		<Author,,Name>

-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
 
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetFreeQuantityOnOrder] 
 @ProductQuantity int,
 @ProductId int
 --@BuyerId int
AS
BEGIN
if(@ProductQuantity < 50)
begin
Select 50 as FreeQuantityUnitValue,2 as FreeQuantity
end
else
begin
Select 50 as FreeQuantityUnitValue,10 as FreeQuantity
end
END
 
 
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetOrderDetails] 
 @OrderId int
AS
BEGIN
Select 'OrderID_12345' as OrderNumber,1 as OrderStatusId,'Order Entered by Buyer' as OrderStatus
END