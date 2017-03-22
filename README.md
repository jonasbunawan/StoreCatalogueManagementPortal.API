# StoreCatalogueManagementPortal.API
Initial Development

Thanks for looking up this application repository.
This program is made as opposed to TillPOS Programming Practice prior to staff employment.

Program Specification:
Store Catalogue Management Portal which allows user to operate CRUD process through the app for 3 basic entities/records
which are Category, SubCategory, and Product.

Database Configuration:
MongoDB 3.2
Installed on Windows 10 64-bit on Program Files folder.

DatabaseConfigurationFileContent (.cfg):
systemLog:
  destination: file
  path: c:\\mongodb\\data\\log\\mongod.log
storage:
  dbPath: c:\\mongodb\data\\db
  
  ConnectionString: mongodb://localhost:27017/
  DatabaseName: StoreCatalogueManagementPortal
  
  Complete Step-By-Step on how to prepare MongoDB database for the app can be found on:
  https://docs.mongodb.com/manual/tutorial/install-mongodb-on-windows/
  
  Basically, mongodb just needs to be ensurely installed and the program will take care of the rest in regards to database structure,
  unless if the corresponding programmer/tester wants to populate some data prior to using the program which can actually be done
  through GUI.
  
  Application Deployment:
  https://msdn.microsoft.com/en-us/library/dd483479(v=vs.100).aspx
  
  The program was developed in Visual Studio 2017 Community Edition.
  Testing can be done through built-in Visual Studio compiler which hosts the program through IIS Express Server
  and displays web app on browser(client).
  
  Further development needs to be done to completely transform the web app to RESTFUL program as it is now merely validated as RESTFUL.
  
  If there is any enquiries, please feel free to send a message to the following e-mail address: jonas_bun@yahoo.com
  
  Regards,
  JB
