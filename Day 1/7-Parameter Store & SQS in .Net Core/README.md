<img src="../../img/logo.png" alt="Chmurowisko logo" width="200" align="right">
<br><br>
<br><br>
<br><br>

# Parameter Store & SQS

## LAB Overview


## Task 1: Starting development environment
In this task you will start your Cloud9 environment.

1. Open your exixsting **Cloud9** environment. 
2. Verify that *dotnet* is already installed by typing following command:
```
dotnet --help
```
If successful, the .NET Core 2 SDK version number is displayed. If the version is less than 2.0, or if an error such as bash: ``dotnet: command not found`` is displayed, install the .NET Core 2 SDK. 

## Task 2. Creating console .NET Core app

In this task you will create simple console application.

3. Enter your environment dictionary by typing:
```
cd ~/environment/
```
4. Create and enter a new directory:
```
mkdir parameterstoreapp
cd parameterstoreapp
```
5. Create a .NET Core console application project:
```
dotnet new console -lang C#
```

## Task 4. Reading parameters from Parameter Store

In this task you will add AWS SDK to your application. Next, you add code to create a bucket, delete the bucket you just created, and then list your available buckets.

6. Still in your application directory type following command into your terminal window
```
dotnet add package AWSSDK.SimpleSystemsManagement
```

For the names and versions of other AWS related packages in NuGet, see [NuGet packages tagged with aws-sdk](https://www.nuget.org/packages?q=Tags%3A%22aws-sdk%22) on the NuGet website.

7. From the Environment window in the AWS Cloud9 IDE, open the Program.cs file. In the editor, replace the file's  contents with the [Program.cs file](Program1.cs), and then save the Program.cs file.

8. Run the project. In the terminal window enter
```
dotnet run
```
and press *ENTER*.

You read two parameters from *Parameter Store*:
* a bucket name
* SQS queue URL.

## END LAB

<br><br>

<center><p>&copy; 2019 Chmurowisko Sp. z o.o.<p></center>
