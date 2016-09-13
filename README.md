# RESTier-DI-Sample
This is a simple, self-contained example of the right way to do Dependency Injection in a .NET app. 
It also explains the different ways that RESTier's implementation is incorrect.

This example is fully-functional. Just clone the repo, open in VS, and hit F5, and you should be taken to a working
sample, backed by a database with a single table.

Only files tha are absolutely necessary to execute the application are included. If you search for `"@robertmclaws:"`,
you'll find my commentary on the different sections and whether or not they are following best practices.

NOTE: Please see `Startup.cs` for how registration *SHOULD* take place, and `\Controllers\UnusedSampleController.cs` for
notes on why the current implementation is bad form.