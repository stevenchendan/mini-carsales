# mini-carsales

## 1. Background:

This is a mini-carsales website. Provide car management(add new, update, delete). In the future It needs to support more vehicle types(bikes, boats...)

## 2. Frameworks:
Back-end:
* .Net Core 2.2

Front-end: 
* React
* Ant Design
* Axios
* Webpack
* Bootstrap


## 3. How to run:

Visual Studio(preferred):  

I recommend to use visual studio because you can directly open the solution file and then click **F5** to run the project.

VS Code: 

Step 1: cd ClientApp
```
cd mini-carsales\MiniCarsales\ClientApp
```

Step 2: 

```
npm install
```

Step 3(go back to upper level): 

```
cd mini-carsales\MiniCarsales\
```


Step 4: 

```
dotnet run
```



## 4. How to use:
1. **Create** new car allow you to create cars by providing the valid information
2. **Delete** will delete car from memory
3. **Update** can update existing car information by providing valid information

![car](https://i.ibb.co/frrXqf7/Create-vehicle.png)

![uml](https://i.ibb.co/LrZ8dBQ/uml.png)

## 5. Unit Tests

High coverage percentage. Currently cover all the functions in service, repository and controller.

## 6. Recommended improvements:

Given time limitation. Here are some improvement suggestion:

- Add More Defensive code
- Add more unit tests
- Add integration test
- use async/await
- Add logging
- Support batch upload(from .csv file)
- Separate front-end and back-end into two applications
- Paging(improve performance)
- Provide filter and sorting at cars table