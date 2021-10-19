CREATE VIEW SystemJobHistoryIndexView AS
SELECT SJ.SystemJobDescription, SJH.DateExecuted, 
CASE SJH.AutoExecuted
    WHEN 0 THEN 'False'
    ELSE 'True'
END AS 'AutoExecuted'
FROM SystemJobHistories SJH
    INNER JOIN SystemJobs SJ ON SJH.SystemJobId = SJ.SystemJobId