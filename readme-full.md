![logo](https://bitbucket.org/christianspecht/recordset.net/raw/tip/img/logo64x64.png)

Recordset.Net is a library to convert .NET POCOs to ADODB.Recordsets.  
For version 1.0, it will only support converting **from** lists of POCOs **to** read-only Recordsets, not vice-versa.  
*(converting to Recordsets is the only thing **I** need at the moment)*

---

## Links

- [Main Project page on Bitbucket](https://bitbucket.org/christianspecht/recordset.net)
- [Download page](https://bitbucket.org/christianspecht/recordset.net/downloads)
- [NuGet gallery](https://nuget.org/packages/Recordset.Net)

---

## Setup

You can either download Recordset.Net from the download page on Bitbucket (link above) or install with [NuGet](https://nuget.org/):

[![NuGet](https://bitbucket.org/christianspecht/recordset.net/raw/tip/img/nuget.png)](https://nuget.org/packages/Recordset.Net)

Please note that in order to use Recordset.Net, you need to add a COM reference to "Microsoft ActiveX Data Objects 2.8 Library" to your project.  
*(you need to add the reference yourself **even if you use NuGet** to install - apparently it's not possible to add COM references with NuGet, so I couldn't do it in the package)*

---

## How to use

Recordset.Net provides a single extension method to `IEnumerable<T>`, which is named `.ToRecordset()`.  
This will convert any `IEnumerable<T>` into an `ADODB.Recordset`, **but only if `T` is a custom class with user defined properties**.  
If you try to use `.ToRecordset()` on something like an `IEnumerable<string>` or `IEnumerable<int>`, then Recordset.Net will throw an `ArgumentException`.

Each property of the POCO will be converted into a field in the Recordset, but only if its type is supported by ADO. POCO properties with types unsupported by ADO will be omitted. You can see a list of the supported CLR types and their ADO counterparts [in the code](https://bitbucket.org/christianspecht/recordset.net/src/tip/src/Recordset.Net/DataTypes.cs).

#### Example

Given this POCO:

    class SomePoco
    {
        public int NumericValue { get; set; }
        public string StringValue { get; set; }
    }

Convert it to a Recordset:

    var list = new List<SomePoco>();
    list.Add(new SomePoco { NumericValue = 1, StringValue = "foo" });

    var rs = list.ToRecordset();

Get values from the Recordset after the conversion:

    var value = rs.Fields["StringValue"].Value;

For more examples, you can [take a look at the tests](https://bitbucket.org/christianspecht/recordset.net/src/tip/src/Recordset.Net.Tests/IEnumerableToRecordsetTests.cs).

---

## How to build

Just run `build.bat` in the main folder. This will create a new folder named `release` with the compiled assembly.  
To run the unit tests as well, run `build-and-run-tests.bat` (also in the main folder). The `release` folder will not be created if the tests fail.  
You can also run `build-release.bat` to do all of the above **and** create a NuGet package and a zip file (in the `release` folder) as well.

---

### Acknowledgements

Recordset.Net makes use of the following open source projects:

 - [xUnit.net](http://xunit.codeplex.com/)
 - [NuGet](http://nuget.codeplex.com/)
 - [MSBuild Community Tasks](https://github.com/loresoft/msbuildtasks)

---

### License

Recordset.Net is licensed under the MIT License. See [License.txt](https://bitbucket.org/christianspecht/recordset.net/raw/tip/License.txt) for details.