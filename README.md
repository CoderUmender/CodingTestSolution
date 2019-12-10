# CodingTestSolution
Solution for Coding Test Excesses

Solution  layers.

CodingTest.Sln,
  CodingTest.BAL:

  CodingTest.DAL,
  CodingTest.ServerAPI,
  Codingtest.Test
  
  Deployment Steps (Manual)
  
  1) UI- Angular 
  
  Build Generation 
  
  Place Prod/non Prod API Urls in Envormnent files
                environment.ts --Non prod
                environment.prod.ts ---Prod
  
  
  FOr Generating   Angular Build Please run Below Commands In Angular CLI
        1) ng build ------> Non prod
        2) ng build --prod .....> Prod
    
    Build Files will be generated in Dist Folder Under  Solution
    
   
        Deplyment:
        
        Take all the files from Dist folder and place it IIS Or any other Webserver
        
   2) Server API
   
Build generation:

Before generating Build,please run All the Unit test methods from test project 
if all the methods  succeed Folow below Buid& deployee  files .
 
Right Click on Api project and click on Publish 
Give The Path to generate Published files from Visual Studio

Replace Connection string in Web.config .

Take the published files from local path And Deploy the files to server (IIS).

make sure We have to allow UI Url from API,if bothe wer deplyed in diffrent Domains.


3)Configure Requires settings in Webserver inorder to provide Access for the Api From UI app



     
  
