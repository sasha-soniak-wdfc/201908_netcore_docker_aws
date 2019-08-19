<img src="../../img/logo.png" alt="Chmurowisko logo" width="200" align="right">
<br><br>
<br><br>
<br><br>

# AWS Roles and Access Keys using .NET Core

## LAB Overview

#### In this lab you will learn how to use IAM Roles and other credentials to authenticate SDK calls.

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
mkdir app1
cd app1
```
5. Create a .NET Core console application project:
```
dotnet new console -lang C#
```

## Task 3. Building and running the code.

In this tak you will add both builder and runner to your Cloud9 IDE. Then you will run the app.

6. On the Cloud9 menu, choose **Run*, **Build System**, **New Build System**.
7. On the *My Builder.build* tab, replace the tab's contents with the following code.
```
{
  "cmd" : ["dotnet", "build"],
  "info" : "Building..."
}
```
8. Click **File**, **Save As*.
9. For **Filename**, type *.NET Core.build*.
10. For **Folder**, type */.c9/builders*.
11. Click **Save**.
12. With the contents of the *Program.cs* file displayed in the editor, click **Run**, **Build System, .NET Core**. Then choose **Run**, **Build**.
13. On the menu bar, choose **Run*, **Run With**, **New Runner**.
14. On the **My Runner.run** tab, replace the tab's contents with the following code.
```
{
  "cmd" : ["dotnet", "run", "$args"],
  "working_dir": "$file",
  "info" : "Running..."
}
```
15. Choose **File**, **Save As**.
16. For **Filename**, type *.NET Core.run*.
17. For **Folder**, type */.c9/runners*.
18. Choose Save.
19. Run the application
* With the contents of the *Program.cs* file displayed in the editor, choose **Run** -> **Run With** -> **.Net Core**. If you have any error change CWD dirctory.

## Task 4. Adding AWS SDK and a new code

In this task you will add AWS SDK to your application. Next, you add code to create a bucket, delete the bucket you just created, and then list your available buckets.

20. Still in your application directory type following command into your terminal window
```
dotnet add package AWSSDK.S3
```

For the names and versions of other AWS related packages in NuGet, see [NuGet packages tagged with aws-sdk](https://www.nuget.org/packages?q=Tags%3A%22aws-sdk%22) on the NuGet website.

21. From the Environment window in the AWS Cloud9 IDE, open the Program.cs file. In the editor, replace the file's  contents with the [Program.cs file](Program.cs), and then save the Program.cs file.

22. Build the project. To do this, with the contents of the *Program.cs* file displayed in the editor, on the menu bar, click **Run**, **Build**.
23. Run the application with the name of the Amazon S3 bucket to create and the ID of the AWS Region to create the bucket in (for example, my-studentX-bucket and eu-west-1) as follows:
* With the contents of the *Program.cs* file still displayed in the editor, choose **Run**, **Run Configurations**, **New Run Configuration**.
24. In the [New] - Idle tab, choose **Runner: Auto**, and then choose **.NET Core**.
25. In the Command box, type the name of the application, the name of the Amazon S3 bucket to create, and the ID of the AWS Region to create the bucket in (for example, *app1 my-studentX-test-bucket eu-west-1*). 
26. Choose Run.

## Task 5. Removing temporary creddentials.

In this task you will remove temporary credentials that Cloud9 environment handles for you and will try running the app without any privileges.

27. Click **Cloud9** menu and **Preferences**.
28. Unwind **AWS Settings** section.
29. Turn off **AWS managed temporary credentials**

![img](img/cloud9_credentials.png)

30. Try running the app again by clicking **Run** button.

![img](img/cloud9_run.png)

Now, you should get an error. Your app can't authhenticate to AWS API.

## Task 6. Creating EC2 instance role.

In this task you will add a role to the VM. This Role grants permission to get a list of S3 buckets and create and delete a S3 bucket. With this role you will be able to perform those operations using AWS SDK.

31. In the **AWS Management Console**, on the **Services** menu, click **IAM**.
32. In the navigation pane on the left, click **Roles**.
33. Click **Create role**.
34. For Select type of trusted entity choose the *EC2 service*.
35. Click Next:Permissions.

You can choose one or more policies that are already created. Policies with the orange icon are created by AWS (called AWS Managed policies).  For our lab you will create a new Policy from scratch.

36. Click Create policy.
37. Switch to JSON tab, download [policy file](policy.json) and paste its content as policy definition:
```
{
    "Version": "2012-10-17",
    "Statement": [
        {
            "Effect": "Allow",
            "Action": [
                "s3:ListAllMyBuckets",
                "s3:CreateBucket",
                "s3:DeleteBucket"
            ],
            "Resource": "*"
        }
    ]
}
```

38. Click **Review policy**.
39. Enter a name for the policy StudentX-EC2-S3-Policy.
40. Click **Create policy**.
41. Switch back to the create role window and press Refresh and in the Search box search for you policy.
42. Select your policy and click **Next:Tags**.
43. Click **Next: Review**.
44. Enter a name for the Role: StudentX-EC2-S3Role.
45. Click **Create role**.

## Task 7. Assign role to your EC2

In this task you will assign an IAM Role to your Cloud9 EC2 instance and will try running the app again.

46. In the AWS Management Console, on the Services menu, click **EC2**.
47. In the navigation pane on the left, click **Instances**.
48. Select your Cloud9 instance and press **Action**.
49. Go to **Instance Settings** and choose **Attach/Replace IAM Role**.
50. Select your IAM role and press **Apply**.
51. Go back to your Cloud9 terminal window.
52. Check if IAM Role is assigned to instance: ``curl http://169.254.169.254/latest/meta-data/iam/info/``

As a result you will get an InstanceProfileArn with a name of your IAM Role. This is an example of using instance metadata to get the configuration details about your machine.

53. Run the application again by clicking **Run Last** button

![img](img/run_last.png)

Now the app should work as expected.
54. Remove the role from the instance by:
* Select your Cloud9 instance and press **Action**.
* Go to **Instance Settings** and choose **Attach/Replace IAM Role**.
* Select *No Role** and press **Apply**.
* Click **Yes, detach**.

## Task 8. In this task you will use user credentials to connect S3 client to AWS APIs.

55. On the Services menu, click IAM.
56. Click Users
57. Select your user
58. Go to Security credentials
59. Click Create access key
60. Save in notepad Access key ID and Secret access key

You can view Secret access key only once if you forgot it you must generate new key.

61. From the Environment window in the AWS Cloud9 IDE, open the *Program.cs* file. In the editor, replace the file's  contents with the [new Program.cs file](Program_credentials.cs), and then save the Program.cs file.

62. Replace the values of the access key and secret key id with yours
```
private static string ACCESS_KEY = "AKIAZRF5IZXNO4LDURE4";
private static string SECRET_KEY_ID = "sslCThVyxsVKs5N/j+F2lmXlcPVIXPr1FA60x0GG";
```
63. Look into line 34 of the code
```
s3Client = new AmazonS3Client(ACCESS_KEY, SECRET_KEY_ID, bucketRegion);
```
Now you use your credentials to connect to AWS API.

## END LAB

<br><br>

<center><p>&copy; 2019 Chmurowisko Sp. z o.o.<p></center>
