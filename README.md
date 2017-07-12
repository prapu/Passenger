# Passenger
Passenger data
=======================
This codebase uses VS2015, ASP.NET MVC/C#, WebApi/C#, SQL2012 or higher, AngularJs, Bootstrap

How to setup the application
----------------------------
Download the code base and extract into a folder.
Create a DB named MyDeal and run the DB script (Mydeal-table-script.sql)

Update the connection string settings based on your sql server settings. These settings are in the Data project app.config and 
WebApi project web.config.

Create local IIS vertual folders using WebApi property page and ASP.NET Web solution property page.

If required, restore packages and build the solution. 

In your browser type http://localhost/MyDeal.PNL.Web/ then you will be presented with a UI to upload passenger data, search passenger data, list passenger data.

You can copy your text file contents into the textbox given in the dialog box and hit the upload button. Once upload is completed you will be notified with a success message.

Once upload is completed you can perform search, list operations.
