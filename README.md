# TruckManager

The objective of this project is to allow an user to manage truck models and trucks, following some rules.

After downloading this code, there are some ways to run this app, I will exemplify 2:
1. Run it directly from Visual Studio, this is the simplest way to do that.

2. You can open a powershel prompt and navigate to the TruckManager.Web project folder <%SolutionFolder%>/src/TruckManager.Web, there you can run the command: 
dotnet publish -p:PublishProfile=FolderProfile -o bin\publish -f netcoreapp3.1
It will generate the Release version of the application under <%SolutionFolder%>/src/TruckManager.Web/bin/publish, navigate to this folder and execute the TruckManager.Web.exe file. If everything went fine, you will geta message that the application is listening port 5000 --> Now listening on: http://localhost:5000 <--
open your favorite browser and paste that url to the address bar.

Now that you have it up and running, you will see that the interface is very simple and  intuitive, there are the links on the top-right to navigate to Truck and TruckModel pages


I hope everything is clear, if not, please, don't hesitate to get in touch.

Regards...
Elton Foggiatto
