<img src="../../img/logo.png" alt="Chmurowisko logo" width="200" align="right">
<br><br>
<br><br>
<br><br>

# Creating Parameter Store params using Cloudformation

## LAB Overview

#### In this lab you will create the two AWS CloudFormation users. Both assigned to groups. The admin group with all privileges to CloudFormation the user group with "read" privileges.

## Task 1: Creating Cloud formation stack

1. Download and save [main.yaml](template.yaml) file. 
2. On the **Services** menu, click **Cloud Formation**.
3. Click **Create stack**.
4. Select **Upload a template to Amazon S3**.
5. Upload *template.yaml* you downloaded in step 1.
6. Click **Next**.
7. Enter a name for the stack: *student-X-cfstack*.
8. Enter admin and user passwords.
9. Click *Next**.
10. Click **Next**.
11. Check the checkmark **I acknowledge that AWS CloudFormation might create IAM resources.**.
12. Click **Create**.
<br><br>

Wait until stack is in state **CREATE_COMPLETE**.

## Task 2. Review Events, Outpust, Resources etc.

1. Find your stack and click on its name.
2. Look into sections:
    * Outputs
    * Resources
    * Events
    * Parameters


## END LAB

<center><p>&copy; 2019 Chmurowisko Sp. z o.o.<p></center>