My-Mail-Drive
=============


Intra-communication mail system for any organization and also provide storage drive for each user.

>Pre-requisite Tools and Technology

* [Visual studio 2010](http://www.microsoft.com/en-in/download/details.aspx?id=23507)
* [Microsoft SQL Server 2008] (http://www.microsoft.com/en-in/download/details.aspx?id=12548)
  
After installing above software
>In Microsoft SQL Server 2008

1. Create new Database
2. Restore .bak file means backup file in database, .bak file placed at ProjMailDrive/sql directory, use latest updated .bak file.

>In Visual studio

1. Now change web.cong file which is XML Configuration file, it placed    at ProjMailDrive directory. Open file and modify it for database settings
<pre>
<code>
`<appSettings>
    <add key="ServerName" value="."/>
    <add key="UserName" value="sa"/>
    <add key="Password" value=""/>
    <add key="DataBaseName" value="myMail"/>
  </appSettings>`
</code>
</pre>
Modify above tag value as per your MS SQl Server settings.

>Use Tools and Technology in Project
* HTML,HTML5,CSS3 and jQuery for front and designing
* [Bootstrap3](http://getbootstrap.com/) for responsive frontend designing
* [CkEdter](http://docs.cksource.com/CKEditor_3.x/Developers_Guide/ASP.NET/Integration_Beginners) for well formated Mail writting
