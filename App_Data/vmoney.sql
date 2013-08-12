SELECT 
	account AS 'Account', 
	RefId0.[name] AS 'Type', 
	RefId1.[name] AS 'Status', 
	[datetime] AS 'DateTime'
FROM [SMS_VirtualMoney] AS vMoney
INNER JOIN [SMS_ReferenceId] AS RefId0
ON vMoney.[type] = RefId0.id
INNER JOIN [SMS_ReferenceId] AS RefId1
ON vMoney.[status] = RefId1.id
WHERE [account] = '09173254062';


SELECT 

(
	SUM(amount)  --// Get Total Desosit
	- --// Substract 
	(
		SELECT 
			SUM(amount) 
		FROM [SMS_VirtualMoney] 
		WHERE [type] = 22 AND [account] = '09173254062'
	) -- // Get Total Widthraw 

) AS TotalBalance --// Total Remaining Balance
  
FROM [SMS_VirtualMoney]
WHERE [type] = 21 AND [account] = '09173254062';

