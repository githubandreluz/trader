#Trader

This implementation is a code challenge requested by GFT.
The mission of this project is receive a list of trades as an input and give back a list of string categorizing the risk of each trade considering specific rules. 
This project assumes that any rule can be added or removed any time, and the code was written with that in mind I developed my own validation that can be scalable in the future.

#Question 1 : About Architecture and Design Pattern (C# Object-oriented programming)
    - Developed a console application in .Net 6.0
    - Using DDD Design Pattern
    - Dependency Injection
    - IoC
    - Unit Tests
    - Integration Tests

 #User interface: 
    ![UserInterface](https://lh3.google.com/u/0/d/1i8M3cwCvmldmyarpvMydjGLAl-hmsRft=w1920-h890-iv1)
    
#Tests:
    ![Tests](https://lh3.google.com/u/0/d/1MqlX414b55_DkvlECnXB5zZmV5YymbJI=w1920-h890-iv1)

#How to run: 
        - Fill the file "inputFile_Portifolio.json" (located on application root) with the desired data, press F5 on Visual Situdio.
        
#Question 2 (Procedural T-SQL to solve the same problem)
    - The T-SQL can be found here (https://gitlab.com/gitlabandre/trader/-/blob/master/QUESTION%202%20-%20PROCEDURAL%20VERSION/T-SQL%20-%20Procedural%20Solution%20(Question%202).sql) including the script to create tables, inserts, function and the SQL procedure.
    #How to run: 
        - Download the SQL file located on the link above
        - Execute a creation scripting selecting all code from the begin until this commentary "--TO EXECUTE SELECT FROM THIS LINE UNTIL THE END" , after execute the creation script, select the code from this commentary "--TO EXECUTE SELECT FROM THIS LINE UNTIL THE END" until the end and execute the script.
        - The script will insert all json data into the trade table and categorize each one of the trades.



