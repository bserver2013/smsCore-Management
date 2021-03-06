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
	M.ID,   
    M.ReferenceNo,  
    M.Account_Number,  
    M.Group_Name,  
    M.Family_Name,  
    M.First_Name,  
    M.Town,  
    M.Sponsor_ID,
	B.TotalBalance
FROM SMS_Members AS M 
INNER JOIN (
SELECT
	W1.account, 
	(
		SUM(W1.amount) - (
		SELECT SUM(W2.amount) 
		FROM [SMS_VirtualMoney] AS W2
		INNER JOIN SMS_Members AS M2
		ON W2.account = M2.CP_Number
		WHERE W2.[type] = 22)
	) AS TotalBalance

FROM [SMS_VirtualMoney] AS W1
INNER JOIN SMS_Members AS M1
ON W1.account = M1.CP_Number
WHERE W1.[type] = 21
GROUP BY W1.account
) AS B

ON M.CP_Number = B.account
ORDER BY DateReg;


--SELECT 

--(
--	SUM(amount)  --// Get Total Desosit
--	- --// Substract 
--	(
--		SELECT 
--			SUM(amount) 
--		FROM [SMS_VirtualMoney] 
--		WHERE [type] = 22 AND [account] = '09173254062'
--	) -- // Get Total Widthraw 

--) AS TotalBalance --// Total Remaining Balance
  
--FROM [SMS_VirtualMoney]
--WHERE [type] = 21 AND [account] = '09173254062';
