
@set name=%date%

@set ngay=%date:~0,2%

del /a D:\PROJECT\DataBase\BK\GNKDT_%ngay%.BAK

SQLCMD -S . -Q"BACKUP DATABASE tanhoa TO DISK = 'D:\PROJECT\DataBase\BK\GNKDT_%ngay%.BAK' WITH STATS = 1"
pause

