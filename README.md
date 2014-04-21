My-Mail-Drive
=============


Intra-communication mail system for any organization and also provide storage drive for each user.

Pre-requisite Tools and Technology
* visual studio 2010
* Microsoft SQL Server 2008
  
After installing above software
* Microsoft SQL Server 2008
1.	Create new Database
2.	Restore .bak file means backup file in database, .bak file placed at ProjMailDrive/sql, use latest updated .bak file.

* Project Settings in Visual studio
1.	Now change web.cong file which is XML Configuration file, it placed    at ProjMailDrive. Open file and modify it for database settings

<appSettings>
    <add key="ServerName" value="."/>
    <add key="UserName" value="sa"/>
    <add key="Password" value=""/>
    <add key="DataBaseName" value="myMail"/>
  </appSettings>
Modify above tag value as per your MS SQl Server settings.
