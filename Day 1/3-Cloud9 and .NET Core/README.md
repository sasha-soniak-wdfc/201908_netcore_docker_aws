<img src="../../img/logo.png" alt="Chmurowisko logo" width="200" align="right">
<br><br>
<br><br>
<br><br>

# Cloud9 and .NET Core

## LAB Overview

#### This lab will whow you how to set up Cloud9 IDE for NET.Core.

#### This lab will demonstrate:
 * Prepating Cloud9 development environment

## Task 1. Prepare Cloud9 environment

In this task you will prepare Cloud9 devevlopment environment to work on your project.

1. In the AWS Management Console, on the **Services** menu, click **Cloud9**.
2. Click **Create environment**.
3. Enter a name for your environment, e.g. "student-x-environment".
4. Click **Next step**.
5. As "Environment type" select *Create a new instance for environment (EC2)*.
6. Select *t2.micro* as "Instance type".
![Cloud9](img/cloud9_settings.png)
7. Select *Amazon Linux* as **Platform**.
8. Set **Cost-saving setting** to *After 30 minutes (default)*.


IMPORTANT!!!
If you have already made your own VPC and want to use this environment inside this VPC:
* Unwind **Network settings (advanced)**
* Select your VPC
* SELECT **PUBLIC** SUBNET!!!

9. Click **Next step**.
10. Review your environment and click **Create environment**.

## Task 2. Installing required tools.

In this task you will install toole required to work with NET.Core

11. Check if thhere is NET.Core already installed on the machine by typing following command in the terminal window

```
dotnet --version
```

If the version is less than 2.0, or if an error such as bash: ``dotnet: command not found`` is displayed, continue on to install the .NET Core 2 SDK.

12. Run the following commands to help ensure the latest security updates and bug fixes are installed, and to install a libunwind package that the .NET Core 2 SDK needs
```
sudo yum -y update
sudo yum -y install libunwind
```

13. Download the .NET Core 2 SDK installer script into your environment by running the following command.
```
curl -O https://dot.net/v1/dotnet-install.sh
```
14. Make the installer script executable by the current user by running the following command.
```
sudo chmod u=rx dotnet-install.sh
```
15. Run the installer script, which downloads and installs the .NET Core 2 SDK, by running the following command.
```
./dotnet-install.sh -c Current
```

16. Add the .NET Core 2 SDK to your PATH. Run following command
```
nano ~/.bashrc
```
17. Move to the line that starts with export PATH. Add the **$HOME/.dotnet** subdirectory to the PATH variable by typing :$HOME/.dotnet. The line should now look similar to the following.

``
export PATH=$PATH:$HOME/.local/bin:$HOME/bin:$HOME/.dotnet
``

18. Save the file by pressing **CTRL+X** and press **Y** and enter to save file .

19. Load the .NET Core 2 SDK by running the following command.
```
. ~/.bashrc
```

20. Confirm the .NET Core 2 SDK is loaded by running .NET Core CLI
```
dotnet --help
```
If successful, the .NET Core 2 SDK version number is displayed, with additional usage information.


## END LAB

<br><br>
