# Recordset.Net

Recordset.Net is a library to convert .NET POCOs to ADODB.Recordsets.  
For version 1.0, it will only support converting **from** lists of POCOs **to** read-only Recordsets, not vice-versa.  
*(converting to Recordsets is the only thing **I** need at the moment)*


## How to build

Just run **build.bat** in the main folder. This will create a new folder named **release** with the compiled assembly.  
To run the unit tests as well, run **build-and-run-tests.bat** (also in the main folder). The **release** folder will not be created if the tests fail.


### Acknowledgements

Recordset.Net makes use of the following open source projects:

 - [xUnit.net](http://xunit.codeplex.com/)
 
### License

Recordset.Net is licensed under the MIT License. See [License.txt](https://bitbucket.org/christianspecht/recordset.net/raw/tip/License.txt) for details.