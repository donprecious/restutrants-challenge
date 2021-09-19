
# Read Me  
 This project contains two task  
- Task 1. 
    A program that takes JSON-formatted opening hours of a restaurant as  an input and outputs hours in more human readable format 
- Task 2 
    Inverse Permutation

## Task 1 
    A program that takes JSON-formatted opening hours of a restaurant as  an input and outputs hours in more human readable format 
    
### Input  
Input JSON consist of keys indicating days of a week and corresponding opening hours as  values.  
One JSON file includes data for one restaurant.  
{  
<dayofweek>: <opening hours>  
<dayofweek>: <opening hours>  
  ....
}  

<dayofweek> : monday / tuesday / wednesday / thursday / friday / saturday / sunday  <opening hours>: an array of objects containing opening hours. Each object consists  of two keys: type: open or close  
value: opening / closing time as UNIX time (1.1.1970 as a date)

### Payload example 
```
{
    "monday": [],
    "tuesday": [
        {"type": "open", "value": 36000},
        {"type": "close", "value": 64800}
    ],
    "wednesday": [],
    "thursday": [
        {"type": "open", "value": 36000},
        {"type": "close", "value": 64800}
    ],
    "friday": [
        {"type": "open", "value": 36000}
    ],
    "saturday": [
        {"type": "close", "value": 3600},
        {"type": "open", "value": 36000}
    ],
    "sunday": [
        {"type": "close", "value": 3600},
        {"type": "open", "value": 43200},
        {"type": "close", "value": 75600}
    ]
} 
```

### Response 
```
{
  "Sunday": "1:00 PM - 10:00 PM ",
  "Monday": "closed",
  "Tuesday": "11:00 AM - 7:00 PM ",
  "Wednesday": "closed",
  "Thursday": "11:00 AM - 7:00 PM ",
  "Friday": "11:00 AM - 1:00 AM ",
  "Saturday": "11:00 AM - 2:00 AM "
}
```
## Projects and Structure for Task 1 
1. ResturantsOpenApi - This is the presentation layer of the project, and houses the api , which is on ResturantController
 2. ResturantsOpenLibrary - This is the domain layer which includes models, utility, and services 
 3. Tests.ResturantsOpen - This is the Test Project which includes unit tests of models and services from ResturantsOpenLibrary, it uses xunit and moq 
 
## HOW TO RUN  API ResturantsOpenApi 
 1. Clone the Repo 
 2. Restore Packages running ```dotnet restore``` 
 3. Build and ResturantsOpenApi project  
 
## HOW TO RUN  API Tests.ResturantsOpen 
 1. After cloning the repo
 2. Restore Packages running ```dotnet restore``` 
 3. Build and Tests.ResturantsOpen project  
 
## Thoughts About Request Data Structure 
The current data format is not that bad, and can be easily seen as a dictionary where the key is the day and value is the array,  such as ``` Dictionary<string, List<object>> ``` ,  
Combinatation of Dictionary, LinkedList, List data structures allowed to come up with an optimal solution 
of time complexity of O(n) . 
But other request data structure , such as 
``` 
{ day: "monday", 
  events : [
    {type: "open", value: 3600},
    {type: "close", value: 3600}
] } 
```  
or even simplified as 
``` 
{ day: "monday", 
  events : [
    {type: "open", value: 8:00},
    {type: "close", value: 13:00}
] } 
```  

## Projects and Structure for Task 2
1. InversePermutation  - This contain a console application with a class that does the Inverse Permutation 
2. Tests.InversePermutation - This is the Test Project which includes unit tests for various inputs and outputs against the method implemented on InversePermutation
