CREATE VIEW SystemJobIndexView AS

SELECT SJ.SystemJobId, SJ.SystemJobDescription, SJ.ProcedureName, 
CASE SJ.AutoRunOnStartUp WHEN 1 THEN 'True' ELSE 'False' END AS 'AutoRunOnStartUp',
(SELECT MAX(SJH.DateExecuted) FROM SystemJobHistories AS SJH WHERE SJH.SystemJobId = SJ.SystemJobId) AS 'DateLastExecuted'
FROM SystemJobs SJ