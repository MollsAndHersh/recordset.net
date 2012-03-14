![logo](https://bitbucket.org/christianspecht/recordset.net/raw/tip/img/logo64x64.png)

Recordset.Net is a library to convert .NET POCOs to ADODB.Recordsets.  
For version 1.0, it will only support converting **from** lists of POCOs **to** read-only Recordsets, not vice-versa.  
*(converting to Recordsets is the only thing **I** need at the moment)*

## Links

- [Main Project page on Bitbucket](https://bitbucket.org/christianspecht/recordset.net)
- [Download page](https://bitbucket.org/christianspecht/recordset.net/downloads)

## How to build

Just run `build.bat` in the main folder. This will create a new folder named `release` with the compiled assembly.  
To run the unit tests as well, run `build-and-run-tests.bat` (also in the main folder). The `release` folder will not be created if the tests fail.  
You can also run `build-release.bat` to do all of the above **and** create a NuGet package (in the `release` folder) as well.


### Acknowledgements

Recordset.Net makes use of the following open source projects:

 - [xUnit.net](http://xunit.codeplex.com/)
 - [NuGet](http://nuget.codeplex.com/)
 - [MSBuild Community Tasks](http://msbuildtasks.tigris.org/)
 
### License

Recordset.Net is licensed under the MIT License. See [License.txt](https://bitbucket.org/christianspecht/recordset.net/raw/tip/License.txt) for details.