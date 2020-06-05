## Project: **Week 12 Code Review - Pierre's Sweet and Savory Treats**
#### Author: **Christopher Huber**
## Goal: Build Many-to-Many database with Authentication

### Github page: https://github.com/CHuber42/Fri-5-29-Code-Review
#### Github repo: You're standing on it.
##### Copyright Christopher Huber, 2020

&nbsp;
     
&nbsp;
         
##### Build instructions/Installation: 

This project is built in C# 8.0 using .netcoreapp2.2 on a system running Ubuntu 18.04.
Dependencies are declared in the HairSalon.csproj and HairSalon.Tests.csproj files in their respective folders.
.NetCoreApp 2.2 Framework is required.

To install, simply clone (or download) this folder into a new directory, git bash to PSST.Solution/PSST/ folder,
and run dotnet restore.

To run: either build the project using dotnet build and run the .exe, or navigate to the
PSST.Solution/PSST/ folder in a terminal and enter "dotnet run"

##### MySQL Setup Instructions

##### Development Description:

The application should have user authentication. A user should be able to log in and log out. Only logged in users should have create, update and delete functionality. All users should be able to have read functionality.   
There should be a many-to-many relationship between Treats and Flavors. A treat can have many flavors (such as sweet, savory, spicy, or creamy) and a flavor can have many treats. For instance, the "sweet" flavor could include chocolate croissants, cheesecake, and so on.   
A user should be able to navigate to a splash page that lists all treats and flavors. Users should be able to click on an individual treat or flavor to see all the treats/flavors that belong to it.    

##### Development specs/Phases:

Phase 1: Build models folder. Components: "Treat" class w/ "TreatId", "Name", "List of Join Entities" attribute. Same for "Flavor" class. Then add 
Join entity class with "JoinEntityId", "TreatId", "Treat class object", "FlavorId", "Flavor class object" in it. Each Join entity represents 1 edge
between a flavor and a treat. Also add db context model. (Done? YES)

Phase 2: Add Controller infrastructure for Routes (Index/Create/Edit/Delete/Details) in Treats and Flavors controllers. (Done? YES)   

Phase 3: Flesh out P2 controllers with DB accesses (Done? YES)  

Phase 4: Add views/forms in views for Treats and Flavors to navigate through basic functionality (Authorization comes later) (Done? YES)   

Phase 5: Add Join Table Routes + Views (Done? NO)   

Phase 6: 


##### Stretch Goals 

** Add Nav Bar

##### _Contact_:

CHuber42.Gmail.com

##### _Copyright Christopher Huber 2020, all rights reserved._







